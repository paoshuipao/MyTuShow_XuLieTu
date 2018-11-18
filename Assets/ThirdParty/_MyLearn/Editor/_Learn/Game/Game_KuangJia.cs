using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Game_KuangJia : AbstactNewKuang
    {
        [MenuItem(LearnMenu.ZhiShi_KuangJia)]
        static void Init()
        {
            Game_KuangJia instance = GetWindow<Game_KuangJia>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Frist";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Frist ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Frist);
            }
            AddSpace();


            #region StrangeIoc

            bool isSIOC = (type == EType.StrangeIoc || type == EType.StrangeIoc1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "StrangeIoc";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.StrangeIoc ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.StrangeIoc);
            }

            if (isSIOC)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.StrangeIoc1 ? " 框架图".AddBlue() : " 框架图");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.StrangeIoc1);
                }
            }


            #endregion

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "全单例";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.DanLi ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.DanLi);
            }

            AddSpace();

            #region 组合系统

            bool isString = (type == EType.CeJi || type == EType.CeJi1 || type == EType.CeJi2 || type == EType.CeJi3 || type == EType.CeJi4 || type == EType.CeJi5 || type == EType.CeJi6);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "组合系统";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.CeJi ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.CeJi);
            }
            if (isString)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi1 ? " 角色系统".AddBlue() : " 角色系统");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi2 ? " 技能系统".AddBlue() : " 技能系统");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi3 ? " 关卡系统".AddBlue() : " 关卡系统");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi4 ? " 数据控制系统".AddBlue() : " 数据控制系统");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi5 ? " UI 系统".AddBlue() : " UI 系统");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.CeJi6 ? " 剧情设计".AddBlue() : " 剧情设计");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.CeJi6);
                }
            }

            #endregion

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "GOAP";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.GOAP ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.GOAP);
            }



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Frist:        DrawRightPage1(DrawFirst);         break;
                case EType.StrangeIoc:   DrawRightPage3(DrawStrange);       break;
                case EType.StrangeIoc1:  DrawRightPage(DrawStrangeIocTu);   break;
                case EType.DanLi:        DrawRightPage3(DrawDanLi);         break;
                case EType.CeJi:         DrawRightPage4(DrawZhongJie);      break;
                case EType.CeJi1:        DrawRightPage5(DrawJieSeSystem);   break;
                case EType.CeJi2:        DrawRightPage6(DrawJiNentSystem);  break;
                case EType.CeJi3:        DrawRightPage7(DrawSceneSystem);   break;
                case EType.CeJi4:        DrawRightPage8(DrawDataSystem);    break;
                case EType.CeJi5:        DrawRightPage4(DrawUI);            break;
                case EType.CeJi6:        DrawRightPage8(DrawJuQin);         break;
                case EType.GOAP:         DrawRightPage1(DrawGOAP);          break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -30;
                    break;
            }
        }



        #region 私有
        private enum EType
        {
            Frist,
            StrangeIoc,StrangeIoc1,
            DanLi,

            CeJi,CeJi1,CeJi2,CeJi3,CeJi4,CeJi5,CeJi6,

            GOAP

        }

        private bool isFSM01, isFSM02;
        private EType type = EType.CeJi;

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
            return "框架思考";
        }


        #endregion



        private void DrawStrange()                                   // StrangeIoc
        {
            MyCreate.Heng(() =>
            {
                MyCreate.FenGeXian("    代码托管在 github", () =>
                {
                    Application.OpenURL("https://github.com/strangeIoc/strangeioc");
                });
                MyCreate.AddSpace();
                MyCreate.FenGeXian("使用文档    ", () =>
                {
                    Application.OpenURL(@"E:\Pro\PSPFramework\插件\.docs\index.html");
                });
            });
            m_Tools.Text_H("直接在 AssetStore 导入插件,毕竟免费");


        }

        private void DrawStrangeIocTu()
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180712090720683-996819154.png");
        }




        private void DrawFirst()                                     // First
        {
            m_Tools.Text_B("Level Manager");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("使用一配置文件 来记录每个 Level ");
                m_Tools.Text_L("只提供一个 NextLevel 的方法");
                m_Tools.Text_L("同时控制跳转时的特效");
                m_Tools.Text_L("可以看看 Mad Level Manager 这个插件");
            });
            m_Tools.Text_B("Pool Manager");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("每个 Perfab 对一个 Pool ，控制 pool 最多数量");
                m_Tools.Text_L("就是不是无限加进池子中，当超过数量就删除");

            });
            m_Tools.Text_B("Save Manager");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("推荐使用 Easy Save2 插件，它用二进制存储");
            });

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("mvcs 用反射比下面慢，没界面，免费");
                m_Tools.Text_L("MVVM UFRAME 可视化框架，收费，快");
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("Published by unity 测试工具");
                m_Tools.Text_L("Unity test /Integration test /Assertion component");
            });



        }

        private void DrawDanLi()                                     // 全单例
        {

        }

        #region 组合系统


        private void DrawJieSeSystem()                           // 角色系统
        {
            m_Tools.Text_Y("1. 角色应该是", "基于组件".AddGreen(), "的设计，需要那个组件就添加上");
            m_Tools.Text_Y("2. ", "上下、相邻层次".AddGreen(), "才能访问，比如", " 技能信息可以访问角色信息".AddHui());
            m_Tools.BiaoTi_Y("角色基类通过 " + "RequireComponent ".AddHui() + "来添加对应的功能组件");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("             ─── [ ", "挂载了就有动画".AddBlue(), " ] ");
                m_Tools.Text_L("             ─── [ ", "挂载了就有血条".AddBlue(), " ] ");
                m_Tools.Text_L("             ─── [ ", "有 HP、MP、防御这些属性".AddBlue(), " ] ");
                m_Tools.Text_L("             ─── [ ", "挂载了就有阴影".AddBlue(), " ] ");
                MyCreate.Text(("角色Base     ─── [" + " 角色信息".AddBlue() + " ] ").AddLightBlue());
                m_Tools.Text_L("             ─── [ ", "技能信息".AddBlue(), " ] ");
                m_Tools.Text_L("             ─── [ ", "装备信息".AddBlue(), " ] ");
                m_Tools.Text_L("             ─── [ ", "攻击到这角色就触发动画".AddBlue(), " ] ");
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("             继承".AddWhite(), " ─ 角色Base ");
                m_Tools.Text_L("             ─── [ ", "物理 ".AddBlue(), "] ");
                m_Tools.Text_L("             ─── [ ", "上下左右移动".AddBlue(), " ] ");
                MyCreate.Text(("Player        ─── [" + " 技能连招，触发buff ".AddBlue() + " ] ").AddLightBlue());
                m_Tools.Text_L("             ─── [ ", "动画控制".AddBlue(), " ] ");
                m_Tools.Text_W("             实现" + " ─  注册FSM 空闲、移动、战斗、死亡、眩晕等状态".AddHui(), ref isFSM01, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_OY("Idle状态", "1.空闲动画  2.检测摇杆输入", -100);
                        m_Tools.TextText_OY("Move状态", "1.移动动画  2.读取移动值  3.控制移动与转向", -100);
                        m_Tools.TextText_OY("Dead状态", "1.死亡动画  2.发送死亡事件通知", -100);
                        m_Tools.Text_O("晕眩、战斗、跳跃等、发技能等状态");

                    });
                });

            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("             继承".AddWhite(), " ─ 角色Base ");
                MyCreate.Text(("怪物           ─── [" + " AI 找到最近的敌人 ".AddBlue() + " ] ").AddLightBlue());
                m_Tools.Text_W("             实现" + " ─  注册FSM  空闲、追向、战斗、死亡等状态".AddHui(), ref isFSM02, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_OY("Idle状态", "1.空闲动画  2.检测玩家是否进入攻击范围", -100);
                        m_Tools.TextText_OY("LookAt状态", "1.追向动画  2.追向玩家", -100);
                        m_Tools.TextText_OY("Fight状态", "1.攻击动画  2.攻击  3.发技能", -100);
                        m_Tools.TextText_OY("Dead状态", "1.死亡动画  2.发送死亡事件通知", -100);
                        m_Tools.Text_O("晕眩、逃跑状态、被攻击等状态");

                    });
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_Y("角色状态机设计");
            MyCreate.Box(() =>
            {
                MyCreate.Text("状态机控制：1." + "注册状态机".AddGreen() + " 2." + "状态切换".AddGreen());
                m_Tools.Text_L("状态机控制Base  衍生─── ", "玩家状态机控制、怪物状态机控制".AddWhite());
                m_Tools.Text_L("                     衍生─── ", "Boss状态机控制、NPC状态机控制".AddWhite());
                AddSpace_3();
                MyCreate.Text("状态机：1." + "进入状态做什么".AddGreen() + " 2." + "退出状态做什么".AddGreen() + " 3." + "在状态做什么".AddGreen());
                m_Tools.Text_L("状态机Base  衍生─── ", "Idle状态".AddWhite(), "    衍生─── ", "玩家Idle、怪物Idle ...".AddWhite());
                m_Tools.Text_L("                衍生─── ", "Jump状态".AddWhite(), "  衍生─── ", "玩家Jump、NPCJump".AddWhite());
                m_Tools.Text_L("                衍生─── ", "Skill状态".AddWhite(), "    衍生─── ", "玩家Skill、怪物Skill".AddWhite());

            });
        }

        private void DrawJiNentSystem()                          // 技能系统
        {
            MyCreate.Tests("树状配置结构".AddBlue(), "：解决", "配置复杂性".AddHui() + "与", "大量数据".AddHui());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("                 ─── 触发的事件", " （开始、技能命中、子弹命中）".AddWhite());
                m_Tools.Text_L("                 ─── 添加某个buff");
                MyCreate.Text("技能整体配置    " + "─── 播放某个粒子效果".AddLightBlue());
                m_Tools.Text_L("                 ─── 攻击范围");
                m_Tools.Text_L("                 ─── 带动玩家滞后或后摇");
                m_Tools.Text_L("                 ─── 镜头震动");

            });
            MyCreate.Tests("技能状态机".AddBlue(), "：解决", "运行时复杂性".AddHui(), "，将", "技能伤害、判定、方式".AddHui(), " 等元素分离");
        }

        private void DrawSceneSystem()                           // 关卡系统
        {
            m_Tools.BiaoTi_Y("编辑关卡：");
            m_Tools.Text_L("场景静态元素：", "墙壁、地板、灯等游戏装饰物".AddWhite());
            m_Tools.Text_L("场景动态元素：", "怪物、机关可以和玩家发生交互的对象".AddWhite());
            m_Tools.Text_L("场景设计：：", "1.", "关卡风格、怪物、机关".AddWhite(), "  2. ", "奖励物品".AddWhite(), " 等");
            AddSpace_3();
            m_Tools.BiaoTi_Y("关卡运行时：");
            m_Tools.Text_L("1. 读取配置表和关卡配置结构");
            m_Tools.Text_L("2.  • 主 Camera 初始化");
            m_Tools.Text_L("    • 剧情");
            m_Tools.Text_L("    • 怪物生产与管理");
            m_Tools.Text_L("    • 关卡流式加载器");
        }

        private void DrawDataSystem()                            // 数据控制系统
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("分类：", " 静态数据".AddBlue(), "(怪物攻击力)".AddHui(), "    动态数据".AddBlue(), "(玩家HP)".AddHui());
                m_Tools.Text_Y("来源：", " 网络同步数据".AddBlue(), "(其他玩家的血量)".AddHui());
                m_Tools.Text_B("         配置表的数据", "(怪物信息)".AddHui());
                m_Tools.Text_B("         客户端临时计算数据", "(玩家的当前位置)".AddHui());
                m_Tools.Text_Y("是否序列化：", "如玩家当前位置需要序列化,通过网络传输到其他玩家".AddHui());
            });
            AddSpace();
            MyCreate.Window("采用多层结构来设计", () =>
            {
                m_Tools.Text_L("             ─── 道具数据", "  ──静态配置数据".AddWhite());
                MyCreate.Text("角色属性      " + "─── 技能数据".AddLightBlue() + "  ──静态配置数据".AddWhite());
                m_Tools.Text_L("             ─── 装备数据", "  ──静态配置数据".AddWhite());
                AddSpace_3();
                m_Tools.Text_W("excel 表 ──> 直接转成 C# 代码的 " + "dll".AddGreen());
            });
        }


        private void DrawUI()                                    // UI 系统
        {
            MyCreate.Window("MVC 模式", () =>
            {
                m_Tools.Text_W("_____________________ 事件 _____________________");
                m_Tools.Text_W("↓                                                                        ↑");
                m_Tools.Text_W("View（子View1、子View1） ──> DataController ──> 装备数据 ");
                AddSpace_3();
                m_Tools.Text_L("View2 ──> XXXController ");
            });
            AddSpace();
            MyCreate.Window("UI 管理", () =>
            {
                m_Tools.Text_L("1. 根据堆栈一层层打开/关闭");
                m_Tools.Text_L("2. 添加蒙版挡住下面 UI");
            });
        }



        private void DrawJuQin()                                 // 剧情设计
        {
            m_Tools.Text_B("剧情需求");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("▪ 在进入特定场景");
                m_Tools.Text_L("▪ 特定条件下");
                m_Tools.Text_L("▪ 触发特定的对话 或者NPC动作或者其它行为");
                m_Tools.Text_L("▪ 剧情触发完成，改变系统某些状态变量");
            });
            AddSpace();
            m_Tools.Text_B("核心设计思路");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("▪ 每个场景需要一个自己的剧情管理器");
                m_Tools.Text_L("▪ 其它NPC系统，战斗系统需要提供对剧情的支持");
                m_Tools.Text_L("▪ 剧情需要通过事件系统来驱动");
                m_Tools.Text_L("▪ 剧情内部的组织需要通过协程来控制");
            });

        }


        private void DrawZhongJie()                              // 总结
        {

            m_Tools.BiaoTi_Y("拿个怪物来说");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("就加一个怪物组件,在面板上设置它的参数".AddGreen());
                m_Tools.Text_L("数据就从 dll 那里取");
                m_Tools.Text_L("其他组件使用 AddComponent 自动添加进来");
                m_Tools.Text_L("    比如 血条、动画控制、移动命令、状态机等等");
                m_Tools.Text_L("    发事件过，它在 就响应");

            });


        }



        #endregion



        private void DrawGOAP()
        {
            m_Tools.Text_G("GOAP (目标导向型行动计划)的说明");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("G", "Goal", "打什么怪", "目标");
                m_Tools.Method_BL("O", "Oriented", "怎么打", "导向、规则");
                m_Tools.Method_BL("A", "Action", "去打", "行动");
                m_Tools.Method_BL("P", "Planning", "走那条路，选择最优", "计划");
            });

            m_Tools.Text_G("演示版本");
            MyCreate.Box(() =>
            {
                m_Tools.TextUrl("GOAP 说明文档".PadLeft(55), MyComputePath.GOAPUrl);
                m_Tools.TextText_BL("矿工", "获得矿石、需要工具（会消耗）、", -60);
                m_Tools.TextText_BL("樵夫", "获得原木、需要工具（会消耗）", -60);
                m_Tools.TextText_BL("伐木工", "获得木头、需要原木、工具（会消耗）", -60);
                m_Tools.TextText_BL("铁匠", "产生工具、需要木头、矿石", -60);


            });
        }


    }

}

