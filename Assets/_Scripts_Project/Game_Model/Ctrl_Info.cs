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



public class Ctrl_Info : Singleton_Mono<Ctrl_Info>
{


    public void InitData()
    {
        // 左边 Item 名称
        LeftItemNames = ES3.Load(PP_LEFT_NAME, new[] { "等边（小）", "等边（中）", "等边（中）", "等边（大）", "等边（大）", "等边（大）", "横", "竖" });


        // 底下名称
        if (ES3.KeyExists(PP_BOTTOM_NAMES))
        {
            BottomName = ES3.Load<string[][]>(PP_BOTTOM_NAMES);
        }
        else
        {
            BottomName = new string[8][];
            BottomName[0] = new[] { "64", "小2", "小3", "小4", "小5" };
            BottomName[1] = new[] { "128", "中2", "中3", "中4", "中5" };
            BottomName[2] = new[] { "150", "中2", "中2", "中2", "中2" };
            BottomName[3] = new[] { "230", "大2", "大3", "大4", "大5" };
            BottomName[4] = new[] { "230", "大2", "大3", "大4", "大5" };
            BottomName[5] = new[] { "230", "大2", "大3", "大4", "大5" };
            BottomName[6] = new[] { "2倍小", "2倍大", "3倍小", "3倍大", "4倍" };
            BottomName[7] = new[] { "2倍小", "2倍大", "3倍小", "3倍大", "4倍" };

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
                GetSizeBean(64, 128), GetSizeBean(128, 256), GetSizeBean(40, 120), GetSizeBean(80, 240), GetSizeBean(64, 256),
            };
            l_GridSize[7] = new[]
            {
                GetSizeBean(128, 64), GetSizeBean(256, 128), GetSizeBean(120, 40), GetSizeBean(240, 80), GetSizeBean(256, 64),
            };
        }


    }



    public string[] LeftItemNames { get; private set; }          // 总 左边Item

    public string[][] BottomName { get; private set; }           // 底下名称

    public GridSizeBean[][] l_GridSize { get; private set; }     // Grid 大小





    #region 私有

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


    #endregion




    void OnApplicationQuit()
    {

        ES3.Save<string[]>(PP_LEFT_NAME, LeftItemNames);
        ES3.Save<string[][]>(PP_BOTTOM_NAMES, BottomName);
        ES3.Save<GridSizeBean[][]>(PP_BOTTOM_SIZES, l_GridSize);

    }








}
