using System;
using System.Collections.Generic;
using System.Text;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace UnityEditor
{
    internal sealed class Tools_QuickKey                                       // 快捷键
    {

        [MenuItem("Help/清除Log %y")]                            //Ctrl + Y 
         static void ClearConsole()
        {
#if UNITY_2017
            //在Unity2017路径换成这个
            string logClearTypeString = "UnityEditor.LogEntries,UnityEditor.dll";
#endif
#if !UNITY_2017
            string logClearTypeString = "UnityEditorInternal.LogEntries,UnityEditor.dll";
#endif

            MyType.RunNormalMethod(logClearTypeString, "Clear");




        }


        [MenuItem("Help/将Dll放进来 %q")]                        //Ctrl + Q 
        static void PullDllComeIn()
        {
            string savePath = Application.dataPath;
            string firstDllPath;
            if (OpenWindow.ChooseFile(@"F:\MyNewDll", out firstDllPath))
            {
                string fileName = MyAssetUtil.GetFileNameByFullName(firstDllPath);
                if (!MyAssetUtil.GetFileSuffix(fileName).Equals("dll"))
                {
                    MyLog.Orange("选择的文件不是dll ——" + fileName);
                    return;
                }
                string saveDllPath;
                if (OpenWindow.ChooseFloder(savePath, out saveDllPath))
                {
                    saveDllPath = saveDllPath + "/" + fileName;
                    MyIO.FileCopy(firstDllPath, saveDllPath);
                }
                else
                {
                    MyLog.Green("取消操作");
                }
            }
            else
            {
                MyLog.Green("取消操作");
            }
            AssetDatabase.Refresh();
        }



        [MenuItem("Help/复制 UGUI 对象名 %w")]                   //Ctrl + W
        static void GetName()
        {
            Transform[] ts = Selection.GetTransforms(SelectionMode.TopLevel);
            if (ts.Length !=1 || null == (ts[0] as RectTransform)|| ts[0].root.name != UIROOT || ts[0].name == UIROOT)
            {
                MyLog.Red("选择一个 UGUI 对象，而且根目录应该是放在 "+ UIROOT+" 下的");
                return;
            }
            List<string> l_Name = new List<string>();
            ForeachParent(ts[0], l_Name);
            l_Name.Reverse();                           // 将集合反转
            StringBuilder sb= new StringBuilder();
            sb.Append("\"");
            for (int i = 0; i < l_Name.Count; i++)
            {
                if (i == 0)
                {
                    sb.Append(l_Name[0].Remove(0,1));
                }
                else
                {
                    sb.Append(l_Name[i]);
                }
            }
            sb.Append("\"");
            //复制到系统全局的粘贴板上
            GUIUtility.systemCopyBuffer = sb.ToString();
        }



        [MenuItem("Help/复制 Resources 路径 %E")]                      //Ctrl + E
        static void GetResName()
        {
            GameObject[] prefabs = Selection.GetFiltered<GameObject>(SelectionMode.DeepAssets);
            if (prefabs.Length == 1)
            {
                GameObject prefab = prefabs[0];
                string assetPath = AssetDatabase.GetAssetPath(prefab);
                if (assetPath.IsNullOrEmpty() || !assetPath.Contains("Resources/"))
                {
                    MyLog.Red("选择一个 Resources 下的预制体啊");
                }
                else
                {
                    int resIndex = assetPath.IndexOf("Resources/", StringComparison.Ordinal);
                    int lastPoint = assetPath.LastIndexOf('.');           // 去除后缀

                    GUIUtility.systemCopyBuffer = "\"" + assetPath.Substring(resIndex + 10, lastPoint - resIndex - 10) + "\"";
                }
            }
            else
            {
                MyLog.Red("先选择一个 Resources 下的预制体啊（不能多，也不能少）");
            }



        }




        #region 私有


        private const string UIROOT = "UIRoot";
        private static void ForeachParent(Transform t ,List<string> list)
        {
            Transform parent = t.parent;
            if (parent.name == UIROOT)
            {
                return;
            }
            list.Add("/"+ t.name);
            ForeachParent(parent, list);
        }



        #endregion


    }
}


