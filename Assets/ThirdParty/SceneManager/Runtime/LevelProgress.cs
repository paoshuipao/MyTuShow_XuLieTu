using UnityEngine;

public class LevelProgress 
{
    private const string LAST_LEVEL = "LastLevel";
    private const string CURRENT_LEVEL = "CurrentLevel";
    private const string HAS_ALL_FINISH = "hasAllFinish";
    private const string GROUP_STATE = "GS.";
    private const string LEVEL_STATE = "LS.";


    public string LastLevelName                                                // 最后玩着的那一关的名称
    {
        get { return PlayerPrefs.GetString(m_ConfigurationName + LAST_LEVEL, ""); }
        set { PlayerPrefs.SetString(m_ConfigurationName + LAST_LEVEL, value); }
    }

    public string CurrentLevelName                                             // 当前关卡的名称
    {
        get { return PlayerPrefs.GetString(m_ConfigurationName + CURRENT_LEVEL, ""); }
        set { PlayerPrefs.SetString(m_ConfigurationName + CURRENT_LEVEL, value); }
    }

    public void ResetLastLevel()                                               // 重置游戏进度
    {
        PlayerPrefs.DeleteKey(m_ConfigurationName + LAST_LEVEL);
        PlayerPrefs.DeleteKey(m_ConfigurationName + CURRENT_LEVEL);
        HasAllLevelFinish = false;


    }

    public bool IsFristPlay                                                    // 是否第一次玩
    {
        get
        {
            return !PlayerPrefs.HasKey(m_ConfigurationName + LAST_LEVEL);
        }

    }


    public bool HasAllLevelFinish                                              // 是否全部关卡都通关了
    {
        get
        {
            return PlayerPrefs.GetInt(m_ConfigurationName + HAS_ALL_FINISH, 0)==1;
        }
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt(m_ConfigurationName + HAS_ALL_FINISH,1);
            }
            else
            {
                PlayerPrefs.SetInt(m_ConfigurationName + HAS_ALL_FINISH,0);
            }
        }
    }


    public GroupStatusEnum GetGroupStatus(string groupName)                    // 获取组的状态
    {
        return (GroupStatusEnum)PlayerPrefs.GetInt(m_ConfigurationName + GROUP_STATE + groupName, (int)GroupStatusEnum.New);
    }


    public void SetGroupStatus(string groupName, GroupStatusEnum groupStatus)  // 设置组的状态
    {
        PlayerPrefs.SetInt(m_ConfigurationName + GROUP_STATE + groupName, (int)groupStatus);
    }


    public LevelStatusEnum GetLevelStatus(string levelName)                    // 获取关卡的状态
    {
        return (LevelStatusEnum) PlayerPrefs.GetInt(m_ConfigurationName + LEVEL_STATE + levelName, (int) LevelStatusEnum.New);
    }

    public void SetLevelStatus(string levelName, LevelStatusEnum levelStatus)  // 设置关卡的状态
    {
        PlayerPrefs.SetInt(m_ConfigurationName + LEVEL_STATE + levelName, (int) levelStatus);
    }





    #region 私有

    private readonly string m_ConfigurationName;

    public LevelProgress(string configurationName)
    {
        m_ConfigurationName = configurationName + "_";
    }

    #endregion



}