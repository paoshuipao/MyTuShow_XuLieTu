/*
using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class Game_GaiMing : SubUI 
{







    #region 私有

    private EGameType mCurrentType;
    private Text tx_YuanName,tx_GaiName;
    private GameObject go_ErrorTip;
    private InputField input_Name;


    public override string GetUIPathForRoot()
    {
        return "Right/GaiNing";
    }


    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }

    #endregion


    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EGameType,string>(E_GameEvent.ShowGeiMingUI, E_OnShow);

        tx_YuanName = Get<Text>("Contant/Grid/Middle/TxYuan");
        tx_GaiName = Get<Text>("Contant/Grid/Middle/TxGaiName");
        go_ErrorTip = GetGameObject("Contant/Grid/Top/ErrorTip");
        input_Name = Get<InputField>("Contant/Grid/Top/InputField");



        AddInputOnValueChanged(input_Name, Input_ValueChange);
        AddButtOnClick("Contant/Grid/Middle/Arrow", Btn_OnClickArrow);
        AddButtOnClick("Contant/Grid/Bottom/BtnSure",Btn_OnSure);
        AddButtOnClick("Contant/Grid/Bottom/BtnFalse", Btn_OnFalse);


    }


    private void Input_ValueChange(string value)         // 输入发生改变
    {
        if (go_ErrorTip.activeSelf)
        {
            go_ErrorTip.SetActive(false);
        }
        tx_GaiName.text = value;
    }


    private void Btn_OnClickArrow()                     // 点击箭头
    {
        tx_GaiName.text = tx_YuanName.text;
        input_Name.text = tx_YuanName.text;
    }



    private void Btn_OnSure()                           // 点击确定
    {
        if (string.IsNullOrEmpty(input_Name.text))
        {
            go_ErrorTip.SetActive(true);

        }
        else
        {
            mUIGameObject.SetActive(false);
            MyEventCenter.SendEvent(E_GameEvent.SureGeiMing, mCurrentType, input_Name.text);
        }
    }


    private void Btn_OnFalse()                          // 点击取消
    {
        mUIGameObject.SetActive(false);
    }


    //—————————————————— 事件——————————————————

    private void E_OnShow(EGameType type,string yuanName)        // 显示
    {
        mCurrentType = type;
        tx_GaiName.text = "";
        input_Name.text = "";
        if (go_ErrorTip.activeSelf)
        {
            go_ErrorTip.SetActive(false);
        }
        tx_YuanName.text = yuanName;
        mUIGameObject.SetActive(true);
    }





}
*/
