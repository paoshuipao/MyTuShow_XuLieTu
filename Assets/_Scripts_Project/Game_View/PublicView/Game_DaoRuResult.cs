using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Game_DaoRuResult : SubUI 
{

    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<EGameType,ushort,List<FileInfo>,bool>(E_GameEvent.DaoRuTuFromFile, E_DaoRuTuFromFile);
        MyEventCenter.AddListener<EGameType, ushort, List<ResultBean>, bool>(E_GameEvent.DaoRuTuFromResult, E_DaoRuFromTuResult);

        MyEventCenter.AddListener<EAudioType,List<FileInfo>,bool>(E_GameEvent.DaoRuAudioFromFiles, E_DaoRuAudioFromFiles);
        MyEventCenter.AddListener<EAudioType,AudioResBean>(E_GameEvent.DaoRuAudioFromResult, E_DaoRuAudioFromResult);

        go_Ok = GetGameObject("Contant/Ok");
        go_Error = GetGameObject("Contant/Error");

        // 模版_错误用
        go_ErrorMoBan = GetGameObject("Contant/Error/ErrorInfo/MoBan");
        rt_ErrorContant = Get<RectTransform>("Contant/Error/ErrorInfo/Contant");


        // 按钮
        tx_GoTo = Get<Text>("Contant/BottomBtn/BtnGoTo/Text");
        tx_GoTo2 = Get<Text>("Contant/BottomBtn222/BtnGoTo/Text");
        go_Bottom1 = GetGameObject("Contant/BtnSure");
        go_Bottom2 = GetGameObject("Contant/BottomBtn222");
        go_Bottom3 = GetGameObject("Contant/BottomBtn");

        AddButtOnClick("Contant/BtnSure", CloseThis);
        AddButtOnClick("Contant/BottomBtn/BtnGoTo", Btn_GoToDaoRuWhere);
        AddButtOnClick("Contant/BottomBtn222/BtnGoTo", Btn_GoToDaoRuWhere);
        AddButtOnClick("Contant/BottomBtn/BtnFanHui", CloseThis);
        AddButtOnClick("Contant/BottomBtn222/BtnSure", CloseThis);
        AddButtOnClick("Contant/BottomBtn/BtnNext", Btn_OnNextFolder);

    }



    #region 私有

    private readonly List<string> l_ErrorList_Name = new List<string>();
    private EGameType mSelectType;
    private int mSelectIndex = 0;
    private Text tx_GoTo,tx_GoTo2; // 去那按钮的文字

    private GameObject go_Ok,go_Error;
    // 模版_错误用
    private GameObject go_ErrorMoBan;
    private RectTransform rt_ErrorContant;

    // 底下
    private GameObject go_Bottom1,go_Bottom2,go_Bottom3;



    public override string GetUIPathForRoot()
    {
        return "Right/DaoRuResult";
    }


    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }





    #endregion


    private void Show(EGameType gameType, bool isOk)                            // 显示导入结果
    {
        mSelectType = gameType;
        mUIGameObject.SetActive(true);
        // 是否成功
        go_Ok.SetActive(isOk);
        go_Error.SetActive(!isOk);
        string str = "去";
        switch (gameType)
        {
            case EGameType.XuLieTu:
                str += Ctrl_UserInfo.XuLieTu_LeftStr;
                break;
            case EGameType.XuLieTu222:
                str += Ctrl_UserInfo.XuLieTu222_LeftStr;
                break;
            case EGameType.JiHeXuLieTu:
                str += Ctrl_UserInfo.JiHeXuLieTu_LeftStr;
                break;
            case EGameType.TaoMingTu:
                str += Ctrl_UserInfo.TaoMingTu_LeftStr;
                break;
            case EGameType.NormalTu:
                str += Ctrl_UserInfo.JpgTu_LeftStr;
                break;
            case EGameType.JiHeTu:
                str += Ctrl_UserInfo.JiHeTu_LeftStr;
                break;
            case EGameType.Audio:
                str += Ctrl_UserInfo.Aduio_LeftStr;
                break;
            default:
                throw new Exception("未定义");
        }
        tx_GoTo.text = str + "处";
        tx_GoTo2.text = str + "处";

        if (!isOk)         // 不成功产生错误信息
        {
            foreach (string name in l_ErrorList_Name)
            {
                Transform t = InstantiateMoBan(go_ErrorMoBan, rt_ErrorContant);
                t.Find("TxName").GetComponent<Text>().text = name;
            }

        }

    }


    private void CloseThis()                 // 关闭
    {
        mUIGameObject.SetActive(false);
        go_Bottom1.SetActive(false);
        go_Bottom2.SetActive(false);
        go_Bottom3.SetActive(false);

        for (int i = 0; i < rt_ErrorContant.childCount; i++)
        {
            Object.Destroy(rt_ErrorContant.GetChild(i).gameObject);
        }
    }


    private bool IsSaveOk(EGameType type, ushort index, string[] paths)          // 判断是否保存成功
    {
        l_ErrorList_Name.Clear();
        switch (type)
        {
            case EGameType.XuLieTu:
                if (!Ctrl_TextureInfo.Instance.SaveXunLieTu(index, paths))
                {
                    l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(paths[0]));
                }
                break;
            case EGameType.XuLieTu222:
                if (!Ctrl_TextureInfo.Instance.SaveXunLieTu222(index, paths))
                {
                    l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(paths[0]));
                }
                break;
            case EGameType.JiHeXuLieTu:
                foreach (string path in paths)
                {
                    if (!Ctrl_TextureInfo.Instance.SaveJiHeXuLieTu(index, path))
                    {
                        l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(path));
                    }
                }
                break;
            case EGameType.TaoMingTu:
                foreach (string path in paths)
                {
                    if (!Ctrl_TextureInfo.Instance.SaveTaoMingTu(index, path))
                    {
                        l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(path));
                    }
                }
                break;
            case EGameType.NormalTu:
                foreach (string path in paths)
                {
                    if (!Ctrl_TextureInfo.Instance.SaveJpgTu(index, path))
                    {
                        l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(path));
                    }
                }
                break;
            case EGameType.JiHeTu:
                foreach (string path in paths)
                {
                    if (!Ctrl_TextureInfo.Instance.SaveJiHeTu(index, path))
                    {
                        l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(path));
                    }
                }
                break;
            case EGameType.Audio:
                foreach (string path in paths)
                {
                    if (!Ctrl_TextureInfo.Instance.SaveAudio(index, path))
                    {
                        l_ErrorList_Name.Add(Path.GetFileNameWithoutExtension(path));
                    }
                }
                break;
            default:
                throw new Exception("未定义");
        }

        return l_ErrorList_Name.Count <= 0;  // 少于 0个 ，表示没错咯
    }




    //—————————————————— UI ——————————————————

    private void Btn_GoToDaoRuWhere()                                  // 点击 去到刚刚导入的地方
    {
        MyEventCenter.SendEvent<EGameType, int>(E_GameEvent.ChangGameToggleType, mSelectType, mSelectIndex);
        CloseThis();
    }




    private void Btn_OnNextFolder()                                    // 点击 到下个文件夹
    {
        MyEventCenter.SendEvent(E_GameEvent.GoToNextFolderDaoRu);
        CloseThis();
    }



    //—————————————————— 事件 ——————————————————


 
    private void E_DaoRuTuFromFile(EGameType type, ushort index, List<FileInfo> fileInfos, bool isSave)   // 通过 FileInfo 导入
    {
        mSelectIndex = index;
        bool isNoError = true;
        if (isSave)   // 要保存的才显示
        {
            string[] paths = new string[fileInfos.Count];
            for (int i = 0; i < fileInfos.Count; i++)
            {
                paths[i] = fileInfos[i].FullName;
            }
            isNoError = IsSaveOk(type, index, paths);   
            go_Bottom1.SetActive(true);
            Show(type, isNoError);
        }
        if (isNoError)       // 没有错那就真正导入
        {
            switch (type)
            {
                case EGameType.XuLieTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_XLT_FromFile,(EXuLieTu)index, fileInfos);
                    if (index == 3 || index ==4)
                    {
                        mSelectIndex = 3;
                    }else if (index >=5)
                    {
                        mSelectIndex = 4;
                    }
                    break;
                case EGameType.XuLieTu222:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_XLT222_FromFile,(EXuLieTu222)index, fileInfos);
                    break;
                case EGameType.JiHeXuLieTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_JiHeXLT_FromFile,(EJiHeXuLieTuType)index, fileInfos);
                    break;
                case EGameType.TaoMingTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_TaoMing_FromFile, (ETaoMingType)index, fileInfos);
                    break;
                case EGameType.NormalTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_Jpg_FromFile, (ENormalTuType)index, fileInfos);
                    break;
                case EGameType.JiHeTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_JiHe_FromFile, (EJiHeType)index, fileInfos);
                    break;
                default:
                    throw new Exception("未定义");
            }
        }

    }


   
    private void E_DaoRuFromTuResult(EGameType type, ushort index, List<ResultBean> resultBeans, bool isFromDaoRu) // 通过 ResultBean 导入
    {
        mSelectIndex = index;
        string[] paths = new string[resultBeans.Count];
        for (int i = 0; i < resultBeans.Count; i++)
        {
            paths[i] = resultBeans[i].File.FullName;
        }
        bool isNoError = IsSaveOk(type, index, paths);
        if (isFromDaoRu)
        {
            go_Bottom3.SetActive(true);
        }
        else
        {
            go_Bottom2.SetActive(true);
        }
        Show(type,isNoError);
        if (isNoError)       // 没有错那就真正导入
        {
            if (!isFromDaoRu)
            {
                MyEventCenter.SendEvent(E_GameEvent.ZhuangOtherDRSuccess);
            }
            switch (type)
            {
                case EGameType.XuLieTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_XLT_FromResult, (EXuLieTu)index, resultBeans);
                    if (index == 3 || index == 4)
                    {
                        mSelectIndex = 3;
                    }
                    else if (index >= 5)
                    {
                        mSelectIndex = 4;
                    }
                    break;
                case EGameType.XuLieTu222:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_XLT222_FromResult, (EXuLieTu222)index, resultBeans);
                    break;
                case EGameType.JiHeXuLieTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_JiHeXLT_FromResult, (EJiHeXuLieTuType)index, resultBeans);
                    break;
                case EGameType.TaoMingTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_TaoMing_FromResult, (ETaoMingType)index, resultBeans);
                    break;
                case EGameType.NormalTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_Jpg_FromResult, (ENormalTuType)index, resultBeans);
                    break;
                case EGameType.JiHeTu:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRu_JiHe_FromResult, (EJiHeType)index, resultBeans);
                    break;
            }
        }


    }




    private void E_DaoRuAudioFromFiles(EAudioType type, List<FileInfo> fileInfos, bool isSave)
    {
        mSelectIndex = (ushort)type;
        bool isNoError = true;
        if (isSave)   // 要保存的才显示
        {
            string[] paths = new string[fileInfos.Count];
            for (int i = 0; i < fileInfos.Count; i++)
            {
                paths[i] = fileInfos[i].FullName;
            }
            isNoError = IsSaveOk(EGameType.Audio, (ushort)type, paths);
            go_Bottom1.SetActive(true);
            Show(EGameType.Audio, isNoError);
        }

        if (isNoError)
        {
            Ctrl_Coroutine.Instance.StartCoroutine(DownLoadAudio(type, fileInfos));
        }
    }

    public IEnumerator DownLoadAudio(EAudioType type, List<FileInfo> files)
    {
        foreach (FileInfo file in files)
        {
            Ctrl_LoadAudioClip.Instance.StartLoadAudioClip(file, (resBean) =>
            {
               MyEventCenter.SendEvent(E_GameEvent.DaoRu_Audio,type, resBean);
            });
            yield return new WaitForEndOfFrame();
        }
    }



    private void E_DaoRuAudioFromResult(EAudioType type, AudioResBean resBean)
    {
        mSelectIndex = (ushort)type;
        bool isNoError = IsSaveOk(EGameType.Audio, (ushort)type, new string[]{ resBean.SavePath});
        go_Bottom2.SetActive(true);
        Show(EGameType.Audio, isNoError);
        if (isNoError)
        {
            MyEventCenter.SendEvent(E_GameEvent.DaoRu_Audio, type, resBean);
        }
    }


}
