using System;
using System.Collections.Generic;
using System.IO;
using PSPUtil.Singleton;
using PSPUtil.StaticUtil;
using UnityEngine;





public class Ctrl_UserInfo : Singleton_Mono<Ctrl_UserInfo>
{


    public string DaoRuFirstPath { get; set; }                     // 导入时 打开的路径（导入框）

    public List<string> L_FavoritesPath { get; set; }              // 收藏的路径集合


    public string ShowFirstPath { get; set; }                     // 点击导入的大项，一开始显示的路径


    public bool IsXuLieTuShowTip { get; set; }                   // 序列图是否需要提示





    //——————————————————— 大小 —————————————————
    public bool IsCanChangeSize { get; set; }                       // 是否可改大小
    public GridSizeBean[] L_XuLieTu222Size { get; private set; }               // 序列图222 Grid 大小

    public GridSizeBean[] L_JiHeXuLieTuSize { get; private set; }             // 集合序列图 Grid 大小

    public GridSizeBean[] L_TaoMingTuSize { get; private set; }               // 透明图 Grid 大小

    public GridSizeBean[] L_JPGTuSize { get; private set; }                   // Jpg图 Grid 大小

    public GridSizeBean[] L_JiHeTuSize { get; private set; }                  // 集合图 Grid 大小


    //—————————————————— 底下名称 ——————————————————



    public string[] BottomXuLeTu222Name { get; private set; }            // 底下序列图222名称
    public string[] BottomJiHeXLTName { get; private set; }              // 底下集合序列图名称
    public string[] BottomTaoMingName { get; private set; }              // 底下透明图名称
    public string[] BottomJpgName { get; private set; }                  // 底下Jpg名称
    public string[] BottomJiHeName { get; private set; }                 // 底下集合名称
    public string[] BottomAudioName { get; private set; }                // 底下音频名称




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


    // 大小
    private const string PP_IS_CHANGE_SIZE = "PP_IS_CHANGE_SIZE";
    private const string PP_XU_LIE_TU222_SIZE = "PP_XU_LIE_TU222_SIZE";
    private const string PP_JIHE_XLT_SIZES = "PP_JIHE_XLT_SIZES";
    private const string PP_TAO_MING_SIZE = "PP_TAO_MING_SIZE";
    private const string PP_JPG_SIZE = "PP_JPG_SIZE";
    private const string PP_JI_HE_SIZE = "PP_JI_HE_SIZE";

    // 底下名称
    private const string PP_BOTTOM_XU_LIE_TU222_NAME = "PP_BOTTOM_XU_LIE_TU222_NAME";
    private const string PP_BOTTOM_JIHE_XLT_NAME = "PP_BOTTOM_JIHE_XLT_NAME";
    private const string PP_BOTTOM_TAO_MING_NAME = "PP_BOTTOM_TAO_MING_NAME";
    private const string PP_BOTTOM_JPG_NAME = "PP_BOTTOM_JPG_NAME";
    private const string PP_BOTTOM_JI_HE_NAME = "PP_BOTTOM_JI_HE_NAME";
    private const string PP_BOTTOM_AUDIO_NAME = "PP_BOTTOM_AUDIO_NAME";

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
        IsCanChangeSize = ES3.Load(PP_IS_CHANGE_SIZE, false);

        InitSize();
        InitBottomName();


        pathK_ColorV = ES3.Load(PP_BIAO_JI_PATH, new Dictionary<string, ushort>());

    }



    private void InitSize()               // 初始化大小
    {

        // 序列图222
        if (!ES3.KeyExists(PP_XU_LIE_TU222_SIZE))
        {
            L_XuLieTu222Size = new GridSizeBean[5];
            L_XuLieTu222Size[0] = GetGridSizeBean(160, 160);
            L_XuLieTu222Size[1] = GetGridSizeBean(160, 160);
            L_XuLieTu222Size[2] = GetGridSizeBean(160, 160);
            L_XuLieTu222Size[3] = GetGridSizeBean(160, 160);
            L_XuLieTu222Size[4] = GetGridSizeBean(160, 160);
        }
        else
        {
            L_XuLieTu222Size = ES3.Load<GridSizeBean[]>(PP_XU_LIE_TU222_SIZE);
        }


        // 集合序列图
        if (!ES3.KeyExists(PP_JIHE_XLT_SIZES))
        {
            L_JiHeXuLieTuSize = new GridSizeBean[5];
            L_JiHeXuLieTuSize[0] = GetGridSizeBean(128, 128);
            L_JiHeXuLieTuSize[1] = GetGridSizeBean(325, 325);
            L_JiHeXuLieTuSize[2] = GetGridSizeBean(325, 325);
            L_JiHeXuLieTuSize[3] = GetGridSizeBean(325, 325);
            L_JiHeXuLieTuSize[4] = GetGridSizeBean(325, 325);
        }
        else
        {
            L_JiHeXuLieTuSize = ES3.Load<GridSizeBean[]>(PP_JIHE_XLT_SIZES);
        }


        // 透明图
        if (!ES3.KeyExists(PP_TAO_MING_SIZE))
        {
            L_TaoMingTuSize = new GridSizeBean[5];
            L_TaoMingTuSize[0] = GetGridSizeBean(128, 128);
            L_TaoMingTuSize[1] = GetGridSizeBean(128, 128);
            L_TaoMingTuSize[2] = GetGridSizeBean(128, 128);
            L_TaoMingTuSize[3] = GetGridSizeBean(64, 64);
            L_TaoMingTuSize[4] = GetGridSizeBean(128, 128);
        }
        else
        {
            L_TaoMingTuSize = ES3.Load<GridSizeBean[]>(PP_TAO_MING_SIZE);
        }

        // Jpg图
        if (!ES3.KeyExists(PP_JPG_SIZE))
        {
            L_JPGTuSize = new GridSizeBean[5];
            L_JPGTuSize[0] = GetGridSizeBean(128, 128);
            L_JPGTuSize[1] = GetGridSizeBean(128, 128);
            L_JPGTuSize[2] = GetGridSizeBean(128, 128);
            L_JPGTuSize[3] = GetGridSizeBean(128, 128);
            L_JPGTuSize[4] = GetGridSizeBean(128, 128);
        }
        else
        {
            L_JPGTuSize = ES3.Load<GridSizeBean[]>(PP_JPG_SIZE);
        }

        // 集合图
        if (!ES3.KeyExists(PP_JI_HE_SIZE))
        {
            L_JiHeTuSize = new GridSizeBean[5];
            L_JiHeTuSize[0] = GetGridSizeBean(325, 325);
            L_JiHeTuSize[1] = GetGridSizeBean(325, 325);
            L_JiHeTuSize[2] = GetGridSizeBean(325, 325);
            L_JiHeTuSize[3] = GetGridSizeBean(325, 325);
            L_JiHeTuSize[4] = GetGridSizeBean(325, 325);
        }
        else
        {
            L_JiHeTuSize = ES3.Load<GridSizeBean[]>(PP_JI_HE_SIZE);
        }
    }


    private void InitBottomName()        // 初始化底下名称
    {
        BottomXuLeTu222Name = !ES3.KeyExists(PP_BOTTOM_XU_LIE_TU222_NAME) ? new[] { "序列 1", "序列 2", "序列 3", "序列 4", "序列 5" } : ES3.Load<string[]>(PP_BOTTOM_XU_LIE_TU222_NAME);
        BottomJiHeXLTName = !ES3.KeyExists(PP_BOTTOM_JIHE_XLT_NAME) ? new[] { "特效 小", "特效 大", "序集 3", "序集 4", "序集 5" } : ES3.Load<string[]>(PP_BOTTOM_JIHE_XLT_NAME);
        BottomTaoMingName = !ES3.KeyExists(PP_BOTTOM_TAO_MING_NAME) ? new[] { "系统", "文字", "武器", "其他（小）", "其他" } : ES3.Load<string[]>(PP_BOTTOM_TAO_MING_NAME);
        BottomJpgName = !ES3.KeyExists(PP_BOTTOM_JPG_NAME) ? new[] { "jpg1", "jpg2", "jpg3", "jpp4", "jpg5" } : ES3.Load<string[]>(PP_BOTTOM_JPG_NAME);
        BottomJiHeName = !ES3.KeyExists(PP_BOTTOM_JI_HE_NAME) ? new[] { "集合 1", "集合 2", "集合 3", "集合 4", "集合 5" } : ES3.Load<string[]>(PP_BOTTOM_JI_HE_NAME);
        BottomAudioName = !ES3.KeyExists(PP_BOTTOM_AUDIO_NAME) ? new[] { "放松音乐", "BGM", "特效音效", "按键音效", "人物动作" } : ES3.Load<string[]>(PP_BOTTOM_AUDIO_NAME);


    }



    private GridSizeBean GetGridSizeBean(float x,float y)
    {
        GridSizeBean bean = new GridSizeBean();
        bean.YuanSize = new Vector2(x,y);
        bean.CurrentSize = bean.YuanSize;
        bean.ChangeValue = 0;
        return bean;
    }





    void OnApplicationQuit()
    {
        ES3.Save<string>(PP_DAORU_PATH, DaoRuFirstPath);
        ES3.Save<List<string>>(PP_FAVORITES_PATH, L_FavoritesPath);
        ES3.Save<string>(PP_SHOW_FIRST_PATH, ShowFirstPath);
        ES3.Save<bool>(PP_IS_XLT_SHOW_TIP, IsXuLieTuShowTip);
        // 大小
        ES3.Save<bool>(PP_IS_CHANGE_SIZE, IsCanChangeSize);
        ES3.Save<GridSizeBean[]>(PP_XU_LIE_TU222_SIZE, L_XuLieTu222Size);
        ES3.Save<GridSizeBean[]>(PP_JIHE_XLT_SIZES, L_JiHeXuLieTuSize);
        ES3.Save<GridSizeBean[]>(PP_TAO_MING_SIZE, L_TaoMingTuSize);
        ES3.Save<GridSizeBean[]>(PP_JPG_SIZE, L_JPGTuSize);
        ES3.Save<GridSizeBean[]>(PP_JI_HE_SIZE, L_JiHeTuSize);
        // 初始化底下名称
        ES3.Save<string[]>(PP_BOTTOM_XU_LIE_TU222_NAME, BottomXuLeTu222Name);
        ES3.Save<string[]>(PP_BOTTOM_JIHE_XLT_NAME, BottomJiHeXLTName);
        ES3.Save<string[]>(PP_BOTTOM_TAO_MING_NAME, BottomTaoMingName);
        ES3.Save<string[]>(PP_BOTTOM_JPG_NAME, BottomJpgName);
        ES3.Save<string[]>(PP_BOTTOM_JI_HE_NAME, BottomJiHeName);
        ES3.Save<string[]>(PP_BOTTOM_AUDIO_NAME, BottomAudioName);

        // 标记
        ES3.Save<Dictionary<string, ushort>>(PP_BIAO_JI_PATH, pathK_ColorV);

    }





    //——————————————————  不保存的 ——————————————————


  
    public static readonly string[] BottomXuLieTuName = { "64等边","128等边","大长方体" };  // 序列图
    public static readonly Vector2 XLTSize1 = new Vector2(64,64);
    public static readonly Vector2 XLTSize2 = new Vector2(128,128);
    public static readonly Vector2 XLTSize3 = new Vector2(300, 150);



    // 每个大小的 上下幅度范围
    public static Vector2 XuLieTu222MinMax = new Vector2(-64, 128);   // 序列图222 
    public static Vector2 JiHeXuLieTuMinMax = new Vector2(-64, 64);   // 集合序列图
    public static Vector2 TaoMingTuMinMax = new Vector2(-32, 64);     // 透明图
    public static Vector2 JpgTuMinMax = new Vector2(-32, 64);         // 普通图
    public static Vector2 JiHeTuMinMax = new Vector2(-64, 64);        // 集合图    



    // 左边的名称
    public const string XuLieTu_LeftStr = "<color=#00ff00ff>序列图</color>（固定）";
    public const string XuLieTu222_LeftStr = "<color=#00ff00ff>序列图</color>（自定）";
    public const string JiHeXuLieTu_LeftStr = "<color=#008000ff>合集序列图</color>";
    public const string TaoMingTu_LeftStr = "<color=#00ffffff>透明图</color>（.png）";
    public const string JpgTu_LeftStr = "<color=#008080ff>普通图</color>（.jpg）";
    public const string JiHeTu_LeftStr = "<color=#add8e6ff>整套合集图</color>";
    public const string Aduio_LeftStr = "音频播放";

    public const string DAO_RU_STR = "导入到 ";
    public const string ZHUANG_YI_STR = "转移到 ";
    public const string CHU_STR = " 处";






}
