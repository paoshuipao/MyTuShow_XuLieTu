using System;
using System.IO;
using System.Windows.Forms;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;

namespace UnityEditor
{
    public class GongNeng_DLL : AbstactNewKuang
    {

        [MenuItem(LearnMenu.GongNeng_CS)]
        static void Init()
        {
            GongNeng_DLL Instance = GetWindow<GongNeng_DLL>(false, "");
            Instance.SetupWindow();
        }


        protected override void DrawLeft()
        {
            MyCreate.Text("C# System ");
            bool isTmp1 = (type == EType.WindowsForms || type == EType.WindowsForms2 || type == EType.OpenFileDialog || type == EType.FolderBrowserDialog);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Windows.Forms".AddSize(15);
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.WindowsForms ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.WindowsForms);
            }

            if (isTmp1)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.WindowsForms2 ? "MessageBox".AddBlue() : "MessageBox");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.WindowsForms2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.OpenFileDialog ? "OpenFileDialog".AddBlue() : "OpenFileDialog");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.OpenFileDialog);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FolderBrowserDialog ? "FolderBrowserDialog".AddBlue() : "FolderBrowserDialog");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FolderBrowserDialog);
                }
            }
            AddSpace();

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Drawing";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Drawing ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Drawing);
            }
        }

        protected override void DrawRight()
        {

            switch (type)
            {
                case EType.WindowsForms:
                    DrawRightPage1(DrawWindowsForms);
                    break;
                case EType.WindowsForms2:
                    DrawRightPage3(DrawDrawWindowsForms2);
                    break;
                case EType.OpenFileDialog:
                    DrawRightPage3(DrawOpenFileDialog);
                    break;
                case EType.FolderBrowserDialog:
                    DrawRightPage4(DrawFBD);
                    break;
                case EType.Drawing:
                    break;
            }

        }

        protected override void DrawRightSize()
        {
            switch (type)
            {
                case EType.WindowsForms:
                    mWindowSettings.pageWidthExtraSpace.target = -20;
                    break;
                case EType.WindowsForms2:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                case EType.OpenFileDialog:
                    mWindowSettings.pageWidthExtraSpace.target = 20;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }


        #region 私有


        private EType type = EType.WindowsForms;
        private bool isSpecialFolder;

        private enum EType
        {

            WindowsForms, WindowsForms2, OpenFileDialog, FolderBrowserDialog,
            Drawing,


        }

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
            return "Dll 扩展";
        }

        #endregion




        private void DrawWindowsForms()                          // Windows.Forms
        {
            m_Tools.GuangFangWenDan("https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.forms?view=netframework-4.7.2");
            m_Tools.BiaoTi_B("使用说明");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("1. 在对应的版本下查找：如果用其他的 编辑器不报错，导出来会报错:".AddYellow());
                m_Tools.TextButton_Open("D:\\Soft\\Unity2017\\Editor\\Data\\Mono\\lib\\mono\\2.0", "D:\\Soft\\Unity2017\\Editor\\Data\\Mono\\lib\\mono\\2.0");
                MyCreate.Text("2. 修改脚本集:".AddYellow());
                m_Tools.Text_L("Build -> Other Settings -> Api Compatibility Level -> ",".NET 2.0".AddGreen());
            });
            m_Tools.BiaoTi_B("包含众多好用的类");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_OL("MessageBox", "显示一个消息框");
                m_Tools.TextText_OL("OpenFileDialog", "打开文件对话框，选择文件");
                m_Tools.TextText_OL("FolderBrowserDialog", "打开文件夹选择框，选择文件夹");
            });

        }


        private void DrawDrawWindowsForms2()                     // MessageBox
        {
            m_Tools.BiaoTi_B("MessageBox -> 消息框"+ "(向用户显示消息)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L(" 1. 会阻止应用程序中的其他操作,直到关闭它为止" + "(即当前应用会挂起)".AddGreen());
                m_Tools.Text_L(" 2. MessageBox 可以包含通知和指示用户的文本，按钮和符号");
                m_Tools.Text_L(" 3. Static 类  -> 只有一个 "," public static DialogResult Show（...）".AddHui()," 方法");

            });

            AddSpace();

            m_Tools.BiaoTi_B("MessageBox.Show（ ） 返回-> DialogResult" + "(多种重载)");
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("Show("+"string 内容".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
                m_Tools.Text_B("Show("+"string 内容，string 标题".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
                m_Tools.Text_B("Show("+ "string，string，MessageBoxButtons 按钮类型".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
                m_Tools.Text_B("Show("+ "string，string，MessageBoxButtons，MessageBoxIcon 图标".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
                m_Tools.Text_B("Show("+ "上面4个参数， MessageBoxDefaultButton 默认按钮".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
                m_Tools.Text_B("Show("+ "上面5个参数， MessageBoxOptions 消息框选项".AddColorAndSize(MyEnumColor.Hui,10,false)+")");
            });

            m_Tools.BiaoTi_B("使用到的枚举");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_Y("DialogResult " + "（点击了那里）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("DialogResult.Cancel", "点击了右上取消按钮 " + "X".AddRed(), 30);
                    m_Tools.TextText_WL("DialogResult.OK", "点击了 确定 按钮", 30);
                    m_Tools.TextText_WL("同理 Yes/No/Abort/Retry/Ignore", "点击了 Yes/No/Abort/Retry/Ignore", 30);
                });

                m_Tools.BiaoTi_Y("MessageBoxButtons " + "（指定有那些按钮）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("MessageBoxButtons.OK", "只有 OK 按钮"+"(不填该参数，默认这个)".AddLightGreen(),30);
                    m_Tools.TextText_WL("MessageBoxButtons.OKCancel", "带 OK 和 Cancel 按钮", 30);
                    m_Tools.TextText_WL("MessageBoxButtons.AbortRetryIgnore", "带Abort、Retry、Ignore 三按钮", 30);
                    m_Tools.TextText_WL("同理 YesNoCancel/YesNo/RetryCancel", "带 xxx 按钮", 30);
                });
                m_Tools.BiaoTi_Y("MessageBoxIcon " + "（指定提供那些图标）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_W("None", "（没有）".AddLightBlue(), "           Hand", "（手）".AddLightBlue(), "              Stop", "（停止）".AddLightBlue());
                    m_Tools.Text_W("Error", "（错误）".AddLightBlue(), "           Question", "（问题）".AddLightBlue(), "       Exclamation", "（感叹）".AddLightBlue());
                    m_Tools.Text_W("Warning", "（警告）".AddLightBlue(), "       Asterisk", "（星号）".AddLightBlue(), "        Information", "（信息）".AddLightBlue());
                });
                m_Tools.BiaoTi_Y("MessageBoxDefaultButton " + "（默认那个按钮会高亮）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_W("Button1/Button2/Button3  ","(就是按钮1、2、3 那个需要默认高亮)".AddLightBlue());
                });
                m_Tools.BiaoTi_Y("MessageBoxOptions " + "（消息框选项）".AddGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_WL("DefaultDesktopOnly", "消息框显示在活动桌面上", 30);
                    m_Tools.TextText_WL("RightAlign", "文本右对齐", 30);
                    m_Tools.TextText_WL("RtlReading", "文本按从右到左的阅读顺序显示", 30);
                    m_Tools.TextText_WL("ServiceNotification", "服务通知", 30);
                });

            });   

            m_Tools.BiaoTi_O("功能实现"+"(例子)".AddLightGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.Button("简单例子", () =>
                    {
                        MyLog.Red(MessageBox.Show("这里内容"));
                    });
                    MyCreate.Button("内容 + 标题", () =>
                    {
                        MessageBox.Show("内容？","标题",MessageBoxButtons.AbortRetryIgnore);
                    });
                    MyCreate.Button("多个参数", () =>
                    {
                        MessageBox.Show("内容？", "标题", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);

                    });
                });

            });

        }


        private void DrawOpenFileDialog()                       // OpenFileDialog
        {

            m_Tools.BiaoTi_B("OpenFileDialog "+ "(显示标准对话框，提示用户打开文件)");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.forms.openfiledialog?view=netframework-4.7.2");
                m_Tools.Text_H(" sealed 类，不能继承，需要 new 出来，最好使用 using:");
                m_Tools.Text_H(" using (OpenFileDialog ofd = new OpenFileDialog())");
            });
            m_Tools.BiaoTi_B("属性"+"(都是可读可写的)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("InitialDirectory", "","初始目录","string");
                m_Tools.Method_BL("Filter", "", "筛选器","string");
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("例子1："+"1. 仅显示 .txt   2. 所有文件");
                    m_Tools.Text_H("ofd.Filter =”仅文本(*.txt)| *.txt | 所有文件| *.* “;");
                    MyCreate.Text("例子2：" + "1. 仅显示BMP、JPG、GIF文件   2. 所有文件");
                    m_Tools.Text_H("ofd.Filter =”仅图(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF| 所有文件|*.*“;");

                });
                m_Tools.Method_BL("FilterIndex", "", "上面的筛选器默认先使用那个", "int");
                m_Tools.Method_BL("FileName", "", "单个文件名", "string");
                m_Tools.Method_BL("FileNames", "", "多选，多个文件名", "string[]");

            });
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("ShowDialog", "","打开窗口", "DialogResult");
                m_Tools.Method_OY("OpenFile", "","打开选中的文件", "Stream");
            });
            

            m_Tools.BiaoTi_O("功能实现" + "(例子)".AddLightGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.Button("简单例子", () =>
                    {
                        using (OpenFileDialog dialog1 = new OpenFileDialog())
                        {
                            dialog1.ShowDialog();
                        }
                    });

                    MyCreate.Button("详细例子", () =>
                    {
                        string fileContent = string.Empty;
                        string filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.InitialDirectory = "c:\\";
                            openFileDialog.Filter = "仅文本 (*.txt)|*.txt|All files (*.*)|*.*";
                            openFileDialog.FilterIndex = 2;
                            openFileDialog.RestoreDirectory = true;

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                //获取指定文件的路径
                                filePath = openFileDialog.FileName;
                                //Read the contents of the file into a stream
                                Stream fileStream = openFileDialog.OpenFile();

                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                }
                            }
                        }

                        MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
                    });
                });

            });
        }



        private void DrawFBD()                                  // FolderBrowserDialog
        {
            m_Tools.BiaoTi_B("FolderBrowserDialog "+ "(显示对话框，提示用户选择文件夹)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.GuangFangWenDan("https://docs.microsoft.com/zh-cn/dotnet/api/system.windows.forms.folderbrowserdialog?view=netframework-4.7.2");
                m_Tools.Text_H(" sealed 类，不能继承，需要 new 出来，最好使用 using:");
                m_Tools.Text_H(" using (FolderBrowserDialog dialog = new FolderBrowserDialog())");
            });

            m_Tools.BiaoTi_B("属性" + "(都是可读可写的)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Method_BL("RootFolder", "", "开始浏览的位置", "SpecialFolder 枚举",ref isSpecialFolder, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_LW("MyComputer", "我的电脑", -20);
                        m_Tools.TextText_LW("Desktop", "桌面",-20);
                        MyCreate.Text("好像其他都没有卵用".AddGreen());
                        m_Tools.TextText_LW("MyDocuments", "D:\\Documents", -20);
                        m_Tools.TextText_LW("Programs", "", -20);
                        m_Tools.TextText_LW("Personal", "", -20);
                        m_Tools.TextText_LW("Favorites", "", -20);
                        m_Tools.TextText_LW("Startup", "", -20);
                        m_Tools.TextText_LW("Recent", "", -20);
                        m_Tools.TextText_LW("SendTo", "", -20);
                        m_Tools.TextText_LW("StartMenu", "", -20);
                        m_Tools.TextText_LW("MyMusic", "", -20);
                        m_Tools.TextText_LW("DesktopDirectory", "", -20);
                        m_Tools.TextText_LW("Templates", "", -20);
                        m_Tools.TextText_LW("ApplicationData", "", -20);
                        m_Tools.TextText_LW("LocalApplicationData", "", -20);
                        m_Tools.TextText_LW("InternetCache", "", -20);
                        m_Tools.TextText_LW("Cookies", "", -20);
                        m_Tools.TextText_LW("History", "", -20);
                        m_Tools.TextText_LW("CommonApplicationData", "", -20);
                        m_Tools.TextText_LW("System", "", -20);
                        m_Tools.TextText_LW("ProgramFiles", "", -20);
                        m_Tools.TextText_LW("MyPictures", "", -20);
                        m_Tools.TextText_LW("CommonProgramFiles", "", -20);


                    });
                });
                m_Tools.Method_BL("Description", "", "文本说明", "stirng");
                m_Tools.Method_BL("ShowNewFolderButton", "", "true :显示“新建文件夹按钮”", "bool");
                m_Tools.Method_BL("SelectedPath", "", "选择的文件夹路径", "string");

            });


            m_Tools.BiaoTi_B("方法");
            MyCreate.Box(() =>
            {
                m_Tools.Method_OY("ShowDialog", "","打开窗口", "DialogResult");

            });



            m_Tools.BiaoTi_O("功能实现" + "(例子)".AddLightGreen());
            MyCreate.Box(() =>
            {
                MyCreate.Heng(() =>
                {
                    MyCreate.Button("简单例子", () =>
                    {
                        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                        {
                            dialog.ShowDialog();
                        }
                    });
                    MyCreate.Button("详细例子", () =>
                    {
                        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                        {
                            dialog.RootFolder = Environment.SpecialFolder.ApplicationData;  //开始浏览的位置
                            dialog.Description = "说明"; 
                            dialog.ShowNewFolderButton = true;         // 能够使用“新建文件夹按钮”创建新文件夹
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                MyLog.Green("获得文件夹 —— "+ dialog.SelectedPath);

                            }
                        }
                    });
                });


            });
        }
    }

}

