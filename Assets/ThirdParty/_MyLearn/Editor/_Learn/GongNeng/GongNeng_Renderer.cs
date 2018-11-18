using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class GongNeng_Renderer : AbstactNewKuang
    {

        [MenuItem(LearnMenu.GongNeng_Renderer)]
        static void Init()
        {
            GongNeng_Renderer Instance = GetWindow<GongNeng_Renderer>(false, "");
            Instance.SetupWindow();
        }

        protected override void DrawLeft()
        {


            MyCreate.Text("Renderer 渲染体");


            #region Renderer 基类

            bool tmpOther = (type == EType.Renderer || type == EType.Renderer1 || type == EType.Renderer2 || type == EType.Renderer3 || type == EType.Renderer4);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Renderer 基类".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Renderer ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Renderer);
            }

            if (tmpOther)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Renderer1 ? "  各子类应用场景".AddBlue() : "  各子类应用场景");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Renderer1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Renderer2 ? "  各子类图".AddBlue() : "  各子类图");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Renderer2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Renderer3 ? "  面板对比图".AddBlue() : "  面板对比图");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Renderer3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Renderer4 ? "  Bounds".AddBlue() : "  Bounds");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Renderer4);
                }
            }


            #endregion

            AddSpace_3();

            MyCreate.Text("______");

            #region SkinnedMeshRenderer

            bool tmpSkinned = (type == EType.SkinMesh || type == EType.SkinMesh1);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "SkinnedMeshRenderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.SkinMesh ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.SkinMesh);
            }
            if (tmpSkinned)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.SkinMesh1 ? "与 MeshRenderer 相同点".AddColorAndSize(MyEnumColor.Blue,11,false): "与 MeshRenderer 相同点".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.SkinMesh1);
                }
            }

            #endregion


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "MeshRenderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Mesh ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Mesh);
            }

            AddSpace_3();



            MyCreate.Text("______");

            bool tmpLine = (type == EType.Line || type == EType.Line1);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "LineRenderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Line ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Line);
            }
            if (tmpLine)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Line1 ? "与 TrailRenderer 相同点".AddColorAndSize(MyEnumColor.Blue, 11, false) : "与 TrailRenderer 相同点".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Line1);
                }
            }

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "TrailRenderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Trail ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Trail);
            }


            AddSpace_3();


            bool tmpSprite = (type == EType.Sprite || type == EType.Sprite1);


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "SpriteRenderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Sprite ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Sprite);
            }
            if (tmpSprite)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Sprite1 ? "与 Canvas 相同点".AddColorAndSize(MyEnumColor.Blue, 11, false) : "与 Canvas 相同点".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Sprite1);
                }
            }

            AddSpace_3();


            bool tmpOther2= (type == EType.Other || type == EType.Billboard || type == EType.Other1 || type == EType.Other2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "其他 Renderer".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(tmpOther2 ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Billboard);
            }
            if (tmpOther2)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Billboard ? "BillboardRenderer".AddColorAndSize(MyEnumColor.Blue, 11, false) : "BillboardRenderer".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Billboard);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Other1 ? "粒子 Renderer".AddColorAndSize(MyEnumColor.Blue, 11, false) : "粒子 Renderer".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Other1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Other2 ? "TilemapRenderer".AddColorAndSize(MyEnumColor.Blue, 11, false) : "粒子 Renderer".AddSize(11));
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Other2);
                }
            }



            AddSpace();
            
            MyCreate.Text("Collider 碰撞体");

            bool tmpCollider = (type == EType.Collider || type == EType.Collider1 || type == EType.Collider2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Collider 基类".AddSize(13);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Collider ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Collider);
            }

            if (tmpCollider)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Collider1 ? "  Collision".AddBlue() : "  Collision");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Collider1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Collider2 ? "  PolygonCollider2D".AddBlue() : "  PolygonCollider2D");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Collider2);
                }
            }

        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Renderer:     DrawRightPage1(DrawRenderer);         break;
                case EType.Renderer1:    DrawRightPage1(DrawRendererApi);      break;
                case EType.Renderer2:    DrawRightPage(DrawZiTu);              break;
                case EType.Renderer3:    DrawRightPage(DrawDuiBiTu);           break;
                case EType.SkinMesh:     DrawRightPage3(DrawSkinnedMesh);      break;
                case EType.Mesh:         DrawRightPage4(DrawMeshRenderer);     break;
                case EType.Line:         DrawRightPage5(DrawLineRenderer);     break;
                case EType.Line1:        DrawRightPage(DrawLineAndTrail);      break;
                case EType.Trail:        DrawRightPage6(DrawTrailRenderer);    break;
                case EType.Sprite:       DrawRightPage7(DrawSpriteRenderer);   break;
                case EType.Billboard:    DrawRightPage8(DrawBillboard);        break;
                case EType.Collider:     DrawRightPage1(DrawCollider);         break;
                case EType.Collider1:    DrawRightPage3(DrawCollision);        break;
                case EType.Collider2:    DrawRightPage4(DrawPolygon2D);        break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Renderer2:
                    mWindowSettings.pageWidthExtraSpace.target = 200;
                    break;
                case EType.Renderer3:
                    mWindowSettings.pageWidthExtraSpace.target = 220;
                    break;
                case EType.SkinMesh:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.Mesh:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.Line1:
                    mWindowSettings.pageWidthExtraSpace.target = 80;
                    break;
                case EType.Sprite:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                case EType.Billboard:
                    mWindowSettings.pageWidthExtraSpace.target = 40;
                    break;
                case EType.Collider:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;

            }
        }



        #region 私有

        private static readonly string LOOKATstr = "始终朝向摄像机".AddGreen();
        private bool isTU, isReceive, isReflection, isMotion, isProbes, isReflectionPro;

        private enum EType
        {
            Renderer, Renderer1, Renderer2, Renderer3, Renderer4,
            SkinMesh, SkinMesh1,
            Mesh,
            Line, Line1,
            Trail,
            Sprite, Sprite1,
            Other,Billboard, Other1, Other2,
            Collider, Collider1, Collider2

        }


        private EType type = EType.Renderer;

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
            return "Renderer";
        }


        private void TheSameMainBan()                         // 共有面板
        {
            m_Tools.BiaoTi_B("共有面板");
            MyCreate.Box(() =>
            {
                MyCreate.Text("1.  Material  ->  材质".AddGreen());
                m_Tools.TextText_BL("只有 SpriteRenderer 搞特殊 -> Material","只能用一个 材质",80);
                m_Tools.TextText_BL("其他 都是使用 -> Materials", "使用至少 1 个材质",80);
            });

        }


        #endregion

        #region Renderer 基类


        private void DrawRenderer()                              // Renderer
        {
           
            m_Tools.BiaoTi_O("Renderer 结构图");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("Object  ->  Component","(附加到 GameObject 的组件)".AddHui(),"  ->  Renderer");
                m_Tools.TextText_BY("   Renderer -> SkinnedMeshRenderer"+ONE,"带动画的 Mesh",90);
                m_Tools.TextText_BY("   Renderer -> MeshRenderer"+TWO,"静态物体的 Mesh", 90);
                m_Tools.TextText_BY("   Renderer -> LineRenderer"+THREE,"线性，"+ LOOKATstr, 90);
                m_Tools.TextText_BY("   Renderer -> TrailRenderer"+FOUR,"拖尾", 90);
                m_Tools.TextText_BY("   Renderer -> SpriteRenderer"+FIVE,"图", 90);
                m_Tools.TextText_BG("   Renderer -> BillboardRenderer" + SIX, LOOKATstr, 90);
            });

            AddSpace();

            m_Tools.BiaoTi_B("回调函数  " + "脚本有 Renderer 组件才触发".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("OnBecameVisible", "Renderer 变成可见时调用");
                m_Tools.TextText_OY("OnBecameInvisible", "Renderer 在" + "任何相机不再可见".AddGreen() + "的情况下调用");
            });

            AddSpace();

            TheSameMainBan();



        }



        private void DrawRendererApi()                           // 各子类应用场景
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Renderer.html");


            m_Tools.BiaoTi_O("各个 Renderer 应用场景：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("FBX、3DMax 模型，带有动画，那么它", "自带".AddGreen(), " SkinnedMeshRenderer");
                m_Tools.Text_L("FBX、3DMax 模型，没有动画，那么它", "自带".AddGreen(), " MeshRenderer");
                m_Tools.Text_L("想要一条或多条始终在屏幕上看见到的线", "（直线、曲线）".AddOrange(), "  -> LineRenderer");
                m_Tools.Text_L("想要在屏幕上看见到拖尾", "（尾巴逐渐消失）".AddOrange(), "  -> TrailRenderer");
                m_Tools.Text_L("想要 3D 显示一张图片  -> SpriteRenderer");
                m_Tools.Text_L("比如头顶文字、血条、3d场景里的2d角色  -> BillboardRenderer");

            });

            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("material","", "返回第一个Material", "Material");
                m_Tools.Method_OY("materials","", "这个Renderer 的Material", "Material[]");
                m_Tools.Method_OY("sharedMaterials", "", "影响所有Perfab 的Material", "Material[]");
                m_Tools.Method_OY("sortingLayerName", "", "渲染层的名字", "string");
                m_Tools.Method_OY("sortingOrder", "", "渲染层（sortingOrder > Z 轴）", "int");
                m_Tools.Method_OY("allowOcclusionWhenDynamic", "", "Dynamic Occluded   " + "是否动态遮挡剔除", "bool");
                m_Tools.TextText_OW("reflectionProbeUsage", " Lighting/Reflection Probe  " + "反射探头".AddYellow(), ref isReflection, () =>
                {
                    ReflectionProbeUsage(true);
                });

                m_Tools.TextText_OW("receiveShadows", " Lighting/Receive Shadows  " + "是否接收阴影".AddYellow(), ref isReceive, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_G("是否接收阴影");
                        m_Tools.Text_G("面板没有的，默认 false");
                    });
                });

            });

            AddSpace();


        }

        private void DrawDuiBiTu()                               // 面板对比图
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725215759334-299713514.png");
        }


        private void DrawZiTu()                                  // Renderer 图
        {
            m_Tools.BiaoTi_O("SkinnedMeshRenderer");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725165123746-1966238023.png");
            AddSpace();
            m_Tools.BiaoTi_O("MeshRenderer");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725165410292-1792441487.png");
            AddSpace();

            m_Tools.BiaoTi_O("LineRenderer");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725165417532-1107435208.png");
            AddSpace();

            m_Tools.BiaoTi_O("TrailRenderer");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725165424745-584143833.png");
            AddSpace();

            m_Tools.BiaoTi_O("SpriteRenderer");
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180725165430218-714616010.png");


        }


        #endregion


        #region Line 与 Trail

        private void DrawLineRenderer()                          // LineRenderer 线性
        {
            m_Tools.BiaoTi_B("Line Renderer");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("  1. 始终朝向摄像机，即只要存在，一定会渲染在屏幕上");
                m_Tools.Text_G("  2. Transform 任何属性都不会起作用");
                m_Tools.Text_H("  3. 与 TrailRenderer 有许多相同属性，特有的如下：");
            });
            AddSpace_15();
            m_Tools.TextText_BL("▪  Positions","坐标");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_W("     既然 Transform 不起作用，肯定需要 坐标来定位置");
                m_Tools.Text_W("     两点成一线，两个点以上成拆线");
            });
            AddSpace();
            m_Tools.TextText_BL("▪  Use World Space","是否使用世界坐标");
            AddSpace();
            m_Tools.TextText_BL("▪  Loop", "是否首尾相接，形成循环"+"(3个点以上)".AddGreen());


        }


        private void DrawLineAndTrail()                           // Line 与 Trail 相同 点
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180726083121451-664045256.png");

            m_Tools.BiaoTi_O("上部分");
            MyCreate.Box(() =>
            {
                MyCreate.Text("一开始是 -> 阴影的设置：".AddColorAndSize(MyEnumColor.Yellow, 10, false));
                m_Tools.TextText_OY("Cast Shadows", "产生阴影（无、有、双面、只有阴影）");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text4_L("      Off", "这物体不会产生阴影", "TwoSided", "我能给你产生阴影，你也能在我身上产生阴影", 2);
                    m_Tools.Text4_L("      On", "产生阴影", "ShadowsOnly", "物体是不可见的，但产生阴影物体", 2);
                });

                m_Tools.TextText_OY("Receive Shadows", "是否接收阴影");
                MyCreate.Text("然后就是关于 -> 动态操作：".AddColorAndSize(MyEnumColor.Blue, 10, false));
                m_Tools.TextText_OB("Dynamic Occluded", "是否动态遮挡剔除，不勾（静态），勾（动态）");
                m_Tools.TextText_OB("Motion Vectors", "运动向量(从一帧到下一帧跟踪每像素对象的速度)", ref isMotion, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BL("   Camera", "仅使用相机移动来跟踪动作", -30);
                        m_Tools.TextText_BL("   Object", "此对象将呈现每个对象的运动矢量通道" + "(面板没有的，默认这个)".AddGreen(), -30);
                        m_Tools.TextText_BL("   ForceNoMotion", "此对象将呈现零运动", -30);
                    });
                });
                MyCreate.Text("常规操作 -> 设置材质".AddColorAndSize(MyEnumColor.Blue, 10, false));
                m_Tools.TextText_OB("Materials", "设置至少 1 个材质");
                m_Tools.TextText_OH("Lightmap Parameters", "启用该线与全局照明系统进行交互");

            });
            m_Tools.BiaoTi_O("下部分");
            MyCreate.Box(() =>
            {
                MyCreate.Text("先来两个简单的 -> ".AddColorAndSize(MyEnumColor.Yellow, 10, false));
                m_Tools.TextText_OY("Width", "宽度" + "（即这个两大小不关 Scale 影响）".AddGreen());
                m_Tools.TextText_OY("Color", "带渐变的颜色条");

                MyCreate.Text("四角的拆角 要不要光滑一点 -> ".AddColorAndSize(MyEnumColor.Green, 10, false));
                m_Tools.TextText_OG("Corner Vertices".AddOrange(), "拆角处的顶点数,值越高,越圆滑");
                m_Tools.TextText_OG("End Cap Vertices".AddOrange(), "两端处的顶点数,值越高,越圆滑");

                MyCreate.Text("关于图片、相机的操作 -> ".AddColorAndSize(MyEnumColor.Hui, 10, false));
                m_Tools.TextText_OH("Alignment".AddOrange(), "是" + "面向相机".AddGreen() + " 还是 " + "面向本地Transform".AddGreen());
                m_Tools.TextText_OH("Texture Mode".AddOrange(), "纹理模式：" + "拉伸、包裹还是平铺".AddGreen() + ",与 Image 相似");
                m_Tools.TextText_OH("Generate Lighting Data".AddOrange(), "勾选 " + "光照".AddGreen() + "对其会有影响");
                m_Tools.TextText_OH("Sorting Layer", "渲染层 ( > Z 轴 )");
                m_Tools.TextText_OH("Order In Layer ", " Z 轴不动情况下，值越大，类Z轴越大 ");
                m_Tools.TextText_OH("Light Probes", "光探针", ref isProbes, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_BL("  Off", "不使用任何插值光探针");
                        m_Tools.TextText_BL("  Blend Probes", "使用一个内插光探针 (默认选项)");
                        m_Tools.TextText_BL("  Use Proxy Volume", "使用插入光探针的3D网格");
                    });
                });
                m_Tools.TextText_OH("Reflection Probes", "反射探针", ref isReflectionPro, () =>
                {
                    MyCreate.Box_Hei(() =>
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
            });

        }


        private void DrawTrailRenderer()                         // TrailRenderer 拖尾
        {

            m_Tools.BiaoTi_B("Trail Renderer" + "(拖尾)".AddGreen());

            MyCreate.Box(() =>
            {
                m_Tools.Text_H("  1. 过一段时间会从尾部逐渐消失，形成拖尾");
                m_Tools.Text_G("  2. 头坐标就是 Transform 的 Position 坐标");
                m_Tools.Text_G("  3. Transform 的 Rotation、Scale 不起作用");
                m_Tools.Text_H("  3. 与 LineRenderer 有许多相同属性，特有的如下：");
            });
            AddSpace();
            m_Tools.BiaoTi_B("特有面板属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("▪  Time", "多长时间消失");
                m_Tools.TextText_BL("▪  Min Vertex Distance", "最小的距离");
                m_Tools.TextText_BL("▪  Autodestruct", "是否销毁这 GameObject，当没有拖尾时");
            });


            AddSpace();
            m_Tools.BiaoTi_L("切水果 例子：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_O("1. 一定是把阴影关掉啊，不浪费性能");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_W("    Cast Shadows -> Off       Recive Shadows -> 不勾选");
                });

                m_Tools.Text_O("2. 材质");
                MyCreate.Box_Hei(() =>
                {
                   m_Tools.TextButton_Open("导入例子材质",@"F:\ZiLiao\使用其它插件的包\我的测试用\水果拖尾.unitypackage");
                });
                m_Tools.Text_O("3. Trail 特有的设置");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text4_B("  Time"," 0.15","Min Vertex Distance","0");
                    m_Tools.Text4_B("  Width"," 3.5","Color","颜色 选个好看的渐变即可");
                });

                m_Tools.Text_O("4. 其他默认即可");

            });



        }







        #endregion

        #region Renderer

        private void DrawSkinnedMesh()                             // Skinned Mesh Renderer 带动画的Mesh
        {

            m_Tools.BiaoTi_B("Skinned Mesh Renderer"+"(带动画的 Mesh)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Quality", "在蒙皮时每个顶点使用的" + "骨骼".AddWhite() + "的最大数量");
                MyCreate.Box(() =>
                {
                    m_Tools.TextText("Auto", "自动 （获得所需的动画质量和帧率的平衡）");
                    m_Tools.TextText("1 2 4 Bone", "骨骼数，数量越多，渲染器的质量就越高");
                    m_Tools.Text_G("使用四块骨头可以得到最好的结果,但会带来更高的处理开销");
                    m_Tools.Text_G("游戏通常使用两个骨骼重量，这是视觉质量和性能之间的良好折衷");
                });

                m_Tools.TextText_OY("Update When Offscreen", "勾选在" + "屏幕外动画".AddWhite() + "也会运行，高消耗");
                m_Tools.TextText_OY("Skinned Motion Vectors", "皮肤的" + "运动矢量".AddWhite());
                m_Tools.Text_G("启用: Mesh蒙皮数据会双缓冲,蒙皮运动有缓存并放置到运动矢量Texture中");
                m_Tools.Text_G("         GPU内存开销换更正确的运动向量");
                m_Tools.TextText_OY("Mesh", "Mesh Filter 整合在这里");
                m_Tools.TextText_OY("Root Bone", "使用它来定义作为动画“根”的骨骼");
                m_Tools.TextText_OY("", "（即所有其他骨骼相对于其移动的骨骼）".AddGreen());
                m_Tools.TextText_OY("Bounds", "边框");
                DrawBounds();
            });

            MeshTheSame();
        }

        private void DrawMeshRenderer()                          // Mesh Renderer 静态物体的Mesh
        {
            m_Tools.BiaoTi_B("Mesh Renderer" + "(静态物体的 Mesh)".AddGreen());
            MeshTheSame();
        }


        private void DrawSpriteRenderer()                        // SpriteRenderer 图片
        {
            m_Tools.BiaoTi_B("Sprite Renderer" + "(图片)".AddGreen());

            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Flip".AddOrange(), "反转".AddWhite() + " 勾选那个轴，那个轴反转");
                m_Tools.TextText_OY("Draw Mode".AddOrange(), "图片模式，与 Image 一样，就少了最后的Filled填充");
                m_Tools.TextText_OY("Sorting Layer", "渲染层 ( > Z 轴 )");
                SortingLayer();
                m_Tools.TextText_OY("Mask Interaction".AddOrange(), "使用 Mask 遮罩（默认不起作用）");
            });
        }

        private void DrawTilemapRenderer()                       // TilemapRenderer 2D地图制作
        {
/*            m_Tools.ButtonText("Tilemap Renderer", "2D地图制作" + MyCreate.TODO, ref isTilemap, () =>
            {

            });*/
        }

        private void DrawBillboard()                             // BillboardRenderer 朝向摄像机
        {
            m_Tools.BiaoTi_B("Billboard Renderer" + "(就像广告牌，添加该组件就会始终朝向摄像机)".AddGreen());

            m_Tools.Text_G("可以应用的场景：");
            m_Tools.Text_G("    1.游戏角色的头顶文字，血条");
            m_Tools.Text_G("    2.场景的树，草");
            m_Tools.Text_G("    3.3d场景里的2d角色");

            MyCreate.Box(() =>
            {
                Shadows();
                DynamicOccluded();
                MotionVectors(false);
                m_Tools.TextText_OY("Billboard".AddOrange(), "如果有预先制作的广告牌资产");
                LightProbes();
                ReflectionProbeUsage(false);
            });
        }

        #endregion

        #region Old



        private void DrawBounds()                                //Bounds
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("图解", ref isTU, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711235548982-217155082.png");
                });
                m_Tools.Method_OY("center", "边框的中心点", "Vector3");
                m_Tools.Method_OY("extents", "X:中心点到 X 边框的向量，同理YZ", "Vector3");
                m_Tools.Method_OY("size", "边框大小，size = extents x 2 ", "Vector3");
                MyCreate.FenGeXian();
                m_Tools.Method_OY("Contains(Vector3 v)", "v 是否包含在边框之中", "bool");
                m_Tools.Method_OY("IntersectRay(Ray r)", "射线 r 是否与边框相交", "bool");
                m_Tools.Method_OY("Intersects(Bounds b)", "另一边框 b 是否与边框相交", "bool");

            });

        }


        private void MeshTheSame()
        {
            MyCreate.Box(() =>
            {
                LightProbes();
                ReflectionProbeUsage(false);
                m_Tools.TextText_OY("Anchor Override", "使用" + "光探针".AddWhite() + "或" + "反射探针".AddWhite() + "时的插值位置的变换");
                m_Tools.TextText_OY("Receive Shadows", "是否接收阴影");
                Shadows();
                m_Tools.TextText_OY("Motion Vectors", "运动向量", ref isMotion, () =>
                {
                    MotionVectors(false);
                });
                m_Tools.TextText_OY("Lightmap Static", "光照贴图静态");
            });

        }



        private void Color()                                     //Color 颜色 （渐变）
        {
            m_Tools.TextText_OY("Color".AddOrange(), "颜色 （渐变）" + "Shader用Spritesa或Additive".AddWhite());
        }

        private void CornerVertices()                            //Corner Vertices 拆角处 +End Cap Vertices 两端处
        {
            m_Tools.TextText_OY("Corner Vertices".AddOrange(), "拆角处".AddGreen() + "的顶点数,值越高,越圆滑");
            m_Tools.TextText_OY("End Cap Vertices".AddOrange(), "两端处".AddGreen() + "的顶点数,值越高,越圆滑");
        }


        private void Alignment()                                 //Alignment 面向相机
        {
            m_Tools.TextText_OY("Alignment".AddOrange(), "是" + "面向相机".AddGreen() + " 还是 " + "面向本地Transform".AddGreen());
        }


        private void TextureMode()                               //Texture Mode 纹理模式
        {
            m_Tools.TextText_OY("Texture Mode".AddOrange(), "纹理模式：" + "拉伸、包裹还是平铺".AddGreen() + ",与 Image 相似");
        }

        private void GenerateLightingData()                      //Generate Lighting Data
        {
            m_Tools.TextText_OY("Generate Lighting Data".AddOrange(), "勾选 " + "光照".AddGreen() + "对其会有影响");
        }


        private void Shadows()                                   //Cast Shadows 产生阴影 +Receive Shadows 是否接收阴影
        {
            m_Tools.TextText_OY("Cast Shadows", "产生阴影（无、有、双面、只有阴影）");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText("Off", "这物体不会产生阴影");
                m_Tools.TextText("On", "普通 产生阴影");
                m_Tools.TextText("TwoSided", "我能给你产生阴影，你也能在我身上产生阴影");
                m_Tools.TextText("ShadowsOnly", "物体是不可见的，这是只能产生阴影物体");
            });

            m_Tools.TextText_OY("Receive Shadows", "是否接收阴影");

        }

        private void DynamicOccluded()                           //Dynamic Occluded 是否动态遮挡剔除
        {
            m_Tools.TextText_OY("Dynamic Occluded", "是否动态" + "遮挡剔除".AddWhite() + "，不勾（静态），勾（动态）");
        }


        private void MotionVectors(bool isInRenderer)            //Motion Vectors 运动向量
        {
            m_Tools.TextText_OY("Motion Vectors", "运动向量");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("1.运动矢量从一帧到下一帧跟踪每像素对象的速度");
                m_Tools.Text_G("2.可以应用到特定的图像效果，如运动模糊或时间消除锯齿");
                if (isInRenderer)
                {
                    m_Tools.Text_G("3.面板没有的，默认 Object");
                }
                m_Tools.TextText("Camera", "仅使用相机移动来跟踪动作");
                m_Tools.TextText("Object", "此对象将呈现每个对象的运动矢量通道");
                m_Tools.TextText("ForceNoMotion", "此对象将呈现零运动");
            });

        }

        private void Materials()                                 //Materials 所有材质
        {
            m_Tools.TextText_OY("Materials", "所有材质");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_OY("material", "返回第一个Material", "Material");
                m_Tools.Method_OY("materials", "这个Renderer 的Material", "Material【】");
                m_Tools.Method_OY("sharedMaterials", "影响所有Perfab 的Material", "Material【】");
            });

        }

        private void SortingLayer()                              //Sorting Layer 渲染层
        {
            m_Tools.TextText_OY("Sorting Layer", "渲染层 ( > Z 轴 )");
            m_Tools.TextText_OY("Order In Layer ", " Z 轴不动情况下，值越大，类Z轴越大 ");
        }

        private void LightProbes()                               //Light Probes 光探针
        {
            m_Tools.TextText_OY("Light Probes", "光探针");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText("Off", "不使用任何插值光探针");
                m_Tools.TextText("Blend Probes", "使用一个内插光探针 (默认选项)");
                m_Tools.TextText("Use Proxy Volume", "使用插入光探针的3D网格");
            });
        }

        private void ReflectionProbeUsage(bool isInRenderer)     //Reflection Probes 反射探针
        {

            m_Tools.TextText_OY("Reflection Probes", "反射探针");
            MyCreate.Box_Hei(() =>
            {
                if (isInRenderer)
                {
                    m_Tools.Text_G("1.这个 Renderer 应该使用反射探针吗？");
                    m_Tools.Text_G("2.如果已启用且反射探针存在于场景中，则将为此对象选取反射纹理,");
                    m_Tools.Text_G("   并将其设置为内置着色器统一变量。表面着色器自动使用这些信息");
                    m_Tools.Text_G("3.面板没有的，默认 Off");
                    MyCreate.FenGeXian();
                }
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
        }


        #endregion



        #region Collider 碰撞体


        private void DrawCollider()                              // Collider
        {
            m_Tools.BiaoTi_Y("先说一下 花Q 的注意事项");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("两两触发的回调事件 ：","OnTriggerEnter/Stay/Exit ".AddGreen());
                m_Tools.Text_L("     • 脚本对象必须带上 Rigidbody，Collider 可在子对象");
                m_Tools.Text_L("     • Rigidbody 必须勾选 IsKinematic");
                m_Tools.Text_G("     • Collider 必须勾选 IsTrigger");
                m_Tools.Text_L("     • 被触发的 Collider 可以不勾选 IsTrigger");

            });
            AddSpace();
            m_Tools.BiaoTi_Y("Collider 与 Collision");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("Collider  ->  碰撞体");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     1. 是 BoxCollider, SphereCollider, CapsuleCollider, MeshCollider 的父类");
                    m_Tools.Text_H("     2. Collider ","继承 <- Component <- Object".AddGreen());
                    m_Tools.Text_H("     3. 使用 OnTriggerEnter/Stay/Exi 触发回调的参数是 Collider");

                });
                m_Tools.Text_B("Collision  ->  碰撞信息");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("     1. Collision ","没有继承".AddGreen(),"，简单类");
                    m_Tools.Text_H("     2. 使用 OnCollisionEnter/Stay/Exi 碰撞回调的参数是 Collision");
                });
            });
        }


        private void DrawCollision()                             // Collision
        {
            m_Tools.BiaoTi_B("碰撞信息 -> 只有属性  -> 全部只读");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("collider", "只读", "击中的对撞体", "Collider");
                m_Tools.Method_BY("contacts", "只读", "接触点集合", "ContactPoint[]");
                m_Tools.Method_BY("impulse", "只读", "总冲量", "Vector3");
                m_Tools.Method_BY("relativeVelocity", "只读", "两个碰撞对象的相对线速度", "Vector3");
                m_Tools.Method_BY("rigidbody", "只读","碰撞的刚体", "Rigidbody");
                m_Tools.Method_BY("gameObject", "只读", "碰撞的对象", "GameObject");
                m_Tools.Method_BY("transform", "只读","","Transform");
            });
        }



        private void DrawPolygon2D()                      // PolygonCollider2D
        {
            m_Tools.BiaoTi_B("PolygonCollider2D "+ "(多边形 + 碰撞体 + 2D)");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/class-PolygonCollider2D.html");
                m_Tools.Text_L("▪ 用于处理物理对象的碰撞，边缘必须是完全封闭的区域");
                m_Tools.Text_L("▪ 编辑边框：删除顶点按下 Ctrl / Cmd 键单击它即可");
                m_Tools.Text_L("▪ 想隐藏的 2D 轮廓移，只需折组件叠箭头即可");
            });

            m_Tools.BiaoTi_B("面板");
            MyCreate.Box(() =>
            {
                
                m_Tools.TextText_BL("Material", "物理材质"+"（如摩擦与弹跳）".AddLightGreen());
                m_Tools.TextText_BL("isTrigger", "true：用作触发而非用于碰撞");
                m_Tools.TextText_BL("Used By Effector", "是否被附接到执行器");
                m_Tools.TextText_BL("Used By Composite", " 需要 Composite Collider 2D 组件");
                m_Tools.TextText_BL("Auto Tiling", "自动平铺2D");
                m_Tools.TextText_BL("Offset","偏移");
                m_Tools.TextText_BL("Points","坐标");


            });
        }


        #endregion

    }
}

