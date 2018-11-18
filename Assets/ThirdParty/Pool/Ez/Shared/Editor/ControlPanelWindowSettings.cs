using QuickEngine.Core;
using PSPUtil.Attribute;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Ez.Editor
{
    public class ControlPanelWindowSettings : ScriptableObject
    {
        public static ControlPanelWindowSettings _instance;
        public static ControlPanelWindowSettings Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Q.GetResource<ControlPanelWindowSettings>(EZT.RESOURCES_PATH_CONTROL_PANEL_WINDOW_SETTINGS, "ControlPanelWindowSettings");
#if UNITY_EDITOR
                    if(_instance == null)
                    {
                        _instance = Q.CreateAsset<ControlPanelWindowSettings>(EZT.RELATIVE_PATH_CONTROL_PANEL_WINDOW_SETTINGS, "ControlPanelWindowSettings");
                    }
#endif
                }
                return _instance;
            }
        }

        public float windowMinimumWidth
        {
            get
            {
                return SidebarCurrentWidth + pageShadowWidth + pageWidth + pageWidthExtraSpace.value + scrollbarSize;
            }
        }
        [MyHead("页面高度，低于 640 可缩放")]
        public float windowMinimumHeight = 640;
        
        [MyHead("左边距离")]
        [Space(20)]
        public float sidebarExpandedWidth = 296;
        public float sidebarCollapsedWidth = 32;
        public AnimBool sidebarIsExpanded = new AnimBool(true);

        public float SidebarCurrentWidth
        {
            get
            {
                return (sidebarExpandedWidth * sidebarIsExpanded.faded) + (sidebarCollapsedWidth * (1 - sidebarIsExpanded.faded));
            }
        }

        [Space(10)]
        public float sidebarButtonHeight = 32;
        public float sidebarVerticalSpacing = 16;
        public float sidebarLogoHeight = 80;

        [Space(20)]
        public float scrollbarSize = 32;

        [Space(20)]
        public float pageShadowWidth = 16;
        [MyHead("页面宽度")]
        public float pageWidth = 640;
        public AnimFloat pageWidthExtraSpace = new AnimFloat(0);
        public float pageHeaderHeight = 64;
        public float CurrentPageContentWidth { get { return pageWidth + pageWidthExtraSpace.value - pageShadowWidth; } }

        [Space(20)]
        public float editorAnimationSpeed = 4;

        [Space(20)]
        public Tools_EZ.Page currentPage = Tools_EZ.Page.Pooly;
    }
}
