using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using Sirenix.OdinInspector;

namespace UnityEditor
{
    public class Game_YouHua : AbstractChooseKuang<Game_YouHua>              //优化
    {


        [MenuItem(LearnMenu.ZhiShi_YouHua)]

        public static void ShowWindow()
        {

            CreateWindow("优化", 460, 550);
        }


        protected override void OnEditorGUI()
        {
            switch (_FenLie)
            {
                case YHType.性能优化:
                    DrawWhat();
                    break;
                case YHType.脚本:
                    DrawYouHua();
                    break;
                case YHType.图形与物理:
                    DrawTu();
                    break;
                case YHType.文件:
                    DrawWenJian();
                    break;
                case YHType.相机:
                    DrawCamera();
                    break;
            }


            MyCreate.AddSpace();
        }



        private void DrawWhat()                                  // 什么是性能优化
        {
            MyCreate.Window("常见的优化类型", () =>
            {
                m_Tools.TextText_YG("1. 性能优化", " 是否吃内存、吃显卡、吃硬盘", -50);
                m_Tools.TextText_YL("2. 流程优化", "（如之前点击十次才通过，现点击2次即可）", -50);
                m_Tools.TextText_YL("3. 体验优化", "（如角色跑步不协调）", -50);
            });
            AddSpace_15();
            MyCreate.Window("性能优化的目标", () =>
            {
                m_Tools.Text_Y("♦ 游戏流畅运行");
                m_Tools.Text_B("    1. 多种帧数标准", "（通常 PC 60帧，移动 30帧）".AddGreen());
                m_Tools.Text_G("        （当然不同游戏、不同机型对帧数的需求也不同）");
                m_Tools.Text_B("    2. 避免卡顿");
                AddSpace_3();
                m_Tools.Text_Y("♦ 游戏符合市场需要");
                m_Tools.Text_B("    1. 硬件兼容性            2. 安装包/数据包大小");
            });

            AddSpace_15();
            MyCreate.Window("原则："+"（用户不察觉，即可优化）".AddWhite(), () =>
            {
                m_Tools.Text_W("玩家不一定能发现欠优化的地方，可优化"+ "(如故意降低画质)".AddGreen());
                m_Tools.Text_W("玩家不一定能发现欠佳的地方，可优化" + "(如远处用小图)".AddGreen());
            });
            AddSpace_15();
            MyCreate.Window("优化常见的误区", () =>
            {
                m_Tools.Text_Y("误区1. 我的游戏很简单不需要优化");
                m_Tools.Text_L("    （任何游戏都需要一定的优化）");
                AddSpace_3();
                m_Tools.Text_Y("误区2. 优化工作太早进行");
                m_Tools.Text_L("    （游戏没成型之前，任何优化工作成效不大）");
                AddSpace_3();
                m_Tools.Text_Y("误区3. 性能优化 = Debug");
                m_Tools.Text_L("    （报错、逻辑错误不等于性能优化）");
                m_Tools.Text_L("    （性能优化要在没有错误的前提下才开始）");
            });


        }



        private void DrawYouHua()                                // 脚本优化
        {
            m_Tools.TextButton_Open("使用 " + "Profile ".AddWhite() + "评估工具", MainBan_LiZi.Init);
            AddSpace();
            m_Tools.Text_B("● 常规循环 ", "（Update/FixedUpdate/LateUpdate）".AddWhite());
            AddSpace_3();
            m_Tools.Text_B("● 变量的隐性调用");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("    go.transform = go.GetComponnent<Transform>()");
                m_Tools.Text_H("    （上面是等价的，而搜索总是会消耗一定性能的）");

            });
            AddSpace_3();
            m_Tools.Text_B("● GameObject.Find", "（场景GameObject越多，耗时越大）".AddGreen());
            AddSpace_3();
            m_Tools.Text_B("● 多线程/协程 " , "-> IO操作，下载".AddGreen());
            AddSpace_3();
            m_Tools.Text_B("● 合理降低数学精度");
            MyCreate.Box(() =>
            {
                MyCreate.Text("比如：计算距离（ A ->目标点向量，B ->目标点向量）");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG(" Vector3.SqrMagnitude()", "//   x²+y²+z²");
                    m_Tools.Text_H("      ↓ 可以代替就代替");
                    m_Tools.TextText_HG(" Vector3.Magnitude()", "//  √根号 x²+y²+z²");
                });
                MyCreate.Text("比如：计算方向" + "（使用点积而不直接求出角度）".AddGreen());
                MyCreate.Text("比如：技能范围（如不需要太精确，也可减少精度）");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("多边形的技能范围", " 改成-> ".AddLightGreen(), "单一三角形范围");
                    m_Tools.Text_H("Boss 不规则技能推进 ", "改成->".AddLightGreen(), " 使用一个Box碰撞盒推进过去");
                });
            });
            AddSpace_3();
            m_Tools.Text_B("● Object Pool " , "（避免对象的重复产生与销毁）".AddLightGreen());
            AddSpace_3();
            m_Tools.Text_B("● Total 与 Self 的总消耗时间","(从 Profiler 观察得到)".AddGreen());

        }



        private void DrawTu()                                    // 图形与物理
        {
            m_Tools.BiaoTi_B("♦ 美术资源"+"（Mesh/Material/Shader/粒子）");
            MyCreate.AddSpace(12);
            MyCreate.Window("Mesh", () =>
            {
                MyCreate.Text("Statistics面板看：Tris 面数" + "(移动 推荐60K↓)".AddGreen() + "     Verts 顶点数");
                m_Tools.Text_Y("LOD ".AddRed(), "技术：模型离相机 ", "近中远 ".AddGreen(), "分别使用不同面数的模型");
                m_Tools.Text_L("    1. 美术来创造，然后使用 ", "LOD Group".AddWhite(), " 组件");
                m_Tools.Text_L("    2. 通过程序自动生成", "(插件全自动完全： Simple LOD)".AddRed());
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("Material", () =>
            {
                MyCreate.Text("Statistics面板看：SetPass Calls " + "不同材质越少，该值越少".AddWhite() + "(移动60↓)".AddGreen());
                m_Tools.Text_Y("1. 图片标记 Pcking Tag，使用 Sprite Packer");
                m_Tools.Text_Y("2. 尽量引用同一 Material");
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("Shader", () =>
            {
                m_Tools.Text_L("1. 尽量小引用图/使用Moblie Shader");
                m_Tools.Text_H("2. 插件： Shader Forge （图形化编辑，如不需要直接删除）");
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("粒子", () =>
            {
                m_Tools.Text_Y("数量、透明", "（能停止就不要全透明隐藏那种）".AddGreen(), "、材质");
            });

            AddSpace();
            m_Tools.BiaoTi_B("♦ 物理效果（镜头、光照、碰撞、CheckList）");
            MyCreate.AddSpace(12);
            MyCreate.Window("镜头" + "(Camera看不到就剔除)".AddGreen(), () =>
            {
                m_Tools.Text_L("1. Camera 范围不必要就减小");
                m_Tools.Text_L("2. Camera 上的 ", "Occlusion Culling".AddWhite(), "（操作与导航相同）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("◘ 把静态的物体标记成", " Occluder Static".AddWhite());
                    m_Tools.Text_H("◘ 打开 Window -> Lighting -> Bake 烘焙");
                });
            });

            MyCreate.AddSpace(12);
            MyCreate.Window("光照" + "（Bake And Probes）", () =>
            {
                m_Tools.Text_L("1. 减少实时光");
                m_Tools.Text_L("2. 光源选择 Baked 烘焙光", "（同样操作与导航相同）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("◘ 把静态的物体标记成", " Lightmap Static".AddWhite());
                });
                m_Tools.Text_H("    缺点：增加文件大小、不能照射动态的物体", "（所以用到第3点）".AddLightGreen());

                m_Tools.Text_L("3. 使用Light Probo Group", "（放球球）".AddLightGreen());
            });

            MyCreate.AddSpace(12);
            MyCreate.Window("碰撞", () =>
            {
                m_Tools.Text_L("1. 尽可能用Box/Sphere/Capsule Collider 代替 Mesh Collider");
                m_Tools.Text_L("2. 控制 rigidbody 刚体数量");
            });
            MyCreate.AddSpace(12);
            MyCreate.Window("CheckList 官方提供的优化列表", () =>
            {
                m_Tools.TextUrl("Simple checklist to make your game faster  ( 打开官方文档 )", "https://docs.unity3d.com/Manual/OptimizingGraphicsPerformance.html");
            });

        }

        private void DrawWenJian()                               // 文件
        {

            m_Tools.BiaoTi_B("■ 安装包/资源包的优化");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. 打开 Editor Log 查看资源总大小", "(搜索 Complete size)".AddLightGreen());
                m_Tools.Text_H("2. 媒体文件:");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("♦ 压缩图片、压缩网格与动画", "（Mesh/Anim Compression）".AddLightGreen());
                    m_Tools.Text_H("♦ 音频：ogg > mp3 > wav");
                    m_Tools.Text_H("♦ 共用 animationclip");

                });
                m_Tools.Text_H("3. 能用 AssetBundle 代替 Resource 就代替");

                MyCreate.Text("Player Settings 中的设置");
                m_Tools.Text_H("4. ApiCompatibillyLevel ->", " NET 2.0 Subset".AddGreen());
                m_Tools.Text_H("Android：5. Device Filter 选择", " ARM".AddGreen(), "， 不选择x86");
                m_Tools.Text_H("Android：6. " + "Stripping Level".AddBlue() + " 一层层的拿掉东西，默认关闭", ref _isStripping, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.Text_L("这个就是一层一层的剥掉东西，最上是关闭，最下是剥掉很多东西");
                        m_Tools.Text_L("推荐使用第 3 层 Scrip Byte Code");
                        m_Tools.Text_L("如果崩溃了就使用上一层");
                        m_Tools.Text_G("大概就是十几 M，不过放在现在也问题不大");
                    });
                });
            });
            AddSpace_15();
            m_Tools.BiaoTi_B("■ 工作流程的优化");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("推荐 Debug 插件：", "SRDebugger".AddRed());
                m_Tools.Text_H("    即使在真机也有一个一模一样的 Console 甚至可以调试");
                MyCreate.AddSpace(13);
                MyCreate.Window("建立一套优化方法", () =>
                {
                    m_Tools.Text_L("1. 确定优化目标：帧数");
                    m_Tools.Text_L("2. 选择合适的工具：Profiler、SRDebugger");
                    m_Tools.Text_L("3. 找到性能瓶颈：脚本/图形/文件");
                    m_Tools.Text_L("4. 无法解决：找手册、问Google、线开、与团队沟通");
                });
            });

        }

        private void DrawCamera()                               //  相机
        {
            m_Tools.Text_Y("1. 视椎体越小越好 注意远裁剪面");

        }

        #region 私有

        private bool  _isStripping;


        public enum YHType
        {
            性能优化,
            脚本,
            图形与物理,
            文件,
            相机,
            
        }

        [HideLabel]
        [EnumToggleButtons(true,80)]
        public YHType _FenLie = YHType.性能优化;




        #endregion



    }

}