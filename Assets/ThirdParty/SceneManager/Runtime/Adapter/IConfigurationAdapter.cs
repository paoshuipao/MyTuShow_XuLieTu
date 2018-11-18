public interface IConfigurationAdapter
{

    bool IsGroup { get; }                                        // 是否分组

    string ConfigurationName { get; }                            // 配置文件的名称

    string[] Levels { get; }                                     // 关卡集合

    string[] Groups { get; }                                     // 组的集合

    string[] NormalScene { get; }                                // 普通场景的集合

    string FirstScreen { get; }                                  // 标记成开始的场景

    string AfterLastLevelSceneName { get; }                      // 完成所有关卡后的场景名

    WorkflowActionEnum AfterGroup2Load { get; }                 // 组结束后 应该加载那个场景

    string AfterGroupSceneName { get; }                          // 组结束后如果是加载场景,那它的名称

    string[] GetLevelsByGroupName(string groupName);             // 获得这个组的关卡集合

    string GetGroupNameByLevelName(string levelName);            // 给个关卡名来反获得这个组的名

    bool LevelExists(string levelName);                          // 关卡是否存在


    bool GroupExists(string groupName);                          // 组是否存在        


}