using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class GongNeng_Shader : AbstactNewKuang
    {

        [MenuItem(LearnMenu.GongNeng_Shader)]
        static void Init()
        {
            GongNeng_Shader instance = GetWindow<GongNeng_Shader>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            #region 系统自带的

            bool tmpOther = (type == EType.SystemShader || type == EType.SystemShader1 || type == EType.SystemShader2 || type == EType.SystemShader3);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "系统自带的";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.SystemShader ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.SystemShader);
            }

            if (tmpOther)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.SystemShader1 ? "  Standard".AddBlue() : "  Standard");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.SystemShader1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.SystemShader2 ? "  Skybox".AddBlue() : "  Skybox");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.SystemShader2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.SystemShader3 ? "  Legacy".AddBlue() : "  Legacy");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.SystemShader3);
                }
            }

            #endregion

            AddSpace();

            #region Shader 简介与基础

            bool tmpJuChu = (type == EType.Shader || type == EType.JiChu1 || type == EType.JiChu2 || type == EType.JiChu3);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Shader 简介与基础".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Shader ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Shader);
            }

            if (tmpJuChu)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiChu1 ? "  渲染管线".AddBlue() : "  渲染管线");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiChu1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiChu2 ? "  3D 数学".AddBlue() : "  3D 数学");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiChu2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JiChu3 ? "  xxx".AddBlue() : "  xxx");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JiChu3);
                }
            }
            #endregion

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "shaderlab 结构".AddSize(16);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.XinShi ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.XinShi);
            }


            #region ㈠ 表面着色器

            bool tmpSurface = (type == EType.Surface || type == EType.Surface1 || type == EType.Surface2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "㈠ 表面着色器";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Surface ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Surface);
            }

            if (tmpSurface)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Surface1 ? "  简单例子".AddBlue() : "  简单例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Surface1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Surface2 ? "  高级一点的例子".AddBlue() : "  高级一点的例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Surface2);
                }
            }

            #endregion

            AddSpace_3();

            #region ㈡ 顶点、片段
            bool tmpVF = (type == EType.VFShader || type == EType.VFShader1 || type == EType.VFShader2 || type == EType.VFShader3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "㈡ 顶点、片段";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.VFShader ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.VFShader);
            }

            if (tmpVF)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.VFShader1 ? "  CG 语言".AddBlue() : "  CG 语言");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.VFShader1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.VFShader2 ? "  xx".AddBlue() : "  xx");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.VFShader2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.VFShader3 ? "  xxx".AddBlue() : "  xxx");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.VFShader3);
                }
            }
            #endregion

            AddSpace_3();


            #region ㈢ 固定功能

            bool tmpFix = (type == EType.FixShader || type == EType.FixShader1 || type == EType.FixShader2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "㈢ 固定功能";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.FixShader ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.FixShader);
            }

            if (tmpFix)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FixShader1 ? " 简单例子".AddBlue() : " 简单例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FixShader1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FixShader2 ? " 高级一点的例子".AddBlue() : " 高级一点的例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FixShader2);
                }
            }
            #endregion
        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.SystemShader:    DrawRightPage1(DrawSystemShader);    break;
                case EType.SystemShader1:   DrawRightPage3(DrawStandard);        break;
                case EType.SystemShader2:   DrawRightPage4(DrawSkybox);          break;
                case EType.SystemShader3:   DrawRightPage5(DrawLegacy);          break;
                case EType.Shader:          DrawRightPage6(DrawShader);          break;
                case EType.JiChu1:          DrawRightPage7(DrawXuanRan);         break;
                case EType.JiChu2:          DrawRightPage8(Draw3DMath);          break;
                case EType.JiChu3:
                    break;
                case EType.XinShi:           DrawRightPage7(DrawXingShi);        break;
                case EType.Surface:          DrawRightPage1(DrawSurfaceShader);  break;
                case EType.Surface1:         DrawRightPage(DrawSurfaceLiZi);     break;
                case EType.Surface2:         DrawRightPage(DrawSurfaceShader);   break;
                case EType.VFShader:
                    break;
                case EType.VFShader1:
                    DrawRightPage1(DrawCG);
                    break;
                case EType.VFShader2:
                    break;
                case EType.VFShader3:
                    break;
                case EType.FixShader:        DrawRightPage8(DrawFixedShader);    break;
                case EType.FixShader1:       DrawRightPage1(DrawFixedLiZi);      break;
                case EType.FixShader2:       DrawRightPage3(DrawFixedGao);       break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.VFShader1:
                    mWindowSettings.pageWidthExtraSpace.target = 35;
                    break;
                case EType.XinShi:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.SystemShader:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -10;
                    break;
            }
        }


        #region 私有
        private bool isDes1, istypedef, isJieGuo, isShuJu, isZhuZhen, isFunc, isLiZi1, isLiZi2, isNaiZhi, isDes;
        private bool isJieGouTi, isShuZu, isYuYi;
        private bool isShuoMing, isTexture,isVertexBuffer, isIndexBuffer,  isOBJ;
        private bool isShuoMing2, isColor, isVectex, isSuoYin;
        private bool isVector, isCross, isDot, isTu1, isChaZhiDianZhi, isJuZhen, isGuo;
        private bool isTu2, isMAPI, isUseMatrix4x4, is2DZhuang, is3DZhuang, isJiaoDuYuHuDu;
        private bool isDes22, isDes2, isDes3, isPinYi2D, isPinYi3D, isPosition, isJie, isSinCos;
        private bool isChaZhi = true;
        private bool isRoughness, isSpecular,isCube;
        private bool isTu, isTu00, isAl;
        private static readonly string colorStr = "颜色".AddYellow();
        private static readonly string floatStr = " + float 大小".AddGreen();
        private static readonly string TEXTURE = "图片_变量".AddLightBlue();

        private enum EType
        {
            SystemShader,SystemShader1,SystemShader2,SystemShader3,

            Shader,
            JiChu1,JiChu2,JiChu3,
            XinShi,
            Surface,Surface1,Surface2,

            VFShader, VFShader1, VFShader2, VFShader3,

            FixShader,FixShader1, FixShader2,

        }

        private EType type = EType.SystemShader;

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
            return "Shader";
        }



        private void TextKey(string str1, string str2)
        {
            m_Tools.TextText(str1.AddBlue().AddBold(), str2.AddLightBlue());

        }

        private void DiaoYong()
        {
            MyCreate.Text("调用：");
        }
        #endregion


        #region 系统Shader

        private void DrawSystemShader()                      // 系统自带的
        {

            m_Tools.BiaoTi_B("很多 Shader 都是组合而来的");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H(ONE, "[Diffuse]".AddBlue(), "  ->  漫反射  ->  ", "一张 main 图 + ".AddOrange(), colorStr);
                m_Tools.Text_H(TWO, "[Bumped]".AddBlue(), "  ->  凹凸感  ->  ", "一张法线贴图".AddOrange());
                m_Tools.Text_B(THREE + "[Roughness]" + "  ->  粗糙程度  -> ".AddHui() + colorStr + floatStr, ref isRoughness,
                    () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710102718927-609496410.png");

                    });
                m_Tools.Text_B(FOUR + "[Specular]" + "  ->  高光反射  -> ".AddHui() + colorStr + floatStr.AddYellow(), ref isSpecular,
                    () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710102826794-1463650310.png");
                    });

                m_Tools.Text_H(FIVE, "[Transparent]".AddBlue(), "  ->  透明  ->  ", "一张透明图".AddOrange());
                m_Tools.Text_H(SIX, "[VertexLit]".AddBlue(), "  ->  顶点光（没有片断函数）  -> ", "一张图".AddOrange());
                m_Tools.Text_B(SEVEN + "[特殊] ->".AddHui(), " Skybox(天空盒子)、Particles(粒子)、");
                m_Tools.Text_B(EIGHT + "[特殊] ->".AddHui(), " Unlit(不受光影响,只用颜色或贴图，性能最高，但视觉风格有所限制)");

            });

            m_Tools.BiaoTi_O("Standard " + "（标准）".AddGreen());
            MyCreate.Box(() =>
            {

                m_Tools.TextText_BY("Standard" + "(Roughness setup)".AddLightBlue() + THREE, "标准(" + "粗糙度".AddGreen() + "设置)", 50);
                m_Tools.TextText_BY("Standard" + "(Specular setup)" + FOUR.AddLightBlue(), "标准(" + "高光反射".AddGreen() + "设置)", 50);
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("FX/Flare " + "（特效/闪烁）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("1.整体是 高亮、发光的感觉    2.一直显示在前端，即使前面有障碍物也会显示");
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Mobile " + "（手机用的【消耗性能低】）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Bumped Diffuse" + ONE + TWO, "凹凸感（法线贴图）+漫反射", 50);
                m_Tools.TextText_BL("Bumped Specular" + ONE + FOUR, "凹凸感（法线贴图）+ 高光（镜面）", 50);
                m_Tools.TextText_BL("Diffuse" + ONE, "漫反射", 50);
                m_Tools.TextText_BL("Particles" + SEVEN, "粒子系统用的", 50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text4_HW("Additive", "叠加上去", "Alpha Blended", "与 Alpha 透明度混合");
                    m_Tools.Text4_HW("Multiply", "相乘上去", "VertexLit Blended" + SIX, "与 顶点光 混合");
                });
                m_Tools.TextText_BL("Skybox" + SEVEN, "天空盒子", 50);
                m_Tools.TextText_BL("Unlit" + "(Supports Lightmap)".AddLightBlue() + EIGHT, "不受光影响（支持光照贴图）", 50);
                m_Tools.TextText_BL("VertexLit" + SIX, "顶点光", 50);
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("Unlit " + EIGHT + "（不受光影响）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text4_HW("Color", "只用颜色", "Texture", "只用一张图片");
                m_Tools.Text4_HW("Transparent", "只用一张透明图片", "Transparent Cutout", "透明图片 + 剪切程度");
            });
            AddSpace_3();
            m_Tools.BiaoTi_L("团里还用不上的 Shader ");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OG("Nature", "大自然、树、地形等");
                m_Tools.TextText_OG("AR、VR", "AR、VR 用的");
                m_Tools.TextText_OG("GUI/Text Shader", "GUI 文字用");
                m_Tools.TextText_OG("UI、Sprites", "可能用在 UGUI、Sprite 身上的吧");
            });

        }


        private void DrawStandard()                          // Standard
        {
            m_Tools.BiaoTi_Y("Main Maps (主 Maps)");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OL("Albedo", "物体表面基本颜色，表面散射的颜色", -5);
                m_Tools.TextText_OL("Metallic", "金属感".AddGreen() + "，金属一般超过90%，非金属20%以下", -5);
                m_Tools.TextText_OL("Smoothness", "光滑感".AddGreen(), -5);
                m_Tools.TextText_OL("Normal map", "法线贴图（" + "明暗凹凸感".AddGreen() + "）", -5);
                m_Tools.TextText_OL("Height map", "视差贴图（" + "高低感".AddGreen() + "）", -5);
                m_Tools.TextText_OL("Occlusion", "环境遮挡(加一张贴图)", -5);
                m_Tools.TextText_OL("Detail mask", "详细的遮挡(加一张贴图)", -5);
                m_Tools.TextText_OL("Emission", "可当做发光体", -5);
            });

            m_Tools.BiaoTi_Y("Secondary Maps (次要 Maps)");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OL("Detail Albedo", "详情反照率", -5);
                m_Tools.TextText_OL("Normal map", "法线贴图", -5);
            });

            m_Tools.BiaoTi_Y("Forward Rendering Options (前项渲染选项)");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OL("Specular Highlights", "镜面高光", -5);
                m_Tools.TextText_OL("Reflections", "反射", -5);
                m_Tools.BiaoTi_Y("Advanced Options (高级选项)");
                m_Tools.TextText_OL("Enable GPU Instanc", "启用GPU实例", -5);
            });

        }


        private void DrawSkybox()                            //Skybox 天空盒子用的
        {
            m_Tools.BiaoTi_L("共有属性 (程序Skybox 没有 Rotation)");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Exposure(曝光程度)", "0为全黑，值越高越光亮");
                m_Tools.TextText_BY("Rotation(转动)", "只有左右旋转");
            });
            m_Tools.BiaoTi_B("6 Sided "+"（6张图）".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("图片使用"," Default ".AddGreen(),"即可，但是","名字要统一".AddGreen(),"（不然不好拖动）");
                MyCreate.Heng(() =>
                {
                    MyCreate.SelectText("XXX_0_Front+Z", 200);
                    MyCreate.SelectText("XXX_1_Back-Z", 200);
                });
                MyCreate.Heng(() =>
                {
                    MyCreate.SelectText("XXX_2_Left+X", 200);
                    MyCreate.SelectText("XXX_3_Right-X", 200);
                });
                MyCreate.Heng(() =>
                {
                    MyCreate.SelectText("XXX_4_Up+Y", 200);
                    MyCreate.SelectText("XXX_5_Down-Y", 200);
                });

            });
            m_Tools.BiaoTi_B("Cubemap " + "（一张立方体贴图/全景图）".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("图片使用"+"Default -> "+"Cube".AddGreen()+" -> 立方体贴图");

                m_Tools.Text_L("图片详细设置图：",ref isCube, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180703164352025-1806044071.png");
                });


            });
            m_Tools.BiaoTi_B("Procedural " + "（用程序或者直接面板调控）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Sun","");
                m_Tools.TextText_BL("Sun Size","");
                m_Tools.TextText_BL("Sun Size Convergen","");
                m_Tools.TextText_BL("Atmosphere Thickness","");
                m_Tools.TextText_BL("Sky Tint","");
                m_Tools.TextText_BL("Ground","");
            });

            AddSpace();
            m_Tools.BiaoTi_L("Moble 的 Skybox 设置");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("只有 ","6张图".AddGreen()," 的设置，且","没有 Exposure、Rotation".AddGreen());

            });
        }


        private void DrawLegacy()                            // Legacy
        {

            m_Tools.BiaoTi_B("Legacy Shader （传统Shader）");
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/shader-NormalFamily.html", "详细并带图");
            m_Tools.Text_G("Diffuse -> 漫反射（太阳光+环境光）");
            m_Tools.TextText_OL("Bumped Diffuse", "凹凸感（法线贴图）+漫反射", -40);
            m_Tools.TextText_OL("Bumped Specular", "凹凸感（法线贴图）+ 高光（镜面）", -40);
            m_Tools.TextText_OL("Decal", "漫反射 + 加一层贴图（占主要）", -40);
            m_Tools.TextText_OL("Diffuse", "漫反射", -40);
            m_Tools.TextText_OL("Diffuse Detail", "漫反射 + 加一层贴图", -40);
            m_Tools.TextText_OL("Diffuse Fast", "漫反射（优化，消耗少）", -40);
            m_Tools.TextText_OL("Lightmapped", "支持光照贴图相关的", -40);
            m_Tools.TextText_OL("Parallax ", "+法线贴图（明暗感）+视差贴图（高低感）", -40);
            m_Tools.TextText_OL("Reflective", "与反射相关的（反射周围物体）", -40);
            m_Tools.TextText_OL("Self-Illumin", "自发光相关的", -40);
            m_Tools.TextText_OL("Specular", "高光", -40);
            m_Tools.TextText_OL("Transparent", "透明贴图相关的", -40);
            m_Tools.TextText_OL("VertexLit", "顶点光（没有片断函数）", -40);
        }


        #endregion


        #region Shader 简介与基础

        private void DrawShader()                            //Shader 简介与基础
        {
            m_Tools.BiaoTi_O("GPU 与 CPU 的优越性");
            MyCreate.Box(() =>
            {
                MyCreate.Text("优");
                m_Tools.Text_L("GPU 具有高并行结构");
                m_Tools.Text_L("    -> 所有GPU在处理图形数据和复杂算法方法面拥有比 CPU 理高的效率");
                m_Tools.Text_L("GPU 采用流式并行计算模式");
                m_Tools.Text_L("    -> 对每个数据进行独立的并行计算（即同时处理 n 个顶点）");
                MyCreate.Text("缺");
                m_Tools.Text_L("相对 CPU 缺少强大的逻辑能力");
            });
            AddSpace();
            m_Tools.BiaoTi_O("Shader "+"(可编程图形管线的算法片段)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("用于告诉图形硬件如何计算和输出图像");
                m_Tools.Text_W("它主要分为两类 ：Vertex Shader 和 Fragment Shader");
            });
            AddSpace();

            m_Tools.BiaoTi_O("图片、Shader、Material");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("图片".AddBlue(),"  ->  布料");
                m_Tools.Text_L("Shader".AddBlue(), "  -> 将布料、颜色、光照等进行加工的程序");
                m_Tools.Text_L("Material ".AddBlue(), " ->  Shader 加工完成的 成品");
            });

        }


        private void DrawXuanRan()                         // 渲染管线
        {
            m_Tools.BiaoTi_O("渲染管线 " + "(把它理解为：渲染流水线)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("建车厂流水线生产车 ：装躯干 -> 装车盒 -> 装轮胎 -> 上油漆");
                m_Tools.Text_H("渲染流水线也一样：按照固定的一条线来工作");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180703194102696-1618324478.png");
            });

            m_Tools.Text_G("概述", ref isShuoMing, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("渲染管线就是如何让这张2D图像看上去是3D物体");
                    m_Tools.Text_B("视觉系统的特性：");
                    m_Tools.Text("    1.平行线汇集成一个点");
                    m_Tools.Text("    2.物体的大小会随着距离增加而减小，越远的物体看起来越小");
                    m_Tools.Text("    3.物体会有重叠");
                    m_Tools.Text("    ");
                });
            });

            m_Tools.Text_G("我的总结", ref isShuoMing2, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("1.每个模型有很多个顶点（Bean），顶点包含空间坐标、自身信息等");
                    m_Tools.Text_B("2.索引顺序就是根据顶点画三角形，" + "想渲染那部分就取那部分的索引".AddGreen());
                    m_Tools.Text_B("3.实现移动、旋转、缩放就是 " + "顶点乘以对应的矩形".AddGreen());

                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("计算机基本颜色", ref isColor, () =>
            {
                m_Tools.Text_W("RGB  " + "Red  ".AddRed() + "Green  ".AddGreen() + "Blue".AddBlue() + "  三种颜色加起来就是白色");
                MyCreate.Box(() =>
                {
                    m_Tools.Text("1.通常用 8 位数表示一个颜色分量，即 0 到 255");
                    m_Tools.Text("2.三个颜色组合(255x255x255)约1600万色(支持1600万像素就这意思)");
                    m_Tools.Text("3.程序用 0 到 1 表示颜色分量，只要除以 255 即可");
                    m_Tools.Text("4.加入 Alpha " + "透明度".AddGreen() + "，为 " + "RGBA".AddWhite() + "这就是常说的 " + "32位色".AddGreen());

                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("输入阶段 顶点和顶点缓冲区", ref isVectex, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("顶点: 是由空间位置和多种属性组成的" + " (就是个Bean)".AddGreen());
                    m_Tools.Text("    例如：这个Bean包含了空间位置、平面的法线、自定义数据");
                    m_Tools.Text("    当GUP处理时，就可以使用平面的法线、自定义数据");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("顶点封装 " + "(怎么定义这个Bean) :".AddGreen());
                    m_Tools.Text("    struct Vectex {");
                    m_Tools.TextText_LG("            Vector3D Position;", "//空间坐标");
                    m_Tools.TextText_LG("            Vector3D Normal;", "//法线");
                    m_Tools.TextText_LG("            Vector3D Color; } ", "//颜色");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("顶点缓冲区 (VertexBuffer)", ref isVertexBuffer, () =>
                    {
                        m_Tools.Text("1.为了能够让GDP能够访问 Bean 数组");
                        m_Tools.Text("2.必须将顶点数据放置到顶点缓冲区的容器中");
                        m_Tools.Text("3.创建或申请顶点缓冲区，然后上传顶点数据" + " (这些都封装好了)".AddGreen());
                    });
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("输入阶段 索引和索引缓冲区", ref isSuoYin, () =>
            {
                MyCreate.TextCenter("这个是解决:".AddWhite() + " 根据顶点怎么画三角形 （v0 v1 v2）");
                MyCreate.Box(() =>
                {
                    m_Tools.Text("1.索引顺序不同，构成的三角形不同");
                    m_Tools.Text("2.DX 默认顺时针，OpenGL 默认逆时针");
                    m_Tools.Text("3.索引是简整数、某些低端设备只支持65535个索引数据");
                    m_Tools.Text("4.渲染整个模型就是从 0 开始到模型索引的数据长度");
                    m_Tools.Text("5.渲染这个模型的一部分就是单独用这部分的索引（例如背面剔除）");
                });
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("索引缓冲区 (IndexBuffer)", ref isIndexBuffer, () =>
                    {
                        m_Tools.Text("1.与顶点缓冲区类似");
                        m_Tools.Text("2.合并索引缓冲区，一般用于静态的物体，只需要计算一次");
                    });
                });
            });
            AddSpace_3();
            #region OBJ模型解析


            m_Tools.BiaoTi_O("OBJ模型解析", ref isOBJ, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("OBJ文件的特点：");
                    m_Tools.Text("    1.OBJ文件是一种3D模型文件，不包含动画、材质特性、粒子等信息");
                    m_Tools.Text("    2.OBJ文件主要支持多边形(Polygons)模型");
                    m_Tools.Text("    3.OBJ文件支持法线和贴图(UV)坐标");
                });

                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("OBJ文件的基本结构：");
                    m_Tools.Text("    1.开头用注释 " + "# 文件信息".AddGreen());
                    m_Tools.Text("    2.关键字 XXX (关键字说明这一行是什么数据)");
                });

                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("关键字：");
                    MyCreate.Box(() =>
                    {
                        m_Tools.BiaoTi_O("顶点数据(Vertex data):");
                        TextKey("v", "几何体顶点(Geometric vertices)");
                        TextKey("vt", "贴图坐标点(Texture vertices)");
                        TextKey("vn", "顶点法线(Vertex normals)");

                        m_Tools.BiaoTi_O("元素(Elements):");
                        TextKey("p", "点(Point)");
                        TextKey("l", "线(Line)");
                        TextKey("f", "面(Face)");
                        TextKey("curv", "曲线(Curve)");
                        TextKey("curv2 2D", "曲线(Curve)");
                        TextKey("surf", "表面(Surface)");

                        m_Tools.BiaoTi_O("组(Grouping):");
                        TextKey("g", "组名称(Group name)");
                        TextKey("s", "光滑组(Smoothing group)");
                        TextKey("mg", "合并组(Merging group)");
                        TextKey("o", "对象名称(Object name)");
                        m_Tools.BiaoTi_O("显示(Display)/渲染属性(render attributes):");
                        TextKey("usemtl", "材质名称(Material name)");
                        TextKey("mtllib", "材质库(Material library)");
                    });
                });
            });
            #endregion

            MyCreate.AddSpace(20);
            MyCreate.TextCenter("3D纹理映射".AddBold());
            m_Tools.Text_G("纹理概述、纹理坐标", ref isTexture, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("纹理概述:");
                    m_Tools.Text("     1.纹理用来存储图像数据，每个纹理元素中存储一个像素颜色");
                    m_Tools.Text("     2.纹理分为：1D纹理、2D纹理、3D纹理（类似1、2、3维数组）");

                });

                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("纹理坐标UV:");
                    m_Tools.Text("1.就是这张图中的xy轴的坐标,不同的是只有0到1");
                    m_Tools.Text("2.RawImage中的UVRect,以图片的左下为原点，xy为坐标");
                });

            });
        }



        private void Draw3DMath()                           // 3D mathr
        {
            m_Tools.BiaoTi_O("坐标系");
            m_Tools.Text_B("模型坐标 -> 世界坐标 -> 摄像机坐标 -> 屏幕投影坐标       " + "// 简称 MVP".AddGreen(), ref isPosition, () =>
            {
                m_Tools.Text_Y("1.in float4 v ：POSITION  ，进来的就是模型坐标");
                m_Tools.Text_Y("2.float4 -> float4 -> float4 -> float4 用的就是矩阵");
                m_Tools.Text_O("3.屏幕投影坐标float4（x,y,z,w） -> 真正屏幕坐标(x/w,y/w),w其实是 z/距离");

            });
            AddSpace_3();

            #region 向量

            m_Tools.BiaoTi_O("向量");
            m_Tools.Text_B("向量的定义" + " (有大小，有方向)".AddGreen() + "  (只有大小叫标量)".AddWhite(), ref isVector, () =>
            {
                MyCreate.Box(() =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710092351796-117375090.png");
                });

            });
            AddSpace_3();
            m_Tools.Text_B("向量的叉积 " + "(" + "Cross".AddYellow() + ") 就是垂直于两个向量的向量".AddGreen() + " (应用法线)".AddWhite(), ref isCross, () =>
            {
                m_Tools.Text_W(" （ 法线 ：垂直这个平面的向量 【可通过两个向量的叉积计算出来】 ）");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("定义：1.叉积向量　" + "方向".AddGreen() + "：垂直".AddGreen() + "原来的两个向量");
                    m_Tools.Text_Y("          2.叉积向量　" + "大小".AddGreen() + "：原来的两个向量的" + "大小相乘再乘以 sin 角度".AddGreen());
                    m_Tools.Text_Y("          3.使用 Vector3.Cross 如图下");
                    m_Tools.Text_G("图解", ref isChaZhi, () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710092453160-1752391237.png");
                    });

                });
            });

            AddSpace_3();
            m_Tools.Text_B("向量的点积 " + "(" + "Dot".AddYellow() + ")  两向量同方向为正，异方向为负".AddGreen(), ref isDot, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("计算方法： 两 x 相乘+两 y 相乘+两 z 相乘");
                    m_Tools.Text_G("重要性质：");
                    m_Tools.Text("    1.点积 = 0，两向量互相垂直");
                    m_Tools.Text("    2.点积 > 0，两向量夹角小于90度");
                    m_Tools.Text("    3.点积 < 0，两向量夹角大于90度");
                    m_Tools.Text_G("两个向量是统一化情况下：");
                    m_Tools.Text_B("    1.同向为正");
                    m_Tools.Text_B("    2.异向为负");
                    m_Tools.Text_B("    3.同方向最大 为 1");
                    m_Tools.Text_B("    4.异方向最小 为 -1");
                    m_Tools.Text_G("点积图解", ref isTu1, () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710092617456-1989215513.png");
                    });
                });

            });
            AddSpace_3();
            m_Tools.Text_B("向量叉积、点积应用于光照例子  " + "(光的方向要相反)".AddGreen(), ref isChaZhiDianZhi, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710092731721-897973156.png");
            });
            AddSpace_3();
            m_Tools.Text_B("向量 Vector3 " + "API".AddGreen() + "  (x,y,z)既可以代表是点，也可以向量".AddWhite());


            #endregion

            #region 矩形
            m_Tools.BiaoTi_O("矩阵");
            m_Tools.Text_B("矩阵的定义、矩阵的运算、单位矩阵、转置矩阵、逆矩阵、方阵", ref isJuZhen, () =>
            {

                MyCreate.Box(() =>
                {
                    m_Tools.Text("矩阵的定义、矩阵的运算", ref isDes22, () =>
                    {
                        ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710094342595-2084610554.png");
                        m_Tools.Text_Y(" 两矩阵是否相等 ：两矩阵相同行列才能比较，" + "全部元素相同".AddGreen() + "就相等");
                        m_Tools.Text_Y(" 两矩阵相加减    ：两矩阵相同行列才能加减，" + "对应元素相加减".AddGreen() + "得出");
                        m_Tools.Text_Y(" 矩阵乘以float    ：这个矩阵" + "每个元素都乘以这个 float数值".AddGreen());
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("两矩阵相相乘   ：" + "假设 " + "A[M][N] ,B[N][P]".AddOrange());
                            m_Tools.Text_G("    1.条件：" + "A 列 = B 行".AddOrange() + " （判断：先 Shu 后Heng）");
                            m_Tools.Text_G("    2.结果：" + "C[M][P]".AddOrange());
                            m_Tools.Text_G("    3.过程：" + " （计算：框 Heng 框 Shu）", ref isGuo, () =>
                            {
                                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710094437318-735422032.png");
                            });
                        });
                    });
                    AddSpace_3();
                    m_Tools.Text("单位矩阵", ref isDes2, () =>
                    {
                        m_Tools.Text_Y("1.正方形矩阵，行列相等");
                        m_Tools.Text_Y("2.对角线元素为1，其它元素全为0");
                        m_Tools.Text_Y("3.矩阵A * 单位矩阵 =矩阵 A ，相当于数字1");
                    });
                    AddSpace_3();
                    m_Tools.Text("转置矩阵", ref isDes3, () =>
                    {
                        m_Tools.Text_Y("1.转置矩阵就是 把这个矩阵的" + "行向量".AddGreen() + "变成" + "列向量".AddGreen() + "得到的矩阵");
                        m_Tools.Text_Y("2.转置矩阵相乘： A * B =（B(转置) * A(转置)）（转置）");
                        m_Tools.Text_G("转置图解", ref isTu2, () =>
                        {
                            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710094829522-250499103.png");
                        });
                    });
                    AddSpace_3();


                    m_Tools.BiaoTi_B("逆矩阵、逆运算");
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text("1.只有正方形矩阵（行列相等）才能做逆运算");
                        m_Tools.Text("2.一个 nxn 的矩阵的逆矩阵仍然是一个 nxn 矩阵");
                        m_Tools.Text("3.不是所有的矩阵都有逆矩阵，有逆矩阵的矩阵为可逆");
                        m_Tools.Text("4.如果有可逆矩阵，那么这个逆矩阵一定是唯一");
                        m_Tools.Text("5.将一个矩阵与它的逆矩阵相乘，结果一定为单位矩阵");
                        m_Tools.Text_G("就是乘以个可逆矩阵，可以撤销回原来的");
                    });

                    m_Tools.BiaoTi_B("方阵：行与列相同的矩阵");

                });
            });
            AddSpace_3();
            m_Tools.Text_B("矩阵 Matrix4x4 " + "API".AddGreen(), ref isMAPI, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_B("使用 Matrix4x4", ref isUseMatrix4x4, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("1.矩阵方法：" + "Vector4 target= m.转换方法（Vector3 position）".AddWhite());
                            m_Tools.Text_Y("2.得到的 Vector4 ：");
                            m_Tools.Text_G("        （x,y,z,0）用于描述方向，没有大小");
                            m_Tools.Text_G("        （x,y,z,1）用于描述点");
                        });

                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_BL("Matrix4x4.Rotate", "创建一个旋转矩阵");
                            m_Tools.TextText_BL("Matrix4x4.Scale", "创建一个缩放矩阵");
                            m_Tools.TextText_BL("Matrix4x4.Translate", "创建一个移动矩阵");
                            m_Tools.TextText_BL("Matrix4x4.TRS", "创建一个位置，旋转和缩放的矩阵,多转换用这更省性能");
                        });


                    });
                    m_Tools.Text("Unity 使用的是4x4矩阵,描述变换操作基本步骤为：");
                    m_Tools.Text("1.先设置一个4x4矩阵M，使用矩阵M来描述一个特定的变换。");
                    m_Tools.Text("2.然后将一个点或者向量的坐标放置到1x4行向量v中。");
                    m_Tools.Text("3.通过向量矩阵乘积 v*M=w，w就是经过矩阵M变换之后的新的点或者向量");
                });

            });
            AddSpace_3();
            m_Tools.Text_B("我对矩阵Matrix4x4的理解", ref isJie, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_LG("float4x4 m=", "");
                    m_Tools.TextText_LG("{", "");
                    m_Tools.TextText_LG("   float4(x轴，0，0，0)", "// 想要x轴不变 就为1");
                    m_Tools.TextText_LG("   float4(0，y轴，0，0)", "// 想要y轴不变 就为1");
                    m_Tools.TextText_LG("   float4(0，0，z轴，0)", "// 想要z轴不变 就为1");
                    m_Tools.TextText_LG("   float4(0，0，0，1)", "1对点，0对方向");
                    m_Tools.TextText_LG("}", "");

                });

            });
            #endregion

            #region 矩形与转换

            m_Tools.BiaoTi_O("矩形与转换");
            m_Tools.Text_B("2D 旋转矩阵", ref is2DZhuang, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710095105400-1656937821.png");
            });
            m_Tools.Text_B("2D 平移", ref isPinYi2D, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710095248537-1038993088.png");
            });
            m_Tools.Text_B("3D 旋转矩阵", ref is3DZhuang, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710095354829-1877783771.png");
            });

            m_Tools.Text_B("3D 平移矩阵", ref isPinYi3D, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710095718233-1914180839.png");
            });

            #endregion

            #region 角度与弧度

            m_Tools.BiaoTi_O("角度与弧度", ref isJiaoDuYuHuDu, () =>
            {
                m_Tools.Text_Y("角度 = 180/π 乘以 弧度    [ 0 ,360 ]");
                m_Tools.Text_Y("弧度 = π/180 乘以 弧度    [ 0, 2π ]");
                m_Tools.Text_G("Shader 角度转弧度：radians");
                m_Tools.Text_G("Shader 弧度转角度：degrees");
                m_Tools.Text_G("Unity ：弧度 = 角度 * Mathf.Deg2Rad");
                m_Tools.Text_G("Unity : 角度 = 弧度 * Mathf.Rad2Deg");

            });

            #endregion

            #region Sin 与 Cos 图
            m_Tools.BiaoTi_O("Sin 与 Cos 图", ref isSinCos, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710101206041-83973511.png");
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180710101232498-1321534629.png");

            });
            #endregion
        }


        #endregion

        private void DrawXingShi()                          // shaderlab 结构
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/SL-Reference.html","Unity Shader指引");

            m_Tools.BiaoTi_B("shader 可以使用下面三种不同方式编写 " + TWO);
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("1. surface shaders ","(Unity 在 ".AddGreen(),"2"," 的基础上封装好的 表面 Shader)".AddGreen());
                m_Tools.Text_B("2. vertex and fragment shaders ", "(顶点 和 片段 Shader)".AddGreen());
                m_Tools.Text_B("3.  fixed function shaders ", "(固定功能 Shader，能力有限)".AddGreen());

            });

            AddSpace_3();
            m_Tools.BiaoTi_O("但是无论是选择哪一种方式，实际 Shader 都需要"+ "遵循以下 shaderlab 结构".AddYellow());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("Shader ”Custom/MyShader“");
                m_Tools.Text_H("{");
                m_Tools.Text_L("    Properties "+ONE);
                m_Tools.Text_H("    {");
                m_Tools.Text_H("         _MyTexture (”MyTexture“, 2D) = ”white“ { }");
                m_Tools.Text_Y("         // 其他属性如颜色或矢量也会在这里");
                m_Tools.Text_H("    }");
                m_Tools.Text_L("    SubShader " + TWO);
                m_Tools.Text_H("    {");
                m_Tools.Text_Y("         // 这里就是主要编写的地方"+"（使用上面三种形式的其中一种）".AddGreen());
                m_Tools.Text_H("    }");
                m_Tools.TextText_LG("    SubShader", "// 一个 SubShader 或者有多个 SubShader");
                m_Tools.Text_H("    {");
                m_Tools.Text_Y("         // 更简单的 SubShader 版本（在较旧的显卡运行），上面不通过就到这个");
                m_Tools.Text_H("    }");
                m_Tools.TextText_LG("    FallBack ”Diffuse“ " + THREE, "// 上面 SubShader 全部不能用时就回滚使用系统的");
                m_Tools.Text_H("}");
            });
            AddSpace_3();

            m_Tools.BiaoTi_B("Properties 属性 " + ONE);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_B("变量（”面板显示“，类型） = 默认值");
                m_Tools.Text_L("    _Color (”颜色“, Color) = (1,1,1,1)");
                m_Tools.Text_L("    _Float (”浮点值“, Range(0,1)) = 0.5");
                m_Tools.Text_L("    _MyTexture (”主图片“, 2D) = ”white“ { }");
                    
            });
            AddSpace_3();

            m_Tools.BiaoTi_B("FallBack 回滚到可用的 Shader " + THREE);
            MyCreate.Box(() =>
            {
                m_Tools.SelectTextText_W("Unlit","不受光影响，只用颜色或贴图");
                m_Tools.SelectTextText_W("VertextLit","顶点光照");
                m_Tools.SelectTextText_W("Diffuse","漫反射");
                m_Tools.SelectTextText_W("Normal mapped","法线贴图");
                m_Tools.SelectTextText_W("Specular","高光");

            });


        }



        #region SurfaceShader


        private void DrawSurfaceShader()
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/Manual/SL-SurfaceShaders.html");


        }


        private void DrawSurfaceLiZi()
        {
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180704112816181-1836318526.png");
            AddSpace();
            MyCreate.FenGeXian();
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180704114745869-833760249.png");

        }

        #endregion



        private void DrawCG()                                    // CG语言
        {

            #region 基本数据类型
            m_Tools.BiaoTi_O("基本数据类型 " + "（fixed、half、float、bool、sampler）".AddYellow(), ref isShuJu, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("fixed ", "// [ -2 , 2 ] ,通常用作颜色或单位向量的类型");
                    m_Tools.TextText_BG("half ", "// 16位浮点数，比float范围低一半，尽量用它不用float");
                    m_Tools.TextText_BG("float ", "// 32位浮点数");
                    m_Tools.Text_Y("这3种基本数值类型 组成 vector 或 matrix：");
                    m_Tools.Text_Y("1.向量（ vector ）：比如" + " half3 是由3个 half 组成", ref isDes1, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_W("     " + "float2 fl2=float(1,0);".AddWhite());
                            m_Tools.Text("1.  " + "float4 fl4=float(1,0,1,4);".AddWhite());
                            m_Tools.TextText_LG("   2.  " + "float4 fl4=float( f2.xy,1,4);".AddWhite(), "// 顺序就是： xyzw / rgba");
                            m_Tools.TextText_LG("   3  " + "float4 fl4=float( f2.xyxx);".AddWhite(), "  // 取fl2的 (1,0,1,1)");
                            m_Tools.TextText_LG("   4  " + "float4 fl4=float( f2.gggr);".AddWhite(), "  // 取fl2的 (0,0,0,1)");

                        });
                    });
                    m_Tools.Text_Y("2.矩阵（ matrix ）：比如 " + "float4x4 是由16个 float 组成", ref isZhuZhen, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_LG("float2x4 M24={ (1,0,1,1) ,(0,1,1,1)};", "  // 大括号｛ ｝");
                            m_Tools.TextText_LG("float4 f4 =M24[ 0 ]", "// 用法与数组相同");
                        });
                    });
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BG("bool", "// 用法与 C// 一样，同样可以用" + " true ? 真：假".AddWhite());
                        m_Tools.TextText_BG("sampler", "// 给图片定义的  " + "sampler2D 就是纹理2D".AddWhite());

                    });



                    m_Tools.BiaoTi_O("数组  " + "( float m[4] )".AddYellow(), ref isShuZu, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_B("float m[4]");
                            m_Tools.Text_B("half a[2]");
                            m_Tools.Text_B("float3 v[12]");
                        });

                    });
                });
            });


            MyCreate.AddSpace(10);
            #endregion

            #region 结构体

            m_Tools.BiaoTi_O("结构体  " + "( struct )".AddYellow(), ref isJieGouTi, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Heng(() =>
                    {
                        m_Tools.Text_G("// 可以放在 include “xxx.cginc” 类库文件上");
                        MyCreate.AddSpace();
                        MyCreate.FenGeXian("打开Unity定义的 in 结构体", () =>
                        {
                            //                            MySystem.DoubleClickFile(MyPath.CGIncludesPath + "/UnityCG.cginc");
                        });
                    });
                    m_Tools.Text_G("// 可指定语义 " + "(要不全是 out,要不全是 in)".AddWhite());
                    m_Tools.Text_B("struct v2f");
                    m_Tools.Text_B("{");
                    m_Tools.TextText_BG("       float4 pos : POSITION", "  // 相当于 out float4 pos:POSITION");
                    m_Tools.TextText_BG("       float2 objPos ：TEXCOORD0", "// 相当于 out float2 objPos ：TEXCOORD0");
                    m_Tools.TextText_BG("};", "// 这里居然要逗号 ");
                    DiaoYong();
                    m_Tools.Text_B("v2f vert(in float2 xx:POSITION)");
                    m_Tools.Text_B("{");
                    m_Tools.Text_B("       v2f o;");
                    m_Tools.Text_B("       o.pos = float4( xxx );");
                    m_Tools.Text_B("       o.objPos = float4( xxx );");
                    m_Tools.TextText_BG("       return o;", "// 一次 out 结构体中的所有");
                    m_Tools.Text_B("}");
                });

            });

            #endregion

            MyCreate.AddSpace(10);

            #region typedef 、#define
            m_Tools.BiaoTi_O("typedef " + "(给基本类型改个自己定义的名)".AddGreen() + "、#define " + "(相当于 全局 const)".AddGreen(), ref istypedef, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_WG("#define DINGYIN float4(1,0,1,1);", "  // 在全局中定义一个常量");
                    m_Tools.TextText_WG("typedef float4 FL4;", "           // 定义一个FL4 的类型");
                    DiaoYong();
                    m_Tools.TextText_WG("FL4 f=DINGYIN", "           // 相当于 float4 f=float4(1,0,1,1)");
                });

            });
            MyCreate.AddSpace(10);

            #endregion

            #region 方法
            m_Tools.BiaoTi_O("方法与 c 相同，只能由上往下走" + "（上面没定义，下面报错）".AddGreen() + "+ (制作CG类库)".AddYellow(), ref isFunc, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("1.要不把方法定义在" + "最上面".AddYellow());
                    m_Tools.Text_G("2.要不在最上面加个 " + "void 方法名();".AddWhite());
                    m_Tools.Text_G("3.要引起引用值改变，一样可以加上个 " + "out".AddYellow());
                    m_Tools.Text_G("4.传递数组必须声明长度");
                    m_Tools.Text("使用 out 方法例子：", ref isLiZi1, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_WG("void Function1( out float4 c )", "  // 加out 传递值改变");
                            m_Tools.Text_W("{");
                            m_Tools.Text_W("        c=float4(0,1,0,1);");
                            m_Tools.Text_W("}");
                            DiaoYong();
                            m_Tools.TextText_WG("Function1(col);", "// 不需要加上 out");
                        });
                    });

                    m_Tools.Text("传递数组 方法例子：", ref isLiZi2, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_WG("float Function2(float arr[2])", "  // 数组后面要加上长度");
                            m_Tools.Text_W("{");
                            m_Tools.Text_W("        float value=0;");
                            m_Tools.Text_W("        for(int i=0;i<arr.Length;i++)");
                            m_Tools.Text_W("        {");
                            m_Tools.Text_W("             value+=arr[i];");
                            m_Tools.Text_W("        ｝");
                            m_Tools.Text_W("        return value;");
                            m_Tools.Text_W("}");
                            DiaoYong();
                            m_Tools.TextText_WG("float arr[2]={0.5,0.5};", "// 先定义数组，以 c 方式定义（后面带 [ ]）");
                            m_Tools.TextText_WG("col.r=Function1(arr);", "// 赋值带数组的方法必须先赋值");
                        });

                    });

                    MyCreate.FenGeXian("制作CG类库".AddYellow());
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_B("1.定义一个 " + ".cginc".AddYellow() + "文件，把方法复制粘贴上去");
                        MyCreate.Heng(() =>
                        {
                            m_Tools.Text_B("2.把文件放到" + " .../CGIncludes".AddYellow() + " 文件夹下");
                            MyCreate.AddSpace();
                            MyCreate.Button("打开 ", () =>
                            {
                                //                                MySystem.OpenFloder(MyPath.CGIncludesPath);

                            });
                        });
                        m_Tools.TextText_BG("  3.在开头声明" + " //include“ MyCG/Function.cginc”".AddYellow(), "    // 以 CGIncludes 为根路径");
                    });

                });

            });

            MyCreate.AddSpace(10);
            #endregion

            #region 语义
            m_Tools.BiaoTi_O("语义 " + "（强转）".AddYellow(), ref isYuYi, () =>
            {
                MyCreate.Box(() =>
                {

                    m_Tools.Text_B("1.out int 只能有一个强转类型");
                    m_Tools.Text_B("2.如 POSITION 强转成顶点坐标，给顶点用或者顶点输入进来");
                    m_Tools.Text_B("3.如果想自己的顶点函数传给片断函数用，用 TEXCOORD");
                    MyCreate.SelectText("POSITION");
                    MyCreate.SelectText("TANGENT");
                    MyCreate.SelectText("NORMAL");
                    MyCreate.SelectText("TEXCOORD0  TEXCOORD1  TEXCOORD2  TEXCOORD3");
                    MyCreate.SelectText("COLOR");
                });

            });

            MyCreate.AddSpace(10);
            #endregion

            #region CG内建函数
            m_Tools.BiaoTi_O("内置函数", ref isNaiZhi, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BG("sin( 弧度 )", "// sin弧度 = 正弦值 ");
                    m_Tools.TextText_BG("asin( 正弦值 )", "// asin正弦值 = 弧度" + "([-π/2, π/2])".AddWhite());
                    m_Tools.TextText_BG("cos( 弧度 )", "// cos弧度 = 余弦值");
                    m_Tools.TextText_BG("acos( 余弦值 )", "// acos余弦值 = 弧度" + "（[0,π]）".AddWhite());
                    m_Tools.TextText_BG("tan( 弧度 )", "// tan弧度 = 正切值 ");
                    m_Tools.TextText_BG("atan( 正切值 )", "// atan正切值 = 弧度" + "([-π/2, π/2])".AddWhite());
                    m_Tools.TextText_BG("atan2( y,x )", "// 计算y/x 的反正切值");
                    m_Tools.TextText_BG("tanh( x )", "// 双曲正切值");
                    //                    MyCreate.FenGeXian_Long();
                    m_Tools.TextText_BG("ceil( x )", "// 向上取整," + "如 ceil（1.3）返回 2.0".AddWhite());
                    m_Tools.TextText_BG("floor( x )", "// 向下取整," + "如 floor（1.3）返回 1.0".AddWhite());
                    m_Tools.TextText_BG("frac( x )", "// 返回小数部分，即x - floor(x);");
                    m_Tools.TextText_BG("abs( x )", "// 绝对值");
                    m_Tools.TextText_BG("pow( b,n )", "// 返回 b 的 n 次方");
                    m_Tools.TextText_BG("clamp( x,min,max)", "// 将x收缩至min与max之间");
                    m_Tools.TextText_BG("distance( u,v )", "// u 和 v 之间的距离");
                    m_Tools.TextText_BG("length( x )", "// 返回 x 的长度");
                    m_Tools.TextText_BG("lerp( u,v,t )", "// 根据参数 t 在 u 和 v 之间线性插值【0，1】");
                    m_Tools.TextText_BG("log10( x )", "// 计算 log10的值，x 必须大于0");
                    m_Tools.TextText_BG("max( x,y )", "// 最大");
                    m_Tools.TextText_BG("min( x,y )", "// 最小");
                    m_Tools.TextText_BG("normalize( v )", "// 规范化");
                    m_Tools.TextText_BG("sqrt( x )", "// x 的开方");
                    m_Tools.TextText_BG("round( x )", "// 四舍五入");
                    m_Tools.TextText_BG("transpose( x )", "// 转置矩阵");
                    m_Tools.TextText_BG("log( x )", "// 计算ln(x)的值，x必须大于 0");

                });
            });


            MyCreate.Box(() =>
            {
                m_Tools.TextText_BG("saturate( x )", "// clamp( x, 0 ,1) 限定在【 0 , 1 】");
                m_Tools.TextText_BG("cross( u,v )", "// 返回 u 和 v 的叉积");
                m_Tools.TextText_BG("dot( u,v )", "// u 和 v 的点积");
                m_Tools.TextText_BG("degrees( x )", "// 弧度转角度");
                m_Tools.TextText_BG("radians( x )", "// 角度转弧度");
                m_Tools.TextText_BG("fmod( x ,y )", "// x/y的余数");


                m_Tools.TextText_BG("mul( M,N )", "// 矩阵相乘");
                m_Tools.TextText_BG("UnityObjectToClipPos( v )", "// 输入顶点到屏幕坐标" + "mul（UNITY_MATRIX_MVP，v)".AddWhite());
                m_Tools.TextText_BG("reflect( v,n )", "// 根据入射向量 v 和法线 n 计算反射向量");
                m_Tools.TextText_BG("refract( v,n,eta )", "// 入射向量 v 、法线 n 、折射指数 eta");

                //                MyCreate.FenGeXian_Long();
                m_Tools.TextText_BG("tex2D(sampler2D tex, float2 s)", "// 二维纹理查询    " + "fixed4".AddWhite());
                m_Tools.TextText_BG("tex2D(sampler2D,float2,float2,float2)", "// 后面两参数可作模糊左右上下的偏移");
                m_Tools.TextText_BG("texCUBE(samplerCUBE tex, float3 s)", "// 查询立方体纹理");

            });
            #endregion
            MyCreate.AddSpace();

            #region  注意
            m_Tools.Text_G("注意", ref isDes, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text("1.循环和判断语句与 C# 一样，但应该" + "避免使用".AddGreen());
                    m_Tools.Text("2.因为 if else 语句 不管对错都会预执行," + "单用 if ".AddGreen());
                    m_Tools.Text("3.while 和 for 更不好，每个顶点运行一次，n个顶点几何爆增");
                    m_Tools.Text_B("函数：");
                    m_Tools.Text_B("1.函数语法与 C# 一样");
                    m_Tools.Text_B("2.参数为值传递");
                    m_Tools.Text_B("3.不支持递归");

                });
            });
            #endregion
        }




        #region 固定功能

        private void DrawFixedShader()                      // 固定功能
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("SubShader");
                m_Tools.Text_H("{");
                m_Tools.TextText_LG("    pass {  命令/命令块  }", "// 无分号，命令相当于方法，不需声明变量");
                m_Tools.Text_H("}");
            });

            AddSpace_3();
            m_Tools.BiaoTi_B("命令");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW("color(1,1,1,1)", "小括号 -> 固定颜色 -> 即现在是 全白");
                m_Tools.TextText_BW("color[变量]" + ONE, "中括号 -> 使用面板的颜色");
            });
            m_Tools.BiaoTi_B("命令块");
            MyCreate.Box(() =>
            {
                
            });
        }


        private void DrawFixedLiZi()
        {
            m_Tools.BiaoTi_B("最简单的使用  color[变量] 命令"+ONE);
            MyCreate.Box(() =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180704094339736-2062961673.png");
            });
        }


        private void DrawFixedGao()
        {
            m_Tools.BiaoTi_B("贴图 " + "使用 " + "SetTexture".AddYellow() + " 命令块", ref isTu, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("SetTexture[ " + TEXTURE + " ]");
                    m_Tools.Text_W("{");
                    m_Tools.Text_G("    //Combine texture         // 这时就可以显示图片");
                    m_Tools.TextText_WG("", "//  但是上面的material不起作用");
                    m_Tools.TextText_WG("     Combine texture * primary double", "    // primary 上面 material的颜色值");
                    m_Tools.Text_G("// double 乘以2倍，提高亮度 (primary 乘以4倍)".PadLeft(75));
                    m_Tools.Text_W("}");
                });
            });

            m_Tools.BiaoTi_B("两张贴图", ref isTu00, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("SetTexture[ " + TEXTURE + " ]");
                    m_Tools.Text_W("{");
                    m_Tools.Text_W("     Combine texture * primary double");
                    m_Tools.Text_W("}");

                    m_Tools.Text_W("SetTexture[ " + TEXTURE + "2 ]");
                    m_Tools.Text_W("{");
                    m_Tools.Text_W("     Combine texture * previous double");
                    m_Tools.Text_W("}");
                    m_Tools.Text_G("// primary 指 material 和 Lighting 的值 ，previous 指当前所有的值");
                });

            });
            m_Tools.BiaoTi_B("使用透明", ref isAl, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("Tags{\" Queue \"=\" Transparent \"}");
                    m_Tools.Text_W("SubShader");
                    m_Tools.Text_W("{");
                    m_Tools.Text_W("      pass");
                    m_Tools.Text_W("      {");
                    m_Tools.Text_W("            Blend SrcAlpha OneMinusSrcAlpha");
                    m_Tools.Text_W("            Material { ... }");
                    m_Tools.Text_W("            SetTexture { ... }");

                    m_Tools.Text_W("      }");
                    m_Tools.Text_W("}");
                });
            });


        }


        #endregion

    }

}

