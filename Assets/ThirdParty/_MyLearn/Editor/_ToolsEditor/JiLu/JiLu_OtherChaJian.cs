using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class JiLu_OtherChaJian : AbstactNewKuang
    {

        [MenuItem(LearnMenu.OtherChaJian)]
        static void Init()
        {
            JiLu_OtherChaJian instance = GetWindow<JiLu_OtherChaJian>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {

            #region EasyTouch

            bool isShiPing = (type == EType.EasyTouch || type == EType.EasyTouch1 || type == EType.EasyTouch2 || type == EType.EasyTouch3 || type == EType.EasyTouch4 || type == EType.EasyTouch5 || type == EType.EasyTouch22 || type == EType.ET);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "EasyTouch";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.EasyTouch ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.EasyTouch);
            }

            if (isShiPing)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ET ? "       总结".AddBlue() : "       总结");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ET);
                }

                MyCreate.Text("无界面");
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch1 ? "  QuickOnClick".AddBlue() : "  QuickOnClick");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch2 ? "  Gesture 字段".AddBlue() : "  Gesture 字段");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch22 ? "  Gesture 方法".AddBlue() : "  Gesture 方法");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch22);
                }

                MyCreate.Text("有界面");

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch3 ? "  ETCJoystick".AddBlue() : "  ETCJoystick");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch4 ? "  ETCDPad".AddBlue() : "  ETCDPad");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasyTouch5 ? "  ETCTouchPad".AddBlue() : "  ETCTouchPad");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasyTouch5);
                }
            }

            #endregion

            AddSpace();

            #region Uniwebview


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Uniwebview";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Uniwebview ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Uniwebview);
            }

            #endregion

            AddSpace();

            #region Zip 压缩


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Zip 压缩";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Zip ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Zip);
            }
            #endregion

            AddSpace();


            #region Destory2D


            bool isAC = type == EType.Destory2D || type == EType.AC1 || type == EType.AC2;

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "破坏2D";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Destory2D ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.AC1);
            }
            if (isAC)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AC1 ? "     文档翻译".AddBlue() : "     文档翻译");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AC1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AC2 ? "     破坏的原理".AddBlue() : "     破坏的原理");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AC2);
                }
            }
            #endregion


            #region EasySave


            bool isEasySave = type == EType.EasySave || type == EType.EasySave2 || type == EType.EasySave3;

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "EasySave";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isEasySave ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.EasySave);
            }
            if (isEasySave)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasySave ? "使用".AddBlue() : "使用");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasySave);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasySave2 ? "核心类 ES3 ".AddBlue() : "核心类 ES3");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasySave2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.EasySave3 ? "ES3Settings 设置 ".AddBlue() : "ES3Settings 设置");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.EasySave3);
                }
            }
            #endregion



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.EasyTouch:    DrawRightPage1(DrawEasyTouch);    break;
                case EType.ET:           DrawRightPage8(DrawET);           break;
                case EType.EasyTouch1:   DrawRightPage3(DrawQuickTap);     break;
                case EType.EasyTouch2:   DrawRightPage4(DrawGesture);      break;
                case EType.Uniwebview:   DrawRightPage5(DrawUniwebview);   break;
                case EType.EasyTouch22:  DrawRightPage6(DrawGesture2);     break;
                case EType.Zip:          DrawRightPage6(DrawZip);          break;
                case EType.AC1:          DrawRightPage5(DrawAC1);          break;
                case EType.AC2:          DrawRightPage5(DrawDestroy);      break;
                case EType.EasySave:     DrawRightPage6(DrawEasySave);     break;
                case EType.EasySave2:    DrawRightPage6(DrawDrawEasySave2);break;
                case EType.EasySave3:    DrawRightPage3(DrawDrawEasySave3);break;


            }

        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Uniwebview:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                case EType.EasyTouch22:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                case EType.EasySave2:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
            }
        }



        #region 私有


        private bool _isOne, _isShow;
        private static readonly string CUBE = "Cube".AddWhite();
        private static readonly string QuickOnClick = "QuickOnClick".AddYellow();
        private static readonly string OneOrTwo = "单击或双击 ".AddGreen();

        private enum EType
        {
            EasyTouch, EasyTouch1, EasyTouch2, EasyTouch22, EasyTouch3, EasyTouch4, EasyTouch5,ET,
            Uniwebview,
            Zip,
            Destory2D,AC1,AC2,
            EasySave, EasySave2, EasySave3,

        }

        private EType type = EType.EasySave;

        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }

        }



        protected override string Tittle()
        {
            return "其他插件";
        }


        #endregion


        #region EasyTouch

        private void DrawET()                                         // 总结
        {
            m_Tools.BiaoTi_B("第一步：先添加功能到对应的"+"(添加了就要对应功能)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("可3D物体 也可UI".AddGreen());
                m_Tools.TextText_BY("   ET_Drag", "拖拽");
                m_Tools.TextText_BY("   ET_EnterGoExit", "进入、经过、离开");
                m_Tools.TextText_BY("   ET_HuaDong", "屏幕滑动");
                m_Tools.TextText_BY("   ET_OnClick", "点击、双击");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("EasyTouch.AddOnOneClick", "单击", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnDoubleClick", "双击", 80);
                });
                m_Tools.TextText_BY("   ET_OnLongClick", "长点击");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("EasyTouch.AddOnLongClickStart", "长点击的开始  1", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnLongClickProgress", "长点击进行中  n", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnLongClickEnd", "长点击结束  1", 80);
                });
                m_Tools.TextText_BY("   ET_OnTouch", "接触");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("EasyTouch.AddOnTouchStart", "接触开始  1", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnTouchDown", "接触时  n", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnTouchUp_Over", "离开时在原物体上方  1", 80);
                    m_Tools.TextText_HL("EasyTouch.AddOnTouchUp_NoOver", "离开时不在原物体上方  1", 80);
                });
                m_Tools.TextText_BY("   ET_Pinch", "双指缩放");
                m_Tools.TextText_BY("   ET_Twist", "双指旋转、扭、拧");
                MyCreate.Text("直接添加在一个空对象即可".AddGreen());
                m_Tools.TextText_BY("   ET_Trail", "拖尾");
            });
            m_Tools.BiaoTi_B("第二步：要作回调的就使用 EasyTouch.XXX 添加回调");

        }


        private void DrawEasyTouch()                                 // EasyTouch
        {

            m_Tools.BiaoTi_O("注意一下");
            MyCreate.Box(() =>
            {

                MyCreate.Text("• Down 与 Pressed 区别".AddYellow());
                m_Tools.TextText_YL("  Down", "一直按着，只调用按下那一次",-20);
                m_Tools.TextText_YL("  Pressed", "一直按着，一直调用", -20);
                AddSpace();
                MyCreate.Text("• 下面 有界面 与 无界面 分别使用不同类的".AddYellow());


            });
            AddSpace_3();
            m_Tools.BiaoTi_B("无界面的 ->"+"(如 一个手指，二个手指，拖物体，划场景)");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("核心类： EasyTouch","（调整面板 + 调用其 Static 方法）".AddGreen());
                m_Tools.Text_L("场景中也可以", "不添加 EasyTouch".AddGreen(), " ，直接只添加以下的", "直接功能：".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("比如，想长点击 3D 物体 -> 响应事件 == 添加 QuickLongTap 脚本即可".AddHui());
                    m_Tools.Text4_B("      QuickTouch", "触摸", "QuickOnClick" + ONE, "点击，包含双击",30);
                    m_Tools.Text4_B("      QuickLongTap", "长点击", "QuickDrag" + TWO, "拖拽", 30);
                    m_Tools.Text4_B("      QuickEnterOverExist", "进入一直调用，离开就没有", "", "", 30);
                    m_Tools.Text4_B("      QuickSwipe", "整个屏幕，只要滑屏了，就调用", "", "", 30);
                    m_Tools.Text4_B("      QuickPinch", "双指缩放", "QuickTwist", "双指调整旋转", 30);


                });


            });
            AddSpace();
            m_Tools.BiaoTi_B("有界面的 ->" + "(如 摇杆、按钮)");
            MyCreate.Box(() =>
            {
                MyCreate.Text("四个好用的面板类");
                m_Tools.TextText_BL("ETCJoystick"+THREE, "摇杆", 20);
                m_Tools.TextText_BL("ETCButton", "按钮", 20);
                m_Tools.TextText_BL("ETCDPad"+FOUR, "手柄方向", 20);
                m_Tools.TextText_BL("ETCTouchPad"+FIVE, "触摸板", 20);

                AddSpace();
                MyCreate.Text("一个 Mono 单例类"+"(不需要手动添加，自动添加到场景)".AddGreen());
                m_Tools.TextText_BL("ETCInput", "输入控制",20);
            });

        }



        private void DrawQuickTap()                                  // QuickOnClick 点击、双击
        {
            m_Tools.BiaoTi_O("实现简单例子：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("放一个 ", CUBE," 在场景中，", OneOrTwo, CUBE,"  -> 变颜色");
            });
            AddSpace();
            m_Tools.BiaoTi_B("过程");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("1. 在 Cube 身上添加 ".AddLightBlue()+ QuickOnClick+ " 脚本，面板中选择".AddLightBlue()+ OneOrTwo);
                MyCreate.Text("2. 简单编写个脚本  -> 在 Start 方法中添加回调事件".AddLightBlue());
                m_Tools.Text_H("   GetComponent<", QuickOnClick,">().OnClick.AddListener(E_OnClick);");
                MyCreate.Text("3. E_OnClick 就是单击/双击的回调事件了".AddLightBlue());
                m_Tools.Text_H("   private void E_OnClick(Gesture gesture)");
                m_Tools.Text_H("   {");
                m_Tools.Text_H("      GetComponent<Renderer>().material.color = 对应颜色");
                m_Tools.Text_H("   }");

            });
            m_Tools.BiaoTi_B("唯一注意点： 回调参数是 -> " + "Gesture".AddGreen());


        }



        private void DrawGesture()                                   // Gesture 字段
        {
            m_Tools.BiaoTi_B("字段");
            MyCreate.Box(() =>
            {
                MyCreate.Text("通用：".AddOrange());
                m_Tools.Method_BY("twoFingerDistance", "", "两个手指之间的距离", "float", 0);
                m_Tools.Method_BY("actionTime", "", "这次动作的时长", "float", 0);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("   比如：QuickOnClick 点击 -> 从点击到放开的时长");
                });
                m_Tools.Method_BY("position", "", "坐标位置", "Vector2", 0);
                m_Tools.Method_BY("pickedObject", "", "目的对象", "GameObject", 0);


                MyCreate.Text("滑动和拖动的手势专用： swipe % drag".AddGreen());
                m_Tools.Method_WL("swipe", "枚举", "方向", "SwipeDirection",0);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("   None，Other，All");
                    m_Tools.Text_H("   Left，Right，Up，Down，UpLeft，UpRight，DownLeft，DownRight");
                });
                m_Tools.Method_WL("swipeLength", "", "长度", "float", 0);
                m_Tools.Method_WL("swipeVector", "", "单位方向", "Vector2", 0);


                MyCreate.Text("双指缩放的手势专用 pinch：".AddGreen());

                m_Tools.Method_WL("deltaPinch", "", "自上次更改以来的夹点长度增量", "float", 0);
                MyCreate.Text("双指 拧 手势专用 twist：".AddGreen());
                m_Tools.Method_WL("twistAngle", "", "拧 的角度", "float",0);

            });
        }



        private void DrawGesture2()                                   // Gesture 方法
        {
            m_Tools.BiaoTi_B("很有用的方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("GetTouchToWorldPoint", "float 距离 z 轴坐标", "将触摸位置转换为世界空间", "Vector3",50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    • 参数 float -> z 轴坐标，值越大，越靠近相机，越先显示");
                    m_Tools.Text_H("    • 比如用途：将其 直接 赋值给 Trail（拖尾）使用");
                });
            });

            AddSpace();
            m_Tools.BiaoTi_L("其他方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_WL("GetSwipeOrDragAngle", "", "获取滑动或拖动角度", "float", 50);
                m_Tools.Method_WL("NormalizedPosition", "", "规范化了的屏幕位置", "Vector2", 50);
                m_Tools.Method_WL("GetCurrentFirstPickedUIElement", "", "获得当前第一个点击的 UI 元素", "GameObject", 50);
                m_Tools.Method_WL("GetCurrentPickedObject", "", "获得当前第一个点击的 3D 物体", "GameObject", 50);
                m_Tools.Method_WL("Clone", "", "因为继承 ICloneable", "object", 50);

            });
        }




        #endregion


        #region Uniwebview、压缩


        private void DrawUniwebview()                              // Uniwebview
        {

            m_Tools.BiaoTi_B("Uniwebview  "+"->  浏览网页".AddGreen());
            MyCreate.Heng(() =>
            {
                m_Tools.BiaoTi_O("1. 添加包" + "(版本 2_9_1)".AddLightGreen() + " (AndroidManifest.xml 说明)".AddYellow(), ref _isOne, null);

                MyCreate.Button("导入包", () =>
                {
                    Application.OpenURL("F:/ZiLiao/使用其它插件的包");
                });

            });
            if (_isOne)
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Text("▪ 获得使用" + "网络的许可".AddGreen());
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("<uses-permission android:name=\"android.permission.INTERNET\"/>");
                    });
                    AddSpace_3();
                    MyCreate.Text("▪ 这个 activity 是" + "必须要的".AddRed());
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("<activity android:name=\"com.unity3d.player.UnityPlayerActivity\"");
                        m_Tools.Text_H("         android:label=\"@string / app_name\"");
                        m_Tools.Text_H("         android:hardwareAccelerated=\"true\">\"");
                        m_Tools.Text_G("// UniWebView 的 Web 页面和视频加速");
                        m_Tools.Text_H("    <intent-filter>");
                        m_Tools.Text_H("        ...");
                        m_Tools.Text_H("    </intent-filter>");
                        m_Tools.Text_H("        ...");
                        m_Tools.Text_H("</activity>");

                    });
                    AddSpace_3();
                    MyCreate.Text("▪ 需要额外活动: " + "（如需要 上传 一张 照片）".AddGreen() + "这个 activity 就需要");
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("<activity android:name=\"com.onevcat.uniwebview.");
                        m_Tools.Text_H("                    UniWebViewFileChooserActivity\"/>");
                        m_Tools.Text_G("// 图像文件选择器的 activity");
                    });

                    AddSpace_3();
                    MyCreate.Text("▪ 其他权限");
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_HG("ACCESS_FINE_LOCATION", "如：想使用 Web 服务的位置", 20);
                        m_Tools.TextText_HG("WRITE_EXTERNAL_STORAGE", "如：想选择或捕获照片上传", 20);
                    });
                });
            }
            else
            {
                AddSpace();
            }

            m_Tools.BiaoTi_O("2. 使用 " + "UniWebView ".AddWhite() + "组件（即可使用浏览器浏览网页）", true);
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("Insets", "", "插入网页大小" + "（默认全屏(0, 0, 0, 0)）".AddGreen(), "UniWebViewEdgeInsets", -110);
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("[ 委托 ]", () =>
            {
                m_Tools.Method_BY("OnLoadComplete+=", "UniWebView，bool 是否成功，string 错误信息", "加载完成");
            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_YL("Load", "string url", "加载网页" + "(不会显示)".AddGreen());
                m_Tools.Method_YL("Show", "4个已赋值参数", "显示", "", ref _isShow, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BL("fade = false", "");
                        m_Tools.TextText_BL("UniWebViewTransitionEdge = None", "");
                        m_Tools.TextText_BL("float = 0.4f", "");
                        m_Tools.TextText_BL("Action = null", "显示完成回调");
                    });
                });
            });




            m_Tools.BiaoTi_O("3.使用 " + "UniWebViewEdgeInsets".AddWhite() + " 类来调整浏览器大小",true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("UniWebView：Insets 属性");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("▪ 面板设置 Insets");
                    m_Tools.Text_H("▪ uniwebView.insets = new UniWebViewEdgeInsets(0, 0, 0, 0)");

                });
                MyCreate.Text("UniWebView：InsetsForScreenOreitation " + "使用自动旋转,调整大小");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("uniWebView.InsetsForScreenOreitation += (webView,方向)=>");
                    m_Tools.Text_H("{");
                    m_Tools.TextText_HG("    if (方向 == UniWebViewOrientation.Portrait)", "// 竖");
                    m_Tools.Text_H("        return new UniWebViewEdgeInsets(0, 0, 0, 0);");
                    m_Tools.Text_H("    else ...");
                    m_Tools.Text_H("}");

                });

            });


        }



        private void DrawZip()                                     // 压缩
        {
            m_Tools.TextButton_Open("打开文件夹导入dll和工具类", "F:/ZiLiao/使用其它插件的包/使用压缩包");
            m_Tools.BiaoTi_B("压缩文件和文件夹" + "(同步)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("MyZipUtil.Zip", "(string[]，string，string = null)".AddHui());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("   string[]", "文件夹路径或者文件名的集合", -50);
                    m_Tools.TextText_HL("   string", "输出压缩包的全路径", -50);
                    m_Tools.TextText_HL("   string", "压缩密码，默认不添加", -50);
                });

            });
            AddSpace_3();
            m_Tools.BiaoTi_B("解压Zip包" + "(同步)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_B(ZhongZai + "MyZipUtil.UnzipFile", "(string，string，string = null)".AddHui());
                m_Tools.Text_B(ZhongZai + "MyZipUtil.UnzipFile", "(byte[]，string，string = null)".AddHui());
                m_Tools.Text_B(ZhongZai + "MyZipUtil.UnzipFile", "(Stream，string，string = null)".AddHui());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("   string/byte[]/Stream", "Zip文件路径/字节数组输入流", -50);
                    m_Tools.TextText_HG("   string", "解压压缩包的出来路径", -50);
                    m_Tools.TextText_HG("   string", "压缩密码，默认没有", -50);
                });

            });
        }


        #endregion


        #region Destory2D


        private void DrawAC1()
        {

            m_Tools.BiaoTi_B("简单步骤");
            MyCreate.Box(() =>
            {
                MyCreate.Text("第1步 制作 Sprite");
                m_Tools.Text_L("  用到的组件是"," SpriteRenderer".AddGreen(),"，所以图片要设置成 Sprite");
                MyCreate.Text("第2步 设置可破坏");
                m_Tools.Text_L("  点击选择齿轮图标 选择可破坏");
                MyCreate.Text("第3步 相机设置");
                m_Tools.Text_L("  1. 设置成 正交");
                m_Tools.Text_L("  2. 添加 ClickToSpawn 组件");

            });

            AddSpace();
            m_Tools.BiaoTi_B("例子");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Break Off 崩解", "点击爆炸  划动分割", 10);
                m_Tools.TextText_WL("Break Through 冲击", "产生一个方块撞击另一方块", 10);
                m_Tools.TextText_WL("Breakable Eggs 易碎的鸡蛋", "扔石头砸鸡蛋"+"（碎的程度与力度有关）".AddGreen(), 10);
                m_Tools.TextText_WL("Breakable Glass 易碎玻璃", "扔石头"+"(轻不会碎，大力才会)".AddGreen(), 10);
                m_Tools.TextText_WL("Bullet Impacts 子弹影响", "(好像没用)", 10);
                m_Tools.TextText_WL("Car Damage 汽车危险", "汽车碰撞", 10);
                m_Tools.TextText_WL("Compound Spaceship 复合太空飞船", "飞船爆炸后像悬浮一样", 10);
                m_Tools.TextText_WL("Explode 爆炸", "点击一个物体马上四分五裂", 10);
                m_Tools.TextText_WL("Glacier 冰川", "小太阳融化冰川", 10);
                m_Tools.TextText_WL("Heal Damage 治愈伤害", "物体怎么破坏、分割都能修复", 10);
                m_Tools.TextText_WL("Huge Map 巨大的地图", "可移动",10);
                m_Tools.TextText_WG("Multi Layer 多层", "(鱼皮 鱼肉 鱼骨)", 10);
                m_Tools.TextText_WL("Shooting Gallery 射击馆", "射击小游戏",10);
                m_Tools.TextText_WL("Spaceship 飞船", "飞船射击(好完整)", 10);
                m_Tools.TextText_WL("Swinging Weight", "摆动重量", 10);
            });
        }


        private void DrawDestroy()                            // 破坏原理
        {

            m_Tools.BiaoTi_B("工作方式");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("1. 存储 Sprite 的原始纹理 和 alpha（透明度）的数据");
                m_Tools.Text_L("2. 破坏时  -> 减小 alpha 的数据");
                
                ShowImage("https://img2018.cnblogs.com/blog/959112/201809/959112-20180923145238704-1464093031.png");
            });

            AddSpace();
            m_Tools.BiaoTi_B("关于添加");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("把图片直接拖入场景产生 SpriteRenderer，右上点击“制作可破坏对象”");
                MyCreate.Text("选项的差别：");
                m_Tools.Text_B("1. 制作成可破坏对象"+"(没刚体，没碰撞体)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("D2dDestructible、MeshFilter、MeshRenderer、Sorter");

                });

                m_Tools.Text_B("1. 制作成可破坏对象(有刚体、有碰撞体)");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("D2dDestructible、MeshFilter、MeshRenderer、Sorter");
                    m_Tools.Text_Y("+  D2dPolygonCollider  会碰撞");
                    m_Tools.Text_Y("+  Rigidbody2D   刚体 2D 会下落");


                });




                m_Tools.Text_B("2. 制作成可破坏对象(动态可拆分)");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("D2dDestructible、MeshFilter、MeshRenderer、Sorter");
                    
                    m_Tools.Text_Y("+ D2dPolygonCollider");
                });




            });

        }


        #endregion

        #region EasySave

        private void DrawEasySave()
        {
            m_Tools.BiaoTi_B("入门指南"+ "(基本保存和加载)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("Easy Save将数据存储为键和值，就像字典一样");
                m_Tools.TextText_BW("要保存值 ->", "ES3.Save<T>(string key,T 值)");
                m_Tools.TextText_BW("要加载值 ->", "ES3.Load <T>(string key,T 默认值)");
            });

            m_Tools.BiaoTi_B("退出时保存"+"（在那函数调用好）");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW("PC","OnApplicationQuit");
                m_Tools.TextText_BW("移动", "OnApplicationPause（bool）");
            });

        }


        private void DrawDrawEasySave2()
        {
            m_Tools.GuangFangWenDan("https://docs.moodkie.com/easy-save-3/es3-api/es3-class/#description");

            MyCreate.FenGeXian("保存");
            m_Tools.TextText_OY("ES3.Save<T>", "object值 保存到文件中", 50);
            m_Tools.TextText_OY("ES3.SaveImage", "Texture2D 保存为图像文件", 50);
            m_Tools.TextText_HL("ES3.SaveRaw/AppendRaw", "byte[] 保存到文件中/追加", 50);
            MyCreate.FenGeXian("加载");
            m_Tools.TextText_OY("ES3.Load<T>   -> T", "从文件中获得 object值", 50);
            m_Tools.TextText_OY("ES3.LoadInto<T>", "从文件中获得值赋值到已存在的对象", 50);
            m_Tools.TextText_OY("ES3.LoadImage   -> Texture2D", "加载 JPG 或 PNG 图像文件", 50);
            m_Tools.TextText_OY("ES3.LoadAudio  -> AudioClip", "加载音频文件", 50);
            m_Tools.TextText_HL("ES3.LoadRawBytes  -> byte[]", "从文件中获得byte[]数据", 50);
            MyCreate.FenGeXian("判断是否存在");
            m_Tools.TextText_HL("ES3.KeyExists", "这个文件是否存在这个 Key", 50);
            m_Tools.TextText_HL("ES3.FileExists", "是否存在这个 文件", 50);
            m_Tools.TextText_HL("ES3.DirectoryExists", "是否存在这个 目录", 50);
            MyCreate.FenGeXian("删除");
            m_Tools.TextText_HL("ES3.DeleteKey", "删除 Key", 50);
            m_Tools.TextText_HL("ES3.DeleteFile", "删除 文件", 50);
            m_Tools.TextText_HL("ES3.DeleteDirectory", "删除 目录", 50);
            MyCreate.FenGeXian("备份");
            m_Tools.TextText_HL("ES3.CreateBackup", "备份", 50);
            m_Tools.TextText_HL("ES3.RestoreBackup", "恢复备份文件", 50);
            MyCreate.FenGeXian("密钥文件和目录的方法");
            m_Tools.TextText_HL("ES3.RenameFile", "重命名文件", 50);
            m_Tools.TextText_HL("ES3.CopyFile", "复制文件", 50);
            m_Tools.TextText_HL("ES3.GetKeys", "从文件中获取键名称数组", 50);
            m_Tools.TextText_HL("ES3.GetFiles", "目录中获取文件名的数组", 50);
            m_Tools.TextText_HL("ES3.GetDirectories", "获得所有目录名的数组", 50);
            m_Tools.TextText_HL("ES3.GetTimestamp", "获得上次更新的日期时间", 50);

        }


        private void DrawDrawEasySave3()
        {
            m_Tools.BiaoTi_B("ES3Settings 可以 new 出来，默认的在 Tools 设置");


        }


        #endregion


    }


}

