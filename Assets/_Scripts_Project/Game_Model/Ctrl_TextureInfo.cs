using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;

[Serializable]
public class XuLieSaveBean
{
    public ushort TuType;
    public string KName;
    public string[] Paths;

}


public class Ctrl_TextureInfo : Singleton_Mono<Ctrl_TextureInfo> 
{

    #region 序列图

    public List<string[]> GetXunLieTuPaths(EXuLieTu index)                // 获取
    {
        List<string[]> paths = new List<string[]>();
        foreach (XuLieSaveBean bean in l_XunLieTuBean)
        {
            if (bean.TuType == (ushort)index)
            {
                paths.Add(bean.Paths);
            }
        }
        return paths;

    }


    /// <summary>
    /// 保存序列图
    /// </summary>
    /// <param name="index"></param>
    /// <param name="paths"></param>
    /// <returns>true： 保存成功   false:之前已有，保存失败</returns>
    public bool SaveXunLieTu(ushort index,string[] paths)               // 保存
    {
        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (!string.IsNullOrEmpty(kName))
        {
            kName = kName.Trim();
        }
        else
        {
            return false;
        }
        for (int i = 0; i < l_XunLieTuBean.Count; i++)
        {
            if (l_XunLieTuBean[i].KName == kName && l_XunLieTuBean[i].TuType == index)
            {
                return false;
            }
        }
        XuLieSaveBean newBean = new XuLieSaveBean();
        newBean.TuType = index;
        newBean.KName = kName;
        newBean.Paths = paths;
        l_XunLieTuBean.Add(newBean);
        return true;
    }


    public void DeleteXuLieTuSave(EXuLieTu index, string[] paths)         // 删除单个
    {
        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (string.IsNullOrEmpty(kName))
        {
            return;
        }
        kName = kName.Trim();
        XuLieTuPathV_BeanV.Remove(kName);
        for (int i = 0; i < l_XunLieTuBean.Count; i++)
        {
            XuLieSaveBean bean = l_XunLieTuBean[i];
            if (bean.KName == kName && bean.TuType == (ushort)index)
            {
                l_XunLieTuBean.RemoveAt(i);
                return;
            }
        }
    }



    public void DeleteXuLieTuOneLine(EXuLieTu index)                      // 删除一行
    {
        for (int i = 0; i < l_XunLieTuBean.Count; i++)
        {
            if (l_XunLieTuBean[i].TuType == (ushort)index)
            {
                XuLieTuPathV_BeanV.Remove(l_XunLieTuBean[i].KName);
                l_XunLieTuBean.RemoveAt(i);
            }
        }
    }

    #endregion


    #region 序列图222

    public List<string[]> GetXunLieTu222Paths(EXuLieTu222 index)                // 获取
    {
        List<string[]> paths = new List<string[]>();
        foreach (XuLieSaveBean bean in l_XunLieTu222Bean)
        {
            if (bean.TuType == (ushort)index)
            {
                paths.Add(bean.Paths);
            }
        }
        return paths;

    }


    /// <summary>
    /// 保存序列图
    /// </summary>
    /// <param name="index"></param>
    /// <param name="paths"></param>
    /// <returns>true： 保存成功   false:之前已有，保存失败</returns>
    public bool SaveXunLieTu222(ushort index, string[] paths)                   // 保存
    {

        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (!string.IsNullOrEmpty(kName))
        {
            kName = kName.Trim();
        }

        for (int i = 0; i < l_XunLieTu222Bean.Count; i++)
        {
            if (l_XunLieTu222Bean[i].KName == kName && l_XunLieTu222Bean[i].TuType == index)
            {
                return false;
            }
        }
        XuLieSaveBean newBean = new XuLieSaveBean();
        newBean.TuType = index;
        newBean.KName = kName;
        newBean.Paths = paths;
        l_XunLieTu222Bean.Add(newBean);
        return true;
    }


    public void DeleteXuLieTu222Save(EXuLieTu222 index, string[] paths)         // 删除
    {
        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (string.IsNullOrEmpty(kName))
        {
            return;
        }
        kName = kName.Trim();
        XuLieTuPathV_BeanV.Remove(kName);
        for (int i = 0; i < l_XunLieTu222Bean.Count; i++)
        {
            XuLieSaveBean bean = l_XunLieTu222Bean[i];
            if (bean.KName == kName && bean.TuType == (ushort)index)
            {
                l_XunLieTu222Bean.RemoveAt(i);
                return;
            }
        }
    }



    public void DeleteXuLieTu222OneLine(EXuLieTu222 index)                      // 删除一行
    {
        for (int i = 0; i < l_XunLieTu222Bean.Count; i++)
        {
            if (l_XunLieTu222Bean[i].TuType == (ushort)index)
            {
                XuLieTuPathV_BeanV.Remove(l_XunLieTuBean[i].KName);
                l_XunLieTu222Bean.RemoveAt(i);
            }
        }
    }

    #endregion


    #region 集合序列图 


    public List<string> GetJiHeXuLieTuPaths(EJiHeXuLieTuType index)                     // 获取
    {
        return jiHeXuLieTypeK_PathV[(ushort)index];
    }


    public bool SaveJiHeXuLieTu(ushort index,string path)                    // 保存
    {

        if (!jiHeXuLieTypeK_PathV[index].Contains(path))
        {
            jiHeXuLieTypeK_PathV[index].Add(path);
            return true;
        }
        else
        {
            return false;
        }
    }


    public void DeleteJiHeXuLieSave(EJiHeXuLieTuType index,string path)                // 删除一个
    {
        if (jiHeXuLieTypeK_PathV[(ushort)index].Contains(path))
        {
            jiHeXuLieTypeK_PathV[(ushort) index].Remove(path);
        }
    }

    public void DeleteJiHeXuLieOneLine(EJiHeXuLieTuType index)                         // 删除整行
    {
        jiHeXuLieTypeK_PathV[(ushort)index].Clear();
    }


    #endregion


    #region 透明图


    public List<string> GetTaoMingTuPaths(ETaoMingType index)                      // 获取
    {
        return taoMingTypeK_PathV[(ushort)index];
    }


    public bool SaveTaoMingTu(ushort index, string path)                     // 保存
    {

        if (!taoMingTypeK_PathV[index].Contains(path))
        {
            taoMingTypeK_PathV[index].Add(path);
            return true;
        }
        else
        {
            return false;
        }
    }


    public void DeleteTaoMingSave(ETaoMingType index, string path)                 // 删除一个
    {
        if (taoMingTypeK_PathV[(ushort)index].Contains(path))
        {
            taoMingTypeK_PathV[(ushort)index].Remove(path);
        }
    }

    public void DeleteTaoMingOneLine(ETaoMingType index)                           // 删除整行
    {
        taoMingTypeK_PathV[(ushort)index].Clear();
    }

    #endregion


    #region Jpg


    public List<string> GetJpgTuPaths(ENormalTuType index)                      // 获取
    {
        return normalTypeK_PathV[(ushort)index];
    }


    public bool SaveJpgTu(ushort index, string path)                     // 保存
    {

        if (!normalTypeK_PathV[index].Contains(path))
        {
            normalTypeK_PathV[index].Add(path);
            return true;
        }
        else
        {
            return false;
        }
    }


    public void DeleteJpgSave(ENormalTuType index, string path)                 // 删除一个
    {
        if (normalTypeK_PathV[(ushort)index].Contains(path))
        {
            normalTypeK_PathV[(ushort)index].Remove(path);
        }
    }

    public void DeleteJpgOneLine(ENormalTuType index)                           // 删除整行
    {
        normalTypeK_PathV[(ushort)index].Clear();
    }

    #endregion


    #region 集合图


    public List<string> GetJiHeTuPaths(EJiHeType index)                      // 获取
    {
        return jiHeTypeK_PathV[(ushort)index];
    }


    public bool SaveJiHeTu(ushort index, string path)                     // 保存
    {

        if (!jiHeTypeK_PathV[index].Contains(path))
        {
            jiHeTypeK_PathV[index].Add(path);
            return true;
        }
        else
        {
            return false;
        }
    }


    public void DeleteJiHeSave(EJiHeType index, string path)                 // 删除一个
    {
        if (jiHeTypeK_PathV[(ushort)index].Contains(path))
        {
            jiHeTypeK_PathV[(ushort)index].Remove(path);
        }
    }

    public void DeleteJiHeOneLine(EJiHeType index)                           // 删除整行
    {
        jiHeTypeK_PathV[(ushort)index].Clear();
    }

    #endregion


    //—————————————————— 音频 ——————————————————
    public List<string> GetAudioPaths(EAudioType index)                        // 获取
    {
        return audioTypeK_PathV[(ushort)index];
    }

    public bool SaveAudio(ushort index, string savePath)                       // 保存
    {
        savePath = savePath.Replace("\\", "/");
        if (!audioTypeK_PathV[index].Contains(savePath))
        {
            audioTypeK_PathV[index].Add(savePath);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DeleteAudioSave(EAudioType index, string savePath)             // 删除
    {
        savePath = savePath.Replace("\\", "/");
        if (audioTypeK_PathV[(ushort)index].Contains(savePath))
        {
            audioTypeK_PathV[(ushort)index].Remove(savePath);
        }
    }


    public void DeleteAudioOneLine(EAudioType index)                           // 删除整行
    {
        audioTypeK_PathV[(ushort)index].Clear();
    }


    #region 私有

    // 序列图
    private List<XuLieSaveBean> l_XunLieTuBean { get; set; }
    private const string PP_XUN_LIE_TU = "PP_XUN_LIE_TU";
    private const string XunLieTuFile = "XuLieTu.es3";


    // 序列图222
    private List<XuLieSaveBean> l_XunLieTu222Bean { get; set; }
    private const string PP_XUN_LIE_TU222 = "PP_XUN_LIE_TU222";
    private const string XunLieTuFile222 = "XuLieTu222.es3";


    // 集合序列图
    private Dictionary<ushort, List<string>> jiHeXuLieTypeK_PathV { get; set; }
    private const string PP_JIHE_XULIE_TU = "PP_JIHE_XULIE_TU";
    private const string JiHeXuLieTuFile = "JiHeXuLieTu.es3";

    // 透明图
    private Dictionary<ushort,List<string>> taoMingTypeK_PathV { get; set; }
    private const string PP_TAO_MING_TU = "PP_TAO_MING_TU";
    private const string TaoMingTuFile = "TaoMingTu.es3";

    // Jpg
    private Dictionary<ushort, List<string>> normalTypeK_PathV { get; set; }
    private const string PP_JPG_TU = "PP_JPG_TU";
    private const string JpgTuFile = "JpgTu.es3";

    // 集合图
    private Dictionary<ushort, List<string>> jiHeTypeK_PathV { get; set; }
    private const string PP_JI_HE_TU = "PP_JI_HE_TU";
    private const string JiHeTuFile = "JiHeTu.es3";



    // 音频
    private Dictionary<ushort, List<string>> audioTypeK_PathV { get; set; }
    private const string PP_AUDIO = "PP_AUDIO";
    private const string AudioFile = "AudioFile.es3";



    #endregion

    public bool IsInitFinish =false;


    public void OnInitData()
    {
        // 序列图
        l_XunLieTuBean = ES3.Load(PP_XUN_LIE_TU, XunLieTuFile, new List<XuLieSaveBean>());

        // 序列图222
        l_XunLieTu222Bean = ES3.Load(PP_XUN_LIE_TU222, XunLieTuFile222, new List<XuLieSaveBean>());


        #region 集合序列图

        if (!ES3.KeyExists(PP_JIHE_XULIE_TU, JiHeXuLieTuFile))
        {
            jiHeXuLieTypeK_PathV = new Dictionary<ushort, List<string>>();
            foreach (EJiHeXuLieTuType type in Enum.GetValues(typeof(EJiHeXuLieTuType)))
            {
                jiHeXuLieTypeK_PathV.Add((ushort)type, new List<string>());
            }
        }
        else
        {
            jiHeXuLieTypeK_PathV = ES3.Load(PP_JIHE_XULIE_TU, JiHeXuLieTuFile, new Dictionary<ushort, List<string>>());
        }

        #endregion

        #region 透明图

        if (!ES3.KeyExists(PP_TAO_MING_TU, TaoMingTuFile))
        {
            taoMingTypeK_PathV = new Dictionary<ushort, List<string>>();
            foreach (ETaoMingType type in Enum.GetValues(typeof(ETaoMingType)))
            {
                taoMingTypeK_PathV.Add((ushort)type,new List<string>());
            }
        }
        else
        {
            taoMingTypeK_PathV = ES3.Load(PP_TAO_MING_TU, TaoMingTuFile, new Dictionary<ushort, List<string>>());
        }

        #endregion

        #region Jpg

        if (!ES3.KeyExists(PP_JPG_TU, JpgTuFile))
        {
            normalTypeK_PathV = new Dictionary<ushort, List<string>>();
            foreach (ENormalTuType type in Enum.GetValues(typeof(ENormalTuType)))
            {
                normalTypeK_PathV.Add((ushort)type, new List<string>());
            }
        }
        else
        {
            normalTypeK_PathV = ES3.Load(PP_JPG_TU, JpgTuFile, new Dictionary<ushort, List<string>>());
        }

        #endregion

        #region 集合图

        if (!ES3.KeyExists(PP_JI_HE_TU, JiHeTuFile))
        {
            jiHeTypeK_PathV = new Dictionary<ushort, List<string>>();
            foreach (EJiHeType type in Enum.GetValues(typeof(EJiHeType)))
            {
                jiHeTypeK_PathV.Add((ushort)type, new List<string>());
            }
        }
        else
        {
            jiHeTypeK_PathV = ES3.Load(PP_JI_HE_TU, JiHeTuFile, new Dictionary<ushort, List<string>>());
        }

        #endregion

        // 音频
        if (!ES3.KeyExists(PP_AUDIO, AudioFile))
        {
            audioTypeK_PathV = new Dictionary<ushort, List<string>>();
            foreach (EAudioType type in Enum.GetValues(typeof(EAudioType)))
            {
                audioTypeK_PathV.Add((ushort)type, new List<string>());
            }
        }
        else
        {
            audioTypeK_PathV = ES3.Load(PP_AUDIO, AudioFile, new Dictionary<ushort, List<string>>());
        }

        IsInitFinish = true;

    }



    void OnApplicationQuit()
    {
        // 退出时保存
        ES3.Save<List<XuLieSaveBean>>(PP_XUN_LIE_TU, l_XunLieTuBean, XunLieTuFile);
        ES3.Save<List<XuLieSaveBean>>(PP_XUN_LIE_TU222, l_XunLieTu222Bean, XunLieTuFile222);
        ES3.Save<Dictionary<ushort, List<string>>>(PP_JIHE_XULIE_TU, jiHeXuLieTypeK_PathV, JiHeXuLieTuFile);
        ES3.Save<Dictionary<ushort, List<string>>>(PP_TAO_MING_TU, taoMingTypeK_PathV, TaoMingTuFile);
        ES3.Save<Dictionary<ushort, List<string>>>(PP_JPG_TU, normalTypeK_PathV, JpgTuFile);
        ES3.Save<Dictionary<ushort, List<string>>>(PP_JI_HE_TU, jiHeTypeK_PathV, JiHeTuFile);
        ES3.Save<Dictionary<ushort, List<string>>>(PP_AUDIO, audioTypeK_PathV, AudioFile);


    }



    //——————————————— 用于搜索—————————————————————


    private static readonly Dictionary<string, ResultBean[]> XuLieTuPathV_BeanV = new Dictionary<string, ResultBean[]>();   // 所有的序列图



    public static Dictionary<string, ResultBean[]> SearchXLT(string inputStr)         // 搜索序列图
    {

        Dictionary<string, ResultBean[]> resDir = new Dictionary<string, ResultBean[]>();
        foreach (string kName in XuLieTuPathV_BeanV.Keys)
        {
            if (kName.ToLower().Contains(inputStr.ToLower()))
            {
                resDir.Add(kName,XuLieTuPathV_BeanV[kName]);
            }
        }
        return resDir;
    }

    
    public static void AddXuLieTu(ResultBean[] resBeans)        // 添加进来 
    {
        string kName = Path.GetFileNameWithoutExtension(resBeans[0].File.FullName);
        if (!string.IsNullOrEmpty(kName))
        {
            kName = kName.Trim();
            ushort addIndex = 0;
            while (XuLieTuPathV_BeanV.ContainsKey(kName))
            {
                addIndex++;
                kName += addIndex;
            }
            XuLieTuPathV_BeanV.Add(kName, resBeans);

        }

    }





}
