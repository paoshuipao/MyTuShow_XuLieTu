/*
using System;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class MainBan_Asset : AbstactNewKuang
    {


        static void Init()
        {
            MainBan_Asset instance = GetWindow<MainBan_Asset>(false, "");
            instance.SetupWindow();
        }


        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "图片";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Testure ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Testure);
            }
            AddSpace();

            #region Model

            bool isModel = (type == EType.Model || type == EType.Model1 || type == EType.Model2 || type == EType.Model3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "模型";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Model ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Model);
            }
            if (isModel)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model1 ? "    Rig".AddBlue() : "    Rig");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model2 ? "    Animation".AddBlue() : "    Animation");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Model3 ? "    Materials".AddBlue() : "    Materials");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Model3);
                }
            }

            #endregion
            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "音频";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Audio ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Audio);
            }

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Prefab";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Prefab ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Prefab);
            }

            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Dll";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Dll ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Dll);
            }

            AddSpace();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "脚本";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Script ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Script);
            }


        }

        protected override void DrawRight()
        {
            switch (type)
            {
//                case EType.Testure:       DrawRightPage1(DrawTu);           break;
                case EType.Model:         DrawRightPage3(DrawModel);        break;
                case EType.Model1:        DrawRightPage4(DrawRig);          break;
                case EType.Model2:        DrawRightPage5(DrawAnimation);    break;
                case EType.Model3:        DrawRightPage6(DrawMaterials);    break;
                case EType.Script:        DrawRightPage7(DrawScript);       break;
                case EType.Dll:           DrawRightPage8(DrawDll);          break;
                case EType.Prefab:        DrawRightPage1(DrawPrefab);       break;
                case EType.Audio:         DrawRightPage6(DrawASMainBan);    break;

            }
        }


        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.Testure:
                    mWindowSettings.pageWidthExtraSpace.target = 18;

                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = -25;
                    break;
            }
        }


        #region 私有
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
            Testure, 
            Model, Model1, Model2, Model3,
            Script,
            Audio,
            Dll,
            Prefab,

        }

        private EType type = EType.Testure;

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
            return "Asset 的面板";
        }


        #endregion


        #region 图片
/*        private void DrawTu()                                    // 图片
        {
            TextrueType();
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
                    SpriteMode();
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

        private void SpriteMode()                                //Sprite Mode 
        {
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
        }

        private void TextrueType()                               //Textrue Type 图片类型
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

        }#1#


        #endregion






        private void DrawASMainBan()                          // 音频
        {
            m_Tools.Text_L("音频文件格式有", "aif，wav，mp3".AddGreen(), " 和", " ogg".AddGreen());
            MyCreate.AddSpace(13);
            MyCreate.Window("上方面板", () =>
            {
                m_Tools.TextText_BL("Force To Mono", OpenSure + "在打包前，强制将多声道音频混合成单声道", -55);
                m_Tools.TextText_BL("Normalize", OpenSure + "在强制单声道混音过程中，音频将被标准化", -55);
                m_Tools.TextText_BL("Load In Background", OpenSure + "加载会延迟，而不会阻塞主线程", -55);
                m_Tools.TextText_BL("Ambisonic", OpenSure + "环绕声", -55);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("环绕声 音频源在音频存储格式表示声场旋转,可以根据收听者的方位".AddHui());
                    MyCreate.Text("它被用于360度视频应用和VR。启用此项,音频文件包含音频环绕声编码".AddHui());
                });
            });
            MyCreate.AddSpace(13);
            MyCreate.Window("不同设备 选项面板", () =>
            {
                m_Tools.TextText_BY("Load Type", "", -50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("Decompress On Load", "");
                    m_Tools.TextText_WL("Compressed In Memory", "");
                    m_Tools.TextText_WL("Streaming", "");
                });
                m_Tools.TextText_BY("Preload Audio Data", OpenSure + "", -50);
                m_Tools.TextText_BY("Compression Format", "", -50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("PCM", "");
                    m_Tools.TextText_WL("ADPCM", "");
                    m_Tools.TextText_WL("Vorbis/MP3", "");
                    m_Tools.TextText_WL("HEVAG", "");
                });
                m_Tools.TextText_BY("Sample Rate Setting", "", -50);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("Preserve Sample Rate", "");
                    m_Tools.TextText_WL("Optimize Sample Rate", "");
                    m_Tools.TextText_WL("Override Sample Rate", "");

                });
            });
            MyCreate.AddSpace(13);
            MyCreate.Window("预览窗口" + "(右上包含三个 toggle 按钮)".AddGreen(), () =>
            {
                m_Tools.Text_Y("1.  " + OpenSure + " 选中后立即播放");
                m_Tools.Text_Y("2.  " + OpenSure + " 循环播放");
                m_Tools.Text_Y("3.  " + OpenSure + " 播放");
            });


        }



        private void DrawScript()                             // 脚本
        {

        }


        private void DrawDll()                                // Dll
        {

        }


        private void DrawPrefab()                             // Prefab
        {

        }


    }

}

*/
