using System;
using System.Collections;
using System.IO;
using PSPUtil;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.UI;


public enum EDuoTuInfoType
{
    DaoRu,
    InfoShow,
    SearchShow,
}


public class Sub_DuoTuInfo : SubUI
{
    protected override void OnStart(Transform root)
    {
        MyEventCenter.AddListener<ResultBean[], EDuoTuInfoType>(E_GameEvent.ShowDuoTuInfo, E_Show);    // 显示
    

        AddButtOnClick("BtnClose", Btn_OnCloseShowInfo);

        #region 大图显示
        rtAnimTu = Get<RectTransform>("Contant/Top/D2_Tu/Tu/AnimTu");
        anim_Tu = Get<UGUI_SpriteAnim>("Contant/Top/D2_Tu/Tu/AnimTu/Anim");
        tx_Name = Get<Text>("Contant/Top/D2_Tu/Right/TxName/Name");
        tx_WidthSize = Get<Text>("Contant/Top/D2_Tu/Right/SliderWidth/TxValue");
        slider_Width = Get<Slider>("Contant/Top/D2_Tu/Right/SliderWidth/Slider");
        tx_HeightSize = Get<Text>("Contant/Top/D2_Tu/Right/SliderHeight/TxValue");
        slider_Height = Get<Slider>("Contant/Top/D2_Tu/Right/SliderHeight/Slider");
        AddSliderOnValueChanged(slider_Width, (value) =>
        {
            SetTuSize(value);
        });
        AddSliderOnValueChanged(slider_Height, (value) =>
        {
            SetTuSize(0, value);
        });
        AddButtOnClick("Contant/Top/D2_Tu/Right/BtnSize/BtnPlusHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 0.5f, yuanLaiHidth * 0.5f);
        });
        AddButtOnClick("Contant/Top/D2_Tu/Right/BtnSize/BtnFirst", () =>
        {
            SetTuSize(yuanLaiWidth, yuanLaiHidth);
        });
        AddButtOnClick("Contant/Top/D2_Tu/Right/BtnSize/BtnAddHalf", () =>
        {
            SetTuSize(yuanLaiWidth * 1.5f, yuanLaiHidth * 1.5f);
        });
        AddButtOnClick("Contant/Top/D2_Tu/Right/BtnSize/BtnAddTwo", () =>
        {
            SetTuSize(yuanLaiWidth * 2f, yuanLaiHidth * 2f);
        });

        #endregion



        // 切换
        go_D2Tu = GetGameObject("Contant/Top/D2_Tu");
        go_D2Item = GetGameObject("Contant/Top/D2_Item");
        tx_ChangeText = Get<Text>("Contant/Middle/Left/BtnQieHuan/Text");
        AddButtOnClick("Contant/Middle/Left/BtnQieHuan", Btn_OnChangeBiTu);


        // 打开文件、速度、不保存
        AddButtOnClick("Contant/Middle/Left/BtnOpenFolder", Btn_OnOpenFolder);
        AddSliderOnValueChanged("Contant/Middle/Left/Speed/Slider", Sldier_OnSpeedChange);
        go_Delete = GetGameObject("Contant/Middle/Left/BtnIsDelete");
        AddButtOnClick("Contant/Middle/Left/BtnIsDelete", Btn_OnNoSaveThis);


        go_Bottom = GetGameObject("Contant/Bottom");
        // 导入


    }

    public override void OnEnable()
    {

    }


    #region 私有

    private ResultBean[] mCurrentBeans;

    // 上
    private RectTransform rtAnimTu;
    private UGUI_SpriteAnim anim_Tu;
    private Slider slider_Width, slider_Height;
    private Text tx_Name,tx_WidthSize, tx_HeightSize;
    private Vector2 TuSize = new Vector2(512, 512);
    private float yuanLaiWidth, yuanLaiHidth;



    // 切换
    private bool isShowBigTu = true;
    private GameObject go_D2Tu, go_D2Item;
    private Text tx_ChangeText;


    // 下
    private GameObject go_Delete;
    private GameObject go_Bottom;



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



    private void Btn_OnOpenFolder()                     // 点击打开文件夹
    {
        FileInfo file1 = mCurrentBeans[0].File;
        DirectoryInfo dir = file1.Directory;
        if (null!=dir)
        {
            Application.OpenURL(dir.FullName);   
        }
    }


    private void Btn_OnChangeBiTu()                     // 点击切换成大图
    {
        ShowWhicContant(!isShowBigTu);
    }



    private void Sldier_OnSpeedChange(float value)      // 拖动滑动条改变速度
    {
        anim_Tu.FPS = 0.5f / value;
    }

    private void Btn_OnNoSaveThis()                    // 点击不保存这个
    {
        MyEventCenter.SendEvent(E_GameEvent.OnClickNoSaveThisDuoTu, mCurrentType, mCurrentBeans.ToFullPaths());
        Btn_OnCloseShowInfo();
    }


    private void Btn_OnCloseShowInfo()                 // 关闭打开的信息
    {
        mUIGameObject.SetActive(false);
        mCurrentBeans = null;
        MyEventCenter.SendEvent(E_GameEvent.CloseDuoTuInfo, mCurrentType);

    }

    //—————————————————— 事件 ——————————————————
    private EDuoTuInfoType mCurrentType;

    private void E_Show(ResultBean[] resultBeans, EDuoTuInfoType type)      // 显示
    {
        mCurrentBeans = resultBeans;
        mCurrentType = type;

        mUIGameObject.SetActive(true);

        switch (type)
        {
            case EDuoTuInfoType.DaoRu:
                go_Delete.SetActive(false);
                go_Bottom.SetActive(true);
                break;
            case EDuoTuInfoType.InfoShow:
                go_Delete.SetActive(true);
                go_Bottom.SetActive(true);
                break;
            case EDuoTuInfoType.SearchShow:
                go_Delete.SetActive(false);
                go_Bottom.SetActive(false);
                break;
            default:
                throw new Exception("未定义");
        }


        ShowWhicContant(true);
        Ctrl_Coroutine.Instance.StartCoroutine(StartLoadDuoTu(resultBeans));

    }

    IEnumerator StartLoadDuoTu(ResultBean[] resultBeans)                    // 显示调用的
    {

        // 设置大图
        Sprite[] sps = new Sprite[resultBeans.Length];

        for (int i = 0; i < resultBeans.Length; i++)
        {
            sps[i] = resultBeans[i].SP;
        }
        tx_Name.text = Path.GetFileNameWithoutExtension(resultBeans[0].File.FullName);
        yuanLaiWidth = resultBeans[0].Width;
        yuanLaiHidth = resultBeans[0].Height;
        anim_Tu.ChangeAnim(sps);
        SetTuSize(yuanLaiWidth, yuanLaiHidth);


        yield return 0;

//        // 多项 Item 
//        foreach (ResultBean bean in resultBeans)
//        {
//            Transform t = InstantiateMoBan(moBan_Item, rt_GridContant);
//            itemSelectK_ResutltV.Add(t.gameObject, bean);
//
//            // 图标
//            Transform btnIcon = t.Find("BtnIcon");
//            btnIcon.GetComponent<Image>().sprite = bean.SP;
//            FileInfo fileInfo = bean.File;
//            btnIcon.GetComponent<Button>().onClick.AddListener(() =>
//            {
//                Application.OpenURL(fileInfo.FullName);
//            });
//
//
//            // 文件名
//            t.Find("FileName").GetComponent<Text>().text = bean.File.Name;
//            // 大小
//            t.Find("Size").GetComponent<Text>().text = bean.Width + " x " + bean.Height;
//
//            // 单击这一项
//            GameObject chooseGOBg = t.Find("Choose/Bg").gameObject;
//            t.GetComponent<Button>().onClick.AddListener(() =>
//            {
//                if (null != mCuurentChooseBg)
//                {
//                    mCuurentChooseBg.SetActive(false);
//                }
//
//                mCuurentChooseBg = chooseGOBg;
//                mCuurentChooseBg.SetActive(true);
//            });
//            // 删除按钮
//            t.Find("Choose/BtnContrl/BtnDelete").GetComponent<Button>().onClick.AddListener(() =>
//            {
//                EachBtn_Delete(t.gameObject);
//            });
//            // Up 按钮
//            t.Find("Choose/BtnContrl/BtnUp").GetComponent<Button>().onClick.AddListener(() =>
//            {
//                EeachBtn_Up(t.gameObject);
//            });
//            // Down 按钮
//            t.Find("Choose/BtnContrl/BtnDown").GetComponent<Button>().onClick.AddListener(() =>
//            {
//                EachBtn_Down(t.gameObject);
//            });
//
//            yield return 0;

//        }


    }




}
