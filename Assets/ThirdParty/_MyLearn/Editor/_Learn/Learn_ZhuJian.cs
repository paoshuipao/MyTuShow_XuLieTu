using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;

namespace UnityEditor
{
    public class Learn_ZhuJian : AbstactNewKuang
    {
        [MenuItem(LearnMenu.UnityZhongJie,false,LearnMenu.UnityZu_INDEX)]
        static void Init()
        {
            Learn_ZhuJian instance = GetWindow<Learn_ZhuJian>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "CharacterController".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.CharacterController ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.CharacterController);
            }
            AddSpace_3();


            bool isUntiy = (type == EType.Rigidbody || type == EType.Rigidbody2D || type == EType.Rigidbody2D2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "刚体".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isUntiy ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Rigidbody);
            }


            if (isUntiy)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Rigidbody ? "  Rigidbody".AddBlue() : "  Rigidbody");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Rigidbody);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Rigidbody2D ? "  Rigidbody2D".AddBlue() : "  Rigidbody2D");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Rigidbody2D);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Rigidbody2D2 ? "  Rigidbody2D面板".AddBlue() : "  Rigidbody2D面板");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Rigidbody2D2);
                }
            }




            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "WindZone".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.WindZone ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.WindZone);
            }
            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "NavMeshAgent".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Nav ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Nav);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "PhysicMaterial".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.PhyMaterial ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.PhyMaterial);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Camera";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Camera ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Camera);
            }
            AddSpace_3();

            bool isTmp1 = (type == EType.Light || type == EType.Light1 || type == EType.Light2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Light";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Light ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Light);
            }
            if (isTmp1)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Light1 ? "  阴影 shadow".AddRed() : "  阴影 shadow");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Light1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Light2 ? " 全局光照和烘焙".AddRed() : "  全局光照和烘焙");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Light2);
                }
            }
            AddSpace_3();
        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.CharacterController:
                    DrawRightPage1(DrawCharacterController);
                    break;
                case EType.Light:
                    DrawRightPage3(DrawLights);
                    break;
                case EType.Rigidbody:
                    DrawRightPage4(DrawRigidbody);
                    break;
                case EType.Rigidbody2D:
                    DrawRightPage7(DrawRigidbody2);
                    break;
                case EType.Rigidbody2D2:
                    DrawRightPage8(DrawRigidbody2DMain);
                    break;
                case EType.WindZone:
                    DrawRightPage5(DrawWindZone);
                    break;
                case EType.Camera:
                    DrawRightPage6(DrawCamera);
                    break;
                case EType.PhyMaterial:
                    DrawRightPage7(DrawPhysicMaterial);
                    break;
                case EType.Nav:
                    DrawRightPage8(DrawNavMeshAgent);
                    break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.CharacterController:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                case EType.Camera:
                    mWindowSettings.pageWidthExtraSpace.target = -10;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
            }
        }


        #region 私有

        private bool mIsCC = true,isLight = true,ismRigidbody = true, ismRigidbody2D = true, isWindZone = true,isNavMeshAgent = true, isPhysicMaterial =true;

        private CharacterController mCC;
        private Light mLight;
        private Rigidbody mRigidbody;
        private Rigidbody2D mRigidbody2D;
        private WindZone mWindZone;
        private NavMeshAgent mNavMeshAgent;
        private PhysicMaterial mPhysicMaterial;

        private const int AddJianGe = 10;

        private enum EType
        {
            CharacterController,
            Light,Light1,Light2,
            Rigidbody, Rigidbody2D, Rigidbody2D2,
            WindZone,
            Camera,
            Nav,
            PhyMaterial,

        }

        private EType type = EType.CharacterController;

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
            return "组件";
        }


        private string GetArrayStr(string[] arr, int index)
        {
            if (arr.Length == 0)
            {
                return "没数据";
            }
            if (index < 0 || index >= arr.Length)
            {
                return index + ",数组：" + arr.Length;
            }
            else
            {
                return arr[index];
            }
        }

        protected Enum TextEnum(string str1, string str2, Enum value, int changeJianGe = AddJianGe)
        {
            Enum tmp = m_Tools.TextEnum_Y(str1 + (" (" + str2 + ")").AddWhite(), value, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected int TextEnum(string str2, int value, string[] ops, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            int tmp = m_Tools.TextEnum_Y(GetArrayStr(ops, value) + (" (" + str2 + ")").AddWhite(), value, ops, ref isShow, () =>
            {
                if (null != ShowAction)
                {
                    MyCreate.Box(ShowAction);
                }
            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected int TextEnum(string str2, int value, string[] ops, int changeJianGe = AddJianGe)
        {
            int tmp = m_Tools.TextEnum_Y(GetArrayStr(ops, value) + (" (" + str2 + ")").AddWhite(), value, ops, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected Enum TextEnum(string str1, string str2, Enum value, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            Enum tmp = m_Tools.TextEnum_Y(str1 + (" (" + str2 + ")").AddWhite(), value, ref isShow, () =>
            {
                MyCreate.Box(ShowAction);
            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected int TextEnum2(string str2, int value, string[] ops, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            int tmp = m_Tools.TextEnum2_Y(GetArrayStr(ops, value) + (" (" + str2 + ")").AddWhite(), value, ops, ref isShow, () =>
            {
                if (null != ShowAction)
                {
                    MyCreate.Box(ShowAction);
                }
            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected float TextFloat(string str1, string str2, float value, int max, int changeJianGe = AddJianGe, int minValue = 0)
        {
            float tmp = m_Tools.TextFloat_Y(str1 + (" (" + str2 + ")").AddWhite(), value, minValue, max, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }
        protected float TextFloat(string str1, string str2, float value, float max, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe, int minValue = 0)
        {
            float tmp = m_Tools.TextFloat_Y(str1 + (" (" + str2 + ")").AddWhite(), value, minValue, max, ref isShow, () =>
            {
                if (null != ShowAction)
                {
                    MyCreate.Box(ShowAction);
                }

            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }
        protected float TextFloat(string str1, string str2, float value, float max, int changeJianGe = AddJianGe, float minValue = 0)
        {
            float tmp = m_Tools.TextFloat_Y(str1 + (" (" + str2 + ")").AddWhite(), value, minValue, max, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }
        protected int TextInt(string str1, string str2, int value, int max, int changeJianGe = AddJianGe, int minValue = 0)
        {
            int tmp = m_Tools.TextInt_Y(str1 + (" (" + str2 + ")").AddWhite(), value, minValue, max, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }
        protected void TextText1(string str1, string str2, string str3, int changeJianGe = AddJianGe)
        {
            m_Tools.TextText_BL(str1 + (" (" + str2 + ")").AddWhite(), str3, changeJianGe);
            MyCreate.AddSpace(4);
        }
        protected void TextText1(string str1, string str2, string str3, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            m_Tools.TextText_BW(str1 + (" (" + str2 + ")").AddWhite(), str3, ref isShow, () =>
            {
                MyCreate.Box(ShowAction);
            }, changeJianGe);
            MyCreate.AddSpace(4);
        }

        protected Vector3 TextVector3(string str1, string str2, Vector3 value, int changeJianGe = AddJianGe)
        {
            Vector3 tmp = m_Tools.TextVector3_Y(str1 + (" (" + str2 + ")").AddWhite(), value, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected bool TextBool(string str1, string str2, bool value, int changeJianGe = AddJianGe)
        {
            bool tmp = m_Tools.TextBool_Y(str1 + (" (" + str2 + ")").AddWhite(), value, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected bool TextBool(string str1, string str2, bool value, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            bool tmp = m_Tools.TextBool_Y(str1 + (" (" + str2 + ")").AddWhite(), value, ref isShow, () =>
            {
                MyCreate.Box(ShowAction);
            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected bool TextBool(string trueStr1, string falseStr1, string str2, bool value, int changeJianGe = AddJianGe)
        {
            bool tmp = m_Tools.TextBool_Y((value ? trueStr1 : falseStr1) + (" (" + str2 + ")").AddWhite(), value, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        protected bool TextBool(string trueStr1, string falseStr1, string str2, bool value, ref bool isShow, Action ShowAction, int changeJianGe = AddJianGe)
        {
            bool tmp = m_Tools.TextBool_Y(trueStr1 + (" (" + str2 + ")").AddWhite(), falseStr1 + (" (" + str2 + ")").AddWhite(), value, ref isShow, () =>
            {
                MyCreate.Box(ShowAction);
            }, changeJianGe);
            MyCreate.AddSpace(4);
            return tmp;
        }

        private void Text6(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            MyCreate.Heng(() =>
            {
                m_Tools.Text4_BW(str1, str2, str3, str4, -45);
                if (!string.IsNullOrEmpty(str5))
                {
                    MyCreate.AddSpace();
                    MyCreate.Text(str5.AddBlue() + str6.AddWhite());
                }
            });
        }


        private void ZhuJian<T>(ref T t, ref bool isShow, Action OnDrawScriptGUI, Action OnNoScriptGUI=null)
            where T : Object
        {
            m_Tools.TextUnityObject<T>(t == null ? typeof(T).Name.AddRed() : typeof(T).Name.AddGreen(), ref t, ref isShow, () =>
            {
                MyCreate.AddSpace(6);
                if (null != OnDrawScriptGUI)
                {
                    OnDrawScriptGUI();
                }
            }, () =>
            {
                if (null != OnNoScriptGUI)
                {
                    OnNoScriptGUI();
                }
            });
        }

        #endregion


        #region CharacterController

        private void DrawCharacterController()                   // CharacterController
        {
            ZhuJian(ref mCC, ref mIsCC, () =>
            {
                m_Tools.BiaoTi_O("首先需要设置 包含物体");
                MyCreate.Box(() =>
                {
                    mCC.radius = TextFloat("半径 ", "Radius", mCC.radius, 10);
                    mCC.height = TextFloat("高度", "Height", mCC.height, 10);
                    mCC.center = TextVector3("中心点", "Center", mCC.center);
                });

                m_Tools.BiaoTi_O("基本设置");
                MyCreate.Box(() =>
                {
                    mCC.slopeLimit = TextFloat("坡度极限", "Slope Limit", mCC.slopeLimit, 89);
                    m_Tools.Text_L("    就是允许能够走上去的最大坡度，以度数为单位");
                });

                float StepOffsetMaxValue = mCC.radius * 2 + mCC.height / 2;
                if (StepOffsetMaxValue > mCC.height)
                {
                    StepOffsetMaxValue = mCC.height - 0.1f;
                }
                MyCreate.Box(() =>
                {
                    mCC.stepOffset = TextFloat("每一步的距离", "Step Offest", mCC.stepOffset, StepOffsetMaxValue);
                    m_Tools.Text_L("    Step Offest 最大值取决于半径与高度");
                });
                MyCreate.Box((() =>
                {
                    mCC.skinWidth = TextFloat("皮肤厚度", "Skin Width", mCC.skinWidth, 5);
                    m_Tools.Text_L("    1. 如果角色卡住了,很可能是因为 Skin Width 太小了");
                    m_Tools.Text_L("    2. 防止进入另一物体的里面的情况发生");
                    m_Tools.Text_L("    3. 建议 至少", "大于 0.01 和半径的 10％".AddGreen());
                }));
                MyCreate.Box(() =>
                {
                    mCC.minMoveDistance = TextFloat("最小距离", "Min Move Distance", mCC.minMoveDistance, 5);
                    m_Tools.Text_L("    如果角色试图移动到指定的值以下，它将不会移动");
                    m_Tools.Text_L("    这可以用来减少抖动。在大多数情况下，这个值应该保持为0");
                });
            });

            AddSpace_15();
            CharacterControllerAPI();
        }

        private void CharacterControllerAPI()
        {
            if (!mIsCC || null == mCC)
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Object -> Component ->", " Collider".AddGreen(), " -> CharacterController");
                    m_Tools.Text_L("   不需要使用刚体，使用 CharacterController ", "也能进行碰撞限制运动".AddGreen());
                    m_Tools.Text_L("   不受力的影响，调用 Move 才会移动，且一些属性和回调函数只受移动影响");
                });
            }

            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                Text6("radius", "半径", "height", "高度", "center", "(中心点)");
                Text6("slopeLimit", "坡度极限", "skinWidth", "皮肤厚度", "minMoveDistance", "(最小距离)");
                Text6("isGrounded", "是否踩在地面上移动".AddGreen(), "stepOffset", "每一步的距离", "velocity", "(速度)");
            });
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("SimpleMove", "Vector3 速度", "移动，接地返回 true", "bool", 20);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1. 调用该方法会", "自动施加重力".AddGreen(), "，所以", "会忽略沿着 Y 轴的速度".AddGreen());
                    m_Tools.Text_H("2. Vector3 速度  -> ( 米 / 秒 )");
                    m_Tools.Text_H("3. 放在 Update 运行： controller.SimpleMove(forward * speed)");
                });
            });
            m_Tools.BiaoTi_B("回调函数 Messages");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("void ", "OnControllerColliderHit".AddBlue(), "(ControllerColliderHit 碰撞体信息)");
                m_Tools.Text_H("{");
                m_Tools.Text_G("    // 在 移动时 碰撞到其他碰撞体调用");
                m_Tools.Text_H("}");
            });

            m_Tools.BiaoTi_B("继承Collider 的回调函数 Inherited Messages");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("void", " OnCollisionEnter".AddBlue(), "(Collision)｛ ", "//进入碰撞器调用一次".AddGreen(), " ｝");
                m_Tools.Text_H("void ", "OnCollisionExit".AddBlue(), "(Collision)｛ ", "  //离开碰撞器调用一次".AddGreen(), " ｝");
                m_Tools.Text_H("void", " OnCollisionStay".AddBlue(), "(Collision)｛ ", " //进入碰撞器每帧调用".AddGreen(), " ｝");
                m_Tools.Text_H("void", " OnTriggerEnter".AddBlue(), "(Collider)｛ ", "  //进入 Trigger 调用一次".AddGreen(), " ｝");
                m_Tools.Text_H("void", " OnTriggerExit".AddBlue(), "(Collider)｛ ", "    //离开 Trigger 调用一次".AddGreen(), " ｝");
                m_Tools.Text_H("void", " OnTriggerStay".AddBlue(), "(Collider)｛ ", "  //进入 Trigger 每帧调用".AddGreen(), " ｝");

            });

        }


        #endregion

        #region Light

        private void DrawLights()
        {
            ZhuJian(ref mLight,ref isLight, () =>
            {
                mLight.type = (LightType)m_Tools.BiaoTi2_O("类型 (Type)", (int)mLight.type, TypeStrs, ref isType, () =>
                {
                    switch (mLight.type)
                    {
                        case LightType.Spot:
                            m_Tools.Text("[ 点光 ]".AddOrange());
                            SpotLightDes();
                            break;
                        case LightType.Directional:
                            m_Tools.Text("[ 方向光 ]".AddOrange());
                            DirectionalLightDes();
                            break;
                        case LightType.Point:
                            m_Tools.Text("[ 聚光灯 ]".AddOrange());
                            PointLightDes();
                            break;
                        case LightType.Area:
                            m_Tools.Text("[ 区域灯 ]".AddOrange());
                            AreaLightDes();
                            break;
                    }
                });
                AddSpace();
                switch (mLight.type)
                {
                    case LightType.Spot:
                        mLight.range = TextFloat("范围", "Range", mLight.range, 50);
                        mLight.spotAngle = TextInt("角度", "Spot Angle", (int)mLight.spotAngle, 179);
                        break;
                    case LightType.Point:
                        mLight.range = TextFloat("范围", "Range", mLight.range, 50);
                        break;
                    case LightType.Area:
                        MyCreate.TextCenter("这个消耗巨大,能不用就不用");
                        break;
                }
                mLight.lightmapBakeType = (LightmapBakeType)TextEnum("Mode", (int)mLight.lightmapBakeType, LightModeStrs);

                mLight.intensity = TextFloat("明亮程度", "Intensity", mLight.intensity, 10);
                mLight.bounceIntensity = TextFloat("间接光倍数", "Indirect Multiplier", mLight.bounceIntensity, 10, ref isIndirect, () =>
                {
                    MyCreate.TextCenter("用代码修改的属性是 bounceIntensity");
                    m_Tools.Text_Y("间接光线".AddWhite() + " 是从一个物体反射到另一个物体的光线");
                    m_Tools.Text_G("           （可以理解为一个物体的环境光要乘以的倍数）");

                    m_Tools.Text_Y("    > 1".AddWhite() + " :使得每次反弹时光线更亮");
                    m_Tools.Text_Y("    < 1".AddWhite() + " :每次反弹都会使反弹的灯变暗");
                });
                mLight.shadows = (LightShadows)TextEnum("Shadow Type", (int)mLight.shadows, ShadowsTypeStrs, ref isShadowType, ShadowTypeDes);
                if (mLight.shadows == LightShadows.Soft && mLight.lightmapBakeType == LightmapBakeType.Baked)
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BW("Baked Shadow Angle", " 烘焙阴影的角度");

                    });
                }
                if (mLight.lightmapBakeType == LightmapBakeType.Realtime && mLight.shadows != LightShadows.None)
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_Y("Realtime Shadows 实时阴影");
                        mLight.shadowStrength = TextFloat("阴影有多暗", "Strength", mLight.shadowStrength, 1);
                        mLight.shadowResolution = (LightShadowResolution)TextEnum("越高越真越高消耗", "Resolution", mLight.shadowResolution);
                        mLight.shadowBias = TextFloat("阴影距光线的距离", "Bias", mLight.shadowBias, 2);
                        mLight.shadowNormalBias = TextFloat("距法线的距离", "Normal Bias", mLight.shadowNormalBias, 2);
                        mLight.shadowNearPlane = TextFloat("近剪辑平面的值", "Near Plane", mLight.shadowNearPlane, 10);
                    });
                }


                if (mLight.lightmapBakeType == LightmapBakeType.Realtime)
                {
                    TextText1("阴影的纹理遮罩", "Cookie", "例如 Light创建轮廓或图案照明");
                }
                TextText1("是否绘制光晕", "Draw Halo", "光线会绘制一定半径范围的球形光晕");
                TextText1("闪光", "Flare", "设置一个Flare来渲染Light的位置");

                mLight.renderMode = (LightRenderMode)TextEnum("Render Mode", (int)mLight.renderMode, RenderModeStrs, ref isRenderMode, () =>
                {
                    m_Tools.TextText_OY("Auto", "具体取决于附近灯光的亮度和当前设置");
                    m_Tools.TextText_OY("Important", "重要模式，更好的视觉效果");
                    m_Tools.TextText_OY("Not Important", "光线始终以更快的顶点光照模式呈现");
                });
                TextText1("剔除层", "Culling Mask", "剔除不受灯光影响的层");
            });

            LightBottom();
        }



        private void LightBottom()
        {
            if (!isLight || null == mLight)
            {
                m_Tools.BiaoTi_B("Light 的几种类型");
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("Directional Light", "方向光" + "（太阳）".AddLightGreen());
                    m_Tools.TextText_BL("Point Light", "点光" + "（灯泡）".AddLightGreen());
                    m_Tools.TextText_BL("Spot Light", "聚光灯" + "（舞台上的聚光灯）".AddLightGreen());
                    m_Tools.TextText_BL("Area Light", "区域灯" + "（街灯、体育场的灯）".AddLightGreen());
                });
            }
            AddSpace_3();
            m_Tools.BiaoTi_B("性能问题");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. 实时光源越少越好，最多一个实时平行光");
                m_Tools.Text_H("2. 利用好离线烘焙");
                m_Tools.Text_H("3. SpotLight开销较大，AreaLight更大");
                m_Tools.Text_H("4. 实时光源只使用定点光Spot，或限制像素光的数量");
                m_Tools.Text_H("5. 谨慎使用实时的阴影");
                m_Tools.Text_H("6. 用软影");
                m_Tools.Text_H("7. 减少影子距离");
                m_Tools.Text_H("8. 高低Shadow Castcade");
            });
        }



        private bool isType, isIndirect, isRenderMode;
        private bool isNeng, isSetting, isShadowType, isCastShadows;
        private bool isLightmap;
        private bool isQuanJu = true;

        private readonly string[] RenderModeStrs =
        {
            "Auto取决附近光","Important片断","Not Important顶点"
        };

        private readonly string[] TypeStrs =
        {
            "Spot_射灯",
            "Directional_方向光",
            "Point_点光",
            "Area_区域光"
        };


        private readonly string[] ShadowsTypeStrs =
        {
            "不产生阴影",
            "生硬阴影",
            "柔和阴影",
        };


        private readonly string[] LightModeStrs =
        {
            "",
            "实时和烘焙混合",
            "烘焙",
            "",
            "实时",
        };



        private void QuanJuLight()                               //全局光照
        {
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("局部光照", "只考虑光源到模型表面的照射效果" + "(默认)".AddLightGreen(), -55);
                m_Tools.TextText_BL("全局光照", "考虑到环境中所有表面和光源相互作用的照射效果", -55);
                MyCreate.AddSpace(3);
                m_Tools.Text_G("Unity5 中全局光照构成：" + "(Lightmap + light probe + reflection probe)".AddBlue(), ref isQuanJu, () =>
                {
                    m_Tools.Text_LG("就是现在有两个物体靠得很近，应该两个物体都有对方的反射过来的颜色");
                    m_Tools.TextText_BL("1.Lightmap", "离线存储了颜色贴图，然后贴上去", ref isLightmap, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("对" + "静态".AddGreen() + "物体和光" + "预先计算存储".AddGreen() + "，不必实时计算，整个过程叫做烘焙");
                            m_Tools.Text_Y("烘焙的结果就是一张light mapping 贴图");
                        }, 25);

                    }, -20);
                    m_Tools.TextText_BL("2.light probe", "光照探头", -20);
                    m_Tools.TextText_BL("3.reflection probe", "反射探头", -20);
                    m_Tools.TextText_BL("4.可作为光源的自发光体", "Standard Shader 中的 Emission", -20);

                });
                MyCreate.AddSpace(3);
                m_Tools.Text_G("实时更新");

            });

        }


        private void ShadowTypeDes()                             //阴影的说明
        {
            m_Tools.TextText_OY("No Shadows", "没有阴影");
            m_Tools.TextText_OY("Hard Shadows", "生硬的阴影，有锯齿");
            m_Tools.TextText_OY("Soft Shadows", "正常的阴影，光滑、更真实");
        }

        private void DirectionalLightDes()                       //方向光的说明
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("1.方向是主体,忽略位置属性");
                m_Tools.Text_O("2.灯光放在无穷远处。它影响着在场景里所有物体");
                m_Tools.Text_Y("3.模拟 太阳");
            });

        }

        private void PointLightDes()                             //点灯的说明
        {
            m_Tools.Text_O("1.从灯光位置向各方向发光线，影响[ 范围内 ]的对象");
            m_Tools.Text_O("2.灯光亮度会从中心向四周衰减");
            m_Tools.Text_Y("3.模拟 灯泡");
        }

        private void SpotLightDes()                              //Spot光的说明
        {
            m_Tools.Text_O("1.光线在按照聚光灯的角度和范围所定义的一个圆锥区域");
            m_Tools.Text_O("2.灯光亮度从顶点向下衰减");
            m_Tools.Text_Y("3.模拟 舞台上的聚光灯");
        }

        private void AreaLightDes()                              //AreaLight的说明
        {
            m_Tools.Text_O("1.一个面发射一区域的灯");
            m_Tools.Text_O("2.性能吃的大，不要实时，烘焙好");
            m_Tools.Text_Y("3.模拟 街灯、体育场的灯");

        }


        #endregion

        #region Rigidbody

        private void DrawRigidbody()                     // Rigidbody
        {
            ZhuJian(ref mRigidbody,ref ismRigidbody, () =>
            {
                m_Tools.BiaoTi_O("基本设置");
                MyCreate.Box(() =>
                {
                    mRigidbody.mass = TextFloat("质量", "Mass", mRigidbody.mass, 200,25);
                    m_Tools.Text_L("    两个刚体的相对质量【单位为Kg】决定了它们在","相互碰撞时的反应".AddGreen());
   
                });
                MyCreate.Box(() =>
                {
                    mRigidbody.drag = TextFloat("[移动]受到空气阻力", "Drag", mRigidbody.drag, 50,25);
                    m_Tools.Text_L("    下降速度".AddGreen(),"不应该是使用 Mass 来决定，应该是","由 Drag 决定".AddGreen());
                    m_Tools.Text_L("    Drag 越低越重，如 0.001（金属块）和 10（羽毛）");
                });
                mRigidbody.angularDrag = TextFloat("[旋转]受到空气阻力", "Angular Drag", mRigidbody.angularDrag, 50, 28);
                mRigidbody.useGravity = TextBool("受重力影响", "Use Gravity", mRigidbody.useGravity, 58);
                MyCreate.Box(() =>
                {
                    mRigidbody.isKinematic = TextBool("此时不受物理引擎驱动", "此时受物理引擎驱动", "Is Kinematic", mRigidbody.isKinematic, 53);

                    m_Tools.Text_L("开启此项：");
                    m_Tools.Text_L("    1. 对象将不受物理引擎的影响,只能通过其 Transform 来操作");
                    m_Tools.Text_L("    2. 可用于 HingeJoint 关节操作");
                });
                AddSpace();
                m_Tools.BiaoTi_O("特殊情况改下以下的选项");
                MyCreate.Box(() =>
                {
                    mRigidbody.interpolation = (RigidbodyInterpolation)TextEnum("插值" + "(抖动)".AddGreen(), "Interpolate", mRigidbody.interpolation, 53);
                    m_Tools.Text_G("    如果刚体运动时有抖动，可以通过修改这个参数来修改");
                    m_Tools.TextText_BL("    None:", "没有插值");
                    m_Tools.TextText_BL("    Interpolate:", "根据上一桢的位置做平滑插值");
                    m_Tools.TextText_BL("    Extrapolate:", "根据下一桢的位置做平滑插值");
                });
                MyCreate.Box(() =>
                {
                    mRigidbody.collisionDetectionMode = (CollisionDetectionMode)TextEnum("碰撞模式" + "(高速)".AddGreen(), "Collision Detection", mRigidbody.collisionDetectionMode, 53);
                    m_Tools.Text_G("    用于防止刚体因快速移动而穿过其他对象");
                    m_Tools.TextText_BL("    Discrete:", "不连续 正常情况下都使用这个");
                    m_Tools.TextText_BL("    Continuous:", "连续 高速物体的碰撞检测");
                    m_Tools.TextText_BL("    Con Dynamic:", "动态连续 更高速，更耗性能");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("约束", "(Constraints)".AddWhite());
                    TextText1("     ", "Freeze Position", "有选择地停止在世界X，Y和Z轴上的移动",-3);
                    TextText1("     ", "Freeze Rotation", "有选择地停止本地X，Y和Z轴旋转", -3);
                });

            });
            AddSpace();
            RigidbodyBottom();
        }


        private void RigidbodyBottom()
        {

            if (!ismRigidbody || null == mRigidbody)
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Rigidbody.html");
                RigidbodyDes();
            }
            else
            {
                MyCreate.FenGeXian();
            }
            AddSpace_3();
            m_Tools.BiaoTi_B("属性 " + "(忽略面板的属性)".AddLightGreen());
            MyCreate.Box(() =>
            {
                Text6("position", "位置", "rotation", "旋转", "velocity", "(速度)");
            });
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("AddForce", "Vector3 向量，ForceMode 枚举", "给它一个 作用力", "", 80);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL(" ForceMode.Force", "使用质量，添加一个连续的力", 20);
                    m_Tools.TextText_HL(" ForceMode.Impulse", "使用质量，添加一个瞬间的力", 20);
                    m_Tools.TextText_HL(" ForceMode.Acceleration", "忽略其质量，添加一个连续的加速度", 20);
                    m_Tools.TextText_HL(" ForceMode.VelocityChange", "忽略其质量，添加一个瞬间的力", 20);
                });
                m_Tools.Method_BY("AddTorque", "Vector3 向量，ForceMode 枚举", "给它一个 扭矩", "", 80);
            });

            if (ismRigidbody || null != mRigidbody)
            {
                AddSpace_3();
                RigidbodyDes();
            }
        }

        private void RigidbodyDes()
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Object  -> Component  ->  Rigidbody");
                m_Tools.Text_L("  1. 加了刚体，能进行", "物理操作".AddGreen(), "（接收力的操作 + 扭矩操作）");
                m_Tools.Text("        扭矩：使物体发生转动的力");
                m_Tools.Text("        扭矩对于车而言，扭矩越大，加速性越好，爬坡度越大,发动机越好");
                m_Tools.Text_L("  2. 可通过物理加速图像引擎与其他对象进行交互", "(如 Joint 关节)".AddGreen());
                m_Tools.Text_L("  3. 除非开启 IsKinematic，都" + "不要使用 Transform 组件移动".AddRed());
                m_Tools.Text_L("  4. 只需将其角度拖动设置为无穷大，就无法使对象停止旋转");
            });
        }






        private void DrawRigidbody2()                        // Rigidbody2D
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/class-Rigidbody2D.html", "Manual");
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Rigidbody2D.html", "Script");

            m_Tools.Text_B("说明");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("▪ Rigidbody2D、Rigidbody  都是继承 Component");
                m_Tools.Text_L("▪ 对象只能在XY平面中移动，并且只能在垂直于该平面的轴上旋转");
                
            });
        }


//        private string[] R2DType = { "动态", "运动学", "静态" };
        private void DrawRigidbody2DMain()                   // Rigidbody2D 面板
        {
            ZhuJian(ref mRigidbody2D, ref ismRigidbody2D, () =>
            {

                mRigidbody2D.bodyType = (RigidbodyType2D)TextEnum("主体类型 ", "Body Type", mRigidbody2D.bodyType);
                MyCreate.Box_Hei(() =>
                {
                     m_Tools.TextText_BL("Dynamic  动态", "阻力、重力、移动、旋转、碰撞、最高消耗真实模拟",-40);
                     m_Tools.TextText_BL("Kinematic  运动学", "有碰撞、速度不受阻力，无重力，移动模拟", -40);
                     m_Tools.TextText_BL("Static  静态", "不动的", -40);

                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("物理材质" + "<没特殊可不加>".AddLightGreen(), "(Material)".AddWhite());
                    mRigidbody2D.simulated = TextBool("模拟" + "<true即可>".AddLightGreen(), "Simulated", mRigidbody2D.simulated, 40);
                    if (mRigidbody2D.bodyType == RigidbodyType2D.Kinematic)
                    {
                        mRigidbody2D.useFullKinematicContacts = TextBool("使用全部运动触点" + "<默认false>".AddLightGreen(), "Use Full Kinematic Contacts", mRigidbody2D.useFullKinematicContacts, 40);
                    }
                    if (mRigidbody2D.bodyType == RigidbodyType2D.Dynamic)
                    {
                        mRigidbody2D.mass = TextFloat("质量", "Mass", mRigidbody2D.mass, 200, 40);
                        mRigidbody2D.drag = TextFloat("[移动]受到空气阻力", "Angular Drag", mRigidbody2D.drag, 50, 40);
                        mRigidbody2D.angularDrag = TextFloat("[旋转]受到空气阻力", "Angular Drag", mRigidbody2D.angularDrag, 50, 40);
                        mRigidbody2D.gravityScale = TextFloat("重力大小", "Gravity Scale", mRigidbody2D.gravityScale, 50, 40);
                    }
                });
      

                if (mRigidbody2D.bodyType != RigidbodyType2D.Static)
                {

                    MyCreate.Box(() =>
                    {
                        mRigidbody2D.collisionDetectionMode = (CollisionDetectionMode2D)TextEnum("碰撞模式" + "(高速)".AddGreen(), "Collision Detection", mRigidbody2D.collisionDetectionMode, 53);
                        m_Tools.Text_G("    用于防止刚体因快速移动而穿过其他对象");
                        m_Tools.TextText_BL("    Discrete:", "不连续 正常情况下都使用这个");
                        m_Tools.TextText_BL("    Continuous:", "连续 高速物体的碰撞检测，耗性能");
                    });
                    MyCreate.Box(() =>
                    {
                        mRigidbody2D.sleepMode = (RigidbodySleepMode2D)TextEnum("睡眠模式" + "(什么时候有刚体)".AddGreen(), "Sleeping Mode", mRigidbody2D.sleepMode, 53);
                        m_Tools.TextText_BL("    NeverSleep:", "一直运行<耗性能>"+ "(如:Active = false 也运行)".AddGreen(),-30);
                        m_Tools.TextText_BL("    StartAwake:", "Awake调用"+"(如:物体激活就会受重力掉下去)".AddGreen(), -30);
                        m_Tools.TextText_BL("    StartAsleep:", "碰撞唤醒"+"(如:另一物体撞它才会受重力掉下去)".AddGreen(), -30);
                    });

                    MyCreate.Box(() =>
                    {
                        mRigidbody2D.interpolation = (RigidbodyInterpolation2D)TextEnum("插值" + "(抖动)".AddGreen(), "Interpolation", mRigidbody2D.interpolation, 53);
                        m_Tools.Text_G("    如果刚体运动时有抖动，可以通过修改这个参数来修改");
                        m_Tools.TextText_BL("    None:", "没有插值");
                        m_Tools.TextText_BL("    Interpolate:", "根据上一桢的位置做平滑插值");
                        m_Tools.TextText_BL("    Extrapolate:", "根据下一桢的位置做平滑插值");
                    });


                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_Y("约束", "(Constraints)".AddWhite());
                        TextText1("     ", "Freeze Position", "有选择地停止在世界 X 和 Y 轴上的移动", -3);
                        TextText1("     ", "Freeze Rotation", "true：Z 轴不能旋转（即禁止旋转）", -3);
                    });

                }



            });
        }







        #endregion

        #region WindZone

        private void DrawWindZone()
        {
            ZhuJian(ref mWindZone,ref isWindZone, () =>
            {
                mWindZone.mode = (WindZoneMode)m_Tools.BiaoTi_O("模式 （Mode）", (int)mWindZone.mode, WindModeStrs,25);
                if (mWindZone.mode == WindZoneMode.Spherical)
                {
                    m_Tools.Text_L("    [ 风区仅影响半径内，中心风力最强朝向边缘衰减 ]");
                    mWindZone.radius = TextFloat("半径", "Radius", mWindZone.radius, 100);
                }
                else
                {
                    m_Tools.Text_L("    [ 风区会影响整个场景的一个方向 ]");
                }
                mWindZone.windMain = TextFloat("主要风力", "Main", mWindZone.windMain, 10, 25);
                mWindZone.windTurbulence = TextFloat("产生快速变化的风压", "Turbulence", mWindZone.windTurbulence, 10, 25);
                mWindZone.windPulseMagnitude = TextFloat("时间推移风变化", "Pulse Magnitude", mWindZone.windPulseMagnitude, 5, 25);
                mWindZone.windPulseFrequency = TextFloat("风向改变频率", "Pulse Frequency", mWindZone.windPulseFrequency, 1, 25);
            });

            AddSpace();
            WindZoneBottom();
        }


        private readonly string[] WindModeStrs =
        {
            "Directional_方向",
            "Spherical_球形",

        };


        private void WindZoneBottom()
        {
            if (!isWindZone || null == mWindZone)
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Object  -> Component  ->  WindZone");
                    m_Tools.Text_L("  • 添加风区，来使树木挥舞着树枝和树叶仿佛被风吹过");
                    m_Tools.Text_L("  • 添加风区会影响粒子的 External Forces");
                });
            }

            AddSpace();
            m_Tools.BiaoTi_B("产生一个轻微变化的大风");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("1. " + "Directional".AddYellow() + " 定向风向，" + "Main".AddYellow() + " 风速设为1.0或更低");
                m_Tools.Text_W("2. " + "Turbulence".AddYellow() + " 湍流 0.1");
                m_Tools.Text_W("3. " + "Pulse Magnitude".AddYellow() + " 脉冲幅度 1.0或更大");
                m_Tools.Text_W("4. " + "Pulse Frequency".AddYellow() + " 脉冲频率 0.25");
            });
            m_Tools.BiaoTi_B("直升机通过的效果");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("1. " + "Spherical".AddYellow() + " 球形风区，设置半径 " + "Radius".AddYellow() + " 适合直升机的大小");
                m_Tools.Text_W("2. " + "Main".AddYellow() + " 风速 3.0");
                m_Tools.Text_W("3. " + "Turbulence".AddYellow() + " 湍流 5");
                m_Tools.Text_W("4. " + "Pulse Magnitude".AddYellow() + " 脉冲幅度 0.1");
                m_Tools.Text_W("5. " + "Pulse Frequency".AddYellow() + " 脉冲频率 1.0");
            });
            m_Tools.BiaoTi_B("爆炸的效果");
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("1. 与直升机一样");
                m_Tools.Text_W("2. 但要迅速消除风速Main和湍流Turbulence，使效果减弱");

            });
        }


        #endregion

        #region NavMeshAgent

        private readonly string[] ObstacleAvoidanceTypes =
        {
            "无",
            "低水平",
            "中等水平",
            "优质水平",
            "最高水平"
        };

        private void DrawNavMeshAgent()
        {
            ZhuJian(ref mNavMeshAgent,ref isNavMeshAgent, () =>
            {
                m_Tools.Text_Y("导航类型","(Agent Type)".AddWhite());
                m_Tools.BiaoTi_O("首先需要设置 包围盒包含物体");
                MyCreate.Box(() =>
                {
                    mNavMeshAgent.radius = TextFloat("半径", "Radius", mNavMeshAgent.radius, 10, 25);
                    mNavMeshAgent.height = TextFloat("高度", "Height", mNavMeshAgent.height, 10, 25);
                    mNavMeshAgent.baseOffset = TextFloat("包围盒上下偏移", "Base Offset", mNavMeshAgent.baseOffset, 10, 25, -10);
                });

                m_Tools.BiaoTi_O("驾驶 " + "(Steering) ".AddYellow() + "1代表1个 world units per，速度以每秒世界单位");
                MyCreate.Box(() =>
                {
                    mNavMeshAgent.speed = TextFloat("速度", "Speed", mNavMeshAgent.speed, 30, 25);
                    mNavMeshAgent.angularSpeed = TextFloat("转弯速度", "Angular Speed", (int)mNavMeshAgent.angularSpeed, 300, 25);
                    mNavMeshAgent.acceleration = TextFloat("起动速度", "Acceleration", mNavMeshAgent.acceleration, 30, 25);
                    mNavMeshAgent.stoppingDistance = TextFloat("距离多少停止", "Stopping Distance", mNavMeshAgent.stoppingDistance, 30, 25);
                    mNavMeshAgent.autoBraking = TextBool("放慢速度到达目标", "正常速度到达目标", "Auto Braking ", mNavMeshAgent.autoBraking, 53);
                });
                m_Tools.BiaoTi_O("避免障碍 " + "(Obstacle Avoidance)".AddYellow());
                MyCreate.Box(() =>
                {
                    mNavMeshAgent.obstacleAvoidanceType = (ObstacleAvoidanceType)TextEnum("障碍躲避水平 Quality", (int)mNavMeshAgent.obstacleAvoidanceType, ObstacleAvoidanceTypes, 53);
                    mNavMeshAgent.avoidancePriority = TextInt("躲避优先级", "Priority", mNavMeshAgent.avoidancePriority, 99, 53);
                });

                m_Tools.BiaoTi_O("路径寻找 " + "(Path Finding)".AddYellow());
                MyCreate.Box(() =>
                {
                    mNavMeshAgent.autoTraverseOffMeshLink = TextBool("使用传送点", "AutoTraverseOffMeshLink", mNavMeshAgent.autoTraverseOffMeshLink,65);
                    MyCreate.Heng(() =>
                    {
                        mNavMeshAgent.autoRepath = TextBool("自动规划网格", "AutoRepath", mNavMeshAgent.autoRepath, 65);
                        MyCreate.Text("如路径失效会自动规划新的路径".AddBlue());
                    });
                    m_Tools.TextText_YB("剔除层" + "(Area Mask)".AddWhite(), "打勾的为需要考虑的层",65);
                    Text6("Walkable", "可行走", "Not Walkable", "不可行走的区域", "Jump", "(跳)");
                });
            });
            AddSpace();
            NavMeshAgentBottom();
        }

        private void NavMeshAgentBottom()
        {
            if (!isNavMeshAgent || null == mNavMeshAgent)
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Object -> Component -> Behaviour -> NavMeshAgent");
                    m_Tools.Text_H("    导航详细看 各大功能 -> 热更新、导航等");
                });
            }
            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("hasPath", "只读", "目前是否有路径", "bool");
                m_Tools.Method_BW("pathStatus", "只读", "当前路径的状态", "NavMeshPathStatus 枚举");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL("   PathComplete", "会到达目的地", 20);
                    m_Tools.TextText_HL("   PathPartial", "无法到达目的地", 20);
                    m_Tools.TextText_HL("   PathInvalid", "路径无效", 20);
                });
                m_Tools.Method_BW("isOnNavMesh", "只读", "例如，场景没有导航网格 返回false", "bool");
                m_Tools.Method_BW("remainingDistance", "只读","与目标点的距离", "float");
            });
        }

        #endregion

        #region PhysicMaterial

        private void DrawPhysicMaterial()
        {
            ZhuJian(ref mPhysicMaterial,ref isPhysicMaterial, () =>
            {
                MyCreate.Box(() =>
                {
                    mPhysicMaterial.dynamicFriction = TextFloat("运行摩擦力", "Dynamic Friction", mPhysicMaterial.dynamicFriction, 1, 40);
                    m_Tools.Text_L("    ▪ 这个就是动摩擦力，下面是静摩擦力");
                    m_Tools.Text_L("    ▪ 静摩擦可防止静止的物体移动，需要足够大的力才将其移动");
                    m_Tools.Text_L("    ▪ 动摩擦是在移动时减慢物体的速度");
                    mPhysicMaterial.staticFriction = TextFloat("放置在表面时摩擦力", "Static Friction", mPhysicMaterial.staticFriction, 1, 40);
                });
                MyCreate.Box(() =>
                {
                    mPhysicMaterial.bounciness = TextFloat("弹性", "Bounciness", mPhysicMaterial.bounciness, 1, 40);
                    m_Tools.Text_L("    值为 0 时：表示没有反弹");
                    m_Tools.Text_L("    值为 1 时：表示能量没有损失的反弹，会一直反弹");
                });
                MyCreate.Box(() =>
                {
                    mPhysicMaterial.frictionCombine = (PhysicMaterialCombine)TextEnum("摩擦力组合","Friction Combine", mPhysicMaterial.frictionCombine, 60);
                    m_Tools.Text_Y("        [两个碰撞物体的摩擦力是如何结合的]");
                    m_Tools.TextText_HL("   Average", "两个碰撞体的摩擦力取平均值",10);
                    m_Tools.TextText_HL("   Minimum", "两个碰撞体的摩擦力取最小的那个", 10);
                    m_Tools.TextText_HL("   Maximum", "两个碰撞体的摩擦力取最大的那个", 10);
                    m_Tools.TextText_HL("   Multiply", "两个碰撞体的摩擦力取两个相乘", 10);

                    mPhysicMaterial.bounceCombine = (PhysicMaterialCombine)TextEnum("反弹组合", "Bounce Combine", mPhysicMaterial.bounceCombine, 60);
                    m_Tools.Text_Y("        [两个碰撞物体的弹力是如何结合的]");
                });
            });
            AddSpace();
            PhysicMaterialBottom();
        }

        private void PhysicMaterialBottom()
        {
            if (!isPhysicMaterial || null == mPhysicMaterial)
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("Object  ->  PhysicMaterial");
                    m_Tools.Text_L("    ▪ PhysicMaterial 是用来调整 ", "调整摩擦".AddGreen()," 和 ","碰撞对象的反弹效应".AddGreen());
                    m_Tools.Text_L("    ▪ 是用在", " Collider".AddBlue()," 上");
                    AddSpace();
                    MyCreate.Text("导入Characters包 包含以下:");
                    m_Tools.TextText_HY("Bouncy", "有弹性的");
                    m_Tools.TextText_HY("Ice", "冰");
                    m_Tools.TextText_HY("MaxFriction", "最大摩擦");
                    m_Tools.TextText_HY("Metal", "金属");
                    m_Tools.TextText_HY("Rubber", "橡胶");
                    m_Tools.TextText_HY("Wood", "木");
                    m_Tools.TextText_HY("ZeroFriction", "零摩擦");
                });
            }

        }


        #endregion


        private void DrawCamera()                                // Camera相机
        {
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("Clear Flags"+" (上一帧怎么清除，这一帧怎么画)".AddYellow());
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BL("Skybox", "上一帧全部清除，这一帧先画天空盒子", -50);
                    m_Tools.TextText_BL("Solid Color", "上一帧全部清除，这一帧先画固定的颜色", -50);
                    m_Tools.TextText_BL("Depth only", "不清除颜色，只清除深度，这一帧永远覆盖上一帧", -50);

                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("    这个通常用于多台摄像机的应用");
                        m_Tools.Text_H("    如两个 UI 摄像机，第二台在第一台之后渲染，就用这个");
                        m_Tools.Text_H("    配合下面的 " + "Depth".AddOrange() + " 深度，用来多台摄像机排序");
                    });
                    m_Tools.TextText_BL("Don't Clear", "不清除，完全保留上一帧", -50);

                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Culling Mask"+ "(想那层不渲染，就把这层不打勾)".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("例如：只渲染 UI ，那就只把 UI 这层打勾即可");
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Projection" + "(2D 还是 3D 投影)".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Perspective", "投影：透视投影，3D");
                m_Tools.TextText_BL("Orthographic", "投影：正投投影，2D");
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Viewport Rect" + "(视图绘制在屏幕的什么地方)".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("相当于渲染出来一张图，然后把图贴在屏幕那个位置");
                m_Tools.Text_L("(x 坐标，y 坐标，w 宽，h 高)");

            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Depth" + "(控制摄像机的渲染顺序)".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("呼应上面：每台相机的深度");
            });
            m_Tools.BiaoTi_O("Rendering Path" + "(渲染路径)".AddYellow());
            AddSpace_3();
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Use Player Settings", "使用 PlayerSetting 的设置");
                m_Tools.TextText_LW("Vertex Lit"+"(快速渲染)".AddBlue(), "将所有的对象做为顶点光照对象来渲染");
                m_Tools.TextText_LW("Forward"+"(快速渲染)".AddBlue(), "对所有对象按每种材质一个通道的方式来渲染");
                m_Tools.TextText_LW("Deferred Lighting"+"(延迟光照)".AddBlue(), "先对所有对象进行一次无光照渲染,");
                m_Tools.Text_W("                    记录光照信息，然后再次渲染所有对象并叠加光照信息");
            });
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Target Texture", "将渲染结果渲染到一张纹理上", -40);
                m_Tools.TextText_OY("HDR", "照到的显示，没照到的隐藏" + "（还需要其他操作）".AddGreen(), -40);
                m_Tools.TextText_OY("Target Display", "用于 多屏（分屏）显示", -40);
            });


        }




    }

}

