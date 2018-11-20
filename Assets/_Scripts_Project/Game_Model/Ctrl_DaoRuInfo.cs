using System;
using System.Collections.Generic;
using System.IO;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;
using UnityEngine;


public class Ctrl_DaoRuInfo : Singleton_Mono<Ctrl_DaoRuInfo>
{


    public string DaoRuFirstPath { get; set; }                     // 导入时 打开的路径（导入框）

    public List<string> L_FavoritesPath { get; set; }              // 收藏的路径集合


    public string ShowFirstPath { get; set; }                     // 点击导入的大项，一开始显示的路径


    public bool IsXuLieTuShowTip { get; set; }                   // 序列图是否需要提示





    //—————————————————— 标记 ——————————————————


    public bool GetIsBiaoJi(string path ,ref MyEnumColor color)        // 获得标记
    {
        foreach (string key in pathK_ColorV.Keys)
        {
            if (key == path)
            {
                color = (MyEnumColor)pathK_ColorV[key];
                return true;
            }
        }
        return false;
    }


    public void AddBiaoJi(string path,MyEnumColor color)               // 添加标记
    {
        if (pathK_ColorV.ContainsKey(path))
        {
            pathK_ColorV[path] = (ushort)color;
        }
        else
        {
            pathK_ColorV.Add(path,(ushort)color);
        }
    }

    public void RemoveBiaoJi(string path)                              // 移除标记
    {
        if (pathK_ColorV.ContainsKey(path))
        {
            pathK_ColorV.Remove(path);
        }
        
    }




    #region 私有
    private Dictionary<string, ushort> pathK_ColorV;


    private const string PP_DAORU_PATH = "PP_DAORU_PATH";
    private const string PP_FAVORITES_PATH = "PP_FAVORITES_PATH";
    private const string PP_SHOW_FIRST_PATH = "PP_SHOW_FIRST_PATH";
    private const string PP_IS_XLT_SHOW_TIP = "PP_IS_XLT_SHOW_TIP";



    // 标记
    private const string PP_BIAO_JI_PATH = "PP_BIAO_JI_PATH";



    private string GetPath(string pp)    // 判断路径是否存在，不存在返回桌面的路径
    {
        string path = ES3.LoadStr(pp, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)  // 不存在的情况
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        return path;
    }


    #endregion


    protected override void OnAwake()
    {
        base.OnAwake();
        L_FavoritesPath = ES3.Load(PP_FAVORITES_PATH,new List<string>());
        DaoRuFirstPath = GetPath(PP_DAORU_PATH);
        ShowFirstPath = GetPath(PP_SHOW_FIRST_PATH);
        IsXuLieTuShowTip = ES3.Load(PP_IS_XLT_SHOW_TIP, true);
        pathK_ColorV = ES3.Load(PP_BIAO_JI_PATH, new Dictionary<string, ushort>());

    }



    void OnApplicationQuit()
    {
        ES3.Save<string>(PP_DAORU_PATH, DaoRuFirstPath);
        ES3.Save<List<string>>(PP_FAVORITES_PATH, L_FavoritesPath);
        ES3.Save<string>(PP_SHOW_FIRST_PATH, ShowFirstPath);
        ES3.Save<bool>(PP_IS_XLT_SHOW_TIP, IsXuLieTuShowTip);



        // 标记
        ES3.Save<Dictionary<string, ushort>>(PP_BIAO_JI_PATH, pathK_ColorV);

    }




}
