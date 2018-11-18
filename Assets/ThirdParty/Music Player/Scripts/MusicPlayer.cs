using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// Set the audio clip.
    /// </summary>
    /// <param name="audioClip">The Audio clip.</param>
    public void SetAudioClip(AudioClip audioClip)
    {
        this.currentAudioClip = audioClip;
        audioSource.clip = audioClip;




    }

    /// <summary>
    /// Play the audio clip at time.
    /// </summary>
    /// <param name="time">time in seconds.</param>
    public void PlayAudioClipAtTime(float time)
    {
        skipPlay = false;
        //Avoid error execution result 
        if (!(time >= 0 && time < currentAudioClip.length))
        {
            time = 0;
            skipPlay = true;
        }

        playButtonImage.sprite = pauseIcons;
        Interrupted = false;
        audioSource.time = time;

        if (skipPlay)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Play the audio clip.
    /// </summary>
    public void PlayAudioClip()
    {
        playButtonImage.sprite = pauseIcons;
        Interrupted = false;
        skipPlay = false;
        //Avoid error execution result 
        if (!(musicSlider.value >= 0 && musicSlider.value < currentAudioClip.length))
        {
            musicSlider.value = 0;
            skipPlay = true;
        }
        audioSource.time = musicSlider.value;

        if (skipPlay)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Pause the audio clip.
    /// </summary>
    public void PauseAudioClip()
    {
        playButtonImage.sprite = playIcons;
        Interrupted = true;
        audioSource.Pause();
    }

    /// <summary>
    /// Stop the audio clip.
    /// </summary>
    public void StopAudioClip()
    {
        Interrupted = true;
        playButtonImage.sprite = playIcons;
        audioSource.Stop();
        audioSource.time = 0;
        SetMusicSliderValue();
    }

    /// <summary>
    /// Mute the audio clip.
    /// </summary>
    public void MuteAudioClip()
    {
        soundButtonImage.sprite = soundIcons[3];
        Muted = true;
        audioSource.mute = true;
    }

    /// <summary>
    /// Unmute the audio clip.
    /// </summary>
    public void UnMuteAudioClip()
    {
        soundButtonImage.sprite = soundIcons[0];
        Muted = false;
        audioSource.mute = false;
    }

    /// <summary>
    /// Toggles the audio source loop.
    /// </summary>
    public void ToggleLoop()        // 改成重来
    {
        PlayAudioClipAtTime(0);
    }


    /// <summary>
    ///Play the next audio clip
    /// </summary>
    public void NextAudioClip()
    {
        if (currentClipIndex + 1 > 0 && currentClipIndex + 1 < L_AudioClip.Count)
        {
            if (musicInfoAnimator != null)
            {
                musicInfoAnimator.SetTrigger("Toggle");
            }
            SetUpAudioClip(currentClipIndex + 1, !Interrupted);
        }
    }

    /// <summary>
    /// Play the previous audio clip.
    /// </summary>
    public void PreviousAudioClip()
    {
        if (currentClipIndex - 1 >= 0 && currentClipIndex - 1 < L_AudioClip.Count)
        {
            musicInfoAnimator.SetTrigger("Toggle");
            SetUpAudioClip(currentClipIndex - 1, !Interrupted);
        }
    }







    public bool Muted                // 是否静音 播放
    { get; private set; }


    public bool Playing              // 是否播放中
    {
        get { return this.audioSource.isPlaying; }
    }
    public bool Interrupted         // 是否被中断
    { get; private set; }





    //————————————————————————————————————


    /// <summary>
    /// The audio source reference.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// The total time of the audio clip.
    /// </summary>
    private string totalTime = "00:00"; // 总时间

    /// <summary>
    /// The index of the current clip.
    /// </summary>
    [HideInInspector] public int currentClipIndex; // 第几个音频的索引

    /// <summary>
    /// Whether a click down on the music player .
    /// </summary>
    private bool musicPlayerClickDown;


    /// <summary>
    /// The music time.
    /// </summary>
    public MusicTime musicTime;

    /// <summary>
    /// The sound level slider reference.
    /// </summary>
    public Slider soundLevelSlider;

    /// <summary>
    /// The music slider reference.
    /// </summary>
    public Slider musicSlider;

    /// <summary>
    /// The audio clips references.
    /// </summary>
    public List<AudioClip> L_AudioClip = new List<AudioClip>();


    /// <summary>
    /// The current audio clip.
    /// </summary>
    private AudioClip currentAudioClip;

    /// <summary>
    /// The sound icons references.
    /// </summary>
    public Sprite[] soundIcons;


    /// <summary>
    /// The play icons references.
    /// </summary>
    public Sprite playIcons;

    /// <summary>
    /// The pause icons references.
    /// </summary>
    public Sprite pauseIcons;

    /// <summary>
    /// The repeat button image reference.
    /// </summary>
    public Image repeatButtonImage;

    /// <summary>
    /// The repeat button image reference.
    /// </summary>
    public Image soundButtonImage;

    /// <summary>
    /// The play button image reference.
    /// </summary>
    public Image playButtonImage;

    /// <summary>
    /// Whether to play the first audio clip on start.
    /// </summary>
    public bool playOnStart = true;

    /// <summary>
    /// Whether to skip audio playing
    /// </summary>
    private bool skipPlay;

    /// <summary>
    /// The music info animator.
    /// </summary>
    public Animator musicInfoAnimator;

    /// <summary>
    /// Whether the click began on music slider or not.
    /// </summary>
    [HideInInspector] public bool clickBeganOnMusicSlider;


    /// <summary>
    /// Set the value of music slider.
    /// </summary>
    private void SetMusicSliderValue()
    {
        musicSlider.value = audioSource.time;
    }


    /// <summary>
    /// Set up the audio clip for the audio source.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="playClip">If set to true , play the clip.</param>
    private void SetUpAudioClip(int index, bool playClip)
    {
        if (!(index >= 0 && index < L_AudioClip.Count))
        {
            return;
        }

        currentClipIndex = index;
        currentAudioClip = L_AudioClip[index];
        if (currentAudioClip != null)
        {
            musicSlider.minValue = 0;
            musicSlider.maxValue = currentAudioClip.length;
            totalTime = MusicTime.TimeToString(currentAudioClip.length);
        }
        else
        {
            Debug.Log("AudioClip is undefined");
        }
        audioSource.clip = currentAudioClip;
        StopAudioClip();
        if (playClip)
        {
            PlayAudioClip();
        }
    }



    void Start()
    {
        //Setting up the references
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (soundLevelSlider == null)
        {
            soundLevelSlider = GameObject.FindGameObjectWithTag("SoundLevelSlider").GetComponent<Slider>();
        }

        if (musicSlider == null)
        {
            musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        }

        if (musicTime == null)
        {
            musicTime = GameObject.FindGameObjectWithTag("MusicTime").GetComponent<MusicTime>();
        }


        //Set sound level slider boundary
        soundLevelSlider.minValue = 0;
        soundLevelSlider.maxValue = 1;

        //Set the initial audio clip
        SetUpAudioClip(0, playOnStart);
        audioSource.clip = currentAudioClip;
    }

    void Update()
    {
        if (!audioSource.isPlaying && !Interrupted)
        {
            StopAudioClip();
        }

        if (audioSource.isPlaying)
        {
            if (!clickBeganOnMusicSlider)
            {
                SetMusicSliderValue();
            }
        }

        //Set time of the audio clip
        musicTime.SetTime(musicSlider.value, totalTime);
        //Set the sound volume
        audioSource.volume = soundLevelSlider.value;
    }
}