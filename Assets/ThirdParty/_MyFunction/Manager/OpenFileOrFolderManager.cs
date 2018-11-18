using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using PSPUtil;
using PSPUtil.StaticUtil;
using UnityEngine;





public class OpenFileOrFolderManager : Manager 
{


//    protected override void OnStart()
//    {
//        base.OnStart();
//
//        MyEventCenter.AddListener<OpenBean>(E_GameEvent.OpenFileOrFolderContrl, (bean) =>
//        {
//            if (bean.IsFile)
//            {
//                StartCoroutine(StartOpenFile(bean));
//            }
//            else
//            {
//                StartCoroutine(StartOpenFolder(bean));
//            }
//        });
//
//    }
//
//    IEnumerator StartOpenFile(OpenBean bean)
//    {
//        yield return new WaitForSeconds(0.05f);
//        Time.timeScale = 0;
//        using (OpenFileDialog dialog = new OpenFileDialog())
//        {
//            dialog.InitialDirectory = bean.OpenPath;
//            dialog.Title = bean.Description;
//            switch (bean.FileFilter)
//            {
//                case EFileFilter.All:
//                    dialog.Filter = "显示所有文件(*.*)|*.*";
//                    break;
//                case EFileFilter.TuAndAll:
//                    dialog.Filter = "仅显示图片(*.PNG;*.JPG;*.BMP)|*.PNG;*.JPG;*.BMP|显示所有文件(*.*)|*.*";
//                    break;
//                case EFileFilter.JpgAndTuAndAll:
//                    dialog.Filter = "仅显示 JPG 图片(*.JPG)|显示图片(*.PNG;*.JPG;*.BMP)|*.PNG;*.JPG;*.BMP|显示所有文件(*.*)|*.*";
//                    break;
//                case EFileFilter.PngAndTuAndAll:
//                    dialog.Filter = "仅显示 PNG 图片(*.PNG)|显示图片(*.PNG;*.JPG;*.BMP)|*.PNG;*.JPG;*.BMP|显示所有文件(*.*)|*.*";
//                    break;
//                case EFileFilter.TextAnAll:
//                    dialog.Filter = "仅显示文本(*.txt)|*.txt|显示所有文件(*.*)|*.*";
//                    break;
//                default:
//                    throw new Exception("未定义");
//            }
//            DialogResult result = dialog.ShowDialog();
//            if (result == DialogResult.OK)
//            {
//                string[] files = dialog.FileNames;
//                if (null!= files && files.Length>0)
//                {
//                    MyEventCenter.SendEvent(E_GameEvent.ChooseFile, bean.Type, files);
//                }
//            }
//            Time.timeScale = 1;
//            MyEventCenter.SendEvent(E_GameEvent.CloseFileOrFolderContrl);
//
//        }
//    }
//
//
//
//
//    IEnumerator StartOpenFolder(OpenBean bean)
//    {
//        yield return new WaitForSeconds(0.05f);
//        Time.timeScale = 0;
//        using (FolderBrowserDialog dialog = new FolderBrowserDialog())
//        {
//            string folderPaht = bean.OpenPath;
//            if (!Directory.Exists(folderPaht))
//            {
//                MyLog.Red("给的初始化路径不存在 —— "+ folderPaht);
//                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
//            }
//            else
//            {
//                dialog.SelectedPath = folderPaht;
//            }
//            dialog.Description = bean.Description;
//            dialog.ShowNewFolderButton = true;
//            DialogResult result = dialog.ShowDialog();
//            if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
//            {
//                MyEventCenter.SendEvent(E_GameEvent.ChooseFolder, bean.Type, dialog.SelectedPath);
//            }
//            Time.timeScale = 1;
//            MyEventCenter.SendEvent(E_GameEvent.CloseFileOrFolderContrl);
//
//        }
//
//    }


}
