/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;


public enum EAudioType
{
    EasyMusic,
    BGM,
    Effect,
    Click,
    Perple
}



public class Game_Audio : SubUI
{


    public void ChangeOtherPage()
    {
        if (null != mCurrentPlayBean && !isHuoTai)
        {
            mCurrentPlayBean.Stop();
            mCurrentPlayBean = null;
        }
    }


    private void StopAudio()             // 转其他大项 或者 小项
    {
        if (null != mCurrentPlayBean)
        {
            mCurrentPlayBean.Stop();
            mCurrentPlayBean = null;
        }
    }


    public void Show(int index)
    {
        switch (index)
        {
            case 0:
                tg_BottomContrl.ChangeToggleOn(ITEM_STR1);
                break;
            case 1:
                tg_BottomContrl.ChangeToggleOn(ITEM_STR2);
                break;
            case 2:
                tg_BottomContrl.ChangeToggleOn(ITEM_STR3);
                break;
            case 3:
                tg_BottomContrl.ChangeToggleOn(ITEM_STR4);
                break;
            case 4:
                tg_BottomContrl.ChangeToggleOn(ITEM_STR5);
                break;
        }
    }



    public void OnUpdate()
    {
        if (null != mCurrentPlayBean)
        {
            mCurrentPlayBean.Update(() =>
            {
                List<EachItemBean> list = typeK_BeanListV[mCurrentIndex];
                int index = list.IndexOf(mCurrentPlayBean);
                index++;
                if (index >= list.Count)
                {
                    index = 0;
                }
                mCurrentPlayBean = list[index];
                mCurrentPlayBean.Play();

            });
        }
    }



    #region 私有

    private bool isHuoTai;
    private EAudioType mCurrentIndex;
    private EachItemBean mCurrentPlayBean;        // 当前播放
    private readonly Dictionary<EAudioType, List<EachItemBean>> typeK_BeanListV = new Dictionary<EAudioType, List<EachItemBean>>();  // 每小页为Key，每个音频按钮Bean 为Value


    // 模版
    private GameObject go_MoBan;
    private const string CREATE_FILE_NAME = "AudioFile";        // 模版产生的名
    private AudioSource mAudioSource;

    // 上方
    private ScrollRect m_SrollView;
    private DTToggle5_Fade dt5_Contrl;

    // 音量
    private Slider slider_Volume;
    private DTToggle4_Fade dt4_Volume;

    // 底下
    private UGUI_ToggleGroup tg_BottomContrl;
    private Text tx_BottomName1, tx_BottomName2, tx_BottomName3, tx_BottomName4, tx_BottomName5;
    private const string ITEM_STR1 = "GeShiItem1";
    private const string ITEM_STR2 = "GeShiItem2";
    private const string ITEM_STR3 = "GeShiItem3";
    private const string ITEM_STR4 = "GeShiItem4";
    private const string ITEM_STR5 = "GeShiItem5";


    // 导入失败界面
    private GameObject go_DaoRuError;
    private RectTransform rt_ErrorDRContant;
    private GameObject moBan_Error,moBan_Ok;


    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/Audio";
    }




    public override void OnDisable()
    {
    }



    private RectTransform GetParentRT(EAudioType type)
    {
        RectTransform rt = null;     // 放在那里
        switch (type)
        {
            case EAudioType.EasyMusic:
                rt = dt5_Contrl.GO_One.transform as RectTransform;
                break;
            case EAudioType.BGM:
                rt = dt5_Contrl.GO_Two.transform as RectTransform;
                break;
            case EAudioType.Effect:
                rt = dt5_Contrl.GO_Three.transform as RectTransform;
                break;
            case EAudioType.Click:
                rt = dt5_Contrl.GO_Four.transform as RectTransform;
                break;
            case EAudioType.Perple:
                rt = dt5_Contrl.GO_Five.transform as RectTransform;
                break;
            default:
                throw new Exception("还有其他？");
        }
        return rt;
    }




    private bool isSelect;                  // 是否之前点击了

    private IEnumerator CheckoubleClick()           // 检测是否双击
    {
        isSelect = true;
        yield return new WaitForSeconds(MyDefine.DoubleClickTime);
        isSelect = false;
    }



    private void DeleteOneLine(EAudioType type)
    {
        Ctrl_TextureInfo.Instance.DeleteAudioOneLine(type);
        RectTransform rt = GetParentRT(type);
        for (int i = 0; i < rt.childCount; i++)
        {
            UnityEngine.Object.Destroy(rt.GetChild(i).gameObject);
        }
    }

    #endregion



    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EAudioType, AudioResBean>(E_GameEvent.DaoRu_Audio, E_DaoRu_Audio);      // 从导入
        MyEventCenter.AddListener<EGameType>(E_GameEvent.ClickTrue, E_DelteTrue);                         // 确定删除
        MyEventCenter.AddListener(E_GameEvent.DelteAll, E_DeleteAll);                                     // 删除所有
        MyEventCenter.AddListener<EGameType, string>(E_GameEvent.SureGeiMing, E_OnSureGaiMing);           // 确定改名

        MyEventCenter.AddListener<float>(E_GameEvent.ChangeAudioVolumeing, E_OnChangeAudioVolume);        // 改变音量
        MyEventCenter.AddListener<float>(E_GameEvent.ChangeAudioVolumeEnd, E_OnChangeAudioVolumeEnd);     // 结束改变音量



        foreach (EAudioType type in Enum.GetValues(typeof(EAudioType)))
        {
            typeK_BeanListV.Add(type, new List<EachItemBean>());
        }


        mAudioSource = mUITransform.parent.parent.Find("AudioSource").GetComponent<AudioSource>();


        // 内容 
        go_MoBan = GetGameObject("Top/Contant/ScrollView/MoBan");
        m_SrollView = Get<ScrollRect>("Top/Contant/ScrollView");
        dt5_Contrl = Get<DTToggle5_Fade>("Top/Contant/ScrollView");


        // 底下
        tg_BottomContrl = Get<UGUI_ToggleGroup>("Bottom/Contant");
        tg_BottomContrl.OnChangeValue += E_OnBottomValueChange;
        tg_BottomContrl.OnDoubleClick += E_OnBottomDoubleClick;

        tx_BottomName1 = Get<Text>("Bottom/Contant/GeShiItem1/Text");
        tx_BottomName2 = Get<Text>("Bottom/Contant/GeShiItem2/Text");
        tx_BottomName3 = Get<Text>("Bottom/Contant/GeShiItem3/Text");
        tx_BottomName4 = Get<Text>("Bottom/Contant/GeShiItem4/Text");
        tx_BottomName5 = Get<Text>("Bottom/Contant/GeShiItem5/Text");



        // 右边
        AddButtOnClick("Top/Left/DaoRu", Btn_OnDaoRu);
        AddButtOnClick("Top/Left/DeleteAll", Btn_DeleteOneLine);
        AddToggleOnValueChanged("Top/Left/IsHuoTai/Toggle", Toggle_IsHuoTai);

        // 音量
        dt4_Volume = Get<DTToggle4_Fade>("Top/Left/Volume/Icon");
        slider_Volume = Get<Slider>("Top/Left/Volume/Slider");
        AddSliderOnValueChanged(slider_Volume, (value) =>
        {
            MyEventCenter.SendEvent(E_GameEvent.ChangeAudioVolumeing, value);
        });
        Get<SliderEvent>("Top/Left/Volume/Slider").E_OnDragEnd += () =>
        {
            MyEventCenter.SendEvent(E_GameEvent.ChangeAudioVolumeEnd, slider_Volume.value);
        };

        // 导入失败界面
        go_DaoRuError = GetGameObject("DaoRuError");
        rt_ErrorDRContant = Get<RectTransform>("DaoRuError/Contant/Error/Contant");
        moBan_Error = GetGameObject("DaoRuError/Contant/Error/MoBan_Error");
        moBan_Ok = GetGameObject("DaoRuError/Contant/Error/MoBan_Ok");
        AddButtOnClick("DaoRuError/Contant/BtnSure", Btn_ErrorUIClickSure);
    }



    public override void OnEnable()
    {
        tx_BottomName1.text = Ctrl_UserInfo.Instance.BottomAudioName[0];
        tx_BottomName2.text = Ctrl_UserInfo.Instance.BottomAudioName[1];
        tx_BottomName3.text = Ctrl_UserInfo.Instance.BottomAudioName[2];
        tx_BottomName4.text = Ctrl_UserInfo.Instance.BottomAudioName[3];
        tx_BottomName5.text = Ctrl_UserInfo.Instance.BottomAudioName[4];


    }



    //————————————————————————————————————

    private void E_OnBottomDoubleClick()                                     // 底下 双击 改名
    {
        MyEventCenter.SendEvent(E_GameEvent.ShowGeiMingUI, EGameType.Audio, Ctrl_UserInfo.Instance.BottomAudioName[(int)mCurrentIndex]);
    }

    private void E_OnBottomValueChange(string changeName)                     // 底下的切换
    {

        switch (changeName)
        {
            case ITEM_STR1:
                mCurrentIndex = EAudioType.EasyMusic;
                dt5_Contrl.Change2One();
                break;
            case ITEM_STR2:
                mCurrentIndex = EAudioType.BGM;
                dt5_Contrl.Change2Two();
                break;
            case ITEM_STR3:
                mCurrentIndex = EAudioType.Effect;
                dt5_Contrl.Change2Three();
                break;
            case ITEM_STR4:
                mCurrentIndex = EAudioType.Click;
                dt5_Contrl.Change2Four();
                break;
            case ITEM_STR5:
                mCurrentIndex = EAudioType.Perple;
                dt5_Contrl.Change2Five();
                break;
        }

        StopAudio();
        m_SrollView.content = GetParentRT(mCurrentIndex);

    }


    private void Btn_OnDaoRu()                                                // 点击导入
    {
        MyOpenFileOrFolder.OpenFile(Ctrl_UserInfo.Instance.DaoRuFirstPath, "选择一个或多个音频文件", EFileFilter.AudioAndAll,
            (filePaths) =>
            {

                List<FileInfo> fileInfos = new List<FileInfo>(filePaths.Length);
                bool isError = false;

                foreach (string filePath in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (MyFilterUtil.IsAudio(fileInfo))
                    {
                        if (fileInfo.Extension == ".mp3")
                        {
                            isError = true;
                        }
                        else
                        {
                            fileInfos.Add(fileInfo);
                        }
                    }
                    else
                    {
                        isError = true;
                        MyLog.Red("选择了其他的格式文件 —— " + fileInfo.Name);
                    }
                }
                if (isError)
                {
                    go_DaoRuError.SetActive(true);
                    foreach (string path in filePaths)
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        Transform t;
                        if (MyFilterUtil.IsAudio(fileInfo))
                        {
                            if (fileInfo.Extension == ".mp3")
                            {
                               t= InstantiateMoBan(moBan_Error, rt_ErrorDRContant);
                            }
                            else
                            {
                                t = InstantiateMoBan(moBan_Ok, rt_ErrorDRContant);
                            }
                        }
                        else
                        {
                            t = InstantiateMoBan(moBan_Error, rt_ErrorDRContant);
                        }
                        t.Find("TxName").GetComponent<Text>().text = fileInfo.Name;
                    }
                }
                else
                {
                    MyEventCenter.SendEvent(E_GameEvent.DaoRuAudioFromFiles, mCurrentIndex, fileInfos,true);
                }

            });
    }


    private void Btn_DeleteOneLine()                                           // 点击右上的删除
    {
        string tittle = "删除";
        switch (mCurrentIndex)
        {
            case EAudioType.EasyMusic:
                tittle += "  放松音乐 所有音频？";
                break;
            case EAudioType.BGM:
                tittle += " BGM 所有音频？";
                break;
            case EAudioType.Effect:
                tittle += " 特效音效 所有音频？";
                break;
            case EAudioType.Click:
                tittle += " 按键音效 所有音频？";
                break;
            case EAudioType.Perple:
                tittle += " 人物动作 所有音频？";
                break;
        }
        MyEventCenter.SendEvent(E_GameEvent.ShowIsSure, EGameType.Audio, tittle);

    }


    private void Toggle_IsHuoTai(bool value)                                  // 切换是否后台
    {
        isHuoTai = value;
    }



    //———————————————————— 事件 ————————————————

    private void E_DaoRu_Audio(EAudioType type, AudioResBean resBean)
    {
        Transform t = InstantiateMoBan(go_MoBan, GetParentRT(type), CREATE_FILE_NAME);
        t.Find("Top/TxName").GetComponent<Text>().text = Path.GetFileNameWithoutExtension(resBean.YuanPath);
        Text tx_ZhongTime = t.Find("Top/TxZhongTime").GetComponent<Text>();

        if (resBean.Clip.length <= 1)
        {
            tx_ZhongTime.text = "极短";
        }
        else
        {
            tx_ZhongTime.text = resBean.Clip.length.ToTiemStr();
        }

        Text tx_CurrentTime = t.Find("Bottom/TxCurrentTime").GetComponent<Text>();
        Button btn_Play = t.Find("Bottom/BtnPlay").GetComponent<Button>();
        Button btn_Pause = t.Find("Bottom/BtnPause").GetComponent<Button>();
        Slider slider_Progress = t.Find("Bottom/Slider_Progress").GetComponent<Slider>();

        EachItemBean itemBean = new EachItemBean(mAudioSource, resBean.Clip, btn_Play.gameObject, btn_Pause.gameObject, slider_Progress, tx_CurrentTime);
        typeK_BeanListV[type].Add(itemBean);
        // 播放按钮
        btn_Play.onClick.AddListener(() =>
        {
            if (null != mCurrentPlayBean)
            {
                mCurrentPlayBean.Stop();
            }
            mCurrentPlayBean = itemBean;
            mCurrentPlayBean.Play();

        });
        // 暂停按钮
        btn_Pause.onClick.AddListener(() =>
        {
            mCurrentPlayBean.Pause();
        });
        // 检测双击
        t.Find("Bg").GetComponent<Button>().onClick.AddListener(() =>
        {
            if (isSelect)
            {
                isSelect = false;
                StopAudio();
                MyEventCenter.SendEvent<Text, FileInfo, bool>(E_GameEvent.ShowMusicInfo, null, new FileInfo(resBean.SavePath), false);
            }
            else
            {
                Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
            }
        });
        // 删除按钮
        t.Find("Top/BtnClose").GetComponent<Button>().onClick.AddListener(() =>
        {
            if (itemBean == mCurrentPlayBean)
            {
                mCurrentPlayBean.Stop();
                mAudioSource.clip = null;
                mCurrentPlayBean = null;
            }
            typeK_BeanListV[type].Remove(itemBean);
            UnityEngine.Object.Destroy(t.gameObject);
            Ctrl_TextureInfo.Instance.DeleteAudioSave(type, resBean.SavePath);
        });
    }





    private void E_DelteTrue(EGameType type)             // 真的删除一行
    {
        if (type == EGameType.Audio)
        {
            DeleteOneLine(mCurrentIndex);
        }
    }


    private void E_DeleteAll()                           // 删除所有
    {
        StopAudio();
        foreach (EAudioType type in Enum.GetValues(typeof(EAudioType)))
        {
            DeleteOneLine(type);
        }

    }



    private void Btn_ErrorUIClickSure()                  // 在导入失败界面点击确定
    {
        go_DaoRuError.SetActive(false);
        for (int i = 0; i < rt_ErrorDRContant.childCount; i++)
        {
            UnityEngine.Object.DestroyImmediate(rt_ErrorDRContant.GetChild(i).gameObject);
        }
    }



    private void E_OnSureGaiMing(EGameType type,string changeNamne)           // 确定改名
    {
        if (type == EGameType.Audio)
        {
            switch (mCurrentIndex)
            {
                case EAudioType.EasyMusic:
                    tx_BottomName1.text = changeNamne;
                    break;
                case EAudioType.BGM:
                    tx_BottomName2.text = changeNamne;
                    break;
                case EAudioType.Effect:
                    tx_BottomName3.text = changeNamne;
                    break;
                case EAudioType.Click:
                    tx_BottomName4.text = changeNamne;
                    break;
                case EAudioType.Perple:
                    tx_BottomName5.text = changeNamne;
                    break;
            }
            Ctrl_UserInfo.Instance.BottomAudioName[(int) mCurrentIndex] = changeNamne;
        }
    }



    private void E_OnChangeAudioVolume(float value)                  // 改变音量大小ing
    {
        mAudioSource.volume = value;
        if (slider_Volume.value !=value)
        {
            slider_Volume.value = value;
        }
    }

    private void E_OnChangeAudioVolumeEnd(float value)             // 改变音量大小 结束
    {
        if (value>0.75f)
        {
            dt4_Volume.Change2One();
        }else if (value >0.45f)
        {
            dt4_Volume.Change2Two();
        }else if (value >0)
        {
            dt4_Volume.Change2Three();
        }
        else
        {
            dt4_Volume.Change2Four();
        }


    }


    #region EachItemBean


    public class EachItemBean
    {
        private readonly GameObject go_Play;
        private readonly GameObject go_Pause;
        private readonly Slider slider_Progress;
        private readonly Text tx_CurrentTime;
        private readonly AudioClip mAudioClip;
        private readonly AudioSource mAudioSource;



        private bool isPlaying, isOnSliderChange;

        public EachItemBean(AudioSource source, AudioClip clip, GameObject goPlay, GameObject goPause, Slider sliderProgress, Text txCurrentTime)
        {
            mAudioSource = source;
            mAudioClip = clip;
            go_Play = goPlay;
            go_Pause = goPause;
            slider_Progress = sliderProgress;
            tx_CurrentTime = txCurrentTime;

            SliderEvent sliderEvent = sliderProgress.GetComponent<SliderEvent>();
            if (null == sliderEvent)
            {
                throw new Exception("在 Slider 上添加 SliderEvent！");
            }
            sliderEvent.E_OnDrag += E_OnSliderDrag;
            sliderEvent.E_OnDragEnd += E_OnSliderDragEnd;

            slider_Progress.minValue = 0;
            slider_Progress.maxValue = clip.length;
            slider_Progress.value = 0;
        }

        private void E_OnSliderDrag()         // 开始拖动 Slider
        {
            if (isPlaying)
            {
                isOnSliderChange = true;
            }

        }

        private void E_OnSliderDragEnd()      // 结束拖动 Slider
        {
            if (isOnSliderChange && isPlaying)
            {
                isOnSliderChange = false;
                mAudioSource.time = slider_Progress.value;
            }
        }



        public void Play()
        {
            isPlaying = true;
            go_Play.SetActive(false);
            go_Pause.SetActive(true);
            slider_Progress.gameObject.SetActive(true);
            tx_CurrentTime.gameObject.SetActive(true);
            if (mAudioSource.clip != mAudioClip)
            {
                mAudioSource.clip = mAudioClip;
                mAudioSource.time = slider_Progress.value;

            }
            mAudioSource.Play();

        }

        public void Pause()
        {
            go_Play.SetActive(true);
            go_Pause.SetActive(false);
            isPlaying = false;
            mAudioSource.Pause();
        }


        public void Stop()
        {
            slider_Progress.value = 0;
            slider_Progress.gameObject.SetActive(false);
            go_Play.SetActive(true);
            go_Pause.SetActive(false);
            tx_CurrentTime.gameObject.SetActive(false);

            isPlaying = false;
            mAudioSource.Stop();
        }

        public void Update(Action onFinsh)
        {
            if (isPlaying)
            {
                if (mAudioSource.isPlaying)
                {
                    if (!isOnSliderChange)
                    {
                        slider_Progress.value = mAudioSource.time;
                    }
                    tx_CurrentTime.text = mAudioSource.time.ToTiemStr();
                }
                else
                {
                    Stop();
                    onFinsh();
                }
            }

        }

    }



    #endregion



}




*/
