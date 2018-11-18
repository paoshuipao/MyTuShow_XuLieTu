using System.IO;
using UnityEngine;

public static class MyFilterUtil
{

    public const string AllFileStr = "显示所有文件(*.*)|*.*";
    public const string TuAndAllStr = "仅显示图片(*.PNG;*.JPG;*.BMP;*.JPEG)|*.PNG;*.JPG;*.BMP;*.JPEG|显示所有文件(*.*)|*.*";
    public const string JpgAndTuAndAllStr = "仅显示 JPG 图片(*.JPG;*.JPEG)|*.JPG;*.JPEG|显示图片(*.PNG;*.JPG;*.BMP;*.JPEG)|*.PNG;*.JPG;*.BMP;*.JPEG|显示所有文件(*.*)|*.*";
    public const string PngAndTuAndAllStr = "仅显示 PNG 图片(*.PNG)|*.PNG|显示图片(*.PNG;*.JPG;*.BMP;*.JPEG)|*.PNG;*.JPG;*.BMP;*.JPEG|显示所有文件(*.*)|*.*";
    public const string TextAnAllStr = "仅显示文本(*.txt)|*.txt|显示所有文件(*.*)|*.*";
    public const string AudioAndAllStr = "仅显示音频(*.AIFF;*.WAV;*.MP3;*.OGG)|*.AIFF;*.WAV;*.MP3;*.OGG|显示所有文件(*.*)|*.*";

    public static readonly string[] ONLY_TU_AUDIO_FILTER = { ".jpg", ".jpeg", ".png", ".bmp", ".aiff", ".wav", ".mp3", ".ogg" };  // 只有图片和音频的过滤器


    private static readonly string[] TuExtension = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };       // 图片后缀名集合
    private static readonly string[] AudioExtension = { ".aiff", ".wav", ".mp3", ".ogg" };                   // 音频后缀名集合




    public static bool IsTu(FileInfo fileInfo)                                  // ture: 是图片
    {
        for (int i = 0; i < TuExtension.Length; i++)
        {
            if (fileInfo.Extension.ToLower().Equals(TuExtension[i]))
            {
                return true;
            }
        }
        return false;
    }


    public static bool IsAudio(FileInfo fileInfo)                               // ture: 是音频
    {
        for (int i = 0; i < AudioExtension.Length; i++)
        {
            if (fileInfo.Extension.ToLower().Equals(AudioExtension[i]))
            {
                return true;
            }
        }
        return false;
    }


    public static bool IsTuOrAudio(FileInfo fileInfo)                            // true:是图片或者音频 
    {
        for (int i = 0; i < TuExtension.Length; i++)
        {
            if (fileInfo.Extension.ToLower().Equals(TuExtension[i]))
            {
                return true;
            }
        }
        for (int i = 0; i < AudioExtension.Length; i++)
        {
            if (fileInfo.Extension.ToLower().Equals(AudioExtension[i]))
            {
                return true;
            }
        }
        return false;
    }


}
