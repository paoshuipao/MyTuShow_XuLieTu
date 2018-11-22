using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Expansion_List  
{

    public static string[] ToFullPaths(this List<FileInfo> fileInfos)               // 转成全路径集合
    {
        string[] res = new string[fileInfos.Count];

        for (int i = 0; i < fileInfos.Count; i++)
        {
            res[i] = fileInfos[i].FullName;
        }
        return res;
    }

    public static string[] ToFullPaths(this List<ResultBean> resultBeans)           // 转成全路径集合
    {
        string[] res = new string[resultBeans.Count];

        for (int i = 0; i < resultBeans.Count; i++)
        {
            res[i] = resultBeans[i].File.FullName;
        }
        return res;
    }


    public static string[] ToFullPaths(this ResultBean[] resultBeans)              // 转成全路径集合
    {
        string[] res = new string[resultBeans.Length];

        for (int i = 0; i < resultBeans.Length; i++)
        {
            res[i] = resultBeans[i].File.FullName;
        }
        return res;
    }


    public static Sprite[] ToSprites(this ResultBean[] resultBeans)                // 转成全图片集合
    {
        Sprite[] sps = new Sprite[resultBeans.Length];
        for (int i = 0; i < resultBeans.Length; i++)
        {
            sps[i] = resultBeans[i].SP;
        }
        return sps;
    }


    public static Sprite[] ToSprites(this List<ResultBean> resultBeans)                // 转成全图片集合
    {
        Sprite[] sps = new Sprite[resultBeans.Count];
        for (int i = 0; i < resultBeans.Count; i++)
        {
            sps[i] = resultBeans[i].SP;
        }
        return sps;
    }


}
