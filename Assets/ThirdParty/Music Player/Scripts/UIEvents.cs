using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class UIEvents : MonoBehaviour
{
    private MusicPlayer musicPlayer;

    void Start()
    {
        GameObject musicPlayerGameObject = GameObject.Find("MusicPlayer");
        if (musicPlayerGameObject != null)
            musicPlayer = musicPlayerGameObject.GetComponent<MusicPlayer>();
    }

    public void PlayButtonEvent()
    {
        if (musicPlayer.Playing && !musicPlayer.Interrupted)
        {
            musicPlayer.PauseAudioClip();
        }
        else if (!musicPlayer.Playing && musicPlayer.Interrupted)
        {
            musicPlayer.PlayAudioClip();
        }
    }

    public void StopButtonEvent()
    {
        musicPlayer.StopAudioClip();
    }

    public void SoundButtonEvent()
    {
        if (musicPlayer.Muted)
        {
            musicPlayer.UnMuteAudioClip();
        }
        else
        {
            musicPlayer.MuteAudioClip();
        }
    }

    public void RepeatButtonEvent()
    {
        musicPlayer.ToggleLoop();
    }

    public void NextButtonEvent()
    {
        musicPlayer.NextAudioClip();
    }

    public void BackButtonEvent()
    {
        musicPlayer.PreviousAudioClip();
    }

    public void SoundLevelSliderPotentialDrag()
    {
        musicPlayer.UnMuteAudioClip();
    }

    public void MusicSliderClick()
    {
        if (musicPlayer.Playing)
        {
            musicPlayer.clickBeganOnMusicSlider = false;
            musicPlayer.PlayAudioClipAtTime(musicPlayer.musicSlider.value);
        }
    }

    public void MusicSliderPotentialDrag()
    {
        musicPlayer.clickBeganOnMusicSlider = true;
    }

    public void MusicSliderEndDrag()
    {
        if (musicPlayer.clickBeganOnMusicSlider)
        {
            musicPlayer.clickBeganOnMusicSlider = false;
            if (musicPlayer.Playing)
            {
                musicPlayer.PlayAudioClipAtTime(musicPlayer.musicSlider.value);
            }
        }
    }
}