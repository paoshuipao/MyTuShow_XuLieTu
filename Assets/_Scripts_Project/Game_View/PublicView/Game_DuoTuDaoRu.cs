using System.Collections;
using System.Collections.Generic;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Game_DuoTuDaoRu : SubUI 
{
    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<ResultBean[],string>(E_GameEvent.ShowDuoTuDaoRu, E_Show);
        MyEventCenter.AddListener<EGameType, string>(E_GameEvent.SureGeiMing, E_OnSureGaiMing);

        // 上方
        dt2_TopContant = Get<DTToggle2_Fade>("Top/ScrollView");
        mScrollRect = Get<ScrollRect>("Top/ScrollView");
        rt_GridContant = Get<RectTransform>("Top/ScrollView/Contant");
        rt_TuContant = Get<RectTransform>("Top/ScrollView/TuContant");
        moBan_Item = GetGameObject("Top/ScrollView/MoBan");

        // 切换成大图显示
        rtAnimTu = Get<RectTransform>("Top/ScrollView/TuContant/Tu/AnimTu");
        anim_Tu = Get<UGUI_SpriteAnim>("Top/ScrollView/TuContant/Tu/AnimTu/Anim");
        slider_Width = Get<Slider>("Top/ScrollView/TuContant/Right/SliderWidth/Slider");
        slider_Height = Get<Slider>("Top/ScrollView/TuContant/Right/SliderHeight/Slider");
        tx_WidthSize = Get<Text>("Top/ScrollView/TuContant/Right/SliderWidth/TxValue");
        tx_HeightSize = Get<Text>("Top/ScrollView/TuContant/Right/SliderHeight/TxValue");
        AddSliderOnValueChanged(slider_Width, (value) =>
        {
            SetTuSize(value);
        });
        AddSliderOnValueChanged(slider_Height, (value) =>
        {
            SetTuSize(0, value);
        });
        AddButtOnClick("Top/ScrollView/TuContant/Right/BtnSize/BtnFirst", () =>
        {
            SetTuSize(yuanLaiWidth, yuanLaiHidth);
        });
        AddButtOnClick("Top/ScrollView/TuContant/Right/BtnSize/BtnPlusHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 0.5f, yuanLaiHidth * 0.5f);
        });
        AddButtOnClick("Top/ScrollView/TuContant/Right/BtnSize/BtnAddHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 1.5f, yuanLaiHidth * 1.5f);
        });
        AddButtOnClick("Top/ScrollView/TuContant/Right/BtnSize/BtnAddTwo", () =>
        {
            SetTuSize(yuanLaiWidth * 2f, yuanLaiHidth * 2f);
        });



        // 中间
        tx_ChangeText = Get<Text>("Middle/Left/BtnQieHuan/Text");
        AddButtOnClick("Middle/Left/BtnOpenFolder", Btn_OnOpenFolder);
        AddButtOnClick("Middle/Left/BtnQieHuan", Btn_OnChangeBiTu);
        AddSliderOnValueChanged("Middle/Left/Speed/Slider", Sldier_OnSpeedChange);




        #region 下方

        Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item1/Btn/ItemDaoRu").text = Ctrl_UserInfo.BottomXuLieTuName[0];
        Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item2/Btn/ItemDaoRu").text = Ctrl_UserInfo.BottomXuLieTuName[1];
        Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item3/Btn/ItemDaoRu").text = Ctrl_UserInfo.BottomXuLieTuName[2];
        tx_DuoXLT222_1 = Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn1/BtnMDR/ItemDaoRu");
        tx_DuoXLT222_2 = Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn2/BtnMDR/ItemDaoRu");
        tx_DuoXLT222_3 = Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn3/BtnMDR/ItemDaoRu");
        tx_DuoXLT222_4 = Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn4/BtnMDR/ItemDaoRu");
        tx_DuoXLT222_5 = Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn5/BtnMDR/ItemDaoRu");
        tx_DuoJHXuLie1 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn1/BtnMDR/ItemDaoRu");
        tx_DuoJHXuLie2 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn2/BtnMDR/ItemDaoRu");
        tx_DuoJHXuLie3 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn3/BtnMDR/ItemDaoRu");
        tx_DuoJHXuLie4 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn4/BtnMDR/ItemDaoRu");
        tx_DuoJHXuLie5 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn5/BtnMDR/ItemDaoRu");
        tx_DuoTaoMing1 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn1/BtnMDR/ItemDaoRu");
        tx_DuoTaoMing2 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn2/BtnMDR/ItemDaoRu");
        tx_DuoTaoMing3 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn3/BtnMDR/ItemDaoRu");
        tx_DuoTaoMing4 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn4/BtnMDR/ItemDaoRu");
        tx_DuoTaoMing5 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn5/BtnMDR/ItemDaoRu");
        tx_DuoJpg1 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn1/BtnMDR/ItemDaoRu");
        tx_DuoJpg2 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn2/BtnMDR/ItemDaoRu");
        tx_DuoJpg3 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn3/BtnMDR/ItemDaoRu");
        tx_DuoJpg4 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn4/BtnMDR/ItemDaoRu");
        tx_DuoJpg5 = Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn5/BtnMDR/ItemDaoRu");
        tx_DuoJiHe1 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn1/BtnMDR/ItemDaoRu");
        tx_DuoJiHe2 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn2/BtnMDR/ItemDaoRu");
        tx_DuoJiHe3 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn3/BtnMDR/ItemDaoRu");
        tx_DuoJiHe4 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn4/BtnMDR/ItemDaoRu");
        tx_DuoJiHe5 = Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn5/BtnMDR/ItemDaoRu");



        AddButtOnClick("BtnClose", Btn_OnCloseThis);
        // 序列图
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item1/Btn", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu,(ushort)EXuLieTu.G1Zheng);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item2/Btn", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu,(ushort)EXuLieTu.G2Zheng_XiTong);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item3/Btn", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu, (ushort)EXuLieTu.G3Zheng_Big);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item4/BtnHeng", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu, (ushort)EXuLieTu.G4Two_Heng);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item4/BtnShu", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu, (ushort)EXuLieTu.G4Two_Shu);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item5/BtnHeng", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu, (ushort)EXuLieTu.G5Three_Heng);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu/Contant/Item5/BtnShu", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu, (ushort)EXuLieTu.G5Three_Shu);
        });

        // 序列图222
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn1/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu222, (ushort)EXuLieTu222.XLT222_1);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn2/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu222, (ushort)EXuLieTu222.XLT222_2);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn3/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu222, (ushort)EXuLieTu222.XLT222_3);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn4/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu222, (ushort)EXuLieTu222.XLT222_4);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_XunLieTu222/Contant/Btn5/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.XuLieTu222, (ushort)EXuLieTu222.XLT222_5);
        });




        // 集合序列图
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn1/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeXuLieTu,(ushort)EJiHeXuLieTuType.JiHeXLT1);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn2/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeXuLieTu, (ushort)EJiHeXuLieTuType.JiHeXLT2);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn3/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeXuLieTu, (ushort)EJiHeXuLieTuType.JiHeXLT3);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn4/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeXuLieTu, (ushort)EJiHeXuLieTuType.JiHeXLT4);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/Contant/Btn5/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeXuLieTu, (ushort)EJiHeXuLieTuType.JiHeXLT4);
        });

        // 透明图
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn1/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.TaoMingTu,(ushort)ETaoMingType.XiTong);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn2/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.TaoMingTu, (ushort)ETaoMingType.WenZi);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn3/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.TaoMingTu, (ushort)ETaoMingType.WuQi);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn4/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.TaoMingTu, (ushort)ETaoMingType.DaoJu);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Png/Contant/Btn5/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.TaoMingTu, (ushort)ETaoMingType.ChengJi);
        });

        // Jpg
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn1/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.NormalTu, (ushort)ENormalTuType.Jpg1);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn2/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.NormalTu, (ushort)ENormalTuType.Jpg2);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn3/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.NormalTu, (ushort)ENormalTuType.Jpg3);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn4/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.NormalTu, (ushort)ENormalTuType.Jpg4);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_Jpg/Contant/Btn5/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.NormalTu, (ushort)ENormalTuType.Jpg5);
        });




        // 集合图
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn1/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeTu, (ushort)EJiHeType.JiHe1);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn2/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeTu, (ushort)EJiHeType.JiHe2);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn3/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeTu, (ushort)EJiHeType.JiHe3);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn4/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeTu, (ushort)EJiHeType.JiHe4);
        });
        AddButtOnClick("BottomContrl/ScrollView/Contant/Item_JiHe/Contant/Btn5/BtnMDR", () =>
        {
            ManyBtn_DaoRu(EGameType.JiHeTu, (ushort)EJiHeType.JiHe5);
        });


        #endregion



    }

    public override void OnEnable()
    {

        Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.XuLieTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("BottomContrl/ScrollView/Contant/Item_XunLieTu222/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.XuLieTu222_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHeXuLie/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JiHeXuLieTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("BottomContrl/ScrollView/Contant/Item_Png/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.TaoMingTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("BottomContrl/ScrollView/Contant/Item_Jpg/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JpgTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("BottomContrl/ScrollView/Contant/Item_JiHe/TxTittle").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JiHeTu_LeftStr + Ctrl_UserInfo.CHU_STR;



        tx_DuoXLT222_1.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[0];
        tx_DuoXLT222_2.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[1];
        tx_DuoXLT222_3.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[2];
        tx_DuoXLT222_4.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[3];
        tx_DuoXLT222_5.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[4];

        tx_DuoJHXuLie1.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[0];
        tx_DuoJHXuLie2.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[1];
        tx_DuoJHXuLie3.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[2];
        tx_DuoJHXuLie4.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[3];
        tx_DuoJHXuLie5.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[4];

        tx_DuoTaoMing1.text = Ctrl_UserInfo.Instance.BottomTaoMingName[0];
        tx_DuoTaoMing2.text = Ctrl_UserInfo.Instance.BottomTaoMingName[1];
        tx_DuoTaoMing3.text = Ctrl_UserInfo.Instance.BottomTaoMingName[2];
        tx_DuoTaoMing4.text = Ctrl_UserInfo.Instance.BottomTaoMingName[3];
        tx_DuoTaoMing5.text = Ctrl_UserInfo.Instance.BottomTaoMingName[4];

        tx_DuoJpg1.text = Ctrl_UserInfo.Instance.BottomJpgName[0];
        tx_DuoJpg2.text = Ctrl_UserInfo.Instance.BottomJpgName[1];
        tx_DuoJpg3.text = Ctrl_UserInfo.Instance.BottomJpgName[2];
        tx_DuoJpg4.text = Ctrl_UserInfo.Instance.BottomJpgName[3];
        tx_DuoJpg5.text = Ctrl_UserInfo.Instance.BottomJpgName[4];

        tx_DuoJiHe1.text = Ctrl_UserInfo.Instance.BottomJiHeName[0];
        tx_DuoJiHe2.text = Ctrl_UserInfo.Instance.BottomJiHeName[1];
        tx_DuoJiHe3.text = Ctrl_UserInfo.Instance.BottomJiHeName[2];
        tx_DuoJiHe4.text = Ctrl_UserInfo.Instance.BottomJiHeName[3];
        tx_DuoJiHe5.text = Ctrl_UserInfo.Instance.BottomJiHeName[4];
    }



    #region 私有


    private Dictionary<GameObject, ResultBean> itemSelectK_ResutltV = new Dictionary<GameObject, ResultBean>();     // item每行的作为 Key 结果为Value


    private GameObject mCuurentChooseBg;
    private GameObject moBan_Item;
    private RectTransform rt_GridContant, rt_TuContant;
    private string mCurrentFolderPath;


    // 上
    private DTToggle2_Fade dt2_TopContant;
    private ScrollRect mScrollRect;

    private RectTransform rtAnimTu;
    private UGUI_SpriteAnim anim_Tu;
    private Slider slider_Width, slider_Height;
    private Text tx_WidthSize, tx_HeightSize;
    private Vector2 TuSize = new Vector2(512, 512);
    private float yuanLaiWidth, yuanLaiHidth;



    // 中
    private bool isShowBigTu = true;
    private Text tx_ChangeText;


    // 导入 Text
    private Text tx_DuoXLT222_1, tx_DuoXLT222_2, tx_DuoXLT222_3, tx_DuoXLT222_4, tx_DuoXLT222_5;
    private Text tx_DuoJHXuLie1, tx_DuoJHXuLie2, tx_DuoJHXuLie3, tx_DuoJHXuLie4, tx_DuoJHXuLie5;
    private Text tx_DuoTaoMing1, tx_DuoTaoMing2, tx_DuoTaoMing3, tx_DuoTaoMing4, tx_DuoTaoMing5;
    private Text tx_DuoJpg1, tx_DuoJpg2, tx_DuoJpg3, tx_DuoJpg4, tx_DuoJpg5;
    private Text tx_DuoJiHe1, tx_DuoJiHe2, tx_DuoJiHe3, tx_DuoJiHe4, tx_DuoJiHe5;


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


    public override string GetUIPathForRoot()
    {
        return "Right/DuoTuDaoRu";
    }



    public override void OnDisable()
    {
    }



    #endregion


    private void SetTuSize(float width = 0, float height = 0)         // 设置图大小
    {
        if (width > 0)
        {
            if (width < 8)
            {
                width = 8;
            }
            if (width > 512)
            {
                width = 512;
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
            if (height > 512)
            {
                height = 512;
            }
            TuSize.y = height;
            slider_Height.value = height;
            tx_HeightSize.text = height.ToString();
        }
        rtAnimTu.sizeDelta = TuSize;
    }



    private void Btn_OnOpenFolder()                                  // 打开文件夹
    {
        Application.OpenURL(mCurrentFolderPath);
    }


    private void Btn_OnChangeBiTu()                                  // 点击切换成大图
    {
        ShowWhicContant(!isShowBigTu);

    }


    private void ShowWhicContant(bool showBigTu)      // 显示那个 内容
    {
        if (showBigTu)        // 显示大图
        {
            isShowBigTu = true;
            dt2_TopContant.Change2One();
            mScrollRect.content = rt_TuContant;
            tx_ChangeText.text = "切换到栏目";
        }
        else
        {
            isShowBigTu = false;
            dt2_TopContant.Change2Two();
            mScrollRect.content = rt_GridContant;
            tx_ChangeText.text = "还原到大图";
        }
    }



    private void Sldier_OnSpeedChange(float value)                  // 拖动滑动条改变速度
    {
        anim_Tu.FPS = 0.5f /value;
    }



    //—————————————————— 每个 Item ——————————————————


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


    private void ManyBtn_DaoRu(EGameType type, ushort index)         // 点击导入
    {
        List<ResultBean> resultBeans = new List<ResultBean>(itemSelectK_ResutltV.Values);
        MyEventCenter.SendEvent(E_GameEvent.DaoRuTuFromResult, type, index, resultBeans,true);
        Btn_OnCloseThis();
    }






    //—————————————————— 事件 ——————————————————

    private void E_Show(ResultBean[] resultBeans,string folderPath)                     // 显示
    {
        mCurrentFolderPath = folderPath;
        mUIGameObject.SetActive(true);
        ShowWhicContant(true);
        Ctrl_Coroutine.Instance.StartCoroutine(StartLoadDuoTu(resultBeans));

    }


    private void Btn_OnCloseThis()                                                    // 点击关闭
    {
        mUIGameObject.SetActive(false);
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




    IEnumerator StartLoadDuoTu(ResultBean[] resultBeans)                                // 大图 和 多张图的每个 Item
    {

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


        yield return 0;

        // 多项 Item 
        foreach (ResultBean bean in resultBeans)
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
            t.Find("FileName").GetComponent<Text>().text = bean.File.Name;
            // 大小
            t.Find("Size").GetComponent<Text>().text = bean.Width + " x " + bean.Height;

            // 单击这一项
            GameObject chooseGOBg = t.Find("Choose/Bg").gameObject;
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
            t.Find("Choose/BtnContrl/BtnDelete").GetComponent<Button>().onClick.AddListener(() =>
            {
                EachBtn_Delete(t.gameObject);
            });
            // Up 按钮
            t.Find("Choose/BtnContrl/BtnUp").GetComponent<Button>().onClick.AddListener(() =>
            {
                EeachBtn_Up(t.gameObject);
            });
            // Down 按钮
            t.Find("Choose/BtnContrl/BtnDown").GetComponent<Button>().onClick.AddListener(() =>
            {
                EachBtn_Down(t.gameObject);
            });

            yield return 0;

        }


    }




    private void E_OnSureGaiMing(EGameType type, string changeNamne)                   // 确定改名
    {
        switch (type)
        {
            case EGameType.XuLieTu222:
                tx_DuoXLT222_1.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[0];
                tx_DuoXLT222_2.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[1];
                tx_DuoXLT222_3.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[2];
                tx_DuoXLT222_4.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[3];
                tx_DuoXLT222_5.text = Ctrl_UserInfo.Instance.BottomXuLeTu222Name[4];
                break;
            case EGameType.JiHeXuLieTu:

                tx_DuoJHXuLie1.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[0];
                tx_DuoJHXuLie2.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[1];
                tx_DuoJHXuLie3.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[2];
                tx_DuoJHXuLie4.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[3];
                tx_DuoJHXuLie5.text = Ctrl_UserInfo.Instance.BottomJiHeXLTName[4];
                break;
            case EGameType.TaoMingTu:

                tx_DuoTaoMing1.text = Ctrl_UserInfo.Instance.BottomTaoMingName[0];
                tx_DuoTaoMing2.text = Ctrl_UserInfo.Instance.BottomTaoMingName[1];
                tx_DuoTaoMing3.text = Ctrl_UserInfo.Instance.BottomTaoMingName[2];
                tx_DuoTaoMing4.text = Ctrl_UserInfo.Instance.BottomTaoMingName[3];
                tx_DuoTaoMing5.text = Ctrl_UserInfo.Instance.BottomTaoMingName[4];
                break;
            case EGameType.NormalTu:
                tx_DuoJpg1.text = Ctrl_UserInfo.Instance.BottomJpgName[0];
                tx_DuoJpg2.text = Ctrl_UserInfo.Instance.BottomJpgName[1];
                tx_DuoJpg3.text = Ctrl_UserInfo.Instance.BottomJpgName[2];
                tx_DuoJpg4.text = Ctrl_UserInfo.Instance.BottomJpgName[3];
                tx_DuoJpg5.text = Ctrl_UserInfo.Instance.BottomJpgName[4];
                break;
            case EGameType.JiHeTu:
                tx_DuoJiHe1.text = Ctrl_UserInfo.Instance.BottomJiHeName[0];
                tx_DuoJiHe2.text = Ctrl_UserInfo.Instance.BottomJiHeName[1];
                tx_DuoJiHe3.text = Ctrl_UserInfo.Instance.BottomJiHeName[2];
                tx_DuoJiHe4.text = Ctrl_UserInfo.Instance.BottomJiHeName[3];
                tx_DuoJiHe5.text = Ctrl_UserInfo.Instance.BottomJiHeName[4];
                break;
        }
    } 

}
