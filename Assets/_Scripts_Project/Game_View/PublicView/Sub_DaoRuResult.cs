using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


public class Sub_DaoRuResult : SubUI 
{


    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EDuoTuInfoType, ushort,ushort,List<FileInfo>>(E_GameEvent.RealyDaoRu_File, E_DaoRuTuFromFile);
        MyEventCenter.AddListener<EDuoTuInfoType, ushort,ushort,List<ResultBean>>(E_GameEvent.RealyDaoRu_Result, E_DaoRuFromTuResult);


        go_Ok = GetGameObject("Contant/Ok");
        go_Error = GetGameObject("Contant/Error");


        // 一个按钮
        go_Bottom1 = GetGameObject("Contant/BottomBtn1");
        AddButtOnClick("Contant/BottomBtn1", CloseThis);

        // 二个按钮
        go_Bottom2 = GetGameObject("Contant/BottomBtn2");
        tx_GoTo2 = Get<Text>("Contant/BottomBtn2/BtnGoTo/Text");
        AddButtOnClick("Contant/BottomBtn2/BtnGoTo", Btn_GoToDaoRuWhere);  
        AddButtOnClick("Contant/BottomBtn2/BtnSure", CloseThis);

        // 三个按钮
        go_Bottom3 = GetGameObject("Contant/BottomBtn3");
        tx_GoTo3 = Get<Text>("Contant/BottomBtn3/BtnGoTo/Text");
        AddButtOnClick("Contant/BottomBtn3/BtnGoTo", Btn_GoToDaoRuWhere);
        AddButtOnClick("Contant/BottomBtn3/BtnFanHui", CloseThis);
        AddButtOnClick("Contant/BottomBtn3/BtnNext", Btn_OnNextFolder);



        Get<Button>().onClick.AddListener(CloseThis);

    }



    #region 私有

    private ushort mCurrentBigIndex,mCurrentBottomIndex;
    private Text tx_GoTo2,tx_GoTo3; // 去那按钮的文字(1 没有的)

    private GameObject go_Ok,go_Error;
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


    public void ShowThis(bool isSaveOk, EDuoTuInfoType type)       // 显示 
    {
        mUIGameObject.SetActive(true);
        go_Ok.SetActive(isSaveOk);
        go_Error.SetActive(!isSaveOk);
        go_Bottom1.SetActive(false);go_Bottom2.SetActive(false);go_Bottom3.SetActive(false);
        
        switch (type)
        {
            case EDuoTuInfoType.SearchShow:
                go_Bottom1.SetActive(true);
                break;
            case EDuoTuInfoType.InfoShow:
                go_Bottom2.SetActive(true);
                tx_GoTo2.text = "去"+Ctrl_ContantInfo.Instance.LeftItemNames[mCurrentBigIndex]+"处";
                break;
            case EDuoTuInfoType.DaoRu:
                go_Bottom3.SetActive(true);
                tx_GoTo3.text = "去" + Ctrl_ContantInfo.Instance.LeftItemNames[mCurrentBigIndex]+"处";
                break;
            default:
                throw new Exception("未定义 —— "+ type);
        }
    }


    private void CloseThis()                                         // 关闭
    {
        mUIGameObject.SetActive(false);

    }




    //—————————————————— UI ——————————————————

    private void Btn_GoToDaoRuWhere()                                   // 点击 去到刚刚导入的地方
    {
        MyEventCenter.SendEvent(E_GameEvent.ChangeLeftItem, mCurrentBigIndex, mCurrentBottomIndex);
        CloseThis();
    }




    private void Btn_OnNextFolder()                                     // 点击 到下个文件夹
    {
        MyEventCenter.SendEvent(E_GameEvent.GoToNextFolderDaoRu);
        CloseThis();

    }



    //—————————————————— 事件 ——————————————————



    private void E_DaoRuTuFromFile(EDuoTuInfoType type,ushort bigIndex, ushort bottomIndex, List<FileInfo> fileInfos)      // 通过 FileInfo 导入
    {
        mCurrentBigIndex = bigIndex;
        mCurrentBottomIndex = bottomIndex;
        bool isSaveOk = Ctrl_XuLieTu.Instance.Save(bigIndex, bottomIndex,fileInfos.ToFullPaths());
        ShowThis(isSaveOk, type);
        if (isSaveOk)
        {
            MyEventCenter.SendEvent(E_GameEvent.DaoRu_FromFile, bigIndex, bottomIndex, fileInfos);
        }
    }


   
    private void E_DaoRuFromTuResult(EDuoTuInfoType type, ushort bigIndex, ushort bottomIndex, List<ResultBean> resultBeans) // 通过 ResultBean 导入
    {
        mCurrentBigIndex = bigIndex;
        mCurrentBottomIndex = bottomIndex;
        bool isSaveOk = Ctrl_XuLieTu.Instance.Save(bigIndex, bottomIndex, resultBeans.ToFullPaths());
        ShowThis(isSaveOk, type);
        if (isSaveOk)
        {
            MyEventCenter.SendEvent(E_GameEvent.DaoRu_FromResult, bigIndex, bottomIndex, resultBeans);
            switch (type)
            {
                case EDuoTuInfoType.DaoRu:
                    MyEventCenter.SendEvent(E_GameEvent.ChangeDaoRuGreenText, resultBeans);   // 告诉改颜色
                    break;
                case EDuoTuInfoType.InfoShow:
                    MyEventCenter.SendEvent(E_GameEvent.DaoRuSucees2Delete, resultBeans);
                    break;
                case EDuoTuInfoType.SearchShow:
                    break;
            }
        }

    }



}
