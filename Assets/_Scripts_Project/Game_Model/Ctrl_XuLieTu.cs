using System.Collections.Generic;
using System.IO;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;
using UnityEngine;



public class Ctrl_XuLieTu : Singleton_Mono<Ctrl_XuLieTu>
{


    public void InitData()
    {
        // 先初始化 indexK_KNameV
        for (ushort i = 0; i < 8; i++)
        {
            string fileName = FIleNames[i];   // 文件名
            Dictionary<ushort, Dictionary<string, string[]>> bottomK_pathsV= new Dictionary<ushort, Dictionary<string, string[]>>();
            for (ushort j = 0; j < 5; j++)
            {
                string keyName = BottomKeyName[j];
                Dictionary<string, string[]> kNameK_PathsV = ES3.Load(keyName, fileName,new Dictionary<string, string[]>());
                bottomK_pathsV.Add(j,kNameK_PathsV);
            }
            indexK_KNameV.Add(i, bottomK_pathsV);
        }
        IsInitFinish = true;
    }




    public List<string[]> GetPaths(ushort bigIndex,ushort bottomIndex)                            // 获取
    {

        return new List<string[]>(indexK_KNameV[bigIndex][bottomIndex].Values);
    }



    public bool Save(ushort bigIndex,ushort bottomIndex,string[] paths)            // 保存,成功返回 true
    {
        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (string.IsNullOrEmpty(kName))
        {
            return false;
        }

        if (indexK_KNameV[bigIndex][bottomIndex].ContainsKey(kName))
        {
            return false;
        }

        indexK_KNameV[bigIndex][bottomIndex].Add(kName,paths);

        return true;

    }


    public void DeleteOne(ushort bigIndex, ushort bottomIndex, string[] paths)        // 删除单个 
    {
        string kName = Path.GetFileNameWithoutExtension(paths[0]);
        if (string.IsNullOrEmpty(kName))
        {
            MyLog.Red("不可能吧？");
            return;
        }
        indexK_KNameV[bigIndex][bottomIndex].Remove(kName);
    }



    #region 私有

    public bool IsInitFinish = false;
    private readonly Dictionary<ushort,Dictionary<ushort,Dictionary<string,string[]>>> indexK_KNameV = new Dictionary<ushort, Dictionary<ushort, Dictionary<string, string[]>>>();



    private static readonly string[] FIleNames = new[]
    {
        "ItemFile_0.es3", "ItemFile_1.es3", "ItemFile_2.es3", "ItemFile_3.es3",
        "ItemFile_4.es3", "ItemFile_5.es3", "ItemFile_6.es3", "ItemFile_7.es3",
    };


    private static readonly string[] BottomKeyName = new[]
    {
        "Item0", "Item1",  "Item2", "Item3", "Item4",
    };

    #endregion



    void OnApplicationQuit()
    {

        for (ushort i = 0; i < 8; i++)
        {
            string fileName = FIleNames[i];   // 文件名
            for (ushort j = 0; j < 5; j++)
            {
                string keyName = BottomKeyName[j];
                ES3.Save<Dictionary<string,string[]>>(keyName, indexK_KNameV[i][j],fileName);
            }

        }


    }





}
