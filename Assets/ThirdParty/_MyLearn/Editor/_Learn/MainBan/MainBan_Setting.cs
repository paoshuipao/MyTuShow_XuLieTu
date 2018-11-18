using System;
using System.Collections.Generic;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;


namespace UnityEditor
{
    public class MainBan_Setting : AbstactNewKuang
    {

        [MenuItem(LearnMenu.MainBan_Setting)]
        static void Init()
        {
            MainBan_Setting instance = GetWindow<MainBan_Setting>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Console";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Log ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Log);
            }
            AddSpace_15();


            #region Build 发布设置

            MyCreate.Text("Build 发布设置");
            bool isWindow = (type == EType.PlayerWindow || type == EType.PlayerWindow1 || type == EType.PlayerWindow2);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "  Window";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.PlayerWindow ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.PlayerWindow);
            }

            if (isWindow)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PlayerWindow1 ? "     快速搜索".AddBlue() : "     快速搜索");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PlayerWindow1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PlayerWindow2 ? "     详细版".AddBlue() : "     详细版");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PlayerWindow2);
                }
            }

            AddSpace_3();

            bool isAndroid = (type == EType.PlayerAndroid || type == EType.PlayerAndroid1 || type == EType.PlayerAndroid2);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "  Android";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.PlayerAndroid ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.PlayerAndroid);
            }

            if (isAndroid)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PlayerAndroid1 ? "     快速搜索".AddBlue() : "     快速搜索");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PlayerAndroid1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PlayerAndroid2 ? "     详细版".AddBlue() : "     详细版");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PlayerAndroid2);
                }
            }


            #endregion

            AddSpace_15();

            #region Project Settings

            MyCreate.Text("Edit -> Project Settings");

            bool isProject = (type == EType.Editor || type == EType.Input || type == EType.Physics);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Project";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isProject ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Editor);
            }
            if (isAndroid)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Editor ? "     Editor".AddBlue() : "     Editor");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Editor);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Input ? "     Input".AddBlue() : "     Input");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Input);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Physics ? "     Physics".AddBlue() : "     Physics");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Physics);
                }
            }


            #endregion

            AddSpace_15();


            #region Lighting

            MyCreate.Text("Window->Lighting->Settings");
            bool isLighting = (type == EType.Lighting || type == EType.Lighting1 || type == EType.Lighting2 || type == EType.Lighting3 || type == EType.Lighting4 || type == EType.Lighting5);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "光照设置";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isLighting ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Lighting1);
            }
            if (isLighting)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lighting1 ? "Environment 环境".AddBlue() : "Environment 环境");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lighting1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lighting2 ? "Realtime/Mixed 光照".AddBlue() : "Realtime/Mixed 光照");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lighting2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lighting3 ? "Lightmapping Setting".AddBlue() : "Lightmapping Setting");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lighting3);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lighting4 ? "Other/Debug Setting".AddBlue() : "Other/Debug Setting");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lighting4);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Lighting5 ? "Global/Object maps".AddBlue() : "Global/Object maps");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Lighting5);
                }
            }
            #endregion


            AddSpace_15();

            #region Preferences

            MyCreate.Text("Edit -> Preferences");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "编辑器偏爱设置".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Preferences ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Preferences);
            }

            #endregion



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Log:  DrawRightPage8(DrawConsole); break;
                case EType.PlayerWindow: DrawRightPage1(DrawEasyWindow); break;
                case EType.PlayerWindow1: DrawRightPage1(DrawWindowEnglish); break;
                case EType.PlayerWindow2: DrawRightPage1(DrawPlayerWindow); break;
                case EType.PlayerAndroid: DrawRightPage3(DrawPlayerAndroid); break;
                case EType.PlayerAndroid1: DrawRightPage3(DrawAndroidEnglish); break;
                case EType.PlayerAndroid2: DrawRightPage3(DrawAndroid); break;
                case EType.Editor: DrawRightPage4(DrawEditor); break;
                case EType.Input: DrawRightPage5(DrawInput); break;
                case EType.Physics: DrawRightPage6(DrawPhysics); break;
                case EType.Lighting1: DrawRightPage1(DrawEnvironment); break;
                case EType.Lighting2: DrawRightPage3(DrawRealtime); break;
                case EType.Lighting3: DrawRightPage4(DrawLightmapping); break;
                case EType.Lighting4: DrawRightPage5(DrawOtherSetting); break;
                case EType.Lighting5: DrawRightPage5(Globalmaps); break;
                case EType.Preferences: DrawRightPage8(DrawPreferences); break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.PlayerWindow:
                    mWindowSettings.pageWidthExtraSpace.target = 105;
                    break;
                case EType.PlayerWindow1:
                    mWindowSettings.pageWidthExtraSpace.target = 100;
                    break;
                case EType.PlayerWindow2:
                    mWindowSettings.pageWidthExtraSpace.target = 110;
                    break;
                case EType.PlayerAndroid2:
                    mWindowSettings.pageWidthExtraSpace.target = 105;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
            }
        }


        protected override void OnInit()
        {
            base.OnInit();
            mWindowWWW = new WWW("https://github.com/paoshuipao/LearnEnglish/raw/master/WindowBuild.txt");
            mAndroidWWW = new WWW("https://github.com/paoshuipao/LearnEnglish/raw/master/AndroidBuild.txt");

        }


        #region 私有

        private WWW mWindowWWW, mAndroidWWW;
        private bool isWindowDone = false;
        private bool isAndroidDone = false;
        private readonly List<string> l_EnglishWindow = new List<string>();
        private readonly List<string> l_ChinaWindow = new List<string>();
        private readonly List<string> l_EnglishWindow2 = new List<string>();
        private readonly List<string> l_ChinaWindow2 = new List<string>();
        private string mInput;



        private static readonly string Full = " 全屏 ".AddYellow();
        private static readonly string FenBian = "分辨率".AddGreen();
        private static readonly string Mac = "Mac".AddHui();
        private static readonly string Linux = "Linux".AddHui();
        private bool isDis, isColor, isDef, isSho, isDev, isStr;

        private enum EType
        {
            PlayerWindow, PlayerWindow1, PlayerWindow2,

            PlayerAndroid, PlayerAndroid1, PlayerAndroid2,

             Editor, Input,Physics,

            Lighting, Lighting1, Lighting2, Lighting3, Lighting4, Lighting5,

            Preferences,

            Log

        }

        private EType type = EType.PlayerWindow;

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
            return "Setting 设置";
        }




        private void EnglishChina(WWW www, List<string> englishs, List<string> china, ref bool isDone)
        {
            mInput = m_Tools.TextString_Y("输入要搜索的英文", mInput);
            if (!isDone)
            {
                m_Tools.Text_R("下载中.....");
                if (www.isDone)
                {
                    string[] strArray = www.text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArray)
                    {
                        string[] eachInfo = str.Split("##".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        englishs.Add(eachInfo[0]);
                        china.Add(eachInfo[1]);
                        isDone = true;
                    }
                }
            }
            else
            {
                MyCreate.Box_Hei(() =>
                {
                    if (string.IsNullOrEmpty(mInput))
                    {
                        for (int i = 0; i < englishs.Count; i++)
                        {
                            m_Tools.TextText_WL(englishs[i], china[i], 30);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < englishs.Count; i++)
                        {
                            string eng = englishs[i];
                            string chi = china[i];
                            if (eng.IsContains(mInput, StringComparison.OrdinalIgnoreCase) || chi.IsContains(mInput, StringComparison.OrdinalIgnoreCase))
                            {
                                m_Tools.TextText_BL(eng, chi, 30);
                            }
                        }
                    }

                });
            }

        }

        #endregion



        private void DrawConsole()
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/Console.html");

            m_Tools.BiaoTi_B("控制栏");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Collapse", "true：启用折叠重复的 Log");
                m_Tools.TextText_BL("Clear on Play", "true：运行时自动清除所有 Log");
                m_Tools.TextText_BL("Error Pause", "调用了 Debug.LogError 程序会挂起");
                m_Tools.TextText_BL("Connected Player", "连接的设备");
            });


            AddSpace_15();
            m_Tools.BiaoTi_B("Open Eidtor Log");
            MyCreate.Box(() =>
            {
                m_Tools.TextSelectText_Y("查看各项占用大小", "Build Report");

            });


        }


        #region Window 发布设置


        private void DrawEasyWindow()                             // Player Window 简单版
        {
            m_Tools.BiaoTi_O("Resolution and Presentation" + "(分辨率和演示)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Default Is Full Screen", OpenSure + "默认使用" + Full, 10);
                m_Tools.TextText_BL("Default Is Native Resolution", OpenSure + "默认使用原生" + FenBian, 10);
                m_Tools.TextText_BL("Run In Background", OpenSure + "程序可以在后台运行", 10);
                m_Tools.TextText_BL("Display Resolution Dialog", "显示/禁用" + FenBian + "对话框", 49);
                m_Tools.TextText_BL("Resizable Window", OpenSure + "可调整窗口的大小", 10);
                m_Tools.TextText_BL("Visible In Background", OpenSure + "Shift + Tab 切换窗口只置后" + "(不开启：最小化)".AddGreen(), 10);
                m_Tools.TextText_BL("Allow Fullscreen Switch", OpenSure + "可以使用 " + Full + " 的按钮", 10);
                m_Tools.TextText_BL("Force Single Instance", OpenSure + "同时只允许打开一个该游戏程序", 10);
                m_Tools.TextText_BL("Supported Aspect Ratios", "支持的长宽比:" + FenBian + "对话框将提供显示器支持的" + FenBian, 49);
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Other Setting" + "(其他设置)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Scripting Runtime Version", "使用 " + "Dll".AddGreen() + " 的版本（稳定的3.5 还是试验 4.6）", 49);
                m_Tools.TextText_BL("Api Compatibility Level", "API 兼容性级别", 49);
                m_Tools.TextText_BL("Scripting Define Symbols", "定义 宏定义", 49);
                MyCreate.Text("Optimization".AddYellow() + "（优化）".AddGreen());

                m_Tools.TextText_HL("Prebake Collision Meshes", OpenSure + "生成 Mesh 的碰撞数据", 10);
                m_Tools.TextText_HL("Keep Loaded Shaders Alive", OpenSure + "加载了的 Shader 会一直保持激活的状态", 10);
                m_Tools.TextText_HL("Preloaded Assets", "在启动游戏时，会预加载的资产集合", 49);
                m_Tools.TextText_HL("Vertex Compression", "压缩顶点", 49);
                m_Tools.TextText_HL("Optimize Mesh Data", "网格数据优化(注意这里会有坑)", 49);



            });

        }


        private void DrawPlayerWindow()                          // Player Window 详细版
        {

            m_Tools.BiaoTi_O("Resolution and Presentation" + "(分辨率和演示)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("Resolution".AddYellow() + "（分辨率）".AddGreen());
                m_Tools.TextText_HL("Default Is Full Screen", OpenSure + "默认使用" + Full, 0);
                m_Tools.TextText_HL("Default IsNative Resolution", OpenSure + "默认使用原生" + FenBian, 0);
                m_Tools.TextText_HL("Mac Retina Support", OpenSure + Mac + "支持使用视网膜", 0);
                m_Tools.TextText_HL("Run In Background", OpenSure + "程序可以在后台运行", 0);
                AddSpace_3();
                MyCreate.Text("Standalone Player Options".AddYellow() + "（独立播放器选项）".AddGreen());
                m_Tools.TextText_HL("Capture Single Screen", OpenSure + "在多显示器的情况下，第二显示器会变暗", 0);
                m_Tools.TextText_HL("Display Resolution Dialog", "显示" + FenBian + "对话框", ref isDis, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BW("Disabled", "禁用", -20);
                        m_Tools.TextText_BW("Enabled", "启用", -20);
                        m_Tools.TextText_BW("Hidden by default ", "默认隐藏,在游戏开始时按“alt”键才能打开分辨率对话框", -20);
                    });
                }, 40);
                m_Tools.TextText_HL("Use Player Log", OpenSure + "使用播放器日志", 0);
                m_Tools.TextText_HL("Resizable Window", OpenSure + "可调整窗口的大小", 0);
                m_Tools.TextText_HL("Mac Fullscreen Mode", "Mac 全屏模式", 30);
                m_Tools.TextText_HL("D3D Fullscreen Mode", "D3D9 全屏模式(3D效果的选择项)", 40);
                m_Tools.TextText_HL("D3D11 Fullscreen Mode", "D3D11 全屏模式(3D效果的选择项)", 40);
                m_Tools.TextText_HL("Visible In Background", OpenSure + "Shift + Tab 切换窗口只置后" + "   不启用：".AddWhite() + "最小化", 0);
                m_Tools.TextText_HL("Allow Fullscreen Switch", OpenSure + "可以使用 " + Full + " 的按钮", 0);
                m_Tools.TextText_HL("Foce Single Instance", OpenSure + "同时只允许打开一个该游戏程序", 0);
                m_Tools.TextText_HL("Suported Aspect Ratios", "支持的长宽比:在" + FenBian + "对话框将提供显示器支持的" + FenBian, 40);

            });
            AddSpace();
            m_Tools.BiaoTi_O("Other Setting" + "(其他设置)".AddGreen());
            MyCreate.Box(() =>
            {
                WindowAndroidSame1();
                m_Tools.TextText_HL("Auto Graphics ...", OpenSure + Mac + " 自动选择图形API", 0);
                m_Tools.TextText_HL("Auto Graphics ...", OpenSure + Linux + " 自动选择图形API", 0);
                WindowAndroidSame2();
                MyCreate.Text("Mac App Store Options".AddYellow() + "（Mac 商店选项）".AddGreen());
                m_Tools.TextText_HL("Bundle Identifier", "从苹果开发者网络帐户在你的证书中使用的字符串", 40);
                m_Tools.TextText_HL("Version", "指定该包的版本号", 40);
                m_Tools.TextText_HL("Build", "该版本号的对应名称", 40);
                m_Tools.TextText_HL("Category", "类别", 40);
                m_Tools.TextText_HL("Mac App Store Validation", OpenSure + "Mac 应用商店验证", 0);

                WindowAndroidSame3();
                WindowAndroidSame4();
                WindowAndroidSame5();
                WindowAndroidSame6();
                WindowAndroidSame7();

            });

        }


        private void DrawWindowEnglish()                        // Window 快速搜索
        {
            EnglishChina(mWindowWWW, l_EnglishWindow, l_ChinaWindow, ref isWindowDone);

            /*            mInput = m_Tools.TextString_Y("输入要搜索的英文", mInput);
                        if (!isWindowDone)
                        {
                            m_Tools.Text_R("下载中.....");
                            if (mWindowWWW.isDone)
                            {
                                string[] strArray = mWindowWWW.text.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                foreach (string str in strArray)
                                {
                                    string[] eachInfo = str.Split("##".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                    l_EnglishWindow.Add(eachInfo[0]);
                                    l_ChinaWindow.Add(eachInfo[1]);
                                    isWindowDone = true;
                                }
                            }
                        }
                        else
                        {
                            MyCreate.Box_Hei(() =>
                            {
                                if (string.IsNullOrEmpty(mInput))
                                {
                                    for (int i = 0; i < l_EnglishWindow.Count; i++)
                                    {
                                        m_Tools.TextText_WL(l_EnglishWindow[i], l_ChinaWindow[i], 30);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < l_EnglishWindow.Count; i++)
                                    {
                                        string eng = l_EnglishWindow[i];
                                        string chi = l_ChinaWindow[i];
                                        if (eng.Contains(mInput, StringComparison.OrdinalIgnoreCase) || chi.Contains(mInput, StringComparison.OrdinalIgnoreCase))
                                        {
                                            m_Tools.TextText_BL(eng, chi, 30);
                                        }
                                    }
                                }

                            });
                        }*/
        }


        #region WindowAndroidSame

        private void WindowAndroidSame1()
        {
            MyCreate.Text("Rendering".AddYellow() + "（渲染）".AddGreen());
            m_Tools.TextText_HL("Color Space", "用于渲染的色彩空间", ref isColor, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_OW("Gamma", "伽马空间渲染", -20);
                    m_Tools.TextText_OW("Linear", "线性渲染", -20);
                });
            }, 40);
            m_Tools.TextText_HL("Auto Graphics ...", OpenSure + "Windows 自动选择图形API", 0);
        }

        private void WindowAndroidSame2()
        {
            m_Tools.TextText_HL("Static Batching", OpenSure + "编译时设置使用静态批处理(专业版功能)", 0);
            m_Tools.TextText_HL("Dynamic Batching", OpenSure + "编译时设置使用动态批处理（默认激活）", 0);
            m_Tools.TextText_HL("GPU Skinning", OpenSure + "支持换肤", 0);
            m_Tools.TextText_HL("Graphics Jobs", OpenSure + "多线程(图形渲染),使得渲染代码并行运行在多核机器上", 0);
        }


        private void WindowAndroidSame3()
        {
            MyCreate.Text("Configuration".AddYellow() + "（配置）".AddGreen());
            m_Tools.TextText_HL("Scripting Runtime Version", "使用 Dll 的版本（稳定的3.5 还是试验 4.6）", 40);
            m_Tools.TextText_HL("Scripting Backend", "脚本后端(现在就只有 Mono)", 40);
            m_Tools.TextText_HL("Api Compatibility Level", "API 兼容性级别 ", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B(".NET API 2.0  ", "优点：".AddGreen());
                m_Tools.Text_G("    1. 更好于桌面Unity和第三方库代码兼容性     2. 在标准API集有更多功能");
                m_Tools.Text_R("缺点：");
                m_Tools.Text_R("    1. 用程序构建大小较大     2. 应用程序启动时间略差");

                m_Tools.Text_B(".NET 2.0 子集  ", "优点：".AddGreen());
                m_Tools.Text_G("    尤其是当剥离不使用时，较小的应用程序分配大小");
                m_Tools.Text_R("缺点：");
                m_Tools.Text_R("    对于标准和第三方库更糟糕的兼容性");
            });
        }

        private void WindowAndroidSame4()
        {
            m_Tools.TextText_HL("Disable HW Statistics", OpenSure + "禁用 HW 统计", 0);

        }

        private void WindowAndroidSame5()
        {
            m_Tools.TextText_HL("Scripting Define Symbols", "宏定义", 40);
            m_Tools.TextText_HL("Active Input Handing", "激活那个输入处理", 40);

        }

        private void WindowAndroidSame6()
        {
            MyCreate.Text("Optimization".AddYellow() + "（优化）".AddGreen());
            m_Tools.TextText_HL("Prebake Collision Meshes", OpenSure + "生成 Mesh 的碰撞数据", 0);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("    不勾选： 不会生成 Mesh 碰撞数据，到时如果需要访问顶点数据，就会报错");
                m_Tools.Text_B("    勾选：   就会导致额外内存占用");
            });
            m_Tools.TextText_HL("Keep Loaded Shaders Alive", OpenSure + "加载了的 Shader 会一直保持激活的状态", 0);
            m_Tools.TextText_HL("Preloaded Assets", "在启动游戏时，会预加载的资产集合", 40);
        }

        private void WindowAndroidSame7()
        {
            m_Tools.TextText_HL("Vertex Compression", "压缩顶点", 40);
            m_Tools.TextText_HL("Optimize Mesh Data", "网格数据优化(注意这里会有坑)", 40);
            MyCreate.Box(() =>
            {
                MyCreate.Text("如果开启了此选项，将会在 Build 过程中根据场景中 Mesh 所使用的材质");
                MyCreate.Text("进行静态分析，来去掉 Mesh 中“无用”的数据（材质不使用的数据）");
                MyCreate.Text("比如：切线，发现，定点色，多余uv等，以此减少数据量和最终构建的游戏包的大小".AddBlue());
                m_Tools.Text_G("    注意：如果是用代码动态修改 Shader，那就坑了");
            });
        }

        #endregion

        #endregion


        #region Android 发布设置

        private void DrawPlayerAndroid()                         // Player Android
        {

        }


        private void DrawAndroidEnglish()                       // Android 快速搜索
        {
            EnglishChina(mAndroidWWW, l_EnglishWindow2, l_ChinaWindow2, ref isAndroidDone);

        }

        private void DrawAndroid()                              // Android 详细版
        {
            m_Tools.BiaoTi_O("Resolution and Presentation" + "(解决方案和演示)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("Resolution Scaling".AddYellow() + "（分辨率缩放）".AddGreen());
                m_Tools.TextText_HL("Resolution Scaling Mode", "分辨率缩放模式(不使用/固定DPI)", 40);
                m_Tools.TextText_HL("Blit Type", "", 40);
                MyCreate.Text("Supported Aspect Ratio".AddYellow() + "（支持的宽高比）".AddGreen());
                m_Tools.TextText_HL("Aspect Ratio Mode", "纵横比模式", 40);
                MyCreate.Text("Orientation".AddYellow() + "（方向）".AddGreen());
                m_Tools.TextText_HL("Default Orientation", "纵向/纵向倒置/右横向/左横向/自动旋转", ref isDef, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BW("Portrait", "纵向模式,home键在底部", -20);
                        m_Tools.TextText_BW("Portrait Upside Down", "纵向倒置,home键在顶部", -20);
                        m_Tools.TextText_BW("Landscape Right", "横向模式，home键在左边", -20);
                        m_Tools.TextText_BW("Landscape Left", "横向模式，home键在右边", -20);
                        m_Tools.TextText_BW("Auto Rotation", "基于设备物理设备方向，自动旋转", -20);
                        m_Tools.Text_Y("Allowed Orientations for Auto Rotation");
                        m_Tools.Text_G("自动旋转时，允许那种方式可以使用");
                    });
                }, 40);
                m_Tools.TextText_HL("Use 32bit Display Buffer", OpenSure + "使用32位显示缓冲器", 0);
                m_Tools.TextText_HL("Disable Depth and Stencil", OpenSure + "禁止深度和模板", 0);
                m_Tools.TextText_HL("Show Loading Indicator", "一开始时是否显示加载条", ref isSho, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BW("Don't Show", "不显示", -20);
                        m_Tools.TextText_BW("Large ", "大", -20);
                        m_Tools.TextText_BW("Inversed Large ", "反转大", -20);
                        m_Tools.TextText_BW("Small", "小", -20);
                        m_Tools.TextText_BW("Inversed Small", "反转小", -20);
                    });
                }, 40);
            });


            AddSpace();
            m_Tools.BiaoTi_O("Other Setting" + "(其他设置)".AddGreen());
            MyCreate.Box(() =>
            {
                WindowAndroidSame1();
                m_Tools.TextText_HL("Multithreaded Rendering", OpenSure + "多线程渲染", 0);
                WindowAndroidSame2();
                m_Tools.TextText_HL("Protect Graphics Memory", OpenSure + "保护图形内存", 0);
                MyCreate.Text("Identification".AddYellow() + "（标识符）".AddGreen());
                m_Tools.TextText_HL("Package Name", "包名", 40);
                m_Tools.TextText_HL("Version", "版本", 40);
                m_Tools.TextText_HL("Bundle Version Code", "包版本代码", 40);
                m_Tools.TextText_HL("Minimum API Level", "最低 API 版本", 40);
                m_Tools.TextText_HL("Target API Level", "目标 API 版本（自动安装最高API的）", 40);
                WindowAndroidSame3();

                m_Tools.TextText_HL("Mute Other Audio Sources", OpenSure + "把其他音频源静音", 0);
                WindowAndroidSame4();

                m_Tools.TextText_HL("Device Filter", "架构设备筛选", -90);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_B("使用 ARMv7 能减少安装包大小");
                    m_Tools.Text_B("如果用户是使用 ZenPhone,ZenPad ，那么必须使用 x86");
                });
                m_Tools.TextText_HL("Install Location", "安装位置（自动/优先外部/强制内部）", 40);
                m_Tools.TextText_HL("Internet Access", "互联网接入(自动/要求)", 40);
                m_Tools.TextText_HL("Write Permission", "写入权限（内部/外部SD卡）", 40);
                m_Tools.TextText_HL("Fillter Touches ...", OpenSure + "当触摸模糊不清时忽略", 0);
                m_Tools.TextText_HL("Low Accuracy Location", OpenSure + "使用低精度的位置", 0);
                m_Tools.TextText_HL("Android TV Compatibility", OpenSure + "兼容 Android TV 设备", 0);
                m_Tools.TextText_HL("Android Game", OpenSure + "Android Game", 0);
                m_Tools.TextText_HL("Android Gamepad Support Level", "手柄支持", 40);
                WindowAndroidSame5();
                WindowAndroidSame6();
                m_Tools.TextText_HL("Stripping Level", "代码剥离水平", ref isStr, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BW("Disabled", "禁用代码剥离", -20);
                        m_Tools.TextText_BW("StripAssemblies", "剥离代码的未使用部分", -20);
                        m_Tools.TextText_BW("StripByteCode", "管理身体的一切方法。AOT唯一平台", -20);
                        m_Tools.TextText_BW("UseMicroMSCorlib", "Mscorlib 轻量级版本将被用于在有限的相容性", -20);
                    });
                }, -90);
                m_Tools.TextText_HL("Enable Internal Profiler", OpenSure + "使用内部的 Profiler", 0);
                WindowAndroidSame7();
            });


            AddSpace();
            m_Tools.BiaoTi_O("Publishing Settings" + "(Andriod电子市场的发布设置)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Key", "密钥库", 40);
                MyCreate.Text("Key".AddYellow() + "（密钥）".AddGreen());
                m_Tools.TextText_HL("Alias", "别名", 40);
                m_Tools.TextText_HL("Password", "密码发", 40);
                MyCreate.Text("Build".AddYellow() + "（构建）".AddGreen());

                m_Tools.TextText_HL("Build System", "构造系统", 40);
                m_Tools.TextText_HL("Custom Gradle Template", "自定义Gradle模板", 40);
                m_Tools.TextText_HL("Split Application Binary", OpenSure + "分离应用程序二进制", 0);
            });
        }


        #endregion


        #region Project Setting

        private void DrawEditor()                                // Editor
        {
            m_Tools.BiaoTi_O("Unity Remote" + "(直接在移动设备运行)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Dev", "设备", -50);
                m_Tools.TextText_HL("Com", "压缩", -50);
                m_Tools.TextText_HL("Res", "解析度(缩小/正常)", -50);
                m_Tools.TextText_HL("Joy", "游戏杆来源(远程/本地)", -50);

            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    1. 手机端下载 Unity Remote.apk)");
                m_Tools.Text_H("    2. 确保手机和电脑连接（手机USB连接必须开启【允许调试】模式）");
                m_Tools.Text_H("    3. 手机端运行 Unity Remote.apk");
                m_Tools.Text_H("    4. 在电脑端 Unity Remote下选择 " + "Any Android Device".AddBlue());
                m_Tools.Text_H("    5. 在电脑端运行游戏，可以看到手机和电脑是同步运行的了！");
                m_Tools.Text_G("注：如果没反应，就把 BuildSettings ->");
                m_Tools.Text_G("Delepment Build、Auto Profiler、Script Debgging 几个勾给勾上");
            });
            m_Tools.BiaoTi_O("Version Control" + "(版本控制)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Mode", "隐藏源文件/可见源文件/企业管理/SCM", -80);
            });
            m_Tools.BiaoTi_O("Asset Serialization" + "(Asset资源序列化)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Mode", "混合/强制二进制/强制文本", -80);
            });
            m_Tools.BiaoTi_O("Default Behavior Mode" + "(默认行为模式)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Mode", "3D/2D", -80);
            });
            m_Tools.BiaoTi_O("Sprite Packer" + "(图集)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Mode", "关闭/仅Build使用/一直使用", -80);
                m_Tools.TextText_HL("Padd", "Padding 边缘留空大小", -80);
            });
            m_Tools.BiaoTi_O("C# Project Generation" + "(C＃项目生成)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Addi", "包含的其他扩展", -80);
                m_Tools.TextText_HL("Root", "根命名空间", -80);
            });
            m_Tools.BiaoTi_O("ETC Texture Compressor" + "(ETC纹理压缩器)".AddGreen());

        }

        private void DrawInput()                                 // Input
        {
            m_Tools.TextText_OL("Name", "");
            m_Tools.TextText_OL("Descriptive Name", "正按钮的描述" + "（Window分辨率窗口可看到）".AddGreen());
            m_Tools.TextText_OL("Descriptive Negative Name", "负按钮的描述" + "（Window分辨率窗口可看到）".AddGreen());
            m_Tools.TextText_OL("Negative Button", "负 按钮");
            m_Tools.TextText_OL("Positive Button", "正 按钮");
            m_Tools.TextText_OL("Alt Negative Button", "负 按钮 Alt");
            m_Tools.TextText_OL("Alt Positive Button", "正 按钮 Al");
            m_Tools.TextText_OL("Gravity", "输入复位的速度，仅用于类型为 键/鼠标 的按键");
            m_Tools.TextText_OL("Dead", "任何小于该值的输入值（不论正负值）都会被视为0");
            m_Tools.TextText_OL("Sensitivity", "灵敏度,越大则响应时间越快,越小则越平滑");
            m_Tools.TextText_OL("Snap", OpenSure + "当轴收到反向信号，轴的数值会立即置为0");
            m_Tools.TextText_OL("Invert", OpenSure + "正向按钮发送负值，反向按钮发送正值");
            m_Tools.TextText_OL("Type", " 所有按钮输入设置为(键盘、鼠标/鼠标移动/摇杆轴)");
            m_Tools.TextText_OL("Axis", "设备的输入轴（摇杆，鼠标，手柄等）");
            m_Tools.TextText_OL("Joy Num", "设置使用哪个摇杆。默认是接收所有摇杆的输入");
        }

        private void DrawPhysics()                               // Physics
        {
            m_Tools.TextText_OL("Gravity", "重力 应用至所有刚体部件", -20);
            m_Tools.TextText_OL("Default Material", "默认的物理材料 ", -20);
            m_Tools.TextText_OL("Bounce Threshold ", "两个碰撞对象的相对速度低于这个值,不会相互反弹", -20);
            m_Tools.TextText_OL("Sleep Velocity", "这个物理系统运行低这个值，当作睡眠不更新帧", -20);
            m_Tools.TextText_OL("Default Contact Offset", "默认碰撞偏移（接近0会抖动所有要偏移）", -20);
            m_Tools.TextText_OL("Default Solver Iterations", "默认迭代求解器", -20);
            m_Tools.TextText_OL("Default Solver Velocity Iterations", "", -20);
            m_Tools.TextText_OL("Queries Hit Backfaces", OpenSure + "背面的也可以命中(如Physics.Raycast，默认关)", -20);
            m_Tools.TextText_OL("Queries Hit Triggers", OpenSure + "物理命中（默认开）", -20);
            m_Tools.TextText_OL("Enable Adaptive Force", OpenSure + "拥有自适应压力（如影响堆叠）", -20);
            m_Tools.TextText_OL("Enable PCM", OpenSure + "使用PCM触点的物理引擎", -20);
            m_Tools.TextText_OL("Auto Simulation", OpenSure + "物理仿真运行时允许自动或显式地控制它", -20);
            m_Tools.TextText_OL("Auto Sync Transforms", OpenSure + "自动变换同步变化与物理系统每当变换分量变化", -20);
            m_Tools.TextText_OL("Layer Collision Matrix", "使用该定义 基于层 的碰撞行为检测系统", -20);

        }


        #endregion


        #region 光照


        private void DrawPreferences()                           // Preferences 
        {
            m_Tools.BiaoTi_B("General 概括");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Aut", OpenSure + "当资源改变时，编辑器自动更新资源", -50);
                m_Tools.TextText_BL("Loa", OpenSure + "在启动时 直接加载以前的项目", -50);
                m_Tools.TextText_BL("Com", OpenSure + "导入 Asset 时自动压缩", -50);
                m_Tools.TextText_BL("Dis", OpenSure + "禁止自动发回信息给官方", -50);
                m_Tools.TextText_BL("Sho", OpenSure + "可以直接搜索 Asset Store 的内容 ", -50);
                m_Tools.TextText_BL("Ver", OpenSure + "核实退出时单独保存的资源", -50);
                m_Tools.TextText_BL("Edi", "编辑器 皮肤", -50);
                m_Tools.TextText_BL("Ena", OpenSure + "在 Hierarchy 使用数字排序", -50);
            });
            m_Tools.BiaoTi_B("ExternalTools 外部工具");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Ext", "用那个程序打开脚本文件", -50);
                m_Tools.TextText_BL("Add ", OpenSure + "生成解决方案 ( .sln ) 文件 ", -50);
                m_Tools.TextText_BL("Edi", OpenSure + "允许从外部脚本编辑器中控制调试", -50);
                m_Tools.TextText_BL("Ima", "使用哪个应用程序打开图片文件", -50);
                m_Tools.TextText_BL("Rev", "使用哪个程序解决文件在资源服务器上的差异", -50);
            });
            m_Tools.BiaoTi_B("Colors 颜色");
            MyCreate.Box((() =>
            {
                MyCreate.Text("Animation".AddYellow() + " (动画)".AddGreen());
                m_Tools.TextText_BL("Property Animated", "属性 动画");
                m_Tools.TextText_BL("Property Candidate", "属性 候选人");
                m_Tools.TextText_BL("Property Recorded", "属性 记录");
                MyCreate.Text("General".AddYellow() + " (普遍)".AddGreen());
                m_Tools.TextText_BL("Playmode tint", "游戏模式 色调");
                MyCreate.Text("Scene".AddYellow() + " (场景)".AddGreen());
                m_Tools.Text4_BW("Background", "背景", "Center Axis", "中心轴");
                m_Tools.Text4_BW("Grid", "格子", "Grid Component", "格子 组件");
                m_Tools.Text4_BW("Guide Line", "导航线", "Preselection Highlight", "预选突出显示");
                m_Tools.Text4_BW("Selected Axis", "选定的轴", "Selected Outline", "选定的大纲");
                m_Tools.Text4_BW("Wireframe", "线框", "Wireframe Overlay", "线框覆盖");
                m_Tools.Text4_BW("Wireframe Selected", "选择线框", "X Axis", "x 轴");
                m_Tools.Text4_BW("Y Axis", "y 轴", "Z Axis", "z 轴");
                m_Tools.Text4_BW("Use Defaults", "使用默认值", "", "");
            }));
            m_Tools.BiaoTi_B("GICache");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Maximum Cache Size", "最大缓存大小");
                m_Tools.TextText_BL("Custom cache location", "自定义缓存位置");
                m_Tools.TextText_BL("Cache compression", "缓存压缩");
                m_Tools.TextText_BL("Clean Cache", "清理缓存");
            });
            m_Tools.BiaoTi_B("自定义");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("自定义详情可以看  OdinInspectorAboutWindow ");
            });

        }



        private void DrawEnvironment()                           // Environment 环境
        {
            m_Tools.Text_G("Scene：设置整个场景而不是个体属性，设置控制光效应中的优化选项");
            m_Tools.BiaoTi_B("Environment 环境");
            m_Tools.TextText_HL("Skybox Material", "天空盒子 材质", -40);
            m_Tools.TextText_HL("SunSource", "指定 Light 当作太阳(没有,选择最亮方向光)", -40);
            MyCreate.Text("Environment Lighting".AddYellow() + "（环境光）".AddGreen());
            m_Tools.TextText_HL("Source", "环境光来源", -40);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW(" Skybox", "天空盒子材质", -60);
                m_Tools.TextText_BW(" Gradient", "天空颜色、赤道颜色和地面颜色之间平滑混合", -60);
                m_Tools.TextText_BW(" Color", "颜色", -60);

            });
            m_Tools.TextText_HL("Ambient Color/Mode", "周围 颜色/模式", -40);
            MyCreate.Text("Environment Reflections".AddYellow() + "（环境反射）".AddGreen());
            m_Tools.TextText_HL("Source", "反射来源", -40);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW(" Skybox", "(默认)天空盒子", -60);
                m_Tools.TextText_BW(" Custom", "自定义添加使用 Cubemap 立方体图", -60);
            });
            m_Tools.TextText_HL("Resolution", "解析度", -40);
            m_Tools.TextText_HL("Compression", "压缩（自动/压缩/不压缩）", -40);
            m_Tools.TextText_HL("Intensity Multiplier", "反射强度0-1", -40);
            m_Tools.TextText_HL("Bounces", "反弹", -40);
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("一个object接受到的光照会来自多个object的反射光");
                m_Tools.Text_W("unity中用 Reflection probe 来模拟这种反射情况");
            });
        }


        private void DrawRealtime()                              // Realtime/Mixed 光照
        {

            m_Tools.BiaoTi_B("Realtime Lighting 实时光照");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Realtime Global Illumination", OpenSure + "实时全局光照");

            });
            AddSpace();
            m_Tools.BiaoTi_B("Mixed Lighting 混合光照");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Baked Global Illumination", OpenSure + "烘焙全局照明");
                m_Tools.TextText_HL("Lighting Mode", "照明模式");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_BW("Baked Indirect", "间接烘焙", -20);
                    m_Tools.TextText_BW("Shadowmask", "遮挡阴影", -20);
                    m_Tools.TextText_BW("Subtractive", "减法", -20);
                });
                m_Tools.TextText_HL("Realtime Shadow Color", "实时 阴影 颜色");
            });

        }


        private void DrawLightmapping()                          // Lightmapping Setting 光照贴图设置
        {
            m_Tools.BiaoTi_B("Lightmapping Setting 光照贴图设置");
            m_Tools.TextText_HL("Lightmapper", "光照贴图渲染器", -20);
            m_Tools.TextText_HL("Indirect Resolution", "间接 解析", -20);
            m_Tools.TextText_HL("Lightmap Resolution", "光照 贴图 分辨率", -20);
            m_Tools.TextText_HL("Lightmap Padding", "光照 填充", -20);
            m_Tools.TextText_HL("Lightmap Size", "光照 渲染 尺寸", -20);
            m_Tools.TextText_HL("Compress Lightmaps", "光照 贴图 压缩", -20);
            m_Tools.TextText_HL("Ambient Occlusion", "环境 遮挡", -20);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW(" Max Distance", "最大 距离");
                m_Tools.TextText_BW(" Indirect Contribution", "间接 贡献");
                m_Tools.TextText_BW(" Direct Contribution", "直接 贡献");
            });
            m_Tools.TextText_HL("Final Gather", "最终 聚集", -20);
            m_Tools.TextText_HL("Directional Mode", " 定向 模式", -20);
            m_Tools.TextText_HL("Indirect Intensity", "间接 强度", -20);
            m_Tools.TextText_HL("Albedo Boost", "反照率 升压", -20);
            m_Tools.TextText_HL("Lightmap Parameters", "光照 贴图 参数", -20);
        }


        private void DrawOtherSetting()                          // Other/Debug Setting
        {
            m_Tools.BiaoTi_B("Other Setting 其他设置");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Fog", OpenSure + "雾", -20);
                m_Tools.TextText_HL("Halo Texture", "设置用于纹理绘制光晕周围的灯光", -20);
                m_Tools.TextText_HL("Halo Strength", "定义所述可见度的光晕，0~1", -20);
                m_Tools.TextText_HL("Flare Fade Speed", "火炬衰落速度，秒为单位", -20);
                m_Tools.TextText_HL("Flare Strength", "定义了从灯光能见度的镜头，0~1", -20);
                m_Tools.TextText_HL("Spot Cookie", "设置 Cookie 要使用的纹理投光灯", -20);
            });

            AddSpace();
            m_Tools.BiaoTi_B("Debug Setting 其他设置");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_HL("Debug Settings", "设置,帮助您调试场景", -20);
                m_Tools.TextText_HL("Update Statistics", "", -20);
                m_Tools.Text_G("如果在统计窗口的底部处的照明设置窗口被更新为场景变化");
                m_Tools.Text_G("这可能会影响性能播放模式。为了更好 的性能，在播放模式中,取消勾选!");

                m_Tools.TextText_HL("Light Probe Visualization", "光探针在场景视图可视化", -20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_BW("Only Probes Used By Selection", "光探针将仅影响当前选定内容中的场景视图");
                    m_Tools.TextText_BW("All Probes No Cells", "所有光探针可视化场景视图");
                    m_Tools.TextText_BW("All Probes With Cells", "所有光探针 + 四面体插值的数据 可视化");
                    m_Tools.TextText_BW("None", "无光探针可视化场景视图");
                });
                m_Tools.TextText_HL("Display Weights", "主动的选择位置上使用四面体内插", -20);
                m_Tools.TextText_HL("Display Occlusion", "用于遮挡数据的混合照明光探针模式距离荫罩或荫罩", -20);
            });

        }



        private void Globalmaps()                                // Global/Object maps
        {
            m_Tools.BiaoTi_B("Globalmaps");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("显示所有资产进行光照所产生的文件 Gi 照明过程");
                m_Tools.Text_G("使用 Global maps 去查看照明系统使用的实际纹理");
                m_Tools.Text_G("包括强度光照贴图，阴影遮罩和方向性贴图");
                m_Tools.Text_G("这仅适用于使用烘焙照明或混合照明的情况; 预览对于实时照明是空白的");
                m_Tools.TextText_HL("Lighting Data Asset", "光照 数据 Asset");
                m_Tools.TextText_HL("Preview", "预演示");
            });
            AddSpace();
            m_Tools.BiaoTi_B("Objectmaps");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("当前选择的游戏对象，显示预览的纹理(光照 GI)阴影");
                m_Tools.Text_G("使用 Object maps 查看当前选定的游戏对象的已烘焙贴图的预览，包括遮罩");

            });



        }

        #endregion

    }




}

