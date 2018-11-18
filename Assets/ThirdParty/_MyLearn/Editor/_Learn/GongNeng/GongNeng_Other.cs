using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class GongNeng_Other : AbstactNewKuang
    {
        [MenuItem(LearnMenu.GongNeng_Other)]
        static void Init()
        {
            GongNeng_Other instance = GetWindow<GongNeng_Other>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            bool isNav = (type == EType.Nva || type == EType.Nva1 || type == EType.Nva2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "NavMesh 导航";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Nva ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Nva);
            }

            if (isNav)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Nva1 ? "  实现物体导航".AddBlue() : "  实现物体导航");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Nva1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Nva2 ? "  导航数据与优化".AddBlue() : "  导航数据与优化");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Nva2);
                }

            }


            MyCreate.AddSpace(20);
            bool isReGenXin = (type == EType.RenGenXin || type == EType.RenGenXin1 || type == EType.RenGenXin2);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "热更新";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.RenGenXin ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.RenGenXin);
            }
            if (isReGenXin)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.RenGenXin1 ? "  数据结构用法".AddBlue() : "  数据结构用法");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.RenGenXin1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.RenGenXin2 ? "  uLua 说明".AddBlue() : "  uLua 说明");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.RenGenXin2);
                }

            }


            MyCreate.AddSpace(20);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "小地图";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XiaoMap ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XiaoMap);
            }


        }


        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Nva:
                    DrawRightPage1(DrawNav);
                    break;
                case EType.Nva1:
                    DrawRightPage3(DrawDaoHang);
                    break;
                case EType.Nva2:
                    DrawRightPage4(DrawDav3);
                    break;
                case EType.RenGenXin:
                    DrawRightPage5(DrawRenGenXin);
                    break;
                case EType.RenGenXin1:
                    DrawRightPage6(DrawShuJuJieGuo);
                    break;
                case EType.RenGenXin2:
                    DrawRightPage7(DrawUlua);
                    break;
                case EType.XiaoMap:
                    DrawRightPage8(DrawXiaoMap);
                    break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.RenGenXin:
                    mWindowSettings.pageWidthExtraSpace.target = -10;

                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -50;
                    break;
            }
        }



        #region 私有
        private void Donw()
        {
            m_Tools.Text_H("     ↓");
        }

        private bool _isFirst, _isTu, _isXing;
        private bool isJieShao, isdefine, isXu;
        private bool _isAdvanced, _isOffMehs, _isOff, _isCheng, _isObs, _isTwo;

        private static readonly string JianTuo = "->".AddHui();

        private enum EType
        {
            Nva,Nva1,Nva2,

            RenGenXin,RenGenXin1, RenGenXin2,

            XiaoMap

        }

        private EType type = EType.Nva;

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
            return "热更新、小地图、导航";
        }


        #endregion


        #region 导航


        private void DrawNav()                                              // NavMesh 导航
        { 
            m_Tools.BiaoTi_O("导航说明");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("基本概念：".AddYellow(), "从一点走到另一点");
                m_Tools.Text_L("需要考虑：".AddYellow(), "阻挡，路径选择，是否可行走，地形特点，行走行为拟人化");
                MyCreate.Text("游戏中常用的导航情况");
                m_Tools.Text_L("AI 角色：".AddYellow(), "纯导航");
                m_Tools.Text_L("主   角：".AddYellow(), " 玩家在 UI 交互控制下的导航");
                MyCreate.Text("导航常用算法");
                m_Tools.Text_L("A*算法：".AddYellow(), "广泛应用于2D格子型地面，最小路径的广度优先搜索");
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("深度优先：".AddWhite() + "见路就走到底，路不通，找上一条分支走到底".AddHui());
                    m_Tools.Text_LG("（优：不需要记全图，只要记走过的路的叉路口）");
                    MyCreate.Text("广度优先：".AddWhite() + "每分支都记一遍，走最近的".AddHui());
                    m_Tools.Text_LG("（优：可以找到最近的路径）");
                });
                m_Tools.Text_L("基于 navegation mesh 寻路算法：".AddYellow(), " A* 算法的变种");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1.将A*算法的格子变成三角形或多边形网格");
                    m_Tools.Text_H("2.可以方便从二维扩展到三维");
                });
                m_Tools.Text_G("Unity 导航就是基于 navegation mesh 导航网格来实现");
            });

            AddSpace_15();
            m_Tools.BiaoTi_O("制作导航网格 " + "(Window -> Navigation)".AddLightGreen(), true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("1. 生成导航网格的东西一定是" + "不能动".AddRed());
                MyCreate.Text("2. 标记成 " + "Navigation Static".AddYellow());
                MyCreate.Text("3. Navigation 面板参数设置" + "（可行走、不可行走、倾斜面等）".AddGreen());
                MyCreate.Text("4. " + "Bake ".AddYellow() + "烘焙，被 Navigation Static 标记的物体就成为了导航网格");
                m_Tools.Text_G("Tip: 一般都不是用模型来做导航网格的，使用 Plane 来做成导航网格");
            });
        }

        private void DrawDaoHang()                                         // 实现物体导航
        {
            m_Tools.BiaoTi_O("1.制作导航网格");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("制作场景 ", JianTuo, " 设定 navmesh static ", JianTuo, " 设定可行走区域 ", JianTuo, " bake");
                m_Tools.Text_Y("考虑那些生成网格：", "直接从场景物体，或者使用虚拟 Collider".AddHui());
            });
            AddSpace_3();
            MyCreate.Window("Bake 参数", () =>
            {
                MyCreate.Text("控制一块导航网络多边形".AddLightBlue());
                m_Tools.TextText_HY("Agent Radius", "导航半径");
                m_Tools.TextText_HY("Agent Height", "导航高度");
                m_Tools.TextText_HY("Max Slope", "最大的上坡能力");
                m_Tools.TextText_HY("Step Height", "台阶高度");
                MyCreate.Text("自动的生成 Off-mesh Links".AddLightBlue());
                m_Tools.TextText_HY("Drop Height", "断层高度");
                m_Tools.TextText_HY("Jump Distance", "断层时可跳高");
                m_Tools.Text("高级", ref _isAdvanced, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_HY("Manual Voxel Size", "需要很精致就确定这个");
                        m_Tools.TextText_HY("MinRegionArea", "最小范围区域");
                        m_Tools.TextText_HY("HeightMesh", "真正的踩在地板上，实实的计算");
                    });

                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("2.使用 NavMeshAgent 实现物体的导航", true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("2.1 物体添加".AddYellow() + " NavMeshAgent ".AddWhite() + "组件" + "(配置移动参数)".AddGreen());
                MyCreate.Text("2.2 导航实现：".AddYellow() + "navMeshAgen.SetDestination( Vector3 目标点 )".AddHui());

            });
            AddSpace();

            m_Tools.BiaoTi_L("Off-mesh Links".AddWhite() + " 实现不连接表面的行走" + "(如跳过悬崖)".AddLightGreen(), ref _isOff, () =>
            {
                MyCreate.Text("如现在有两个不连接的 plane ,实现从一个导航到另一个上");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1. 在两个 plane 设置两个 GameObject，作为传送点");
                    m_Tools.Text_H("2. 选择其中一个添加" + " OffMeshLink".AddWhite() + " 组件" + "(参数展开)".AddLightGreen(), ref _isOffMehs, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_BH("Start", "开始点", -20);
                            m_Tools.TextText_BH("End", "结束点", -20);
                            m_Tools.TextText_BH("Cost Override", "代价，越高，优先选择代价低的路", -20);
                            m_Tools.TextText_BH("BiDirectional", "勾选： 结束点 <-> 开始点", -20);
                            m_Tools.TextText_BH("Activated", "勾选：激活（可代码动态激活）", -20);
                            m_Tools.TextText_BH("AutoUpdatePosition", "传送点是否可以随时更新", -20);
                            m_Tools.TextText_BG("NavigationArea", "标记是否可行走、跳等的标签", -20);
                        });
                    });
                    m_Tools.Text_H("3. 在导航网格的", " Object ".AddGreen(), "把 ", "Generate OffMeshLinks".AddGreen(), " 勾选上");

                    m_Tools.Text_H("4. 烘焙，结果会出现一个连接线");
                });
            });

            AddSpace_3();
            m_Tools.BiaoTi_L("导航网格的" + "层".AddOrange(), ref _isCheng, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("1. 定义层：", "Navigation -> Areas ".AddHui());
                    m_Tools.Text_Y("2. 表达：", "导航的规划、代价".AddHui(), "(Cost越低，优先选择这条路)");
                    MyCreate.Box_Hei(() =>
                    {
                        MyCreate.Text("比如默认的: " + "（都不能少过1）".AddGreen());
                        m_Tools.TextText_BG("   Walkable", "可行走的层，代价为 1", -50);
                        m_Tools.TextText_BG("   NotWalkable", "不可行走的层，实际代价为无限大，不可改", -50);
                        m_Tools.TextText_BG("   Jump", "用作跳的层，代价比可行走的高，为 2", -50);

                    });
                    m_Tools.Text_Y("3. 作用于：", "NavMeshAgent".AddWhite(), " 的 AreaMak", "（可作用的层）".AddGreen());
                    m_Tools.Text_Y("              OffMeshLink".AddWhite(), " 的 NavigationArea", "（传送点用到的层）".AddGreen());
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_L("实现动态导航阻挡" + " NavMeshObstacle".AddWhite() + "(不推荐)".AddLightGreen(), ref _isObs, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("1. 先把包围盒包围全身");
                    m_Tools.Text_L("    Shape", "形状".AddHui(), "   Center/Size", "中心/大小".AddHui());
                    m_Tools.Text_L("    Carve", "就是利用这个属性来动态的修改阻挡".AddGreen());
                    m_Tools.Text_L("2. 把 Crave 打勾，成为阻挡网格");
                    m_Tools.TextText_HG("   MoveThreshold", "大于这个值的移动才重新计算阻挡");
                    m_Tools.TextText_HG("   TimeToStationary", "");
                    m_Tools.TextText_HG("   CarveOnlyStationary", "");
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_L("实现动态导航阻挡其他方式", ref _isTwo, () =>
            {
                AddSpace();
                MyCreate.Window("最好的方法：利用改变层来控制", () =>
                {
                    m_Tools.Text_L("1. 将有可能成为的阻挡物下面加一个 plane");
                    m_Tools.Text_L("2. 通过修改 Navigation Area 网格层来控制是否可行");
                    m_Tools.Text_H("    如：这个是阻挡，导航的AreaMask不了它这个层就行了");
                });
                AddSpace();
                MyCreate.Window("其次：利用射线检测", () =>
                {
                    m_Tools.Text_L("向前发一个胶囊体的射线", "Physics.CapsuleCast".AddWhite());
                });
            });
        }


        private void DrawDav3()                                            // 导航数据与优化
        {
            m_Tools.BiaoTi_L("导出".AddOrange() + "导航网格数据");
            MyCreate.Box(() =>
            {
                MyCreate.Text("用途例如：自己一份，导出去服务器定位一份".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_Y("使用 ", "NavMesh.CalculateTriangulation（）".AddHui());
                    m_Tools.Text_Y("返回 ", "NavMeshTriangulation ".AddHui());
                    MyCreate.Box(() =>
                    {
                        m_Tools.Method_BL("areas", "", "所有层的集合", "int[]", -30);
                        m_Tools.Method_BL("vertices", "", "所有顶点的集合", "Vector3[]", -30);
                        m_Tools.Method_BL("indices", "", "所有索引的集合", "int[]", -30);
                    });
                });
                MyCreate.Text("Tip: 有插件直接可使用：".AddGreen() + " CAINav".AddOrange());
            });
            AddSpace_15();
            m_Tools.BiaoTi_L("关于大型地图导航的" + "优化".AddOrange());
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("为什么：Unity导航是基于A*的广度优先的", "(需要记录全地图)".AddLightGreen());
                m_Tools.Text_W("           当在大地图从一个点导航到另一个点的消耗巨大");
                m_Tools.Text_Y("所以：可以把大地图划分几个小地区，当从这个小区到另一个小区");
                m_Tools.Text_H("    位置 -> 区的记录点 -> 最终区的记录点 -> 再导航到目标点");
            });
        }


        #endregion


        #region 热更新

        private void DrawRenGenXin()                                             // 热更新
        {
            m_Tools.BiaoTi_O("Lua 的执行顺序", ref isXu, () =>
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BG("  Main", "// 主入口", -50);
                        Donw();
                        m_Tools.TextText_BG("  Network." + "Start".AddLightBlue(), "// 网络开始", -50);
                        Donw();
                        m_Tools.TextText_BG("  Game." + "OnInitOk".AddLightBlue(), "// 在这里写逻辑", -50);
                        Donw();
                        m_Tools.TextText_BG("  Ctrl 控制类", "// New、Awake、OnCreate", -50);
                        Donw();
                        m_Tools.TextText_BG("  xxxPanel 视图类", "// Awake、Start", -50);
                    });
                    AddSpace_3();
                    MyCreate.Shu(() =>
                    {
                        AddSpace();
                        AddSpace();
                        MyCreate.Window("Ctrl 与 视图的顺序", () =>
                        {
                            AddSpace();
                            MyCreate.Text("xxCtrl.New".AddHui());
                            Donw();
                            MyCreate.Text("xxCtrl.Awake".AddHui());
                            Donw();
                            MyCreate.Text("xxxPanel.Awake");
                            Donw();
                            MyCreate.Text("xxCtrl.OnCreate".AddHui());
                            Donw();
                            MyCreate.Text("xxPanel.OnCreate");
                            AddSpace();
                        });
                    });

                });

            });
            AddSpace();
            m_Tools.BiaoTi_O("1. 一个C# 类能让 Lua 调用：" + "(以 Ctrl_Audio 播放音乐为例)".AddLightGreen(), true);
            MyCreate.Box(() =>
            {

                m_Tools.TextButton_Open("1. 写上" + " _GT(typeof(Ctrl_Audio)).SetNameSpace(\"PSPUtil\")".AddHui(), () =>
                {
//                    Application.OpenURL(MyComputePath.CustomSettingsPath).;
                });
                m_Tools.TextButton_Open("2. 注入脚本", () =>
                {
                    
                });
                m_Tools.TextButton_Open("3. 在 StaticFunctions 中写好方法 " + "( . 普通方法/ : Ctrl)".AddGreen(), () =>
                {
//                    Application.OpenURL(MyComputePath.StaticFunctionsPath);
                });
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Ctrl_Audio".AddWhite(), " = PSPUtil.Ctrl_Audio;");
                    AddSpace();
                    m_Tools.Text_H("function", " Static_PlayBackground".AddBlue(), "(bgName)");
                    m_Tools.Text_H("     Ctrl_Audio".AddWhite(), ".".AddGreen(), "Instance", ":".AddGreen(), "PlayBackground(bgName)");
                    m_Tools.Text_H("end");
                });
                MyCreate.TextCenter("之后在任意 Lua 中都可以调用播放背景音乐方法：");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Static_PlayBackground".AddBlue(), "(\"Audio / FadeOut\");");

                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("2. 调用 ulua 自带这的方法", true);
            MyCreate.AddSpace(15);
            MyCreate.Window("启动协程下载 txt", () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("coroutine.start(Test_Coroutine)", "// 开始协程");
                });

                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("function Test_Coroutine()");
                    m_Tools.TextText_HG("   coroutine.wait(1)", "//  yield return 1 秒", 15);
                    m_Tools.TextText_HG("   local www = WWW(“网址”)", "//  WWW www =new WWW", 15);
                    m_Tools.TextText_HG("   coroutine.www(www)", "// yield return www", 15);
                    m_Tools.TextText_HG("   print(www.text)", "// 获得返回的结果", 15);
                    m_Tools.Text_H("end");

                });
            });
        }


        private void DrawShuJuJieGuo()                                           // lua 数据结构
        { 
            m_Tools.BiaoTi_Y(" MyList " + "（m_List = MyList:New()  方法使用 : 冒号）".AddHui());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("require".AddWhite() + " \"MyList\"", "// 注入", 20);
                m_Tools.TextText_HG("m_List =" + " MyList".AddLightBlue() + ":" + "New".AddBlue() + "()", "// new 一个对象", 20);
                m_Tools.TextText_HG("m_List:" + "Add".AddBlue() + "(\"value1\");", "// 添加数据", 20);
                m_Tools.TextText_HG("print(m_List" + "[1]".AddBlue() + "));", "// 索引器，从 " + "1".AddRed() + " 开始", 20);
                m_Tools.TextText_HG("m_List:" + "Contains".AddBlue() + "(\"value\")", "// 是否包含这个值", 20);
                m_Tools.TextText_HG("m_List:" + "Count".AddBlue() + "()", "// 集合的总数", 20);
                m_Tools.TextText_HG("(m_List:" + "Remove".AddBlue() + "(\"value\")", "// 删除这个值", 20);
                m_Tools.TextText_HG("m_List:" + "RemoveAt".AddBlue() + "(1)", "// 索引删除，从 " + "1".AddRed() + " 开始", 20);
                m_Tools.TextText_HG("m_List:" + "Clear".AddBlue() + "()", "// 清除", 20);

                AddSpace_3();
                m_Tools.Text_H("function DoAction(value)");
                m_Tools.Text_H("    print(value)");
                m_Tools.Text_H("end");
                m_Tools.TextText_HG("m_List:" + "ForEach".AddBlue() + "(DoAction)", "// 遍历，方法体必须在上面", 20);
            });


            AddSpace();
            m_Tools.BiaoTi_Y("MyDictionary");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("require".AddWhite() + " \"MyDictionary\"", "// 注入", 20);
                m_Tools.TextText_HG("dic =" + " MyDictionary".AddLightBlue() + ":" + "New".AddBlue() + "()", "// new 一个对象", 20);
                m_Tools.TextText_HG("dic:" + "Add".AddBlue() + "(key,value);", "// 添加数据", 20);
                m_Tools.TextText_HG("print(dic" + "[key]".AddBlue() + "));", "// 索引器 ", 20);
                m_Tools.TextText_HG("dic:" + "ContainsKey".AddBlue() + "(key)", "// 是否包含这个key", 20);
                m_Tools.TextText_HG("dic:" + "ContainsValue".AddBlue() + "(value)", "// 是否包含这个value", 20);
                m_Tools.TextText_HG("dic:" + "Count".AddBlue() + "()", "// 集合的总数", 20);
                m_Tools.TextText_HG("(dic:" + "Remove".AddBlue() + "(key)", "// 删除这个键值对", 20);
                m_Tools.TextText_HG("dic:" + "Clear".AddBlue() + "()", "// 清除", 20);
                AddSpace_3();
                m_Tools.Text_H("function DoAction(key)");
                m_Tools.Text_H("    print(key,dic[key])");
                m_Tools.Text_H("end");
                m_Tools.TextText_HG("dic:" + "ForeachKeys".AddBlue() + "(DoAction)", "// 遍历，方法体必须在上面", 20);
            });
        }


        private void DrawUlua()                                                 // ulua
        {
            m_Tools.BiaoTi_O("LuaFramework/lua 目录下的目录介绍", ref isJieShao, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BY("Common", "define全局配置、functions常用函数库、protocal通讯协议", -100);
                    m_Tools.TextText_BY("Controller", "操作数据、控制面板显示", -100);
                    m_Tools.TextText_BY("Logic", "游戏、网络管理器", -100);
                    m_Tools.TextText_BY("System", "用lua重写的unity常用类，目的优化速度，", -100);
                    m_Tools.TextText_BY("View", "面板的视图层，走的是Unity生命周期的事件调用", -100);
                });
            });
            AddSpace_3();

            m_Tools.BiaoTi_O("Lua 文件说明", true);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("define.lua", "全局声明，其他lua脚本直接使用", ref isdefine, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_G("比如" + " Util = LuaFramework.LuaUtil".AddHui());
                        m_Tools.Text_H("之后要使用 C# 的 Util 类就调用 LuaUtil 就行了");
                    });
                });
                m_Tools.TextText_BL("Main.lua", "Lua 程序入口");

            });
            AddSpace_3();
            m_Tools.BiaoTi_O("CS 文件说明", true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("Lua 与 C# 交互 " + "( 两个工具类 )".AddGreen());
                m_Tools.TextText_BL("LuaHelper.cs、Util.cs", "");
                MyCreate.Text("需要配置的类");
                m_Tools.TextText_BL("CustomSetting.cs", "要给Lua用的类都要在这里配置");
            });
            m_Tools.BiaoTi_O("操作");
            m_Tools.Text_W("1.调试把 LuaBundleMode 设为 false，发布改回 true");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("bool LuaBundleMode = false", "// Lua 测试模式，方便调试");
            });
            m_Tools.Text_W("2.Main.lua 的 Main() 调用：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("LuaFramework.Util.Log(\"HelloWorld\") ", "// Lua 调用 LuaUtil 类");

            });
        }

        #endregion

        private void DrawXiaoMap()                               // 小地图
        {
            m_Tools.BiaoTi_B("1. 摄像机方法" + "(渲染场景两次 浪费GPU)".AddLightBlue(), ref _isFirst, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("新建 RenderTexture 放到 Camera 上，实时渲染");
                });

            });
            AddSpace();

            m_Tools.BiaoTi_B("2. 等比转换坐标", true);
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("♦ 小地图 <-> 真实地图 比例关系是多少？");
                m_Tools.Text_L("♦ 人物的坐标在真实地图 <-> 坐标在小地图的对应");
                m_Tools.Text_L("♦ 人物小图标在小地图 <-> 人物在真实地图比例");
            });

            m_Tools.Text_G("1. GUI 右上角放一个 Image 的背景图，子 Image 作为角色图标");
            m_Tools.Text_G("2. 代码图（不太准确）", ref _isTu, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711234714432-2046814331.png");
            });
            AddSpace();
            AddSpace();

            m_Tools.BiaoTi_O("把小地图改成不同形状" + "（正方形 -> 圆形）".AddLightGreen(), ref _isXing, () =>
            {
                m_Tools.Text_Y("原理：", "用一张中间圆形透明，四边黑色的图片".AddWhite());
                m_Tools.Text_W("        叠加在 Shader 上，黑色的部分屏蔽");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("_MainTex(“原黑乎乎”,2D)=“white”");
                    m_Tools.Text_H("_Mask(“遮挡图片”,2D)=“white”");
                    m_Tools.Text_H("_Cutoff(“低于透明度为遮挡”,Range(0,1))=0.1");
                });
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Tags｛“RenderType”=“Transparent”｝");
                    m_Tools.Text_H("LOD 100");
                    m_Tools.Text_H("AlphaTest LEqual[_Cutoff]");
                    m_Tools.Text_L("Pass");
                    m_Tools.Text_H("    SetTexture[_Mask]{ combine texture }");
                    m_Tools.Text_H("    SetTexture[_MainTex]{ combine texture，previous }");
                    m_Tools.Text_H("");


                });
            });

        }



    }

}

