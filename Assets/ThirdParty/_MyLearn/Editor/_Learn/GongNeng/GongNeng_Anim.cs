using DG.DOTweenEditor.Core;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class GongNeng_Anim : AbstactNewKuang
    {

        [MenuItem(LearnMenu.GongNeng_Anim)]
        static void Init()
        {
            GongNeng_Anim instance = GetWindow<GongNeng_Anim>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            #region Animation

            bool isAnimation = (type == EType.Animation || type == EType.Animation1 || type == EType.Animation2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Animation";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isAnimation ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Animation1);
            }
            if (isAnimation)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Animation1 ? "   面板".AddBlue() : "   面板");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Animation1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Animation2 ? "   API".AddBlue() : "   API");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Animation2);
                }
            }

            #endregion

            AddSpace();

            #region Animator


            bool isAnimator = (type == EType.Animator || type == EType.Animator1 || type == EType.Animator2 || type == EType.Animator3);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Animator";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Animator ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Animator);
            }

            if (isAnimator)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Animator1 ? "  Animator1".AddBlue() : "  Animator1");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Animator1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Animator2 ? "  Animator2".AddBlue() : "  Animator2");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Animator2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Animator3 ? "  Animator3".AddBlue() : "  Animator3");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Animator3);
                }
            }
            #endregion


            AddSpace();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "动画相关";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.AnimOther ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.AnimOther);
            }


            AddSpace();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Itween";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Itween ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Itween);
            }

            AddSpace();


            #region DoTween

            bool isDoTween = (type == EType.DoTween || type == EType.DoTween1 || type == EType.DoTween2 || type == EType.DoTween3 || type == EType.DoTween4 || type == EType.DoTween5 || type == EType.DoTween6 || type == EType.DoTween7);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "DoTween";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.DoTween ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.DoTween);
            }

            if (isDoTween)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween2 ? "  创建 Tweener 总结".AddBlue() : "  创建 Tweener 总结");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween3 ? "  相机、灯 扩展".AddBlue() : "  相机、灯 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween4 ? "  Transform 扩展".AddBlue() : "  Transform 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween5 ? "  渲染相关 扩展".AddBlue() : "  渲染相关 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween6 ? "  刚体 扩展".AddBlue() : "  刚体 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween6);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween7 ? "  音频 扩展".AddBlue() : "  音频 扩展");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween7);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTween1 ? "  Tools".AddBlue() : "  Tools");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTween1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.DoTweenPath ? "  DoTweenPath".AddBlue() : "  DoTweenPath");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.DoTweenPath);
                }
            }

            #endregion



        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Animation1: DrawRightPage1(DrawAnimationMain); break;
                case EType.Animation2: DrawRightPage3(DrawAnimation); break;
                case EType.Animator: DrawRightPage4(DrawAnimator); break;
                case EType.Animator1: DrawRightPage5(DrawAnimator1); break;
                case EType.Animator2: DrawRightPage6(DrawAnimator2); break;
                case EType.Animator3: DrawRightPage7(DrawAnimator3); break;
                case EType.AnimOther: DrawRightPage8(DrwXianGuan); break;
                case EType.Itween: DrawRightPage4(DrawItween); break;
                case EType.DoTween: DrawRightPage3(DrawDoTween); break;
                case EType.DoTween1: DrawRightPage8(DrawDoTween1); break;
                case EType.DoTween2: DrawRightPage7(DrawGWDo); break;
                case EType.DoTween3: DrawRightPage6(DrawKZ); break;
                case EType.DoTween4: DrawRightPage1(DrawTransformKX); break;
                case EType.DoTween5: DrawRightPage3(DrawRendererKZ); break;
                case EType.DoTween6: DrawRightPage4(DrawGTKZ); break;
                case EType.DoTween7: DrawRightPage5(DrawAKzx); break;
                case EType.DoTweenPath: DrawRightPage6(DrawDoTweenPath); break;
               
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.DoTween:
                    if (isTu)
                    {
                        mWindowSettings.pageWidthExtraSpace.target = 180;
                    }
                    else
                    {
                        mWindowSettings.pageWidthExtraSpace.target = 00;
                    }
                    break;
                case EType.Itween:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.DoTween3:
                    mWindowSettings.pageWidthExtraSpace.target = 70;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }



        #region 私有

        private bool isDOFade, isDOGradientColor, isDOffset, isDOTilling, isDORotate, isTu;
        private bool isAPI, isAnimationClip, isAnimationEvent, isAddClip, isAnimationState;
        private static readonly string ShaderPassName = "string Shader属性名".AddWhite();
        private static readonly string NoFrom = " (没有 Form 版本)".AddGreen();

        private enum EType
        {
            Animation, Animation1, Animation2,
            Animator, Animator1, Animator2, Animator3,
            AnimOther,
            Itween,
            DoTween, DoTween1, DoTween2, DoTween3, DoTween4, DoTween5, DoTween6, DoTween7,DoTweenPath,

        }

        private EType type = EType.Animation;

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
            return "动画";
        }

        private void Note()
        {
            m_Tools.BiaoTi_O("再次说明一点");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("    使用 .From()  ".AddGreen(), " ->  表示从 目的参数 到 对象参数");
            });
        }

        #endregion

        #region Animation


        private void DrawAnimation()                             // Animation API
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("Animation ".AddHui(), "是 ", "AnimationClip ".AddHui(), "的存储集合,可添加、删除，播放");
                m_Tools.Text_Y("AnimationClip".AddHui(), " 是Assets上的动画片断资源，可拖，可显示在面板上");
                m_Tools.Text_Y("Animation ".AddHui(), "实际运行动画时使用的对象是", " AnimationState".AddHui());
                m_Tools.Text_Y("AnimationState ".AddHui(), "允许播放动画时修改速度，重量，时间和图层");

                m_Tools.Text_G("总结：");
                m_Tools.Text_G("Animation".AddHui(), "集合  ", "AnimationClip".AddHui(), "资源  ", "AnimationState".AddHui(), "播放对象");
            });
            m_Tools.BiaoTi_O("Animation " + "API".AddYellow(), ref isAPI, () =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Animation.html");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("1. 支持循环遍历  ", "foreach (", "AnimationState ".AddLightBlue(), "state in anim)".AddHui());
                    m_Tools.Text_B("2. 支持索引器  ", "AnimationState".AddLightBlue(), " as = anim[“动画名”]".AddHui());

                });
                MyCreate.PropertiesWindow(() =>
                {
                    MyCreate.Text("与 Inspector 面板对应");
                    m_Tools.Method_BY("clip", "", "默认播放的动画", "AnimationClip", -30);
                    m_Tools.Method_BY("playAutomatically", "", "是否自动播放", "bool", -30);
                    m_Tools.Method_BY("animatephysics", "", "应用物理动画", "bool", -30);
                    m_Tools.Method_BY("cullingType", "", "剔除动画", "AnimationCullingType", -30);
                    MyCreate.Text("获取");
                    m_Tools.Method_BY("wrapMode", "", "播放模式", "WrapMode", -30);
                    m_Tools.Method_BY("isPlaying", "", "是否正在播放动画", "bool", -30);

                });
                MyCreate.MethodWindow(() =>
                {
                    MyCreate.Text("添加");
                    m_Tools.Method_BY("AddClip", "AnimationClip 片断，string 新名称", "", "", ref isAddClip, () =>
                    {
                        m_Tools.Method_BY("AddClip", "AnimationClip 片断,string 新名称,int 第一帧,int 最后帧,bool 是否循环", "");
                    });
                    MyCreate.Text("移除");
                    m_Tools.Method_BY("RemoveClip", "AnimationClip 片断/string 名", "", "");
                    MyCreate.Text("播放 （使用 string 动画名）");
                    m_Tools.Method_BY("CrossFade", "string", "淡出前动画，淡入该动画", "void", -50);
                    m_Tools.Method_BY("CrossFadeQueued", "string", "", "AnimationState");
                    m_Tools.Text_Y("    等待之前的动画结束后淡出，然后才淡入这个动画");
                    m_Tools.Method_BY("Play", "string", "无需等待，立即播放", "bool", -50);
                    m_Tools.Method_BY("playqueued", "String", "前动画播放完后播放此动画", "AnimationState", -50);
                    m_Tools.Method_BY("Rewind", "string ", "倒带", "");
                    MyCreate.Text("停止播放");
                    m_Tools.Method_BY("stop", "", "", "");
                    MyCreate.Text("判断");
                    m_Tools.Method_BY("IsPlaying", "string", "这个动画是否播放", "bool", -50);
                });


            });
            AddSpace();

            m_Tools.BiaoTi_O("AnimationState " + "animation[”名“]".AddYellow(), ref isAnimationState, () =>
            {
                MyCreate.PropertiesWindow(() =>
                {
                    m_Tools.Method_BY("blendMode", "", "应该使用哪种混合模式", "AnimationBlendMode", -60);
                    m_Tools.Method_BY("clip", "", "使用那个片断", "AnimationClip", -60);
                    m_Tools.Method_BY("enabled", "", "暂停动画", "bool", -60);
                    m_Tools.Method_BY("length", "", "动画长度，以 秒 为单位", "float", -60);
                    m_Tools.Method_BY("normalizedSpeed", "", "通常用于同步两个混合动画的播放速度", "float", -60);
                    m_Tools.Text_H("anim[”Run“].normalizedSpeed=anim[”Walk“].normalizedSpeed");
                    m_Tools.Method_BY("speed", "", "1：正常速度，负：向后播放", "float", -60);
                    m_Tools.Method_BY("time", "", "时间大于长度，将根据wrapMode进行包装", "float", -60);
                    m_Tools.Method_BY("weight", "", "动画曲线的混合权重", "float", -60);
                    m_Tools.Method_BY("wrapMode", "", "播放模式", "WrapMode", -60);
                });

            });
            AddSpace();


            m_Tools.BiaoTi_O("AnimationClip " + "存储关键帧的动画片断".AddYellow(), ref isAnimationClip, () =>
            {
                MyCreate.PropertiesWindow(() =>
                {
                    m_Tools.Method_BY("events", "", "此动画片段的动画事件", "AnimationEvent[]", -30);
                    m_Tools.Method_BY("wrapMode", "", "播放模式", "WrapMode", -30);
                });
                MyCreate.MethodWindow(() =>
                {
                    m_Tools.Method_BY("AddEvent", "AnimationEvent", "添加动画事件");
                });

            });
            AddSpace();


            m_Tools.BiaoTi_O("AnimationEvent " + "动画事件".AddYellow(), ref isAnimationEvent, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("动态向片断添加事件: " + "(退出游戏不会在编辑器留下)".AddLightGreen());
                    m_Tools.Text_H("AnimationClip clip;");
                    m_Tools.Text_H("AnimationEvent evt = new AnimationEvent();");
                    m_Tools.TextText_HG("evt.intParameter = 12345;", "// 传递 int 参数", 40);
                    m_Tools.TextText_HG("evt.time = 1.3f;", "// 设置时间点", 40);
                    m_Tools.TextText_HG("evt.functionName = “PrintEvent”;", "// 设置方法", 40);
                    m_Tools.TextText_HG("clip.AddEvent(evt);", "// 添加事件", 40);
                });
                MyCreate.PropertiesWindow(() =>
                {
                    MyCreate.Text("设置那个方法被调用");
                    m_Tools.Method_BY("functionName", "", "只能是" + "无参".AddGreen() + "或者" + "1个参数".AddGreen() + "的方法", "string", -20);

                    MyCreate.Text("设置参数");
                    m_Tools.Method_BY("floatParameter", "", "设置 float 参数", "float", -20);
                    m_Tools.Method_BY("intParameter", "", "设置 float 参数", "int", -20);
                    m_Tools.Method_BY("stringParameter", "", "设置 string 参数", "string", -20);
                    m_Tools.Method_BY("objectReferenceParameter", "", "设置 Object  参数", "Object", -20);
                    MyCreate.Text("设置事件发生在动画的那个时间点");
                    m_Tools.Method_BY("time", "", "时间点", "float", -20);

                    MyCreate.Text("判断");
                    m_Tools.Method_BY("isFiredByLegacy", "", "事件是否已被 Animation 触发", "bool", -20);
                    m_Tools.Method_BY("isFiredByAnimator", "", "事件是否已被 Animation 触发", "bool", -20);

                });

            });
            AddSpace();

        }


        private void DrawAnimationMain()                         // Animation 面板
        {

            m_Tools.TextText_BL("Animation", "默认播放的动画", -45);
            m_Tools.TextText_BL("Play Automatically", "是否自动播放默认动画", -45);
            m_Tools.TextText_BL("Animate Physics", "打开这个选项,动画会在物理循环过程中被执行", -45);
            MyCreate.Box(() =>
            {
                MyCreate.Text("开启这个选项：是为了应用物理系统");
                m_Tools.Text("1.这个动画物体要为刚体");
                m_Tools.Text("2.例如可以应用速度和摩擦到动画中体现");

            });
            m_Tools.TextText_BL("Culling Type", "剔除动画何时" + "暂停播放".AddGreen(), -45);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LG("Always Animate", "一直播放动画", -45);
                m_Tools.TextText_LG("Based on Renderers", "只要渲染不到就会暂停播放动画", -45);
            });

        }

        #endregion

        #region Animator


        private void DrawAnimator()
        {

        }
        private void DrawAnimator1()
        {

        }
        private void DrawAnimator2()
        {

        }
        private void DrawAnimator3()
        {

        }

        #endregion



        private void DrwXianGuan()                               // 动画相关
        {
            m_Tools.Text_Y("WrapMode " + "在 AnimationClip 面板中可以设置".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Once", "播放一次", -50);
                m_Tools.TextText_BL("Loop", "循环", -50);
                m_Tools.TextText_BL("PingPong", "返回在开始和结束之间 ", -50);
                m_Tools.TextText_BL("Default", "默认是动画怎么设置就怎么设置", -50);
                m_Tools.TextText_BL("ClampForever", "播放一次，结束保持在最后一帧", -50);
            });
        }


        private void DrawItween()                                // Itween
        {
            m_Tools.GuangFangWenDan("http://www.pixelplacement.com/itween/documentation.php");
            m_Tools.TextButton_Open("Itween 超叼的例子（抛物线、结合UGUI、物理、音效等等）", "F:/ZiLiao/iTween.unitypackage");

            MyCreate.Box(() =>
            {
                m_Tools.Text_L("优点：免费（直接在商店下载即可）、高效、简洁");
                m_Tools.Text_L("缺点：对 win8 不支持");
            });
            m_Tools.BiaoTi_B("简单来回运行例子：");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("1. 使用 Hashtable 集合");
                m_Tools.Text_H("Hashtable ht =new Hashtable()");
                m_Tools.TextText_HG("ht.Add（“x”，3）", "// x 到 3");
                m_Tools.TextText_HG("ht.Add（“time”，2）", "// 2 秒到达");
                m_Tools.TextText_HG("ht.Add（“delay”，1）", "// 延迟 1 秒");
                m_Tools.TextText_HG("ht.Add（“looptype”，iTween.LoopType.pingPong）", "// 来回运动");
                AddSpace_3();
                m_Tools.Text_H("iTween.MoveTo(gameObject，ht)");
                AddSpace_15();
                MyCreate.Text("2. 参数直接使用 iTween.Hash(“键1”,“值1”,“键2”,值2,“键3”,值3 ....)");

                m_Tools.Text_H("iTween.MoveTo(gameObject，");
                m_Tools.Text_H("      iTween.Hash(“x”,3，“time”，2，“looptype”，iTween.LoopType.pingPong))");

            });
        }


        #region DoTween


        private void DrawDoTween()                               // DoTween
        {
            m_Tools.GuangFangWenDan("http://dotween.demigiant.com/getstarted.php");

            m_Tools.BiaoTi_B("动画曲线");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Linear", "线性", 120);
                m_Tools.TextText_BL("InSine、OutSine、InOutSine", "正弦", 120);
                m_Tools.TextText_BL("InQuad、OutQuad、InOutQuad", "四", 120);
                m_Tools.TextText_BL("InCubic、OutCubic、InOutCubic", "立方体", 120);
                m_Tools.TextText_BL("InQuart、OutQuart、InOutQuart", "夸脱", 120);
                m_Tools.TextText_BL("InQuint、OutQuint、InOutQuint", "昆特", 120);
                m_Tools.TextText_BL("InExpo、OutExpo、InOutExpo", "展览会", 120);
                m_Tools.TextText_BL("InCirc、OutCirc、InOutCirc", "循环的", 120);
                m_Tools.TextText_BL("InElastic、OutElastic、InOutElastic", "弹", 120);
                m_Tools.TextText_BL("InBack、OutBack、InOutBack", "背部", 120);
                m_Tools.TextText_BL("InBounce、OutBounce、InOutBounce", "弹跳", 120);
            });
            m_Tools.BiaoTi_Y("图解", ref isTu, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201808/959112-20180813131512378-1785189343.png");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201808/959112-20180813131454363-579743142.png");
            });
            if (!isTu)
            {
                MyCreate.AddSpace(30);
            }

        }


        private void DrawDoTween1()                              // 没用的 Tools
        {
            m_Tools.BiaoTi_O("DoTween Utility Panel");
            m_Tools.BiaoTi_B("Setup 安装");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("就是官方文档之类的");
            });

            m_Tools.BiaoTi_B("Preferences 优先");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Safe Mode", "安全模式");
                m_Tools.TextText_BL("Editor Report", "编辑报告");
                m_Tools.TextText_BL("Log Behaviour", "记录行为");
                m_Tools.TextText_BL("Draw Path Gizmos", "画路径的 Gizmos");
                m_Tools.TextText_BL("Settings Location", "设置位置");
                m_Tools.TextText_BL("DEFAULTS", "默认值");
                m_Tools.TextText_BL("Recycle Tweens", "回收 Tweens");
                m_Tools.TextText_BL("AutoPlay", "自动播放");
                m_Tools.TextText_BL("Update Type", "更新类型");
                m_Tools.TextText_BL("TimeScale Independent", "独立的 TimeScale");
                m_Tools.TextText_BL("Ease", "缓解");
                m_Tools.TextText_BL("Ease Overshoot", "缓解过冲");
                m_Tools.TextText_BL("Ease Period", "缓和期");
                m_Tools.TextText_BL("AutoKill", "自动删除");
                m_Tools.TextText_BL("Loop Type", "循环模式");
            });


        }



        private void DrawGWDo()                                  // 创建 Tweener 总结
        {
            m_Tools.BiaoTi_O("创建一个 Tweener" + "（包含以下的类型）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("float, double, int, uint, long, ulong, Vector2/3/4");
                m_Tools.Text_Y("Quaternion, Rect, RectOffset, Color, string");
                m_Tools.Text_H("有以下的3个方式来创建一个 Tweener：");
            });
            m_Tools.BiaoTi_B("1. 通用方式" + "(通用所有类型)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("例子：".AddBlue());
                m_Tools.Text_W("• Vector3 v =（0，0，0）  -> 在 1 秒内升到 (3,4,8)");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     DOTween.To(()=> v, x=> v = x, new Vector3(3,4,8), 1);");
                });
                m_Tools.Text_W("• float f = 0  -> 在 1 秒内升到 52");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     DOTween.To(()=> f, x=> f = x, 52, 1);");
                });
                MyCreate.Text("模式：：".AddYellow());
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_YL("1. 那个变量需要变化", "()=> v", 50);
                    m_Tools.TextText_YL("2. 委托返回的值要交给谁", "x=> v", 50);
                    m_Tools.Text_Y("3. 达到的最终值            4. 持续时间");
                });

            });
            m_Tools.BiaoTi_B("2. 快捷键的方法" + "(就是对应类型的扩展方法)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("例子：".AddBlue());
                m_Tools.Text_W("• 脚本对象原坐标（x，x，x） 1 秒内移动到 （0，0，0）");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     transform.DOMove(Vector3.zero, 1);");
                });
                m_Tools.Text_W("• 而从（0，0，0）移动到脚本对象原坐标（x，x，x）只需增加 ", ".From() ".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     transform.DOMove(Vector3.zero, 1)", ".From();".AddGreen());
                });

            });
            m_Tools.BiaoTi_B("3. 其他通用方法"+"(使用 DOTween Static 方法)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("DOTween.Punch", "Vector3 冲", 20);
                m_Tools.TextText_BL("DOTween.Shake", "震动",20);
                m_Tools.TextText_BL("DOTween.ToAlpha", "透明度",20);
                m_Tools.TextText_BL("DOTween.ToArray", "Vector3",20);
                m_Tools.TextText_BL("DOTween.ToAxis", "Vector3 轴", 20);
            });

        }

        private void DrawKZ()                                    // 相机、灯扩展
        {
            Note();
            m_Tools.BiaoTi_B("Camera 扩展");
            MyCreate.Box(() =>
            {
                MyCreate.Text("以 Camera 属性作为变化的".AddGreen());
                m_Tools.Method_YL("DOAspect", "float 目的，float 时间", "Aspect -> ".AddBlue() + "最终游戏屏幕的宽高比", "", 80);
                m_Tools.Method_YL("DOColor", "Color 目的，float 时间", "backgroundColor -> ".AddBlue() + "背景颜色", "", 80);
                m_Tools.Method_YL("DOFarClipPlane", "float 目的，float 时间", "farClipPlane -> ".AddBlue() + "远范围面", "", 80);
                m_Tools.Method_YL("DONearClipPlane", "float 目的，float 时间", "nearClipPlane -> ".AddBlue() + "近范围面", "", 80);
                m_Tools.Method_YL("DOFieldOfView", "float 目的，float 时间", "fieldOfView -> ".AddBlue() + "视图绘制在屏幕什么地方", "", 80);
                m_Tools.Method_YL("DOOrthographicSize", "float 目的，float 时间", "orthographicSize -> ".AddBlue() + "正交投影的大小", "", 80);
                m_Tools.Method_YB("DOPixelRect", "Rect 目的，float 时间", "pixelRect", "", 80);
                m_Tools.Method_YB("DORect", "float 目的，float 时间", "rect ", "", 80);
                MyCreate.Text("相机 震动 功能".AddGreen());
                m_Tools.Method_OY("DOShakePosition", "float，float", "localPosition 沿X Y轴震动", "", 100);
                m_Tools.Method_OY(ZhongZai + "DOShakePosition", "float，Vector3", "每个轴有不同的强度的震动", "", 100);
                m_Tools.Method_OY(ZhongZai + "DOShakePosition", "float，float/Vector3，int = 10 ，float = 90 ，bool = false", "");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("注意1：震动没有 From 版本");
                    m_Tools.Text_G("注意2：震动的是 localPosition 的 X、Y轴，没有Z轴");
                    m_Tools.TextText_HW("    第一参数 float", "持续时间", 60);
                    m_Tools.TextText_HW("    第二参数 float/Vector3", "X、Y 轴震动的距离(强度)", 60);
                    m_Tools.TextText_HW("    第三参数 int", "震动多少次", 60);
                    m_Tools.TextText_HW("    第四参数 float", "震动随机值多少", 60);
                    m_Tools.TextText_HW("    第五参数 bool", "是否非常强烈", 60);
                });
                m_Tools.Method_OY("DOShadeRotation", "float，float", "localRotation 的震动", "", 100);
                m_Tools.Method_OY(ZhongZai + "DOShadeRotation", "float，Vector3", "每个轴有不同的强度的震动", "", 100);
                m_Tools.Method_OY(ZhongZai + "DOShakePosition", "float，float/Vector3，int = 10 ，float = 90", "  同上");
            });
            AddSpace();
            m_Tools.BiaoTi_B("Light 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("DOColor", "Color 目的，float 时间", "color -> ".AddWhite() + "灯的颜色", "", 80);
                m_Tools.Method_BL("DOIntensity", "float 目的，float 时间", "intensity -> ".AddWhite() + "灯的强度", "", 80);
                m_Tools.Method_BL("DOShadowStrength", "float 目的，float 时间", "shadowStrength -> ".AddWhite() + "阴影强度", "", 80);
            });
        }


        private void DrawTransformKX()                            // Transform 扩展
        {
            m_Tools.BiaoTi_O("Move 移动");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("DOMove / DOMoveX / DOMoveY / DOMoveZ");
                m_Tools.Text_Y("DOLocalMove / DOLocalMoveX / DOLocalMoveY / DOLocalMoveZ");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    都是三个参数：", "Vector3 目的，float 时间，bool = false".AddBlue());
                    m_Tools.Text_H("    第三参数表示：", "true：tween 会将所有值平滑地捕捉到整数".AddLightBlue());
                });
            });
            m_Tools.BiaoTi_O("Jump 跳");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("DOJump/DOLocalJump", "Vector3，float，int，float，bool = false", "", "", 80);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    参一 Vector3", "（要达到的最终值）".AddBlue(), "   参二 float", "(跳跃的最大高度 Y 轴)".AddBlue());
                    m_Tools.Text_H("    参三 int", "（跳转总数） ".AddBlue(), "  参四 float", "(时间)".AddBlue(), "     参五bool", "(是否平滑到整数)".AddBlue());
                });
            });
            m_Tools.BiaoTi_O("Rotate 旋转");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("DORotate / DOLocalRotate", "Vector3 目的，float 时间，RotateMode 模式", "", "", ref isDORotate,
                    () =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_L("  注意1：需要 Vector3 结束值，旋转首选，特定才使用下面的四元数方法");
                            m_Tools.Text_L("  注意2：RotateMode 旋转模式 -> 枚举");
                            m_Tools.Text4_L("Fast" + "默认".AddGreen(), "最短，旋转不会超过360", "FastBeyond360", "旋转将超过360°", 50);
                            m_Tools.Text4_L("WorldAxisAdd", "结束值始终被视为相对值", "LocalAxisAdd", "本地轴添加", 50);
                        });
                    }, 80);
                m_Tools.Method_YL("DORotateQuaternion / DOLocalRotateQuaternion", "Quaternion，float", "", "", 80);
                m_Tools.Method_YL("DOLookAt", "Vector 方向，float 时间，AxisConstraint = None，Vector3 = Up", "", "", 80);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("    旋转目标，使其朝向给定位置");
                    m_Tools.Text_L("    参三AxisConstraint(旋转的最终轴约束)  参四 Vector3（定义向上的向量）");
                });
            });
            m_Tools.BiaoTi_O("Scale 大小");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("DoScale / DoScaleX / DoScaleY / DoScaleZ");
            });
            m_Tools.BiaoTi_O("Punch  冲" + NoFrom);
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("DOPunchPosition / DOPunchRotation / DOPunchScale");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("    DOPunchPosition：冲向目标，速度会慢慢地减弱，直到目标处时为 0");
                    m_Tools.Text_H("    DOPunchRotation：就像一巴掌抓拍过去，物体旋转，然后慢慢地减弱");
                });
            });
            m_Tools.BiaoTi_O("Shake  震动" + NoFrom);
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("DOShakePosition / DOShakeRotation / DOShakeScale");
            });
            m_Tools.BiaoTi_O("Path   路径" + NoFrom);
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("DOPath / DOLocalPath ");
            });
            m_Tools.BiaoTi_O("Spiral  螺旋" + NoFrom);
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("螺旋形状转圈圏 -> 慢慢减速  -> 回到原点");
                m_Tools.Text_Y("DOSpiral");
            });

        }


        private void DrawRendererKZ()                            // 渲染相关 扩展
        {
            m_Tools.BiaoTi_B("Material 扩展");
            MyCreate.Box(() =>
            {
                MyCreate.Text("带 Shader 属性重载的");
                m_Tools.Method_YB("DOColor", "Color 目的，float 时间", "颜色", "", 80);
                m_Tools.Method_YB(ZhongZai + "DOColor", "Color 目的，" + ShaderPassName + "，float 时间", "");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("material.DOColor(Color.green,“_SpecColor”, 1)", "  // 例子：镜面颜色");
                });
                m_Tools.Method_YB("DOFade", "float 目的，float 时间", "颜色 alpha 透明度", "", ref isDOFade, () =>
                {
                    m_Tools.Method_YB(ZhongZai + "DoFade", "float 目的，" + ShaderPassName + "，float 时间", "");
                }, 80);

                m_Tools.Method_YB("DOGradientColor", "float 目的，float 时间", "渐变颜色", "", ref isDOGradientColor, () =>
                {
                    m_Tools.Method_YB(ZhongZai + "DOGradientColor", "float 目的，" + ShaderPassName + "，float 时间", "");
                }, 80);
                m_Tools.Method_YB("DOffset", "Vector2 目的，float 时间", "textureOffset", "", ref isDOffset, () =>
                {
                    m_Tools.Method_YB(ZhongZai + "DOffset", "Vector2 目的，" + ShaderPassName + "，float 时间", "");
                }, 80);
                m_Tools.Method_YB("DOTilling", "Vector2 目的，float 时间", "textureScale ", "", ref isDOTilling, () =>
                {
                    m_Tools.Method_YB(ZhongZai + "DOTilling", "Vector2 目的，" + ShaderPassName + "，float 时间", "");
                }, 80);

                MyCreate.Text("单一个扩展的");
                m_Tools.Method_YB("DOFloat", "float 目的，" + ShaderPassName + "，float 时间", "", "", 80);
                m_Tools.Method_YB("DOVector", "Vector4 目的，" + ShaderPassName + "，float 时间", "", "", 80);

            });
            m_Tools.BiaoTi_B("LineRenderer 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YB("DOColor", "Color2 开始值，Color2 结束值，float 时间", "颜色", "", 100);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("     Color2 -> struct 结构体 ->  new Color2(Color 头，Color 尾)");
                });

            });
            m_Tools.BiaoTi_B("SpriteRenderer 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("DOColor", "（颜色）".AddHui(), "、DOFade", "（透明度）".AddHui(), "、DOGradientColor", "（渐变颜色）".AddHui());
            });
            m_Tools.BiaoTi_B("TrailRenderer 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YB("DOResize", "float 宽度头，float 宽度尾，float 时间", "startWidth/endWidth", "", 100);
                m_Tools.Method_YB("DOTime", "float 目的，float 时间", "time ->" + "拖尾滞留时间".AddLightBlue(), "", 100);
            });

        }

        private void DrawGTKZ()                                   // 刚体 扩展
        {
            Note();
            m_Tools.BiaoTi_B("Rigidbody 扩展 ");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("DOMove", "");
                m_Tools.TextText_BL("DOMoveX/Y/Z", "");
                m_Tools.TextText_BL("DOJump", "");
                m_Tools.TextText_BL("DORotate", "");
                m_Tools.TextText_BL("DOLookAt", "");
                m_Tools.TextText_BL("DOSpiral", "");
            });
            m_Tools.BiaoTi_B("Rigidbody2D 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("DOMove", "");
                m_Tools.TextText_BL("DOMoveX/Y/Z", "");
                m_Tools.TextText_BL("DOJump", "");
                m_Tools.TextText_BL("DORotate", "");
            });
        }

        private void DrawAKzx()                                   // 音频 扩展
        {
            Note();
            AddSpace();
            m_Tools.BiaoTi_B("AudioSource 扩展");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("DOFade", "float 目的，float 时间", "volume -> " + "音量".AddGreen(), "", 50);
                m_Tools.Method_BL("DOPitch", "float 目的，float 时间", "pitch -> ".AddWhite() + "高音", "", 50);
            });

            AddSpace();
            m_Tools.BiaoTi_B("AudioMixer 扩展");
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_LH("AudioMixer", "  音效混合器");
                    m_Tools.TextTextOpen_LH("Unity5.x 音效 AudioMixer", "（讲得不错的博客）", () =>
                    {
                        Application.OpenURL("https://blog.csdn.net/yupu56/article/details/75212660");
                    });
                });
                m_Tools.Method_BL("DOSetFloat", "string floatName,float 目的，float 时间", "", "", 50);


            });


        }




        private void DrawDoTweenPath()                            // DotweenPath
        {


            m_Tools.BiaoTi_L("Scene View Commands"+"（场景视图命令）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Shift + Ctrl","增加导航点");
                m_Tools.TextText_WL("Shift + Alt","移除导航点");
            });
            AddSpace();
            m_Tools.BiaoTi_B("Path Tween Options"+"（路径动画设置）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_YB("Path Type", "轨迹线类型"+ "(Linear：线型， Catmull Rom：曲线)".AddLightBlue(),-20);
                m_Tools.TextText_YB("Close Path", "true: 封闭曲线，将起点和终点相连", -20);
                m_Tools.TextText_YB("Local Movement", "true：本地坐标移动  false：世界坐标移动", -20);
                m_Tools.TextText_YB("Orientation", "朝向", -20);
            });
            AddSpace();
            m_Tools.BiaoTi_B("Path Editor Options" + "（编辑器中 路径设置）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_YB("Relative", "相对的，表示路径跟随物体移动", -20);
                m_Tools.TextText_YB("Color", "颜色", -20);
                m_Tools.TextText_YB("Show Indexes", "是否显示索引", -20);
                m_Tools.TextText_YB("Live Preview", "", -20);
                m_Tools.TextText_YB("Mandles Type", "", -20);
                m_Tools.TextText_YB("Handles Mode", "", -20);
            });
        }


        #endregion



    }

}

