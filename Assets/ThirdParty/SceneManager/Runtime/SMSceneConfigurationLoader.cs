/*using PSPUtil.StaticUtil;
using UnityEngine;


public class SMSceneConfigurationLoader

{
    /// <summary>
    /// 加载选中的场景配置文件
    /// </summary>
    /// <returns></returns>
    public static IConfigurationAdapter LoadActiveConfiguration()
    {
        Object[] resources = Resources.LoadAll(Defines_Resources.SceneConfig, typeof(SMSceneConfiguration));

        foreach (Object resource in resources)

        {
            SMSceneConfiguration configuration = (SMSceneConfiguration) resource;

            if (configuration.activeConfiguration)

            {
                return new Adapter_Scene(configuration);
            }
        }


        resources = Resources.LoadAll(Defines_Resources.SceneConfig, typeof(SMGroupedSceneConfiguration));

        foreach (Object resource in resources)

        {
            var configuration = (SMGroupedSceneConfiguration) resource;

            if (configuration.activeConfiguration)

            {
                return new Adapter_GroupedScene(configuration);
            }
        }

        MyLog.Red("没有找到给激活的场景配置文件 —— " + Defines_Resources.SceneConfig);

        return null;
    }
}*/