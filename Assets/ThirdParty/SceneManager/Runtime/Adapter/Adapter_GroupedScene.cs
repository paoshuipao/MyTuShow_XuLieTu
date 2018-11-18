using System;
using System.Collections.Generic;
using PSPUtil.StaticUtil;

public class Adapter_GroupedScene : IConfigurationAdapter        //分组的关卡的适配器
{
    public bool IsGroup                                          // 是否分组了
    {
        get { return true; }
    }

    public string ConfigurationName                              // 配置文件的名称
    {
        get { return m_Configuration.name; }
    }

    public string[] Levels                                       // 关卡集合
    {
        get { return m_Configuration.levels; }
    }

    public string[] Groups                                       // 组集合
    {
        get { return m_Configuration.groups; }
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

    public WorkflowActionEnum AfterGroup2Load                    // 组结束后 应该加载那个场景
    {
        get { return m_Configuration.actionAfterGroup; }
    }

    public string AfterGroupSceneName                            // 组结束后如果是加载场景,那它的名称是
    {
        get { return m_Configuration.firstScreenAfterGroup; }
    }

    public string[] GetLevelsByGroupName(string groupName)       // 通过这个组的关卡集合
    {
        if (!GroupExists(groupName))
        {
            MyLog.Red("这个组不存在 —— " + groupName);
            return null;
        }
        return groupK_LevelsV[groupName];
    }


    public string GetGroupNameByLevelName(string levelName)      // 通过关卡名来获取组名
    {
        if (!LevelExists(levelName))
        {
            MyLog.Red("这个关卡不存在 —— "+ levelName);
            return null;
        }
        return levelNameK_GuropNameV[levelName];
    }

    public bool LevelExists(string levelName)                    // 传进来的关卡是否存在
    {
        return levelNameK_GuropNameV.ContainsKey(levelName);
    }

    public bool GroupExists(string groupName)                    // 传进来的组是否存在
    {
        return groupK_LevelsV.ContainsKey(groupName);

    }


    #region 私有

    private readonly SMGroupedSceneConfiguration m_Configuration;
    private readonly Dictionary<string, string[]> groupK_LevelsV = new Dictionary<string, string[]>();
    private readonly Dictionary<string, string> levelNameK_GuropNameV = new Dictionary<string, string>();

    public Adapter_GroupedScene(SMGroupedSceneConfiguration configuration)
    {
        m_Configuration = configuration;

        for (int i = 0; i < configuration.groups.Length; i++)
        {
            int groupOffset = i;
            string group = Groups[i];

            int start = configuration.groupOffset[groupOffset];
            int end = (groupOffset + 1 == Groups.Length)
                ? Levels.Length
                : configuration.groupOffset[groupOffset + 1];
            int len = end - start;

            string[] result = new string[len];
            Array.Copy(Levels, start, result, 0, len);
            groupK_LevelsV[group] = result;

            foreach (var lvl in result)
            {
                levelNameK_GuropNameV[lvl] = group;
            }
        }
    }

    #endregion



}