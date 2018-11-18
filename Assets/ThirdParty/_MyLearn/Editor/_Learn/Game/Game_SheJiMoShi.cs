using System;
using Ez;
using JetBrains.Annotations;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Game_SheJiMoShi : AbstactNewKuang
    {
        [MenuItem(LearnMenu.ZhiShi_SheJiMoShi)]
        static void Init()
        {
            Game_SheJiMoShi instance = GetWindow<Game_SheJiMoShi>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "设计原则";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.YuanZe ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.YuanZe);
            }
            MyCreate.Text("创建型");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "工厂模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Create1 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Create1);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "建造者模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Create3 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Create3);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "创建其他";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Create4 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Create4);
            }

            AddSpace_3();
            MyCreate.Text("结构型");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "装饰模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JieGuo1 ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JieGuo1);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "结构其他";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JieGuo2 ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JieGuo2);
            }


            AddSpace_3();
            MyCreate.Text("行为型");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "策略模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XingWei1 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XingWei1);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "观察者模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XingWei2 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XingWei2);
            }

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "状态模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XingWei3 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XingWei3);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "职责链模式";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XingWei4 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XingWei4);
            }
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "行为其他";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XingWei5 ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XingWei5);
            }






        }

        protected override void DrawRight()
        {

            switch (type)
            {
                case EType.YuanZe:
                    DrawRightPage8(DrawShejiMoShi);
                    break;
                case EType.Create1:
                    DrawRightPage1(DrawGongChang);
                    break;
                case EType.Create3:
                    DrawRightPage5(DrawJianZaoZhe);
                    break;
                case EType.Create4:
                    DrawRightPage3(DrawCreateOther);
                    break;
                case EType.JieGuo1:
                    DrawRightPage4(DrawZhuang);
                    break;
                case EType.JieGuo2:
                    DrawRightPage4(DrawJiGuoOther);
                    break;
                case EType.XingWei1:
                    DrawRightPage6(DrawCheLue);
                    break;
                case EType.XingWei2:
                    DrawRightPage7(DrawGuang);
                    break;
                case EType.XingWei3:
                    DrawRightPage8(DrawState);
                    break;
                case EType.XingWei4:
                    DrawRightPage6(DrawZhiZhe);
                    break;
                case EType.XingWei5:
                    DrawRightPage7(XingWeiOther);
                    break;
            }

        }


        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Create1:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.Create3:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.XingWei2:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.XingWei3:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.XingWei4:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
            }
        }

        #region 私有
        private bool isFSM01, isFSM02, isUML, isTuiJian;
        private bool isUML1;

        private static readonly string JianLiStr = "简历类".AddBlue();
        private static readonly string GongJiLie = "工厂基类".AddYellow();
        private static readonly string GongLie = "工厂类".AddYellow();
        private static readonly string JianGongLie = "建造工厂类".AddYellow();
        private static readonly string CreateStr = "Create功能()".AddWhite();
        private static readonly string GongNeng = "功能基类".AddBlue();
        private static readonly string gAStr = "(“功能A的工厂”)".AddRed();
        private static readonly string gaStr = "功能A".AddRed();
        private static readonly string gnmcStr = "功能名称".AddLightBlue();
        private static readonly string Lie = "类".AddBlue();
        private static readonly string PersonStr = "Person ".AddYellow();
        private static readonly string FuStr = "服饰类".AddBlue();
        private static readonly string ShowStr = "Show()".AddWhite();
        private static readonly string m_PersonStr = "m_Person".AddLightBlue();
        private static readonly string OnUpdateStr = "OnUpdate()".AddLightBlue();
        private static readonly string AddStr = "Add".AddWhite();
        private static readonly string NotifyStr = "Notify()".AddWhite();
        private static readonly string JianTinStr = "接口监听类".AddBlue();
        private static readonly string TongZhiStr = "抽象通知者类".AddYellow();
        private static readonly string StateA = "状态A".AddRed();
        private static readonly string XunFaStr = "算法基类".AddBlue();
        private static readonly string EnumState = "Enum状态".AddLightBlue();
        private static readonly string EnumHandler = "Handler".AddLightBlue();
        private static readonly string CheLieStr = "策略类".AddYellow();
        private static readonly string StateJiLie = "状态基类".AddYellow();
        private static readonly string ChuLiiLie = "处理基类".AddYellow();
        private static readonly string StateGLStr = "状态管理者".AddBlue();
        private static readonly string ZhiZheStr = "职责链类".AddBlue();
        private static readonly string ShuanFaA = "“算法A”".AddRed();
        private static readonly string GetResultStr = " 计算算法()".AddWhite();
        private static readonly string StateWhat2DoStr = " 状态要做什么()".AddWhite();
        private static readonly string DealDoStr = "处理事件".AddWhite();

        private enum EType
        {
            YuanZe,
            Create1,Create3,Create4,
            JieGuo1,JieGuo2,
            XingWei1,XingWei2,XingWei3,XingWei4,XingWei5,
        }

        private EType type = EType.YuanZe;

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
            return "设计模式";
        }




        private void MoBan([NotNull]Action dongJi, [NotNull]Action daiMa, [NotNull]Action zhongJie)
        {
            m_Tools.BiaoTi_L("动机、意图、何时用");
            MyCreate.Box(dongJi);
            AddSpace();
            m_Tools.BiaoTi_L("实例代码：");
            daiMa();
            AddSpace();
            m_Tools.BiaoTi_L("总结");
            MyCreate.Box(zhongJie);
        }

        #endregion



        private void DrawShejiMoShi()                            // 设计模式原则
        {
            m_Tools.BiaoTi_Y("在项目可以使用到的设计模式例子：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_BL("计算伤害" + "(如传入”暴击“或者”正常“ 返回 -> 对应结果) ".AddWhite(), "策略模式", 150);
                m_Tools.TextText_BL("游戏每个状态" + "（比如角色的跑、攻击、死状态） ".AddWhite(), "状态模式", 150);
                m_Tools.TextText_WL("(例如 有多个角色 有多把武器，一个角色对一把武器 ) ", "桥接模式", 150);
                m_Tools.TextText_BL("1.产生UI 2.产生敌人对象 3.产生武器对象", "抽象工厂模式", 150);
                m_Tools.TextText_BL("对角色加属性、加武器、加装备 ", "建造者模式", 150);
                m_Tools.TextText_BL("关卡设计 " + "可以使用".AddHui(), "职责链模式", 150);
                m_Tools.TextText_BL("如果 Bean 需要多份 ", "原型模式", 150);
                m_Tools.TextText_HL("插件".AddBlue() + "的引用使用一个类整理它使用", "外观模式", 150);
                m_Tools.TextText_BL("插件想使用接口", "适配器模式", 150);
                m_Tools.TextText_HL("所有 " + "Manager".AddBlue() + " -> 使用 ", "单例模式", 150);
                m_Tools.TextText_HL("框架使用事件分发的 ", "中介模式", 150);
            });

            m_Tools.BiaoTi_Y("六大原则");
            MyCreate.Box(() =>
            {
                MyCreate.Text("开放-封闭原则".AddBlueBold() + "    （类、模块、函数等）应该" + "可以扩展".AddGreen() + "，但" + "不可修改".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1.对于扩展是开放的   2.对于更改是封闭的");
                    m_Tools.Text_G("    面对需求，对程序的改动是通过增加新的代码进行的，而不是更改现有的代码");
                    m_Tools.Text_R("    就是现在游戏搞掂了，要增加一个英雄，不应该修改原代码，只增加代码即可");
                });
                AddSpace_3();
                MyCreate.Text("依赖倒转原则".AddBlueBold() + "    抽象不应该依赖细节，细节应该依赖抽象");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("    针对接口编程，不要对实现编程");
                    m_Tools.Text_G("    程序中所有的依赖关系都是终止于抽象或者接口 -> 即面向对象的设计");
                    m_Tools.Text_R("    就是这个类如果要依赖其他类，不要依赖实现类，依赖抽象/接口 类");
                });
                AddSpace_3();
                MyCreate.Text("里氏代换原则".AddBlueBold() + "    子类型必须能够替换掉它们的父类型");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    高层调用接口，低层继承接口，谁都不依赖谁");
                    m_Tools.Text_R("    就是现在用父类，如果用尝试子类替换掉，完全O jb K的没问题");
                });
                AddSpace_3();
                MyCreate.Text("单一职责原则".AddBlueBold() + "    一个类，应该仅有一个引起它变化的原因");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_R("    就是这个类的状态发生了变化，真相只有一个，凶手是唯一的它搞的");
                });
                AddSpace_3();
                MyCreate.Text("合成复用原则".AddBlueBold() + "    尽量使用对象组合，而不是继承来达到复用的目的");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_R("    就是 这个都使用的功能 使用组合比写在父类好，因为写在父类很难再改了");
                });
                AddSpace_3();
                MyCreate.Text("迪米特法则".AddBlueBold() + "    如果两个类不必彼此直接通信，则不应发生相互作用");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_R("    就是 这个类改了，其他类会说：改了就改了叭，关我 P 事");
                });
            });


            AddSpace();
            m_Tools.BiaoTi_B("UML图示例", ref isUML, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709223302878-1093025530.png",15);
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("+/#/-", "public/protected/private");
                    m_Tools.TextText_BL("空心三角形+虚线", "实现接口");
                    m_Tools.TextText_BL("实线箭头", "关联");
                    m_Tools.TextText_BL("聚合关系", "相当于数组");
                    m_Tools.TextText_BL("组合关系", "一个类有几个对应实例");
                    m_Tools.TextText_BL("依赖关系", "表示用到这些类");
                });
            });

            AddSpace();
            m_Tools.BiaoTi_B("设计模式书籍推荐", ref isTuiJian, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("《设计模式与完美游戏开发》");
                    m_Tools.Text_Y("《设计模式 可复用面向对象软件的基础》");
                    m_Tools.Text_Y("《Head First 设计模式（中文版）》");
                });
            });
            AddSpace();


            m_Tools.BiaoTi_B("设计模式23种",ref isFSM01, () =>
            {
                m_Tools.TextUrl("  [ 单例模式(Singleton Pattern) ]", "http://www.cnblogs.com/abcdwxc/archive/2007/08/28/873342.html");
                m_Tools.TextUrl("  [ 抽象工厂（Abstract Factory）  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/08/29/874891.html");
                m_Tools.TextUrl("  [ 工厂方法模式（Factory Method)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/08/31/876994.html");
                m_Tools.TextUrl("  [ 建造者模式(Builder)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/08/30/876133.html");
                m_Tools.TextUrl("  [ 原型模式(Prototype)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/03/879936.html");
                AddSpace();
                m_Tools.TextUrl("  [ 适配器模式（Adapter Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/04/881674.html");
                m_Tools.TextUrl("  [ 桥接模式（Bridge Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/05/882918.html");
                m_Tools.TextUrl("  [ 装饰模式(Decorator Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/06/884495.html");
                m_Tools.TextUrl("  [ 组合模式(Composite Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/07/885951.html");
                m_Tools.TextUrl("  [ 外观模式（Facade Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/11/889542.html");
                m_Tools.TextUrl("  [ 享元模式(Flyweight Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/12/890556.html");
                m_Tools.TextUrl("  [ 代理模式(Proxy Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/13/891638.html");
                AddSpace();
                m_Tools.TextUrl("  [ 模板方法(Template Method)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/14/892726.html");
                m_Tools.TextUrl("  [ 命令模式(Command Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/17/896195.html");
                m_Tools.TextUrl("  [ 迭代器模式(Iterator Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/18/896829.html");
                m_Tools.TextUrl("  [ 观察者模式(Observer Pattern）  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/19/898856.html");
                m_Tools.TextUrl("  [ 解释器模式(Interpreter Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/20/900264.html");
                m_Tools.TextUrl("  [ 中介者模式(Mediator Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/24/904253.html");
                m_Tools.TextUrl("  [ 职责链模式(Chain of Responsibility Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/25/905622.html");
                m_Tools.TextUrl("  [ 备忘录模式(Memento Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/26/906636.html");
                m_Tools.TextUrl("  [ 策略模式(Strategy Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/27/908190.html");
                m_Tools.TextUrl("  [ 访问者模式(Visitor Pattern)  ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/28/909482.html");
                m_Tools.TextUrl("  [ 状态模式(State Pattern) ]", "http://www.cnblogs.com/abcdwxc/archive/2007/09/29/910726.html");

            });

        }



        //——————————————————创建——————————————————

        private void DrawJianZaoZhe()                            // 建造者模式
        {
            MyCreate.Text("建造者模式与工厂模式结合：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public class ", JianGongLie);
                m_Tools.Text_H("     private static string ", gnmcStr, " =“", gaStr, "”");
                m_Tools.Text_H("     public static ", GongNeng, " ", CreateStr);
                m_Tools.Text_H("          AssemblyName name = Assembly.GetExecutingAssembly().GetName()");
                m_Tools.Text_H("          ", GongNeng, " g =", "(", GongNeng, ") Assembly.Load(name).CreateInstance(", gnmcStr, ")");
                m_Tools.Text_H("          g.", "加属性()".AddWhite());
                m_Tools.Text_H("          g.", "加武器()".AddWhite());
                m_Tools.Text_H("          g.", "加装备()".AddWhite());
                m_Tools.Text_H("          return g");
            });

            MyCreate.Text("实际的功能实现类，要做什么功能就在子类实现");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public abstract class ", GongNeng);
                m_Tools.Text_H("     public abstract void ", "加属性()".AddWhite());
                m_Tools.Text_H("     public abstract void ", "加武器()".AddWhite());
                m_Tools.Text_H("     public abstract void ", "加装备()".AddWhite());
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public class ", gaStr, " : ", GongNeng, " { ", "实现加属性、加武器、加装备".AddWhite(), " } ");
                m_Tools.Text_H("public class 功能B : ", GongNeng, " { ", "实现加属性、加武器、加装备".AddWhite(), " } ");
            });
            MyCreate.Text("客户端只需要改变 " + gnmcStr + " 里面的类名称即可");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG(GongNeng + " g = " + JianGongLie + "." + CreateStr, "// 工厂类已经是 Static 方法");
            });


        }

        private void DrawChuXiang()                              // 抽象工厂模式
        {
            m_Tools.BiaoTi_B("抽象工厂模式");
            MyCreate.Text("客户端只需要和" + GongLie + "打交道，不会与实际实现类有任何交互");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public class ", GongLie);
                m_Tools.Text_H("     private static string ", gnmcStr, " =“", gaStr, "”");
                m_Tools.Text_H("     public static ", GongNeng, " ", CreateStr);
                m_Tools.Text_H("          AssemblyName name = Assembly.GetExecutingAssembly().GetName()");
                m_Tools.Text_H("          return (", GongNeng, ") Assembly.Load(name).CreateInstance(", gnmcStr, ")");
            });

            MyCreate.Text("实际的功能实现类，要做什么功能就在子类实现");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public abstract class ", GongNeng, " { ... } ");
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public class ", gaStr, " : ", GongNeng, " { ... } ");
                m_Tools.Text_H("public class 功能B : ", GongNeng, " { ... } ");
            });
            MyCreate.Text("客户端只需要改变 " + gnmcStr + " 里面的类名称即可");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG(GongNeng + " g = " + GongLie + "." + CreateStr, "// 工厂类已经是 Static 方法");
            });
            m_Tools.BiaoTi_L("总结");
            MyCreate.Box(() =>
            {
                m_Tools.Text_R("简单好用，易扩展,功能名称甚至可以" + "使用配置文件/枚举".AddGreen() + "来解决");

            });
        }


        private void DrawGongChang()                             // 工厂模式
        {
            m_Tools.BiaoTi_B("工厂模式");
            MoBan(() =>
            {
                m_Tools.Text_R("比如一开始用这个功能类 A，过段时间又要用相同结构的功能类 B，或者再来个 C");
                m_Tools.Text_W("隔离”这个易变对象“的变化，保持”其它依赖的对象“不随需求的变化而变化");
            }, () => {
                MyCreate.Text("客户端就和工厂类打交道，不会与实际实现类有任何交互");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public abstract class ", GongJiLie);
                    m_Tools.Text_H("     public abstract 功能基类 ", CreateStr);
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class", " 功能A的工厂".AddRed(), ": ", GongJiLie);
                    m_Tools.Text_H("    public override 功能基类 ", CreateStr);
                    m_Tools.Text_H("        return new 功能A();");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class 功能B的工厂 : ", GongJiLie);
                    m_Tools.Text_H("    public override 功能基类 ", CreateStr);
                    m_Tools.Text_H("        return new 功能B();");

                });
                MyCreate.Text("实际的功能实现类，要做什么功能就在子类实现");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public abstract class ", GongNeng, " { ... } ");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class 功能A : ", GongNeng, " { ... } ");
                    m_Tools.Text_H("public class 功能B : ", GongNeng, " { ... } ");
                });
                MyCreate.Text("客户端只需要改变 方法名" + gAStr + " 即可改变对应的功能");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("AssemblyName name = Assembly.GetExecutingAssembly().GetName()");
                    m_Tools.Text_H(GongJiLie, " f = (", GongJiLie, ") Assembly.Load(name).CreateInstance", gAStr);
                    m_Tools.Text_H(GongNeng, " g = f.", CreateStr);
                    m_Tools.Text_G("// 这时的”g“已经是想要的类了,想调用那个方法就调用那个方法叭");
                });
            }, () =>
            {
                MyCreate.Text("1. 工厂模式 -> 利用工厂 -> 创建想要的对象");
                MyCreate.Text("2. 如增加一个 C 功能类并使用：增加功能C的工厂、功能C、客户端调用”功能C的工厂“".AddRed());
                MyCreate.Text("   优点:原来的功能代码不需要更改，隔离了使用者和具体类型之间的耦合关系");
                MyCreate.Text("   缺点：每加一个功能就需要加一个功能的工厂类");
            });
            AddSpace_3();
            m_Tools.BiaoTi_L("UML 图", ref isUML1, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709223754285-530795452.png");
            });
            AddSpace();

            DrawChuXiang();




        }


        private void DrawCreateOther()                           // 创建其他
        {
            m_Tools.BiaoTi_B("单例模式");
            m_Tools.Text_B("单例与 static 类的区别");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("   单例类", "     Static 工具类");
                m_Tools.TextText_OY("有状态", "不保存状态");
                m_Tools.TextText_OY("都能使用", "仅提供一些静态方法或静态属性来使用");
                m_Tools.TextText_OY("可以有子类继承，能多态", "不可继承多态");
                m_Tools.TextText_OY("唯一的对象实例", "只不过是一些方法属性的集合");
            });
            m_Tools.Text_B("优点");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("只需要一个实例对象，全局唯一的访问点，不多创建，易删除，易使用");
            });
            m_Tools.Text_B("缺点");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("1. 单例模式扩展很困难，若要扩展，除了修改代码基本上没有第二种途径可以实现");
                m_Tools.Text_H("2. 单例类的职责过重，在一定程序上违背了”单一职责原则“");
                m_Tools.Text_H("3. 滥用单例，一样是动一发而改全身的情况");
                m_Tools.Text_R("4. 所以我认为 除了 Manager 管理类用，其他情况都不要用比较好");
            });



            AddSpace();
            m_Tools.BiaoTi_B("原型模式");
            MoBan(() =>
            {
                m_Tools.Text_R("从一个对象再创建另外一个可定制的对象，而且不需要知道任何创建细节");
            }, () =>
            {
                MyCreate.Text("例如现在要多份的简历类，创建过程都是相同的".AddBold());
                MyCreate.FenGeXian_Blue("简历类 继承 ICloneable，拥有拷贝功能");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("class ", JianLiStr, " ：", "ICloneable".AddYellow());
                    m_Tools.Text_H("     private string name,sex");
                    m_Tools.Text_B("     构造函数 -> 需要 name ,sex ");
                    m_Tools.Text_H("     public void ", "Show".AddWhite(), "(string des){ ... }");
                    AddSpace_3();
                    m_Tools.TextText_YG("     public Object Clone()", "  // ICloneable 接口提供", 110);
                    m_Tools.TextText_YG("         return (Object)this.MemberwiseClone()", "// 弱复制");

                });
                MyCreate.FenGeXian_Blue("客户端 多份简历就不需要一份一份重复地 new 了");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("void Main");
                    m_Tools.Text_H("     ", JianLiStr, " 简历1 = new ", JianLiStr, "(名，性别)", "        // 只需要 new 一次".AddGreen());
                    m_Tools.Text_H("     简历1.", "Show".AddWhite(), "( 1 的说明 )");
                    AddSpace_3();
                    m_Tools.Text_H("     ", JianLiStr, " 简历2 = (", JianLiStr, ")简历1.Clone（）");
                    m_Tools.Text_H("     简历2.", "Show".AddWhite(), "( 2 的说明 )");
                });
            }, () =>
            {
                MyCreate.Text("1. 一般在初始化的信息" + "不发生变化".AddGreen() + "的情况下，克隆是最好的办法");
                MyCreate.Text("2. 这样即隐藏了对象创建的细节，又对性能是大大的提高");
                MyCreate.Text("3. " + "MemberwiseClone(弱复制)".AddYellow() + " 值类型逐位复制，引用对象仍指向原来的对象");
                MyCreate.Text("    即如果上面有一处更改了姓名 name ,全部复制过来的 简历 都会更改");
                MyCreate.Text("4. 深复制就是 Copy（）");
            });

        }

        //——————————————————结构——————————————————


        private void DrawJiGuoOther()                            // 结构其他
        {

            m_Tools.BiaoTi_B("适配器模式");

            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709224516553-784558535.png");
            AddSpace();

            m_Tools.BiaoTi_B("代理模式");
            m_Tools.Text_L("为其他对象提供一种代理以控制对这个对象的访问");
            m_Tools.Text_H("1. 远程代理，为一个对象在不同的地址空间提供局部代表");
            m_Tools.Text_H("2. 虚拟代理，如该对象创建开销很大，可先代理缓存");
            m_Tools.Text_H("3. 安全代理，控制访问对象的访问权限");

            AddSpace();
            m_Tools.BiaoTi_B("组合模式");
            m_Tools.Text_H("和万能模式那个树结构相同 ");



            AddSpace();
            m_Tools.BiaoTi_B("享元模式");
            MoBan(() =>
            {
                m_Tools.Text_Y("运用共享技术有效地支持大量细粒度的对象");

            }, () =>
            {
                MyCreate.Text("TMD 就是用一个字典来存储对象，存在则取，不存在则加");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("class 享元类");
                    m_Tools.Text_H("    private Dictionary<string, ", Lie, "> dic= new Dictionary<string, ", Lie, ">()");
                    m_Tools.Text_H("    public ", Lie, " 获得类(string key)");
                    m_Tools.Text_H("        if (!dic.ContainsKey(key))");
                    m_Tools.Text_H("            dic.Add(key,new ", Lie, "());");
                    m_Tools.Text_H("        return dic[key];");
                });


            }, () =>
            {
                m_Tools.Text_L("string a=“字符串”,string b=“字符串”,这两个的实例是相同的");
                m_Tools.Text_Y("因为字符串 string 也是使用是享元模式，所以==/Equals() 也是相等");
            });



            AddSpace();
            m_Tools.BiaoTi_B("桥接模式");
            MyCreate.Text("以一个生活中的例子来说明：");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709224648311-810479890.png",15);
            m_Tools.Text_B("合成/聚合复用原则：", "尽量使用合成/聚合，尽量不要使用类继承".AddLightBlue());
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709224807176-529840882.png",15);

            AddSpace();
            m_Tools.BiaoTi_B("外观模式");
            m_Tools.BiaoTi_L("动机、意图、何时用");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("为一个复杂子系统提供一个简单接口");
                m_Tools.Text_H("在层次化结构中，可以使用外观模式定义系统中每一层的入口");
                m_Tools.Text_R("比如 低层有很多功能类，用一个类包含所有低层功能类提供给高层使用");
            });
            m_Tools.BiaoTi_L("总结");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("就是像插件一样，把所有复杂的功能合成一个接口提供使用");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709225004482-1805190169.png",15);
            });
        }



        private void DrawZhuang()                                // 装饰模式
        {

            m_Tools.BiaoTi_O("装饰模式" + "(动态地给一个对象添加一些额外职责，比生成子类更灵活)".AddYellow());
            AddSpace();
            MyCreate.Text("可以给人搭配不同的服饰的系统".AddBold());

            MyCreate.FenGeXian_Blue(PersonStr + ",拥有 Show 形象展示方法");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("class ", PersonStr);
                m_Tools.TextText_HG("     public virtual void " + ShowStr + "{ ... }", "// 可以给子类继承");
            });
            MyCreate.FenGeXian_Blue("服饰类 继承 Person 类，构造方法要求带一个 Person");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("class ", FuStr, " : ", PersonStr);
                m_Tools.Text_H("     protected ", PersonStr, m_PersonStr);
                m_Tools.Text_G("     服饰类构造方法 -> 带一个 Person -> 赋值给 " + m_PersonStr);
                m_Tools.Text_H("     public override void ", ShowStr);
                m_Tools.TextText_HG("         " + m_PersonStr + "." + ShowStr, "// 注意这里没有 base 了");

            });

            MyCreate.FenGeXian_Blue("下面就是想要怎么设计服饰就怎么设计服饰了");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("class T恤类 : ", FuStr);
                m_Tools.Text_H("     public override void ", ShowStr);
                m_Tools.TextText_HG("       ....", "// 具体设计 T 恤的方法");
                m_Tools.TextText_HG("       base.Show()", "// 先调用自己的再调用父类");
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("class 裤类 : ", FuStr);
                m_Tools.Text_H("     public override void ", ShowStr);
                m_Tools.TextText_HG("       ....", "// 具体设计裤方法,与上面一致");
                m_Tools.Text_H("       base.Show()");
            });
            MyCreate.FenGeXian_Blue("客户端最终只需要一层叠一层添加即可");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("一个人只穿一件T恤");
                m_Tools.Text_H(PersonStr, " p = ", PersonStr, "()");
                m_Tools.Text_H("T恤类 t = T恤类(p)");
                m_Tools.TextText_HG("t.Show();", "// 同时会调用 p 内部的 Show 方法的了");
                MyCreate.AddSpace(5);
                MyCreate.Text("一个人先穿T恤再穿上裤" + "再穿上等等的装饰".AddLightGreen());
                m_Tools.Text_H(PersonStr, " p = ", PersonStr, "()");
                m_Tools.Text_H("裤类 h = 裤类(p)");
                m_Tools.Text_H("T恤类 t = T恤类(h)");
                m_Tools.Text_LG("其他的装饰同理...");
                m_Tools.TextText_HG("t.Show();", "// 先是T恤Show ->裤类Show->Person Show");
            });
            AddSpace();
            MyCreate.FenGeXian("总结：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("1. 这样做，把装饰这功能从 Person 类中抽取出来了（修改与添加也不会影响）");
                m_Tools.Text_B("2. 同时去除了重复的 Show");
            });

        }


        //——————————————————行为——————————————————

        private void XingWeiOther()                               // 行为其他
        {
            AddSpace();
            m_Tools.BiaoTi_B("解释器模式");



            AddSpace();
            m_Tools.BiaoTi_B("访问者模式");
            m_Tools.Text_H("想不到那里会需要这模式");

            AddSpace();
            m_Tools.BiaoTi_B("备忘录模式");
            m_Tools.Text_H("就是 数据Bean，然后写多一个类来记录这个 数据Bean");


            AddSpace();
            m_Tools.BiaoTi_B("命令模式");
            m_Tools.Text_H("就是将一个方法封装成对象来调用");
            m_Tools.Text_H("类巨多，不喜欢");

            AddSpace();
            m_Tools.BiaoTi_B("模板方法模式");
            m_Tools.BiaoTi_L("动机、意图、何时用" + "(这个模式简单、常用)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_R("就是把父类定义成一个模板，给子类实现");
                m_Tools.Text_H("一次性实现一个算法的不变的部分，并将可变的行为留给子类来实现");
                m_Tools.Text_H("各子类中公共的行为应被提取出来并集中到一个公共父类中以避免代码重复");
            });

            AddSpace();
            m_Tools.BiaoTi_B("中介者模式");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709225152340-1096691406.png",15);

        }


        private void DrawGuang()                                 // 观察者模式
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题。");
                m_Tools.Text_Y("这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己");
            });
            AddSpace();

            MyCreate.FenGeXian_Blue(TongZhiStr + "，保存所有观察者，可增删观察者，通知的功能");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public abstract class ", TongZhiStr);
                m_Tools.Text_H("     private List<", JianTinStr, "> l_o = new List<", JianTinStr, ">()");
                m_Tools.Text_H("     public void ", AddStr, " (", JianTinStr, "){ l_o.Add... }");
                m_Tools.Text_H("     public void ", "Remove ".AddWhite(), "(", JianTinStr, "){ l_o.Remove... }");
                m_Tools.TextText_HG("     public void " + NotifyStr, "// 通知");
                m_Tools.Text_H("          foreach(", JianTinStr, " o in l_o)");
                m_Tools.Text_H("               o.", OnUpdateStr);
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public class 通知者实现类 : ", TongZhiStr);
                m_Tools.Text_H("     // 具体通知者实现，核心是已拥有", " Notify、Add、Remove ".AddWhite(), "方法");
            });
            AddSpace();
            MyCreate.FenGeXian_Blue("接口/抽象监听类，定义一个更新接口让通知者通知自己");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("interface ", JianTinStr);
                m_Tools.Text_H("     void ", OnUpdateStr);
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public class 监听实现类1 : ", JianTinStr);
                m_Tools.Text_H("     public override void ", OnUpdateStr, "{ //1具体要做什么... }");
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("public class 监听实现类2 : ", JianTinStr);
                m_Tools.Text_H("     public override void ", OnUpdateStr, "{ //2具体要做什么... }");
            });
            AddSpace();
            MyCreate.FenGeXian_Blue("客户端 通知者先添加要通知的监听者，到需要时就发起通知");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("通知者实现类 s = new 通知者实现类（）");
                m_Tools.Text_H("s.", AddStr, "( new 监听实现类1() )");
                m_Tools.Text_H("s.", AddStr, "( new 监听实现类2() )");
                m_Tools.Text_H("s.", NotifyStr);
            });
            AddSpace();
            MyCreate.FenGeXian("总结：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("1. 当一个对象的改变需要同时改变其他对象，而且它不知道具体有多少对象有待改变使用");
                m_Tools.Text_Y("2. 所做的工件就是在解除耦合，让耦合双方都依赖于抽象，而不是依赖于具体");
                m_Tools.Text_Y("      从而使用各自的变化都不会影响另一边的变化");
                m_Tools.Text_Y("3. 其实委托也完全可以实现");

            });
        }

        private void DrawZhiZhe()                                // 职责链模式
        {
            MoBan(() =>
            {
                m_Tools.Text_L("将处理对象连成一条链，沿着这条链传递请求，直到有一个处理对象处理为止");
                m_Tools.Text_R("就是遍历所有的处理对象，直到是这个处理对象来处理为止");

            }, () =>
            {
                MyCreate.Text("处理类名枚举" + EnumHandler + "(注意：是按每个状态的类名来命名)".AddGreen());
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public enum ", EnumHandler);
                    m_Tools.Text_H("    处理1,处理2,处理3");
                });
                MyCreate.Text("每个处理类要处理什么，自己加好判断，自己做好");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public abstract class ", ChuLiiLie);
                    m_Tools.Text_H("    public abstract bool ", DealDoStr, "(int 事件ID)");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class 处理1 ", ChuLiiLie);
                    m_Tools.Text_H("    public override bool ", DealDoStr, "(int 事件ID)");
                    m_Tools.Text_H("        if (事件ID >= 0 && 事件ID < 10)");
                    m_Tools.Text_H("            // 处理1 要做什么");
                    m_Tools.Text_H("            return true;");
                    m_Tools.Text_H("        return false;");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class 处理2 ", ChuLiiLie);
                    m_Tools.Text_H("        // 与处理 1 类似 判断改成 if (事件ID >= 10 && 事件ID < 20)");

                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class 处理2 ", ChuLiiLie);
                    m_Tools.Text_H("        // 与处理 1 类似 判断改成 if (事件ID >= 20 && 事件ID < 30)");

                });
                MyCreate.Text(ZhiZheStr + "构造时会自己添加所有枚举类名，调用时自动调用到对应类");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public class ", ZhiZheStr);
                    m_Tools.TextText_HG("    private List<" + ChuLiiLie + "> list=new List<" + ChuLiiLie + ">()", "// 所有处理对象集合");
                    m_Tools.Text_H("    public void ", DealDoStr, "(int 事件ID)");
                    m_Tools.TextText_HG("        for (int i = 0; i < list.Count; i++)", "// 遍历所有处理对象直到有处理就 break");
                    m_Tools.Text_H("            bool isHandler=  list[i].", DealDoStr, "(事件ID);");
                    m_Tools.Text_H("            if (isHandler)");
                    m_Tools.Text_H("                break;");
                    m_Tools.Text_B("构造函数 -> 把枚举中的类命名全部加入到 list 当中");
                    m_Tools.Text_H("        foreach (", EnumHandler, " h in Enum.GetValues(typeof(", EnumHandler, ")))");
                    m_Tools.Text_H("            AssemblyName n=  Assembly.GetExecutingAssembly().GetName();");
                    m_Tools.Text_H("            ", ChuLiiLie, " handler = (", ChuLiiLie, ")Assembly.Load(n).CreateInstance(h.ToString());");
                    m_Tools.Text_H("            list.Add(handler);");
                });
                MyCreate.Text("客户端 只需要使用职责链类，而且不需要知道那个处理，直接用即可");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H(ZhiZheStr, " z = new ", ZhiZheStr, "()");
                    m_Tools.TextText_HG("z." + DealDoStr + "( 3 )", "// 想处理那个事件，直接用即可");
                    m_Tools.Text_H("z.", DealDoStr, "( 25 )");
                });
            }, () =>
            {
                m_Tools.Text_R("添加处理对象只需要增加 处理4 和增加枚举即可，连 " + ZhiZheStr + " 也无需更改");
            });

        }


        private void DrawState()                                 // 状态模式
        {
            MoBan(() =>
            {
                m_Tools.Text_L("目的就是为了削除庞大的条件分支语句");

            }, () =>
            {
                MyCreate.Text("状态枚举" + "(注意：是按每个状态的类名来命名)".AddGreen());
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public enum ", EnumState);
                    m_Tools.Text_H("    None,", StateA, ",状态B,状态C");
                });

                MyCreate.Text(StateGLStr + " 控制当前状态，提供当前状态要做什么");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public class ", StateGLStr);
                    m_Tools.Text_H("    private ", StateJiLie, " m =null;");
                    m_Tools.Text_H("    private ", EnumState, " m_State= ", EnumState, ".None;");
                    m_Tools.Text_B("    构造函数 -> ", EnumState, " 初始状态 -> m_State");
                    m_Tools.Text_H("    public ", EnumState, " State");
                    m_Tools.Text_H("        get ->  return m_State");
                    m_Tools.Text_H("        set ->");
                    m_Tools.Text_H("            if (value==", EnumState, ".None || m_State == value)");
                    m_Tools.Text_H("                return;");
                    m_Tools.Text_H("            m_State = value;");
                    m_Tools.Text_H("            AssemblyName name = Assembly.GetExecutingAssembly().GetName()");
                    m_Tools.Text_H("            m = (", StateJiLie, ")Assembly.Load(name).CreateInstance(m_State.ToString())");
                    m_Tools.Text_H("    public void ", StateWhat2DoStr);
                    m_Tools.Text_H("            m.", StateWhat2DoStr);
                });
                MyCreate.Text("每个状态要做什么事，自己管理好，与其他状态无关");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public abstract class ", StateJiLie);
                    m_Tools.Text_H("    public abstract void 状态要做什么();");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("public class ", StateA, " : ", StateJiLie);
                    m_Tools.Text_H("    public override void ", StateWhat2DoStr, "{ // 状态A 实现内容}");
                    m_Tools.Text_H("public class 状态B : ", StateJiLie);
                    m_Tools.Text_H("    public override void ", StateWhat2DoStr, "{ // 状态B 实现内容}");
                    m_Tools.Text_H("public class 状态C : ", StateJiLie);
                    m_Tools.Text_H("    public override void ", StateWhat2DoStr, "{ // 状态C 实现内容}");
                });
                MyCreate.Text("客户端 只需要使用状态管理者，判断切换状态即可");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H(StateGLStr, " 管理者 = new ", StateGLStr, "(", EnumState, ".", StateA, ")");
                    m_Tools.Text_H("    void Update()");
                    m_Tools.TextText_HG("        管理者." + StateWhat2DoStr, "// 只要 管理者.State = 状态X 切换状态，即可跳到对应状态");
                });

            }, () =>
            {
                m_Tools.Text_R("增加新的状态，只需要增加 状态D 类，然后在 Enum状态 中添加 状态D 即可");
            });
        }

        private void DrawCheLue()                                // 策略模式
        {
            MoBan(() =>
            {
                m_Tools.Text_W("比如要一个结果需要 switch 语句，case 很多，而且经常有变动的");
                m_Tools.Text_L("switch(参数) ->", " case 算法经常变动".AddRed(), " -> 结果");
                m_Tools.Text_W("此模式让算法的变化不会影响到使用算法的客户");
            },
                () =>
                {
                    MyCreate.Text("客户端就和策略类打交道，不会与实际的任何算法有联系" + "（传算法类名）".AddGreen());
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("public class ", CheLieStr);
                        m_Tools.Text_H("    private string ", "算法类名".AddLightBlue());
                        m_Tools.Text_Y("    构造方法 -> 传 string -> 赋值 ", "算法类名".AddLightBlue());
                        m_Tools.Text_H("    public float ", GetResultStr);
                        m_Tools.Text_H("        AssemblyName an = Assembly.GetExecutingAssembly().GetName()");
                        m_Tools.Text_H("        ", XunFaStr, " a = (", XunFaStr, ")Assembly.Load(an).CreateInstance(", "算法类名".AddLightBlue(), ")");
                        m_Tools.Text_H("        return a.", GetResultStr);
                    });
                    MyCreate.Text("实际的算法实现类，要怎么计算就在子类实现");
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("public abstract class ", XunFaStr);
                        m_Tools.Text_H("    public abstract float ", GetResultStr);
                    });
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_H("public class ", "算法A".AddRed(), " : ", XunFaStr);
                        m_Tools.Text_H("    public override float ", GetResultStr, " { return // A计算 }");
                    });
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_H("public class 算法B : ", XunFaStr);
                        m_Tools.Text_H("    public override float ", GetResultStr, " { return // B计算 }");
                    });
                    MyCreate.Text("客户端想要那个算法只要传对应的类名(" + ShuanFaA + ")即可");
                    MyCreate.Box_Hei(() =>
                    {

                        m_Tools.Text_H(CheLieStr, " a=  new ", CheLieStr, "(", ShuanFaA, ")");
                        m_Tools.Text_H("a.", GetResultStr, "  ->  得到结果".AddGreen());
                    });

                },
                () =>
                {
                    MyCreate.Text("1. 策略模式 -> 利用策略类调用唯一接口 -> 返回不同的结果");
                    MyCreate.Text("2. 如现要增加另一 C 算法，只要增加 算法C和new 策略类（”算法C“）即可".AddRed());
                    MyCreate.Text("3. 同一接口但有不同的业务规则/算法/需求，就可以考虑使用策略模式");
                });
            AddSpace_3();
            m_Tools.BiaoTi_L("UML 图", ref isUML1, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709225418006-52826444.png",15);
            });
            AddSpace();
        }



    }

}


