/*
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public enum EGameType
{
    XuLieTu,
    XuLieTu222,
    JiHeXuLieTu,
    TaoMingTu,
    NormalTu,
    JiHeTu,
    Audio,
    DaoRu,
    Search,
}



public class UIStart_Game : BaseUI
{
    protected override void OnStart(Transform root)
    {

        #region 左边

        go_Loading = GetGameObject("Left/Loading");
        anim_LeftContrl = Get<DTExpansion_Contrl>("Left");
        AddButtOnClick("Left/BtnBig", Btn_OnBig);

        go_XuLieChoose1 = GetGameObject("Left/Contant/Group/XuLieTu/Choose1");
        go_XuLieChoose2 = GetGameObject("Left/Contant/Group/XuLieTu/Kuang/Choose2");
        go_XuLie222Choose1 = GetGameObject("Left/Contant/Group/XuLieTu222/Choose1");
        go_XuLie222Choose2 = GetGameObject("Left/Contant/Group/XuLieTu222/Kuang/Choose2");
        go_TaoMingChoose1 = GetGameObject("Left/Contant/Group/TaoMingTu/Choose1");
        go_TaoMingChoose2 = GetGameObject("Left/Contant/Group/TaoMingTu/Kuang/Choose2");
        go_NormalChoose1 = GetGameObject("Left/Contant/Group/NormalTu/Choose1");
        go_NormalChoose2 = GetGameObject("Left/Contant/Group/NormalTu/Kuang/Choose2");
        go_JiHeChoose1 = GetGameObject("Left/Contant/Group/JiHeTu/Choose1");
        go_JiHeChoose2 = GetGameObject("Left/Contant/Group/JiHeTu/Kuang/Choose2");
        go_AudioChoose1 = GetGameObject("Left/Contant/Group/Audio/Choose1");
        go_AudioChoose2 = GetGameObject("Left/Contant/Group/Audio/Kuang/Choose2");
        go_DaoRuChoose1 = GetGameObject("Left/Contant/Group/DaoRu/Choose1");
        go_DaoRuChoose2 = GetGameObject("Left/Contant/Group/DaoRu/Kuang/Choose2");
        go_SearchChoose1 = GetGameObject("Left/Contant/Group/Search/Kuang/Choose2");
        go_SearchChoose2 = GetGameObject("Left/Contant/Group/Search/Kuang/Choose2");
        go_JiHeXuLieTuChoose1 = GetGameObject("Left/Contant/Group/JiHeXuLieTu/Choose1");
        go_JiHeXuLieTuChoose2 = GetGameObject("Left/Contant/Group/JiHeXuLieTu/Kuang/Choose2");

        AddButtOnClick("Left/Contant/Group/XuLieTu", () =>
        {
            Btn_OnLeftClick(EGameType.XuLieTu);
        });
        AddButtOnClick("Left/Contant/Group/XuLieTu222", () =>
        {
            Btn_OnLeftClick(EGameType.XuLieTu222);
        });
        AddButtOnClick("Left/Contant/Group/JiHeXuLieTu", () =>
        {
            Btn_OnLeftClick(EGameType.JiHeXuLieTu);
        });
        AddButtOnClick("Left/Contant/Group/TaoMingTu", () =>
        {
            Btn_OnLeftClick(EGameType.TaoMingTu);
        });
        AddButtOnClick("Left/Contant/Group/NormalTu", () =>
        {
            Btn_OnLeftClick(EGameType.NormalTu);
        });
        AddButtOnClick("Left/Contant/Group/JiHeTu", () =>
        {
            Btn_OnLeftClick(EGameType.JiHeTu);
        });
        AddButtOnClick("Left/Contant/Group/Audio", () =>
        {
            Btn_OnLeftClick(EGameType.Audio);
        });
        AddButtOnClick("Left/Contant/Group/DaoRu", () =>
        {
            Btn_OnLeftClick(EGameType.DaoRu);
        });
        AddButtOnClick("Left/Contant/Group/Search", () =>
        {
            Btn_OnLeftClick(EGameType.Search);
        });



        #endregion


        // 左下设置
        dt2_Setting = Get<DTToggle2_Fade>("Left/Bottom");
        AddButtOnClick("Left/Bottom/BtnIcon", Btn_OnSetting);
        AddButtOnClick("Left/Bottom/Setting/Contant/Btn/BtnDelete", Btn_OnClickZhongZhi);
        Get<UGUI_PointEnterAndExit>("Left/Bottom/Setting").E_OnMouseExit += E_OnMouseExitSetting;

        Toggle toggle1 = Get<Toggle>("Left/Bottom/Setting/Contant/ToggleTip");
        toggle1.isOn = Ctrl_UserInfo.Instance.IsXuLieTuShowTip;
        AddToggleOnValueChanged(toggle1, Toggle_IsShowTip);

        Toggle toggle2 = Get<Toggle>("Left/Bottom/Setting/Contant/ToggleIsChangeSize");
        toggle2.isOn = Ctrl_UserInfo.Instance.IsCanChangeSize;
        AddToggleOnValueChanged(toggle2, Toggle_IsCanChangeSize);



        // 右边
        rt_Right = Get<RectTransform>("Right");
        d9_RightContant = Get<DTToggle9_Fade>("Right/EachContant");


        // 底下的等待UI
        go_WaitBrowser = GetGameObject("OpenBrowser");
        tx_Wait = Get<Text>("OpenBrowser/Text");


        // 确定是否界面
        go_IsSure = GetGameObject("Right/IsSure");
        tx_IsSureTittle = Get<Text>("Right/IsSure/Contant/Tittle");
        go_IsSureTip = GetGameObject("Right/IsSure/Contant/Tip");
        AddButtOnClick("Right/IsSure/Contant/BtnSure", Btn_OnSureClick);
        AddButtOnClick("Right/IsSure/Contant/BtnFalse", Btn_OnFalseClick);




        // 一开始把之前所有的都加载进来
        Ctrl_Coroutine.Instance.StartCoroutine(StartFirst());
    }

    protected override void OnEnable()
    {
        E_OnToggleChange(EGameType.XuLieTu,0);

        Get<Text>("Left/Contant/Group/XuLieTu/Kuang/Text").text = Ctrl_UserInfo.XuLieTu_LeftStr;
        Get<Text>("Left/Contant/Group/XuLieTu222/Kuang/Text").text = Ctrl_UserInfo.XuLieTu222_LeftStr;
        Get<Text>("Left/Contant/Group/JiHeXuLieTu/Kuang/Text").text = Ctrl_UserInfo.JiHeXuLieTu_LeftStr;
        Get<Text>("Left/Contant/Group/TaoMingTu/Kuang/Text").text = Ctrl_UserInfo.TaoMingTu_LeftStr;
        Get<Text>("Left/Contant/Group/NormalTu/Kuang/Text").text = Ctrl_UserInfo.JpgTu_LeftStr;
        Get<Text>("Left/Contant/Group/JiHeTu/Kuang/Text").text = Ctrl_UserInfo.JiHeTu_LeftStr;



    }

    protected override void OnAddListener()
    {
        MyEventCenter.AddListener(E_GameEvent.OpenFileContrl, OnShowGameWaitUI_File);
        MyEventCenter.AddListener(E_GameEvent.OpenFolderContrl, OnShowGameWaitUI_Folder);
        MyEventCenter.AddListener(E_GameEvent.CloseFileOrFolderContrl, OnHideGameWaitUI_Browser);
        MyEventCenter.AddListener<EGameType, int>(E_GameEvent.ChangGameToggleType, E_OnToggleChange);
        MyEventCenter.AddListener<EGameType,string>(E_GameEvent.ShowIsSure, E_ShowIsSure);

    }

    protected override void OnRemoveListener()
    {
        MyEventCenter.RemoveListener(E_GameEvent.OpenFileContrl, OnShowGameWaitUI_File);
        MyEventCenter.RemoveListener(E_GameEvent.OpenFolderContrl, OnShowGameWaitUI_Folder);
        MyEventCenter.RemoveListener(E_GameEvent.CloseFileOrFolderContrl, OnHideGameWaitUI_Browser);
        MyEventCenter.RemoveListener<EGameType, int>(E_GameEvent.ChangGameToggleType, E_OnToggleChange);
        MyEventCenter.RemoveListener<EGameType,string>(E_GameEvent.ShowIsSure, E_ShowIsSure);


    }

    protected override void OnUpdate()
    {
        sub_MusicInfo.OnUpdate();
//        sub_Audio.OnUpdate();
        
    }



    #region 私有

    private bool isBig =false;  // 是否最大化
    private EGameType mCurrentGameType;
    private bool isClickZhongZhi;

    // 底下的等待UI
    private GameObject go_WaitBrowser;
    private Text tx_Wait;
    private const string WAIT_FILE = "等待,选择文件中...";
    private const string WAIT_FOLDER = "等待,选择文件夹中...";


    // 左边
    private DTExpansion_Contrl anim_LeftContrl;
    private static readonly Vector2 FirstOffsetMin = new Vector2(272, 0);
    private static readonly Vector2 ToOffsetMin = new Vector2(84, 0);

    private GameObject go_XuLieChoose1, go_XuLieChoose2;
    private GameObject go_XuLie222Choose1, go_XuLie222Choose2;
    private GameObject go_JiHeXuLieTuChoose1, go_JiHeXuLieTuChoose2;
    private GameObject go_TaoMingChoose1, go_TaoMingChoose2;
    private GameObject go_NormalChoose1, go_NormalChoose2;
    private GameObject go_JiHeChoose1, go_JiHeChoose2;
    private GameObject go_AudioChoose1, go_AudioChoose2;
    private GameObject go_DaoRuChoose1,go_DaoRuChoose2;
    private GameObject go_SearchChoose1,go_SearchChoose2;
    private EGameType mCurrentType;

    private GameObject go_Loading;


    // 左下设置 
    private DTToggle2_Fade dt2_Setting;


    // 右边
    private DTToggle9_Fade d9_RightContant;
    private RectTransform rt_Right;
    private GameObject go_IsSure;
    private Text tx_IsSureTittle;
    private GameObject go_IsSureTip;



    // 右边的子UI
//    private readonly Game_XuLieTu sub_XuLieTu1 = new Game_XuLieTu();            // 序列图
//    private readonly Game_XuLieTu222 sub_XuLieTu222 = new Game_XuLieTu222();    // 序列图222
//    private readonly Game_JiHeXuLieTu sub_JiHeXuLieTu = new Game_JiHeXuLieTu(); // 集合序列图
//    private readonly Game_TaoMingTu sub_TaoMing = new Game_TaoMingTu();         // 透明图
//    private readonly Game_NormalTu sub_Jpg = new Game_NormalTu();               // Jpg
//    private readonly Game_JiHeTu sub_JiHeTu = new Game_JiHeTu();                // 集合图
//    private readonly Game_Audio sub_Audio = new Game_Audio();                   // 音频
    private readonly Sub_DaoRu sub_DaoRu1 = new Sub_DaoRu();                  // 导入
    private readonly Sub_Search sub_Search = new Sub_Search();                // 搜索


    // 其他子UI
    private readonly Game_MusicInfo sub_MusicInfo = new Game_MusicInfo();    // 音乐信息
    private readonly Game_GaiMing sub_GaiMing = new Game_GaiMing();          // 改名
    private readonly Game_SingleTuInfo sub_SingleTuInfo = new Game_SingleTuInfo();   // 单张图片信息
    private readonly Game_DuoTuInfo sub_DuoTuInfo = new Game_DuoTuInfo();            // 多张图片信息
    private readonly Game_DuoTuDaoRu sub_DuoTuDaoRu = new Game_DuoTuDaoRu();         // 多张图片 导入
    private readonly Game_SingleTuDaoRu sub_SingleTuDaoRu = new Game_SingleTuDaoRu();// 单张图片 导入
    private readonly Sub_DaoRuResult sub_DaoRuResult = new Sub_DaoRuResult();      // 导入结果

//
//    protected override SubUI[] GetSubUI()
//    {
//        return new SubUI[] 
//        {
//            sub_XuLieTu1, sub_XuLieTu222, sub_DaoRu1, sub_TaoMing ,sub_Audio,sub_JiHeXuLieTu, sub_Jpg, sub_JiHeTu ,sub_Search,
//            sub_MusicInfo,  sub_GaiMing , sub_SingleTuInfo, sub_DuoTuInfo,sub_DuoTuDaoRu,sub_SingleTuDaoRu,sub_DaoRuResult };
//    }
    protected override SubUI[] GetSubUI()
    {
        return null;
    }


    #region 私有


    protected override E_GameEvent GetShowEvent()
    {
        return E_GameEvent.ShowStartGameUI;
    }

    protected override E_GameEvent GetHideEvent()
    {
        return E_GameEvent.HideStartGameUI;
    }

    protected override string GetResName()
    {
        return "UI/UIStart_Game";
    }

    public override EF_Scenes GetSceneType()
    {
        return EF_Scenes._0_Main;
    }


    protected override void OnDisable()
    {
    }





    #endregion


    #endregion



    IEnumerator StartFirst()                                      // 一开始显示调用这里加载原来存储的
    {
        go_Loading.SetActive(true);

        while (!Ctrl_TextureInfo.Instance.IsInitFinish)
        {
            yield return 0;
        }

        #region 序列图

        foreach (EXuLieTu type in Enum.GetValues(typeof(EXuLieTu)))
        {
            List<string[]> list = Ctrl_TextureInfo.Instance.GetXunLieTuPaths(type); // 获得这一页的所有数据
            for (int i = 0; i < list.Count; i++) // 加载每一个
            {
                string[] tmpLists = list[i];
                List<FileInfo> fileInfos = new List<FileInfo>(tmpLists.Length);
                bool isChuZai = true; // 这些路径是否存在
                for (int j = 0; j < tmpLists.Length; j++)
                {
                    FileInfo fileInfo = new FileInfo(tmpLists[j]);
                    if (!fileInfo.Exists)
                    {
                        isChuZai = false;
                        break;
                    }
                    fileInfos.Add(fileInfo);
                }
                if (isChuZai) // 存在就导入进来
                {
                    MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.XuLieTu,(ushort)type, fileInfos, false);
                    yield return 0;
                }
                else // 不存在就删除存储的
                {
                    Ctrl_TextureInfo.Instance.DeleteXuLieTuSave(type, tmpLists);
                }
            }
            yield return 0;
        }
        #endregion

        Get<Button>("Left/Contant/Group/XuLieTu").interactable = true;
        yield return 0;



        #region 序列图222

        foreach (EXuLieTu222 type in Enum.GetValues(typeof(EXuLieTu222)))
        {
            List<string[]> list = Ctrl_TextureInfo.Instance.GetXunLieTu222Paths(type); // 获得这一页的所有数据
            for (int i = 0; i < list.Count; i++) // 加载每一个
            {
                string[] tmpLists = list[i];
                List<FileInfo> fileInfos = new List<FileInfo>(tmpLists.Length);
                bool isChuZai = true; // 这些路径是否存在
                for (int j = 0; j < tmpLists.Length; j++)
                {
                    FileInfo fileInfo = new FileInfo(tmpLists[j]);
                    if (!fileInfo.Exists)
                    {
                        isChuZai = false;
                        break;
                    }
                    fileInfos.Add(fileInfo);
                }
                if (isChuZai) // 存在就导入进来
                {
                    MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.XuLieTu222, (ushort)type, fileInfos, false);
                    yield return 0;
                }
                else // 不存在就删除存储的
                {
                    Ctrl_TextureInfo.Instance.DeleteXuLieTu222Save(type, tmpLists);
                }
            }
            yield return 0;
        }
        #endregion
        Get<Button>("Left/Contant/Group/XuLieTu222").interactable = true;
        yield return 0;


        #region 集合序列图

        foreach (EJiHeXuLieTuType type in Enum.GetValues(typeof(EJiHeXuLieTuType)))
        {
            List<string> list = Ctrl_TextureInfo.Instance.GetJiHeXuLieTuPaths(type);
            List<FileInfo> tmpFileInfos = new List<FileInfo>();
            for (int i = 0; i < list.Count; i++)
            {
                FileInfo fileInfo = new FileInfo(list[i]);
                if (fileInfo.Exists)       // 存在就加载
                {
                    tmpFileInfos.Add(fileInfo);

                }
                else                       // 不存在删除
                {
                    Ctrl_TextureInfo.Instance.DeleteJiHeXuLieSave(type, list[i]);
                }
            }
            MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.JiHeXuLieTu, (ushort)type, tmpFileInfos, false);
            yield return 0;

        }
        #endregion
        Get<Button>("Left/Contant/Group/JiHeXuLieTu").interactable = true;
        yield return 0;

        
        #region 透明图

        foreach (ETaoMingType type in Enum.GetValues(typeof(ETaoMingType)))
        {

            List<string> list = Ctrl_TextureInfo.Instance.GetTaoMingTuPaths(type);
            List<FileInfo> tmpFileInfos = new List<FileInfo>();
            for (int i = 0; i < list.Count; i++)
            {
                FileInfo fileInfo = new FileInfo(list[i]);
                if (fileInfo.Exists)       // 存在就加载
                {
                    tmpFileInfos.Add(fileInfo);
                }
                else                       // 不存在删除
                {
                    Ctrl_TextureInfo.Instance.DeleteTaoMingSave(type, list[i]);
                }
            }
            MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.TaoMingTu, (ushort)type, tmpFileInfos, false);
            yield return 0;
        }
        #endregion
        Get<Button>("Left/Contant/Group/TaoMingTu").interactable = true;
        yield return 0;


        #region Jpg

        foreach (ENormalTuType type in Enum.GetValues(typeof(ENormalTuType)))
        {

            List<string> list = Ctrl_TextureInfo.Instance.GetJpgTuPaths(type);
            List<FileInfo> tmpFileInfos = new List<FileInfo>();

            for (int i = 0; i < list.Count; i++)
            {
                FileInfo fileInfo = new FileInfo(list[i]);
                if (fileInfo.Exists)       // 存在就加载
                {
                    tmpFileInfos.Add(fileInfo);
                }
                else                       // 不存在删除
                {
                    Ctrl_TextureInfo.Instance.DeleteJpgSave(type, list[i]);
                }
            }
            MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.NormalTu, (ushort)type, tmpFileInfos, false);
            yield return 0;
        }
        #endregion
        Get<Button>("Left/Contant/Group/NormalTu").interactable = true;
        yield return 0;


        #region 集合

        foreach (EJiHeType type in Enum.GetValues(typeof(EJiHeType)))
        {
            List<string> list = Ctrl_TextureInfo.Instance.GetJiHeTuPaths(type);
            List<FileInfo> tmpFileInfos = new List<FileInfo>();
            for (int i = 0; i < list.Count; i++)
            {
                FileInfo fileInfo = new FileInfo(list[i]);
                if (fileInfo.Exists)       // 存在就加载
                {
                    tmpFileInfos.Add(fileInfo);
                }
                else                       // 不存在删除
                {
                    Ctrl_TextureInfo.Instance.DeleteJiHeSave(type, list[i]);
                }
            }
            MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile, EGameType.JiHeTu, (ushort)type, tmpFileInfos, false);
            yield return 0;
        }
        #endregion
        Get<Button>("Left/Contant/Group/JiHeTu").interactable = true;
        yield return 0;


        #region 音频

        foreach (EAudioType type in Enum.GetValues(typeof(EAudioType)))
        {
            List<string> paths = Ctrl_TextureInfo.Instance.GetAudioPaths(type);
            List<FileInfo> tmpFileInfos = new List<FileInfo>();
            for (int i = 0; i < paths.Count; i++)
            {
                FileInfo fileInfo = new FileInfo(paths[i]);
                if (fileInfo.Exists)       // 存在就加载
                {
                    tmpFileInfos.Add(fileInfo);
                }
                else                       // 不存在删除
                {
                    Ctrl_TextureInfo.Instance.DeleteAudioSave(type, paths[i]);
                }
            }
            MyEventCenter.SendEvent(E_GameEvent.DaoRuAudioFromFiles,type, tmpFileInfos,false);
            yield return 0;

        }


        #endregion
        Get<Button>("Left/Contant/Group/Audio").interactable = true;
        yield return 0;


        Get<Button>("Left/Contant/Group/DaoRu").interactable = true;
        Get<Button>("Left/Contant/Group/Search").interactable = true;
        go_Loading.SetActive(false);



    }



    //————————————————————————————————————



    private void Btn_OnLeftClick(EGameType type)              // 点击左边的按钮
    {
        if (type == mCurrentType)
        {
            return;
        }
        MyEventCenter.SendEvent(E_GameEvent.ChangGameToggleType, type, -1);

    }


    private void Btn_OnBig()                                  // 左边 点击最大化
    {

        if (!isBig)
        {
            DOTween.To(() => rt_Right.offsetMin,x=> rt_Right.offsetMin =x, ToOffsetMin,0.2f);
            anim_LeftContrl.DOPlayForward();
        }
        else
        {
            DOTween.To(() => rt_Right.offsetMin, x => rt_Right.offsetMin = x, FirstOffsetMin, 0.2f);
            anim_LeftContrl.DOPlayBackwards();
        }
        isBig = !isBig;

    }



    //——————————————————底下设置——————————————————

    private void Btn_OnSetting()                                  // 点击了设置
    {
        dt2_Setting.Change2Two();
    }


    private void Btn_OnClickZhongZhi()                           // 点击了重置
    {
        isClickZhongZhi = true;
        go_IsSureTip.SetActive(true);
        tx_IsSureTittle.text = "<color=red>      是否删除全部？</color>";
        go_IsSure.SetActive(true);
    }
    private void E_OnMouseExitSetting()                          // 鼠标离开设置选项
    {
        dt2_Setting.Change2One();

    }

    private void Toggle_IsShowTip(bool isOn)                     // 是否显示提示
    {
        Ctrl_UserInfo.Instance.IsXuLieTuShowTip = isOn;
    }

    private void Toggle_IsCanChangeSize(bool isOn)               // 是否显示改变大小
    {
        Ctrl_UserInfo.Instance.IsCanChangeSize = isOn;
        MyEventCenter.SendEvent(E_GameEvent.ShowChangeSizeSlider,isOn);
    }




    //—————————————————— 确定是否 ——————————————————

    private void Btn_OnSureClick()        // 点击确定
    {
        if (isClickZhongZhi)
        {
            MyEventCenter.SendEvent(E_GameEvent.DelteAll);
            go_IsSureTip.SetActive(false);
            isClickZhongZhi = false;
        }
        else
        {
            MyEventCenter.SendEvent(E_GameEvent.ClickTrue, mCurrentGameType);
        }
        go_IsSure.SetActive(false);


    }

    private void Btn_OnFalseClick()        // 点击取消
    {
        if (isClickZhongZhi)
        {
            go_IsSureTip.SetActive(false);
            isClickZhongZhi = false;
        }
        else
        {
            MyEventCenter.SendEvent(E_GameEvent.ClickFalse, mCurrentGameType);
        }
        go_IsSure.SetActive(false);

    }





    //—————————————————— 事件 ——————————————————

    private void E_OnToggleChange(EGameType type,int choose)                  // 切换左边选项
    {
        switch (mCurrentType)
        {
            case EGameType.XuLieTu:
                go_XuLieChoose1.SetActive(false);
                go_XuLieChoose2.SetActive(false);
                break;
            case EGameType.XuLieTu222:
                go_XuLie222Choose1.SetActive(false);
                go_XuLie222Choose2.SetActive(false);
                break;
            case EGameType.JiHeXuLieTu:
                go_JiHeXuLieTuChoose1.SetActive(false);
                go_JiHeXuLieTuChoose2.SetActive(false);
                break;
            case EGameType.TaoMingTu:
                go_TaoMingChoose1.SetActive(false);
                go_TaoMingChoose2.SetActive(false);
                break;
            case EGameType.NormalTu:
                go_NormalChoose1.SetActive(false);
                go_NormalChoose2.SetActive(false);
                break;
            case EGameType.JiHeTu:
                go_JiHeChoose1.SetActive(false);
                go_JiHeChoose2.SetActive(false);
                break;
            case EGameType.Audio:
                go_AudioChoose1.SetActive(false);
                go_AudioChoose2.SetActive(false);
                break;
            case EGameType.DaoRu:
                go_DaoRuChoose1.SetActive(false);
                go_DaoRuChoose2.SetActive(false);
                break;
            case EGameType.Search:
                go_SearchChoose1.SetActive(false);
                go_SearchChoose2.SetActive(false);
                break;

        }
//        sub_Audio.ChangeOtherPage();
        switch (type)
        {
            case EGameType.XuLieTu:
                go_XuLieChoose1.SetActive(true);
                go_XuLieChoose2.SetActive(true);
                if (choose>0)
                {
//                    sub_XuLieTu1.Show(choose);
                }
                d9_RightContant.Change2One();
                break;
            case EGameType.XuLieTu222:
                go_XuLie222Choose1.SetActive(true);
                go_XuLie222Choose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_XuLieTu222.Show(choose);
                }
                d9_RightContant.Change2Two();
                break;
            case EGameType.JiHeXuLieTu:
                go_JiHeXuLieTuChoose1.SetActive(true);
                go_JiHeXuLieTuChoose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_JiHeXuLieTu.Show(choose);
                }
                d9_RightContant.Change2Three();
                break;
            case EGameType.TaoMingTu:
                go_TaoMingChoose1.SetActive(true);
                go_TaoMingChoose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_TaoMing.Show(choose);
                }
                d9_RightContant.Change2Four();
                break;
            case EGameType.NormalTu:
                go_NormalChoose1.SetActive(true);
                go_NormalChoose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_Jpg.Show(choose);
                }
                d9_RightContant.Change2Five();
                break;
            case EGameType.JiHeTu:
                go_JiHeChoose1.SetActive(true);
                go_JiHeChoose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_JiHeTu.Show(choose);
                }
                d9_RightContant.Change2Six();
                break;
            case EGameType.Audio:
                go_AudioChoose1.SetActive(true);
                go_AudioChoose2.SetActive(true);
                if (choose > 0)
                {
//                    sub_Audio.Show(choose);
                }
                d9_RightContant.Change2Seven();
                break;
            case EGameType.DaoRu:
                go_DaoRuChoose1.SetActive(true);
                go_DaoRuChoose2.SetActive(true);
                sub_DaoRu1.Show();
                d9_RightContant.Change2Eight();
                break;
            case EGameType.Search:
                go_SearchChoose1.SetActive(true);
                go_SearchChoose2.SetActive(true);
                d9_RightContant.Change2Nine();
                break;

        }

        mCurrentType = type;

    }


    //—————————————————— 文件、文件夹事件 ——————————————————


    private void OnShowGameWaitUI_File()            // 接收 显示等待的界面 文件 事件
    {
        go_WaitBrowser.SetActive(true);
        tx_Wait.text = WAIT_FILE;

    }

    private void OnShowGameWaitUI_Folder()          // 接收 显示等待的界面 文件夹 事件
    {
        go_WaitBrowser.SetActive(true);
        tx_Wait.text = WAIT_FOLDER;

    }



    private void OnHideGameWaitUI_Browser()         // 接收 取消等待浏览器的界面 事件
    {
        go_WaitBrowser.SetActive(false);
    }




    private void E_ShowIsSure(EGameType type,string tittle)     // 显示 确定是否界面
    {
        mCurrentGameType = type;
        tx_IsSureTittle.text = tittle;
        go_IsSure.SetActive(true);
    }




}
*/
