using System.Collections.Generic;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Unity_UGUI : AbstactNewKuang
    {

        [MenuItem(LearnMenu.UnityUGUIZhongJie)]
        static void Init()
        {
            Unity_UGUI instance = GetWindow<Unity_UGUI>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {

            #region Canvas

            bool isCanvas = (type == EType.Canvas || type == EType.Canvas1 || type == EType.Canvas2 || type == EType.Canvas3 || type == EType.Canvas4 || type == EType.Canvas5);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Canvas";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Canvas ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Canvas);
            }
            if (isCanvas)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Canvas1 ? "叠加各画布".AddBlue() : "叠加各画布");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Canvas1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Canvas2 ? "画布根据相机来布局".AddBlue() : "画布根据相机来布局");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Canvas2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Canvas3 ? "画布在世界空间随意".AddBlue() : "画布在世界空间随意");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Canvas3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Canvas4 ? "CanvasScaler".AddBlue() : "CanvasScaler");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Canvas4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Canvas5 ? "GraphicRaycaster".AddBlue() : "GraphicRaycaster");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Canvas5);
                }
            }

            #endregion

            AddSpace();

            #region UGUI

            bool isUGUI = (type == EType.UGUI || type == EType.UGUI1 || type == EType.UGUI2 || type == EType.UGUI3 || type == EType.UGUI4 || type == EType.UGUI5 || type == EType.UGUI6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "UGUI";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.UGUI ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.UGUI);
            }
            if (isUGUI)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI1 ? "   结构图".AddBlue() : "   结构图");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI2 ? "   层次关系".AddBlue() : "   层次关系");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI3 ? "   RectTransform".AddBlue() : "   RectTransform");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI3);
                }
                MyCreate.Text("单继承 UIBehaviour");
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI4 ? "   CanvasGroup".AddBlue() : "   CanvasGroup");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI5 ? "   ScrollRect".AddBlue() : "   ScrollRect");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.UGUI6 ? "   ToggleGroup".AddBlue() : "   ToggleGroup");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.UGUI6);
                }
            }


            #endregion

            AddSpace();

            #region 图像组件


            bool tmpTu = (type == EType.Tu || type == EType.Tu1 || type == EType.Tu2 || type == EType.Tu3 || type == EType.Tu4 || type == EType.Tu5);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "图像组件";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(tmpTu ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Tu1);
            }
            if (tmpTu)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Tu1 ? "    Text".AddBlue() : "    Text");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Tu1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Tu2 ? "    Image".AddBlue() : "    Image");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Tu2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Tu3 ? "    RawImage".AddBlue() : "    RawImage");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Tu3);
                }
                MyCreate.Text("与图像组件密切相关的类：");
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Tu4 ? "    Mask".AddBlue() : "    Mask");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Tu4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Tu5 ? "    Effects".AddBlue() : "    Effects");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Tu5);
                }
            }

            #endregion

            AddSpace();

            #region 可交互组件

            bool isJiaHu = (type == EType.JiaHu || type == EType.JiaoHu1 || type == EType.JiaoHu2 || type == EType.JiaoHu3 || type == EType.JiaoHu4 || type == EType.JiaoHu5 || type == EType.JiaoHu6);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "可交互组件";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isJiaHu ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JiaoHu1);
            }
            if (isJiaHu)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu1 ? "    Button".AddBlue() : "    Button");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu2 ? "    Dropdown".AddBlue() : "    Dropdown");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu3 ? "    InputField".AddBlue() : "    InputField");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu4 ? "    Slider".AddBlue() : "    Slider");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu5 ? "    Toggle".AddBlue() : "    Toggle");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiaoHu6 ? "    Scrollbar".AddBlue() : "    Scrollbar");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiaoHu6);
                }
            }

            #endregion

            AddSpace();


            #region LayoutGroup

            bool isLayout = (type == EType.Layout || type == EType.Layout1 || type == EType.Layout2);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "LayoutGroup";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isLayout ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Layout1);
            }
            if (isLayout)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Layout1 ? "GridLayoutGroup".AddBlue() : "GridLayoutGroup");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Layout1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Layout2 ? "横 竖 LayoutGroup".AddBlue() : "横 竖 LayoutGroup");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Layout2);
                }
            }

            #endregion

            AddSpace();

            #region UGUI -> 工具类


            bool isRect = (type == EType.Static || type == EType.Static1 || type == EType.Static2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "UGUI -> 工具类".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isRect ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Static1);
            }
            if (isRect)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static1 ? "DefaultControls".AddBlue() : "DefaultControls");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Static2 ? "RectTransformUtility".AddBlue() : "RectTransformUtility");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Static2);
                }
            }

            #endregion

            AddSpace();

            #region 接口事件


            bool isJieKou = (type == EType.JieKou || type == EType.JieKou1 || type == EType.JieKou2 || type == EType.JieKou3);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "接口事件";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JieKou ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JieKou);
            }
            if (isJieKou)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieKou1 ? "参数".AddBlue() : "参数");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieKou1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieKou2 ? "EventTrigger".AddBlue() : "EventTrigger");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieKou2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieKou3 ? "EventSystem".AddBlue() : "EventSystem");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieKou3);
                }
            }

            #endregion


            AddSpace();

            #region 接口事件


            bool isOhter = (type == EType.Other || type == EType.Other1 );
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "其他";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isOhter ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Other);
            }
            if (isOhter)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Other ? "ContentSizeFitter".AddBlue() : "ContentSizeFitter");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Other);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Other1 ? "ScrollView 组合".AddBlue() : "ScrollView 组合");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Other1);
                }
            }

            #endregion



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.UGUI:         DrawRightPage1(DrawZuJianZhongJie);        break;
                case EType.UGUI1:        DrawRightPage(DrawZhongJie);               break;
                case EType.UGUI2:        DrawRightPage3(DrawCengCi);                break;
                case EType.UGUI3:        DrawRightPage4(DrawRectTransform);         break;
                case EType.UGUI4:        DrawRightPage5(DrawCanvasGroup);           break;
                case EType.UGUI5:        DrawRightPage8(DrawScrollRect);            break;
                case EType.UGUI6:        DrawRightPage1(DrawToggleGroup);           break;
                case EType.Static1:      DrawRightPage1(DrawDefaultControls);       break;
                case EType.Static2:      DrawRightPage5(DrawRectTransformUtility);  break;
                case EType.Canvas:       DrawRightPage8(DrawCanvas);                break;
                case EType.Canvas1:      DrawRightPage1(DrawCanvas1);               break;
                case EType.Canvas2:      DrawRightPage3(DrawCanvas2);               break;
                case EType.Canvas3:      DrawRightPage3(DrawCanvas3);               break;
                case EType.Canvas4:      DrawRightPage3(DrawCanvasScaler);          break;
                case EType.Canvas5:      DrawRightPage3(DrawGraphicRaycaster);      break;
                case EType.Tu1:          DrawRightPage3(DrawText);                  break;
                case EType.Tu2:          DrawRightPage4(DrawImage);                 break;
                case EType.Tu3:          DrawRightPage5(DrawRawImage);              break;
                case EType.Tu4:          DrawRightPage6(DrawMask);                  break;
                case EType.Tu5:          DrawRightPage1(DrawEffects);               break;
                case EType.JiaoHu1:      DrawRightPage7(DrawButton);                break;
                case EType.JiaoHu2:      DrawRightPage8(DrawDropdown);              break;
                case EType.JiaoHu3:      DrawRightPage1(DrawInputField);            break;
                case EType.JiaoHu4:      DrawRightPage3(DrawSlider);                break;
                case EType.JiaoHu5:      DrawRightPage7(DrawToggle);                break;
                case EType.JiaoHu6:      DrawRightPage8(DrawScrollbar);             break;
                case EType.Layout1:      DrawRightPage1(DrawGridLayoutGroup);       break;
                case EType.Layout2:      DrawRightPage2(DrawVerticalLayoutGroup);   break;
                case EType.JieKou:       DrawRightPage8(DrawJieKouEvent);           break;
                case EType.JieKou1:      DrawRightPage1(DrawXiangGuang);            break;
                case EType.JieKou2:      DrawRightPage3(DrawOther);                 break;
                case EType.JieKou3:      DrawRightPage4(DrawEventSystem);           break;
                case EType.Other:        DrawRightPage5(DrawContentSizeFitter);     break;
                case EType.Other1:       DrawRightPage5(DrawScrollView);            break;

            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.JieKou:
                    mWindowSettings.pageWidthExtraSpace.target = 5;
                    break;
                case EType.Canvas:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                case EType.Static1:
                    mWindowSettings.pageWidthExtraSpace.target = 90;
                    break;
                case EType.Tu2:
                    mWindowSettings.pageWidthExtraSpace.target = 15;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }


        #region 私有
        private bool isConstantPixel, isCPhysical, isWorld;
        private bool isFlipLayoutAxes, isFlipLayoutOnAxis, isTouch, isTu, isSorting,isMovement, isInertia;
        private bool isFilled, isNavigation;
        private string m_Input;
        private List<SearchText> l_AllTextAttribute;
        private TransitionType m_TransitionType = TransitionType.ColorTint;
        private float m_ShowBool;


        enum TransitionType
        {
            None,
            ColorTint,
            SpriteSwap,
            Animation
        }


        private enum EType
        {
            UGUI,UGUI1,UGUI2, UGUI3, UGUI4, UGUI5, UGUI6,
            Static, Static1, Static2,
            Canvas, Canvas1, Canvas2, Canvas3, Canvas4, Canvas5,
            Tu, Tu1,Tu2,Tu3,Tu4, Tu5,
            JiaHu, JiaoHu1, JiaoHu2, JiaoHu3, JiaoHu4, JiaoHu5, JiaoHu6,
            Layout,Layout1,Layout2,
            JieKou, JieKou1, JieKou2, JieKou3,
            Other, Other1,


        }

        private EType type = EType.UGUI;

        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }
        }

        protected override void OnInit()
        {
            base.OnInit();
            l_AllTextAttribute = new List<SearchText>();
            l_AllTextAttribute.AddRange(l_EnterAndOut);
            l_AllTextAttribute.AddRange(l_Click);
            l_AllTextAttribute.AddRange(l_Drag);
            l_AllTextAttribute.AddRange(l_Scroll);
            l_AllTextAttribute.AddRange(l_Highlighted);
            l_AllTextAttribute.AddRange(l_Keyboard);
        }

        protected override string Tittle()
        {
            return "UGUI";
        }


        private void ShowItem(SelectTextAddText[] shows)
        {
            foreach (SelectTextAddText textAttribute in shows)
            {
                textAttribute.Show(m_Tools, m_Input);
            }
        }

        private void TheSame()
        {

            m_Tools.BiaoTi_O("继承 LayoutGroup 布局共有属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Padding", "内边距离", -55);
                m_Tools.TextText_BL("Child Alignment", "整体 Item ".AddGreen() + "锚点位置" + "Upper(上 )Middle(中) Lower(下)".AddWhite(), -55);
            });

        }
        private void PixelPerfect(int widht =-70)
        {
            m_Tools.TextText_YB("Pixel Perfect", OpenSure + "像素完美，UI渲染没抗锯齿", widht);
        }

        private void SortingLayer()
        {
            m_Tools.TextText_YB("Sorting Layer", "层的排序，下面的层" + "一定覆盖".AddGreen() + "上面的层", -30);
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("例如：Sprite Renderer 中 选择 Sorting1 " + "（Sorting1 在 Default 下面）".AddGreen());
                m_Tools.Text("     这个 Canvas 选择 Default");
                m_Tools.Text_G("这时不管 Sprite 怎么移动，都会在 Canvas 前面");
            });
        }


        private void OrderinLayer()
        {
            m_Tools.TextText_YB("Order in Layer", "值为 0 ：".AddHui() + "   画布与Z轴正对中", -30);
            m_Tools.TextText_YB("", "值为 100：".AddHui() + " 画布靠近相机正Z轴 +100", -30);
            m_Tools.TextText_YB("", "值为 -1 ：".AddHui() + "  画布远离相机正Z轴 -1", -30);
            m_Tools.TextText_YB("", "即值越大，越近相机，越先渲染，但Z轴不变", -30);
        }

        private void ThreeTheSame()
        {
            AddSpace();
            m_Tools.BiaoTi_B("继承 Graphic 共有属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("Material", "(材质)   ".AddWhite(), "Color", "(颜色)    ".AddWhite(), "RaycastTarget", "(是否接收射线事件)".AddWhite());
            });
        }
        private void ReferencePixeles()
        {
            m_Tools.TextText_YB("Reference Pixels Per Unit", "多少个像素占1世界空间单位", 20);
        }

        private void BaseInteractible()                          //可交互组件基本属性
        {
            m_Tools.BiaoTi_O("继承 Selectable 可交互组件基本属性");
            Selectable();
        }


        private void Selectable()
        {
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Interactible", OpenSure + "是否可以交互", -50);
                m_TransitionType = (TransitionType)m_Tools.BiaoTi_B(m_TransitionType, "Transition", 20);
                switch (m_TransitionType)
                {
                    case TransitionType.None:
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_G("没有点击转换效果");
                        });
                        break;
                    case TransitionType.ColorTint:
                        EachNormal();
                        m_Tools.TextText_BL("Color Multiplier", "实际颜色 = 上面的颜色 X 该值", -10);
                        m_Tools.TextText_BL("Fade Duration", "从一种状态" + "切换".AddGreen() + "另一种状态的" + "时间".AddGreen() + "(单位秒)", -10);
                        break;
                    case TransitionType.SpriteSwap:
                        EachNormal();
                        break;
                    case TransitionType.Animation:
                        EachNormal();
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.TextText_HG("Auto Generate Animation", "自动生成动画");
                        });
                        break;
                }
                m_Tools.TextText2_BY("Navigation".AddBold(), "是否允许键盘按上下左右控制那个高亮      ", ref isNavigation, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_H("1. 必须是", "相同组件".AddGreen(), "才能移动（靠键盘上下左右）");
                            m_Tools.Text_H("2. ", "不会触发".AddGreen(), "点击事件，改值等的事件");
                            m_Tools.Text_H("3. 移动的是那个组件处于", " Highlighted ".AddGreen(), "的状态");
                            m_Tools.TextText_HG("Visualize", "可视化");

                        });
                        m_Tools.TextText_LY(" None", "不用这键盘操作");
                        m_Tools.TextText_LY(" Horizontal", "只能水平移动");
                        m_Tools.TextText_LY(" Vertical", "只能垂直移动");
                        m_Tools.TextText_LY(" Automatic", "水平和垂直都行");
                        m_Tools.TextText_LY(" Explicit", "自定义按上是对应那个组件，按右是那个");

                    });
                }, 10);
            });
        }


        private void EachNormal()
        {
            m_Tools.TextText_BL("Normal Color", "正常的时候颜色", -10);
            m_Tools.TextText_BL("Highlighted Color", "鼠标" + "移到位置".AddGreen() + "或者" + "最后点击".AddGreen(), -10);
            m_Tools.TextText_BL("Pressed Color", "鼠标" + "按下".AddGreen(), -10);
            m_Tools.TextText_BL("Disabled Color", "Interactible ".AddBlue() + "没勾选的时候", -10);
        }


        private void AdditionalShader()                          // Additional Shader Channels
        {
            m_Tools.TextText_YB("Additional Shader Channels", "");
        }


        private readonly SelectTextAddText[] l_EnterAndOut =
        {
            new SelectTextAddText("IPointerEnterHandler", "鼠标进入"),
            new SelectTextAddText("IPointerExitHandler", "鼠标离开"),
        };

        private readonly SelectTextAddText[] l_Click =
        {
            new SelectTextAddText("IPointerDownHandler", "鼠标按下"),
            new SelectTextAddText("IPointerUpHandler", "鼠标放开"+"（可以不在UI身上）".AddGreen()),
            new SelectTextAddText("IPointerClickHandler", "鼠标点击"),
        };

        private readonly SelectTextAddText[] l_Drag =
        {
            new SelectTextAddText("IInitializePotentialDragHandler", "鼠标按下"+"(如果没有IDragHandler，它是没用的)".AddGreen()),
            new SelectTextAddText("IBeginDragHandler", "在 IDragHandler "+"前调用一次".AddGreen()),
            new SelectTextAddText("IDragHandler", "拖动，"+"每移动一点距离就调用一次".AddGreen()),
            new SelectTextAddText("IEndDragHandler", "拖动结束"),
            new SelectTextAddText("IDropHandler", "别的UI".AddGreen()+"拖动到自己这里调用"),
        };

        private readonly SelectTextAddText[] l_Scroll =
        {
            new SelectTextAddText("IScrollHandler", "鼠标中间滚动"),

        };

        private readonly SelectTextAddText[] l_Highlighted =
        {
            new SelectTextAddText("IUpdateSelectedHandler", "只要有高亮的UI，"+"一直调用".AddGreen()),
            new SelectTextAddText("ISelectHandler", "当这个UI成为高亮"),
            new SelectTextAddText("IDeselectHandler", "当这个UI取消高亮"),
        };


        private readonly SelectTextAddText[] l_Keyboard =
        {

            new SelectTextAddText("IMoveHandler", "键盘按（上，下，左，右）"),
            new SelectTextAddText("ISubmitHandler", "键盘按下回车(只在可交互组件触发)"),
            new SelectTextAddText("ICancelHandler", "键盘按下Esc(只在可交互组件触发)"),
        };


        #endregion


        #region UGUI

        private void DrawZuJianZhongJie()                        // 各个组件总结
        {
            m_Tools.BiaoTi_B("UIBehaviour " + "(UI组件基类)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("关联不再是 Transform，而是 " + "RectTransform ".AddWhite());
                    m_Tools.Text_Y("     ToggleGroup" + "(多选项只有一个对)".AddWhite() + "、ScrollRect" + "(滚动区域)".AddWhite());
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("Graphic 衍生 MasKableGraphic " + "(可视化的图像UI)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/UI.Graphic.html", "Graphic官方带自定义图像例子");
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("只要是继承这个类，面板就会有：");
                    m_Tools.Text_H("1. 自动关联 " + "CanvasRenderer".AddBlue());
                    m_Tools.Text_H("2. ", "Material".AddBlue(), "(材质)、", "Color".AddBlue(), "(颜色)、", "RaycastTarget".AddBlue(), "(是否接收射线事件)");
                    m_Tools.Text_Y("     RawImage、Image、Text + Mask 遮挡");
                });

            });
            AddSpace();
            m_Tools.BiaoTi_B("Selectable " + "(可交互组件)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("只要是继承这个类，面板就会有：");
                    m_Tools.Text4(" Interactable".AddBlue(), " （是否能交互）", "Transition".AddBlue(), " （转换）", 30);
                    m_Tools.Text4(" TargetGraphic".AddBlue(), " （目标 Graphic）" , "Navigation".AddBlue(), " （导航）", 30);
                    m_Tools.Text_Y("     Button、Toggle、Sldier、Dropdown、InputField、Scrollbar");
                });

            });
            AddSpace();
            m_Tools.BiaoTi_B("LayoutGroup 布局组");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("     GridLayoutGroup、HorizontalOrVerticalLayoutGroup");
            });


            AddSpace();
            m_Tools.BiaoTi_B(" 与 UGUI 密切关联的类");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("     RectTransform、Canvas、EventSystem、CanvasGroup");
            });


        }

        private void DrawZhongJie()                              // 结构图
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711130309542-390494744.png");

        }

        private void DrawCengCi()                                //层次关系
        {
            m_Tools.BiaoTi_B("层次关系");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("同一 Canvas 下 " + "(UI 越往下面，越靠前)".AddGreen());
                m_Tools.SelectTextText_B("transform.SetAsLastSibling", "组件移动到最下面 " + "(最先显示)".AddGreen());
                m_Tools.SelectTextText_B("transform.SetAsFirstSibling", "组件移动到最上面 " + "(最后显示)".AddGreen());
                m_Tools.SelectTextText_B("transform.SetSiblingIndex", "组件移动到自定义索引处 " + "(0 为最上面)".AddGreen());
                m_Tools.SelectTextText_B("transform.GetSiblingIndex", "获得组件在第几个索引位置 " + "(从 0 开始)".AddGreen());
                AddSpace();
                m_Tools.BiaoTi_O("不同 Canvas 下");
                m_Tools.TextText_LG("Overlay", "Sort Order".AddWhite() + " 越大，越靠前显示", -20);
                m_Tools.TextText_LG("Cmaera", "Order In Layer".AddWhite() + " 越大，越靠近相机，越前显示", -20);
                m_Tools.TextText_LG("World Space", "控制 " + "Order In Layer".AddWhite() + " 或者直接控制" + " Z 轴".AddWhite(), -20);
            });

        }

        private void DrawRectTransform()                         // RectTransform
        {
            m_Tools.BiaoTi_B("RectTransform " + "(继承Transform)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("Anchors 锚点 " + "(矩形、正常坐标系)".AddGreen() + "  Pivot 中心点" + " (正常坐标系)".AddGreen());
                MyCreate.Box(() =>
                {
                    MyCreate.TextCenter("这个两都是 以左下角为原点（0，0）的正常坐标系");
                    m_Tools.Text("锚点 把它看成是矩形就行 " + "Min(X、Y) Max(Width、Height)".AddGreen());
                    m_Tools.Text("中心点 Component 下面 Pivot显示中心点、Center 不显示");
                    m_Tools.Text_G("锚点图解", ref isTu, () =>
                    {
                        MyCreate.Heng(() =>
                        {
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711130552164-1098213569.png");
                            MyCreate.AddSpace(10);
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711130640214-2068169769.png");
                        });
                        MyCreate.Heng(() =>
                        {
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711130825422-39627190.png");
                            MyCreate.AddSpace(10);
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711130932837-688607579.png");
                        });
                    });

                });

                m_Tools.Text_W("Rotation 旋转     Scale 尺寸大小 " + "(与Transform相同)".AddGreen());
                MyCreate.FenGeXian("下面 GetComponent<RectTransform>() 简写 rt".AddWhite());
                m_Tools.Text_O("1.改变RectTransform的top");
                m_Tools.Text_Y("     rt.offsetMax = new Vector2(rt.offsetMax.x, top值)");

                m_Tools.Text_O("2.改变RectTransform的bottom");
                m_Tools.Text_Y("     rt.offsetMin = new Vector2(rt.offsetMin.x, top值)");

                m_Tools.Text_O("3.改变RectTransform的width，height");
                m_Tools.Text_Y("     rt.sizeDelta = new Vector2(width, height)");

                m_Tools.Text_O("4.改变RectTransform的posX，posY");
                m_Tools.Text_Y("     rt.anchoredPosition3D = new Vector3(posX, posY, posZ)");
                m_Tools.Text_Y("     rt.anchoredPosition  = new Vector2(posX, posY)");
                
            });

            m_Tools.BiaoTi_B("总结");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("offsetMin  -> Vector2  ->  对应 Left、Top");
                m_Tools.Text_B("offsetMax  -> Vector2  ->  对应 Right、Bottom ");
                m_Tools.Text_B("sizeDelta  -> Vector2  ->  对应 width、height ");
                m_Tools.Text_B("anchoredPosition3D  -> Vector3  ->  对应 posX、posY,posZ ");

            });

        }


        private void DrawCanvasGroup()                           // CanvasGroup
        {

            m_Tools.BiaoTi_B("CanvasGroup" + "(控制子UI Alpha，Raycasting，Enabled)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("控制自己以及所有的子 UI：", "透明度，射线事件，能否交互".AddGreen());
                m_Tools.Text_H("继承 Component");
            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW("Alpha", "透明度", -20);
                m_Tools.TextText_BW("Interactable", "能否交互，为false，禁用交互" + "(但接口事件能用)".AddGreen(), -20);
                m_Tools.TextText_BW("Block Raycasts", "禁用射线，为false，禁用射线，一切都不能用", -20);
                m_Tools.TextText_BW("Ignore Parent Groups", "忽略父 Canvas Group，自已搞一套", -20);

            });

        }


        private void DrawScrollRect()                            // ScrollRect
        {
            m_Tools.BiaoTi_Y("ScrollRect " + "(占用大量空间的内容需要在小范围内显示)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("当占用大量空间的内容需要在小范围内显示时，滚动矩形提供了滚动此内容的功能");
                m_Tools.Text_H("将", "Scroll Rect".AddLightBlue(), "与 ", "Mask".AddLightBlue(), " 结合以创建滚动视图，可加", "水平或垂直滚动滚动条".AddLightBlue(), "相结合");
            });

            m_Tools.TextText("Content", "要滚动的UI引用");
            m_Tools.BiaoTi_O("以内容作为滑动");
            m_Tools.TextText("Horizontal", "水平滚动（内容能水平拖动，不是滑动条）");
            m_Tools.TextText("Vertical", "垂直滚动（内容能垂直拖动，不是滑动条）");
            m_Tools.TextText_LW(" Movement Type", " 内容拖动到头时的移动性", ref isMovement, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText("Unrestricted", "没限制，没尽头");
                    m_Tools.TextText("Elastic", "弹一下,弹性的长度根据 Elasticity");
                    m_Tools.TextText("Clamped", "夹紧，到头了就到头了");
                });
            });
            m_Tools.TextText_LW(" Inertia", " 有没有惯性，释放鼠标时内容将继续移动", ref isInertia, () =>
            {
                m_Tools.TextText("Deceleration Rate", "速率为0 将立即停止运动");
                m_Tools.TextText("", "速率为1 意味着运动永远不会放慢速度");

            });
            m_Tools.BiaoTi_O("以鼠标中间滑轮作为滑动");
            m_Tools.TextText("Scroll Sensitivity", "为 0 时鼠标滑轮没反应，值越高滚越快");

            m_Tools.BiaoTi_O("以滑动条作为滑动");
            m_Tools.TextText("Horizontal Scrollbar", "水平滚动条引用");
            m_Tools.TextText("Vertical Scrollbar", "垂直滚动条引用");
            m_Tools.TextText("Visibility", " 能见度 就选第三个");
            m_Tools.TextText("Spacing", "滚动条和视口之间的空间");
            m_Tools.TextText_LH("OnValueChange(Vector2)", "当内容发生改变的回调事件");


        }

        private void DrawToggleGroup()                           // ToggleGroup
        {

            m_Tools.BiaoTi_Y("ToggleGroup " + "(bool 组)".AddGreen() + "多个选项只有一个对其它错");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("1.父为Dropdown，子为多个Toggle");
                m_Tools.Text_G("2.子Toggle要在Group引用这个父Dropdown");
                m_Tools.BiaoTi_O("ToggleGroup 属性");
                m_Tools.TextText("Allow Switch Off", "是否允许全为空");
                m_Tools.TextText("", "打勾，可以全为错或者只有一个对");
                m_Tools.TextText("", "不勾，就是多个选项只有一个对其它错");
            });

        }

        #endregion

        #region UGUI -> 工具类




        private void DrawRectTransformUtility()                  // RectTransformUtility
        {
            m_Tools.BiaoTi_Y("RectTransformUtility" + "RectTransform 的辅助工具类".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("首先说明一点：");
                m_Tools.TextText_BL("transform.postion", "3D坐标"+"（与下面是完全是不同的）".AddGreen());
                m_Tools.TextText_BL("rectTransform.anchoredPosition", "2D在Rect里的坐标");
                m_Tools.Text_G("UGUI 坐标还是相对坐标（带节点），所有转换需要使用该辅助工具类");
            });
            m_Tools.BiaoTi_B("static 方法");
            MyCreate.Box(() =>
            {
                MyCreate.Text("翻转".AddGreen());
                m_Tools.Method_YB("FlipLayoutAxes", "", "对称轴翻转", "", ref isFlipLayoutAxes,() =>
                    {
                        MyCreate.Box(() =>
                        {
                            MyCreate.Box_Hei(() =>
                            {
                                m_Tools.Text4_BW("RectTransform", "第 1 参数","bool","第 2 参数 没卵用，就填 false");
                                m_Tools.TextText_BW("bool", "第 3参数 true :子RectTransform 也会翻转");
                            });
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711132143572-1821150100.png");
                        });
                    },50);
                m_Tools.Method_YB("FlipLayoutOnAxis", "", "水平或垂直轴翻转" , "",ref isFlipLayoutOnAxis, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text4_BW("RectTransform", "第 1 参数","bool","第 3 参数 没卵用，就填 false");

                            m_Tools.TextText_BW("int", "第 2 参数 水平是0  垂直是1");
                            m_Tools.TextText_BW("bool", "第 3 参数 true :子RectTransform 也会翻转");

                        });
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711131320360-877927497.png");
                    });
                }, 50);
                MyCreate.Text("转换".AddGreen());
                m_Tools.Method_YB("ScreenPointToLocalPointInRectangle", "...out Vector2", "将 屏幕点 转换 UGUI 坐标", "bool", 140);
                m_Tools.Method_YB("ScreenPointToWorldPointInRectangle", "... out Vector3", "将 屏幕点 转换成 3D世界坐标", "bool", 140);
            });
            AddSpace();
            m_Tools.BiaoTi_B("使用例子：");
            MyCreate.Box(() =>
            {
                MyCreate.Text("翻转".AddGreen()+"例子：");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711131746067-842698814.png");
                AddSpace();
                MyCreate.Text("转换".AddGreen() + "(Image 跟随鼠标移动)");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Vector2 pos;");
                    m_Tools.Text_H("if(RectTransformUtility.ScreenPointToLocalPointInRectangle");
                    m_Tools.Text_H("      图的RectTransform，Input.mousePosition，相机，out pos))");
                    m_Tools.Text_H("{");
                    m_Tools.Text_H("     rectTransform.anchoredPosition = pos");
                    m_Tools.Text_H("}");
                });

            });

            
        }


        private void DrawDefaultControls()                        // DefaultControls
        {
            m_Tools.BiaoTi_B("DefaultControls  -> "+"用于创建默认的 UI 控件".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("    1. 参数都是使用"," 内部的".AddGreen(), " public struct Resources".AddHui());
                m_Tools.Text_L("    2. 返回的结果都是  ->  ","GameObject".AddGreen());
                AddSpace_3();

                m_Tools.Text4("  CreateButton".AddYellow(), " (按钮)".AddWhite(), "CreateDropdown".AddYellow(), " (下拉列表)".AddWhite(),20);
                m_Tools.Text4("  CreateImage".AddYellow(), " (图像)".AddWhite(), "CreateInputField".AddYellow(), " (输入字段)".AddWhite(),20);
                m_Tools.Text4("  CreatePanel".AddYellow(), " (面板)".AddWhite(), "CreateRawImage".AddYellow(), " (原始图像)".AddWhite(),20);
                m_Tools.Text4("  CreateScrollbar".AddYellow(), " (滚动条)".AddWhite(), "CreateScrollView".AddYellow(), " (滚动视图)".AddWhite(),20);
                m_Tools.Text4("  CreateSlider".AddYellow(), " (滑块)".AddWhite(), "CreateText".AddYellow(), " (文本对象)".AddWhite(),20);
                m_Tools.Text4("  CreateToggle".AddYellow(), " (切换)".AddWhite(),"","",20);
            });
            AddSpace();
            m_Tools.BiaoTi_B("DefaultControls.Resources");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("属性都是加 Sprite，可以忽略，只需要 new 出来即可");
            });
            AddSpace();
            m_Tools.BiaoTi_O("例子： 创建一个 UI 按钮");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public static Button CreateButton(string name,Transform parent)");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    DefaultControls.Resources".AddBlue()," resources = new"," DefaultControls.Resources();".AddBlue());
                m_Tools.Text_H("    GameObject go = DefaultControls.","CreateButton".AddYellow(),"(resources);");
                m_Tools.Text_H("    go.name = name;");
                m_Tools.Text_H("    go.transform.SetParent(parent);");
                m_Tools.Text_H("    return go.GetComponent<Button>();");
                m_Tools.Text_H("}");


            });
        }

        #endregion

        #region Canvas

        private void DrawCanvas()                                // Canvas
        {
            m_Tools.BiaoTi_B("Canvas " + "（UI 画布）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("  • 继承 Behaviour");
                m_Tools.Text_G("  • 可在 Canvas 下的子类再添加 Canvas");
            });
            AddSpace();
            m_Tools.BiaoTi_B("Render Mode  渲染模式");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Screen Space - Overlay", "叠加各画布",30);
                m_Tools.TextText_BL("Screen Space - Camera", "画布根据相机来布局",30);
                m_Tools.TextText_BL("World Space", "画布在世界空间随意",30);
            });
            AddSpace();
            m_Tools.BiaoTi_B("当 Canvas 的父对象也有 Canvas 时：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("   1. 没有 Render Mode 渲染模式");
                m_Tools.Text_L("   2. 固定有三个面板属性：");

                PixelPerfect(0);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("      本身属性类型就是 -> ","bool".AddGreen());
                    m_Tools.Text_H("      inherit","（使用父 Canvas 的设置）".AddGreen()," ,  off/on","（重写 -> false/true）".AddGreen());
                });
                m_Tools.TextText_YB("Override Sorting",OpenSure+"重写".AddGreen()+"渲染层级的顺序");
                AdditionalShader();
            });


        }

        private void DrawCanvas1()                               // 叠加各画布 
        {
            m_Tools.BiaoTi_B("Screen Space - Overlay");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. 会把所有 UI 都", "渲染在摄像机之前".AddGreen() + ",所有的 UI 一定是 2D 的");
                m_Tools.Text_H("2. ", "不受摄像机影响".AddGreen(), ",并随着分辨率改变而自适应UI布局");
                m_Tools.Text_H("3. 以 ", "SortOrder ".AddWhite(), "的顺序来", "叠加".AddGreen(), "每一个 Canvas");
            });
            AddSpace();
            m_Tools.BiaoTi_B("面板属性");
            MyCreate.Box(() =>
            {
                PixelPerfect();
                m_Tools.TextText_YB("Sort Order", "每个 Canvas 渲染层级顺序" + "(数值越大显示越靠前)".AddGreen(), -30);
            });

        }

        private void DrawCanvas2()                               // 画布根据相机来布局
        {

            m_Tools.BiaoTi_B("Screen Space - Camera");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. ", "根据摄像机".AddGreen(), "来渲染UI到画布上，UI 可以有 ", "3D 感觉".AddWhite());
                m_Tools.Text_H("2. ", "前后层级顺序".AddGreen(), "和相机有关，", "大小".AddGreen(), "与相机投影相同");
                m_Tools.Text_H("3. 子 UI 只要通过 ", "Roatation".AddWhite(), " 旋转或其他转换实行 ", "3D 感觉".AddWhite());
            });

            AddSpace();
            m_Tools.BiaoTi_B("面板属性");
            MyCreate.Box(() =>
            {
                PixelPerfect();
                m_Tools.TextText_YB("Plane Distance", "就是控制 Z 轴，距离相机多少米", -30);
                SortingLayer();
                OrderinLayer();
            });



        }


        private void DrawCanvas3()                               // 画布在世界空间随意
        {
            m_Tools.BiaoTi_B("World Space");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. ", "世界空间".AddGreen(), "的画布，画布的尺寸可以使用 ", "Rect".AddWhite(), " 变换来设置");
                m_Tools.Text_H("2. 其屏幕尺寸取决于相机的视角和距离");
                m_Tools.Text_H("3. 有时候可方便的将3D UI ", "渲染到场景对象".AddGreen(), "上");
            });
            SortingLayer();
            OrderinLayer();
        }



        private void DrawCanvasScaler()                           // CanvasScaler
        {

            m_Tools.BiaoTi_O("CanvasScaler ");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("  • 继承 UIBehaviour");
                m_Tools.Text_L("  • 画布的缩放, 控制整体比例和像素密度");
            });
            AddSpace();
        
            m_Tools.BiaoTi_B("UI Scale Mode  ->"+"  Constant Pixel Size".AddOrange(),ref isConstantPixel, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        MyCreate.Text("该模式为  ：".AddHui() + "(UI 元素始终保持固定像素大小)".AddGreen());
                    });
                    m_Tools.TextText_YB("Scale Factor", "通过改变此值" + "縮放所有元素大小".AddGreen(), 20);
                    ReferencePixeles();
                });
            });

            AddSpace();
            m_Tools.BiaoTi_B("UI Scale Mode  -> "+" Scale With Screen Size".AddOrange(),true);
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("该模式为  ：".AddHui() + "(UI 元素按屏幕大小比例缩放)".AddGreen());
                    MyCreate.Text("自适应最好：".AddHui()+"选择 Expand（UI一定全部在）,后面作一个背景".AddGreen());
                });
                m_Tools.TextText_YB("Reference Resolution", "参考的分辨率", 20);
                m_Tools.TextText_YB("Screen Match Mode", "屏幕匹配模式", 20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_LW("  Match Width or Height", "根據Width或Height進行混合縮放",-10);
                    m_Tools.TextText_LW("  Expand", "这里只会小，不够的就用相机填满" + "(Match =0)".AddGreen(), -10);
                    m_Tools.TextText_LW("  Shrink", "这里只会多，多出来的剪切掉" + "     (Match =1)".AddGreen(), -10);
                    m_Tools.TextText_YB("Match", "参考是以宽度还是高度还是混合", 20);
                    m_Tools.Text_H("  • 最右时,屏幕高度对于 UI 大小没有影响为1，而 UI 宽度则拉伸或压缩");
                    m_Tools.Text_H("  • 反之最左时,宽度不变，高度会拉伸或压缩");
                    m_Tools.Text_H("  • 处于中间某处时，对上述两者的影响进行权重加成");

                });
                ReferencePixeles();


            });
            AddSpace();
            m_Tools.BiaoTi_B("UI Scale Mode  -> "+" Constant Physical Size".AddOrange(),ref isCPhysical, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Text("该模式为  ：".AddHui() + "(不变的物理尺寸)".AddGreen());
                    MyCreate.Text("用个蛋这个，不用看".AddGreen());
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("UI Scale Mode  -> " + " World".AddOrange(), ref isWorld, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Text("该模式为  ：".AddHui() + "(按如3D物体在世界比例)".AddGreen());
                    MyCreate.Text("渲染模式是 World Space 时，规定只能使用这个".AddGreen());
                });
                m_Tools.TextText_YB("Dynamic Pixels Per Unit", "如文字模糊，提高该值就变清晰", 20);
                ReferencePixeles();
            });

        }


        private void DrawGraphicRaycaster()                      // GraphicRaycaster
        {
            m_Tools.BiaoTi_B("GraphicRaycaster " + "（图形射线检测）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L(" • 继承 UIBehaviour");
                m_Tools.Text_L(" • 如果没有，这个对象下的所有 可交互组件 都不能交互了");
            });
            AddSpace();
            m_Tools.BiaoTi_B("面板属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_YB("Ignore Reversed Graphics", OpenSure + "反转或反向的渲染事件是忽略");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_W("     如：UI Rect Transform 的Rotation Y轴 为180，这时UI反转了");
                    m_Tools.Text_W("        打勾：没有输入事件");
                    m_Tools.Text_W("        不勾：有输入事件");
                });

                AddSpace_3();

                m_Tools.TextText_YB("Blocking Mask", "渲染屏蔽的layer层级", 43);

            });

        }


        #endregion


        #region 图像组件

        private void DrawText()                                  // Text
        {
            m_Tools.BiaoTi_O("Text  (文字)");
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                MyCreate.FenGeXian("  打开电脑字体库   ", () =>
                {
                    Application.OpenURL("C:/Windows/Fonts");
                });

            });
            m_Tools.BiaoTi_B("Character " + "（字符）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text4_HW("Font", "字体", "FontStyle", "字体样式");
                m_Tools.Text4_HW("FontSize", "字体大小", "RichText", "能否使用富文本");
                m_Tools.TextText_BL("Line Spacing", "行间距".AddGreen() + ",一行与一行之间的分隔");
            });
            AddSpace();
            m_Tools.BiaoTi_B("Paragraph " + "（段落）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Align by Geometry", OpenSure + "按几何对齐(小范围调整)", -40);
                m_Tools.TextText_BL("Horizontal Overflow", "水平字太多：" + "Wrap(下一行),".AddGreen() + "Overflow(超过矩形)".AddGreen(), -40);
                m_Tools.TextText_BL("Vertical Overflow", "垂直字太多:" + "Truncate(截断),".AddGreen() + "Overflow(超过矩形)".AddGreen(), -40);
                m_Tools.TextText_BL("Best Fit", "忽略Font Size".AddGreen() + "，字体自动调整字体大小适应矩形", -40);

            });

            ThreeTheSame();

        }

        private void DrawImage()                                 // Image
        {
            m_Tools.BiaoTi_B("Image" + "(图像，纹理只能 Sprite，能动画，能控)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Simple", "简单 " + "Presrve Aspect：保证宽高比例与原图相同".AddGreen());
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711132749323-445787777.png");
                m_Tools.TextText_OY("Sliced", "按九宫格的切法");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711133350295-1168446541.png");
                m_Tools.TextText_OY("Tiled", "图一定是原图大小，少剪切，多增加一张图");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711133539568-1759027133.png");
                m_Tools.TextText_OY("Filled", "按比例来填充", ref isFilled, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText("Fill m_Tools.Method_OY", "填充的方法");
                        m_Tools.TextText("Fill Origin", "填充的超启点");
                        m_Tools.TextText("Fill Amount", "填充的量");
                        m_Tools.TextText("Clock wise", "是否为顺时针");
                        m_Tools.TextText("Presrve Aspect", "保证宽高比例与原图相同");
                    });
                });
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711133624109-306795319.png");
            });

            ThreeTheSame();

        }

        private void DrawRawImage()                              // RawImage
        {
            m_Tools.Text_B("Raw Image" + "非交互图像，接受任何纹理");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("1.不能通过Animator改变图片，只能程序");
                m_Tools.Text_G("2.Animator只能改变颜色、UV Rect、Rect Transform");
                m_Tools.Text_G("3.常用背景图、图标和从URL下载的图像");
                m_Tools.TextText("UV Rect", "图像在控制矩形内的偏移和大小");
            });
            ThreeTheSame();
        }

        private void DrawMask()                                  // Mask
        {
            m_Tools.BiaoTi_B("Mask" + "以父图片遮挡子 UI".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("• 继承 UIBehaviour");
                m_Tools.Text_L("• 一定是用在 图像组件 的", "父 GameObject（带 Image）".AddGreen(),"上");


            });
            AddSpace();
            m_Tools.BiaoTi_B("面板属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("Show Mask Graphic");

                m_Tools.Text_W("    勾选了 -> 以父图片为主，子图片剪切");
                m_Tools.Text_W("    没勾选 -> 只取" + "重叠".AddGreen() + "的部分");
            });
        }



        private void DrawEffects()                               // Effects
        {
            m_Tools.BiaoTi_B("UI -> Effects -> "+"为 图像组件 增加效果".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_YL("Shadow", "加阴影 ");
                m_Tools.TextText_YL("Outline", "加边框（描边）");
                m_Tools.TextText_YL("Position As UV1", "改变 UV 位置");
                m_Tools.TextText_YL("渐变", "上部分一种颜色，下部分另一种颜色");
            });
            AddSpace();
            m_Tools.BiaoTi_L("渐变 简单代码");
            MyCreate.Box(() =>
            {
                
                m_Tools.Text_H("1. 继承 ","BaseMeshEffect".AddWhite());
                m_Tools.Text_H("2. 重写 public override void ModifyMesh(","VertexHelper".AddWhite()," vh)");
                m_Tools.Text_H("3. 收集 这个 UI 所有顶点：");
                m_Tools.Text_H("      List<","UIVertex".AddWhite(),"> vertexList = new List<","UIVertex".AddWhite(),">();");
                m_Tools.Text_H("      vh.GetUIVertexStream(vertexList);");

                m_Tools.Text_H("4. 然后对其高深运算....");

                m_Tools.Text_H("5. 清理原来的，用最新的定义的顶点集合");
                m_Tools.Text_H("      vh.Clear();");
                m_Tools.Text_H("      vh.AddUIVertexTriangleStream(vertexList);");
            });

        }

        #endregion

        #region 可交互组件


        private void DrawButton()                                // Button
        {
            m_Tools.BiaoTi_Y("Button  " + "（按钮）".AddGreen());
            BaseInteractible();
            m_Tools.BiaoTi_O("Button 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LH("OnClick()", "点击按钮的回调事件", -20);
            });

        }

        private void DrawDropdown()                              // Dropdown
        {
            m_Tools.BiaoTi_Y("Dropdown " + "(从下拉列表中选择一个选项)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("每个选项，可以", "指定文本字符串".AddGreen(), "，也可以", "指定图像".AddGreen());

            });
            BaseInteractible();
            m_Tools.BiaoTi_O("Dropdown 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Template", "下拉列表以那个作为模版", -20);
                m_Tools.TextText_LW("Caption Text", "显示的标题".AddGreen() + "用的 Text 引用", -20);
                m_Tools.TextText_LW("Caption Image", "显示的标题用的 Image 引用", -20);
                m_Tools.TextText_LW("Item Text", "每个下拉列表".AddGreen() + "用的 Text 引用", -20);
                m_Tools.TextText_LW("Item Image", "每个下拉列表用的 Image 引用", -20);
                m_Tools.TextText_LW("Value", "值".AddGreen() + " (从0开始)", -20);
                m_Tools.TextText_LW("Options", "要添加的选项".AddGreen() + "就在这里添加", -20);
                m_Tools.TextText_LH("OnValueChange(int)", "当值发生改变的回调事件", -20);
            });


        }

        private void DrawToggle()                                // Toggle
        {
            m_Tools.BiaoTi_Y("Toggle  " + "（一个选项对还是错）".AddGreen());
            MyCreate.Box(() =>
            {
                BaseInteractible();
                m_Tools.BiaoTi_O("Toggle 自带的属性");
                m_Tools.TextText_LW("Is On", "这个选项对还是错", -20);
                m_Tools.TextText_LW("Toggle Transition", "切换动画：" + "None".AddLightBlue() + "：没有，" + "Fade".AddLightBlue() + "：淡入或淡出", -20);
                m_Tools.TextText_LW("Graphic", "打勾的框".AddGreen() + "引用那个 可视化图像", -20);
                m_Tools.TextText_LW("Group", "如果" + "使用 ToggleGroup".AddGreen() + "，需要拖进这里", -20);
                m_Tools.TextText_LH("OnValueChange(bool)", "当值发生改变的回调事件", -20);

            });
        }

        private void DrawSlider()                                // Slider
        {
            MyCreate.Heng(() =>
            {
                m_Tools.BiaoTi_Y("Slider " + "(用于选择数值)".AddGreen());
                MyCreate.Shu(() =>
                {
                    MyCreate.AddSpace(10);
                    m_ShowBool = GUILayout.HorizontalSlider(m_ShowBool, 0, 5);
                });
                MyCreate.AddSpace(10);

                MyCreate.Shu(() =>
                {
                    MyCreate.AddSpace(6);
                    MyCreate.Text("底图+滑轮图+(滑轮值大过的区域的图)");

                });
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Slider：    拖动以改变", "目标点的值".AddGreen());
                m_Tools.Text_H("Scrollbar：拖动以改变", "整体目标百分比比例".AddGreen());
            });
            BaseInteractible();
            m_Tools.BiaoTi_O("Slider 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Fill Rect", "填充过区域的图" + "引用".AddHui());
                m_Tools.TextText_LW("Handle Rect", "滑轮图" + "引用".AddHui());
                m_Tools.TextText_LW("Direction", "方向".AddGreen() + " 左到右 还是 上到下");
                m_Tools.TextText_LW("Min Value", "最小值");
                m_Tools.TextText_LW("Max  Value", "最大值");
                m_Tools.TextText_LW("Whole Numbers", "是否" + "限制为整数值".AddGreen());
                m_Tools.TextText_LW("Value", "选择的数值");
                m_Tools.TextText_LH("OnValueChanged(float)", "当值发生改变的回调事件");
            });


        }

        private void DrawInputField()                            // InputField
        {

            m_Tools.BiaoTi_Y("InputField " + "(输入框)".AddGreen());
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/script-InputField.html");
            BaseInteractible();
            m_Tools.BiaoTi_O("InputField 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Text Component", "Text引用"+"(默认)".AddLightGreen(), -20);
                m_Tools.TextText_LW("Text", "显示的文字", -20);
                m_Tools.TextText_LW("Character Limit", "字符限制" + "(最多可以输入多少个字)".AddGreen(), -20);
                m_Tools.TextText_LW("Content Type", "内容类型", -20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_BY("Standard"+ "(标准)".AddHui(), "可输入任何字符");
                    m_Tools.TextText_BY("Autocorrected"+ "(自动校正)".AddHui(), "如未知字符自动替换");
                    m_Tools.TextText_BY("Integer Number"+ "(整数)".AddHui(), "仅允许整数输入");
                    m_Tools.TextText_BY("Decimal Number"+ "(十进制)".AddHui(), "只允许数字和单个小数点");
                    m_Tools.TextText_BY("Alphanumeric"+ "(字母数字)".AddHui(), "允许字母和数字。不能输入符号");
                    m_Tools.TextText_BY("Name"+"(名)".AddHui(), "英文首字母大写");
                    m_Tools.TextText_BY("Email Address" + "(电子邮件)".AddHui(), "由 @ 和数字组成");
                    m_Tools.TextText_BY("Password" + "(密码)".AddHui(), "用星号标出，仅允许整数仅被输入");
                    m_Tools.TextText_BY("Pin" + "(整数密码)".AddHui(), "用星号标出，仅允许整数仅被输入");
                    m_Tools.TextText_BY("Custom" + "(自定义)".AddHui(), "自己定制");
                });
                m_Tools.TextText_LW("   Line Type", "行类型", -20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_BY("Single Line" + "(单行)".AddHui(), "仅允许一行");
                    m_Tools.TextText_BY("Multi Line Submit" + "(多行提交)".AddHui(), "允许多行，按回车键 "+"确定".AddGreen());
                    m_Tools.TextText_BY("Multi Line Newline" + "(多行换行)".AddHui(), "允许多行，按回车键 "+"换行".AddGreen());

                });
                m_Tools.TextText_LW("Placeholder", "没输入内容时显示的Text 引用", -20);
                m_Tools.TextText_LW("Caret Blink Rate", "标记线的闪烁 速率", -20);
                m_Tools.TextText_LW("Caret Width", "标记线闪烁 宽度", -20);
                m_Tools.TextText_LW("Custom Caret Color", "自定义标记线颜色", -20);
                m_Tools.TextText_LW("Selection Color", "选取文本的部分对应颜色", -20);
                m_Tools.TextText_LW("Hide Moblie Input",OpenSure + "隐藏的本地输入" + "(只适用IOS)".AddGreen(), -20);
                m_Tools.TextText_LW("Read Only",OpenSure+ "只可读", -20);
                m_Tools.TextText_LH("OnValueChange(string)", "当值发生改变的回调事件", -20);
                m_Tools.TextText_LH("OnEndEdit(string)", "当按下回车键或输入字段失去焦点的回调事件", -20);
            });

        }

        private void DrawScrollbar()                             // Scrollbar
        {

            m_Tools.BiaoTi_Y("Scrollbar  " + "（滚动条）".AddGreen() + " 底图+上层填充图");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Slider：    拖动以改变", "目标点的值".AddGreen());
                m_Tools.Text_H("Scrollbar：拖动以改变", "整体目标百分比比例".AddGreen());
            });
            BaseInteractible();
            m_Tools.BiaoTi_O("Scrollbar 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Handle Rect", "上层填充图" + "引用".AddHui());
                m_Tools.TextText_LW("Direction", "方向".AddGreen() + " 左到右 还是 上到下");
                m_Tools.TextText_LW("Value", "滚动条的值");
                m_Tools.TextText_LW("Size", "滚动条（上层填充图）的" + "尺寸".AddGreen());
                m_Tools.TextText_LW("Number Of Steps", "滚动条可以" + "滚动多少格".AddGreen());
                m_Tools.TextText_LH("OnValueChanged(float)", "当值发生改变的回调事件");
            });
        }

        #endregion

        #region LayoutGroup


        private void DrawVerticalLayoutGroup()                   // VerticalLayoutGroup
        {

            m_Tools.BiaoTi_O("HorizontalOrVerticalLayoutGroup 继承 LayoutGroup");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("VerticalLayoutGroup".AddYellow(), "      相当于 Heng 布局");
                m_Tools.Text_L("HorizontalLayoutGroup".AddYellow(), "   相当于 Shu 布局");
                m_Tools.Text_H("两个都继承于 HorizontalOrVerticalLayoutGroup，属性都相同");
            });
            AddSpace_15();
            TheSame();
            m_Tools.BiaoTi_O("自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Spacing", "每个 Item ".AddGreen() + "之间的距离" + "(相当于 AddSpace)".AddWhite(), -30);
                m_Tools.TextText_BL("Child Controls Size", "控制子 UI " + "大小".AddGreen(), -30);
                m_Tools.TextText_BL("Child Force Expand", "是否使子 UI " + "填满".AddGreen() + "所有空间" + " (不勾按图片大小)".AddWhite(), -30);
            });
            AddSpace();
            m_Tools.BiaoTi_O("子UI 可加 " + "LayoutElement".AddYellow() + " 修改自己大小 或 不受控制");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("当父 UI 很小时，子 UI 也会跟着父 UI 变小");
                m_Tools.Text_H(" 所有要修改它就修改 Min Width/Height");
                MyCreate.Text("当 Child Force Expand 没勾选时，子UI 是按图片的大小");
                m_Tools.Text_H(" 所有要修改它就修改 Perferred Width/Height");
                MyCreate.Text("当 Child Force Expand 勾选时，子UI 最大会直接填满父UI");
                m_Tools.Text_H(" 所有要修改它就修改 Flexible Width/Height");
            });

            m_Tools.BiaoTi_B("代码刷新布局");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L(" LayoutRebuilder.ForceRebuildLayoutImmediate( RectTransform... );");
            });

        }

        private void DrawGridLayoutGroup()                       // GridLayoutGroup
        {
            m_Tools.BiaoTi_Y("GridLayoutGroup  " + "( 控制子UI使用 Grid 布局)".AddGreen());
            TheSame();
            m_Tools.BiaoTi_O("GridLayoutGroup 自带的属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Cell Size", "每个 Item".AddGreen() + " 的大小", -30);
                m_Tools.TextText_BL("Spacing", "每个 Item ".AddGreen() + "之间的距离", -30);
                m_Tools.TextText_BL("Start Corner", "第一个 Item ".AddGreen() + "所在位置" + "(左上 还是 右下)".AddWhite(), -30);
                m_Tools.TextText_BL("Start Axisr", "之后的 Itme ".AddGreen() + "向那个方向" + "(水平走 还是 垂直走)".AddWhite(), -30);
                m_Tools.TextText_BL("Constraint", "约束", -30);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_LW("   Flexible", "自动");
                    m_Tools.TextText_LW("   Column", "根据列的数量");
                    m_Tools.TextText_LW("   Row", "根据行的数量");
                });
                m_Tools.Text_G("加上 " + "ContentSizeFitter".AddBlue());
            });
            AddSpace();
            m_Tools.BiaoTi_O("通常会添加 ContentSizeFitter " + "(自己大小按所有子UI控制)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("都设置成 Preferred Size 匹配成所有子UI大小");

            });

        }

        #endregion


        #region 接口事件

        private void DrawJieKouEvent()                           // 接口事件
        {
            AddSearch(ref m_Input, l_AllTextAttribute, null);
            m_Tools.BiaoTi_O("鼠标进入、退出");
            ShowItem(l_EnterAndOut);
            m_Tools.BiaoTi_O("鼠标点击");
            ShowItem(l_Click);
            m_Tools.BiaoTi_O("鼠标拖动");
            ShowItem(l_Drag);
            m_Tools.BiaoTi_O("鼠标中间滚动");
            ShowItem(l_Scroll);
            m_Tools.BiaoTi_O("高亮UI");
            ShowItem(l_Highlighted);
            m_Tools.BiaoTi_O("键盘");
            ShowItem(l_Keyboard);


        }


        private void DrawXiangGuang()                            // 接口事件相关
        {
            m_Tools.BiaoTi_B("除了下面的方法 其他的都带 " + "PointerEventData".AddOrange() + " 参数");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("这里的都是关于 鼠标 的操作");
            });
            m_Tools.BiaoTi_B("方法参数带 " + "BaseEventData".AddOrange() + " 的有：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_BH("IUpdateSelectedHandler", "只要有高亮的UI（一直调用）");
                m_Tools.TextText_BH("ISelectHandler", "当这个UI成为高亮");
                m_Tools.TextText_BH("IDeselectHandler", "当这个UI取消高亮");
                m_Tools.TextText_BH("ISubmitHandler", "键盘按下回车(只在可交互组件触发)");
                m_Tools.TextText_BH("ICancelHandler", "键盘按下Esc(只在可交互组件触发)");
            });
            m_Tools.BiaoTi_B("方法参数带" + " AxisEventData".AddOrange() + " 的有：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_BH("IMoveHandler", "键盘按（上，下，左，右）");
            });
            AddSpace();
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("PointerEventData");
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/EventSystems.PointerEventData.html", "还有很多属性");
                m_Tools.Method_LY("position", "", "当前的指针位置", "Vector2", -10);
            });
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("BaseEventData");
                m_Tools.Method_LW("currentInputModule", "", "当前的输入模块的详细信息", "BaseInputModule", -10);
                m_Tools.Method_LW("selectedObject", "", "当前高亮的物体，没有返回Null", "GameObject", -10);
            });
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("AxisEventData");

            });
            AddSpace();
            m_Tools.BiaoTi_Y("补充说明");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text("1.UI组件要有 " + "Raycast Target".AddGreen() + " 并勾选才能触发接口事件");
                m_Tools.Text("2.检测是否有可交互的组件存在：");
                m_Tools.Text_H("     Graphic g = GetComponent<Graphic>(); ");
                m_Tools.Text_H("     g == null ？");
            });
        }



        private void DrawOther()                                 // 使用EventTrigger
        {
            m_Tools.BiaoTi_B("EventTrigger 使用说明：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. 向 GameObject 添加 EventTrigger 组件");
                m_Tools.Text_H("2. 选择以下一个 EventTriggerType 类型作为触发条件");
                MyCreate.Box(() =>
                {
                    m_Tools.Text4_BW("PointerEnter", "鼠标进入", "PointerExit", "鼠标离开", 40);
                    m_Tools.Text4_BW("PointerDown", "鼠标按下", "PointerUp", "鼠标放开（可不在UI上）", 40);
                    m_Tools.Text4_BW("PointerClick", "鼠标点击", "Drag", "", 40);
                    m_Tools.Text4_BW("Drop", "", "Scroll", "", 40);
                    m_Tools.Text4_BW("UpdateSelected", "", "Select", "", 40);
                    m_Tools.Text4_BW("Deselect", "", "Move", "", 40);
                    m_Tools.Text4_BW("InitializePotentialDrag", "", "BeginDrag", "", 40);
                    m_Tools.Text4_BW("EndDrag", "", "", "", 40);
                    m_Tools.Text4_BW("Submit", "", "Cancel", "", 40);
                });
                m_Tools.Text_H("3. 把方法拖进去即可");

            });





        }


        private void DrawEventSystem()                           // EventSystem
        {
            m_Tools.BiaoTi_B("Event System " + "(事件系统管理器)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("First Selected", "首先选中的GameObject");
                m_Tools.TextText_BL("Send Navigation Events", "是否允许发送导航事件（移动/提交/取消）");
                m_Tools.TextText_BL("Drag Threshold", "拖拽像素的阈值");
            });
            AddSpace_15();
            m_Tools.BiaoTi_B("Standalone Input Module " + "(独立输入模块)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Horizontal Axis", "输入水平轴名称", 20);
                m_Tools.TextText_LW("Vertical Axis", "输入垂直轴名称", 20);
                m_Tools.TextText_LW("Submit Button", "提交按钮名称", 20);
                m_Tools.TextText_LW("Cancel Button", "取消按钮名称", 20);
                m_Tools.TextText_LW("Input Actions Per Second", "每秒允许的键盘/控制器输入数量", 20);
                m_Tools.TextText_LW("Repeat Delay", "重复输入的操作延迟多少秒", 20);
                m_Tools.TextText_LW("Force Module Active", "强制该模块处于活动状态", 20);
            });
            AddSpace_15();
            m_Tools.BiaoTi_L("Touch Input Module 触摸输入模块" + "(已经过时)".AddGreen(), ref isTouch, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("TouchInputModule 已经过时,该模块已集成在Standalone Input Module");
                    m_Tools.TextText_BW("Force Module Active", "强制该模块处于活动状态");
                });

            });

        }

        #endregion

        #region 其他

        private void DrawContentSizeFitter()                   // ContentSizeFitter
        {
            m_Tools.BiaoTi_B("ContentSizeFitter"+" ( 内容 尺寸 钳住 )".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("子UI 多大，这个UI就有多大");
                MyCreate.Text("提示：");
                m_Tools.Text_H("Parent has a type of layout group component，A child of a layout");
                m_Tools.Text_H("    group should not have a Content Size Fitter component，since it");
                m_Tools.Text_H("    should be driven by the layout group");
                MyCreate.Text("翻译：");
                m_Tools.Text_L("父UI 有一种布局组件，布局组的子级不应该用这个组件，因为它应该由布局组驱动");

            });

        }


        private void DrawScrollView()                          // ScrollView 组合
        {

        }



        #endregion

    }

}

