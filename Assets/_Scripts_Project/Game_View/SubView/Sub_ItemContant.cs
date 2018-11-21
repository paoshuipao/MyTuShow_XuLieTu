using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public class Sub_ItemContant : SubUI            // 包含全部的内容
{

    public void Show(ushort bigIndex)
    {
        mCurrentBigIndex = bigIndex;

        mUIGameObject.SetActive(true);
        l_ItemGOs[bigIndex].SetActive(true);
    }



    public void Show(ushort bigIndex,ushort bottomIndex)
    {
        mCurrentBigIndex = bigIndex;
        mCurrentBottomIndex = bottomIndex;

        mUIGameObject.SetActive(true);
        l_ToggleGroup[bigIndex].ChangeItem(bottomIndex);
        l_ItemGOs[bigIndex].SetActive(true);
        l_TopContant[bigIndex][bottomIndex].gameObject.SetActive(true);


    }


    public void Close(ushort index)
    {
        mUIGameObject.SetActive(false);
        l_ItemGOs[index].SetActive(false);
    }



    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<ushort,ushort,List<FileInfo>>(E_GameEvent.DaoRu_FromFile, E_OnDaoRuFromFile);
        MyEventCenter.AddListener<ushort,ushort,List<ResultBean>>(E_GameEvent.DaoRu_FromResult, E_OnDaoRuFromResult);
        MyEventCenter.AddListener<EDuoTuInfoType>(E_GameEvent.CloseDuoTuInfo, E_CloseDuoTuInfo);                       // 关闭多图信息
        MyEventCenter.AddListener<EDuoTuInfoType,string[]>(E_GameEvent.OnClickNoSaveThisDuoTu, E_DeleteOne);           // 多图信息中删除一个
        MyEventCenter.AddListener(E_GameEvent.OnClickSureDeleteAll, E_SureDeleteAl);                                   // 删除所有
        MyEventCenter.AddListener<List<ResultBean>>(E_GameEvent.DaoRuSucees2Delete, E_DaoRuSucees2Delete);            // 转换成功


        // 模版
        go_MoBan = GetGameObject("MoBan");


        for (ushort i = 0; i < 8; i++)
        {
            ushort bigIndex = i;
            // 8 个 Item
            l_ItemGOs[bigIndex] = GetGameObject("Item"+ bigIndex);

            // 8 个 内容 RectTransform
            RectTransform[] rts = new RectTransform[5];
            for (int j = 1; j < rts.Length+1; j++)
            {
                rts[j - 1] = Get<RectTransform>("Item" + bigIndex + "/SrcollRect/FenLie" + j);
       
            }

            l_TopContant[i]= rts;

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
            l_ToggleGroup[i] = bottomGroup;

            // 添加所有底下的字
            Text[] txNames = new Text[5];
            for (int j = 0; j < txNames.Length; j++)
            {
                txNames[j] = Get<Text>("Item"+i+"/Bottom/Contant/GeShiItem"+(j+1)+"/TxBottomName");

            }
            l_BottomNames[i] = txNames;


            // 改名
            go_GaiNing = GetGameObject("GaiNing");
            tx_YuanMing = Get<Text>("GaiNing/Contant/Grid/Middle/TxYuan");
            tx_GaiMing = Get<Text>("GaiNing/Contant/Grid/Middle/TxGaiName");
            input_GaiMIng = Get<InputField>("GaiNing/Contant/Grid/Top/InputField");
            AddInputOnValueChanged(input_GaiMIng, (str) =>
            {
                tx_GaiMing.text = str;
            });
            AddButtOnClick("GaiNing/Contant/Grid/Bottom/BtnSure", Btn_SureGaiMing);
            AddButtOnClick("GaiNing/Contant/Grid/Bottom/BtnFalse",Btn_CloseGaiMing);

        }



        // 最右边
        AddButtOnClick("RightContrl/DaoRu", Btn_DaoRu);
        AddButtOnClick("RightContrl/DeleteAll", Btn_DaoClear);



        // 清空一行
        go_ClearOneLine = GetGameObject("ClearOneLine");
        tx_ClearTittle = Get<Text>("ClearOneLine/Contant/Tittle");
        tx_ClearTip = Get<Text>("ClearOneLine/Contant/Tip");
        AddButtOnClick("ClearOneLine/Contant/Bottom/BtnSure", Btn_SureClearOneLine);
        AddButtOnClick("ClearOneLine/Contant/Bottom/BtnFalse", Btn_CloseClearUI);
    }



    public override void OnEnable()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j <5; j++)
            {
                l_BottomNames[i][j].text = Ctrl_ContantInfo.Instance.BottomName[i][j];
                l_Grids[i][j].CallSize = Ctrl_ContantInfo.Instance.l_GridSize[i][j].CurrentSize;

                Get<TopTipItem>("Item" + i + "/Bottom/Contant/GeShiItem" + (j + 1)).mGrid = l_Grids[i][j];
            }
        }

    }



    #region 私有

    private GameObject go_CurrentSelect; // 当前选择的对象
    private bool isSelect;               // 是否之前点击了


    private ushort mCurrentBigIndex,mCurrentBottomIndex;    // 当前处于那个大的Item索引，和小的索引
    private readonly GameObject[] l_ItemGOs = new GameObject[8];                        // 8个总对象
    private readonly RectTransform[][] l_TopContant = new RectTransform[8][]; // 8个下的分别5个RectTransform
    private readonly Text[][] l_BottomNames = new Text[8][];                  // 8个下的分别5个底下名称
    private readonly UGUI_BtnToggleGroup[] l_ToggleGroup = new UGUI_BtnToggleGroup[8];


    private UGUI_Grid[][] l_Grids;     // 所有的 UGUI_Grid 集合


    public void SetUGUI_GridList(UGUI_Grid[][] grids)
    {
        l_Grids = grids;
    }


    // 模版
    private GameObject go_MoBan;



    // 改名
    private GameObject go_GaiNing;
    private InputField input_GaiMIng;
    private Text tx_YuanMing,tx_GaiMing;


    // 清空一行
    private GameObject go_ClearOneLine;
    private Text tx_ClearTittle,tx_ClearTip;



    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/ItemContant";
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


    //—————————————————— 改名 ——————————————————


    private void E_OnBottomDoubleClick(ushort index)            // 双击 要改名
    {
        go_GaiNing.SetActive(true);
        tx_YuanMing.text = l_BottomNames[mCurrentBigIndex][mCurrentBottomIndex].text;
    }


    private void Btn_SureGaiMing()                             // 确定改名
    {
        string changeName = input_GaiMIng.text;
        if (!string.IsNullOrEmpty(changeName))
        {
            l_BottomNames[mCurrentBigIndex][mCurrentBottomIndex].text = changeName;
            Ctrl_ContantInfo.Instance.BottomName[mCurrentBigIndex][mCurrentBottomIndex] = changeName;
            MyEventCenter.SendEvent(E_GameEvent.GaiBottomName, mCurrentBigIndex, mCurrentBottomIndex, changeName);
        }
        Btn_CloseGaiMing();
    }


    private void Btn_CloseGaiMing()                            // 关闭改名
    {
        go_GaiNing.SetActive(false);
        input_GaiMIng.text = "";
    }


    //—————————————————— 最右边 ——————————————————


    private void Btn_DaoRu()                           // 点击导入
    {
        MyOpenFileOrFolder.OpenFile(Ctrl_DaoRuInfo.Instance.DaoRuFirstPath, "选择多个文件（序列图）", EFileFilter.TuAndAll,
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
                MyEventCenter.SendEvent(E_GameEvent.RealyDaoRu_File, EDuoTuInfoType.SearchShow,mCurrentBigIndex, mCurrentBottomIndex, fileInfos);
            });
    }


    private void Btn_DaoClear()                        // 点击清空
    {
        go_ClearOneLine.SetActive(true);
        int num = l_TopContant[mCurrentBigIndex][mCurrentBottomIndex].childCount;
        if (num<=0)
        {
            tx_ClearTip.text = "当前页一张序列图都没有,不用清空";
        }
        else
        {
            tx_ClearTittle.text = "清空当前<color=white> " + l_BottomNames[mCurrentBigIndex][mCurrentBottomIndex].text + " </color>页所有？";
            tx_ClearTip.text = "当前页总共有序列图<color=white> " + num + " </color>张";
        }
        
    }


    private void Btn_SureClearOneLine()                // 确定清空一行
    {
        DeleteOneLine(mCurrentBigIndex, mCurrentBottomIndex);
        Btn_CloseClearUI();
    }



    private void DeleteOneLine(ushort bigIndex,ushort bottomIndex)                 // 删除一行
    {
        RectTransform rt = l_TopContant[bigIndex][bottomIndex];
        int num = rt.childCount;
        if (num > 0)
        {
            for (int i = 0; i < rt.childCount; i++)
            {
                Object.Destroy(rt.GetChild(i).gameObject);
            }
            Ctrl_XuLieTu.Instance.ClearOneLine(bigIndex, bottomIndex);
        }
    }


    private void Btn_CloseClearUI()                  // 关闭清空的界面
    {
        go_ClearOneLine.SetActive(false);

    }




    private void Slider_OnSizeChange()                 // 拖动大小滑动条
    {

    }


    //—————————————————— 事件 ——————————————————


    private void E_OnDaoRuFromFile(ushort bigIndex, ushort bottomIndex, List<FileInfo> fileInfos)          // 通过 FileInfo 导入
    {
        // 1. 创建一个实例
        Transform t = InstantiateMoBan(go_MoBan, l_TopContant[bigIndex][bottomIndex]);

        // 2. 加载图片
        MyLoadTu.LoadMultipleTu(fileInfos, (resBean) =>
        {
            // 3. 完成后把图集加上去
            InitMoBan(t, resBean);
        });
    }




    private void E_OnDaoRuFromResult(ushort bigIndex,ushort bottomIndex,List<ResultBean> resultBeans)      // 通过 ResultBean 导入
    {
        Transform t = InstantiateMoBan(go_MoBan, l_TopContant[bigIndex][bottomIndex]);
        InitMoBan(t, resultBeans.ToArray());
    }



    private void InitMoBan(Transform t, ResultBean[] resultBeans)                                           // 初始化模版
    {
        GameObject go = t.gameObject;
        Ctrl_XuLieTu.Instance.CeateMobanInitThis(resultBeans);
        t.Find("Tu").GetComponent<UGUI_SpriteAnim>().ChangeAnim(resultBeans.ToSprites());
        t.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (go.Equals(go_CurrentSelect) && isSelect) // 双击
            {

                mUIGameObject.SetActive(false);       // 显示信息时把整个给隐藏了
                MyEventCenter.SendEvent(E_GameEvent.ShowDuoTuInfo, resultBeans, EDuoTuInfoType.InfoShow);
            }
            else // 单击
            {
                go_CurrentSelect = go;
                Ctrl_Coroutine.Instance.StartCoroutine(CheckoubleClick());
            }
        });
    }




    //————————————————————————————————————

    
    private void E_CloseDuoTuInfo(EDuoTuInfoType type)                  // 关闭显示多图信息
    {
        if (type == EDuoTuInfoType.InfoShow)
        {
            mUIGameObject.SetActive(true);
        }
    }


    private void E_DeleteOne(EDuoTuInfoType type, string[] paths)      // 多图信息中删除一个 
    {
        if (type == EDuoTuInfoType.InfoShow)
        {
            Ctrl_XuLieTu.Instance.DeleteOne(mCurrentBigIndex, mCurrentBottomIndex, paths);
            Object.Destroy(go_CurrentSelect);
        }
    }



    private void E_SureDeleteAl()                                     // 确定清空所有图片
    {
        for (ushort i = 0; i < 8; i++)
        {
            for (ushort j = 0; j < 5; j++)
            {
                DeleteOneLine(i,j);
            }
        }
    }


    private void E_DaoRuSucees2Delete(List<ResultBean>  resultBeans)             // 转换成功，需要把转换前的删除
    {
        Ctrl_XuLieTu.Instance.DeleteOne(mCurrentBigIndex,mCurrentBottomIndex, resultBeans.ToFullPaths());
        Object.Destroy(go_CurrentSelect);
        go_CurrentSelect = null;

    }



}


