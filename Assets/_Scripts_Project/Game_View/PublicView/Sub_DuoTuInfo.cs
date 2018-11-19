using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


public enum EDuoTuInfoType
{
    DaoRu,           // 导入
    InfoShow,        // 已导入的图片双击
    SearchShow,      // 搜索出来的图片双击
}


public class Sub_DuoTuInfo : SubUI
{

    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<ResultBean[], EDuoTuInfoType>(E_GameEvent.ShowDuoTuInfo, E_Show);    // 显示
        MyEventCenter.AddListener(E_GameEvent.ItemChange, E_OnChangeLeftItem);      // 左边改



        AddButtOnClick("BtnClose", Btn_OnCloseShowInfo);

        #region 大图显示

        rtAnimTu = Get<RectTransform>("Contant/Left/D2_Tu/Tu/AnimTu");
        anim_Tu = Get<UGUI_SpriteAnim>("Contant/Left/D2_Tu/Tu/AnimTu/Anim");
 
        tx_WidthSize = Get<Text>("Contant/Left/D2_Tu/Bottom/SliderWidth/TxValue");
        slider_Width = Get<Slider>("Contant/Left/D2_Tu/Bottom/SliderWidth/Slider");
        tx_HeightSize = Get<Text>("Contant/Left/D2_Tu/Bottom/SliderHeight/TxValue");
        slider_Height = Get<Slider>("Contant/Left/D2_Tu/Bottom/SliderHeight/Slider");
        slider_Width.maxValue = Max_TuSize;
        slider_Height.maxValue = Max_TuSize;

        AddSliderOnValueChanged(slider_Width, (value) =>
        {
            SetTuSize(value);
        });
        AddSliderOnValueChanged(slider_Height, (value) =>
        {
            SetTuSize(0, value);
        });
        AddButtOnClick("Contant/Left/D2_Tu/Bottom/BtnSize/BtnPlusHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 0.5f, yuanLaiHidth * 0.5f);
        });
        AddButtOnClick("Contant/Left/D2_Tu/Bottom/BtnSize/BtnFirst", () =>
        {
            SetTuSize(yuanLaiWidth, yuanLaiHidth);
        });
        AddButtOnClick("Contant/Left/D2_Tu/Bottom/BtnSize/BtnAddHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 1.5f, yuanLaiHidth * 1.5f);
        });
        AddButtOnClick("Contant/Left/D2_Tu/Bottom/BtnSize/BtnAddTwo", () =>
        {
            SetTuSize(yuanLaiWidth * 2f, yuanLaiHidth * 2f);
        });

        #endregion


        // 条目
        moBan_Item = GetGameObject("Contant/Left/D2_Item/MoBan");
        rt_GridContant = Get<RectTransform>("Contant/Left/D2_Item/Contant");




        // 右
        tx_Name = Get<Text>("Contant/Right/Top/TxInfo/Name/Name");
        tx_Num = Get<Text>("Contant/Right/Top/TxInfo/Num/Num");
        tx_Size = Get<Text>("Contant/Right/Top/TxInfo/Size/Num");

        // 切换
        go_D2Tu = GetGameObject("Contant/Left/D2_Tu");
        go_D2Item = GetGameObject("Contant/Left/D2_Item");
        tx_ChangeText = Get<Text>("Contant/Right/Top/Btn/BtnQieHuan/Text");
        AddButtOnClick("Contant/Right/Top/Btn/BtnQieHuan", Btn_OnChangeBiTu);


        // 打开文件、速度、不保存
        AddButtOnClick("Contant/Right/Top/Btn/BtnOpenFolder", Btn_OnOpenFolder);
        AddSliderOnValueChanged("Contant/Right/Top/Btn/Speed/Slider", Sldier_OnSpeedChange);
        go_Delete = GetGameObject("Contant/Right/Top/Btn/BtnIsDelete");
        AddButtOnClick("Contant/Right/Top/Btn/BtnIsDelete", Btn_OnNoSaveThis);



        // 右下 导入 
        go_AllDaoRu = GetGameObject("Contant/Right/DaoRu");
        for (ushort i = 0; i < 8; i++)
        {
            // 标题
            l_TittleNames[i] = Get<Text>("Contant/Right/DaoRu/Contant/Item_Item" + i + "/TxTittle");

            // 每个按钮文字
            Text[] eachList = new Text[5];
            for (ushort j = 0; j < 5; j++)
            {
                eachList[j] = Get<Text>("Contant/Right/DaoRu/Contant/Item_Item" + i + "/Contant/Btn"+j+"/ItemDaoRu");
                ushort bigIndex = i;
                ushort bottomIndex = j;
                AddButtOnClick("Contant/Right/DaoRu/Contant/Item_Item" + i + "/Contant/Btn" + j, () =>
                    {
                        ManyBtn_DaoRu(bigIndex, bottomIndex);
                    });
            }
            l_DaoRuTexts[i] = eachList;
        }

    }


    public override void OnEnable()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                l_DaoRuTexts[i][j].text = Ctrl_Info.Instance.BottomName[i][j];
                Get<TopTipItem>("Contant/Right/DaoRu/Contant/Item_Item" + i + "/Contant/Btn" + j).mGrid = l_Grids[i][j];

            }
        }

    }


    #region 私有

    private UGUI_Grid[][] l_Grids;

    public void SetUGUI_GridList(UGUI_Grid[][] grids)
    {
        l_Grids = grids;
    }




    private const ushort Max_TuSize = 400;   // 限制图片最大的大小
    private EDuoTuInfoType mCurrentType;
    private ResultBean[] mCurrentBeans;

    // 左边的大图
    private RectTransform rtAnimTu;
    private UGUI_SpriteAnim anim_Tu;
    private Slider slider_Width, slider_Height;
    private Text tx_WidthSize, tx_HeightSize;
    private Vector2 TuSize = new Vector2(512, 512);
    private float yuanLaiWidth, yuanLaiHidth;

    // 左边的条目
    private bool isFirstShowItem = true;
    private GameObject moBan_Item;
    private RectTransform rt_GridContant;
    private Dictionary<GameObject, ResultBean> itemSelectK_ResutltV = new Dictionary<GameObject, ResultBean>();     // item每行的作为 Key 结果为Value


    // 切换
    private bool isShowBigTu = true;
    private GameObject go_D2Tu, go_D2Item;
    private Text tx_ChangeText;
    private GameObject mCuurentChooseBg;




    // 右
    private GameObject go_Delete;
    private GameObject go_AllDaoRu;
    private Text tx_Name,tx_Num,tx_Size;




    private readonly Text[] l_TittleNames = new Text[8];
    private readonly Text[][] l_DaoRuTexts = new Text[8][];


    public override string GetUIPathForRoot()
    {
        return "Right/DuoTuInfo";
    }




    public override void OnDisable()
    {

    }


    private void ShowWhicContant(bool showBigTu)                      // 显示那个 内容
    {
        if (showBigTu)        // 显示大图
        {
            isShowBigTu = true;
            go_D2Tu.SetActive(true);
            go_D2Item.SetActive(false);
            tx_ChangeText.text = "切换到栏目";
        }
        else
        {
            isShowBigTu = false;
            go_D2Tu.SetActive(false);
            go_D2Item.SetActive(true);
            tx_ChangeText.text = "还原到大图";
        }
    }


    private void SetTuSize(float width = 0, float height = 0)         // 设置图大小
    {
        if (width > 0)
        {
            if (width < 8)
            {
                width = 8;
            }
            if (width > Max_TuSize)
            {
                width = Max_TuSize;
            }
            TuSize.x = width;
            slider_Width.value = width;
            tx_WidthSize.text = width.ToString();
        }
        if (height > 0)
        {
            if (height < 8)
            {
                height = 8;
            }
            if (height > Max_TuSize)
            {
                height = Max_TuSize;
            }
            TuSize.y = height;
            slider_Height.value = height;
            tx_HeightSize.text = height.ToString();
        }
        rtAnimTu.sizeDelta = TuSize;
    }



    #endregion



    private void Btn_OnOpenFolder()                     // 点击打开文件夹
    {
        FileInfo file1 = mCurrentBeans[0].File;
        DirectoryInfo dir = file1.Directory;
        if (null!=dir)
        {
            Application.OpenURL(dir.FullName);   
        }
    }


    private void Btn_OnChangeBiTu()                     // 点击切换成大图或者条目
    {
        ShowWhicContant(!isShowBigTu);
        if (isFirstShowItem)          // 第一次点击切换成条目
        {
            isFirstShowItem = false;
            Ctrl_Coroutine.Instance.StartCoroutine(StartLoadItemu());
        }
    }



    private void Sldier_OnSpeedChange(float value)      // 拖动滑动条改变速度
    {
        anim_Tu.FPS = 0.5f / value;
    }

    private void Btn_OnNoSaveThis()                     // 点击不保存这个
    {
        MyEventCenter.SendEvent(E_GameEvent.OnClickNoSaveThisDuoTu, mCurrentType, mCurrentBeans.ToFullPaths());
        Btn_OnCloseShowInfo();
    }


    private void Btn_OnCloseShowInfo()                 // 关闭打开的信息
    {
        mUIGameObject.SetActive(false);
        mCurrentBeans = null;
        MyEventCenter.SendEvent(E_GameEvent.CloseDuoTuInfo, mCurrentType);


        if (itemSelectK_ResutltV.Count > 0)
        {
            List<GameObject> list = new List<GameObject>(itemSelectK_ResutltV.Keys);
            for (int i = 0; i < list.Count; i++)
            {
                Object.Destroy(list[i]);
            }
            itemSelectK_ResutltV.Clear();
        }

    }




    private void ManyBtn_DaoRu(ushort bigIndex,ushort bottomIndex)                       // 多项的导入
    {
        EButtonType buttonTyp;
        switch (mCurrentType)
        {
            case EDuoTuInfoType.DaoRu:
                buttonTyp = EButtonType.ThreeBtn;
                break;
            case EDuoTuInfoType.InfoShow:
                buttonTyp = EButtonType.TwoBtn;
                break;
            case EDuoTuInfoType.SearchShow:
                buttonTyp = EButtonType.OneBtn;
                break;
            default:
                throw new Exception("未定义");
        }

        MyEventCenter.SendEvent(E_GameEvent.RealyDaoRu_Result, buttonTyp, bigIndex, bottomIndex, new List<ResultBean>(mCurrentBeans));
        Btn_OnCloseShowInfo();
    }


    #region 条目



    IEnumerator StartLoadItemu()                    // 加载 Item 条目
    {
        // 多项 Item 
        foreach (ResultBean bean in mCurrentBeans)
        {
            Transform t = InstantiateMoBan(moBan_Item, rt_GridContant);
            itemSelectK_ResutltV.Add(t.gameObject, bean);

            // 图标
            Transform btnIcon = t.Find("BtnIcon");
            btnIcon.GetComponent<Image>().sprite = bean.SP;
            FileInfo fileInfo = bean.File;
            btnIcon.GetComponent<Button>().onClick.AddListener(() =>
            {
                Application.OpenURL(fileInfo.FullName);
            });


            // 文件名
            t.Find("Top/FileName").GetComponent<Text>().text = bean.File.Name;
            // 大小
            t.Find("Bottom/Size").GetComponent<Text>().text = bean.Width + " x " + bean.Height;

            // 单击这一项
            GameObject chooseGOBg = t.Find("Choose").gameObject;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (null != mCuurentChooseBg)
                {
                    mCuurentChooseBg.SetActive(false);
                }

                mCuurentChooseBg = chooseGOBg;
                mCuurentChooseBg.SetActive(true);
            });
            // 删除按钮
            t.Find("Bottom/BtnDelete").GetComponent<Button>().onClick.AddListener(() =>
            {
                EachBtn_Delete(t.gameObject);
            });
            // Up 按钮
            t.Find("Bottom/BtnUp").GetComponent<Button>().onClick.AddListener(() =>
            {
                EeachBtn_Up(t.gameObject);
            });
            // Down 按钮
            t.Find("Bottom/BtnDown").GetComponent<Button>().onClick.AddListener(() =>
            {
                EachBtn_Down(t.gameObject);
            });

            yield return 0;

        }


    }



    private void EachBtn_Delete(GameObject go)                        // 点击了 Item 的 Delete
    {
        itemSelectK_ResutltV.Remove(go);
        Object.Destroy(go);
    }


    private void EeachBtn_Up(GameObject go)                           // 点击了 Item 的 Up
    {

        ChangeDicIndex(go, -1);
    }


    private void EachBtn_Down(GameObject go)                         // 点击了 Item 的 Down
    {
        ChangeDicIndex(go, 1);
    }

    private void ChangeDicIndex(GameObject go, int add)               // 改 Item 上下
    {
        List<GameObject> goList = new List<GameObject>(itemSelectK_ResutltV.Keys);
        int index = goList.IndexOf(go);    // 索引是 0 开始   GetSiblingIndex 是从 1 开始
        int want2Index = index + add;      // 要到的 索引
        if (want2Index < 0 || want2Index >= goList.Count)
        {
            return;
        }

        GameObject changeGO = goList[want2Index];
        // List 交换
        goList[index] = changeGO;
        goList[want2Index] = go;

        go.transform.SetSiblingIndex(want2Index + 1);    // 因为从 1 开始
        Dictionary<GameObject, ResultBean> tmp = new Dictionary<GameObject, ResultBean>();

        foreach (GameObject tmpGO in goList)
        {
            tmp.Add(tmpGO, itemSelectK_ResutltV[tmpGO]);
        }
        itemSelectK_ResutltV = tmp;
    }


    #endregion



    //—————————————————— 事件 ——————————————————



    private void E_Show(ResultBean[] resultBeans, EDuoTuInfoType type)      // 显示
    {
        mCurrentBeans = resultBeans;
        mCurrentType = type;

        mUIGameObject.SetActive(true);

        switch (type)
        {
            case EDuoTuInfoType.DaoRu:
                go_Delete.SetActive(false);
                go_AllDaoRu.SetActive(true);
                for (int i = 0; i < l_TittleNames.Length; i++)
                {
                    l_TittleNames[i].text = "导入 "+Ctrl_Info.Instance.LeftItemNames[i]+" 处";
                }
                break;
            case EDuoTuInfoType.InfoShow:
                go_Delete.SetActive(true);
                go_AllDaoRu.SetActive(true);
                for (int i = 0; i < l_TittleNames.Length; i++)
                {
                    l_TittleNames[i].text = "转移到 " + Ctrl_Info.Instance.LeftItemNames[i] + " 处";
                }
                break;
            case EDuoTuInfoType.SearchShow:
                go_Delete.SetActive(false);
                go_AllDaoRu.SetActive(false);
                break;
            default:
                throw new Exception("未定义");
        }


        ShowWhicContant(true);

        // 设置右边信息
        tx_Name.text = Path.GetFileNameWithoutExtension(resultBeans[0].File.FullName);
        tx_Num.text = resultBeans.Length.ToString();
        tx_Size.text = resultBeans[0].Width + "x" + resultBeans[0].Height;


        // 设置大图
        Sprite[] sps = new Sprite[resultBeans.Length];

        for (int i = 0; i < resultBeans.Length; i++)
        {
            sps[i] = resultBeans[i].SP;
        }

        yuanLaiWidth = resultBeans[0].Width;
        yuanLaiHidth = resultBeans[0].Height;
        anim_Tu.ChangeAnim(sps);
        SetTuSize(yuanLaiWidth, yuanLaiHidth);



    }



    private void E_OnChangeLeftItem()     // 切换左边总的Item时，如果开着就关了
    {

        if (mUIGameObject.activeSelf)
        {
            Btn_OnCloseShowInfo();
        }

    }




}
