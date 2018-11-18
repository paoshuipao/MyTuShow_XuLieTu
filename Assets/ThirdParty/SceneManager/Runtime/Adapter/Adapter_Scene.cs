using System;
using PSPUtil.StaticUtil;

public class Adapter_Scene : IConfigurationAdapter               //不分组的关卡的适配器
{
    public bool IsGroup                                          // 是否分组了
    {
        get { return false; }
    }

    public string ConfigurationName                              // 配置文件的名称
    {
        get { return m_Configuration.name; }
    }

    public string[] Levels                                       // 关卡集合
    {
        get { return m_Configuration.levels; }
    }

    public string[] Groups                                       // 组的集合
    {
        get { return DefaultGroups; }
    }

    public string[] NormalScene                                  // 普通场景的集合
    {
        get { return m_Configuration.screens; }
    }

    public string FirstScreen                                    // 标记成开始的场景
    {
        get { return m_Configuration.firstScreen; }
    }

    public string AfterLastLevelSceneName                        // 完成所有关卡后的场景名
    {
        get { return m_Configuration.firstScreenAfterLevel; }
    }

    public WorkflowActionEnum AfterGroup2Load                    // 组结束后那就加载最后的场景咯
    {
        get { return WorkflowActionEnum.LoadScreen; }
    }

    public string AfterGroupSceneName                            // 那就是最后的场景名    
    {
        get { return AfterLastLevelSceneName; }
    }

    public string[] GetLevelsByGroupName(string groupName)       // 不管传什么进来，都是返回关卡的集合啦
    {
        if (!GroupExists(groupName))
        {
            MyLog.Red("这个组不存在 —— " + groupName);
            return null;
        }
        return Levels;
    }

    public string GetGroupNameByLevelName(string levelName)      // 不管传什么进来，都是返回默认的组名称
    {
        if (!LevelExists(levelName))
        {
            MyLog.Red("这个关卡不存在 —— " + levelName);
            return null;
        }
        return DefaultGroupName;
    }


    public bool LevelExists(string levelName)                    // 传进来的关卡是否存在
    {
        return Array.IndexOf(Levels, levelName) != -1;

    }

    public bool GroupExists(string groupName)                    // 传进来的组是否存在
    {
        return DefaultGroupName.Equals(groupName);
    }


    #region 私有

    private static string DefaultGroupName = "default";
    private static readonly string[] DefaultGroups = { DefaultGroupName };
    private readonly SMSceneConfiguration m_Configuration;

    public Adapter_Scene(SMSceneConfiguration configuration)
    {
        this.m_Configuration = configuration;
    }


    #endregion



}