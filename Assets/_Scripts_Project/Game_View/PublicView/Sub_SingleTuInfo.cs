using System.IO;
using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class Sub_SingleTuInfo : SubUI
{

    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<ResultBean>(E_GameEvent.ShowSingleTuInfo, E_Show);
        MyEventCenter.AddListener(E_GameEvent.ItemChange, E_OnChangeLeftItem);                       // 左边改动


        tx_Name = Get<Text>("Right/InfoName/Name");
        tx_HuoZhui = Get<Text>("Right/InfoHuoZhui/TxHuoZhui");
        tx_YuanSize = Get<Text>("Right/InfoSize/TxNum");


        AddButtOnClick("Right/BtnOpenFolder/BtnOpenFolder",Btn_OpenFolder);
        AddButtOnClick("Right/BtnOpenFolder/BtnOpenFile",Btn_OpenFile);
        AddButtOnClick("Right/BtnBiaoJi/Btn", Btn_BiaoJiThisTu);

        sp_Tu = Get<Image>("Left/Tu/TuSize/Image");
        rt_TuSize = Get<RectTransform>("Left/Tu/TuSize");

        tx_WidthSize = Get<Text>("Right/SliderWidth/TxValue");
        slider_Width = Get<Slider>("Right/SliderWidth/Slider");
        tx_HeightSize = Get<Text>("Right/SliderHeight/TxValue");
        slider_Height = Get<Slider>("Right/SliderHeight/Slider");
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
        AddButtOnClick("Right/BtnSize/BtnPlusHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 0.5f, yuanLaiHidth * 0.5f);
        });
        AddButtOnClick("Right/BtnSize/BtnFirst", () =>
        {
            SetTuSize(yuanLaiWidth, yuanLaiHidth);
        });
        AddButtOnClick("Right/BtnSize/BtnAddHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 1.5f, yuanLaiHidth * 1.5f);
        });
        AddButtOnClick("Right/BtnSize/BtnAddTwo", () =>
        {
            SetTuSize(yuanLaiWidth * 2f, yuanLaiHidth * 2f);
        });

        AddButtOnClick("BtnClose", Btn_OnCloseShowInfo);

    }


    #region 私有

    private ResultBean mCurrentResultBean;

    private Text tx_Name, tx_HuoZhui,tx_YuanSize;

    private const ushort Max_TuSize = 512;   // 限制图片最大的大小
    private Image sp_Tu;
    private RectTransform rt_TuSize;
    private Slider slider_Width, slider_Height;
    private Text tx_WidthSize, tx_HeightSize;
    private Vector2 TuSize = new Vector2(512, 512);
    private float yuanLaiWidth, yuanLaiHidth;




    public override string GetUIPathForRoot()
    {
        return "Right/SingleTuInfo";
    }


    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
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
        rt_TuSize.sizeDelta = TuSize;
    }

    #endregion



    private void Btn_OpenFolder()                     // 点击 打开文件夹
    {
        DirectoryInfo dir = mCurrentResultBean.File.Directory;
        if (null!=dir)
        {
            Application.OpenURL(dir.FullName);
        }
    }


    private void Btn_OpenFile()                      // 点击 打开文件
    {
        Application.OpenURL(mCurrentResultBean.File.FullName);
    }

    private void Btn_BiaoJiThisTu()                   // 点击 标记该图片
    {
        Btn_OnCloseShowInfo();
    }



    private void Btn_OnCloseShowInfo()                 // 关闭打开的信息
    {
        mUIGameObject.SetActive(false);
    }


    //—————————————————— 事件 ——————————————————


    private void E_Show(ResultBean resultBeans)      // 显示
    {
        mCurrentResultBean = resultBeans;

        mUIGameObject.SetActive(true);
        tx_Name.text = Path.GetFileNameWithoutExtension(resultBeans.File.FullName);
        tx_HuoZhui.text = resultBeans.File.Extension;

        sp_Tu.sprite = resultBeans.SP;
        yuanLaiWidth = resultBeans.Width;
        yuanLaiHidth = resultBeans.Height;
        tx_YuanSize.text = yuanLaiWidth + " x " + yuanLaiHidth;

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
