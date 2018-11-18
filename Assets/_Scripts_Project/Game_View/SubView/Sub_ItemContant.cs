using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public class Sub_ItemContant : SubUI            // 包含全部的内容
{


    public void Show(ushort index)
    {
        mUIGameObject.SetActive(true);
        l_ItemGOs[index].SetActive(true);
        mCurrentBigIndex = index;

    }


    public void Close(ushort index)
    {
        mUIGameObject.SetActive(false);
        l_ItemGOs[index].SetActive(false);
    }



    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<ushort,ushort,List<FileInfo>>(E_GameEvent.DaoRu_FromFile, E_OnDaoRuFromFile);


        for (ushort i = 0; i < 8; i++)
        {
            ushort bigIndex = i;
            // 8 个 Item
            l_ItemGOs[bigIndex] = GetGameObject("Item"+ bigIndex);

            // 8 个 内容 RectTransform
            RectTransform[] rts = new RectTransform[5];
            for (int j = 1; j < rts.Length+1; j++)
            {
                rts[j-1] = Get<RectTransform>("Item" + bigIndex + "/SrcollRect/FenLie"+j);
            }

            l_TopContant.Add(rts);

            // 给每个 UGUI_BtnToggleGroup 添加事件
            ScrollRect scroll = Get<ScrollRect>("Item" + bigIndex + "/SrcollRect");
            UGUI_BtnToggleGroup bottomGroup = Get<UGUI_BtnToggleGroup>("Item" + bigIndex + "/Bottom/Contant");
            bottomGroup.E_OnCloseOtherItem += (bottomIndex) =>
            {
                E_OnBottomClosePre(bigIndex, bottomIndex);
            };
            bottomGroup.E_OnChooseItem += (bottomIndex) =>
            {
                E_OnBottomChangeItem(bigIndex, bottomIndex, scroll);
            };
            bottomGroup.E_OnDoubleClickItem += E_OnBottomDoubleClick;


            // 添加所有底下的字
            Text[] txNames = new Text[5];
            for (int j = 0; j < txNames.Length; j++)
            {
                txNames[j] = Get<Text>("Item"+i+"/Bottom/Contant/GeShiItem"+(j+1)+"/TxBottomName");

            }
            l_BottomNames.Add(txNames);


            // 改名
            go_GaiNing = GetGameObject("GaiNing");
            tx_GaiMing = Get<Text>("GaiNing/Contant/Grid/Middle/TxGaiName");
            input_GaiMIng = Get<InputField>("GaiNing/Contant/Grid/Top/InputField");
            AddInputOnValueChanged(input_GaiMIng, (str) =>
            {
                tx_GaiMing.text = str;
            });
            AddButtOnClick("GaiNing/Contant/Grid/Bottom/BtnSure", Btn_SureGaiMing);
            AddButtOnClick("GaiNing/Contant/Grid/Bottom/BtnFalse",Btn_CloseGaiMing);

        }

    }



    public override void OnEnable()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j <5; j++)
            {
                l_BottomNames[i][j].text = Ctrl_Info.Instance.BottomName[i][j];
            }
        }


    }



    #region 私有

    private ushort mCurrentBigIndex,mCurrentBottomIndex;    // 当前处于那个大的Item索引，和小的索引
    private readonly GameObject[] l_ItemGOs = new GameObject[8];
    private readonly List<RectTransform[]> l_TopContant = new List<RectTransform[]>(8);
    private readonly List<Text[]> l_BottomNames = new List<Text[]>(8);


    // 改名
    private GameObject go_GaiNing;
    private InputField input_GaiMIng;
    private Text tx_GaiMing;



    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/ItemContant";
    }




    public override void OnDisable()
    {
    }

    #endregion




    private void E_OnBottomClosePre(ushort bigIndex,ushort bottomIndex)                            // 关闭之前的 Item
    {
        l_TopContant[bigIndex][bottomIndex].gameObject.SetActive(false);
    }

    private void E_OnBottomChangeItem(ushort bigIndex, ushort bottomIndex, ScrollRect scroll)      // 切换 Item
    {
        l_TopContant[bigIndex][bottomIndex].gameObject.SetActive(true);
        scroll.content = l_TopContant[bigIndex][bottomIndex];

        mCurrentBottomIndex = bottomIndex;

    }


    private void E_OnBottomDoubleClick(ushort index)            // 双击 要改名
    {
        go_GaiNing.SetActive(true);
    }


    private void Btn_SureGaiMing()                             // 确定改名
    {
        if (!string.IsNullOrEmpty(input_GaiMIng.text))
        {
            l_BottomNames[mCurrentBigIndex][mCurrentBottomIndex].text = input_GaiMIng.text;
            Ctrl_Info.Instance.BottomName[mCurrentBigIndex][mCurrentBottomIndex] = input_GaiMIng.text;
        }
        Btn_CloseGaiMing();
    }


    private void Btn_CloseGaiMing()                            // 关闭改名
    {
        go_GaiNing.SetActive(false);
        input_GaiMIng.text = "";
    }




    //—————————————————— 事件 ——————————————————


    private void E_OnDaoRuFromFile(ushort bigIndex, ushort bottomIndex, List<FileInfo> fileInfos)  // 通过 FileInfo 导入
    {

    }



}
