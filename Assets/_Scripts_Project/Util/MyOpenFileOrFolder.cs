using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;




public enum EFileFilter       // 文件过滤器
{
    All,               // 所有
    TuAndAll,          // 仅图和所有
    JpgAndTuAndAll,    // jpg、图片、所有
    PngAndTuAndAll,    // png、图片、所有
    TextAnAll,         // 仅文本和所有
    AudioAndAll,       // 仅音频和所有          

}


public static class MyOpenFileOrFolder  
{

    public static void OpenFile(string openPath,string tittle, EFileFilter filter, int filterIndex,Action<string[]> callBack)// 打开文件
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartOpenFile(openPath, tittle, filter, filterIndex, callBack));
    }

    public static void OpenFile(string openPath, string tittle, EFileFilter filter, Action<string[]> callBack)
    {
        OpenFile(openPath, tittle, filter, 0, callBack);

    }


    public static void OpenFile(string openPath, string tittle, Action<string[]> callBack)
    {
        OpenFile(openPath, tittle, EFileFilter.All,0, callBack);
    }



    //————————————————————————————————————


    public static void OpenFolder(string openPath,string des,bool isCanCreateNewFolder,Action<string> callBack)            // 打开文件夹
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartOpenFolder(openPath,des, isCanCreateNewFolder, callBack));
    }

    public static void OpenFolder(string openPath, string des, Action<string> callBack)
    {
        OpenFolder(openPath,des,true,callBack);
    }


    static IEnumerator StartOpenFile(string openPath, string tittle, EFileFilter filter, int filterIndex, Action<string[]> callBack)
    {
        MyEventCenter.SendEvent(E_GameEvent.OpenFileContrl);
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
        using (OpenFileDialog dialog = new OpenFileDialog())
        {
            dialog.InitialDirectory = openPath;
            dialog.Title = tittle;
            dialog.FilterIndex = filterIndex;
            dialog.Multiselect = true;
            switch (filter)
            {
                case EFileFilter.All:
                    dialog.Filter = MyFilterUtil.AllFileStr;
                    break;
                case EFileFilter.TuAndAll:
                    dialog.Filter = MyFilterUtil.TuAndAllStr;
                    break;
                case EFileFilter.JpgAndTuAndAll:
                    dialog.Filter = MyFilterUtil.JpgAndTuAndAllStr;
                    break;
                case EFileFilter.PngAndTuAndAll:
                    dialog.Filter = MyFilterUtil.PngAndTuAndAllStr;
                    break;
                case EFileFilter.TextAnAll:
                    dialog.Filter = MyFilterUtil.TextAnAllStr;
                    break;
                case EFileFilter.AudioAndAll:
                    dialog.Filter = MyFilterUtil.AudioAndAllStr;
                    break;
                default:
                    throw new Exception("未定义");
            }
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = dialog.FileNames;
                if (null != files && files.Length > 0 && null != callBack)
                {
                    callBack(files);
                }
            }
            Time.timeScale = 1;
            MyEventCenter.SendEvent(E_GameEvent.CloseFileOrFolderContrl);

        }
    }

    static IEnumerator StartOpenFolder(string openPath,string des, bool isCanCreateNewFolder, Action<string> callBack)
    {
        MyEventCenter.SendEvent(E_GameEvent.OpenFolderContrl);
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 0;
        try
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                string folderPaht = openPath;
                if (!Directory.Exists(folderPaht))
                {
                    MyLog.Red("给的初始化路径不存在 —— " + folderPaht);
                    dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                }
                else
                {
                    dialog.SelectedPath = folderPaht;
                }
                dialog.Description = des;
                dialog.ShowNewFolderButton = isCanCreateNewFolder;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath) && null != callBack)
                {
                    callBack(dialog.SelectedPath);
                }
            }
        }
        catch (Exception e)
        {
            MyLog.Red("有异常 —— " + e);
        }
        finally
        {
            Time.timeScale = 1;
            MyEventCenter.SendEvent(E_GameEvent.CloseFileOrFolderContrl);
        }

    }


}
