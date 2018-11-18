using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum TextExpandType
{
    AddUnderLine,                                                //加下划线
    AddDeleteLine                                                //加删除线
}

[DisallowMultipleComponent]
[RequireComponent(typeof(Text))]
[AddComponentMenu("我的组件/UI/UGUI_Text(文字扩展)", 12)]
public class UGUI_Text : MonoBehaviour, IPointerDownHandler           
{
    [MyHead("加下划线还是加删除线")]
    public TextExpandType ExpendType;                        //加下划线还是加删除线

    [MyHead("是否使用其他颜色")]
    public bool isUseOtherColor = false;                     //是否使用其它颜色

    [EnableIf("isUseOtherColor")]
    public Color LineColor = Color.green;                    //使用其它颜色


    [MyHead("是否点击会打开网页")]
    public bool IsClick2OpenWeb = false;                     //下划线点击是否打开网页


    [EnableIf("IsClick2OpenWeb")]
    public string WebUrl = "";                               //网址

    void Start()
    {
        Text proText = GetComponent<Text>();
        if (null == proText)
        {
            MyLog.Red("把这个脚本方在Text下");
            return;
        }
        Text copyText = CreateExpandText(proText);           //创建一个新的Text（Tx_Expand）
        string addStr = "";
        switch (ExpendType)
        {
            case TextExpandType.AddUnderLine:
                copyText.color = isUseOtherColor ? LineColor : proText.color;
                addStr = "_";
                break;
            case TextExpandType.AddDeleteLine:
                copyText.color = isUseOtherColor ? LineColor : Color.gray; ;
                addStr = "——";
                break;
        }
        copyText.text = addStr;
        float perlineWidth = copyText.preferredWidth;      //单个下划线宽度  
        float width = proText.preferredWidth;              //原文字的宽度
        int lineCount = (int)Mathf.Round(width / perlineWidth);
        for (int i = 1; i < lineCount; i++)
        {
            copyText.text += addStr;
        }

    }




    private Text CreateExpandText(Text proText)              //创建一个新的Text（Tx_Expand）
    {
        DefaultControls.Resources resources = new DefaultControls.Resources();
        GameObject go = DefaultControls.CreateText(resources);
        go.name = "Tx_Expand";
        go.transform.SetParent(transform);
        go.layer = LayerMask.NameToLayer("UI");
        go.transform.localScale = Vector3.one;

        Text copyText = go.GetComponent<Text>();
        RectTransform rt = copyText.rectTransform;
        rt.anchoredPosition3D = Vector3.zero;
        rt.offsetMax = Vector2.zero;
        rt.offsetMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.anchorMin = Vector2.zero;
        copyText.alignment = proText.alignment;
        copyText.fontSize = proText.fontSize;
        return copyText;
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if (!IsClick2OpenWeb)
        {
            return;
        }
        if (!string.IsNullOrEmpty(WebUrl))
        {
            Application.OpenURL(WebUrl);
        }
        else
        {
            MyLog.Red("网址为空");
        }
    }





}