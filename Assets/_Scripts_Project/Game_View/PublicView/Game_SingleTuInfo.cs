using System.IO;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public class Game_SingleTuInfo : SubUI 
{
    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EGameType, ResultBean>(E_GameEvent.ShowSingleTuInfo, E_Show);
        MyEventCenter.AddListener<EGameType, int>(E_GameEvent.ChangGameToggleType, E_ChangGameToggleType);  // 当前切换左边时关闭


        tx_InfoName = Get<Text>("Right/InfoName/Name");
        tx_HuoZhui = Get<Text>("Right/InfoHuoZhui/TxNum");
        tx_Size = Get<Text>("Right/InfoSize/TxNum");
        sp_Image = Get<Image>("Left/Contant/Tu/TuSize/Image");
        slider_Width = Get<Slider>("Left/Contant/SliderWidth/Slider");
        slider_Height = Get<Slider>("Left/Contant/SliderHeight/Slider");
        tx_WidthSize = Get<Text>("Left/Contant/SliderWidth/TxValue");
        tx_HeightSize = Get<Text>("Left/Contant/SliderHeight/TxValue");
        rtAnimTu = Get<RectTransform>("Left/Contant/Tu/TuSize");

        AddSliderOnValueChanged(slider_Width, (value) =>
        {
            SetTuSize(value);
        });
        AddSliderOnValueChanged(slider_Height, (value) =>
        {
            SetTuSize(0, value);
        });

        AddButtOnClick("Left/Contant/BtnSize/BtnPlusHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 0.5f, yuanLaiHidth * 0.5f);
        });
        AddButtOnClick("Left/Contant/BtnSize/BtnFirst", () =>
        {
            SetTuSize(yuanLaiWidth, yuanLaiHidth);
        });
        AddButtOnClick("Left/Contant/BtnSize/BtnAddHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 1.5f, yuanLaiHidth * 1.5f);
        });
        AddButtOnClick("Left/Contant/BtnSize/BtnAddTwo", () =>
        {
            SetTuSize(yuanLaiWidth * 2f, yuanLaiHidth * 2f);
        });

        AddButtOnClick("Right/BtnOpenFolder/BtnOpenFolder", Btn_OpenFolder);
        AddButtOnClick("Right/BtnOpenFolder/BtnOpenFile", Btn_OpenFile);
        AddButtOnClick("Right/BtnDlelte/Btn", Btn_OnDelete);
        AddButtOnClick("BtnClose", Btn_OnCloseInfo);
    }


    public override void OnEnable()
    {
        Get<Text>("Right/Item/ScrollRect/Contant/Item_JiHeXuLie/Text").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JiHeXuLieTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("Right/Item/ScrollRect/Contant/Item_Png/Text").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.TaoMingTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("Right/Item/ScrollRect/Contant/Item_Jpg/Text").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JpgTu_LeftStr + Ctrl_UserInfo.CHU_STR;
        Get<Text>("Right/Item/ScrollRect/Contant/Item_JiHe/Text").text = Ctrl_UserInfo.DAO_RU_STR + Ctrl_UserInfo.JiHeTu_LeftStr + Ctrl_UserInfo.CHU_STR;


    }




    #region 私有

    private EGameType mCurrentGameType;
    private FileInfo mCurrentFile;


    // 单图信息
    private Text tx_InfoName, tx_HuoZhui, tx_Size;
    private float yuanLaiWidth, yuanLaiHidth;
    private Slider slider_Width, slider_Height;
    private Text tx_WidthSize, tx_HeightSize;
    private RectTransform rtAnimTu;
    private Image sp_Image;
    private Vector2 TuSize = new Vector2(512, 512);



    public override string GetUIPathForRoot()
    {
        return "Right/SingleTuInfo";
    }


    public override void OnDisable()
    {
    }



    private void SetTuSize(float width = 0, float height = 0) // 设置图大小
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


    #endregion



    private void Btn_OnDelete()                 // 点击 不保存这个
    {
        MyEventCenter.SendEvent(E_GameEvent.OnClickNoSaveThis, mCurrentGameType);
        mUIGameObject.SetActive(false);
        mCurrentFile = null;
    }


    private void Btn_OnCloseInfo()             // 点击 关闭信息
    {
        MyEventCenter.SendEvent(E_GameEvent.CloseSingleTuInfo, mCurrentGameType);
        mUIGameObject.SetActive(false);
        mCurrentFile = null;
    }


    private void Btn_OpenFile()                // 点击 打开文件
    {
        if (null == mCurrentFile)
        {
            MyLog.Red("为空？");
            return;
        }
        Application.OpenURL(mCurrentFile.FullName);

    }


    private void Btn_OpenFolder()             // 点击 打开文件夹
    {
        if (null == mCurrentFile)
        {
            MyLog.Red("为空？");
            return;
        }
        DirectoryInfo dir = mCurrentFile.Directory;
        if (null != dir)
        {
            Application.OpenURL(dir.FullName);
        }
    }




    //—————————————————— 事件 ——————————————————



    private void E_Show(EGameType type, ResultBean resultBean)           // 显示单图信息
    {
        mCurrentGameType = type;
        mCurrentFile = resultBean.File;
        mUIGameObject.SetActive(true);
        tx_InfoName.text = resultBean.SP.name;
        sp_Image.sprite = resultBean.SP;
        tx_HuoZhui.text = resultBean.File.Extension;
        tx_Size.text = resultBean.Width + " x " + resultBean.Height;
        yuanLaiWidth = resultBean.Width;
        yuanLaiHidth = resultBean.Height;
        SetTuSize(yuanLaiWidth, yuanLaiHidth);


    }



    private void E_ChangGameToggleType(EGameType type, int index)       // 当前切换左边时，要关闭
    {
        if (mUIGameObject.activeSelf)
        {
            Btn_OnCloseInfo();
        }
    }




}
