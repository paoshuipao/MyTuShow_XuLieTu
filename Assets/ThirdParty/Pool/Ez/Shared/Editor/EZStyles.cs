using QuickEditor;
using System.Collections.Generic;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace Ez
{
    public class EZStyles
    {
        public enum General
        {
            SideButtonCollapseSideBar,
            SideButtonExpandSideBar,

            SideButton1,
            SideButton2,
            SideButton3,
            SideButton4,
            SideButton5,
            SideButton6,
            SideButton7,
            SideButton8,

            SideButtonSelected1,
            SideButtonSelected2,
            SideButtonSelected3,
            SideButtonSelected4,
            SideButtonSelected5,
            SideButtonSelected6,
            SideButtonSelected7,
            SideButtonSelected8,

            SideButtonTwitter,
            SideButtonBlue,
            SideButtonRed,
        }


        private static GUISkin skin;
        public static GUISkin Skin { get { if(skin == null) { skin = GetSkin(); } return skin; } }

        /// <summary>
        /// Returns a style that has been added to the skin.
        /// </summary>
        public static GUIStyle GetStyle(string styleName) { return Skin.GetStyle(styleName); }

        /// <summary>
        /// Returns a style that has been added to the skin.
        /// This method is to be used paired with the enums in the Style class.
        /// </summary>
        public static GUIStyle GetStyle<T>(T styleName)
        {
            return Skin.GetStyle(QStyles.GetStyleName(styleName));
        }

        private static GUISkin GetSkin()
        {
            GUISkin skin = ScriptableObject.CreateInstance<GUISkin>();
            List<GUIStyle> styles = new List<GUIStyle>();
            styles.AddRange(GeneralStyles());

            skin.customStyles = styles.ToArray();
            return skin;
        }

        private static void UpdateSkin()
        {
            skin = null;
            skin = GetSkin();
        }

        public static void AddStyle(GUIStyle style)
        {
            if(style == null) { return; }
            List<GUIStyle> customStyles = new List<GUIStyle>();
            customStyles.AddRange(Skin.customStyles);
            if(customStyles.Contains(style)) { return; }
            customStyles.Add(style);
            Skin.customStyles = customStyles.ToArray();
        }

        public static void RemoveStyle(GUIStyle style)
        {
            if(style == null) { return; }
            List<GUIStyle> customStyles = new List<GUIStyle>();
            customStyles.AddRange(Skin.customStyles);
            if(!customStyles.Contains(style)) { return; }
            customStyles.Remove(style);
            Skin.customStyles = customStyles.ToArray();
        }


        private static List<GUIStyle> GeneralStyles()
        {
            List<GUIStyle> styles = new List<GUIStyle>
            {
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButtonCollapseSideBar), EZResources.sideButtonCollapseSideBar, QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(2, 28, 2, 2), new RectOffset(2, 32, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButtonExpandSideBar), EZResources.sideButtonExpandSideBar, QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(2, 28, 2, 2), new RectOffset(2, 32, 2, 4)),

                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton1), EZResources.sideButtonControlPanel, QUI.IsProSkin ? QColors.BlueLight.Color : QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton2), EZResources.sideButtonDefineSymbols, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton3), EZResources.sideButtonDataManager, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color, QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton4), EZResources.sideButtonDataBind, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton5), EZResources.sideButtonPooly, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton6), EZResources.sideButtonAdsManager, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color, QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton7), EZResources.sideButtonHelp, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButton8), EZResources.sideButtonAbout, QUI.IsProSkin ? QColors.BlueLight.Color :QColors.BlueDark.Color, QColors.BlueDark.Color,  QColors.GreenLight.Color , new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),

                GetSideButtonStyle(QStyles.GetStyleName(General.SideButtonTwitter), EZResources.sideButtonTwitter, MyColor.GetColor(128,128,128), MyColor.GetColor(242,242,242),  MyColor.GetColor(0,153,209), new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4), 14),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButtonBlue), EZResources.sideButtonFacebook, MyColor.GetColor(128,128,128), MyColor.GetColor(242,242,242), MyColor.GetColor(74,112,186), new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4), 14),
                GetSideButtonStyle(QStyles.GetStyleName(General.SideButtonRed), EZResources.sideButtonYoutube, MyColor.GetColor(128,128,128),  MyColor.GetColor(242,242,242),  MyColor.GetColor(255, 102,102), new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4), 14),




                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected1), EZResources.sideButtonControlPanelSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected2), EZResources.sideButtonDefineSymbolsSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected3), EZResources.sideButtonDataManagerSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected4), EZResources.sideButtonDataBindSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected5), EZResources.sideButtonPoolySelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected6), EZResources.sideButtonAdsManagerSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected7), EZResources.sideButtonHelpSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
                GetSideButtonSelectedStyle(QStyles.GetStyleName(General.SideButtonSelected8), EZResources.sideButtonAboutSelected, QColors.GreenLight.Color, new RectOffset(28, 2, 2, 2), new RectOffset(32, 2, 2, 4)),
            };
            return styles;
        }

        private static GUIStyle GetSideButtonStyle(string styleName, QTexture qTexture, Color normalTextColor, Color hoverTextColor, Color activeTextColor, RectOffset border, RectOffset padding, int fontSize = 20)
        {
            return new GUIStyle()
            {
                name = styleName,
                normal = { background = qTexture.normal2D, textColor = normalTextColor },
                onNormal = { background = qTexture.normal2D, textColor = normalTextColor },
                hover = { background = qTexture.hover2D, textColor = hoverTextColor },
                onHover = { background = qTexture.hover2D, textColor = hoverTextColor },
                active = { background = qTexture.active2D, textColor = activeTextColor },
                onActive = { background = qTexture.active2D, textColor = activeTextColor },
                border = border,
                padding = padding,
                fontSize = fontSize,
                alignment = TextAnchor.MiddleLeft,
//                font = QResources.GetFont(Sansation.Regular)
            };
        }
        private static GUIStyle GetSideButtonSelectedStyle(string styleName, QTexture qTexture, Color normalTextColor, RectOffset border, RectOffset padding)
        {
            return new GUIStyle()
            {
                name = styleName.ToString(),
                normal = { background = qTexture.normal2D, textColor = normalTextColor },
                onNormal = { background = qTexture.normal2D, textColor = normalTextColor },
                border = border,
                padding = padding,
                fontSize = 20,
                alignment = TextAnchor.MiddleLeft,
//                font = QResources.GetFont(Sansation.Regular)
            };
        }
    }
}
