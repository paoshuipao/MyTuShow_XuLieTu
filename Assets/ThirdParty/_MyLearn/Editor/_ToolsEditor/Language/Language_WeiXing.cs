using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using Sirenix.OdinInspector;

namespace UnityEditor
{
    public class Language_WeiXing : AbstractChooseKuang<Language_WeiXing>
    {
        protected override void OnEditorGUI()
        {
            switch (_FenLie)
            {
                case WXType.准备工作:
                    DrawGongZuo();
                    break;
                case WXType.HelloWorld:
                    DrawHelloWorld();
                    break;
            }

            MyCreate.AddSpace();
        }

        private void DrawHelloWorld()
        {
            m_Tools.BiaoTi_B("目录结构 ");
            MyCreate.Box(() =>
            {
                DrawnOne("pages".AddYellow(),"// 页面目录，包含页面逻辑、结构、样式",ref isPages, () =>
                {
                    
                }, () =>
                {
                    DrawTwo_NoColor("index".AddYellow(), () =>
                    {
                        DrawThree_NoColor("index.js（每个页面逻辑）", null);
                        DrawThree_NoColor("index.wxml（每个页面结构）", null);
                        DrawThree_NoColor("index.wxss（每个页面样式）", null);
                    });
                    DrawTwo_NoColor("logs".AddYellow(), () =>
                    {
                        DrawThree_NoColor("logs.js(logs 页面逻辑)", null);
                        DrawThree_NoColor("logs.json（logs 页面配置文件)", null);
                        DrawThree_NoColor("logs.wxml（logs 页面结构）", null);
                        DrawThree_NoColor("logs.wxss（logs 页面样式）", null);
                    });
                });
                DrawnOne("utils".AddYellow(), "// 公共脚本",ref isutils, () =>
                {
                    
                },() =>
                {
                    DrawTwo_NoColor("util.js（工具类）", null);
                });
                DrawnOne("app.js", "// Main 入口，写逻辑", ref isappjs, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_G("用于定义整个应用的逻辑");
                        m_Tools.Text_H("App 函数 -> 用来创建一个应用程序实例");
                        m_Tools.Text_H("每个应用程序都会有它的生命周期");
                        m_Tools.Text_G("相当于 Main 入口，执行类似 MonoBehaviour 的生命周期");
                    });
                }, null);
                DrawnOne("app.json", "// 应用配置(类似 manifest),定义颜色、名称等", ref isappJson, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_HG("“navigationBarBackgroundColor”: “#fff”", "// 背景颜色");
                        m_Tools.TextText_HG("“navigationBarTitleText”: “名称”","// 标题头");
                    });

                }, null);
                DrawnOne("app.wxss","// CSS 代码（设置整个应用的样式）",ref isappwxss, () =>
                {
                    
                }, null);
                DrawnOne("project.config.json","// 项目配置",ref isconfig, () =>
                {
                    
                }, null);

            });

        }

        private void DrawGongZuo()                               // 准备工作
        {
            m_Tools.TextButton_Open("打开微信开发工具".AddOrange(), @"C:\Users\Administrator\Desktop\~\微信web开发者工具");
            AddSpace();
            m_Tools.BiaoTi_B("基础： HTML + JS + CSS");

        }


        #region 私有

        private bool isPages, isutils, isappjs, isappJson, isappwxss, isconfig;

        [HideLabel]
        [EnumToggleButtons(true)]
        public WXType _FenLie = WXType.准备工作;

        public enum WXType
        {
            准备工作,
            HelloWorld,

        }



        [MenuItem(LearnMenu.OtherLanguage4)]
        public static void ShowWindow()
        {
            CreateWindow("小程序", 520, 550);
        }

        #endregion



    }

}

