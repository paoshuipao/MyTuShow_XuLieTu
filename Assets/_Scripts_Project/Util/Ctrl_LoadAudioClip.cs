using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NAudio.Wave;
using PSPUtil.Control;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.Networking;


public class AudioResBean         
{

    public bool IsDaoRu { get; set; }             // 是否导入了

    public AudioClip Clip { get; private set; }           // 下载的音频
    public string YuanPath { get; private set; }          // 原路径
    public string SavePath { get; private set; }          // 保存路径（不是mp3等于原路径）
    public FileInfo YuanFileInfo { get; private set; }    // 原路径的文件

    public bool IsMP3 { get; private set; }               // 是否 MP3


    public AudioResBean(AudioClip clip, string yuanPath, string savePath, bool isMp3,FileInfo file)
    {
        IsDaoRu = false;
        Clip = clip;
        YuanPath = yuanPath;
        SavePath = savePath;
        IsMP3 = isMp3;
        YuanFileInfo = file;

    }
}



public class Ctrl_LoadAudioClip : Singleton_Mono<Ctrl_LoadAudioClip>
{


    public void StartLoadAudioClip(FileInfo fileInfo, Action<AudioResBean> callBack)
    {

        foreach (AudioResBean bean in l_AudioResBean)
        {
            if (fileInfo.FullName == bean.YuanPath)
            {
                callBack(bean);
                return; 
            }
        }


        if (fileInfo.Extension == ".mp3")
        {
            MP3ResBean resBean = null;
            for (int i = 0; i < l_HasLoadMp3.Count; i++)
            {
                if (l_HasLoadMp3[i].YuanPath == fileInfo.FullName)
                {
                    resBean = l_HasLoadMp3[i];
                    break;
                }
            }
            if (null == resBean)
            {
                resBean = new MP3ResBean();
                string savePath = dirPath + "/" + Path.GetFileNameWithoutExtension(fileInfo.FullName) + ".wav";
                new Thread(() =>
                {
                    try
                    {
                        FileStream stream = File.Open(fileInfo.FullName, FileMode.Open);
                        Mp3FileReader reader = new Mp3FileReader(stream);
                        WaveFileWriter.CreateWaveFile(savePath, reader);
                        resBean.YuanPath = fileInfo.FullName;
                        resBean.isOk = true;
                        resBean.SavePath = savePath;
                        l_HasLoadMp3.Add(resBean);
                    }
                    catch (Exception e)
                    {
                        MyLog.Red("有错 —— " + e);
                        throw;
                    }
                }).Start();
            }
            Ctrl_Coroutine.Instance.StartCoroutine(LoadMp3(fileInfo,resBean, callBack));
        }
        else
        {
            Ctrl_Coroutine.Instance.StartCoroutine(LoadOtherGeShi(fileInfo, callBack));

        }


    }


    #region 私有


    class MP3ResBean
    {
        public string YuanPath; // 原路径
        public string SavePath; // 保存的路径
        public bool isOk;      // 是否转完成
    }

    private const string SAVE_FOLDER_NAME = "/Mp3SavePath";
    private string dirPath;
    private readonly List<MP3ResBean> l_HasLoadMp3 = new List<MP3ResBean>();      // 已经下载过的 mp3
    private readonly List<AudioResBean> l_AudioResBean = new List<AudioResBean>();    // 所有的音频文件返回结果的集合




    IEnumerator LoadOtherGeShi(FileInfo file,Action<AudioResBean> callBack)
    {
        AudioType type;
        if (file.Extension == ".ogg")
        {
            type = AudioType.OGGVORBIS;
        }
        else if (file.Extension == ".aiff")
        {
            type = AudioType.AIFF;
        }
        else if (file.Extension == ".wav")
        {
            type = AudioType.WAV;
        }
        else
        {
            throw new Exception("还有其他格式？");
        }
        string path = file.FullName;
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" + path, type))
        {
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                MyLog.Red(request.error);
                yield break;
            }
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            clip.name = Path.GetFileNameWithoutExtension(path);
            AudioResBean resBean = new AudioResBean(clip,path,path,false, file);
            l_AudioResBean.Add(resBean);
            if (null != callBack)
            {
                callBack(resBean);
            }
        }
    }

    IEnumerator LoadMp3(FileInfo fileInfo, MP3ResBean res, Action<AudioResBean> callBack)
    {
        while (!res.isOk)
        {
            yield return new WaitForSeconds(0.1f);
        }
        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" + res.SavePath, AudioType.WAV))
        {
            yield return request.SendWebRequest();
            if (request.isHttpError || request.isNetworkError)
            {
                MyLog.Red(request.error);
                yield break;
            }
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            clip.name = Path.GetFileNameWithoutExtension(res.SavePath);

            AudioResBean resBean =new AudioResBean(clip,res.YuanPath,res.SavePath,true, fileInfo);
            l_AudioResBean.Add(resBean);
            if (null != callBack)
            {
                callBack(resBean);
            }
        }

    }

    #endregion


    protected override void OnAwake()
    {
        base.OnAwake();
        dirPath = Application.persistentDataPath + SAVE_FOLDER_NAME;
        DirectoryInfo dir = new DirectoryInfo(dirPath);
        if (!dir.Exists)
        {
            dir.Create();
        }
    }




    void OnApplicationQuit() // 退出把加载的所有音乐删除
    {
        for (int i = 0; i < l_AudioResBean.Count; i++)
        {
            if (l_AudioResBean[i].IsMP3 && !l_AudioResBean[i].IsDaoRu)
            {
                File.Delete(l_AudioResBean[i].SavePath);
            }
        }

    }




}