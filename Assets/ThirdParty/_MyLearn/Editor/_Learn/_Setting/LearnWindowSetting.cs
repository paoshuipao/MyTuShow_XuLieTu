using Ez;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using QuickEngine.Core;
using Sirenix.OdinInspector;
using UnityEditor.AnimatedValues;
using UnityEngine;

public abstract class WindowSetting : ScriptableObject
{

    public float windowMinimumWidth
    {
        get
        {
            return SidebarCurrentWidth + pageShadowWidth + pageWidth + pageWidthExtraSpace.value + scrollbarSize;
        }
    }
    public float SidebarCurrentWidth
    {
        get
        {
            return (sidebarExpandedWidth * sidebarIsExpanded.faded) + (sidebarCollapsedWidth * (1 - sidebarIsExpanded.faded));
        }
    }

    public float CurrentPageContentWidth
    {
        get { return pageWidth + pageWidthExtraSpace.value - pageShadowWidth; }
    }


    //——————————————————下面是配置文件配置的——————————————————


    public Tools_EZ.Page currentPage = Tools_EZ.Page.Pooly;

    [MyHead("页面高度，低于 640 可缩放")]
    public float windowMinimumHeight = 640;


    [Title("控制左边", MyEnumColor.Blue)]
    [MyHead("左边距离")]
    public float sidebarExpandedWidth = 180;
    public float sidebarCollapsedWidth = 32;
    public AnimBool sidebarIsExpanded = new AnimBool(true);
    public float sidebarButtonHeight = 32;
    public float sidebarVerticalSpacing = 16;
    [MyHead("Logo 的高度")]
    public float sidebarLogoHeight = 80;
    public float scrollbarSize = 32;


    [Title("控制右边", MyEnumColor.Blue)]
    public float pageShadowWidth = 16;
    [MyHead("页面宽度")]
    public float pageWidth = 600;
    public AnimFloat pageWidthExtraSpace = new AnimFloat(0);


    [MyHead("Head 标题高度")]
    public float pageHeaderHeight = 30;


}





public class LearnWindowSetting : WindowSetting
{
    public static LearnWindowSetting _instance;
    public static LearnWindowSetting Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Q.GetResource<LearnWindowSetting>(EZT.RESOURCES_PATH_CONTROL_PANEL_WINDOW_SETTINGS, "LearnWindowSetting");
#if UNITY_EDITOR
                if (_instance == null)
                {
                    _instance = Q.CreateAsset<LearnWindowSetting>(EZT.RELATIVE_PATH_CONTROL_PANEL_WINDOW_SETTINGS, "LearnWindowSetting");
                }
#endif
            }
            return _instance;
        }
    }


}
