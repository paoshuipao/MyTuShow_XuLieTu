using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor
{
    public class MainBan_Load : AbstactNewKuang
    {

        [MenuItem(LearnMenu.MainBan_Assets)]
        static void Init()
        {
            MainBan_Load Instance = GetWindow<MainBan_Load>(false, "");
            Instance.SetupWindow();
        }


        protected override void DrawLeft()
        {

            #region Texture

            bool tmpTex = (type == EType.Texture || type == EType.Texture1 || type == EType.Texture2 || type == EType.Texture3 || type == EType.Texture4 || type == EType.Texture5 || type == EType.Texture6);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Texture";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Texture ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Texture);
            }

            if (tmpTex)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture1 ? " 图片面板".AddBlue() : " 图片面板");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture2 ? " Texture2D".AddBlue() : " Texture2D");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture3 ? " MovieTexture".AddBlue() : " MovieTexture");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture4 ? " WebCamTexture".AddBlue() : " WebCamTexture");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture5 ? " RenderTexture".AddBlue() : " RenderTexture");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Texture6 ? " Sprite".AddBlue() : " Sprite");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Texture6);
                }
            }

            #endregion


            AddSpace();

            #region Model

            bool isModel = (type == EType.Model || type == EType.Model1 || type == EType.Model2 || type == EType.Model3 || type == EType.Model4);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "模型";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Model ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Model);
            }
            if (isModel)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model1 ? "面板 -> Rig".AddBlue() : "面板 -> Rig");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model2 ? "面板 -> Animation".AddBlue() : "面板 -> Animation");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model3 ? "面板 -> Materials".AddBlue() : "面板 -> Materials");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model4 ? "模型导入设置".AddBlue() : "模型导入设置");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model4);
                }
            }

            #endregion


            AddSpace();

            #region 导入设置

            bool isAssetImporter = (type == EType.Improt || type == EType.TextImp || type == EType.Improt2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "导入设置";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Improt ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Improt);
            }
            if (isAssetImporter)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.TextImp ? "修改 图片类型 例子".AddBlue() : "修改 图片类型 例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.TextImp);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Improt2 ? " TODO".AddBlue() : " TODO");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Improt2);
                }
            }

            #endregion
           

            AddSpace();

            #region 资源类型


            bool isString = (type == EType.Assets || type == EType.Assets1 || type == EType.Assets2 || type == EType.Assets3 || type == EType.Assets4 || type == EType.Assets5 || type == EType.Assets6);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "资源类型";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Assets ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Assets);
            }
            if (isString)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets1 ? " Material".AddBlue() : " Material");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets2 ? " PhysicMaterial".AddBlue() : " PhysicMaterial");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets3 ? " 预制体".AddBlue() : " 预制体");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets4 ? " scriptableobject".AddBlue() : " scriptableobject");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets5 ? " GUISkin".AddBlue() : " GUISkin");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Assets6 ? " Font".AddBlue() : " Font");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Assets6);
                }
            }
            #endregion

            AddSpace();



            #region 加载

            bool isLoad = (type == EType.Load || type == EType.AssetDatabase || type == EType.AssetD2 || type == EType.Resources);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "加载";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isLoad ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Resources);
            }
            if (isLoad)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetDatabase ? "AssetDatabase".AddBlue() : "AssetDatabase");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetDatabase);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetD2 ? "AssetDatabase 实用".AddBlue() : "AssetDatabase 实用");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetD2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Resources ? "Resources".AddBlue() : "Resources");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Resources);
                }
            }

            #endregion

            AddSpace();


            #region AssetBundle


            bool tmpAssetBundle = (type == EType.AssetBundle || type == EType.AssetBundle1 || type == EType.AssetBundle2 || type == EType.AssetBundle3 || type == EType.AssetBundle4);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "AssetBundle";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.AssetBundle ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.AssetBundle);
            }
            if (tmpAssetBundle)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetBundle1 ? "整个流程".AddBlue() : "整个流程");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetBundle1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetBundle2 ? "BuildPipeline 制作包".AddBlue() : "BuildPipeline 制作包");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetBundle2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetBundle3 ? "加载".AddBlue() : "加载");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetBundle3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.AssetBundle4 ? "其他 API".AddBlue() : "其他 API");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.AssetBundle4);
                }


            }


            #endregion


        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Texture:      DrawRightPage1(DrawTexture);       break;
                case EType.Texture1:     DrawRightPage3(DrawTuMainBan);     break;
                case EType.Texture2:     DrawRightPage5(DrawTexture2D);     break;
                case EType.Texture3:     DrawRightPage6(DrawMovieTexture);  break;
                case EType.Texture4:     DrawRightPage7(DrawWebCamTexture); break;
                case EType.Texture5:     DrawRightPage8(DrawRenderTex);     break;
                case EType.Texture6:     DrawRightPage1(DrawSprite);        break;
                case EType.Model:        DrawRightPage2(DrawModel);         break;
                case EType.Model1:       DrawRightPage3(DrawModelRig);      break;
                case EType.Model2:       DrawRightPage4(DrawModelAni);      break;
                case EType.Model3:       DrawRightPage5(DrawModelMat);      break;
                case EType.Model4:       DrawRightPage6(DrawModelImp);      break;

                case EType.Improt:       DrawRightPage4(DrawAssetImporter); break;
                case EType.TextImp:      DrawRightPage4(DrawTuImprot);      break;
                
                case EType.Assets:       DrawRightPage7(UnityAsset);        break;
                case EType.Assets1:      DrawRightPage8(DrawMaterial);      break;
                case EType.Assets2:      DrawRightPage1(DrawPhysicMat);     break;
                case EType.Assets3:      DrawRightPage3(DrawPrefab);        break;
                case EType.Assets4:      DrawRightPage4(DrawScriptableObj); break;
                case EType.Assets5:      DrawRightPage5(DrawGUISkin);       break;
                case EType.Assets6:      DrawRightPage7(DrawFont);          break;
                case EType.AssetDatabase:DrawRightPage8(DrawAssetDatabase); break;
                case EType.AssetD2:      DrawRightPage1(DrawAssetD2);       break;
                case EType.Resources:    DrawRightPage1(DrawResources);     break;
                case EType.AssetBundle:  DrawRightPage3(DrawAssetBudle);    break;
                case EType.AssetBundle1: DrawRightPage4(DrawAB);            break;
                case EType.AssetBundle2: DrawRightPage5(DrawABLoad);        break;
                case EType.AssetBundle3: DrawRightPage6(DrawBundleDown);    break;
                case EType.AssetBundle4: DrawRightPage7(DrawOther);         break;
            }
        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.TextImp:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                case EType.AssetDatabase:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
            }

        }



        #region 私有

        private bool isDaMa;
        private static readonly string StyleStr = "GUIStyle".AddWhite();
        private bool isPath, isABDes, isBuildAssetBundleOptions, isLoadAllAssets;
        private bool isAssetBundle, isFindObjectsOfTypeAll, isBuildTarget, isBuildAssetBundles, istexture;
        private bool isAssetBundleManifest, isAssetBundleBuild, isCopyAsset, isCreateFolder, isLoadAsset, isLoadAssetWithSubAssets;
        private bool isChace, isBuildPlayer, isGetAssetBundleDependencies, isGet, isRemove, isCreate;
        private bool isWWW, isLoadFromFile, isUnityWebRequest,isTextureFormat;

        private bool isGenerateMipMaps, isSRGB, isAlphaSource, isPixels, isPacking, isMesh, isTextrueType;
        private bool isAnisoLevel, isTextureShape, isNonPoweOfTwo, isReadAndWrite;

        private bool isMapping = true, isAdvanced = true;
        private MyTextrueType m_TextrueType = MyTextrueType.Default;
        private MyTextureShape m_TextureShape = MyTextureShape.纹理2D;
        private MySpriteMode m_SpriteMode = MySpriteMode.Simgle;


        enum MyTextrueType
        {
            Default,
            Sprite,
            NormalMap
        }

        enum MyTextureShape
        {
            纹理2D,
            Cube立方体
        }

        enum MySpriteMode
        {
            Simgle,
            Multiple,
            Polygon_多边形
        }



        private enum EType
        {
            Texture, Texture1,Texture2, Texture3, Texture4, Texture5, Texture6,
            Model, Model1, Model2, Model3, Model4,
            Assets,Assets1,Assets2,Assets3, Assets4,Assets5, Assets6,
            Load, AssetDatabase, AssetD2,Resources,
            AssetBundle,AssetBundle1,AssetBundle2,AssetBundle3,AssetBundle4,
            Improt, TextImp, Improt2,
        }


        private EType type = EType.Assets;

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

            return "资源 And 加载";
        }


        private void MaterialDifferent()
        {
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("Material");
                m_Tools.Text_H("1.面板是 Shader 属性面板，可以通过代码", "修改 Shader 面板不显示的属性".AddGreen());
                m_Tools.Text_H("2.是用在", " Renderer".AddGreen(), " 上，用于", "渲染的".AddGreen());
                MyCreate.Text("PhysicMaterial");
                m_Tools.Text_H("1.PhysicMaterial 是用来", "调整摩擦和碰撞对象的反弹效应".AddGreen());
                m_Tools.Text_H("2.是用在", " Collider 碰撞器".AddGreen(), " 上");
            });

        }

        private void TextureShape()                              //Texture Shape
        {
            m_TextureShape = (MyTextureShape)m_Tools.TextEnum(m_TextureShape + "  (Shape)", m_TextureShape, ref isTextureShape, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("2D纹理:", "普通用法");
                    m_Tools.TextText_OY("立方体贴图: ", "用于" + " [ Skybox ] ".AddGreen() + "或" + " [ 反射探针 ]".AddGreen());
                });
            });
            if (m_TextureShape == MyTextureShape.Cube立方体)
            {
                m_Tools.TextText("Mapping  ", "立方体贴图是" + "怎么制图".AddGreen(), ref isMapping, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText("Auto", "自动");
                        m_Tools.TextText("6 Frames Layout", "天空盒子 6张图用这");
                        m_Tools.TextText("Latitude Longitude Layout", "天空盒子 360全景图用这");
                        m_Tools.TextText("Mirrored Ball", "将纹理映射到球状立方体贴图");

                        m_Tools.Text_B("Convolution Type");
                        m_Tools.TextText("None", "默认 没有");
                        m_Tools.TextText("Diffuse", "将立方贴图用作反射探针");
                        m_Tools.TextText("Diffuse", "立方体贴图作为光探针，这很有用");
                        m_Tools.TextText("Fixup Edge Seams", "在低端平台上使用它作为过滤限制的解决方法");
                    });

                });
            }
        }

        private void NonPowerofTwo()                             //Non Power of 2
        {
            m_Tools.TextText("Non Power of 2", "图片" + "不是2的次幂".AddGreen() + "才用到", ref isNonPoweOfTwo, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("None", "就这样原图 400 -> 400   (最大)");
                    m_Tools.TextText_OY("ToNearest", "用最近的数 400 -> 512 （次之）");
                    m_Tools.TextText_OY("ToLarger", "用最大的数 400 -> 512 （次之）");
                    m_Tools.TextText_OY("ToSmaller", "用最小的数 400 -> 256 （最小）");
                });

            });
        }

        private void ReadAndWrite()                              //Read/Write Enabled是否需要动态修改
        {
            m_Tools.TextText("Read/Write Enabled", "是否需要" + "动态修改".AddGreen() + "这图片", ref isReadAndWrite, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("1.打勾 内存会存在一份这图片");
                    m_Tools.Text_Y("2.不需要动态修改一定要把它关了");
                });
            });
        }

        private void GenerateMipMaps()                           //Generate MipMaps
        {
            m_Tools.TextText("Generate MipMaps", "是否" + "生成 Mipmaps".AddGreen(), ref isGenerateMipMaps, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_O("使用生成 Mipmaps 情况：");
                    MyCreate.Text("1.这张图存储多了递归下去的分辨率（直到1x1为止）".AddYellow());
                    MyCreate.Text("2.所以这张图".AddYellow() + "占用内存多了 0.3333 倍的大小".AddGreen());
                    MyCreate.Text("3.换来的效果是图片远近使用不同的图片,不会锯齿，不会挤压".AddYellow());
                    m_Tools.Text_O("总结情况：");
                    MyCreate.Text("1.当这张图不是频繁远近的操作时".AddYellow() + "（视角基本一样）,就取消勾选".AddGreen());
                    MyCreate.Text("2.勾选了可在图的右上方".AddYellow() + "观看远近情况和增加多少内存".AddGreen());
                });

            });
        }

        private void SRGB()                                      //sRGB
        {
            m_Tools.TextText("sRGB", "如需在 " + "Shader".AddGreen() + " 上特殊取值就 " + "不勾".AddGreen(), ref isSRGB, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("1.默认勾选即可");
                    m_Tools.Text_Y("2.不勾选的情况：");
                    m_Tools.Text_Y("  Texture有特定含义的信息需要在[ Shader ]体现出来");
                });

            });
        }

        private void PackingAndPixels()                          //Packing Tag + Pixels Per Unit
        {
            m_Tools.TextText("Packing Tag", "按名称打包到Sprite图集中", ref isPacking, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("打开Sprite Packer 设置 Edit > Project Settings > Editor");
                    m_Tools.TextText_OY("Disabled", "不使用");
                    m_Tools.TextText_OY("Legacy", "旧版，但新的好像不能用");
                });

            });

            m_Tools.TextText("Pixels Per Unit", "每一个像素在空间上的大小", ref isPixels, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_O("就是这个值越小，在Game视图中越大（Scale同为1）");
                });

            });
        }

        private void MeshType()                                  //Mesh Type 图片形状类型
        {
            m_Tools.TextText("Mesh Type", "图片形状类型", ref isMesh, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("Full Rect", "完整的");
                    m_Tools.TextText_OY("Tight", "尽可能多地裁剪多余的像素");
                    m_Tools.TextText_OY("", "切割过的形状:如用过Polygon切割过");
                });

            });
        }

        private void Alpha()                                     //Alpha Source + Alpha is Transparency
        {
            m_Tools.TextText("Alpha Source", "Alpha（透明度的）来源", ref isAlphaSource, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("None", "没有alpha，即没有透明度的");
                    m_Tools.TextText_OY("Input Texture Alpha", "根据这张图片的alpha");
                    m_Tools.TextText_OY("From Gray Scale", "根据图片的RGB的平均值生成alpha值");
                });

            });
            m_Tools.TextText("Alpha is Transparency", "是否显示Alpha");
            AddSpace();
        }

        private void WrapMode()                                  //Wrap Mode
        {
            m_Tools.TextText_YG("Wrap Mode", "使用 UV 贴图时，超过原图片的（0，1）情况");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("例:用 RawImage 把UVRect X坐标调左,图片会整体向左走，剩下部分用什么填充");
                m_Tools.TextText_LW("  Repeat", "不改变图片大小," + "多张图片拼接".AddGreen() + "来铺满", -20);
                m_Tools.TextText_LW("  Clamp", "剪切，多出来的就" + "空在那".AddGreen(), -20);
                m_Tools.TextText_LW("  Mirror", "镜子，与" + " Repeat 类似".AddLightBlue() + "，不过图片是" + "反转的".AddGreen(), -20);
                m_Tools.TextText_LW("  Mirror Once", "就反转一次，其它按原来的拼接铺满", -20);
            });
        }

        private void FilterMode()                                //Filter Mode
        {
            m_Tools.TextText_YG("Filter Mode", "图显示的尺寸很大，很近相机");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("屏幕给的尺寸大于图片分辨率，这个尺寸分辨率不够用" + "(默认 Bilinear 即可)".AddLightBlue());
                m_Tools.TextText_LW("  Point(no filter)", "选择最近的" + "一个点".AddGreen() + "，会明显有锯齿", -20);
                m_Tools.TextText_LW("  Bilinear", "选择相似的" + "二个点".AddGreen() + "取他们的插值", -20);
                m_Tools.TextText_LW("  Trilinear", "选择相似的" + "三个点".AddGreen() + "取他们的插值", -20);
            });
        }

        private void AnisoLevel()                                //Aniso Level
        {
            m_Tools.TextText_YL("Aniso Level", "图显示的尺寸很小，远离相机", ref isAnisoLevel, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("以一个过小的角度观察纹理时，此数值越高观察到的纹理质量就越高");
                    m_Tools.Text_H("一般用于3D游戏或有视角缩放功能的游戏中，2D游戏一般用不到");
                });
            });
        }

        private void Compression()                               //Compression 压缩
        {
            MyCreate.Box(() =>
            {
                m_Tools.TextText_YL("Compression", "压缩(要么Normal Quality ,要么Low Quality)", -10);

                m_Tools.TextText_YL("Use Crunch Compression", "使用" + "紧缩压缩（能大幅度减小空间）".AddGreen(), -10);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("如果适用，都使用紧缩压缩[ 尽可能少的磁盘空间和下载空间 ]");
                    m_Tools.Text_H("可能需要很长时间来压缩，但在运行时解压缩速度非常快");
                    m_Tools.TextText_BL("Compressor Quality", "值越高，时间越长，纹理越大");

                });
            });

        }
        #endregion


        #region Texture

        private void DrawTexture()                             // Texture
        {

/*            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("Texture", QColors.Color.Blue, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Texture.html");
                    }
                    if (QUI.GhostButton("MovieTexture", QColors.Color.Green, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/MovieTexture.html");
                    }
                    if (QUI.GhostButton("WebCamTexture", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/WebCamTexture.html");
                    }
                    if (QUI.GhostButton("RenderTexture", QColors.Color.Purple, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://docs.unity3d.com/ScriptReference/RenderTexture.html");
                    }
                }
            });*/
            m_Tools.BiaoTi_O("结构图");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("Object-> Texture -> Texture2D、MovieTexture、WebCamTexture、RenderTexture".AddHui());
                m_Tools.TextText_LG("Texture", "都可以直接扔在 renderer.material.mainTexture = xxx", -60);
                m_Tools.TextText_LG("MovieTexture", "用于视频播放" + "（更强大的功能还是用插件好）".AddLightGreen(), -60);
                m_Tools.TextText_LG("WebCamTexture", "调用手机或电脑摄像头", -60);
                m_Tools.TextText_LG("RenderTexture", "渲染纹理，通常给 Camera 使用", -60);


            });

            m_Tools.BiaoTi_Y("父类 Texture");
            MyCreate.Box(() =>
            {
                MyCreate.Text("属性");
                m_Tools.Text_L("width", "（宽度）".AddWhite(), "、height", "（高度）".AddWhite(), "、wrapMode", "（超过原图片的（0，1）怎么填充）".AddWhite());
                m_Tools.Text_L("filterMode", "(很近相机的情况)".AddWhite(), "、anisoLevel", "(远离相机的情况)".AddWhite());

            });

            m_Tools.BiaoTi_Y("Texture ->".AddHui() + " Texture2D");
            MyCreate.Box(() =>
            {
                MyCreate.Text("Static 属性");
                m_Tools.Method_BY("blackTexture", "", "(0，0，0，0) 透明图片", "Texture2D");
                m_Tools.Method_BY("whiteTexture", "", "(1，1，1，1) 白色图片", "Texture2D");
                MyCreate.Text("属性");

                m_Tools.Method_BL("format", "只读", "格式", "TextureFormat（枚举）", ref isTextureFormat, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/TextureFormat.html");
                        MyCreate.Text("TextureFormat： 纹理使用的格式");
                        m_Tools.TextText_HL("Alpha8", "只有 透明");
                        m_Tools.TextText_HL("ARGB4444", "16 bits/像素  彩色透明纹理");
                        m_Tools.TextText_HL("RGB24", " 8-bits/每通道  彩色纹理、没透明");
                        m_Tools.TextText_HL("RGBA32", "8-bits/每通道  彩色透明纹理");
                        m_Tools.TextText_HL("ARGB32", "8-bits/每通道  彩色透明纹理");
                        m_Tools.TextText_HL("RGB565", "16 bit  彩色纹理、没透");
                        m_Tools.Text_G("太多不写了，要看 看文档");
                    });
                });
            });

            AddSpace();
            m_Tools.BiaoTi_Y("Texture ->".AddHui() + " MovieTexture" + "(把视频拖进来就是 MovieTexture 对象了)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text("Unity支持的播放视频格式有" + ".mov、.mpg、.mpeg、.mp4、.avi和.asf".AddGreen());
                    m_Tools.TextText_HG("public MovieTexture " + "movTexture".AddWhite(), "// 把视频拖进来", 30);
                    m_Tools.Text_H("void Start()");
                    m_Tools.Text_H("     GetComponent<Renderer>().material.mainTexture = ", "movTexture".AddWhite());
                    m_Tools.TextText_HG("     movTexture".AddWhite() + ".loop = true", "// 播放模式为循环", 30);
                    m_Tools.Text_H("     movTexture".AddWhite(), ".Play()");
                });
                AddSpace_3();
                MyCreate.Box(() =>
                {
                    MyCreate.Text("属性");
                    m_Tools.Method_LW("audioClip", "", "视频带的音频", "AudioClip", -30);
                    m_Tools.Method_LW("duration", "", "持续时间", "float", -30);
                    m_Tools.Method_LW("isPlaying", "", "是否已经在播放中", "bool", -30);
                    m_Tools.Method_LW("loop", "", "true：播放模式为循环", "bool", -30);
                    MyCreate.Text("方法");
                    m_Tools.Text_L("Play", "(播放)、".AddWhite(), "   Stop" + "（停止）、".AddWhite() + "   Pause" + "（暂停）".AddWhite());


                });
            });

            AddSpace();
            m_Tools.BiaoTi_Y("Texture ->".AddHui() + " WebCamTexture" + "(调用手机或电脑摄像头)".AddGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("void Start()");
                    m_Tools.Text_H("     WebCamTexture ".AddBlue(), "webCam".AddWhite(), " = new ", "WebCamTexture".AddBlue(), "()");
                    m_Tools.Text_H("     GetComponent<Renderer>().material.mainTexture = ", "webCam".AddWhite());
                    m_Tools.Text_H("     webCam".AddWhite(), ".Play()");
                    m_Tools.Text_G("把这个脚本放在 Plane 身上即可调用摄像头");
                });

                MyCreate.Text("构造函数" + "(除了无参，还可以多种带参数方式)".AddLightGreen());
                m_Tools.Text_L("new WebCamTexture()/new WebCamTexture(名称、宽度、高度)等");
                MyCreate.Text("Static 属性 " + "（因为摄像头只有一个）".AddLightGreen());
                m_Tools.Method_BY("isPlaying", "", "是否在播放中", "bool");
                m_Tools.Method_BY("requestedFPS", "", "照相机帧速率(以每秒帧数)", "float");
                m_Tools.Method_BY("devices", "", "返回可用相机设备列表", "WebCamDevice[]");
                MyCreate.Text("属性");
                m_Tools.Method_BL("videoRotationAngle", "", "角度，可用于摄像机多边形正确取向", "int");
                MyCreate.Text("方法");
                m_Tools.Text_L("Play", "(启动照相机)、".AddWhite(), "   Stop" + "（停止照相机）、".AddWhite() + "   Pause" + "（暂停照相机）".AddWhite());


            });


        }

        private void DrawTuMainBan()                          // 图片面板
        {
            m_TextrueType = (MyTextrueType)m_Tools.TextEnum_B(m_TextrueType + "  (Type)".AddLightBlue(), m_TextrueType, ref isTextrueType,
                () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text4_BW("Default", "3D 纹理", "Normalmap", "法线贴图", 40);
                        m_Tools.Text4_BW("Editor GUI", "编辑器用的 GUI 图片", "Sprite", "2D 用于 UGUI图片", 40);
                        m_Tools.Text4_BW("Cursor", "用于光标", "Cookie", "用于聚光灯", 40);
                        m_Tools.Text4_BW("Lightmap", "光照贴图", "SingleChannel", "单通道", 40);
                    });
                });
            switch (m_TextrueType)
            {
                case MyTextrueType.Default:
                    TextureShape();
                    SRGB();
                    Alpha();
                    m_Tools.BiaoTi_B("Advanced", ref isAdvanced, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            NonPowerofTwo();
                            ReadAndWrite();
                            GenerateMipMaps();
                        });
                    });
                    break;
                case MyTextrueType.Sprite:
                    m_SpriteMode = (MySpriteMode)m_Tools.TextEnum("   " + m_SpriteMode + "  (Mode)", m_SpriteMode);
                    switch (m_SpriteMode)
                    {
                        case MySpriteMode.Simgle:
                            PackingAndPixels();
                            MeshType();
                            m_Tools.TextText("Pivot", "中心点");
                            break;
                        case MySpriteMode.Multiple:
                            PackingAndPixels();
                            MeshType();
                            break;
                        case MySpriteMode.Polygon_多边形:
                            MyCreate.TextCenter("会剪切成一张需要的多边形");
                            PackingAndPixels();
                            break;
                    }
                    m_Tools.BiaoTi_B("Advanced", ref isAdvanced, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            SRGB();
                            Alpha();
                            NonPowerofTwo();
                            ReadAndWrite();
                            GenerateMipMaps();
                        });
                    });
                    break;
                case MyTextrueType.NormalMap:
                    MyCreate.TextCenter("法线贴图");
                    m_Tools.TextText("Create from Grayscale".AddLightBlue(), "是否用普通图片转化成的法线贴图");
                    break;
            }
            MyCreate.AddSpace(15);
            WrapMode();
            FilterMode();
            AnisoLevel();
            MyCreate.AddSpace();
            Compression();
        }


        private void DrawTexture2D()                             // Texture2D
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Texture2D.html");
            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Method_BY("blackTexture", "", "(0，0，0，0) 透明图片", "Texture2D", -50);
                m_Tools.Method_BY("whiteTexture", "", "(1，1，1，1) 白色图片", "Texture2D", -50);
            });
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("format", "只读", "格式", "TextureFormat（枚举）", ref isTextureFormat, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/TextureFormat.html");
                        MyCreate.Text("TextureFormat： 纹理使用的格式");
                        m_Tools.TextText_OY("Alpha8", "只有 透明");
                        m_Tools.TextText_OY("ARGB4444", "16 bits/像素  彩色透明纹理");
                        m_Tools.TextText_OY("RGB24", " 8-bits/每通道  彩色纹理、没透明");
                        m_Tools.TextText_OY("RGBA32", "8-bits/每通道  彩色透明纹理");
                        m_Tools.TextText_OY("ARGB32", "8-bits/每通道  彩色透明纹理");
                        m_Tools.TextText_OY("RGB565", "16 bit  彩色纹理、没透");
                        m_Tools.Text_G("太多不写了，要看 看文档");
                    });
                });
                m_Tools.Method_BY("mipmapCount", "只读", "mipmap 的数量", "int");
            });





            AddSpace_15();
            MyCreate.Window("构造函数", () =>
            {
                m_Tools.Text_L("public Texture2D（int", " windth".AddWhite(), "，int ", "height".AddWhite(), "，");
                m_Tools.Text_L("        TextureFormat", " format ".AddWhite(), "= TextureFormat.RGBA32，");
                m_Tools.Text_L("        bool", " mipmap".AddWhite(), " = true, bool ", "linear ".AddWhite(), "= false）");
                m_Tools.TextText_WG("windth/height", "宽度/高度", -20);
                m_Tools.TextText_WG("format/mipmap", "格式/是否使用 mipmap", -20);
                m_Tools.TextText_WG("linear", "是否线性", -20);
            });
        }

        private void DrawWebCamTexture()                         // WebCamTexture
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/WebCamTexture.html");
            m_Tools.BiaoTi_B("WebCamTexture 调用手机或电脑摄像头");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("void Start()");
                m_Tools.Text_H("     WebCamTexture ".AddBlue(), "webCam".AddWhite(), " = new ", "WebCamTexture".AddBlue(), "()");
                m_Tools.Text_H("     GetComponent<Renderer>().material.mainTexture = ", "webCam".AddWhite());
                m_Tools.Text_H("     webCam".AddWhite(), ".Play()");
                m_Tools.Text_G("把这个脚本放在 Plane 身上即可调用摄像头");
            });
            AddSpace_3();
            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Method_BY("isPlaying", "", "是否在播放中", "bool");
                m_Tools.Method_BY("requestedFPS", "", "照相机帧速率(以每秒帧数)", "float");
                m_Tools.Method_BY("devices", "", "返回可用相机设备列表", "WebCamDevice[]");
            });
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("videoRotationAngle", "", "角度，可用于摄像机多边形正确取向", "int");
            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.TextText_YH("Play", "启动照相机");
                m_Tools.TextText_YH("Stop", "停止照相机");
                m_Tools.TextText_YH("Pause", "暂停照相机");
            });

            AddSpace_15();
            MyCreate.Window("构造函数" + "(除了无参，还可以带参数)".AddGreen(), () =>
            {
                m_Tools.TextText_BL("deviceName", "使用视频输入装置的名称", -30);
                m_Tools.TextText_BL("requestedWidth", "所请求的纹理的宽度", -30);
                m_Tools.TextText_BL("requestedHeight", "所请求的纹理的高度", -30);
                m_Tools.TextText_BL("requestedFPS", "所请求的纹理的帧率  ", -30);
            });


        }

        private void DrawMovieTexture()                          // MovieTexture
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/MovieTexture.html");
            m_Tools.BiaoTi_B("MovieTexture 可用于视频播放" + "（更强大的功能还是用插件好）".AddLightGreen());

            MyCreate.Text("Unity支持的播放视频格式有" + ".mov、.mpg、.mpeg、.mp4、.avi和.asf".AddGreen());
            MyCreate.Text("把视频拖入 Project 中自动生成对应的" + " MovieTexture".AddGreen() + " 对象");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("public MovieTexture " + "movTexture".AddWhite(), "// 把视频拖进来");
                m_Tools.Text_H("void Start()");
                m_Tools.Text_H("     GetComponent<Renderer>().material.mainTexture = ", "movTexture".AddWhite());
                m_Tools.TextText_HG("     movTexture".AddWhite() + ".loop = true", "// 播放模式为循环");
                m_Tools.Text_H("     movTexture".AddWhite(), ".Play()");
            });
            AddSpace_3();
            MyCreate.MethodWindow(() =>
            {
                m_Tools.TextText_YH("Play", "播放");
                m_Tools.TextText_YH("Stop", "停止");
                m_Tools.TextText_YH("Pause", "暂停");
            });

            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BL("audioClip", "", "视频带的音频", "AudioClip", -30);
                m_Tools.Method_BL("duration", "", "持续时间", "float", -30);
                m_Tools.Method_BL("isPlaying", "", "是否已经在播放中", "bool", -30);
                m_Tools.Method_BL("isReadyToPlay", "", "返回是否足够数据来播放", "bool", -30);
                MyCreate.Box(() =>
                {
                    m_Tools.Text_W("如果是播放已下载的视频，一直返回 true");
                    m_Tools.Text_W("这是针对从网络在线看的视频，是否有缓存来播放");
                });
                m_Tools.Method_BL("loop", "", "true：播放模式为循环", "bool", -30);
            });
        }

        private void DrawRenderTex()                             // RenderTexture
        {

        }

        private void DrawSprite()                                // Sprite
        {
            m_Tools.BiaoTi_B("Static 方法 ");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YB("Create","超多参数","创建一个 对象 出来", "Sprite");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("有多个重载,必填参数以下：");
                    m_Tools.TextText_OL("    Texture2D", "那张图片");
                    m_Tools.TextText_OL("    Rect", "图片的矩形那部分" + "(0,0,长，宽)".AddGreen());
                    m_Tools.TextText_OL("    Vector2", "中心点在那 " + "new Vector2(0.5,0.5)".AddGreen());
                    m_Tools.TextText_OL("    float", "pixelsPerUnit " + " 100".AddGreen());
                    m_Tools.Text_H("可选参数");
                    m_Tools.TextText_OL("    uint", "向外扩展的数量");
                    m_Tools.TextText_OL("    SpriteMeshType", "枚举  Mesh类型");
                    m_Tools.TextText_OL("    Vector4", "边框大小");
                    m_Tools.TextText_OL("    bool", "是否生成默认的物理形状");
                });
            });


        }


        #endregion


        #region 模型
        private void DrawModel()                                 // Model
        {


        }

          
        private void DrawModelRig()                                // Model -> Rig
        {
            MyCreate.Text("Meshes" + "(网格)".AddGreen());
            m_Tools.TextText_BL("Scale", "比例因子", -80);
            m_Tools.TextText_BL("Use", OpenSure + "使用默认的文件比例", -80);
            m_Tools.TextText_BL("Mesh", "网格压缩", -80);
            m_Tools.TextText_BL("Read", OpenSure + "Mesh数据将保存在内存中，以便动态修改", -80);
            m_Tools.TextText_BL("Optimize", OpenSure + "优化网格", -80);
            m_Tools.TextText_BL("Import", OpenSure + "BlendShapes 与 Mesh 一起导入", -80);
            m_Tools.TextText_BL("Generate", OpenSure + "自动附加 Mesh Colliders", -80);
            MyCreate.Box(() =>
            {
                m_Tools.Text_W("可快速生成碰撞网格，移动的 Mesh 不要使用");
            });
            m_Tools.TextText_BL("Keep", OpenSure + "保持四边（一般都是转换为三角形，用于Shader）", -80);
            m_Tools.TextText_BL("Weld", OpenSure + "共享相同位置的顶点,可优化网格上的顶点数", -80);
            m_Tools.TextText_BL("Import", OpenSure + "导入能见度", -80);
            m_Tools.TextText_BL("Improt", OpenSure + "导入相机", -80);
            m_Tools.TextText_BL("Import", OpenSure + "导入灯光", -80);
            m_Tools.TextText_BL("Swap", OpenSure + "交换主、次UV（如果光照对象错误UV，就开启）", -80);
            m_Tools.TextText_BL("Generate", OpenSure + "创建第二个紫外通道用于光照贴图", -80);
            MyCreate.Text("Normals & Tangents" + "(法线和切线)".AddGreen());

            m_Tools.TextText_BL("Normals", "定义如何计算法线" + "（优化）".AddGreen(), -80);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Import", "(默认选项)从文件导入法线", -50);
                m_Tools.TextText_LW("Calculate", "根据平滑角度计算法线", -50);
                m_Tools.TextText_LW("None", "禁用法线", -50);
                m_Tools.Text_G("如果Mesh既不正常映射也不受实时照明的影响,使用 None");
            });
            m_Tools.TextText_BL("Tangents", "", -80);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Import", "从文件中导入切线和副法线", -50);
                m_Tools.TextText_LW("Calculate", "(默认选项)计算切线和副法线", -50);
                m_Tools.TextText_LW("None", "禁用切线和副法线,不能用于正常映射的 Shader", -50);
            });

        }

        private void DrawModelAni()                            // Model -> Animation
        {
            m_Tools.TextText_BL("Animation Type", "动画的类型", -20);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("None", "没有动画存在");
                m_Tools.TextText_LW("Legacy", "传统动画系统");
                m_Tools.TextText_LW("Generic", "通用");
                m_Tools.TextText_LW("Humanoid", "人形");
            });
            m_Tools.TextText_BL("Avatar Definition", "在哪里获得 Avatar 定义", -20);
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("Create from this model", "从这个模型创建");
                m_Tools.TextText_LW("Copy from other Avatar", "从其他 Avatar 复制");
            });
            m_Tools.TextText_BL("Optimize Game Object", "优化游戏对象", -20);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("打开时，导入角色的游戏对象变换层次结构将被删除并存储在头像和动画组件中");
                m_Tools.Text_H("角色的SkinnedMeshRenderers将直接使用Mecanim内部骨架");
                m_Tools.Text_H("该选项可改善动画角色的性能。你应该打开它的最终产品");
                m_Tools.Text_H("在优化模式下，蒙皮网格矩阵提取也是多线程的");

            });
        }


        private void DrawModelMat()                             // Model -> Materials
        {

        }


        private void DrawModelImp()                            // 模型导入设置
        { 

        }


        #endregion


        #region 导入设置


        private void DrawAssetImporter()                          // AssetImporter
        {
            m_Tools.BiaoTi_O("AssetImporter"+" (资源的进口商)");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/AssetImporter.html");
                m_Tools.Text_L("继承 Object，衍生子类有：");
                m_Tools.Text4_BL("     TextureImporter", "图片", "ModelImporter", "模型",30);
                m_Tools.Text4_BL("     AudioImporter", "音频", "VideoClipImporter", "长视频",30);
            });
            AddSpace();
            m_Tools.BiaoTi_B("Static 方法"+ "(用来获得 AssetImporter 对象)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_YW("GetAtPath", "string 路径","“Assets/xxx”的路径", "AssetImporter",-10);
            });
            AddSpace();
            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YW("assetBundleName", "", "AssetBundle 名", "string", -20);
                m_Tools.Method_YW("assetBundleVariant", "", "AssetBundle 后缀号", "string", -20);
                m_Tools.Method_YW("importSettingsMissing", "", "是否导入时没有 meta 文件", "bool",-20);
            });
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("SetAssetBundleNameAndVariant	", "string 包名，string 后缀名","","", 30);

            });

        }

        private static readonly string TextureImporterStr = "TextureImporter".AddYellow();
        private static readonly string AssetDatabaseStr = "AssetDatabase".AddBlue();
        private static readonly string importerStr = "importer".AddWhite();

        private void DrawTuImprot()                              // 图片导入设置
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/TextureImporter.html", "TextureImporter");

            m_Tools.BiaoTi_B("图片 转成 Sprite 的例子：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("// 路径  -> “Assets/xx”，可用 AssetDatabase.GetAssetPath 得到");
                m_Tools.Text_H(TextureImporterStr," importer ".AddWhite(),"= (", TextureImporterStr,")AssetImporter.GetAtPath(路径)");
                m_Tools.Text_H(importerStr,".textureType = TextureImporterType.Sprite;");
                m_Tools.Text_H(importerStr,".spritePixelsPerUnit = 1;");
                m_Tools.Text_H(importerStr,".mipmapEnabled = false;");
                m_Tools.TextText_HG(importerStr+".crunchedCompression = true;", "// 使用那个超叼压缩",120);
                m_Tools.Text_H(importerStr,".compressionQuality = 80;");
                m_Tools.TextText_HG(AssetDatabaseStr+".ImportAsset(texturePath);","// 保存", 120);
                m_Tools.Text_H(AssetDatabaseStr,".Refresh();");

            });
            AddSpace_3();
            m_Tools.BiaoTi_B("TextureImporter 属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("图片面板有什么属性，它就有什么属性");
            });
            m_Tools.BiaoTi_B("TextureImporter 方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BW("DoesSourceTextureHaveAlpha", "", "是否具有alpha通道", "bool");
            });

        }


        #endregion


        #region 资源类型


        private void UnityAsset()                                // Unity 的资源类型
        {
            m_Tools.BiaoTi_O("Unity 的资源类型");
            MyCreate.Box(() =>
            {
                MyCreate.Text("纯资源 Asset：");
                m_Tools.TextText_BL("Material", "材质" + "（附加Shader，应用于 Renderer 上）".AddGreen());
                m_Tools.TextText_BL("PhysicMaterial", "物理材质" + "（应用于 Collider 碰撞器上）".AddGreen());
                m_Tools.TextText_BL("Texture", "图片");
                m_Tools.TextText_BL("mesh", "即导进来的 Model");
                m_Tools.TextText_BL("animator", "动画");
                m_Tools.TextText_BL("shader", "着色器");
                MyCreate.Text("特殊 Asset：");
                m_Tools.TextText_LW("Perfab(预置)", "实例后成为场景中的 GameObject");
                m_Tools.TextText_LW("Scene", "场景");
                m_Tools.TextText_LW("scriptableobject", "自定义序列文件 .Asset");
                MyCreate.Text("其他 Asset：");
                m_Tools.Text_H("Font、GUISkin" + "（GUISkin 继承 scriptableobject，后缀 .guiskin）".AddGreen());
            });

            AddSpace_15();
            m_Tools.BiaoTi_O("Unity 的加载方式");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BY("AssetDatabase", "编辑器快捷加载方式，路径：" + "“Assets/myM.mat“".AddWhite(), -40);
                m_Tools.TextText_BY("Resources", "Resources 简易加载方式，路径：" + "“myM“".AddWhite(), -40);
                m_Tools.TextText_BY("AssetBundle", "打包加载方式", -40);
            });

        }

        private void DrawMaterial()                              // Material
        {
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/Material.html");
            MaterialDifferent();
            m_Tools.BiaoTi_Y("创建");
            m_Tools.Text_H("new Material(Shader.Find(\"Diffuse\"))" + "      //漫反射的Shader".AddGreen());
            m_Tools.BiaoTi_Y("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("mainTexture", "", "“sampler2D _MainTex”".AddWhite() + "   主图片", "Texture", -20);
                m_Tools.Method_BL("mainTextureOffset", "", "“sampler2D _MainTex”".AddWhite() + "  图片 Offset", "Vector2", -20);
                m_Tools.Method_BL("mainTextureScale", "", "“sampler2D _MainTex”".AddWhite() + "  图片 Tilling", "Vector2", -20);
                m_Tools.Method_BL("color", "", "“fixed4 _Color”".AddWhite() + "  颜色", " Color", -20);
            });
            m_Tools.BiaoTi_Y("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("SetColor", "string,Color", "设置 " + "fixed4 ".AddHui() + "的颜色", "", 40);
                m_Tools.Method_BL("SetFloat", "string,float", "设置 " + "float ".AddHui() + "的数值", "", 40);
                m_Tools.Method_BL("SetMatrix", "string,Matrix4x4", "设置 " + "float4x4 ".AddHui() + "的矩阵", "", 40);
                m_Tools.Method_BL("SetTexture", "string,Texture", "设置 " + "sampler2D ".AddHui() + "的图片", "", 40);
                m_Tools.Method_BL("SetTextureScale", "string,Vector2", "设置 " + "float2 ".AddHui() + "的图片 Tilling", "", 40);
                m_Tools.Method_BL("SetTextureOffset", "string,Vector2", "设置" + "float2 ".AddHui() + "的图片 Offset", "", 40);
                m_Tools.Method_BL("SetVector", "string,Vector4", "设置 " + "float4 ".AddHui(), "", 40);
            });

        }

        private void DrawPhysicMat()                        // PhysicMaterial
        {
            MaterialDifferent();
            AddSpace_3();
            m_Tools.BiaoTi_B("导入Characters包 包含以下");
            MyCreate.Box(() =>
            {
                m_Tools.Text4_BW("Bouncy", "有弹性的", "Ice", "冰", 20);
                m_Tools.Text4_BW("MaxFriction", "最大摩擦", "Metal", "金属", 20);
                m_Tools.Text4_BW("Rubber", "橡胶", "Wood", "木", 20);
                m_Tools.Text4_BW("ZeroFriction", "零摩擦", "", "", 20);
            });
            m_Tools.BiaoTi_B("面板属性");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OY("Dynamic Friction", "运行摩擦力");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("• 这个就是动摩擦力，下面是静摩擦力");
                    m_Tools.Text_H("• 静摩擦可防止静止的物体移动，需要足够大的力才将其移动");
                    m_Tools.Text_H("• 动摩擦是在移动时减慢物体的速度");
                });
                m_Tools.TextText_OY("Static Friction", "放置在表面时摩擦力");
                m_Tools.TextText_OY("Bounciness", "弹性");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("值为 0 时：表示没有反弹");
                    m_Tools.Text_H("值为 1 时：表示能量没有损失的反弹，会一直反弹");
                });
                m_Tools.TextText_OY("Friction Combine", "两个碰撞物体的摩擦力是如何结合的");
                m_Tools.TextText_OY("Bounce Combine", "两个碰撞物体的弹力是如何结合的");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HL(" Average", "两个碰撞体的弹力" + "取平均值".AddWhite(), -20);
                    m_Tools.TextText_HL(" Minimum", "两个碰撞体的弹力" + "取最小的那个".AddWhite(), -20);
                    m_Tools.TextText_HL(" Maximum", "两个碰撞体的弹力" + "取最大的那个".AddWhite(), -20);
                    m_Tools.TextText_HL(" Multiply", "两个碰撞体的弹力" + "取两个相乘".AddWhite(), -20);
                });
            });



        }

        private void DrawPrefab()                                // Prefab
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Prefab 就是 GameObject ");
                m_Tools.Text_H("注意的是 加载进来后 需要实例化 Object.Instantiate 到场景中 ");
                m_Tools.Text_H("Resources.UnloadUnusedAssets() 卸载未使用的资产");
            });
            AddSpace();
            m_Tools.BiaoTi_B("关于 Prefab 的工具类：" + " PrefabUtility".AddYellow());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/PrefabUtility.html", "详情直接看文档");
                MyCreate.Text("Static 方法");
                m_Tools.Method_BY("DisconnectPrefabInstance", "Object", "断开实例 与 Prefab 的联系", "", 50);
                m_Tools.Method_BY("GetPrefabType", "Object", "给定的对象返回其预制型", "PrefabType", 50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_LH(" None", "什么都不是", 60);
                    m_Tools.TextText_LH(" Prefab", "预制体", 60);
                    m_Tools.TextText_LH(" ModelPrefab", "导入的 3D 模型", 60);
                    m_Tools.TextText_LH(" PrefabInstance", "预制体的实例对象", 60);
                    m_Tools.TextText_LH(" ModelPrefabInstance", "导入的 3D 模型的实例对象", 60);
                    m_Tools.TextText_LH(" MissingPrefabInstance", "实例对象 但掉失预制", 60);
                    m_Tools.TextText_LH(" DisconnectedPrefabInstance", "实例对象，但该连接断开", 60);
                    m_Tools.TextText_LH(" DisconnectedModelPrefabInstance", "3D 模型的实例对象但连接断开", 60);
                });

            });


            m_Tools.BiaoTi_B("自定义脚本 Prefab 上 一个面板，在场景中实例化的显示另一个面板");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[CustomEditor(typeof(脚本))]");
                m_Tools.Text_H("public class xxx : Editor");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    public override void OnInspectorGUI()");
                m_Tools.Text_H("    {");
                m_Tools.TextText_HG("        脚本 a = (脚本) target;", "// target 系统提供的", 50);
                m_Tools.Text_H("        if( PrefabUtility.GetPrefabType(a) == PrefabType.Prefab)");
                m_Tools.Text_G("            // 在 Prefab 上的面板怎么画");
                m_Tools.TextText_HG("        else ...", "// 实例化的面板怎么画", 50);
                m_Tools.Text_H("    }");
                m_Tools.Text_H("}");

            });

        }

        private void DrawScriptableObj()                      // ScriptableObject
        {
            m_Tools.BiaoTi_B("简单快捷创建一个 ScriptableObject" + "(右键 -> Create -> 菜单名)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[CreateAssetMenu(menuName = \"Create菜单名\")]");
                m_Tools.Text_H("public class MyScriptableObject : ScriptableObject");
                m_Tools.Text_H("{");
                m_Tools.Text_H("    public int IntValue;");
                m_Tools.Text_H("}");
            });
            AddSpace();
            m_Tools.Text_B("特性".AddGreen() + " [ CreateAssetMenuAttribute ]");
            MyCreate.Box(() =>
            {
                m_Tools.Method_YL("fileName", "", "默认的文件名", "string", -50);
                m_Tools.Method_YL("menuName", "", "显示在  Assets/Create menu", "string", -50);
                m_Tools.Method_YL("order", "", "排序", "int", -50);
            });


        }

        private void DrawFont()                                  // Font
        {

            m_Tools.TextButton_Open("打开电脑的字体库", () =>
            {
                Application.OpenURL(@"C:\Windows\Fonts");
            });
            AddSpace();
            m_Tools.BiaoTi_Y("自定义字体：");


        }

        private void DrawGUISkin()                               // GUISkin
        {
            AddToggleButton("官方文档", "GUISkin", "GUIStyle",
            () =>
            {
                Application.OpenURL("https://docs.unity3d.com/ScriptReference/GUISkin.html");
            }, () =>
            {
                Application.OpenURL("https://docs.unity3d.com/ScriptReference/GUIStyle.html");
            });

            m_Tools.BiaoTi_B("结构图：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("GUISkin 其实就是 scriptableobject，而" + " scriptableobject 就是 Bean".AddGreen());
                m_Tools.Text_H("public sealed class", " GUISkin : ScriptableObject".AddWhite());
                m_Tools.Text_H("{");
                m_Tools.Text_H("     public ", StyleStr, "button { get; set; }");
                m_Tools.Text_H("     public ", StyleStr, "label { get; set; }");
                m_Tools.Text_H("     public", StyleStr, " { get; set; }");
                m_Tools.Text_H("     ....");
                m_Tools.Text_H("}");
                AddSpace_3();
                m_Tools.Text_H("public sealed class ", StyleStr);
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("     public" + " GUIStyleState ".AddLightBlue() + "normal", "// Color 字体颜色 + Texture2D 背景图", 30);
                m_Tools.Text_H("     GUIStyleState 还有: Hover、Active、OnNormal、OnHover 等");
                m_Tools.TextText_HG("     public" + " RectOffset".AddLightBlue() + " border ", "// int left、right、top、bottom", 30);
                m_Tools.Text_H("     // 其他都是枚举和基础类型");
                m_Tools.Text_H("}");


            });
            m_Tools.BiaoTi_B("提供的样式 " + StyleStr);
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("用法：", " GUILayout.XXX".AddYellow());
                m_Tools.Text_L("例如： ", "Button".AddYellow(), "   -> 使用按钮   -> ", "GUILayout.Button".AddYellow());
                m_Tools.Text_H("样式：Box、Button、Toggle、Label、TextField、TextArea");
                m_Tools.Text_H("        HorizontalSlider、HorizontalScrollbar、VerticalScrollbar 等");

            });
            m_Tools.BiaoTi_O("GUIStyle：拥有" + "(Color 字体颜色 + Texture2D 背景图 的参数)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Normal", "正常情况");
                m_Tools.TextText_BL("Hover", "鼠标悬停在控件上");
                m_Tools.TextText_BL("Active", "控件按下时");
                m_Tools.TextText_BL("Focused", "具有键盘焦点时");
                m_Tools.TextText_BL("OnNormal/OnHover/OnActive/OnFocused", "只触发一次事件");

            });
            m_Tools.BiaoTi_O("GUIStyle：拥有" + "左右上下 Left、Right、Top、Bottom 的参数".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Border", "所有背景图像的边界", -20);
                m_Tools.TextText_BL("Margin", "以此样式的元素和任何其他GUI元素之间的边距", -20);
                m_Tools.TextText_BL("Padding", "从 GUIStyle 边缘到内容开始处的空间", -20);
                m_Tools.TextText_BL("Overflow", "额外的空间被添加到背景图像", -20);
            });
            m_Tools.BiaoTi_O("GUIStyle：其他参数");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("简单：Name、Font、FontSize、FontStyle、RichText");
                m_Tools.TextText_BY("Alignment", "对准" + "(上中下、左中右)".AddGreen());
                m_Tools.TextText_BY("WordWrap", OpenSure + "文字超过宽度自动换行", -40);
                m_Tools.TextText_BY("TextClipping", "文字大于宽度的情况");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text4_HW("Overflow", "溢出就继续溢出", "Clip", "剪切掉", 20);
                });
                m_Tools.TextText_BY("ImagePosition", "图像和文本如何组合");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text4_HW("ImageLeft", "图像左侧的文本", "ImageAbove", "图像上方的文本", 20);
                    m_Tools.Text4_HW("ImageOnly", "仅在图像被显示", "TextOnly", "只有文字被显示", 20);
                });
                m_Tools.TextText_BY("ContentOffset", "内容的偏移量");
                m_Tools.TextText_BY("FixedWidth", "若非0，所有此样式的元素使用此宽度");
                m_Tools.TextText_BY("FixedHeight", "若非0，所有此样式的元素使用此高度");
                m_Tools.TextText_BY("StretchWidth", OpenSure + "水平拉伸会跟着改变，即不固定", -40);
                m_Tools.TextText_BY("StretchHeight", "竖直拉伸一般都是固定，即此项不勾");
            });


        }


        #endregion


        #region 加载

        private void DrawAssetDatabase()                         // AssetDatabase
        {
            m_Tools.BiaoTi_O("AssetDatabase（" + "“Assets/myM.mat”".AddHui() + " Assets+文件+后缀）");
            m_Tools.GuangFangWenDan("https://docs.unity3d.com/ScriptReference/AssetDatabase.html");
            MyCreate.Window("Static".AddBold() + " 方法", () =>
            {
                m_Tools.Text_G("路径 path 都为：" + "例“Assets/myM.mat”".AddHui() + "  注意后缀", ref isPath, () =>
                {
                    m_Tools.TextText_YG("   .mat", "材质");
                    m_Tools.TextText_YG("   .cubemap", "立方体贴图");
                    m_Tools.TextText_YG("   .GUISkin", "GUI皮肤");
                    m_Tools.TextText_YG("   .anim", "动画");
                    m_Tools.TextText_YG("   .asset", "用于任意其他资产");
                });
                m_Tools.BiaoTi_O("创建", true);
                m_Tools.Method_BY("CreateAsset", "Object 实例,string 路径", "在asset中创建多种类型", "", 40);
                m_Tools.Method_BY("CreateFolder", "string 路径,string 文件名", "例".AddYellow() + "（“Assets”, “MyFolder”）".AddHui(), "string", ref isCreateFolder,
                    () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_G("返回的是一串 GUID ：");
                            m_Tools.Text_H("  65401a7a4adb97144b789c9a36ee417");
                        });
                    }, 40);
                MyCreate.FenGeXian("");
                m_Tools.Method_BY("CopyAsset", "string 路径, string 新路径", "复制", "bool", ref isCopyAsset, () =>
                {
                    MyCreate.Box(() =>
                    {
                        MyCreate.Text("AssetDatabase.CopyAsset(\"Assets/TM.mat\", \"Assets/FO/TM.mat\")".AddHui());
                        m_Tools.Text_G("1.不会新创建文件夹，没有不会复制");
                        m_Tools.Text_G("2.可以复制整个文件夹");
                    });
                }, 40);
                m_Tools.Method_BY("MoveAsset", "string 路径, string 新路径", "剪切", "string", 40);
                m_Tools.BiaoTi_O("修改", true);
                m_Tools.Method_BY("Refresh", "", "刷新", "", 40);

                m_Tools.BiaoTi_O("卸载", true);
                m_Tools.Method_BY("DeleteAsset", "string 路径", "完全删除", "bool", 40);
                m_Tools.Method_BY("MoveAssetToTrash", "string 路径", "移动到垃圾桶", "bool", 40);
                m_Tools.BiaoTi_O("获取", true);
                m_Tools.Method_BY("GetAssetPath", "Object", "根据 obj 获得 路径", "string", 40);
                //                    m_Tools.Method_BY("GetSubFolders", "string 文件夹路径 有问题", "获得这文件夹下的所有子文件夹", "string[]", 40);
                m_Tools.BiaoTi_O("判断", true);
                m_Tools.Method_BY("IsValidFolder", "string 路径", "是否文件夹", "bool", 40);
                m_Tools.BiaoTi_O("针对 AssetBundle 的", ref isAssetBundle, () =>
                {
                    MyCreate.Text("获取");
                    m_Tools.Method_BY("GetAllAssetBundleNames", "", "所有包名", "string[]", 100);
                    m_Tools.Method_BY("GetAssetBundleDependencies", "string ,bool", "所有依赖项", "string[]", ref isGetAssetBundleDependencies,
                        () =>
                        {
                            m_Tools.TextText_YG("string ", "assetBundle 名称");
                            m_Tools.TextText_YG("bool ", "是否递归");
                            m_Tools.TextText_YG("返回 string[]", "这个包的所有依赖");

                        }, 100);
                    m_Tools.Method_BY("GetAssetPathsFromAssetBundle", "string", "路径", "string[]", 100);
                    m_Tools.Method_BY("GetAssetPathsFromAssetBundleAndAssetName", "string,string", "路径", "string[]", ref isGet,
                        () =>
                        {
                            MyCreate.Box(() =>
                            {
                                m_Tools.Text_G("1. 这个是根据 AssetBundle 名 + 后缀 获得路径");
                                m_Tools.Text_G("2. 上面那个只是根据 AssetBundle 名");
                            });
                        }, 100);
                    m_Tools.Method_BY("GetImplicitAssetBundleName", "string 资源路径", "资源的包名", "string", 100);
                    m_Tools.Method_BY("GetImplicitAssetBundleVariantName", "string 资源路径", "资源的V名", "string", 100);
                    m_Tools.Method_BY("GetUnusedAssetBundleNames", "", "未使用的包名称", " string[]", 100);
                    MyCreate.Text("移除");
                    m_Tools.Method_BY("RemoveAssetBundleName", "string,bool", "移除assetBundle名称", "bool", ref isRemove,
                        () =>
                        {
                            MyCreate.Box(() =>
                            {
                                m_Tools.TextText_YG("string", "要移除的assetBundle名称");
                                m_Tools.TextText_YG("bool", "true: 即使它正在使用中也移除");
                            });
                        }, 100);
                    m_Tools.Method_BY("RemoveUnusedAssetBundleNames", "", "删除未使用的包名", "", 100);
                });
            });
            AddSpace();
            AddSpace();
            MyCreate.Window("Static".AddBold() + " Event", () =>
            {
                m_Tools.Method_BY("importPackageCancelled", "", "用户" + "取消".AddGreen() + "包导入调用");
                m_Tools.Method_BY("importPackageCompleted", "", "包导入" + "成功".AddGreen() + "调用");
                m_Tools.Method_BY("importPackageFailed", "", "包导入" + "失败".AddGreen() + "时调用");
                m_Tools.Method_BY("importPackageStarted", "", "在包导入" + "开始".AddGreen() + "时就调用");
            });
        }


        private string inputTest = "EF_Manager";


        private void DrawAssetD2()                             // AssetDatabase 实用
        {

            m_Tools.BiaoTi_B("1. 根据名称找到它所在的 Asset 路径");
            MyCreate.Box(() =>
            {

                MyCreate.Heng(() =>
                {
                    m_Tools.Text_L("输入文件名：");
                    inputTest = MyCreate.InputString(inputTest);
                    AddSpace();
                    MyCreate.Button("获得 Asset 路径", () =>
                    {
                        string[] assetPathsID = AssetDatabase.FindAssets(inputTest);    // 获得的都是Id英文串
                        foreach (string id in assetPathsID)
                        {
                            string path =  AssetDatabase.GUIDToAssetPath(id);
                            MyLog.Red(path);
                        }
                    });
                });
                m_Tools.Text_L("代码",ref isDaMa, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("string[] assetPathsID = ", "AssetDatabase.FindAssets".AddYellow(), "(文件名);");
                        m_Tools.Text_H("foreach (string id in assetPathsID)");
                        m_Tools.Text_H("｛");
                        m_Tools.Text_H("    string path =  ", "AssetDatabase.GUIDToAssetPath".AddYellow(), "(id);");
                        m_Tools.Text_H("｝");
                    });

                });

            });
        }


        private void DrawResources()                             // Resources
        {
            m_Tools.BiaoTi_O("Resources" + "（API）".AddGreen() + "  “myM”".AddHui());
            m_Tools.Text_G("特性");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. Unity 会保证资源的引用计数");
                m_Tools.Text_H("2. 阻止你的资源无法被gc");
                m_Tools.Text_H("3. 难以在线更新某个资源，发布出去就不能修改");
            });
            m_Tools.Text_G("路径 path 都为：", "例“myM”".AddHui(), "   // myM 在Resources文件夹下");
            AddSpace_15();

            m_Tools.BiaoTi_B("Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_O("加载", true);
                m_Tools.Method_BY("Load", "string 文件,Type 类型", "注意 string 不要为空", "Object",20);
                m_Tools.Method_BY("LoadAll", "string 文件夹路径,Type", "文件夹下所有", "Object[]", 20);
                m_Tools.Method_BY("LoadAsync", "string,Type", "异步加载", "ResourceRequest", 20);
                m_Tools.BiaoTi_O("卸载", true);
                m_Tools.Method_BY("UnloadAsset", "Object", "obj 从内存中卸载", "void", 20);
                m_Tools.Method_BY("UnloadUnusedAssets", "", "卸载未使用的资产", "AsyncOperation", 20);
                m_Tools.BiaoTi_O("搜索", true);
                m_Tools.Method_BY("FindObjectsOfTypeAll", "Type", "返回Type类型的所有物体列表", "Object[]", ref isFindObjectsOfTypeAll, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_Y("1.这个函数可以返回加载的任何类型的Unity对象");
                        m_Tools.Text_Y("2.它将返回任何资源（网格，纹理，预设等）");
                        m_Tools.Text_Y("  或未激活的物体包括游戏对象，预制件，材质，网格，纹理等");
                        m_Tools.Text_Y("3.甚至它还会列出 Asset 中内部的东西");
                        m_Tools.Text_G("4.这个功能非常慢");
                    });
                }, 20);
            });
        }


        #endregion


        #region AssetBundle
        private void DrawAssetBudle()                            // AssetBudle API
        {
            m_Tools.BiaoTi_O("AssetBundle " + "(API)".AddGreen());
            m_Tools.Text_Y("• AssetBundle 的" + "设计原理".AddGreen(), ref isABDes, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_Y("1.资源分包：");
                    m_Tools.Text_H("    一个资源可以分到多个包里");
                    m_Tools.Text_H("    多个资源可以打进一个包");
                    m_Tools.Text_Y("2.可以实时从任意位置加载资源包");
                    m_Tools.Text_Y("3.asset 在打包时维护一个指向它所依赖的包的id");
                });
            });
            m_Tools.Text_Y("• 需要自己控制整个资源的管理 " + "加载效率稍差".AddGreen());
            m_Tools.Text_Y("• 控制整个打包和资源的管理，包括资源的" + "引用计数".AddGreen());
            m_Tools.Text_Y("• 对资源的管理更加精确，可以" + "在线更新".AddGreen() + "某个资源");

            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.Method_BY("isStreamedSceneAssetBundle", "", "是否为场景包", "bool", 20);
                m_Tools.Method_BY("mainAsset", "只读", "这个包的资源", "Object", 20);
            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.BiaoTi_O("搜索", true);
                m_Tools.Method_BY("Contains", "string", "这个包是否包含", "bool", 20);
                m_Tools.BiaoTi_O("获取", true);
                m_Tools.Method_BY("GetAllAssetNames", "", "获得所有Assets名", "string[]", 20);
                m_Tools.Method_BY("GetAllScenePaths", "", "获得所有场景路径", "string[]", 20);
                m_Tools.BiaoTi_O("读取 " + "(下载是 WWW，解包是 www.assetBundle，接着就是读取）".AddGreen(), true);
                m_Tools.Method_BY("LoadAsset", "string 名称", "把包解压单个出来", "Object", ref isLoadAsset, () =>
                {
                    m_Tools.Text_G("名称 就是预制上的名字，不需要后缀");
                    m_Tools.Method_BY("LoadAsset", "string,Type", "精确类型", "Object", 20);
                }, 20);
                m_Tools.Method_BY("LoadAssetWithSubAssets", "string", "把包解压单个所有包含子资源", "Object[]", ref isLoadAssetWithSubAssets, () =>
                {
                    m_Tools.Method_BY("LoadAssetWithSubAssets", "string,Type", "", "Object[]", 20);

                }, 20);
                m_Tools.Method_BY("LoadAllAssets", "", "把包解压所有出来", "Object[]", ref isLoadAllAssets, () =>
                {
                    m_Tools.Method_BY("LoadAllAssets", "Type", "", "Object[]", 20);
                }, 20);
                m_Tools.BiaoTi_O("异步读取", true);
                m_Tools.Method_BY("LoadAssetAsync", "string,Type", "", "AssetBundleRequest", 20);
                m_Tools.Method_BY("LoadAssetWithSubAssetsAsync", "string,Type", "", "AssetBundleRequest", 20);
                m_Tools.Method_BY("LoadAllAssetsAsync", "Type", "", "AssetBundleRequest", 20);
                m_Tools.BiaoTi_O("卸载", true);
                m_Tools.Method_BY("Unload", "bool", "true:场景的引用和包都销毁，false:只销毁包", "", -45);
            });
            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.BiaoTi_O("卸载", true);
                m_Tools.Method_BY("UnloadAllAssetBundles", "bool", "bool参数同上".AddGreen() + "，删除所有");
                m_Tools.Method_BY("GetAllLoadedAssetBundles", "", "需要获取所有当前加载的资产包列表", "AssetBundle");
                m_Tools.Method_BY("LoadFromFile", "", "从磁盘上的文件同步加载AB", "AssetBundle");
                m_Tools.Method_BY("LoadFromFileAsync", "", "异步", "AssetBundleCreateRequest");

            });
        }


        private void DrawAB()                                    // AssetBundle 整个流程
        {
            m_Tools.BiaoTi_B("AssetBundle 整个流程 "+"加载、解压、读取、卸载".AddGreen());
            ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711234000662-1536451562.png");
        }


        private void DrawABLoad()                               // 通过BuildPipeline制作包
        {
            m_Tools.BiaoTi_B("通过 " + "BuildPipeline".AddBlue() + " 制作包 "+ "“Assets/Folder”".AddHui() + " Assets+文件夹");
            AddSpace();
            AddSpace();
            MyCreate.Window("BuildPipeline Static Methods", () =>
            {
                MyCreate.Text("打包" + " （第一个是根据Editor全部打包，第二个是根据自己需要的打包）".AddYellow());
                m_Tools.Method_BY("BuildAssetBundles", "string,BuildAssetBundleOptions,BuildTarget", "", "", ref isBuildAssetBundles,
                    () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("1. Build 编辑器中指定的所有AssetBundles");
                            m_Tools.Text_G("    而下面方法是针对指定的 AssetBundles 才打包");
                            m_Tools.Text_Y("2. 第一个参数为文件夹路径，文件夹不会自动创建，不存在会报错");
                            m_Tools.Text_Y("3. 返回AssetBundleManifest，包含所有资产的列表");
                        });
                    });
                m_Tools.Method_BY("BuildAssetBundles", "AssetBundleBuild[]，其他参数与上面相同", "", "AssetBundleManifest");
                MyCreate.FenGeXian("打包场景");
                m_Tools.Method_BY("BuildPlayer", "BuildPlayerOptions", "打包场景", "string 错误消息", ref isBuildPlayer, () =>
                {
                    ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711234218217-1864792859.png");
                }, 20);


            });
            m_Tools.BiaoTi_B("BuildAssetBundleOptions " + "枚举".AddLightGreen() + "（打包的选项）".AddLightBlue(), ref isBuildAssetBundleOptions, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("None", "不需要特殊选项即可构建 assetBundle");
                    m_Tools.TextText_OY("UncompressedAssetBundle", "不要压缩数据");
                    m_Tools.TextText_OY("DisableWriteTypeTree", "不要包含类型信息");
                    m_Tools.TextText_OY("DeterministicAssetBundle", "使用散列构建资产包");
                    m_Tools.TextText_OY("ForceRebuildAssetBundle", "强制重建 assetBundles");
                    m_Tools.TextText_OY("IgnoreTypeTreeChanges", "忽略类型树更改");
                    m_Tools.TextText_OY("AppendHashToAssetBundleName", "散列追加到assetBundle名称");
                    m_Tools.TextText_OY("ChunkBasedCompression", "基于块的LZ4压缩");
                    m_Tools.TextText_OY("StrictMode", "有错误就不能构建成功");
                    m_Tools.TextText_OY("DryRunBuild", "做一个干运行版本");
                    m_Tools.TextText_OY("DisableLoadAssetByFileName", "这包禁止使用 LoadAssetByFileName");
                    m_Tools.TextText_OY("DisableLoadAssetByFileNameWithExtension", "禁用使用这个方法");
                });

            });
            m_Tools.BiaoTi_B("BuildTarget " + "枚举".AddLightGreen() + "（是应用那个设备）".AddLightBlue(), ref isBuildTarget, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_OY("Android", "");
                    m_Tools.TextText_OY("StandaloneWindows", "Windows32");
                    m_Tools.TextText_OY("StandaloneWindows64", "Windows64");
                    m_Tools.TextText_OY("iOS", "");
                    m_Tools.TextText_OY("StandaloneOSX", "英特尔64位");
                    m_Tools.TextText_OY("StandaloneLinux64", "Linux 64");
                });
            });
            m_Tools.BiaoTi_B("AssetBundleManifest" + "（所有资源的列表）".AddLightBlue(), ref isAssetBundleManifest, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.BiaoTi_O("方法", true);
                    m_Tools.Method_OY("GetAllAssetBundles", "", "所有包的名字", "string[]");
                    m_Tools.Method_OY("GetAllDependencies", "string", "根据包名获得其所有依赖", "string[]");

                });
            });
            m_Tools.BiaoTi_B("AssetBundleBuild" + "（AssetBundle的自打包构建条目）".AddLightBlue(), ref isAssetBundleBuild, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.BiaoTi_O("属性", true);
                    m_Tools.Method_OY("addressableNames", "", "加载资源的可寻址名称", "string[]");
                    m_Tools.Method_OY("assetBundleName", "", "包名称", "string");
                    m_Tools.Method_OY("assetNames", "", "要打包的集合，例如“Assets / MyPrefab.prefab”", "string[]");

                });
            });
            AddSpace();
        }


        private void DrawBundleDown()                            // AssetBundle 加载
        {
            m_Tools.BiaoTi_B("AssetBundle 加载"+ "LoadFromFile、WWW、UnityWebRequest");
            m_Tools.BiaoTi_O("LoadFromFile 从本地处加载", ref isLoadFromFile, () =>
            {
                m_Tools.Text_G(" 的 Static 方法");
                m_Tools.Method_BY("AssetBundle.LoadFromFile", "string", "文件加载", "AssetBundle");
                m_Tools.Method_BY("AssetBundle.LoadFromFileAsync", "string", "", "AssetBundleCreateRequest");
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("WWW API ", ref isWWW, () =>
            {
                MyCreate.PropertiesWindow(() =>
                {
                    MyCreate.Text("资源");
                    m_Tools.Method_BY("assetBundle", "", "解包".AddGreen(), "AssetBundle");
                    m_Tools.Method_BY("text", "只读", "如果格式不对，使用bytes", "string");
                    m_Tools.Method_BY("texture", "只读", "必须是JPG、PNG", "Texture2D", ref istexture, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("1. 建议对图像使用" + "两次幂".AddGreen() + ",任意大小也可以,但占用更多内存");
                            m_Tools.Text_Y("2. JPG文件加载到 " + "RGB24 ".AddHui() + "格式，PNG文件加载到 " + "ARGB32 ".AddHui() + "格式");
                            m_Tools.Text_Y("3. 每次调用texture属性都会分配一个新的Texture2D");
                            m_Tools.Text_Y("4. 如果" + " DXT 压缩".AddHui() + "下载的图像，改为使用 " + "LoadImageIntoTexture".AddGreen());
                        });
                    });
                    m_Tools.Method_BY("textureNonReadable", "只读", "不可修改图，减少内存", "Texture2D");
                    MyCreate.Text("数据");
                    m_Tools.Method_BY("bytes", "只读", "字节方式返回网页的内容", "byte[]");
                    m_Tools.Method_BY("bytesDownloaded", "只读", "查询下载的字节数", "int");
                    MyCreate.Text("信息");
                    m_Tools.Method_BY("error", "只读", "下载过程中发生的错误", "string");
                    m_Tools.Method_BY("isDone", "只读", "下载是否完成", "bool");
                    m_Tools.Method_BY("progress", "只读", "下载进度 0～1", "float");
                    m_Tools.Method_BY("uploadProgress", "只读", "上传进度", "float");
                    m_Tools.Method_BY("responseHeaders", "", "响应头", "Dictionary<string,string>");
                });

                MyCreate.MethodWindow(() =>
                {
                    m_Tools.Method_BY("Dispose", "", "可用于" + "中止下载".AddGreen());
                    m_Tools.Method_BY("LoadImageIntoTexture", "Texture2D", "下载图片");
                });

                MyCreate.StaticMethodWindow(() =>
                {
                    m_Tools.Method_BY("LoadFromCacheOrDownload", "string url,int AssetBundle 版本", "", "WWW", ref isChace, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.Text_Y("1.从" + "缓存中加载".AddGreen() + "具有指定版本号的AssetBundle");
                            m_Tools.Text_Y("    如果未被缓存，它将自动下载并存储在缓存中，以供将来使用");
                            m_Tools.Text_Y("2.缓存 AssetBundles 仅由" + "文件名".AddGreen() + "和" + "版本号".AddGreen() + "标识，而不是 URL 来标识");
                            m_Tools.Text_Y("    因此可以随时更改下载位置,对更新很好帮助");

                        });
                    });
                });
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("UnityWebRequest", ref isUnityWebRequest, () =>
            {
                ShowImage("https://images2018.cnblogs.com/blog/959112/201807/959112-20180711234332638-1403284966.png");
            });

        }



        private void DrawOther()                                 // 与 AssetBundle 相关其他 API
        {
            m_Tools.BiaoTi_B("Manifest"+ "AssetBundleManifest(API)、manifest文件说明");
            m_Tools.BiaoTi_O("AssetBundleManifest" + "(构建中所有AssetBundles的清单)".AddLightGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("1.通过 www 或者 LoadFromFile", "（路径到包里，不要.manifest后缀）".AddYellow(), "下载");
                m_Tools.Text_G("2.然后", "  ab.LoadAsset<AssetBundleManifest>(\"AssetBundleManifest\")".AddHui());
                MyCreate.AddSpace(15);
                MyCreate.Window("API", () =>
                {
                    m_Tools.Method_BY("GetAllAssetBundles", "", "获得所有包名", "string[]");
                    m_Tools.Method_BY("GetAllDependencies", "string", "获得这个包的所有向下依赖", "string[]");
                    m_Tools.Method_BY("GetDirectDependencies", "string", "获得这个包的向上依赖", "string[]");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("manifest文件说明");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OL("Info_1/2..", "总共有多少个包", -50);
                m_Tools.TextText_OL("Dependencies", "这个包里面有那个依赖", -50);
                MyCreate.Text("其他包：");
                m_Tools.TextText_OL("Assets", "有那个 Assets 资源集", -50);
            });


        }


        #endregion




    }

}


