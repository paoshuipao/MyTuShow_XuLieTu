using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Unity_Static : AbstactNewKuang
    {
        [MenuItem(LearnMenu.UnityGongJuZhongJie)]
        static void Init()
        {
            Unity_Static instance = GetWindow<Unity_Static>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            #region Application

            bool tmpApplication = (type == EType.Application || type == EType.Application1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Application";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Application ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Application);
            }
            if (tmpApplication)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Application1 ? "  详细版".AddBlue() : "  详细版");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Application1);
                }
            }
            #endregion

            AddSpace();

            #region SceneManager

            bool tmpScene = (type == EType.SceneManager || type == EType.Scene || type == EType.SceneManager2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "SceneManager";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.SceneManager ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.SceneManager);
            }
            if (tmpScene)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Scene ? "  Scene".AddBlue() : "  Scene");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Scene);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.SceneManager2 ? "  其他相关".AddBlue() : "  其他相关");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.SceneManager2);
                }
            }


            #endregion

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Screen";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Screen ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Screen);
            }
            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Input";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Input ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Input);
            }

            AddSpace();

            #region Physics

            bool isPhysics = (type == EType.Physics || type == EType.Physics1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Physics";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Physics ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Physics);
            }

            if (isPhysics)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Physics1 ? "   射线检测".AddBlue() : "   射线检测");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Physics1);
                }
            }

            #endregion


            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Mathf";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Mathf ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Mathf);
            }

            AddSpace();


            bool isNoUse= (type == EType.NoUse || type == EType.Handheld || type == EType.PrefabUtility || type == EType.GL || type == EType.GUIUtility);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "少使用但实用".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.NoUse ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Handheld);
            }

            if (isNoUse)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Handheld ? "   Handheld".AddBlue() : "   Handheld");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Handheld);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.PrefabUtility ? "   PrefabUtility".AddBlue() : "   PrefabUtility");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.PrefabUtility);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.GUIUtility ? "   GUIUtility".AddBlue() : "   GUIUtility");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.GUIUtility);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.GL ? "   GL".AddBlue() : "   GL");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.GL);
                }
   
            }


        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Application:    DrawRightPage1(DrawEasyApplication);  break;
                case EType.Application1:   DrawRightPage1(DrawApplication);      break;
                case EType.SceneManager:   DrawRightPage3(DrawSceneManager);     break;
                case EType.SceneManager2:  DrawRightPage3(DrawSceneOther);       break;
                case EType.Scene:          DrawRightPage3(DrawScene);            break;
                case EType.Screen:         DrawRightPage3(DrawScreen);           break;
                case EType.Input:          DrawRightPage4(DrawInput);            break;
                case EType.Physics:        DrawRightPage5(DrawPhysics);          break;
                case EType.Physics1:       DrawRightPage1(DrawPhysics1);         break;
                case EType.Mathf:          DrawRightPage6(DrawMathf);            break;
                case EType.Handheld:       DrawRightPage7(DrawHandheld);         break;
                case EType.PrefabUtility:  DrawRightPage8(DrawPrefabUtility);    break;
                case EType.GL:             DrawRightPage1(DrawGL);               break;
                case EType.GUIUtility:     DrawRightPage5(DrawGUIUtility);       break;
            }


        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Application:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Application1:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.PrefabUtility:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                case EType.Screen:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }



        #region 私有
        private static bool isCancelQuit,isTargetFrameRate,isNoUse4, isDefaultSolverIterations;
        private static bool isDeg2Rad, isRad2Deg, isOther3;

        private bool isFourth, isRay, isAll1, isAll2, isAll3, isAll4, isRaycastHit, isFrist, isSecond, isThird;
        private RaycastType m_RaycastType = RaycastType.Physics_Raycast;


        private const string PhysicsRaycast = "Physics.Raycast";
        private const string PhysicsRaycastAll = "Physics.RaycastAll";
        private const string Physics2DRaycast = "Physics2D.Raycast";

        private readonly string[] RaycastTypeStrs = { "Physics.Raycast 3D射线检测", "Physics.RaycastAll 射线穿过所有", "Physics2D.Raycast 2D射线检测" };

        enum RaycastType
        {
            Physics_Raycast,
            Physics_RaycastAll,
            Physics2D_Raycast,
        }


        private enum EType
        {
            Application,Application1,
            SceneManager,Scene, SceneManager2,
            Screen,
            Input,
            Physics,Physics1,
            Mathf,
            NoUse,Handheld,PrefabUtility,GL, GUIUtility,

        }

        private EType type = EType.Application;

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
            return "工具类";
        }


        #endregion


        #region Application



        private void DrawEasyApplication()       // Application 简单版
        {
            m_Tools.BiaoTi_Y("属性：获得路径");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YB("persistentDataPath", "只读", "永久数据目录" + "(可读可写)".AddGreen(), "string", 5);
                m_Tools.Method_YB("streamingAssetsPath", "只读", "StreamingAssets 文件夹的路径" + "(只读不可写)".AddGreen(), "string", 5);
                m_Tools.Method_YB("dataPath", "只读", "获取应用路径" + "（如 E:/Pro/AllText/Asset）".AddLightBlue(), "string", 5);
            });
            m_Tools.BiaoTi_Y("属性：判断");
            MyCreate.Box(() =>
            {
                m_Tools.Text4_YW("isEditor", "是否在编辑器运行", "isFocused", "焦点是否在游戏当中",20);
                m_Tools.Text4_YW("isPlaying", "是否正在运行游戏", "isMobilePlatform", "目前运行时平台是否手机", 20);
            });
            m_Tools.BiaoTi_Y("属性：获取信息" + "（只读的）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("streamedBytes", "只读", "从网络上下载了多少个字节", "int", 5);
                m_Tools.Method_YL("internetReachability", "只读", "获得网络情况"+"(没网络/Wifi/移动网络)".AddGreen(), "NetworkReachability", 5);

            });
            m_Tools.BiaoTi_Y("属性：获取信息" + "（可读可写）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("runInBackground", "", "游戏能否在后台上运行", "bool", 5);
            });
            AddSpace();

            m_Tools.BiaoTi_O("方法");

            MyCreate.Box(AppMethod);
            AddSpace();

            m_Tools.BiaoTi_B("Static 事件");
            MyCreate.Box(AppEvent);

        }

        private void DrawApplication()           // Application 应用
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Application.html");
            MyCreate.StaticPropertiesWindow(() =>
            {
                MyCreate.Text("获得路径");
                m_Tools.Method_OY("persistentDataPath", "只读", "永久数据目录" + "(可读可写)".AddGreen(), "string",5);
                m_Tools.Method_OY("streamingAssetsPath", "只读", "StreamingAssets 文件夹的路径" + "(只读不可写)".AddGreen(), "string", 5);
                m_Tools.Method_OY("dataPath", "只读", "应用 E:/Pro/AllText/Asset", "string", 5);
                MyCreate.Text("判断");
                m_Tools.Method_OY("isEditor", "只读", "在编辑器运行游戏返回ture", "bool", 5);
                m_Tools.Method_OY("isFocused", "只读", "焦点是否在游戏当中", "bool", 5);
                m_Tools.Method_OY("isPlaying", "只读", "是否正在运行游戏", "bool", 5);
                m_Tools.Method_OY("isMobilePlatform", "只读", "目前运行时平台是否移动平台", "bool", 5);


                MyCreate.Text("获取信息");
                m_Tools.Method_OY("platform", "只读", "游戏" + "运行的平台".AddGreen(), "RuntimePlatform", 5);
                m_Tools.Method_OY("identifier", "只读", "标识码".AddGreen() + "，如安卓是包名", "string", 5);
                MyCreate.Text("获取信息或者修改这些信息");
                m_Tools.Method_OY("runInBackground", "", "游戏能否在" + "后台运行".AddGreen(), "bool", 5);
                m_Tools.Method_OY("systemLanguage", "", "使用的" + "语言".AddGreen(), "SystemLanguage", 5);
                m_Tools.Method_OY("targetFrameRate", "", "游戏尝试以指定的" + "帧速率进行渲染".AddGreen(), "int", ref isTargetFrameRate, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("    1. targetFrameRate 默认值是 -1，表示以平台的默认帧速率渲染");
                        m_Tools.Text_H("    2. 在PC上：默认帧速率是可实现的最大帧速率");
                        m_Tools.Text_H("    3. 在移动平台上：默认帧速率是每秒30帧（需要节省电池电量）");
                        m_Tools.Text_H("    4. 设置targetFrameRate不能保证帧速率将会实现，会有波动或无法达到帧速率");
                        m_Tools.Text_H("    5. 如果设置了QualitySettings.vSyncCount属性，targetFrameRate则将被忽略");
                        m_Tools.Text_H("例如，平台的默认渲染速率是每秒60帧，vSyncCount设置为2，则游戏将以每秒30帧为目标");
                    });

                }, 5);
                m_Tools.Method_OY("streamedBytes", "只读", "从网络上下载了多少个字节", "int", 5);
                m_Tools.Method_OY("internetReachability", "", "获得网络情况" + "(没网络/Wifi/移动网络)".AddGreen(), "NetworkReachability", 5);
                m_Tools.Method_OY("isConsolePlatform", "", "当前平台是否Console平台", "bool", 5);
                m_Tools.Method_OY("backgroundLoadingPriority", "", "后台加载线程的优先级", "ThreadPriority", 5);
                m_Tools.Method_OY("genuine", "", "应用程序在运行后发生任何改变，返回false", "bool", 5);
                m_Tools.Method_OY("genuineCheckAvailable", "", "如果可以确认应用程序完整性，则返回true", "bool", 5);
                m_Tools.Method_OY("absoluteURL", "只读", "文档的URL", "string", 5);
                m_Tools.Method_OY("cloudProjectId", "只读", "云项目的Id", "string", 5);
                m_Tools.Method_OY("companyName", "只读", "申请公司名称", "string", 5);
                m_Tools.Method_OY("installerName", "只读", "应用程序安装名", "string", 5);
                m_Tools.Method_OY("installMode", "只读", "返回应用程序安装模式", "ApplicationInstallMode", 5);
                m_Tools.Method_OY("productName", "只读", "返回应用程序产品名称", "string", 5);
                m_Tools.Method_OY("temporaryCachePath", "只读", "包含临时数据/缓存目录的路径", "string", 5);
                m_Tools.Method_OY("unityVersion", "", "Unity运行时版本", "string", 5);
                m_Tools.Method_OY("version", "只读", "返回应用程序版本号", "string", 5);
            });
            MyCreate.StaticMethodWindow(() =>
            {

                AppMethod();
                m_Tools.Method_OY("GetStackTraceLogType", "LogType", "获取堆栈跟踪日志选项", "StackTraceLogType",40);
                m_Tools.Method_OY("SetStackTraceLogType", "", "设置堆栈跟踪日志选项", "SetStackTraceLogType",40);
            });

            MyCreate.StaticEventsWindow(AppEvent);
     

        }

        private void AppMethod()
        {
            m_Tools.Method_OY("OpenURL", "string", "在浏览器中打开网址");
            m_Tools.Method_OY("Unload", "", "挂起游戏，" + "按了Home键".AddGreen());
            m_Tools.Method_OY("Quit", "", "退出游戏");
            m_Tools.Method_OY("CancelQuit", "", "取消退出".AddGreen() + "应用程序", "", ref isCancelQuit, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_Y("   1. 取消退出应用程序。这对于在游戏结束时显示启动画面很有用");
                    m_Tools.Text_Y("   2. 此功能仅适用于 Window 播放器");
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711105436878-351079507.png");
                });

            });
        }

        private void AppEvent()
        {
            m_Tools.TextText_BL("logMessageReceived +=", "收到日志 Log 消息", 55);
            m_Tools.TextText_BL("logMessageReceivedThreaded +=", "在线程".AddGreen() + "也能收到日志消息", 55);
            m_Tools.TextText_BL("lowMemory +=", "当手机运行时通知 " + "内存不足".AddRed() + " 时", 55);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    1. 为了避免应用程序被终止，应该从内存中释放非关键资源（纹理或音频）");
                m_Tools.Text_H("    2. 也可以加载这些资源的较小版本的资源代换掉");
                m_Tools.Text_H("    3. 此外 应该将任何瞬态数据序列化存储，以避免应用程序终止时丢失数据");
                m_Tools.Text_H("    4. Resources.UnloadUnusedAssets() 释放内存");
            });
        }



        #endregion


        #region Input


        private void DrawInput()           // Input 输入
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Input.html");
        }


        private void DrawPhysics1()          // 射线检测
        {
            m_RaycastType = (RaycastType)m_Tools.BiaoTi_O(m_RaycastType, (int)m_RaycastType, RaycastTypeStrs, 60);
            switch (m_RaycastType)
            {
                case RaycastType.Physics_Raycast:
                    DrawPhysicsRaycast();
                    break;
                case RaycastType.Physics_RaycastAll:
                    DrawPhysicsRaycastAll();
                    break;
                case RaycastType.Physics2D_Raycast:
                    DrawPhysics2DRaycast();
                    break;
            }
        }

        private void DrawPhysicsRaycast()
        {
            m_Tools.GuangFangWenDan_Select(PhysicsRaycast, "https://docs.unity3d.com/ScriptReference/Physics.Raycast.html");
            BiaoTi(1, " 起点.方向.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "bool", "( Vector3 , Vector3 )", ref isFrist, () =>
            {
                Origin();
                Direction();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });
            BiaoTi(2, " 起点.方向.被碰撞物.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "bool", "( Vector3 , Vector3 , out RaycastHit )", ref isSecond, () =>
            {
                Origin();
                Direction();
                HitInfo();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });
            BiaoTi(3, " 射线.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "bool", "( Ray )", ref isThird, () =>
            {
                Ray();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });

            BiaoTi(4, " 射线.被撞物.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "bool", "( Ray , out RaycastHit )", ref isFourth, () =>
            {
                Ray();
                HitInfo();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });

            AddSpace();
            MyCreate.Text("[ 说明 ]".AddGreen());
            m_Tools.Text_G(("一." + "[ Ray ] ".AddBlue() + "其实就是起点和方向的封装类"), ref isRay, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("获取点击屏幕发射的射线 Ray ：");
                    m_Tools.Text_W("Ray ray= m_Camera.ScreenPointToRay(Input.mousePosition)");
                });

            });
            RaycastHitDes();
            m_Tools.Text_G("三. 返回的是 " + "bool (是否碰撞到物体)".AddYellow());

        }

        private void DrawPhysicsRaycastAll()
        {
            m_Tools.GuangFangWenDan_Select(PhysicsRaycastAll, "https://docs.unity3d.com/ScriptReference/Physics.RaycastAll.html");
            BiaoTi(1, " 射线.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "RaycastHit【】", "( (Ray )", ref isAll1, () =>
            {
                Ray();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });


            BiaoTi(2, " 起点.方向.".AddBlue() + "最大距离.可撞层.是否触发Trigger", "RaycastHit【】", "( Vector3 , Vector3 )", ref isAll2, () =>
            {
                Origin();
                Direction();
                MaxDistance();
                LayerMask();
                QueryTriggerInteraction();
            });

            AddSpace();
            MyCreate.Text("[ 说明 ]".AddGreen());
            m_Tools.Text_G("一." + "返回的是" + " RaycastHit【】（被撞到的所有物体的集合）".AddYellow());
            RaycastHitDes();

        }


        private void DrawPhysics2DRaycast()
        {
            m_Tools.GuangFangWenDan_Select(Physics2DRaycast, "https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html");
            BiaoTi(1, " 起点.方向.".AddBlue() + "最大距离.可撞层.最小 Z 轴.最大 Z 轴", "RaycastHit2D", "( Vector2 , Vector2 )", ref isAll3, () =>
            {
                Text3("起点".AddBlue(), "2D射线在二维空间的起点", "Vector2");
                Text3("方向".AddBlue(), "2D射线方向的矢量", "Vector2");
                Text3("最大距离".AddLightBlue(), "2D射线最大距离", "float");
                LayerMask();
                Text3("最小 Z 轴".AddLightBlue(), "最小 Z 轴", "float");
                Text3("最大 Z 轴".AddLightBlue(), "最大 Z 轴", "float");
                m_Tools.Text_G("返回2D被撞物信息");
            });

            BiaoTi(2, " 起点.方向.过滤.撞到的所有物体结果.".AddBlue() + "最大距离", "int", "(V2,V2,ContactFilter2D,RaycastHit2D[])", ref isAll4, () =>
            {
                Text3("起点".AddBlue(), "2D射线在二维空间的起点", "Vector2");
                Text3("方向".AddBlue(), "2D射线方向的矢量", "Vector2");
                Text3("过滤".AddBlue(), "与Mask功能相似的封装类", " ContactFilter2D");
                Text3("撞到的所有物体结果".AddBlue(), "", "int");
                Text3("最大距离".AddLightBlue(), "2D射线最大距离", "float");
                m_Tools.Text_G("返回results数组中结果的数量");
            });

        }

        private void Origin()                                    //起点
        {
            Text3("起点".AddBlue(), "射线在世界坐标中的起点", "Vector3");
        }


        private void Direction()                                 //方向
        {
            Text3("方向".AddBlue(), "射线的方向", "Vector3");
        }


        private void MaxDistance()                               //最大距离
        {
            Text3("最大距离".AddLightBlue(), "射线最大距离" + "(默认 Mathf.Infinity)".AddGreen(), "float");
        }


        private void LayerMask()                                 //可撞层
        {
            Text3("可撞层".AddLightBlue(), "那个层能触发" + "(默认 DefaultRaycastLayers)".AddGreen(), "int");
        }

        private void QueryTriggerInteraction()                   //是否触发触发器Trigger
        {
            Text3("是否触发触发器Trigger".AddLightBlue(), "", "QueryTriggerInteraction");
        }


        private void HitInfo()                                   //被撞物
        {
            Text3("被撞物".AddBlue(), "射线撞到的物体信息", "out RaycastHit");
        }


        private void Ray()                                       //射线
        {
            Text3("射线".AddBlue(), "由起点和方向组成的射线封装类", "Ray");
        }


        private void RaycastHitDes()                             //二.[ RaycastHit ] 被撞物API
        {
            AddSpace_3();
            m_Tools.Text_G(("二." + "[ RaycastHit ] ".AddBlue() + "被撞物API"), ref isRaycastHit, () =>
            {
                MyCreate.Box(() =>
                {
                    Text3("distance".AddWhite(), "从射线的起点到碰撞点的距离", "float");
                    Text3("point".AddWhite(), "碰撞点", "Vector3");
                    Text3("rigidbody".AddWhite(), "获得被撞物刚体组件，没为Null", "Rigidbody");
                    Text3("transform".AddWhite(), "获得Transform", "Transform");
                });

            });
            AddSpace_3();
        }
        private void BiaoTi(int num, string biaoTi, string methodPro, string method, ref bool isShow, Action action)
        {
            bool tmp = isShow;
            string str = "";
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_B((num + ".").AddLightBlue() + biaoTi.AddLightBlue(), () =>
                {
                    tmp = !tmp;
                });
                switch (m_RaycastType)
                {
                    case RaycastType.Physics_Raycast:
                        str = PhysicsRaycast;
                        break;
                    case RaycastType.Physics2D_Raycast:
                        str = Physics2DRaycast;
                        break;
                    case RaycastType.Physics_RaycastAll:
                        str = PhysicsRaycastAll;
                        break;
                }
                MyCreate.Heng(() =>
                {
                    m_Tools.Text_W(str + " " + method.AddBlue(), ref tmp, () =>
                    {
                        tmp = !tmp;
                    });
                    MyCreate.AddSpace();
                    MyCreate.Text(methodPro.AddOrange());
                });

                if (null != action && tmp)
                {
                    action();

                }
            });
            AddSpace();
            isShow = tmp;
        }


        private void Text3(string str1, string str2, string str3)
        {
            m_Tools.TextText_OY(str1 + " (" + str3 + ")", str2);

        }

        #endregion



        #region SceneManager

        private void DrawSceneManager()           // SceneManager 场景
        {
            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Method_OY("sceneCount", "", "当前场景中有多少个场景（如没其它就 1）", "int", -50);
                m_Tools.Method_OY("sceneCountInBuildSettings", "", "“Build”中的场景数量", "int");
            });
            MyCreate.StaticMethodWindow(() =>
            {
                MyCreate.Text("加载");
                m_Tools.Method_OY("LoadScene", "", "在“Build”加载场景", "void");
                m_Tools.Method_OY("LoadSceneAsync", "", "异步加载场景", "AsyncOperation");
                MyCreate.Text("获取场景 Scene");
                m_Tools.Method_OY("GetActiveScene", "", "获得当前场景", "Scene");
                m_Tools.Method_OY("GetSceneByBuildIndex", "int “Build”索引 ", "通过 Build 处索引", "Scene", 60);
                m_Tools.Method_OY("GetSceneByName", "string “Build”名称", "通过 Build 处名称", "Scene", 60);
                m_Tools.Method_OY("GetSceneByPath", "string Assets路径", "通过 Assets路径", "Scene", 60);

                MyCreate.Text("操作场景");

                m_Tools.Method_OY("SetActiveScene", "Scene", "", "bool");
                m_Tools.Text_Y("        激活该场景（如果没加载返回 false ）");
                m_Tools.Method_OY("MoveGameObjectToScene", "GameObject，Scene", "");
                m_Tools.Text_Y("        将 GameObject 移动到目标场景中");
                m_Tools.Method_OY("UnloadSceneAsync", "int/string/Scene", "", "AsyncOperation");
                m_Tools.Text_Y("        销毁场景以及所有的 GameObject " + "(不能再加载此场景)".AddGreen());


                MyCreate.StaticEventsWindow(() =>
                {
                    m_Tools.SelectTextText_B("activeSceneChanged +=", "当活动的场景发生改变 调用");
                    m_Tools.SelectTextText_B("sceneLoaded +=", "当一个场景已经加载 调用");
                    m_Tools.SelectTextText_B("sceneUnloaded +=", "当一个场景已经卸载 调用");
                });
            });

        }

        private void DrawScene()
        {
            m_Tools.BiaoTi_B("Scene 场景");
            MyCreate.Box(() =>
            {
                MyCreate.Text("获取");
                m_Tools.Method_OY("rootCount", "", "获取根 transforms 数量", "int");
                m_Tools.Method_OY("buildIndex", "", "返回Build场景的索引", "int");
                m_Tools.Text_G("    （如果是 AssetBundle 加载的场景始终返回 -1）");
                MyCreate.Text("判断");
                m_Tools.Method_OY("isLoaded", "", "场景是否给加载", "bool");
            });
            MyCreate.MethodWindow(() =>
            {
                MyCreate.Text("获取");
                m_Tools.Method_OY("GetRootGameObjects", "", "所有根 GameObject", "GameObject[]");
            });

        }


        private void DrawSceneOther()
        {
            m_Tools.BiaoTi_B("AsyncOperation " + "allowSceneActivation".AddHui() + "是否直接激活场景");
            AddSpace();
            m_Tools.BiaoTi_B("LoadSceneMode 加载场景枚举");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Single", "正常、默认的单一场景加载", -80);
                m_Tools.TextText_OY("Additive", "叠加在上一个场景上，DontDestory 就是使用叠加", -80);
                m_Tools.Text_G("Additive 肯定基本都用不到");
            });

        }

        #endregion



        private void DrawPhysics()               // Physics 物理
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Physics.html");
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_OY("AllLayers", "", "所有层 Eventhing 的索引", "int", -30);
                m_Tools.Method_OY("gravity", "", "重力应用于场景中的所有刚体。", "Vector3", -30);
                MyCreate.Text("该值通常在 Edit->Project Settings->Physics 设置".AddGreen());
                m_Tools.Method_OY("bounceThreshold", "", "", "float", -30);
                m_Tools.Text_Y("    两个相对速度低于此值的碰撞对象不会反弹" + "（默认值2）".AddLightBlue());
                m_Tools.Method_OY("defaultSolverIterations", "", "", "int", ref isDefaultSolverIterations, () =>
                {
                    m_Tools.Text_O("在连接的刚体存在问题时出现振荡并且行为不规律");
                    m_Tools.Text_O("则设置更高的求解器迭代次数可能会提高它们的稳定性（但速度较慢）");

                }, -30);
                m_Tools.Text_Y("    Rigidbody关节和碰撞接触的默认解决方式" + "（默认6）".AddLightBlue());
                m_Tools.Method_OY("defaultSolverVelocityIterations", "", "", "int", -30);
                m_Tools.Text_Y("    Rigidbody关节和碰撞接触的精确度" + "（默认1）".AddLightBlue());

                m_Tools.Text_G("少用的的", ref isNoUse4, () =>
                {
                    m_Tools.Method_OY("autoSimulation", "", "设置是否应自动模拟物理", "bool", -30);
                    m_Tools.Method_OY("autoSyncTransforms", "", "Transform变化时是否自动同步变换与物理系统的变化", "bool", -30);
                    m_Tools.Method_OY("defaultContactOffset", "", "新创建的碰撞器的默认偏移量", "float", -30);
                    m_Tools.Method_OY("DefaultRaycastLayers", "", "默认的Layer mask ", "int", -30);
                    m_Tools.Method_OY("IgnoreRaycastLayer", "", "选择忽略光线投射图层", "int", -30);
                    m_Tools.Method_OY("interCollisionDistance", "", "布料相互碰撞的最小分隔距离", "float", -30);
                    m_Tools.Method_OY("interCollisionStiffness", "", "布料的相互碰撞刚度", "float", -30);
                    m_Tools.Method_OY("sleepThreshold", "", "物理睡眠阈值", "float", -30);
                });

            });
        }

        private void DrawMathf()                 // Mathf 数学公式
        {
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_OY("Deg2Rad", "只读", "弧度 =" + " 角度 * ".AddGreen() + "Mathf.Deg2Rad".AddHui(), "float", ref isDeg2Rad, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_L("表示从角度到弧度转换的", "常量值".AddWhite());
                        m_Tools.Text_L("其值为", "( 2 * Mathf.PI )/360 = 0.01745329".AddHui());
                    });
                }, -30);
                m_Tools.Method_OY("Rad2Deg", "只读", "角度 = " + "弧度 * ".AddGreen() + "Mathf.Rad2Deg".AddHui(), "float", ref isRad2Deg, () =>
                {
                    m_Tools.Text_L("表示从弧度到角度转换的", "常量值".AddWhite());
                    m_Tools.Text_L("其值为", "57.2958f".AddHui());
                }, -30);
                m_Tools.Text_O("NegativeInfinity", "负无穷".AddYellow(), "    Epsilon", "接近0但不等于0".AddYellow(), "    Infinity", "正无穷".AddYellow());
            });
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("Cos", "", "余弦值 = Cos（弧度）", "float", -30);
                m_Tools.Method_OY("Acos", "", "弧度 = Acos （余弦值）", "float", -30);
                m_Tools.Method_OY("Tan", "", "正切值 = Tan（弧度）", "float", -30);
                m_Tools.Method_OY("Atan", "", "弧度 = Atan （正切值）", "float", -30);
                m_Tools.Method_OY("Atan2", "", "角度 = Atan2 （正切值）", "float", -30);
                m_Tools.Method_OY("Ceil", "float", "向上取整," + "如 ceil（1.3）返回 2.0".AddWhite(), "float", -30);
                m_Tools.Method_OY("Floor", "float", "// 向下取整," + "如 floor（1.3）返回 1.0".AddWhite(), "float", -30);
                m_Tools.Method_OY("MoveTowards", "", "与插值类同，但更平滑", "float", -30);
                m_Tools.Method_OY("Log", "float，float", "求对数Log", "float", -30);
                m_Tools.Method_OY("Pow", "b,n", "返回 b 的 n 次方", "float", -30);
                m_Tools.Method_OY("PingPong", "float 时间，float 长)", "Time.time、[0,长度] 来回", "float", -30);
                m_Tools.Method_OY("Repeat", "float 时间，float 长度", "Time.time、[0,长度] 重复", "float,-30");
                m_Tools.Method_OY("SmoothDamp", "", "随着时间的推移逐渐将value转变目标", "", -30);
                m_Tools.Text_G("其他", ref isOther3, () =>
                {
                    m_Tools.Method_OY("Sin", "( float )", "正弦值 = Sin（弧度）", "float");
                    m_Tools.Method_OY("Asin", "( float )", "弧度 = Asin （正弦值）", "float");
                    m_Tools.Method_OY("Abs", "( float )", "绝对值", "float");
                    m_Tools.Method_OY("Clamp", "(x,min,max)", "将 x 收缩至min与max之间", "float");
                    m_Tools.Method_OY("Clamp01", "( x )", "clamp( x,0 ,1)", "float");
                    m_Tools.Method_OY("CorrelatedColorTemperatureToRGB", "(float 温度)", "返回颜色相关的色温", "Color ");
                    m_Tools.Method_OY("GammaToLinearSpace", "( float )", "转换为线性色彩空间", "float");
                    m_Tools.Method_OY("Lerp", "", "插值", "float");
                    m_Tools.Method_OY("LerpAngle", "", "角度的插值", "float");
                    m_Tools.Method_OY("LerpUnclamped", "", "插值没有限制", "float");
                    m_Tools.Method_OY("Log10", "( float)", "求对数Log10", "float");
                    m_Tools.Method_OY("Round", "( float )", "四舍五入", "float");
                    m_Tools.Method_OY("Sign", "( float )", ">=0 返回 1 ，<0 返回 -1", "");
                    m_Tools.Method_OY("Sqrt", "( float )", "开方", "float");
                    m_Tools.Method_OY("SmoothDampAngle", "", "随着时间的推移逐渐将value转变目标", "");
                    m_Tools.Method_OY("SmoothStep", "", "插值之间min和max平滑的极限", "");
                    m_Tools.Method_OY("MoveTowardsAngle", "", "与LerpAngle类同，但更平滑", "float");
                    m_Tools.Method_OY("IsPowerOfTwo", "( int )", "2次幂", "bool");
                    m_Tools.Method_OY("ClosestPowerOfTwo", "( int )", "返回最接近的2次幂", "int");
                    m_Tools.Method_OY("NextPowerOfTwo", "( int )", "返回下一个2次幂", "int");
                });
            });
        }


        private void DrawScreen()                // Screen 分辨率获取 切换
        {

            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Screen.html");
            m_Tools.BiaoTi_B("Static 属性");
            MyCreate.Box(() =>
            {
                MyCreate.Text("获取信息" + "(只读)".AddGreen());
                m_Tools.Text4_BW("   height ", "高度", "width ", "宽度",30);
                m_Tools.Text4_BW("   currentResolution ", "屏幕分辨率", "dpi ", "屏幕/设备的当前DPI",30);
                m_Tools.Method_BW("resolutions", "", "监视器支持的所有全屏分辨率", "Resolution[]",0);

                MyCreate.Text("四个在自动旋转情况下，是否允许以下旋转".AddHui());
                m_Tools.Method_BL("autorotateToLandscapeRight/Left", "", "是否允许自动右转/左转", "bool",20);
                m_Tools.Method_BL("autorotateToPortrait/UpsideDown", "", "是否允许旋转到竖直/颠倒", "bool", 20);

                MyCreate.Text("可通过此属性切换全屏模式".AddYellow());
                m_Tools.Method_BY("fullScreen", "", "游戏是否全屏运行", "bool", 0);
                MyCreate.Text("可通过此属性防止屏幕变暗".AddYellow());
                m_Tools.Method_BY("sleepTimeout", "", "不操作几秒会变暗", "int", 0);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    通常游戏即使不操作也不能变暗，即代码如下：");
                    m_Tools.Text_H("    Screen.sleepTimeout = SleepTimeout.NeverSleep;");
                });
                MyCreate.Text("可通过此属性修改屏幕的横竖方向".AddYellow());

                m_Tools.Method_BY("orientation", "", "屏幕方向", "ScreenOrientation 枚举", 0);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("Portrait", "竖直",30);
                    m_Tools.TextText_HL("PortraitUpsideDown	", "反向竖直",30);
                    m_Tools.TextText_HL("LandscapeLeft", "竖直 -> 逆时针方向 -> 横屏", 30);
                    m_Tools.TextText_HL("LandscapeRight", "竖直 -> 顺时针方向 -> 横", 30);
                    m_Tools.TextText_HL("AutoRotation", "自动旋转",30);
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YG("SetResolution", "int 宽，int 高，bool 是否全屏", "切换屏幕分辨率","",20);
            });

        }



        #region 少使用工具类



        private void DrawHandheld()              // Handheld 手机专用 
        {
            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BL("PlayFullScreenMovie", "", "播放全屏电影", "");
                m_Tools.Method_BL("Vibrate", "", "触发设备振动", "");

            });
        }

        private void DrawPrefabUtility()         // 对预制体实用工具类
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/PrefabUtility.html", "详情直接看文档");


            m_Tools.BiaoTi_B("Static Properties");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("prefabInstanceUpdated", "", "所有的 Prefab 产生的实例变回预制的属性", "", -50);

            });

            m_Tools.BiaoTi_B("Static Methods");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("DisconnectPrefabInstance", "Object", "断开实例 与 Prefab 的联系");
                m_Tools.Method_BW("GetPrefabType", "Object", "给定的对象返回其预制型", "PrefabType");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_LH("None", "什么都不是", 30);
                    m_Tools.TextText_LH("Prefab", "预制体", 30);
                    m_Tools.TextText_LH("ModelPrefab", "导入的 3D 模型", 30);
                    m_Tools.TextText_LH("PrefabInstance", "预制体的实例对象", 30);
                    m_Tools.TextText_LH("ModelPrefabInstance", "导入的 3D 模型的实例对象", 30);
                    m_Tools.TextText_LH("MissingPrefabInstance", "实例对象 但掉失预制", 30);
                    m_Tools.TextText_LH("DisconnectedPrefabInstance", "实例对象，但该连接断开", 30);
                    m_Tools.TextText_LH("DisconnectedModelPrefabInstance", "3D 模型的实例对象但连接断开", 30);
                });

            });
            MyCreate.AddSpace(5);
            m_Tools.BiaoTi_B("应用例子：" + "（自定义脚本 Prefab 上 一个面板，实例化后显示另一个面板）".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[CustomEditor(typeof(脚本))]");
                m_Tools.Text_H("public class xxx : Editor");
                m_Tools.Text_H("    public override void OnInspectorGUI()");
                m_Tools.TextText_HG("        脚本 a = (脚本) target;", "// target 系统提供的");
                m_Tools.Text_H("        if( PrefabUtility.GetPrefabType(a) == PrefabType.Prefab)");
                m_Tools.Text_G("            // 在 Prefab 上的面板怎么画");
                m_Tools.Text_H("        else ...", "// 实例化的面板怎么画".AddGreen());
            });


        }


        private void DrawGL()                    // GL
        {

            m_Tools.Text_Y("1. 要有 material", "（任何材质）".AddGreen(), "，是对这个 material 进行", "修改".AddGreen());
            m_Tools.Text_Y("2. 通常GL用法是，在camera上贴脚本，并在", "OnPostRender()".AddHui(), "里执行");
            m_Tools.Text_Y("3. 我的用法是：协程-> while 最后一帧", "（WaitForEndOfFrame）".AddHui(), "调用GL");


            MyCreate.Text("下面例子：简单的把 material 图片画在整个屏幕上");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("GL.PushMatrix();", "// 把材质压在堆栈上");
                m_Tools.TextText_HG("GL.LoadOrtho();", "// (固定设置)");
                m_Tools.TextText_HG("GL.LoadIdentity();", "// (固定设置)");
                m_Tools.Text_B("// 在这里修改 Shader 上的属性（material.SetFloat....）");
                m_Tools.TextText_HG("for (var i = 0; i < material.passCount; ++i)", "// 每个 pass都作操作");
                m_Tools.Text_H("｛");
                m_Tools.TextText_HG("     material.SetPass(i);", "// (固定) 设置pass");
                m_Tools.Text_G("    // TRIANGLES", "（三角形）".AddLightGreen(), "、TRIANGLE_STRIP", "（三角形条带）".AddLightGreen());
                m_Tools.Text_G("    // QUADS", "（四边形）".AddLightGreen(), "、LINES", "（线）".AddLightGreen());
                m_Tools.TextText_LG("   GL.Begin(GL.QUADS);", "// 开始 绘制四边形");
                m_Tools.TextText_LG("   GL.TexCoord3(0, 0, 0);", "// 图片左下对应屏幕左下");
                m_Tools.Text_L("   GL.Vertex3(0, 0, 0);");
                m_Tools.TextText_LG("   GL.TexCoord3(0, 1, 0);", "// 图片左上对应屏幕左上");
                m_Tools.Text_L("   GL.Vertex3(0, 1, 0);");
                m_Tools.TextText_LG("   GL.TexCoord3(1, 1, 0);", "// 图片右上对应屏幕右上");
                m_Tools.Text_L("   GL.Vertex3(1, 1, 0);");
                m_Tools.TextText_LG("   GL.TexCoord3(1, 0, 0);", "// 图片右下对应屏幕右下");
                m_Tools.Text_L("   GL.Vertex3(1, 0, 0);");
                m_Tools.TextText_LG("   GL.End();", "// 结束 绘制");
                m_Tools.Text_H("｝");
                m_Tools.TextText_HG("GL.PopMatrix();", "// 堆栈弹出读取该材质");
            });

        }


        private void DrawGUIUtility()            // GUIUtility
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/GUIUtility.html");

            m_Tools.Text_H("不是很懂这个类有什么作用");
            m_Tools.Text_H("就知道这个类有一个很叼的属性");
            AddSpace();

            m_Tools.Method_YB("systemCopyBuffer", "", "访问系统范围的剪贴板", "string");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("即 我能用这个属性 知道 我 Ctrl + C 的内容");
                m_Tools.Text_G("以及修改 Ctrl + C 的内容");


            });

        }


        #endregion



    }

}

