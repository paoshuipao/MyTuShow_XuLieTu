using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Unity_Struct : AbstactNewKuang
    {


        [MenuItem(LearnMenu.UnityStructZhongJie)]
        static void Init()
        {
            Unity_Struct instance = GetWindow<Unity_Struct>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {
            MyCreate.Text("struct 结构体：");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Quaternion";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Quaternion ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Quaternion);
            }
            AddSpace_3();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Rect";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Rect ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Rect);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Vector3";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Vector3 ? EZStyles.General.SideButtonSelected3: EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Vector3);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Matrix4x4";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Matrix4x4 ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Matrix4x4);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Scene";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Scene ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Scene);
            }
            AddSpace_3();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Color";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Color ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Color);
            }
            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "LayerMask";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.LayerMask ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LayerMask);
            }
            AddSpace_15();
            MyCreate.Text("Enum 枚举：");
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "RuntimePlatform".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.RuntimePlatform ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.RuntimePlatform);
            }
            AddSpace_3();
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "BuildTarget".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.BuildTarget ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.BuildTarget);
            }
        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Quaternion:        DrawRightPage1(DrawQuaternion);        break;
                case EType.Rect:              DrawRightPage3(DrawRect);              break;
                case EType.Vector3:           DrawRightPage4(DrawVector3);           break;
                case EType.Matrix4x4:         DrawRightPage5(DrawMatrix);            break;
                case EType.Color:             DrawRightPage6(DrawColor);             break;
                case EType.LayerMask:         DrawRightPage7(DrawLayerMask);         break;
                case EType.RuntimePlatform:   DrawRightPage8(DrawRuntimePlatform);   break;
                case EType.BuildTarget:       DrawRightPage1(DrawBuildTarget);       break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -10;
                    break;
            }
        }




        #region 私有
        private static bool isEx2, isDescription2, isSlerp, isLookRotation, isTu, isUse, isMoveTowards;

        private enum EType
        {
            Quaternion,
            Rect,

            Vector3,
            Matrix4x4,
            Color,
            LayerMask,
            Scene,


            RuntimePlatform,
            BuildTarget,



        }

        private EType type = EType.Quaternion;

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
            return "struct、enum";
        }


        #endregion


        //——————————————————结构体——————————————————

        private void DrawQuaternion()            // Quaternion
        {

            m_Tools.BiaoTi_O("Quaternion  " + "（旋转值）".AddGreen());
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Quaternion.html");

            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Method_BY("identity", " 只读 ", "不旋转,对齐世界或父物体方向", "Quaternion", -30);
            });

            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BY("LookRotation", "Vector3，V3", "根据" + "向前和向上方向".AddGreen() + "得出旋转值", "Quaternion", ref isLookRotation, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Text(("LookRotation(Vector3 " + "forward".AddBlue() + " , Vector3 " + "upwards".AddBlue() + " = Vector3.up)").AddWhite());
                        m_Tools.TextText_BG("       forward", "向前的方向");
                        m_Tools.TextText_BG("       upwards", "向上的方向");
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_H("例子 :实现立刻转向目标，而且 y 轴不动：");
                            m_Tools.Text_G("// 指向目标的向量");
                            m_Tools.Text_W("Vector3 v = t_Target.position - transform.position");
                            m_Tools.Text_G("// y 轴不动");
                            m_Tools.Text_W("v.y = 0");
                            m_Tools.Text_G("// 转向始终跟着v向量");
                            m_Tools.Text_W("transform.rotation=Quaternion.LookRotation(v)");
                        });
                    });

                });
                m_Tools.Method_BY("Slerp", "Q1,Q2,t", "旋转值的" + "插值".AddGreen(), "Quaternion", ref isSlerp, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Text(("Slerp( Quaternion " + "from".AddBlue() + " , Quaternion " + "to".AddBlue() + " , float" + " time ".AddBlue() + ")").AddWhite());
                        m_Tools.TextText_BL("       from", "开始的旋转");
                        m_Tools.TextText_BL("       to", "结束的旋转");
                        m_Tools.TextText_BL("       time", "速度 Time.deltaTime * Speed");

                        m_Tools.Text_Y("1.Quaternion.Slerp 与 Quaternion.Lerp区别", ref isDescription2, () =>
                        {
                            MyCreate.Box(() =>
                            {
                                m_Tools.TextText_LW("Quaternion.Slerp", "是以每段角度来作插值");
                                m_Tools.TextText_LW("Quaternion.Lerp", "是以距离长度来作插值");
                                m_Tools.Text_G("旋转时，距离长度会不规则变化，使用固定每段角度 Slerp 才是最好的");
                            });

                        });

                        m_Tools.Text_Y("2.例子 :实现平滑地转向目标，而且 y 轴不动：", ref isEx2, () =>
                        {
                            MyCreate.Box(() =>
                            {
                                m_Tools.Text_G("// 指向目标的向量");
                                m_Tools.Text_W("Vector3 v = t_Target.position - transform.position");
                                m_Tools.Text_G("// y 轴不动");
                                m_Tools.Text_W("v.y = 0");
                                m_Tools.Text_G("// 得到面向目标的转向");
                                m_Tools.Text_W("Quaternion to=Quaternion.LookRotation(v)");
                                m_Tools.Text_G("// 以插值的形式赋值给 transform 旋转值");
                                m_Tools.Text_W("transform.rotation=Quaternion.Slerp(transform.rotation,to,Time.deltaTime)");

                            });
                        });
                    });

                });
                m_Tools.Method_BY("FromToRotation", "V3 a，V3 b", "从" + " a 点到 b 点".AddGreen() + "的旋转值", "Quaternion");
                m_Tools.Method_BY("Euler", "f x ,f y , f z", "将一个向量转成旋转值", "Quaternion");
                m_Tools.Method_BY("Angle", "Q1,Q2", "两个旋转值的" + "角度".AddGreen(), "float");
                m_Tools.Method_BY("Dot", "Q1,Q2", "两次旋转值的" + "点积".AddGreen(), "float");
            });


            MyCreate.AddSpace(15);
            MyCreate.Window("四元数 " + "(旋转值)".AddYellow() + " 与 欧拉角 " + "(旋转后的向量)".AddYellow() + "说明", () =>
            {
                m_Tools.TextText_OW("• 四元数" + " [ Quaternion ]".AddYellow(), "transform.rotation");
                m_Tools.TextText_OW("▪ 欧拉角" + " [ Vector3 ]".AddYellow(), "transform.eulerAngles");
                m_Tools.Text_O("▪ 欧拉角 —— > 四元数：");
                m_Tools.Text_W("       transform.rotation = Quaternion.Euler( x,y,z )");
                m_Tools.Text_O("▪ 四元数 —— > 欧拉角：");
                m_Tools.Text_W("       transform.rotation.eulerAngles");
            });
        }


        private void DrawVector3()               // Vector3 向量
        {
            m_Tools.BiaoTi_O("Vector3  " + "（三维向量，使用此结构来传递3D位置和方向）".AddGreen());
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Vector3.html");


            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_YW("normalized", "只读", "向量归一", "Vector3", -30);
                m_Tools.Method_YW("magnitude", "只读", "向量的长度" + "(这个比下面多开根号算法)".AddGreen(), "float", -30);
                m_Tools.Method_YW("sqrMagnitude", "只读", "向量的长度的平方" + "(能用这个就别用上面)".AddGreen(), "float", -30);
                m_Tools.Method_YW("this[int]", "索引器", "分别使用[0]，[1]，[2]访问x，y，z分量", "float", -30);
            });


            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Method_BL("up、down、left、right、forward、back", "", "单方向为1", "Vector3", ref isTu, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_LW("up " + "(0,1,0)".AddWhite(), "down ".AddLightBlue() + "(0,-1.0)");
                        m_Tools.TextText_LW("left " + "(-1,0,0)".AddWhite(), "right ".AddLightBlue() + "(1,0,0)");
                        m_Tools.TextText_LW("forward" + " (0,0,1)".AddWhite(), "back ".AddLightBlue() + "(0,0,-1)");
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711181456819-1058888860.png");
                    });

                }, 80);
                m_Tools.Method_BL("negativeInfinity/positiveInfinity", "", "负无穷/正无穷", "Vector3", 80);
            });

            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BY("Distance", "Vector3，Vector3", "两点之间距离", "float", 10);
                m_Tools.Method_BY("Dot", "Vector3，Vector3", "点积" + "(同方向为正，异方向为负)".AddGreen(), "float", 10);
                m_Tools.Method_BY("Lerp", "Vector3，Vector3，float", "线性插值", "Vector3", 10);
                m_Tools.Method_BY("Slerp", "Vector3，Vector3，float", "球形插值" + "(用到角度用它好)".AddGreen(), "Vector3", 10);
                m_Tools.Method_BY("ClampMagnitude", "Vector，float", "向量为原点" + "限定最长长度".AddGreen() + "随机向量", "Vector3", 10);
                m_Tools.Method_BY("Cross", "Vector3，Vector3", "叉积" + "(垂直两个向量的向量)".AddGreen(), "Vector3", 10);
                m_Tools.Method_BY("MoveTowards", "Vector3，Vector3 目标点，float 最大到达距离", "移动", "Vector3", ref isMoveTowards,
                    () =>
                    {
                        m_Tools.Text_W("transform.position =Vector3.MoveTowards(transform.position ,目标,Time.deltaTime)");

                    }, 10);

                m_Tools.Text_G("少用的或已熟记", ref isUse, () =>
                {
                    m_Tools.Method_BY("RotateTowards", "Vector3，Vector3，float，float", "a 跟着 b 角度", "Vector3");
                    m_Tools.Method_BY("SmoothDamp", "", "平滑过渡", "Vector3");
                    m_Tools.Method_BY("Angle", "Vector3，Vector3", "a 到 b 的" + "角度".AddGreen(), "float");
                    m_Tools.Method_BY("SignedAngle", "", "返回根据轴的角度", "float");
                    m_Tools.Method_BY("OrthoNormalize", "ref V a,ref V b，ref V c", "向量归一化并相互正交,等于XYZ轴");
                    m_Tools.Method_BY("LerpUnclamped", "V3 a,V3 b,float", "插值不会受限制，如t=10,值=b*10", "Vector3");
                    m_Tools.Method_BY("SlerpUnclamped", "", "球形插值并且不会受最大最小限制", "Vector3");
                    m_Tools.Method_BY("Normalize", "Vector3", "长度为1", "Vector3");
                    m_Tools.Method_BY("Max", "Vector3，Vector3", "a b 那个大返回谁咯", "Vector3");
                    m_Tools.Method_BY("Min", "Vector3，Vector3", "a b 那个小返回谁咯", "Vector3");
                    m_Tools.Method_BY("Project", "Vector3，Vector3", "将 a 投射到 b 身上，多就补，少就剪切", "Vector3", -50);
                    m_Tools.Method_BY("ProjectOnPlane", "", "将矢量投影到由与平面正交的法线定义的平面上", "Vector3", -50);
                    m_Tools.Method_BY("Reflect", "V3,V3", "a 以 b 定义的平面反射出一个向量", "Vector3");
                    m_Tools.Method_BY("Scale", "Vector3，Vector3", "两个矢量分量相乘", "Vector3");
                });

            });

        }

        private void DrawMatrix()                // Matrix4x4 矩阵
        {

            m_Tools.Method("isIdentity", "", "这个矩阵是不是" + "单位矩阵".AddGreen(), "bool");
            m_Tools.Method("transpose", "", "这个矩阵的" + "转置矩阵".AddGreen(), "Matrix4x4");
            m_Tools.Method("inverse", "", "这个矩阵的" + "逆矩阵".AddGreen(), "Matrix4x4");
            m_Tools.Method("lossyScale", "", "从矩阵中获取比例值", "Vector3");
            m_Tools.Method("rotation", "", "从矩阵中获取旋转值", "Quaternion");

            m_Tools.Method("GetRow（int i）", "", "获取矩阵的一" + "行".AddGreen(), "Vector4");
            m_Tools.Method("SetRow", "", "设置矩阵一行", "void");
            m_Tools.Method("GetColumn（int i）", "", "获取矩阵的一" + "列".AddGreen(), "Vector4");
            m_Tools.Method("SetColumn", "设置矩阵一列", "", "void");
            m_Tools.Method("MultiplyPoint（Vector3 v）", "", "通过这个矩阵实现" + "转换位置(通常)".AddGreen(), "Vector3");
            m_Tools.Method("MultiplyPoint3x4（Vector3 v）", "", "通过这个矩阵实现" + "转换位置(快速)".AddGreen(), "Vector3");
            m_Tools.Method("MultiplyVector（Vector3 v）", "", "通过这个矩阵实现" + "转换方向".AddGreen(), "Vector3");
            m_Tools.Method("SetTRS", "", "设置这个矩阵可以实现" + "位置，旋转、缩放".AddGreen(), "void");
            m_Tools.Method("ValidTRS", "", "检查这个矩阵是否是一个有效的变换矩阵", "bool");

            m_Tools.Method("Rotate", "", "创建一个旋转矩阵", "Matrix4x4");
            m_Tools.Method("Scale", "", "创建一个缩放矩阵", "Matrix4x4");
            m_Tools.Method("Translate", "", "创建一个移动矩阵", "Matrix4x4");
            m_Tools.Method("TRS", "", "创建一个位置，旋转和缩放的矩阵", "Matrix4x4");

            m_Tools.TextText_BL(" *  Matrix4x4 b", "两个矩阵" + "相乘".AddGreen());


            m_Tools.Method("this[int,int]", "", "访问元素[行，列]", "float");
            m_Tools.Method("decomposeProjection", "", "分解成六个平面坐标", "FrustumPlanes");
            m_Tools.Method("determinant", "", "决定因素", "float");

            m_Tools.Method("TransformPlane(Plane p)", "", "平面P根据矩形转换成新的Plane", "Plane");


            m_Tools.Method("Frustum", "", "产生一个可视截头的投影矩阵", "Matrix4x4");
            m_Tools.Method("LookAt", "", "产生一个转换矩阵", "Matrix4x4");
            m_Tools.Method("Ortho", "", "产生一个正交投影矩阵", "Matrix4x4");
            m_Tools.Method("Perspective", "", "创建透视投影矩阵", "Matrix4x4");

        }


        private void DrawColor()                 // Color
        {
            MyCreate.Text("rgba :".AddGreen() + "每个颜色分量都是一个范围从".AddLightBlue() + "0到1".AddGreen() + "的浮点值".AddLightBlue());
            m_Tools.Text_H("new Color(float r，float g，float b，float a)");
            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BY("Lerp", "Color 小,Color 大,float 时间", "颜色的插值", "Color", 30);
                m_Tools.Method_BY("LerpUnclamped", "Color 小,Color 大,float 时间", "插值不设限制", "Color", 30);


            });
        }


        private void DrawRect()                  // Rect
        {
            m_Tools.BiaoTi_O("Rect   " + "（矩形）".AddGreen());
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711181337732-1637271992.png");
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BY("xMin", "", "xMax 不变，改变此值将 改变 x坐标与宽度", "float", -100);
                m_Tools.Method_BY("xMax", "", "xMin 不变，改变此值将 改变 宽度", "float", -100);
                m_Tools.Method_BY("yMin", "", "yMax 不变，改变此值将 改变 y坐标与高度", "float", -100);
                m_Tools.Method_BY("yMax", "", "yMin 不变，改变此值将 改变 高度", "float", -100);

            });

            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_BL("Contains", "Vector3", "这个点是否在矩形内", "bool");
                m_Tools.Method_BL("Overlaps", "Rect", "这个矩形是否重叠矩形内", "bool");
            });

            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_OY("Rect.MinMaxRect", "float xmin, float ymin, float xmax, float ymaxs", "", "Rect");
            });



        }


        private void DrawLayerMask()             // LayerMask
        {
            MyCreate.Text("例如，在投射射线时，可以使用图层蒙版选择性地过滤游戏对象");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("public LayerMask mask = -1;");
                m_Tools.Text_H("void Update() {");
                m_Tools.Text_H("    if (Physics.Raycast(坐标,方向,最大距离,mask.value))");
                m_Tools.Text_H("}");
            });
            m_Tools.Text_G("注意:LayerMask是一个位掩码,使用 static 方法生成位掩码");
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("value", "", "将图层蒙版值转换为整数值", "int", -50);
            });
            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BY("GetMask", "params string[] layerNames", "可多个层名获得层索引", "int");
                m_Tools.Method_BY("NameToLayer", "string", "一个层名获得层索引", "int");
                m_Tools.Method_BY("LayerToName", "int 层", "通过层索引反获得层名", "string");
            });
            m_Tools.Text_G("用法：与 int 类同");
        }





        //——————————————————枚举——————————————————



        private void DrawRuntimePlatform()       // RuntimePlatform
        {

            m_Tools.BiaoTi_B("RuntimePlatform " + "( Application.platform 获得正在运行的平台)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("Unity 编辑器");
                m_Tools.TextText_BL("OSXEditor", "在 MacOS 上的编辑器");
                m_Tools.TextText_BL("WindowsEditor", "在 Windows 上的编辑器");
                m_Tools.TextText_BL("LinuxEditor", "在 linux 上的编辑器");
                MyCreate.Text("移动平台");
                m_Tools.TextText_BY("IPhonePlayer", "iPhone");
                m_Tools.TextText_BY("Android", "Android");
                MyCreate.Text("PC 媒体播放器");
                m_Tools.TextText_BY("OSXPlayer", "MacOS");
                m_Tools.TextText_BY("WindowsPlayer", "Windows");
                m_Tools.TextText_BY("LinuxPlayer", "linux");
                MyCreate.Text("其他");
                m_Tools.TextText_BH("WSAPlayerX86/X64/ARM", "在应用商店应用时的 Windows 32位/64位");
                m_Tools.Text_B("WebGLPlayer、PSP2、PS4、XboxOne、WiiU、tvOS、Switch");
            });
        }



        private void DrawBuildTarget()            // BuildTarget
        {
            m_Tools.BiaoTi_B("BuildTarget " + "(打包AssetBundle的平台)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Text("移动平台");
                m_Tools.TextText_BY("iOS", "iPhone", 40);
                m_Tools.TextText_BY("Android", "Android", 40);
                MyCreate.Text("PC 媒体播放器");
                m_Tools.TextText_BY("StandaloneOSX", "MacOS", 40);
                m_Tools.TextText_BY("StandaloneWindows", "Windows 32位", 40);
                m_Tools.TextText_BY("StandaloneWindows64", "Windows 64位", 40);
                m_Tools.TextText_BY("StandaloneLinux", "linux 32位", 40);
                m_Tools.TextText_BY("StandaloneLinux64", "linux 64位,20", 40);
                m_Tools.TextText_BY("StandaloneLinuxUniversal", "linux 通用", 40);
                MyCreate.Text("其他");
                m_Tools.Text_B("WebGL、WSAPlayer、Tizen、Tizen、PS4");
                m_Tools.Text_B("XboxOne、N3DS、WiiU、tvOS、Switch");
            });
        }

    }

}

