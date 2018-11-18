using System;
using System.Collections.Generic;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class MainBan_LiZi : AbstactNewKuang
    {
        [MenuItem(LearnMenu.MainBan_LiZi)]
        public static void Init()
        {
            MainBan_LiZi instance = GetWindow<MainBan_LiZi>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "  [识英文]".AddSize(16);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.LiZiPro2 ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LiZiPro2);
            }
            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "  粒子总结";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ZhongJie ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ZhongJie);
            }
            AddSpace_3();


            bool tmpOther = (type == EType.LiZi || type == EType.LiZi1 || type == EType.LiZi2 || type == EType.LiZi3 || type == EType.LiZi4 || type == EType.LiZi5 || type == EType.LiZi6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "粒子系统";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.LiZi ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LiZi);
            }

            if (tmpOther)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi1 ? "Emission(发射模块)".AddBlue() : "Emission(发射模块)");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi2 ? "Shape(形状模块)".AddBlue() : "Shape(形状模块)");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi3 ? "Collision(碰撞)".AddBlue() : "Collision(碰撞)");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi4 ? "其他模块".AddBlue() : "其他模块");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi5 ? "TextureSA(序列图模块)".AddBlue() : "TextureSA(序列图模块)");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LiZi6 ? "Renderer(渲染模块)".AddBlue() : "Renderer(渲染模块)");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LiZi6);
                }
            }

            MyCreate.AddSpace(20);

            bool tmpProfiler = (type == EType.Profiler || type == EType.Profiler1 || type == EType.Profiler2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Profiler";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Profiler ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Profiler);
            }

            if (tmpProfiler)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Profiler1 ? "   其他模块".AddBlue() : "   其他模块");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Profiler1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Profiler2 ? "   Tip".AddBlue() : "   Tip");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Profiler2);
                }
            }
        }

        protected override void DrawRight()
        {
            switch (type)
            {

                case EType.LiZiPro2:   DrawRightPage3(DrawYingWen);       break;
                case EType.ZhongJie:   DrawRightPage3(DrawLiZiZhongJie);  break;
                case EType.LiZi:       DrawRightPage4(DrawLiZi);          break;
                case EType.LiZi1:      DrawRightPage5(DrawEmission);      break;
                case EType.LiZi2:      DrawRightPage6(DrawShape);         break;
                case EType.LiZi3:      DrawRightPage7(DrawCollision);     break;
                case EType.LiZi4:      DrawRightPage1(DrawOther);         break;
                case EType.LiZi5:      DrawRightPage8(DrawXuLiTu);        break;
                case EType.LiZi6:      DrawRightPage6(DrawRenderer);      break;
                case EType.Profiler:   DrawRightPage1(DrawProfiler);      break;
                case EType.Profiler1:  DrawRightPage3(DrawProOther);      break;
                case EType.Profiler2:  DrawRightPage4(DrawTip);            break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.LiZi:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                case EType.LiZi1:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                case EType.LiZi6:
                    mWindowSettings.pageWidthExtraSpace.target = -10;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -40;
                    break;
            }

        }


        protected override void OnInit()                         // 一开始下载 中英Txt
        {
            base.OnInit();
            www = new WWW("https://github.com/paoshuipao/LearnEnglish/raw/master/LiZi.txt");
        }



        #region 私有
        private bool _isCPU, _isGPU, _isOther, isRendering, isAudio, isVideo, isPhysics, isPhysics2D, isNetwordMessages, isMemory;
        private bool isNetwordOperations, isAtLastShow;
        private bool isJianTuo, isdScene;
        private bool isVisualization, isLifetimeLoss, isLightProbes, isReflection;
        private string mInput;
        private List<string> l_English = new List<string>();
        private string downAllString;
        private WWW www;

        private ShapeType shapeType = ShapeType.Cone_锥体;
        private CollisionType collisionType = CollisionType.Planes_单一面板;


        enum ShapeType
        {
            Sphere_球体,
            Hemisphere_半球体,
            Cone_锥体,
            Donut_甜甜圈,
            Box_盒子,
            Mesh_自定义Mesh,
            Circle_圈,
            Edge_边
        }
        enum CollisionType
        {
            World_全部,
            Planes_单一面板
        }



        private enum EType
        {
            LiZiPro2,
            ZhongJie,
            LiZi,LiZi1, LiZi2,LiZi3,LiZi4,LiZi5,LiZi6,

            Profiler,Profiler1,Profiler2
        }

        private EType type = EType.LiZi;

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
            return "粒子系统、Profiler";
        }



        #endregion



        private void DrawYingWen()                               // 识英文
        {

            mInput = m_Tools.TextString_B("输入要搜索的英文", mInput);
            if (string.IsNullOrEmpty(downAllString))
            {
                m_Tools.Text_R("下载中.....");
                if (www.isDone)
                {
                    downAllString = www.text;
                    string[] strArray = downAllString.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArray)
                    {
                        string[] eachInfo = str.Split("##".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        l_English.Add(eachInfo[0]);
                        l_English.Add(eachInfo[1]);
                    }
                }
            }
            else
            {
                MyCreate.Box_Hei(() =>
                {
                    int i = 0;
                    while (i < l_English.Count)
                    {

                        string str1 = l_English[i];
                        bool isInput1 = false;
                        if (!mInput.IsNullOrEmpty())
                        {
                            isInput1 = str1.IsContains(mInput, StringComparison.OrdinalIgnoreCase);
                        }
                        str1 = isInput1 ? str1.AddBoldAndColor(MyEnumColor.Blue, false) : str1.AddWhite();
                        string str2 = isInput1 ? l_English[i + 1].AddGreen() : l_English[i + 1];
                        str2 = "(" + str2 + ")";
                        string str3 = "";
              
                        string str4 = "";
                        if (i + 2 < l_English.Count)
                        {
                            str3 = l_English[i + 2];
                            bool isInput2 = false;
                            if (!mInput.IsNullOrEmpty())
                            {
                                isInput2 = str3.IsContains(mInput, StringComparison.OrdinalIgnoreCase);
                            }
                            str3 = isInput2 ? str3.AddBoldAndColor(MyEnumColor.Blue, false) : str3.AddWhite();
                            str4 = isInput2 ? l_English[i + 3].AddGreen() : l_English[i + 3];
                            str4 = "(" + str4 + ")";
                        }
                        m_Tools.Text4(str1, str2, str3, str4, 20);
                        i = i + 4;
                    }
                });
            }

        }

        #region 粒子



        private void DrawLiZiZhongJie()                          // 粒子总结
        {

            m_Tools.Text_L("想要发生","来回移动".AddGreen()," ->  Velocity over Lifetime");
            m_Tools.Text_L("想要发生","大小变化".AddGreen()," ->  Size over Lifetime");
            m_Tools.Text_L("想要发生","颜色变化".AddGreen()," ->  Color over Lifetime");
            m_Tools.Text_L("想要发生","图片序列动画".AddGreen()," ->  Texture Sheet Animation");
            AddSpace_15();
            m_Tools.Text_L("Renderer  ->  Material  ->  用 粒子的 Shader 即可");

            AddSpace();
            m_Tools.BiaoTi_B("粒子系统性能");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("▪ 粒子系统是性能的大敌");
                m_Tools.Text_Y("▪ 一个场景的发射器的数量应该控制" + "（ 少于 30 ）".AddGreen());
                m_Tools.Text_Y("▪ 全屏粒子数量应该控制" + "（ 少于 200 ）".AddGreen());
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("可以从面板的 ", "MaxParticles", " 属性控制单个发射器最大数量");
                });
                m_Tools.Text_Y("▪ 慎用子发射器,(Sub Emitters)".AddBlue(), ",能不用就不用");
                m_Tools.Text_Y("▪ 关掉粒子的阴影(默认是关闭的)");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("在 Renderer 模板 -> Cast Shadows");
                });
                m_Tools.Text_Y("▪ 关掉粒子碰撞");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("即是没有什么特殊也不要开启碰撞这个模块");
                });
            });

        }



        private void DrawLiZi()                                  // 粒子系统
        {
            m_Tools.BiaoTi_O("控制" + "整体系统".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Duration", "持续时间");
                m_Tools.TextText_WL("Loop", OpenSure + "循环", -38);
                m_Tools.TextText_WL("Prewarm", OpenSure + "预热" + "(看起来就像已经发射了一个粒子周期)".AddGreen(), -38);
                m_Tools.TextText_WL("Start Delay", "[延时]".AddYellow() + "发射的时间");
            });
            m_Tools.BiaoTi_O("控制" + "每一个粒子".AddGreen() + "的行为");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Start Lifetime", "生命周期" + "(如5，1个粒子发射后经过5秒就消失)".AddGreen());
                m_Tools.TextText_WL("Start Speed", "初始速度");
                m_Tools.TextText_WL("3D Start Size", OpenSure + "拥有不同的初始" + "[XYZ轴 大小]".AddBlue(), -38);
                m_Tools.TextText_WL("Start Size", "初始大小");
                m_Tools.TextText_WL("3D Start Rotation", OpenSure + "拥有不同的初始" + "[XYZ轴 旋转值]".AddBlue(), -38);
                m_Tools.TextText_WL("Start Rotation", "初始旋转值");
                m_Tools.TextText_WL("Randomize Rotation", "[随机化旋转]".AddBlue() + "(范围 0 ~ 1)");
                m_Tools.TextText_WL("Start Color", "初始颜色");
                m_Tools.TextText_WG("Gravity Modifier", "[重力]".AddYellow() + "(0：往上飘，当值增加，就会往下掉)");
            });
            m_Tools.BiaoTi_O("整体".AddGreen() + "粒子效果");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Simulation Space", "粒子是按" + "世界坐标系".AddBlue() + "还是" + "自身坐标系".AddBlue() + "定位");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("   当移动时，世界坐标系粒子会按原来路线继续");
                    m_Tools.Text_H("   当移动时，自身坐标系粒子会按跟着自身");
                });
                m_Tools.TextText_WL("Simulation Speed", "整体粒子的速度");
            });
            m_Tools.BiaoTi_O("游戏本身".AddGreen() + "对粒子的影响");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Delta Time", "[游戏暂停]".AddYellow() + "还动不动" + "(Time.timeScale = 0)".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    Scaled", "(粒子系统也会暂停)".AddLightBlue(), "       Unscaled", "(粒子不暂停，继续)".AddLightBlue());
                });

                m_Tools.TextText_WL("Scaling Mode", "Transform 的" + "[Scale]值".AddYellow() + "对其影响");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText("  Hierarchy".AddHui(), "父 Transform 与自身 Scale 改变，大小也改变".AddLightBlue(), -30);
                    m_Tools.TextText("  Local".AddHui(), "自身 Scale 改变，大小也改变".AddLightBlue(), -30);
                    m_Tools.TextText("  Shape".AddHui(), "不会改变粒子大小".AddLightBlue(), -30);
                });

                m_Tools.TextText_WL("Play On Awake", OpenSure + "自动播放", -38);
                m_Tools.TextText_WL("Emitter Velocity", "发射器速度是由" + "[刚体]".AddBlue() + "还是[" + "位置]".AddBlue() + "产生");
                m_Tools.TextText_WL("Max Particles", "[最多]".AddGreen() + "粒子数量");
                m_Tools.TextText_WL("Auto Random Seed", OpenSure + "随机效果", -38);
                m_Tools.TextText_WL("Stop Action", "停止时的行动" + "(可选隐藏或者销毁)".AddGreen());
            });

            AddSpace_15();
            m_Tools.BiaoTi_L("右边的箭头",ref isJianTuo, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_L("Constant".AddWhite(), "(常量)", "   Curve".AddWhite(), "(曲线)", "   Gradient".AddWhite(), "(渐变(颜色))");
                    m_Tools.Text_L("Random Between Two Constants/Curves".AddWhite(), "两(常量/曲线)间随机");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_L("Scene视图小框"+ "（这里只是观看，不会真正影响粒子）".AddGreen(),ref isdScene, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_WL("Playback Speed", "播放速度，" + "1 为正常时速度".AddGreen());
                    m_Tools.TextText_WL("Playback Time", "播放时间，" + "可改变观看".AddGreen());
                    m_Tools.TextText_WL("Particles", "粒子数量，" + "产生了多少个粒子".AddGreen());
                    m_Tools.TextText_WL("Speed Randge", "粒子范围，" + "粒子多少秒消失".AddGreen());
                });
            });


        }

        private void DrawEmission()                              // 发射模块
        {
            m_Tools.BiaoTi_B("Emission   [ 发射模块 ]");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Rate over Time", "一秒产生多少粒子");
                m_Tools.TextText("Rate over Distance".AddHui(), "一公尺产生多少粒子".AddHui() + "(没什么卵用)".AddLightGreen());
                MyCreate.Box(() =>
                {
                    MyCreate.Text("Bursts" + "[ 爆发 ]发射".AddGreen());
                    m_Tools.Text_W(" Time".AddOrange(), "                 Count".AddYellow(), "                Cycles".AddBlue(), "               Interval".AddLightBlue());
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_L("总时长".AddOrange(), "    总共爆发多少个粒子".AddYellow(), "    一次过 还是 多次".AddBlue(), "   两次或以上的间隔是多少秒");
                    });
                });
            });

            AddSpace();
            m_Tools.BiaoTi_L("注意一下");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("这个模块是必开的，不开等于没有发射器");
                m_Tools.Text_H("粒子爆发(Bursts)： 在" + "持续时间内".AddGreen() + "的" + "指定时刻".AddGreen() + "额外增加大量的粒子");
                m_Tools.Text_H("爆发时间不会超过粒子的持续时间");

            });

        }

        private void DrawShape()                                 // 形状模块
        {
            m_Tools.BiaoTi_B("Shape   [ 形状模块 ]");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("可以在Scene视图手动调整形状");
                shapeType = (ShapeType)m_Tools.TextEnum("Shape", shapeType);
                switch (shapeType)
                {
                    case ShapeType.Sphere_球体:
                    case ShapeType.Hemisphere_半球体:
                        m_Tools.TextText("Radius", "球体的半径");
                        m_Tools.TextText("Radius Trhickness", "半径厚度");
                        break;
                    case ShapeType.Cone_锥体:
                        m_Tools.TextText("Angle", "圆锥的角度");
                        m_Tools.TextText("Radius", "发射口半径");
                        m_Tools.TextText("Radius Trhicknes", "发射口半径厚度");
                        m_Tools.TextText("Arc", "弧");
                        break;
                    case ShapeType.Donut_甜甜圈:
                        m_Tools.TextText("Radius", "半径");
                        m_Tools.TextText("Dounut Radius", "内圈半径");
                        m_Tools.TextText("Radius Trhickness", "半径厚度");
                        m_Tools.TextText("Arc", "弧");
                        break;
                    case ShapeType.Box_盒子:
                        m_Tools.TextText("Emit from", "从...发出");
                        break;
                }
            });
        }

        private void DrawCollision()                             // 碰撞模块
        {
            m_Tools.BiaoTi_B("Collision" + "[ 碰撞 ]".AddGreen());
            MyCreate.Box(() =>
            {
                collisionType = (CollisionType)m_Tools.BiaoTi_O("Type(类型)", collisionType);
                switch (collisionType)
                {
                    case CollisionType.World_全部:
                        MyCreate.TextCenter("碰撞是对于整个场景");
                        break;
                    case CollisionType.Planes_单一面板:
                        MyCreate.TextCenter("碰撞是对于单一个面板");
                        m_Tools.TextText("Planes", "先要给块面板来");
                        m_Tools.TextText_OY("Visualization", "可视化平面：网格还是实体", ref isVisualization, () =>
                        {
                            m_Tools.TextText("Grid", "网格:在场景渲染为辅助线框");
                            m_Tools.TextText("Solid", "实体:在场景渲染为平面");
                        });
                        m_Tools.TextText("Scale Plane", "面板大小");
                        m_Tools.TextText("Dampen", "阻尼（碰撞后变慢）");
                        m_Tools.TextText("Bounce", "反弹力度");
                        m_Tools.TextText_OY("Lifetime Loss", "生命减弱", ref isLifetimeLoss, () =>
                        {
                            MyCreate.Heng(() =>
                            {
                                MyCreate.AddSpace(20);
                                MyCreate.Text("(0-1) 每次碰撞胜铭减弱的比例");
                                MyCreate.Text("0，碰撞后粒子正常死亡");
                                MyCreate.Text("1，碰撞后粒子立即死亡");
                            });
                            MyCreate.Heng(() =>
                            {
                                MyCreate.AddSpace(20);
                                MyCreate.Text("0，碰撞后粒子正常死亡");
                            });
                            MyCreate.Heng(() =>
                            {
                                MyCreate.AddSpace(20);
                                MyCreate.Text("1，碰撞后粒子立即死亡");
                            });
                        });
                        m_Tools.TextText("Min Kill Speed", "最小杀死速度");
                        m_Tools.TextText("Max Kill Speed", "最大杀死速度");
                        m_Tools.TextText("Radius Scale", "半径大小");
                        m_Tools.TextText("Send Collision Message", "发送碰撞消息");
                        m_Tools.TextText("Visualize Bounds", "范围可视化");

                        break;
                }
            });
        }


        private void DrawOther()                                 // 其他模块
        {
            m_Tools.TextText_WY("Velocity over Lifetime", "方向", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HL("  Space", "方向是按照世界 XYZ 还是自身 XYZ");
            });
            m_Tools.TextText_WY("LimitVelocity overLifetime", "方向限制", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HL("   Dampen", "拖拽效果");
                m_Tools.TextText_HL("   Drag", "阻力");
            });
            m_Tools.TextText_WY("Inherit Velocity", "继承速度", 40);
            m_Tools.TextText_WY("Force over Lifetime", "力", 40);
            m_Tools.TextText_WY("Color over Lifetime", "颜色", 40);
            m_Tools.TextText_WY("Color by Speed", "速度对颜色的影响", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    1.在速度范围内的 颜色 变化      2.不会影响真正速度");
            });
            m_Tools.TextText_WY("Size over Lifetime", "大小", 40);
            m_Tools.TextText_WY("Size by Speed", "速度对大小的影响", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    1.在速度范围内的 大小 变化      2.不会影响真正速度");
            });
            m_Tools.TextText_WY("Rotation over Lifetime", "旋转", 40);
            m_Tools.TextText_WY("Rotation by Speed", "速度对旋转的影响", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    1.在速度范围内的 旋转 变化      2.不会影响真正速度");
            });
            m_Tools.TextText_WY("External Forces", "外部作用力影响", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HL("Multiplier", "乘数");
                MyCreate.Text("如：添加了风力( WindZone )后，乘以这个数等于真正的作用力");
            });
            m_Tools.TextText_WY("Noise", "噪声", 40);
            m_Tools.TextText_WY("Triggers", "触发器", 40);
            m_Tools.TextText_WY("Sub Emitters", "每个粒子包含子粒子系统", 40);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    喷出来的每个粒子是另一个粒子系统");
                m_Tools.Text_H("    不用想啦，一定很消耗性能");
            });
            m_Tools.TextText_WY("Texture Sheet Animation", "序列图", 40);
            m_Tools.TextText_WY("Lights", "光照", 40);
            m_Tools.TextText_WY("Trails", "路线", 40);
            m_Tools.TextText_WY("Curstom Data", "自定义数据", 40);

        }


        private void DrawXuLiTu()                               // 序列图
        {
            m_Tools.BiaoTi_O("Texture Sheet Animation" + "序列图模块".AddGreen());
            m_Tools.TextText_WB("Tiles", "瓷砖");
            m_Tools.TextText_WB("Animation", "");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HL("   Whole Sheet", "整张纸");
                m_Tools.TextText_HL("   Single Row", "单行");
            });
            m_Tools.TextText_WB("Frame over Time", "每帧用多少时间");
            m_Tools.TextText_WB("Start Frame", "开始帧");
            m_Tools.TextText_WB("Cycles", "周期");
            m_Tools.TextText_WB("Filp U/V", "翻转");
            m_Tools.TextText_WB("Enabled UV Channels", "通道");

        }


        private void DrawRenderer()                              // 渲染模块
        {
            m_Tools.BiaoTi_O("Renderer" + "[ 渲染每一个粒子 ]".AddGreen());
            
            m_Tools.TextText_WB("Render Mode", "渲染模式");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text4_HW("      Billboard", "广告牌", "Stretched", "拉伸",30);
                m_Tools.Text4_HW("      Horizontal", "横", "Vertical", "竖", 30);
            });

            m_Tools.TextText_WB("Normal Direction", "正常方向");
            m_Tools.TextText_WB("Material", "材料");
            m_Tools.TextText_WB("Trail Material", "仅在 [ Trails 模块 ]启用时可用");
            m_Tools.TextText_WB("Sort Mode", "按相机距离、最前面");
            m_Tools.TextText_WB("Sorting Fudge", "粒子系统的排序");
            m_Tools.TextText_WB("Min Particle Size", "最小粒径");
            m_Tools.TextText_WB("Max Particle Size", "最大粒径");
            m_Tools.TextText_WB("Billboard Alignment", "视图、世界、本地、面对");
            m_Tools.TextText_WB("Pivot", "中心点");
            m_Tools.TextText_WB("Visualize Pivot", "在场景视图中的中心点");
            m_Tools.TextText_WB("Custom Vertex Streams", "自定义顶点");
            m_Tools.TextText_WB("Cast Shadows", "产生阴影（无、有、双面、只有阴影）");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HL("  Off", "这物体不会产生阴影");
                m_Tools.TextText_HL("  On", "普通 产生阴影");
                m_Tools.TextText_HL("  TwoSided", "我能给你产生阴影，你也能在我身上产生阴影");
                m_Tools.TextText_HL("  ShadowsOnly", "物体是不可见的，这是只能产生阴影物体");
            });
            m_Tools.TextText_WB("Receive Shadows", "是否接收阴影");
            m_Tools.TextText_WB("Sorting Layer", "渲染层 ( > Z 轴 )");
            m_Tools.TextText_WB("Order In Layer ", " Z 轴不动情况下，值越大，类Z轴越大 ");
            m_Tools.TextText_WB("Light Probes", "光探针", ref isLightProbes, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("Off", "不使用任何插值光探针");
                    m_Tools.TextText_HL("Blend Probes", "使用一个内插光探针 (默认选项)");
                    m_Tools.TextText_HL("Use Proxy Volume", "使用插入光探针的3D网格");
                });
            });
            m_Tools.TextText_WB("Reflection ProbeUsage", "反射探针", ref isReflection, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("1.这个 Renderer 应该使用反射探针吗？");
                    m_Tools.Text_G("2.如果已启用且反射探针存在于场景中，则将为此对象选取反射纹理,");
                    m_Tools.Text_G("   并将其设置为内置着色器统一变量。表面着色器自动使用这些信息");
                    m_Tools.Text_G("3.面板没有的，默认 Off");
                    MyCreate.FenGeXian();
                    m_Tools.TextText("Off", "反射探头被禁用，天空盒将用于反射");
                    m_Tools.BiaoTi_B("下面3种情况都是 以反射探头已启用 情况下：");
                    m_Tools.TextText("BlendProbes", "混合探针,混合只发生在探头之间，");
                    m_Tools.TextText("", "如果附近没有反射探头，则渲染器将使用默认反射，");
                    m_Tools.TextText("", "但默认反射和探测之间不会混合");
                    m_Tools.TextText("", "在室内环境中很有用");
                    m_Tools.TextText("BlendProbesAndSkybox", "混合探针和Skybox,探头与默认反射之间发生混合");
                    m_Tools.TextText("", "对室外环境有用");
                    m_Tools.TextText("Simple", "简单,当两个重叠的体积时，探针之间不会发生混合");

                });
            });
        }



        #endregion



        #region Profiler


        private void DrawProfiler()                             // Profiler
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_Y("Profiler", "探查、评估".AddHui(), "        Record", "记录".AddHui());
                m_Tools.TextText_YH("Deep Profile", "是否更深入的分析（包含Unity内部封装好的性能）", -70);
                m_Tools.TextText_YH("Profile Editor", "是否添加Editor的分析", -70);
                m_Tools.TextText_YH("Connected Player", "增加Unity设备进分析(根据IP地址)，默认当前编辑器", -70);
            });
            MyCreate.AddSpace(13);
            MyCreate.Window("CPU Usage( CPU资源使用率 )", () =>
            {
                m_Tools.TextText_BL("GC ALLoc", "内存分配了多少B");

            });

            m_Tools.BiaoTi_O("CPU Usage" + " CPU资源使用率".AddYellow(), ref _isCPU, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText("Toatal", "用了多少%CPU");
                    m_Tools.TextText("Self", "自己用了多少%CPU（不包含子函数）");
                    m_Tools.TextText("Calls", "在这一帧被反复调用了多少次");
                    m_Tools.TextText("Time ms", "用了多少毫秒");
                    m_Tools.Text_G("手机保持在33ms以下");
                    m_Tools.Text_G("一般可以把Others屏蔽");

                });
                AddSpace_3();
            });
            m_Tools.BiaoTi_O("GPU Usage" + " GPU资源使用率".AddYellow(), ref _isGPU, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("手机保持在33ms以下");
                    m_Tools.Text_G("手机(CPU ms)那里应该低于2");

                });
                AddSpace_3();
            });

            m_Tools.BiaoTi_O("Rendering" + " 渲染显卡".AddYellow(), ref isRendering, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("渲染是以顶点作为基准的(不以面)，点越高，压力越大");
                    m_Tools.Text_G("Verts 应该低于超过80K");
                });
                AddSpace_3();
            });
            m_Tools.BiaoTi_O("Memory" + " 内存".AddYellow(), ref isMemory, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_O("把Simple转成Detailed，点Take Sample");
                    m_Tools.Text_O("直接看Assets中那些资源占用内存最多");
                    m_Tools.Text_O("（可双击到场景中看是那个资源、挂在那个身上）");
                    m_Tools.Text_G("Scene Memory 最多不要超过30m");
                });
                AddSpace_3();
            });
        }


        private void DrawProOther()                             // Profiler 其他
        {
            m_Tools.BiaoTi_B("其他", ref _isOther, () =>
            {
                m_Tools.ButtonText("Audio", "音频", ref isAudio, AudioMethod);
                m_Tools.ButtonText("Video", "视频", ref isVideo, Video);
                m_Tools.ButtonText("Physics", "物理碰撞", ref isPhysics, PhysicsMethod);
                m_Tools.ButtonText("Physics(2D)", "物理碰撞(2D)", ref isPhysics2D, PhysicsMethod2D);
                m_Tools.ButtonText("NetwordMessages", "网络通信", ref isNetwordMessages, NetwordMessages);
                m_Tools.ButtonText("NetwordOperations", "网络操作", ref isNetwordOperations, NetwordOperations);
            });
        }

        private void DrawTip()                                   // tip
        {
            m_Tools.Text_G("    Tip         ", ref isAtLastShow, () =>
            {
                m_Tools.Text_B("1.按Ctrl+7 打开Profiler面板");
                m_Tools.Text_B("2.想要连接手机使用Profiler:");
                m_Tools.Text("一.在Build Setting 中勾选了Development Build");
                m_Tools.Text("二.在Build Setting 中勾选了Autioconnect Profiler");
                m_Tools.Text("三.手机插在电脑上");
                m_Tools.Text("四.在Connected Player调整");
            });
        }

        #region 每一个按钮


        private void AudioMethod()
        {


        }

        private void Video()
        {


        }

        private void PhysicsMethod()
        {


        }

        private void PhysicsMethod2D()
        {


        }

        private void NetwordMessages()
        {


        }

        private void NetwordOperations()
        {


        }



        #endregion


        #endregion
    }

}

