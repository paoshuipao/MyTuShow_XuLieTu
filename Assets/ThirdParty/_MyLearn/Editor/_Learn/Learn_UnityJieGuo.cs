using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Learn_UnityJieGuo : AbstactNewKuang
    {

        [MenuItem(LearnMenu.UnityJieGou,false, LearnMenu.Unity_INDEX)]
        static void Init()
        {
            Learn_UnityJieGuo instance = GetWindow<Learn_UnityJieGuo>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {

            #region Unity 结构图

            bool isUntiy = (type == EType.JieGuo || type == EType.JieGuo1 || type == EType.JieGuo2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Unity 结构图";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JieGuo ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JieGuo);
            }

            if (isUntiy)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieGuo1 ? "  AudioSource".AddBlue() : "  AudioSource");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieGuo1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieGuo2 ? "  Projector".AddBlue() : "  Projector");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieGuo2);
                }

            }



            #endregion

            AddSpace_3();

            #region 生命周期图

            bool isLife = (type == EType.ShenMing || type == EType.ShenMing2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "生命周期图";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ShenMing ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ShenMing);
            }
            if (isLife)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.ShenMing2 ? "  官方 详细图".AddBlue() : "  官方 详细图");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.ShenMing2);
                }
            }


            #endregion


            AddSpace_3();


            #region 基类


            bool isJiLie = (type == EType.JiLie || type == EType.JiLie1 || type == EType.JiLie2 || type == EType.JiLie3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "基类";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JiLie ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JiLie1);
            }
            if (isJiLie)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiLie1 ? "   Object".AddBlue() : "   Object");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiLie1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiLie2 ? "   Component".AddBlue() : "   Component");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiLie2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiLie3 ? "   Behaviour".AddBlue() : "   Behaviour");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiLie3);
                }
            }
            #endregion

            AddSpace_3();

            #region MonoBehaviour

            bool isMonoBehaviour = (type == EType.MonoBehaviour || type == EType.MonoBehaviour1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "MonoBehaviour".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.MonoBehaviour ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.MonoBehaviour);
            }

            if (isMonoBehaviour)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.MonoBehaviour1 ? "   回调事件".AddBlue() : "   回调事件");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.MonoBehaviour1);
                }
            }
            #endregion

            AddSpace_3();


            #region Transform/GameObject

            bool istg = (type == EType.TG || type == EType.Transform || type == EType.GameObject || type == EType.Find);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Transform/GameObject".AddSize(12);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.TG ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.TG);
            }


            if (istg)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Transform ? "   Transform".AddBlue() : "   Transform");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Transform);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.GameObject ? "   GameObject".AddBlue() : "   GameObject");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.GameObject);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Find ? "   查找 Find".AddBlue() : "   查找 Find");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Find);
                }

            }



            #endregion

            AddSpace_3();

            #region Unity 事件

            bool isTX = (type == EType.TX1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Unity 事件".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isTX ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.TX1);
            }

            if (isTX)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.TX1 ? "   UnityEvent".AddBlue() : "   UnityEvent");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.TX1);
                }
            }
            #endregion
            AddSpace_3();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "游戏暂停".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isTX ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.TimeScale);
            }
        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.JieGuo:           DrawRightPage1(DrawUnityJieGuo);        break;
                case EType.JieGuo1:          DrawRightPage8(DrawAudioSource);        break;
                case EType.JieGuo2:          DrawRightPage3(DrawProjector);          break;
                case EType.ShenMing:         DrawRightPage(DarwShengMing);           break;
                case EType.ShenMing2:        DrawRightPage(DrawShengMing2);          break;
                case EType.JiLie1:           DrawRightPage3(DrawObject);             break;
                case EType.JiLie2:           DrawRightPage4(DrawComponent);          break;
                case EType.JiLie3:           DrawRightPage5(DrawBehaviour);          break;
                case EType.MonoBehaviour:    DrawRightPage5(DrawMonoBehaviourAPI);   break;
                case EType.MonoBehaviour1:   DrawRightPage6(DrawMonoCallMethods);    break;
                case EType.Transform:        DrawRightPage7(DrawTransform);          break;
                case EType.GameObject:       DrawRightPage8(DrawGameObject);         break;
                case EType.Find:             DrawRightPage1(DrawFind);               break;
                case EType.TX1:              DrawRightPage3(DrwUnityEvent);          break;
                case EType.TimeScale:        DrawRightPage5(DrawTimeScale);          break;


            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.JiLie2:
                    mWindowSettings.pageWidthExtraSpace.target = -15;
                    break;
                case EType.JieGuo:
                    mWindowSettings.pageWidthExtraSpace.target = 15;
                    break;
                case EType.Find:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -30;
                    break;
            }
        }

        #region 私有

        private bool isDetachChildren, isRotate, isTranslate, isCreatePrimitive, ishideFlags, isTextureFormat, isProjectorTu;


        private enum EType
        {
            JieGuo, JieGuo1, JieGuo2,
            ShenMing, ShenMing2,

            JiLie, JiLie1, JiLie2, JiLie3,
            MonoBehaviour, MonoBehaviour1,

            TG,Transform, GameObject,Find,

            TX1,

            TimeScale,

        }

        private EType type = EType.JieGuo;

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
            return "Unity 结构图";
        }


        private static readonly string myEventStr = "myEvent".AddYellow();
        private static readonly string SerializableStr = "[Serializable]".AddGreen();


        private void DrwUnityEvent()
        {
            m_Tools.BiaoTi_B("说明");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("• 如： Button 底下的 OnClick 也是使用这个 UnityEvent");
                m_Tools.Text_L("• UnityEvent<T0> 是 abstract 类，必须继承才能用");
                m_Tools.Text_L("• 一定要添加 ", SerializableStr, " 特性");

            });
            AddSpace_3();
            m_Tools.BiaoTi_B("使用例子");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("1. 想要什么参数就在泛型中添加，直接继承类即可");
                m_Tools.Text(SerializableStr);
                m_Tools.Text_H("public class MyEvent : UnityEvent<int> { }");
                MyCreate.Text("2. 在真正的 MonoBehaviour 类中添加字段 即可");
                m_Tools.Text(SerializableStr);
                m_Tools.Text_H("public MyEvent ", myEventStr);
            });
            m_Tools.BiaoTi_B("注册与发送事件");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("注册：");
                m_Tools.Text_L("    • 在面板上拖拽");
                m_Tools.Text_L("    • ", myEventStr, ".AddListener( 方法 )");

                MyCreate.Text("发送事件：");
                m_Tools.Text_L("    • ", myEventStr, ".Invoke()");

            });

        }

        #endregion


        #region 生命周期图

        private void DarwShengMing()                             // 生命周期图
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709175520790-486882522.png",15);
        }


        private void DrawShengMing2()                           // 生命周期图(官方)
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/ExecutionOrder.html", "生命周期");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180709171240120-773408186.png", 15);
        }

        #endregion


        #region MonoBehaviour

        private void DrawMonoBehaviourAPI()                      // MonoBehaviour API
        {
            m_Tools.BiaoTi_O("MonoBehaviour API " + "（就多了 Invoke 和 协程）".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承 ->" + " Component ".AddOrange() + "(组件基类) ->" + " Behavior ".AddOrange() + "(可启用、禁用)");
            });
            AddSpace();
            MyCreate.MethodWindow(() =>
            {
                m_Tools.BiaoTi_B("Invoke 调用");
                MyCreate.Box(() =>
                {
                    m_Tools.Method_BL("Invoke", "string 方法名，float 几秒调用该方法", "");
                    m_Tools.Method_BL("InvokeRepeating", "string 方法名，float 几秒调用该方法，float 几秒重复一次", "");
                    m_Tools.Method_BL("CancelInvoke", "", "取消此 Mono 上的所有Invoke调用");
                    m_Tools.Method_BL("IsInvoking", "string 方法名", "这个方法是否被 Invoke 调用");
                });
                AddSpace();
                m_Tools.BiaoTi_B("Coroutine 协程");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("开始协程 ", "StartCoroutine".AddBlue(), "     结束协程", " StopCoroutine".AddBlue());
                    m_Tools.Text_G("(开始协程与结束协程的参数要一致才能结束)");
                    m_Tools.Method_BL("StopAllCoroutines", "", "停止所有运行的协程");

                });
            });





        }


        private void DrawMonoCallMethods()                       // MonoBehaviour 回调函数
        {
            MyCreate.Box(() =>
            {
                MyCreate.Text("关于复选框的说明：".AddYellow());
                m_Tools.Text_L("1.没有一个下面的函数就", "不会显示".AddGreen() + "复选框");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("    Start、Update、FixedUpdate、LateUpdate、OnGUI");
                    m_Tools.Text_W("    OnEnable、OnDisable");
                });
                m_Tools.Text_L("2.", "禁用".AddGreen(), "复选框只能禁用上面的函数的调用，下面函数一定会调用：");
                m_Tools.Text_L("    如", " Awake".AddWhite(), "、", "OnDestroy".AddWhite());
            });
            AddSpace();
            m_Tools.BiaoTi_O("MonoBehaviour 回调函数");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_Y("受复选框 Enable 控制的");
                MyCreate.Text("初始化、启用与禁用");
                m_Tools.Text_W("Start、OnEnable、OnDisable");
                MyCreate.Text("调用多次");
                m_Tools.Text_W("Update、FixedUpdate、LateUpdate、OnGUI");
                AddSpace();
                m_Tools.BiaoTi_Y("下面函数都是不受复选框 Enable 控制");
                m_Tools.Text_W("Reset、Awake、OnDestroy、OnApplicationQuit" + "（游戏退出）".AddLightGreen());
                AddSpace_3();
                m_Tools.BiaoTi_Y("可在前面添加 IEnumerator 当协程使用");
                m_Tools.Method_BL("OnApplicationFocus", "bool true:有焦点", "当" + "获得或失去焦点".AddGreen() + "发送所有对象");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("    1. 如切换出去另一应用程序时会调用", " OnApplicationFocus（false）".AddHui());
                    m_Tools.Text_Y("    2. 当切换出去再切换进来会再次调用 ", " OnApplicationFocus（true）".AddHui());
                    m_Tools.Text_Y("    3 .Android 启用", "屏幕键盘".AddGreen(), "时 会调用 " + "OnApplicationFocus（false）".AddHui());
                    m_Tools.Text_Y("    3. 如果在启用键盘时按 ", "Home 键".AddGreen(), " 会调用 " + "OnApplicationPause".AddHui());
                    m_Tools.Text_Y("    4. 可以是一个协同函数");
                });
                m_Tools.Method_BL("OnApplicationPause", "bool true:程序暂停", "当" + "程序暂停".AddGreen() + "发送所有对象", "");

            });
            AddSpace();
        }

        #endregion


        #region  Unity 结构


        private void DrawUnityJieGuo()                          // Unity 结构
        {
            
            m_Tools.BiaoTi_Y("继承 Object");
            DrawnOne("Component " + "(所有附加到 GameObject 的组件基类)".AddGreen(), () =>
            {
                DrawTwo("Behaviour " + "(可以启动和禁用的组件)".AddGreen(), () =>
                {
                    DrawThree("MonoBehaviour" + "（增加 Invoke 和 协程）".AddGreen(), null);
                    DrawThree("Camera、AudioSource、Light、Projector" + "(投影)".AddLightGreen(), null);
                    DrawThree("Animation、Animator", null);
                });
                DrawTwo("Transform", () =>
                {
                    DrawThree("RectTransform", null);

                });
                
                DrawTwo("Rigidbody、WindZone", null);
                DrawTwo("Collider", () =>
                {
                    DrawThree("BoxCollider、MeshCollider、CharacterController", null);
                });
                DrawTwo("Renderer", () =>
                {
                    DrawThree("SkinnedMeshRenderer、MeshRenderer", null);
                    DrawThree("SpriteRenderer、LineRenderer", null);
                });
            });
            DrawnOne("GameObject", null);
            DrawnOne("AssetBundle", null);
            DrawnOne("Material、PhysicMaterial、ScriptableObject", null);
            DrawnOne("AudioClip", null);
            DrawnOne("Sprite", null);
            DrawnOne("Texture" + "（可以直接扔在 renderer.material.mainTexture = xxx）".AddGreen(), () =>
            {
                DrawTwo("Texture2D、MovieTexture、WebCamTexture", null);
                DrawTwo("RenderTexture " + "（渲染纹理，通常给 Camera 使用）".AddGreen(), null);
            });

            AddSpace();
            m_Tools.BiaoTi_B("简单总结下：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_BL("Object", "Unity " + "所有引用对象的基类".AddGreen(), -46);
                m_Tools.TextText_BL("GameObject", "Unity 场景中" + "所有实体对象".AddGreen(), -46);
                m_Tools.TextText_BL("Component", "所有附加".AddGreen() + "到 " + "GameObject ".AddBlue() + "的" + "组件基类".AddWhite(), -46);
                m_Tools.TextText_BL("Behaviour", "继承 " + "Component".AddBlue() + "，可以" + "启用".AddGreen() + "或" + "禁用".AddGreen() + "的" + "组件基类".AddWhite(), -46);
                m_Tools.TextText_BL("Transform", "继承" + " Component".AddBlue() + "，对象位置、旋转、缩放的" + "组件实现类".AddWhite(), -46);
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("所以 Transform 不具有启用和禁用功能的，是一定存在的组件");
                    m_Tools.Text_H("而 MonoBehaviour 继承 Behaviour，可以具有启用和禁用功能");
                });
                m_Tools.TextText_BH("RectTransform", "RectTransform rt = transform as RectTransform ", -46);

                m_Tools.TextText_BL("MonoBehaviour", "继承" + " Behaviour".AddBlue() + "增加 协程 和 Invoke", -46);


            });
        }



        private void DrawProjector()                             // Projector投影
        {
            m_Tools.Text_G("图例", ref isProjectorTu, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711202938433-628627248.png");
            });

            MyCreate.AddSpace(12);
            MyCreate.Window("Projector投影仪作用：", () =>
            {
                m_Tools.Text_W("1. 创建 阴影");
                m_Tools.Text_W("2. 使得现实世界与投影处相交的地方使用 " + "渲染纹理".AddGreen());
                m_Tools.Text_W("3. 枪弹 痕迹 的 形成");
                m_Tools.Text_W("4. 时髦 的 照明 效果");
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("面板", () =>
            {
                m_Tools.TextText_BL("Ignore Layers", "那个层会被忽略", -50);
                m_Tools.TextText_BL("Near Clip Plane", "近切面", -50);
                m_Tools.TextText_BL("Far Clip Plane", "远近面", -50);
                m_Tools.TextText_BL("Field Of View", "透视投影情况下的角度大小", -50);
                m_Tools.TextText_BL("Aspect Ratio", "长宽比", -50);
                m_Tools.TextText_BL("Orthographic", "是否正交投影", -50);
                m_Tools.TextText_BL("Orthographic Size", "正交投影的大小", -50);
                m_Tools.TextText_BL("Material", "必填的特定Shader材质，否则没效果", -50);
            });
            MyCreate.TextCenter("使用的 Shader");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("Properties =>");
                m_Tools.Text_H("_Color (\"投影颜色\", Color) = (1,1,1,1)");
                m_Tools.Text_H("_Attenuation (\"透明度\", Range(0.0, 1.0)) = 1.0");
                m_Tools.Text_H("_ShadowTex (\"图片\", 2D) = \"gray\" {}");

                AddSpace_3();
                MyCreate.Text("Subshader =>");
                m_Tools.Text_H("Tags {\"Queue\"=\"Transparents\"}");

                m_Tools.Text_H("Pass {");
                m_Tools.Text_H("     ZWrite Off");
                m_Tools.Text_H("     ColorMask RGB");
                m_Tools.Text_H("     Blend SrcAlpha One");
                m_Tools.Text_H("     Offset -1, -1");
                m_Tools.Text_H("     ");
                m_Tools.Text_H("     CGPROGRAM");
                m_Tools.Text_H("     #pragma vertex vert");
                m_Tools.Text_H("     #pragma fragment frag");
                m_Tools.Text_H("     #include \"UnityCG.cginc\"");
                m_Tools.Text_H("     ");
                m_Tools.Text_H("     sampler2D _ShadowTex;");
                m_Tools.Text_H("     fixed4 _Color;");
                m_Tools.Text_H("     float _Attenuation;");
                m_Tools.TextText_HG("     float4x4 unity_Projector;", "     // 系统提供的投影参数");
                m_Tools.TextText_HG("     float4x4 unity_ProjectorClip;", "// 这个也是，但是下面没用到");
                m_Tools.Text_H("     ");
                m_Tools.Text_H("     struct v2f ");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("         float4 uvShadow : TEXCOORD0;");
                m_Tools.Text_H("         float4 pos : SV_POSITION;");
                m_Tools.Text_H("     };");
                m_Tools.Text_H("     ");
                m_Tools.Text_H("     v2f vert (float4 vertex : POSITION)");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("         v2f o;");
                m_Tools.Text_H("         o.pos = UnityObjectToClipPos (vertex);");
                m_Tools.Text_H("         o.uvShadow = mul (unity_Projector, vertex);");
                m_Tools.Text_H("         return o;");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("     ");
                m_Tools.Text_H("     fixed4 frag (v2f i) : SV_Target");
                m_Tools.Text_H("     {");
                m_Tools.Text_H("         fixed4 texCookie = tex2Dproj");
                m_Tools.Text_H("                (_ShadowTex, UNITY_PROJ_COORD(i.uvShadow));");
                m_Tools.Text_H("         fixed4 outColor = _Color * texCookie.a;");
                m_Tools.Text_H("         float depth = i.uvShadow.z;");
                m_Tools.Text_H("         return outColor * clamp");
                m_Tools.Text_H("                (1.0 - abs(depth) + _Attenuation, 0.0, 1.0);");
                m_Tools.Text_H("     }");
                m_Tools.Text_H("     ENDCG");
                m_Tools.Text_H("}");



            });


        }


        private void DrawAudioSource()                           // AudioSource
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/class-AudioSource.html");
            m_Tools.TextText_BL("Audio Clip", "", -20);
            m_Tools.TextText_BL("Output", "", -20);
            m_Tools.TextText_BL("Mute", OpenSure + "", -20);
            m_Tools.TextText_BL("Bypass Effects", OpenSure + "", -20);
            m_Tools.TextText_BL("Bypass Listener Effects", OpenSure + "", -20);
            m_Tools.TextText_BL("Bypass Reverb Zones", OpenSure + "", -20);
            m_Tools.TextText_BL("Play On Awake", OpenSure + "", -20);
            m_Tools.TextText_BL("Loop", OpenSure + "", -20);
            m_Tools.TextText_BL("Priority", "", -20);
            m_Tools.TextText_BL("Volume", "", -20);
            m_Tools.TextText_BL("Pitch", "", -20);
            m_Tools.TextText_BL("Stereo Pan", "", -20);
            m_Tools.TextText_BL("Spatial Blend", "", -20);
            m_Tools.TextText_BL("Reverb Zone Mix", "", -20);
            m_Tools.TextText_BL("3D Sound Settings", "", -20);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_WL("Doppler Level", "", -20);
                m_Tools.TextText_WL("Spread", "", -20);
                m_Tools.TextText_WL("Volume Relloff", "", -20);
                m_Tools.TextText_WL("Min Distance", "", -20);
                m_Tools.TextText_WL("Max Distance", "", -20);
            });
        }

        #endregion


        #region 基类

        private void DrawObject()                                // Object
        {
            m_Tools.BiaoTi_O("Object " + "(Unity 所有引用对象的基类)".AddGreen());
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BY("hideFlags", "", "控制物体在hierarchy，Inspector中的显示", "HideFlags", ref ishideFlags, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Text("HideFlags 枚举说明：" + "(逐渐递增)".AddLightGreen());
                        m_Tools.TextText_LG("None", "默认情况，一切正常", -40);
                        m_Tools.TextText_LG("NotEditable", "不能被编辑", -40);
                        m_Tools.TextText_LG("HideInInspector", "Inspector 隐藏面板", -40);
                        m_Tools.TextText_LG("HideInHierarchy", "完全消失，只有Game里才看见", -40);
                        m_Tools.Text_G("// 其它设置都是坑");
                    });
                }, -100);
            });

            MyCreate.StaticMethodWindow(() =>
            {
                MyCreate.Text("创建");
                m_Tools.Method_BY("Instantiate", "Object", "", "Object");
                m_Tools.Method_BY(ZhongZai + "Instantiate", "Object，Transform 父位置", "", "Object");
                m_Tools.Method_BY(ZhongZai + "Instantiate", "Object，Transform，bool true:相对世界坐标旋转", "", "Object");
                m_Tools.Method_BY(ZhongZai + "Instantiate", "Object，Vector3 坐标，Quaternion 旋转值", "", "Object");
                m_Tools.Method_BY(ZhongZai + "Instantiate", "Object，Vector3，Quaternion，Transform 父位置", "", "Object");

                m_Tools.Method_BY("Instantiate", "T", "6 种重载方法与上面相同", "T", 10);

                MyCreate.Text("删除——游戏代码使用");
                m_Tools.Method_BY("Destroy", "Object，float 几秒后销毁", "GameObject 或 组件", "", 10);
                MyCreate.Text("删除——编辑器使用" + "（小心使用此功能，因为它可以永久销毁资产 Prefab ）".AddGreen());
                m_Tools.Method_BY("DestroyImmediate", "Object，bool 允许永久销毁资产 = false", "");
                MyCreate.Text("遍历整个场景的查找 " + "（注意：功能非常慢）".AddGreen());
                m_Tools.Method_BY("FindObjectOfType", "Type", "返回第一个对象", "Object", 10);
                m_Tools.Method_BY("FindObjectsOfType", "Type ", "不包含资产和不活动的对象", "Object[]", 10);
                MyCreate.Text("设置");
                m_Tools.Method_BY("DontDestroyOnLoad", "Object", "加载新场景不会自动销毁对象", "", 10);

            });
        }

        private void DrawComponent()                             // Component
        {
            m_Tools.BiaoTi_B("Component " + "(所有附加到 GameObject 的组件基类)".AddGreen());
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("tag", "", "标签可以用来识别游戏对象", "string", -20);
                m_Tools.Method_BL("gameObject", "只读", "该组件附加到的游戏对象", "GameObject", -20);
                m_Tools.Method_BL("transform", "只读", "", "Transform", -20);
            });
            MyCreate.MethodWindow(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("1.组件所有的方法都是根据 gameObject 来调用的");
                    m_Tools.Text_G("2.Component 所有方法与 GameObject 部分方法相同");
                });
                MyCreate.Text("与 " + "gameObject".AddGreen() + " 一样发送信息的方法");
                m_Tools.Text_L("BroadcastMessage", "、".AddHui(), "SendMessage", "、".AddHui(), "SendMessageUpwards");
                AddSpace();
                MyCreate.Text("与 " + "gameObject".AddGreen() + " 一样判断 tag 方法");
                m_Tools.Text_L("CompareTag");
                AddSpace();
                MyCreate.Text("获取身上的 一个 组件");
                m_Tools.Text_L("GetComponent、GetComponentInChildren、GetComponentInParent");
                MyCreate.Text("获取身上的组件 集合");
                m_Tools.Text_L("GetComponents、GetComponentInChildren、GetComponentInParent");
            });

        }

        private void DrawBehaviour()                             // Behavior
        {
            m_Tools.BiaoTi_B("Behaviour " + "(Behaviour 是可以启用或禁用的组件)".AddGreen());
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Text_H("就只有 2 个属性");
                m_Tools.Method_BY("enabled", "", "启用 Mono 对应函数否", "bool");
                m_Tools.Method_BY("isActiveAndEnabled", "", "是否 激活 以及 enabled", "bool");
            });
            AddSpace();
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Transform 是必须的，不需要启用与禁用，所以直接继承 Component");
                m_Tools.Text_H("Rigidbody、Collider、Renderer 自带有 enabled");
                m_Tools.Text_H("自己开关会影响碰撞和渲染问题，所以也是直接继承 Component");
            });

        }

        #endregion



        #region Transform/GameObject

        private void DrawTransform()                             // Transform
        {
            m_Tools.BiaoTi_B("Transform " + "(对象的位置，旋转和缩放组件)".AddGreen());
            m_Tools.Text_G("1.可以遍历循环", " foreach (Transform child in transform)".AddHui());
            m_Tools.Text_G("2.是组件 且不需要启用和禁用，所有继承 Component");
            MyCreate.PropertiesWindow(() =>
            {
                MyCreate.Text("获取信息 " + "（只读）".AddGreen());
                m_Tools.Method_BY("childCount", "", "子对象数量", "int", -40);
                m_Tools.Method_BY("hierarchyCount", "", "自己 + 子对象 + 父对象", "int", -40);
                m_Tools.Method_BY("root", "", "父 Transform", "Transform", -40);
                m_Tools.Method_BY("lossyScale", "", "物体相对于世界坐标的缩放值", "Vector3", -40);
                MyCreate.Text("Get、Set _相对世界空间/父 Transform");
                m_Tools.Method_BY("position / localPosition", "", "位置", "Vector3", 20);
                m_Tools.Method_BY("eulerAngles / localEulerAngles", "", "欧拉角度", "Vector3", 20);
                m_Tools.Method_BY("rotation / localRotation", "", "旋转值", "Quaternion", 20);
                MyCreate.Text("Get、Set");
                m_Tools.Method_BY("localScale", "", "相对父 Transform 缩放比例", "Vector3", -40);
                m_Tools.Method_BY("parent", "", "父 Transform", "Transform", -40);
                m_Tools.Method_BY("right、up、forward", "", "相对世界空间的 XYZ 轴", "Vector3", -40);
            });
            MyCreate.MethodWindow(() =>
            {
                MyCreate.Text("Transform 里面包含一个 " + "List<子Transform> ".AddGreen() + "的集合");
                m_Tools.Text_L("1. ", "foreach ".AddBlue(), "(Transform child in transform)");
                m_Tools.Text_L("2. ", "GetChild(int 索引)".AddBlue(), "   -> 子Transform", "  // 通过索引获得".AddGreen());
                m_Tools.Text_L("3. ", "Find(string 路径)".AddBlue(), "  -> 子Transform", " // 通过路径查找".AddGreen());
                m_Tools.Text_L("4. ", "IsChildOf(Transform 父)".AddBlue(), "  -> bool ", "   // 这个是否父转换的子对象".AddGreen());

                MyCreate.Text("操作");
                m_Tools.Method_BY("DetachChildren", "", "销毁层次结构的根目录", "", ref isDetachChildren, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_G("即这个的所有子游戏对象都没有了父Transform");
                        m_Tools.Text_G("销毁层次结构的根目录而不会破坏子对象");
                    });
                });
                m_Tools.Method_BY("LookAt", "Transform 指向的对象，Vector3=Vector3.up", "");
                m_Tools.Method_BY("SetParent", "Transform", "设置变换的父级");


                MyCreate.Text("平移、旋转");
                m_Tools.Method_BY("Rotate", "float x,float y,float z, Space = Space.Self", "   自身旋转", "", ref isRotate, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "Rotate", "Vector3 欧拉角，Space ", "");
                    m_Tools.Method_BY(ZhongZai + "Rotate", "Vector3 轴，float 角度，Space", "");
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_OY("Space.World", "应用相对于世界坐标系的变换");
                        m_Tools.TextText_OY("Space.Self", "相对于局部坐标系应用变换");
                    });

                });
                m_Tools.Method_BY("RotateAround", "Vector3 点，Vector3 轴，float 角度", "   绕一个点旋转");
                m_Tools.Method_BY("Translate", "Vector3", "默认 相对自身平移多少距离", "", ref isTranslate, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "Translate", "Vector3，Transform 相对点", "根据相对点平移距离");
                    m_Tools.Method_BY(ZhongZai + "Translate", "float x，float y，float z，Space  = Space.Self", "");
                });
            });
        }


        private void DrawGameObject()                            // GameObject
        {
            m_Tools.BiaoTi_B("GameObject " + "(Unity场景中所有实体的基类)".AddGreen());
            m_Tools.Text_G("构造： ", "new GameObject(“名称”,params Type[] 组件)".AddHui());
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BY("activeSelf", "只读", "这个GameObject的" + "本地活动".AddGreen() + "状态", "bool", -25);
                m_Tools.Method_BY("activeInHierarchy", "只读", "在场景是否状态" + "（包括其所有父对象）".AddGreen(), "bool", -25);
                m_Tools.Text_Y("tag".AddBlue(), "标签", "     layer".AddBlue(), "层", "     isStatic".AddBlue(), "是否设置了任何静态标志");
            });
            MyCreate.MethodWindow(() =>
            {
                MyCreate.Text("(常用)".AddLightGreen());
                m_Tools.Text_Y("SetActive、AddComponent<T>、GetComponents<T>");
                MyCreate.Text("获取单个");
                m_Tools.Method_BY("GetComponentInChildren<T>", "", "自己或活动的子Mono查找", "T", 10);
                m_Tools.Method_BY("GetComponentInParent<T>", "", "自己或活动的父Mono查找", "T", 10);
                MyCreate.Text("获取所有");
                m_Tools.Method_BY("GetComponentsInChildren<T>", "bool = false 不查找不活动的", "", "T[]");
                m_Tools.Method_BY("GetComponentsInParent<T>", "bool = false 不查找不活动的", "", "T[]");
                MyCreate.Text("比较");
                m_Tools.Method_BY("CompareTag", "string tag", "这个游戏对象是不是这个 tag", "bool", 10);
                MyCreate.Text("发送信息_向自己 " + "（SendMessageOptions 是否需要打印错误）".AddLightGreen());
                m_Tools.Method_BY("SendMessage", "string 方法名，object 参数，SendMessageOptions", "");
                MyCreate.Text("发送信息_向自己以及所有子 MonoBehaviour");
                m_Tools.Method_BY("BroadcastMessage", "string，object，SendMessageOptions", "");
                MyCreate.Text("发送信息_向自己以及所有父 MonoBehaviour");
                m_Tools.Method_BY("SendMessageUpwards", "string，object，SendMessageOptions", "");

            });

            MyCreate.StaticMethodWindow(() =>
            {
                MyCreate.Text("创建");
                m_Tools.Method_BY("CreatePrimitive", "PrimitiveType", "创建基本物体", "GameObject", ref isCreatePrimitive, () =>
                {
                    MyCreate.Text("PrimitiveType 枚举:".AddYellow());
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_OY("Sphere", "球体", -20);
                        m_Tools.TextText_OY("Capsule", "胶囊体", -20);
                        m_Tools.TextText_OY("Cylinder", "圆柱体", -20);
                        m_Tools.TextText_OY("Cube", "立方体", -20);
                        m_Tools.TextText_OY("Plane", "平面", -20);
                        m_Tools.TextText_OY("Quad", "前显后隐平面", -20);
                    });

                }, 10);
                MyCreate.Text("查找其他 GameObject");
                m_Tools.Method_BY("Find", "string", "支持“/”字符遍历层次结构", "GameObject", 10);
                m_Tools.Text_H("“如 Find（Monster/ Arm） 找到 Monster 下的 Arm”");
                MyCreate.Text("通过 标签 查找其他 GameObject");
                m_Tools.Method_BY("FindWithTag", "string", "", "GameObject", 10);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_L("  注意：旧方法 FindGameObjectWithTag ","(同效果、不报错)".AddGreen());
                });
                m_Tools.Method_BY("FindGameObjectsWithTag", "string", "", "GameObject[]", 10);

            });
        }


        private void DrawFind()                                  // 查找 Find
        {
            m_Tools.BiaoTi_O("Object  Static" + " 查找  ->  Object/T".AddLightBlue());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("Object.FindObjectOfType<T>".AddBlue(), " -> 返回T类型的第一个对象 -> Object/T");
                m_Tools.Text_H("Object.FindObjectsOfType<T>".AddBlue(), " -> 返回所有T类型的对象 -> Object[]/T[]");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_R("    遍历整个场景查找，功能非常慢");
                    m_Tools.Text_R("    不能查找隐藏物体");
                });
            });

            AddSpace();
            m_Tools.BiaoTi_O("GameObject  Static" + " 查找  ->  GameObject".AddLightBlue());
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("GameObject.Find(string 名称/路径)  ", "-> GameObject".AddHui());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("    string 名称/路径 :1.支持直接名称，2.支持”/“字符遍历层次结构的路径");
                    m_Tools.Text_R("    会逐个遍历所有物体,比较浪费性能");
                    m_Tools.Text_R("    不能查找隐藏物体");
                });
                AddSpace_3();
                m_Tools.Text_B("GameObject.FindWithTag(string tag) ", " -> GameObject".AddHui());
                m_Tools.Text_B("GameObject.FindGameObjectsWithTag(string tag)  ", "-> GameObject[]".AddHui());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("    根据 tag 来查找，性能优");
                    m_Tools.Text_R("    tag 标签没有定义会报错");
                    m_Tools.Text_R("    不能查找隐藏物体");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("Transform" + "  对象内部查找  ->  Transform".AddLightBlue());
            MyCreate.Box(() =>
            {
                MyCreate.Text("transform 对象里面包含一个 " + "List<子Transform> ".AddGreen() + "的集合");
                m_Tools.Text_L("1. ", "foreach ".AddBlue(), "(Transform child in transform)", "  // 遍历所有子Transform".AddGreen());
                m_Tools.Text_L("2. ", "GetChild(int 索引)".AddBlue(), "   -> 子Transform", "      // 通过索引获得".AddGreen());
                m_Tools.Text_L("3. ", "Find(string 路径)".AddBlue(), "  -> 子Transform", "        // 通过路径查找".AddGreen());

                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("    可以查找隐藏物体，可以用索引，可以用 foreach 查找全部");
                    m_Tools.Text_R("    Find 一定要填写”/“字符层次结构的路径");
                });
            });


        }



        #endregion



        private void DrawTimeScale()
        {
            m_Tools.Text_O("当  Time.timeScale = 0 时：");
            m_Tools.BiaoTi_B("一次性的函数"+"(都会执行)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("Awake、Start、OnEnable、OnDestroy 等都会执行");
            });
            AddSpace();
            m_Tools.BiaoTi_B("每帧函数" + "(只有 Update 会执行)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_Y("Update" + "(执行)".AddGreen()+ "           FixedUpdate"+ "(不执行)".AddGreen());
                m_Tools.Text_Y("Time.deltaTime" + "( 0 )".AddGreen()+ "     Time.fixedTime" + "( 0 )".AddGreen());
                m_Tools.Text_G("只有 Time.fixedDeltaTime  ->  0.02  !");
            });
            AddSpace();
            m_Tools.BiaoTi_B("协程" + "(只有 yield return 前部分会执行)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("yield return 前部分的语句会执行");
                m_Tools.Text_B("而 yield return 后面的语句就不会执行");
            });


            AddSpace();

            m_Tools.BiaoTi_B("Invoke" + "( 延时函数不会执行 )".AddGreen());

        }



    }
}


