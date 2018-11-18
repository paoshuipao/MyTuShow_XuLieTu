using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using DG.Tweening;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Log : BaseUI_Mono,IPointerClickHandler
{


    protected override void OnStart()
    {
        Application.logMessageReceived += HandleLog;


        // 控制开关（关了也显示的）
        toggle_IsOn = Get<Toggle>("Contrl/Toggle_IsOn");
        AddToggleOnValueChanged(toggle_IsOn, Toggle_IsOn);
        go_Log = GetGameObject("Log");
        tx_LogNum = Get<Text>("Contrl/Right/Log/Text");
        tx_WarningNum = Get<Text>("Contrl/Right/Warning/Text");
        tx_ErrorNum = Get<Text>("Contrl/Right/Error/Text");


        // 上方
        AddButtOnClick("Log/BtnClear", Btn_OnClear);

        // 中间、模版
        t_Group = GetTransform("Log/ScrollView/LogContant") as RectTransform;
        moBan_Log = GetGameObject("Log/ScrollView/LogContant/LogItem");
        moBan_Warning = GetGameObject("Log/ScrollView/LogContant/WarningItem");
        moBan_Error = GetGameObject("Log/ScrollView/LogContant/ErrorItem");


        // 底下
        tx_Stack = Get<Text>("Log/StackShow/Contant/BtnText");
        go_StackContrl = GetGameObject("Log/StackShow/RightContrl");
        AddButtOnClick("Log/StackShow/RightContrl/BtnCopy", Btn_OnCopy);
        AddButtOnClick("Log/StackShow/RightContrl/BtnEasy",Btn_OnEasy);

    }

    protected override void OnShow()
    {
        Btn_OnClear();

    }

    protected override void OnHideAnim()
    {


    }


    #region 私有

    private Toggle toggle_IsOn;
    private GameObject go_Log,moBan_Log,moBan_Warning,moBan_Error;
    private RectTransform t_Group;
    private Text tx_LogNum,tx_WarningNum,tx_ErrorNum,tx_Stack;
    private Button btn_CurrentBtnClose;
    private EItemTtype mCurrentItem;
    private GameObject go_StackContrl;

    private int logNum,warningNum,errorNum;


    private const string ZERO = "0";
    private readonly Dictionary<string, EItemTtype> logK_ItemTypeV = new Dictionary<string, EItemTtype>();

    public class EItemTtype
    {
        public LogType Type;
        public int Num;     // 总共有几个
        public GameObject GoItem;
        public Text Tx_Num;
        public Text Tx_Str;
        public string LogStr;
        public string StackStr;


        public EItemTtype()
        {
            Num = 1;
        }
    }




    protected override void OnAddListener()
    {
    }

    protected override void OnRemoveListener()
    {
    }

    protected override E_GameEvent GetShowEvent()
    {
        return E_GameEvent.ShowLog;
    }

    protected override E_GameEvent GetHideEvent()
    {
        return E_GameEvent.HideLog;
    }



    private void ClosePreClickItem()
    {
        if (null != btn_CurrentBtnClose)
        {
            btn_CurrentBtnClose.onClick.RemoveListener(Btn_OnItemClose);
            btn_CurrentBtnClose.gameObject.SetActive(false);
            go_StackContrl.SetActive(false);
            tx_Stack.text = "";

        }
    }


    private void GengXinNum(LogType type, int num)      // 更新右上角的数字
    {

        switch (type)
        {
            case LogType.Error:
                errorNum += num;
                tx_ErrorNum.text = errorNum.ToString();
                break;
            case LogType.Warning:
                warningNum += num;
                tx_WarningNum.text = warningNum.ToString();
                break;
            case LogType.Log:
                logNum += num;
                tx_LogNum.text = logNum.ToString();
                break;
            default:
                throw new Exception("未实现");
        }

    }

    #endregion


    protected override void OnUpdate()
    {
        base.OnUpdate();
        if ((Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Y)) || (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Y)))
        {
            Btn_OnClear();
        }


        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
        {
            toggle_IsOn.isOn = !toggle_IsOn.isOn;
        }

    }


    private void HandleLog(string logString, string stackTrace, LogType type)        // 核心接收到 Log 事件
    {
        if (type == LogType.Exception || type == LogType.Assert)
        {
            return;
        }

        GengXinNum(type,1);

        if (logK_ItemTypeV.ContainsKey(logString))
        {
            EItemTtype tmpItem = logK_ItemTypeV[logString];
            tmpItem.Num++;
            tmpItem.Tx_Num.text = tmpItem.Num.ToString();
        }
        else
        {
            EItemTtype item = new EItemTtype();
            GameObject go ;
            switch (type)
            {
                case LogType.Error:
                    go = InstantiateMoBan(moBan_Error, t_Group);
                    break;
                case LogType.Warning:
                    go = InstantiateMoBan(moBan_Warning, t_Group);
                    break;
                case LogType.Log:
                    go = InstantiateMoBan(moBan_Log, t_Group);
                    break;
                default:
                    throw new Exception("未实现");
            }
            item.Type = type;
            item.GoItem = go;
            item.LogStr = logString;
            item.StackStr = stackTrace;
            item.Tx_Num = go.transform.Find("Num/Text").GetComponent<Text>();
            item.Tx_Str = go.transform.Find("Contant/Text").GetComponent<Text>();
            item.Tx_Str.text = logString.TrimEnd("\n".ToCharArray());
            Button btnClose = go.transform.Find("BtnClose").GetComponent<Button>();
            btnClose.gameObject.SetActive(false);
            go.GetComponent<Button>().onClick.AddListener(() =>
            {
                mCurrentItem = item;
                Btn_OnItemClick(btnClose);
            });
            logK_ItemTypeV.Add(logString,item);
            LayoutRebuilder.ForceRebuildLayoutImmediate(t_Group);

        }

    }

    private void Btn_OnItemClick(Button btnClose)                     // 点击每一个 Item
    {
        ClosePreClickItem();    // 关闭之前点击 Item 的操作
        btn_CurrentBtnClose = btnClose;
        btn_CurrentBtnClose.onClick.AddListener(Btn_OnItemClose);
        tx_Stack.text = mCurrentItem.StackStr;
        go_StackContrl.SetActive(true);
        btn_CurrentBtnClose.gameObject.SetActive(true);
    }


    private void Btn_OnItemClose()                                   // 单独删除一个
    {
        int num = mCurrentItem.Num;
        GengXinNum(mCurrentItem.Type, -num);

        logK_ItemTypeV.Remove(mCurrentItem.LogStr);
        btn_CurrentBtnClose = null;
        Destroy(mCurrentItem.GoItem);

    }

    public void OnPointerClick(PointerEventData eventData)           // 任何点击事件都会触发这里
    {
        ClosePreClickItem();    // 关闭之前点击 Item 的操作
    }


    //————————————————————————————————————




    private void Toggle_IsOn(bool isOn)                  // 是否显示整个 Log
    {
        go_Log.SetActive(isOn);
    }


    private void Btn_OnClear()                           // 清除
    {
        logNum = 0;
        warningNum = 0;
        errorNum = 0;
        tx_LogNum.text = ZERO;
        tx_WarningNum.text = ZERO;
        tx_ErrorNum.text = ZERO;
        tx_Stack.text = "";

        foreach (EItemTtype item in logK_ItemTypeV.Values)
        {
            Destroy(item.GoItem);
        }

        logK_ItemTypeV.Clear(); 

    }

    private readonly string RexgexStr = @"/\S*cs:[0-9]+";
    private void Btn_OnEasy()                          // 点击简化
    {
        string str = tx_Stack.text;
        Regex regex = new Regex(RexgexStr);
        MatchCollection ms = regex.Matches(str);
        StringBuilder sb = new StringBuilder();
        foreach (Match match in ms)
        {
            sb.AppendLine(match.Value);
        }
        tx_Stack.text = sb.ToString();


    }



    private void Btn_OnCopy()                          // 点击复制
    {
        GUIUtility.systemCopyBuffer = tx_Stack.text;
    }





}
