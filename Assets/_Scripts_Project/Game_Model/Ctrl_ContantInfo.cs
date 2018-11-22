using System;
using PSPUtil.Singleton;
using UnityEngine;


[Serializable]
public class GridSizeBean
{
    public Vector2 YuanSize;           // 原来大小
    public Vector2 CurrentSize;        // 当前大小
    public int ChangeValue;            // 改变的大小

}


public class Ctrl_ContantInfo : Singleton_Mono<Ctrl_ContantInfo>
{


    public void InitData()
    {
        // 左边 Item 名称
        if (ES3.KeyExists(PP_LEFT_NAME))
        {
            LeftItemNames = ES3.Load<string[]>(PP_LEFT_NAME);
        }
        else
        {
            LeftItemNames = new string[8];
            LeftItemNames[0] = "<color=white>" + LeftName[0] + "</color>";
            LeftItemNames[1] = "<color=green>" + LeftName[1] + "</color>";
            LeftItemNames[2] = "<color=green>" + LeftName[2] + "</color>";
            LeftItemNames[3] = "<color=blue>" + LeftName[3] + "</color>";
            LeftItemNames[4] = "<color=blue>" + LeftName[4] + "</color>";
            LeftItemNames[5] = "<color=blue>" + LeftName[5] + "</color>";
            LeftItemNames[6] = "<color=white>" + LeftName[6] + "</color>";
            LeftItemNames[7] = "<color=white>" + LeftName[7] + "</color>";
        }


        // 底下名称
        if (ES3.KeyExists(PP_BOTTOM_NAMES))
        {
            BottomName = ES3.Load<string[][]>(PP_BOTTOM_NAMES);
        }
        else
        {
            BottomName = new string[8][];
            BottomName[0] = new[] { Quan_Quan, Xin_Gun_Dian, XI_TONG_WenZi, DongWu, KUANG };
            BottomName[1] = new[] { Quan_Quan, Xin_Gun_Dian, XI_TONG_WenZi, DongWu, KUANG };
            BottomName[2] = new[] { Quan_Quan, Xin_Gun_Dian, XI_TONG_WenZi, "水、火", KUANG };
            BottomName[3] = new[] { Quan_Quan, Xin_Gun_Dian, XI_TONG_WenZi, DongWu, KUANG };


            BottomName[4] = new[] { "加状态", "死亡特效", "道具", "230", "230" };
            BottomName[5] = new[] { "水、火", "光、暗", "风、雷", "土、木", "五色" };

            BottomName[6] = new[] { "128 x 64", "256 x 128", XI_TONG_WenZi, "240 x 80", "256 x 64" };
            BottomName[7] = new[] { "64 x 128", "128 x 256", XI_TONG_WenZi, "80 x 240", "64 x 256" };

        }


        // Grid 大小

        if (ES3.KeyExists(PP_BOTTOM_SIZES))
        {
            l_GridSize = ES3.Load<GridSizeBean[][]>(PP_BOTTOM_SIZES);
        }
        else
        {
            l_GridSize = new GridSizeBean[8][];
            l_GridSize[0] = new[]
            {
                GetSizeBean(64, 64), GetSizeBean(64, 64), GetSizeBean(64, 64), GetSizeBean(64, 64), GetSizeBean(64, 64),
            };
            l_GridSize[1] = new[]
            {
                GetSizeBean(128, 128), GetSizeBean(128, 128), GetSizeBean(128, 128), GetSizeBean(128, 128), GetSizeBean(128, 128),
            };
            l_GridSize[2] = new[]
            {
                GetSizeBean(150, 150), GetSizeBean(150, 150), GetSizeBean(150, 150), GetSizeBean(150, 150), GetSizeBean(150, 150),
            };
            l_GridSize[3] = new[]
            {
                GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230),
            };
            l_GridSize[4] = new[]
            {
                GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230),
            };
            l_GridSize[5] = new[]
            {
                GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230), GetSizeBean(230, 230),
            };
            l_GridSize[6] = new[]
            {
                GetSizeBean(128, 64), GetSizeBean(256, 128), GetSizeBean(256, 128), GetSizeBean(240, 80), GetSizeBean(256, 64),
            };
            l_GridSize[7] = new[]
            {
                GetSizeBean(64, 128), GetSizeBean(128, 256), GetSizeBean(128, 256), GetSizeBean(80, 240), GetSizeBean(64, 256),
            };
   
        }

    }



    public void ChangeLeftItemNameColor(ushort index,string colorStr)          // 改变左边Item颜色
    {
        LeftItemNames[index] = "<color="+ colorStr + ">" + LeftName[index] + "</color>";
    }


    public string[] LeftItemNames { get; private set; }          // 总 左边Item

    public string[][] BottomName { get; private set; }           // 底下名称

    public GridSizeBean[][] l_GridSize { get; private set; }     // Grid 大小



    #region 私有


    private readonly string[] LeftName = { "64（小）", "128（中）", "150（中）", "230（大）", "230（大）", "230（元素）", "横", "竖" };


    private const string PP_LEFT_NAME = "PP_LEFT_NAME";
    private const string PP_BOTTOM_NAMES = "PP_BOTTOM_NAMES";
    private const string PP_BOTTOM_SIZES = "PP_BOTTOM_SIZES";


    private GridSizeBean GetSizeBean(float x, float y)
    {
        GridSizeBean bean = new GridSizeBean();
        bean.YuanSize = new Vector2(x, y);
        bean.CurrentSize = bean.YuanSize;
        bean.ChangeValue = 0;
        return bean;
    }


    private const string Quan_Quan = "<color=white>圆圈</color>";                // 白色
    private const string Xin_Gun_Dian = "<color=yellow>星光点</color>";          // 黄色
    private const string XI_TONG_WenZi = "<color=#00ff00ff>系统、文字</color>";  // 绿色
    private const string KUANG = "<color=#ffa500ff>边框</color>";                // 橙色
    private const string DongWu = "<color=#add8e6ff>动物</color>";               // 浅蓝



    #endregion




    void OnApplicationQuit()
    {
        ES3.Save<string[]>(PP_LEFT_NAME, LeftItemNames);
        ES3.Save<string[][]>(PP_BOTTOM_NAMES, BottomName);
        ES3.Save<GridSizeBean[][]>(PP_BOTTOM_SIZES, l_GridSize);
    }



}
