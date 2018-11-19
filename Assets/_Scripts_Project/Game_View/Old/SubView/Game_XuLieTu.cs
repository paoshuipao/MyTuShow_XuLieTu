/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public enum EXuLieTu
{
    G1Zheng,
    G2Zheng_XiTong,
    G3Zheng_Big,
    G4Two_Heng,
    G4Two_Shu,
    G5Three_Heng,
    G5Three_Shu,
}


public class Game_XuLieTu : SubUI
{
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


    #region 私有

    private bool isSelect; // 是否之前点击了
    private EXuLieTu mCurrentIndex;
    private GameObject go_CurrentSelect; // 当前选择的对象
    private const string ITEM_STR1 = "GeShiItem1";
    private const string ITEM_STR2 = "GeShiItem2";
    private const string ITEM_STR3 = "GeShiItem3";
    private const string ITEM_STR4 = "GeShiItem4";
    private const string ITEM_STR5 = "GeShiItem5";


    // 模版
    private GameObject go_MoBan;
    private const string CREATE_FILE_NAME = "XuLieTu"; // 模版产生的名

    // 上方
    private GameObject go_Top;
    private DTToggle5_Fade toggle5_Contant;
    private RectTransform rt_Grid1, rt_Grid2, rt_Grid3, rt_Grid4_Shu, rt_Grid4_Heng, rt_Grid5_Shu, rt_Grid5_Heng;
    private Button btn_DaoRu;


    // 底下
    private GameObject go_Bottom;
    private UGUI_ToggleGroup tg_BottomContrl;
    private ScrollRect mScrollRect;
    private Text tx_BottomName1, tx_BottomName2, tx_BottomName3;


    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/XuLieTu";
    }


    public override void OnDisable()
    {
    }


    private IEnumerator CheckoubleClick() // 检测是否双击
    {
        isSelect = true;
        yield return new WaitForSeconds(MyDefine.DoubleClickTime);
        isSelect = false;
    }


    private Sprite[] GetSpriteList(ResultBean[] beans)
    {
        Sprite[] sps = new Sprite[beans.Length];
        for (int i = 0; i < beans.Length; i++)
        {
            sps[i] = beans[i].SP;
        }
        return sps;
    }



    private RectTransform GetParentRT(EXuLieTu tuType)
    {
        RectTransform rt = null; // 放在那里
        switch (tuType)
        {
            case EXuLieTu.G1Zheng:
                rt = rt_Grid1;
                break;
            case EXuLieTu.G2Zheng_XiTong:
                rt = rt_Grid2;
                break;
            case EXuLieTu.G3Zheng_Big:
                rt = rt_Grid3;
                break;
            case EXuLieTu.G4Two_Heng:
                rt = rt_Grid4_Heng;
                break;
            case EXuLieTu.G4Two_Shu:
                rt = rt_Grid4_Shu;
                break;
            case EXuLieTu.G5Three_Heng:
                rt = rt_Grid5_Heng;
                break;
            case EXuLieTu.G5Three_Shu:
                rt = rt_Grid5_Shu;
                break;
            default:
                throw new Exception("还有其他？");
        }
        return rt;
    }


    private void InitMoBan(Transform t, ResultBean[] resultBeans) // 初始化模版
    {
        GameObject go = t.gameObject;
        Ctrl_TextureInfo.AddXuLieTu(resultBeans);
        t.Find("Tu").GetComponent<UGUI_SpriteAnim>().ChangeAnim(GetSpriteList(resultBeans));
        t.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (go.Equals(go_CurrentSelect) && isSelect) // 双击
            {
                go_Top.SetActive(false);
                go_Bottom.SetActive(false);
                MyEventCenter.SendEvent(E_GameEvent.ShowDuoTuInfo, EGameType.XuLieTu, resultBeans);

            }
            else // 单击
            {
                go_CurrentSelect = go;
                Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
            }
        });
    }


    private void DeleteOneLine(EXuLieTu type)           // 删除整行
    {
        Ctrl_TextureInfo.Instance.DeleteXuLieTuOneLine(type);
        RectTransform rt = GetParentRT(type);
        for (int i = 0; i < rt.childCount; i++)
        {
            UnityEngine.Object.Destroy(rt.GetChild(i).gameObject);
        }
    }


    #endregion


    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EXuLieTu, List<FileInfo>>(E_GameEvent.DaoRu_XLT_FromFile, E_OnDaoRu);        // 导入
        MyEventCenter.AddListener<EXuLieTu, List<ResultBean>>(E_GameEvent.DaoRu_XLT_FromResult, E_ResultDaoRu);  // 结果导入
        MyEventCenter.AddListener<EGameType>(E_GameEvent.ClickTrue, E_DelteTrue);                                 // 确定删除
        MyEventCenter.AddListener(E_GameEvent.DelteAll, E_DeleteAll);                                             // 删除全部
        MyEventCenter.AddListener<EGameType>(E_GameEvent.CloseDuoTuInfo, E_CloseDuoTuInfo);                       // 关闭多图信息
        MyEventCenter.AddListener<EGameType,string[]>(E_GameEvent.OnClickNoSaveThisDuoTu, E_DeleteOne);           // 多图信息中删除一个



        // 模版
        go_MoBan = GetGameObject("Top/Contant/MoBan");


        // 上方
        go_Top = GetGameObject("Top");
        toggle5_Contant = Get<DTToggle5_Fade>("Top/Contant/ScrollView");
        mScrollRect = Get<ScrollRect>("Top/Contant/ScrollView");
        rt_Grid1 = Get<RectTransform>("Top/Contant/ScrollView/Item1");
        rt_Grid2 = Get<RectTransform>("Top/Contant/ScrollView/Item2");
        rt_Grid3 = Get<RectTransform>("Top/Contant/ScrollView/Item3");
        rt_Grid4_Shu = Get<RectTransform>("Top/Contant/ScrollView/Item4/Shu");
        rt_Grid4_Heng = Get<RectTransform>("Top/Contant/ScrollView/Item4/Heng");
        rt_Grid5_Shu = Get<RectTransform>("Top/Contant/ScrollView/Item5/Shu");
        rt_Grid5_Heng = Get<RectTransform>("Top/Contant/ScrollView/Item5/Heng");



        // 底下
        go_Bottom = GetGameObject("Bottom");
        tg_BottomContrl = Get<UGUI_ToggleGroup>("Bottom/Contant");
        tg_BottomContrl.OnChangeValue += E_OnBottomContrlChange;
        tx_BottomName1 = Get<Text>("Bottom/Contant/GeShiItem1/Text");
        tx_BottomName2 = Get<Text>("Bottom/Contant/GeShiItem2/Text");
        tx_BottomName3 = Get<Text>("Bottom/Contant/GeShiItem3/Text");


        // 右边
        btn_DaoRu = Get<Button>("Top/Left/DaoRu");
        AddButtOnClick(btn_DaoRu, Btn_OnDaoRu);
        AddButtOnClick("Top/Left/DeleteAll", Btn_DeleteOneLine);




    }



    public override void OnEnable()
    {

        Get<UGUI_Grid>("Top/Contant/ScrollView/Item1").CallSize = Ctrl_UserInfo.XLTSize1;
        Get<UGUI_Grid>("Top/Contant/ScrollView/Item2").CallSize = Ctrl_UserInfo.XLTSize2;
        Get<UGUI_Grid>("Top/Contant/ScrollView/Item3").CallSize = Ctrl_UserInfo.XLTSize3;


        // 底下的文字
        tx_BottomName1.text = Ctrl_UserInfo.BottomXuLieTuName[0];
        tx_BottomName2.text = Ctrl_UserInfo.BottomXuLieTuName[1];
        tx_BottomName3.text = Ctrl_UserInfo.BottomXuLieTuName[2];

    }



    //——————————————————— UI —————————————————


    private void Btn_OnDaoRu()                 // 点击导入
    {
        MyOpenFileOrFolder.OpenFile(Ctrl_UserInfo.Instance.DaoRuFirstPath, "选择多个文件（序列图）", EFileFilter.TuAndAll,
            (filePaths) =>
            {
                List<FileInfo> fileInfos = new List<FileInfo>(filePaths.Length);
                foreach (string filePath in filePaths)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (MyFilterUtil.IsTu(fileInfo))
                    {
                        fileInfos.Add(fileInfo);
                    }
                    else
                    {
                        MyLog.Red("选择了其他的格式文件 —— " + fileInfo.Name);
                    }
                }
                MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromFile,EGameType.XuLieTu, (ushort)mCurrentIndex, fileInfos, true);
            });
    }



    private void Btn_DeleteOneLine()           // 点击删除
    {
        string tittle = "删除";
        switch (mCurrentIndex)
        {
            case EXuLieTu.G1Zheng:
                tittle += " 小等边 的所有序列图片？";
                break;
            case EXuLieTu.G2Zheng_XiTong:
                tittle += " 系统等边 的所有序列图片？";
                break;
            case EXuLieTu.G3Zheng_Big:
                tittle += " 大等边 的所有序列图片？";
                break;
            case EXuLieTu.G4Two_Heng:
                tittle += " 2倍 的所有序列图片？";
                break;
            case EXuLieTu.G5Three_Heng:
                tittle += " 3倍 的所有序列图片？";
                break;
        }
        MyEventCenter.SendEvent(E_GameEvent.ShowIsSure, EGameType.XuLieTu, tittle);
    }



    private void E_OnBottomContrlChange(string changeName)     // 总控制，底下的切换
    {
        switch (changeName)
        {
            case ITEM_STR1:
                toggle5_Contant.Change2One();
                mCurrentIndex = EXuLieTu.G1Zheng;
                btn_DaoRu.interactable = true;
                mScrollRect.content = rt_Grid1;
                break;
            case ITEM_STR2:
                toggle5_Contant.Change2Two();
                mCurrentIndex = EXuLieTu.G2Zheng_XiTong;
                btn_DaoRu.interactable = true;
                mScrollRect.content = rt_Grid2;
                break;
            case ITEM_STR3:
                toggle5_Contant.Change2Three();
                mCurrentIndex = EXuLieTu.G3Zheng_Big;
                btn_DaoRu.interactable = true;
                mScrollRect.content = rt_Grid3;
                break;
            case ITEM_STR4:
                toggle5_Contant.Change2Four();
                mCurrentIndex = EXuLieTu.G4Two_Heng;
                btn_DaoRu.interactable = false;
                mScrollRect.content = rt_Grid4_Shu;
                break;
            case ITEM_STR5:
                toggle5_Contant.Change2Five();
                mCurrentIndex = EXuLieTu.G5Three_Heng;
                btn_DaoRu.interactable = false;
                mScrollRect.content = rt_Grid5_Shu;
                break;
        }
    }




    //—————————————————— 事件 ——————————————————


    private void E_OnDaoRu(EXuLieTu tuType, List<FileInfo> fileInfos)           // 接收导入事件 ，创建一个序列图
    {

        // 1. 创建一个实例
        Transform t = InstantiateMoBan(go_MoBan, GetParentRT(tuType), CREATE_FILE_NAME);

        // 2. 加载图片
        MyLoadTu.LoadMultipleTu(fileInfos, (resBean) =>
        {
            // 3. 完成后把图集加上去
            InitMoBan(t, resBean);
        });
    }


    private void E_ResultDaoRu(EXuLieTu tuType, List<ResultBean> resultBeans)
    {
        Transform t = InstantiateMoBan(go_MoBan, GetParentRT(tuType), CREATE_FILE_NAME);
        InitMoBan(t, resultBeans.ToArray());
    }




    //————————————————————————————————————

    private void E_DelteTrue(EGameType type)               // 真的删除
    {
        if (type == EGameType.XuLieTu)
        {
            switch (mCurrentIndex)
            {
                case EXuLieTu.G4Two_Heng:
                case EXuLieTu.G4Two_Shu:
                    DeleteOneLine(EXuLieTu.G4Two_Heng);
                    DeleteOneLine(EXuLieTu.G4Two_Shu);
                    break;
                case EXuLieTu.G5Three_Heng:
                case EXuLieTu.G5Three_Shu:
                    DeleteOneLine(EXuLieTu.G5Three_Heng);
                    DeleteOneLine(EXuLieTu.G5Three_Shu);
                    break;
                default:
                    DeleteOneLine(mCurrentIndex);
                    break;
            }
        }
    }



    private void E_DeleteAll()                             // 删除所有
    {
        go_CurrentSelect = null;
        foreach (EXuLieTu type in Enum.GetValues(typeof(EXuLieTu)))
        {
            DeleteOneLine(type);
        }

    }




    private void E_CloseDuoTuInfo(EGameType type)                           // 关闭显示多图信息
    {
        if (type == EGameType.XuLieTu)
        {
            go_Top.SetActive(true);
            go_Bottom.SetActive(true);
        }
    }


    private void E_DeleteOne(EGameType type, string[] paths)               // 多图信息中删除一个 
    {
        if (type == EGameType.XuLieTu)
        {
            Ctrl_TextureInfo.Instance.DeleteXuLieTuSave(mCurrentIndex, paths);
            UnityEngine.Object.Destroy(go_CurrentSelect);
        }
    }




}*/