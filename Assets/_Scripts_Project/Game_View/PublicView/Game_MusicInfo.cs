using System.IO;
using PSPUtil;
using PSPUtil.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class Game_MusicInfo : SubUI 
{
    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<Text,FileInfo,bool>(E_GameEvent.ShowMusicInfo, E_Show);
        MyEventCenter.AddListener(E_GameEvent.CloseMusicInfo, E_Close);
        MyEventCenter.AddListener<float>(E_GameEvent.ChangeAudioVolumeing, E_OnChangeAudioVolume);
        MyEventCenter.AddListener<float>(E_GameEvent.ChangeAudioVolumeEnd, E_OnChangeAudioVolumeEnd);


        mAudioSource = mUITransform.parent.Find("AudioSource").GetComponent<AudioSource>();

        // 音乐控制
        go_ShowMusic = GetGameObject("ShowMusic/MusicContrl");
        tx_InfoName = Get<Text>("ShowMusic/MusicContrl/Top/TxName");
        tx_Time = Get<Text>("ShowMusic/MusicContrl/Top/TxTime");
        go_Play = GetGameObject("ShowMusic/MusicContrl/Bottom/Play");
        go_Pause = GetGameObject("ShowMusic/MusicContrl/Bottom/Pause");
        AddButtOnClick("ShowMusic/MusicContrl/Bottom/Play", Btn_OnPlay);
        AddButtOnClick("ShowMusic/MusicContrl/Bottom/Pause", Btn_OnPause);
        AddButtOnClick("ShowMusic/MusicContrl/Bottom/Stop", Btn_OnStop);
        AddButtOnClick("ShowMusic/MusicContrl/BtnOpenFolder", Btn_OpenFolder);
        slider_Progress = Get<Slider>("ShowMusic/MusicContrl/Bottom/SliderProgress");
        SliderEvent sliderEvent = Get<SliderEvent>("ShowMusic/MusicContrl/Bottom/SliderProgress");
        sliderEvent.E_OnDrag += E_OnSliderDrag;
        sliderEvent.E_OnDragEnd += E_OnSliderDragEnd;
        dt4_Volume = Get<DTToggle4_Fade>("ShowMusic/MusicContrl/Bottom/Volume/Icon");
        slider_Volume = Get<Slider>("ShowMusic/MusicContrl/Bottom/Volume/Slider");

        AddSliderOnValueChanged(slider_Volume, (value) =>
        {
            MyEventCenter.SendEvent(E_GameEvent.ChangeAudioVolumeing, value);
        });
        Get<SliderEvent>("ShowMusic/MusicContrl/Bottom/Volume/Slider").E_OnDragEnd += () =>
        {
            MyEventCenter.SendEvent(E_GameEvent.ChangeAudioVolumeEnd, slider_Volume.value);
        };
        // 等待
        go_Wait = GetGameObject("Wait");
        tx_WaitName = Get<Text>("Wait/Middle/TxName");

        // 导入
        go_DaoRu = GetGameObject("ShowMusic/DaoRu");
        tx_DR1 = Get<Text>("ShowMusic/DaoRu/Contant/Btn1/TxSingleDR");
        tx_DR2 = Get<Text>("ShowMusic/DaoRu/Contant/Btn2/TxSingleDR");
        tx_DR3 = Get<Text>("ShowMusic/DaoRu/Contant/Btn3/TxSingleDR");
        tx_DR4 = Get<Text>("ShowMusic/DaoRu/Contant/Btn4/TxSingleDR");
        tx_DR5 = Get<Text>("ShowMusic/DaoRu/Contant/Btn5/TxSingleDR");

        AddButtOnClick("ShowMusic/DaoRu/Contant/Btn1", () =>
        {
            ManyBtn_DaoRu(EAudioType.EasyMusic);
        });
        AddButtOnClick("ShowMusic/DaoRu/Contant/Btn2", () =>
        {
            ManyBtn_DaoRu(EAudioType.BGM);
        });
        AddButtOnClick("ShowMusic/DaoRu/Contant/Btn3", () =>
        {
            ManyBtn_DaoRu(EAudioType.Effect);
        });
        AddButtOnClick("ShowMusic/DaoRu/Contant/Btn4", () =>
        {
            ManyBtn_DaoRu(EAudioType.Click);
        });
        AddButtOnClick("ShowMusic/DaoRu/Contant/Btn5", () =>
        {
            ManyBtn_DaoRu(EAudioType.Perple);
        });
        AddButtOnClick("ShowMusic/BtnClose", Btn_OnClickClose);

    }


    public void OnUpdate()
    {
        if (mAudioSource.isPlaying)
        {
            if (!isOnSliderChange)
            {
                slider_Progress.value = mAudioSource.time;
            }
            tx_Time.text = mAudioSource.time.ToTiemStr() + " / " + mTotalTime;
        }
    }


    #region 私有

    private GameObject go_Wait, go_ShowMusic;
    private Text tx_WaitName,tx_InfoName,tx_Time;
    private GameObject go_Play,go_Pause;
    private AudioSource mAudioSource;
    private Slider slider_Progress,slider_Volume;
    private DTToggle4_Fade dt4_Volume;
    private string mTotalTime;
    private bool isOnSliderChange = false;


    private GameObject go_DaoRu;
    private Text tx_DR1, tx_DR2, tx_DR3, tx_DR4, tx_DR5;



    public override string GetUIPathForRoot()
    {
        return "Right/MusicInfo";
    }



    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }



    #endregion


    private void Btn_OnClickClose()              // 点击关闭
    {
        Btn_OnStop();
        MyEventCenter.SendEvent(E_GameEvent.CloseMusicInfo);
    }


    private void Btn_OnPlay()                    // 点击播放
    {
        mAudioSource.Play();
        go_Play.SetActive(false);
        go_Pause.SetActive(true);
    }


    private void Btn_OnPause()                  // 点击暂停
    {
        mAudioSource.Pause();
        go_Play.SetActive(true);
        go_Pause.SetActive(false);
    }



    private void Btn_OnStop()                  // 点击停止 
    {
        mAudioSource.Stop();
        go_Play.SetActive(true);
        go_Pause.SetActive(false);
        tx_Time.text = "00:00" + " / " + mTotalTime;
        mAudioSource.time = 0;
        slider_Progress.value = 0;
    }



    private void Btn_OpenFolder()              // 打开文件夹
    {
        DirectoryInfo dir = mCurrentAudioResBean.YuanFileInfo.Directory;
        if (null!=dir)
        {
            Application.OpenURL(dir.FullName);
        }

    }



    private void E_OnSliderDrag()                           // 开始拖动 Slider 音乐条
    {
        isOnSliderChange = true;

    }

    private void E_OnSliderDragEnd()                        // 结束拖动 Slider 音乐条
    {
        if (isOnSliderChange)
        {
            isOnSliderChange = false;
            mAudioSource.time = slider_Progress.value;
        }

    }




    private void ManyBtn_DaoRu(EAudioType type)             // 点击导入
    {
        mCurrentAudioResBean.IsDaoRu = true;

        MyEventCenter.SendEvent(E_GameEvent.DaoRuAudioFromResult, type, mCurrentAudioResBean);
        if (null!= tx_Name)
        {
            tx_Name.color = Color.green;
            tx_Name = null;
        }

        Btn_OnClickClose();

    }

    //—————————————————— 事件 ——————————————————

    private AudioResBean mCurrentAudioResBean;
    private Text tx_Name;

    private void E_Show(Text txName ,FileInfo file,bool isNeedDaoRu)       // 显示音乐页事件
    {
        tx_Name = txName;
        mUIGameObject.SetActive(true);
        go_Wait.SetActive(true);
        go_ShowMusic.SetActive(false);
        go_DaoRu.SetActive(false);
        tx_WaitName.text = file.Name;
        Ctrl_LoadAudioClip.Instance.StartLoadAudioClip(file, (resBean) =>
        {
            mAudioSource.loop = true;
            mCurrentAudioResBean = resBean;
            go_Wait.SetActive(false);
            go_ShowMusic.SetActive(true);
            go_DaoRu.SetActive(isNeedDaoRu);
            tx_InfoName.text = file.Name;
            mTotalTime = resBean.Clip.length.ToTiemStr();
            mAudioSource.clip = resBean.Clip;
            slider_Progress.minValue = 0;
            slider_Progress.maxValue = resBean.Clip.length;

            tx_DR1.text = Ctrl_UserInfo.Instance.BottomAudioName[0];
            tx_DR2.text = Ctrl_UserInfo.Instance.BottomAudioName[1];
            tx_DR3.text = Ctrl_UserInfo.Instance.BottomAudioName[2];
            tx_DR4.text = Ctrl_UserInfo.Instance.BottomAudioName[3];
            tx_DR5.text = Ctrl_UserInfo.Instance.BottomAudioName[4];

            Btn_OnPlay();
        });

    }


    private void E_Close()                                                   // 关闭音乐页事件
    {
        mAudioSource.loop = false;
        mUIGameObject.SetActive(false);
        mAudioSource.clip = null;
        mAudioSource.Stop();
    }


    private void E_OnChangeAudioVolume(float value)                  // 改变音量大小ing
    {
        mAudioSource.volume = value;
        if (slider_Volume.value != value)
        {
            slider_Volume.value = value;
        }
    }

    private void E_OnChangeAudioVolumeEnd(float value)             // 改变音量大小 结束
    {
        if (value > 0.75f)
        {
            dt4_Volume.Change2One();
        }
        else if (value > 0.45f)
        {
            dt4_Volume.Change2Two();
        }
        else if (value > 0)
        {
            dt4_Volume.Change2Three();
        }
        else
        {
            dt4_Volume.Change2Four();
        }


    }



}
