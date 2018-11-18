using System;
using System.IO;
using ES3Editor;
using ES3Internal;
using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Tools_EasySave : AbstactNewKuang
    {

        [MenuItem(LearnMenu.EasySave)]
        static void Init()
        {
            Tools_EasySave instance = GetWindow<Tools_EasySave>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()
        {
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "官方文档";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Gun ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Gun);
            }

            AddSpace_15();


            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "工具";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Tools1 ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Tools1);
            }


            AddSpace_15();

            bool isStudy = type == EType.Study1 || type == EType.Study2 || type == EType.Study3 || type == EType.Study4;

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "学习使用";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isStudy ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Study1);
            }
            if (isStudy)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Study1 ? "   总结".AddBlue() : "   总结");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Study1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Study2 ? "   核心类 ES3".AddBlue() : "   核心类 ES3");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Study2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Study3 ? "   ES3Settings".AddBlue() : "   ES3Settings");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Study3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Study4? "   TODO".AddBlue() : "   TODO");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Study4);
                }
            }

            AddSpace();

        }

        protected override void DrawRight()
        {
            switch (type)
            {
                case EType.Gun:
                    DrawRightPage6(DrawGuanFan);
                    break;
                case EType.Tools1:
                    DrawRightPage(DrawSetting);
                    break;
                case EType.Study1:
                    DrawRightPage1(DrawUse1);
                    break;
                case EType.Study2:
                    DrawRightPage4(DrawEs3);
                    break;
                case EType.Study3:
                    DrawRightPage5(DrawEs3Setting);
                    break;
                case EType.Study4:
                    break;
            }
        }

        protected override void DrawRightSize()
        {
        }


        #region 私有

        private bool isLocation, isencryptionType,isbufferSize;

        protected override void OnInit()
        {
            base.OnInit();
            editorSettings = ES3EditorUtility.GetDefaultSettings();
            settings = editorSettings.settings;
        }

        private ES3DefaultSettings editorSettings = null;
        private ES3SerializableSettings settings = null;
        private enum EType
        {
            Gun,
            Tools1,
            Study1, Study2, Study3, Study4


        }
        private EType type = EType.Tools1;


        protected override string Tittle()
        {
            return "EasySave 控制台";
        }


        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }

        }

        #endregion

        private void DrawGuanFan()                     // 官方文档
        {
            m_Tools.BiaoTi_B("第一次使用 Easy Save?");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open_L("入门指南", "http://docs.moodkie.com/easy-save-3/getting-started/");
            });
            
            AddSpace();
            m_Tools.BiaoTi_B("文档和指南");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open_L("文档", "http://docs.moodkie.com/product/easy-save-3/");
                m_Tools.TextButton_Open_L("指南", "http://docs.moodkie.com/product/easy-save-3/es3-guides/");
                m_Tools.TextButton_Open_L("API 脚本参考", "http://docs.moodkie.com/product/easy-save-3/es3-api/");
                m_Tools.TextButton_Open_L("支持的类型", "http://docs.moodkie.com/easy-save-3/es3-supported-types/");
            });

            AddSpace();
            m_Tools.BiaoTi_B("相关支持");
            MyCreate.Box(() =>
            {
                m_Tools.TextButton_Open_L("直接联系官方", "http://www.moodkie.com/contact/");
                m_Tools.TextButton_Open_L("在 Easy Save 3 论坛中提问", "http://moodkie.com/forum/viewforum.php?f=12");
                m_Tools.TextButton_Open_L("在 Unity 论坛主题中提问", "https://forum.unity3d.com/threads/easy-save-the-complete-save-load-asset-for-unity.91040/");

            });

        }



        private void DrawSetting()                     // Setting
        {
            m_Tools.BiaoTi_B("说明");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_WL("ES3.Save<T>(string key ,T value)", "调用下面设置",140);
                m_Tools.TextText_WL("ES3.Save<T>(string key ,T value ,"+ "ES3Settings".AddGreen()+ ")","使用新设置", 140);
            });

            AddSpace();

            m_Tools.BiaoTi_O("默认运行时的"+"设置".AddYellow());
            MyCreate.Box(() =>
            {
                settings.location = (ES3.Location) m_Tools.TextEnum_B("位置"+ "（location）".AddWhite(), settings.location,ref isLocation,
                    () =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_L("数据应存储和加载的位置");
                            m_Tools.Text_L("Resources 只允许加载，当然不能存储"+ "(所以 Resources 作用不大)".AddGreen());
                            m_Tools.Text_G("感觉这个就默认 File 文件即可");
                        });
                    });

                if (settings.location == ES3.Location.File)
                {
                    settings.directory = (ES3.Directory)m_Tools.TextEnum_B("文件保存目录" + "（directory）".AddWhite(), settings.directory);
                }


                settings.path = m_Tools.TextString_B("文件名"+ "(path)".AddWhite(), settings.path);

                MyCreate.AddSpace(5);

                settings.encryptionType = (ES3.EncryptionType)m_Tools.TextEnum_B("加密类型"+"(encryptionType)".AddWhite(), settings.encryptionType,ref isencryptionType,
                    () =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_L("目前支持易保存AES 加密利用 128 位密钥 ");
                            m_Tools.Text_L("不需要加密就 None");
                        });
                    });

                if (settings.encryptionType == ES3.EncryptionType.AES)
                {
                    settings.encryptionPassword = m_Tools.TextString("加密密码"+"(encryptionPassword)".AddWhite(), settings.encryptionPassword);
                }

                settings.format = (ES3.Format)m_Tools.TextEnum_B("文件格式"+ "(format)".AddWhite(), settings.format);
                settings.bufferSize = m_Tools.TextInt_B("缓存长度"+ "(bufferSize)".AddWhite(), settings.bufferSize,ref isbufferSize, () =>
                    {
                        MyCreate.Box_Hei(() =>
                        {
                            m_Tools.Text_L("任何流缓冲区都将设置为此长度（以字节为单位）");
                            m_Tools.Text_L("    通常使用更大的缓冲区会提高性能但也会增加内存使用量，");
                            m_Tools.Text_L("    但有些系统会执行优化，这会使性能下降得不那么明显");
                            m_Tools.Text_G("如果不确定，请将其保留为默认值 2048");
                        });
                    });

            });

            AddSpace();
            m_Tools.BiaoTi_O("Editor" + "设置".AddYellow());
            MyCreate.Box(() =>
            {

                editorSettings.addMgrToSceneAutomatically = m_Tools.TextBool_H("自动将 Manager 添加到场景", editorSettings.addMgrToSceneAutomatically);
                editorSettings.autoUpdateReferences = m_Tools.TextBool_H("自动更新 References", editorSettings.autoUpdateReferences);


                // Show Assembly names array.
                SerializedObject so = new SerializedObject(editorSettings);
                SerializedProperty settingsProperty = so.FindProperty("settings");
                SerializedProperty assemblyNamesProperty = settingsProperty.FindPropertyRelative("assemblyNames");
                EditorGUILayout.PropertyField(assemblyNamesProperty, new GUIContent("包含ES3Types的程序集", "我们要从中加载ES3Types的程序集的名称"), true); // True means show children
                so.ApplyModifiedProperties();
            });


            AddSpace();
            m_Tools.BiaoTi_Y("工具");
            MyCreate.Box(() =>
            {
                MyCreate.Heng(() =>
                {
                    m_Tools.Text_B("Open persistentDataPath 文件夹");
                    MyCreate.AddSpace();
                    MyCreate.Button("  打开  ", () =>
                    {
                        Application.OpenURL(Application.persistentDataPath);
                    });
                });


                MyCreate.Heng(() =>
                {
                    m_Tools.Text_B("Clear persistentDataPath"+"(删除文件夹下所有)".AddGreen());
                    MyCreate.AddSpace();
                    MyCreate.Button("  清理  ", () =>
                    {
                        if (EditorUtility.DisplayDialog("清理 persistentDataPath", "确定全部删除?\n 操作不可销毁.", "删除", "取消"))
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }
                            foreach (DirectoryInfo dir in di.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }
                    });
                });


                MyCreate.Heng(() =>
                {
                    m_Tools.Text_B("Clear PlayerPrefs");
                    MyCreate.AddSpace();
                    MyCreate.Button("  清理  ", () =>
                    {
                        if (EditorUtility.DisplayDialog("清理 PlayerPrefs", "确定全部清理?", "清理", "取消"))
                        {
                            PlayerPrefs.DeleteAll();
                        }
                    });
                });



            });


        }





        //—————————————————— ——————————————————
        private void DrawUse1()                         // 总结
        {
            m_Tools.BiaoTi_B("核心 Static 类 ES3" + "(保存、加载、备份、删除)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW("要保存值 ->", "ES3.Save<T>(string key,T 值)");
                m_Tools.TextText_BW("要加载值 ->", "ES3.Load <T>(string key,T 默认值)");
            });

            m_Tools.BiaoTi_B("退出时保存" + "（在那函数调用好）");
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BW("PC", "OnApplicationQuit");
                m_Tools.TextText_BW("移动", "OnApplicationPause（bool）");
            });

        }


        private void DrawEs3()                          // 核心
        {
            m_Tools.GuangFangWenDan("https://docs.moodkie.com/easy-save-3/es3-api/es3-class/#description");
            MyCreate.FenGeXian("保存");
            m_Tools.TextText_OY("ES3.Save<T>", "object值 保存到文件中", 50);
            m_Tools.TextText_OY("ES3.SaveImage", "Texture2D 保存为图像文件", 50);
            m_Tools.TextText_HL("ES3.SaveRaw/AppendRaw", "byte[] 保存到文件中/追加", 50);
            MyCreate.FenGeXian("加载");
            m_Tools.TextText_OY("ES3.Load<T>   -> T", "从文件中获得 object值", 50);
            m_Tools.TextText_OY("ES3.LoadInto<T>", "从文件中获得值赋值到已存在的对象", 50);
            m_Tools.TextText_OY("ES3.LoadImage   -> Texture2D", "加载 JPG 或 PNG 图像文件", 50);
            m_Tools.TextText_OY("ES3.LoadAudio  -> AudioClip", "加载音频文件", 50);
            m_Tools.TextText_HL("ES3.LoadRawBytes  -> byte[]", "从文件中获得byte[]数据", 50);
            MyCreate.FenGeXian("判断是否存在");
            m_Tools.TextText_HL("ES3.KeyExists", "这个文件是否存在这个 Key", 50);
            m_Tools.TextText_HL("ES3.FileExists", "是否存在这个 文件", 50);
            m_Tools.TextText_HL("ES3.DirectoryExists", "是否存在这个 目录", 50);
            MyCreate.FenGeXian("删除");
            m_Tools.TextText_HL("ES3.DeleteKey", "删除 Key", 50);
            m_Tools.TextText_HL("ES3.DeleteFile", "删除 文件", 50);
            m_Tools.TextText_HL("ES3.DeleteDirectory", "删除 目录", 50);
            MyCreate.FenGeXian("备份");
            m_Tools.TextText_HL("ES3.CreateBackup", "备份", 50);
            m_Tools.TextText_HL("ES3.RestoreBackup", "恢复备份文件", 50);
            MyCreate.FenGeXian("密钥文件和目录的方法");
            m_Tools.TextText_HL("ES3.RenameFile", "重命名文件", 50);
            m_Tools.TextText_HL("ES3.CopyFile", "复制文件", 50);
            m_Tools.TextText_HL("ES3.GetKeys", "从文件中获取键名称数组", 50);
            m_Tools.TextText_HL("ES3.GetFiles", "目录中获取文件名的数组", 50);
            m_Tools.TextText_HL("ES3.GetDirectories", "获得所有目录名的数组", 50);
            m_Tools.TextText_HL("ES3.GetTimestamp", "获得上次更新的日期时间", 50);

        }


        private void DrawEs3Setting()
        {
            m_Tools.BiaoTi_B("ES3Settings 可以 new 出来，默认的在 Tools 设置");


        }



    }

}

