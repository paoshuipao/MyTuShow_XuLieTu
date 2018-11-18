using UnityEngine;

public class Ctrl_Info : ModelBase<Ctrl_Info>
{


    public string[] LeftItemNames { get; set; }        // 总 左边Item

    public string[][] BottomName { get; set; }         // 底下名称


    protected override void InitData()
    {
        LeftItemNames = Load(PP_LEFT_NAME, new[] {"等边（小）", "等边（中）", "等边（中）", "等边（大）", "等边（大）", "等边（大）" , "横", "竖" });

        if (IsExit(PP_BOTTOM_NAME))
        {
            BottomName = Load<string[][]>(PP_BOTTOM_NAME);
        }
        else
        {
            BottomName = new string[8][];
            BottomName[0] = new[] {"64", "小2", "小3", "小4", "小5" };
            BottomName[1] = new[] {"128", "中2", "中3", "中4", "中5" };
            BottomName[2] = new[] {"150", "中2", "中2", "中2", "中2" };
            BottomName[3] = new[] {"230", "大2", "大3", "大4", "大5" };
            BottomName[4] = new[] {"230", "大2", "大3", "大4", "大5" };
            BottomName[5] = new[] {"230", "大2", "大3", "大4", "大5" };
            BottomName[6] = new[] { "2倍小", "2倍大", "3倍小", "3倍大", "横"};
            BottomName[7] = new[] { "2倍小", "2倍大", "3倍小", "3倍大", "竖"};

        }

    }

    protected override void SaveData()
    {
        Save(PP_LEFT_NAME, LeftItemNames);
        Save(PP_BOTTOM_NAME, BottomName);

    }



    #region 私有

    private const string PP_LEFT_NAME = "PP_LEFT_NAME";
    private const string PP_BOTTOM_NAME = "PP_BOTTOM_NAME";

    protected override string GetFileName()
    {
        return "InfoFile";
    }

    #endregion

}
