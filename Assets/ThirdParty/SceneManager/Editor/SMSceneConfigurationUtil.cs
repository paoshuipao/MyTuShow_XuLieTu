using System;
using System.Collections.Generic;
using System.IO;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 用于处理场景配置的实用工具类
/// </summary>
public class SMSceneConfigurationUtil
{

    /// <summary>
    /// 查找所有 *.unity 的场景
    /// </summary>
    /// <param name="isShowAll">是否显示所有</param>
    /// <returns></returns>
    public static Dictionary<string, string> FindAllUnityScene(bool isShowAll=false)
    {
        string[] untiyFileFullPaths= Directory.GetFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories);

        Dictionary<string, string> nameK_AssetPathV = new Dictionary<string, string>();

        foreach (string fullPath in untiyFileFullPaths)
        {
            if (!isShowAll)
            {
                if (fullPath.Contains("\\_AssetBundleResources") || fullPath.Contains("\\Plugins"))      // 不包含需要打包出去的 AssetBundle 包中的场景
                {
                    continue;
                }
            }
            string name = MyAssetUtil.GetFileNameByFullNameNoSuffix(fullPath);
            string assetPath = MyAssetUtil.GetAssetsBackPath(fullPath);
            if (nameK_AssetPathV.ContainsKey(name))
            {
                MyLog.Red("有相同名字的场景，修改一下");
            }
            else
            {
                nameK_AssetPathV.Add(name,assetPath);
            }
        }
        return nameK_AssetPathV;
    }



    /// <summary>
    /// 返回当前项目中的所有场景配置
    /// </summary>
    public static List<SMSceneConfigurationBase> FindConfigurations()
    {
        List<SMSceneConfigurationBase> allConfigurations = new List<SMSceneConfigurationBase>();
        
        string[] assetFullPaths = Directory.GetFiles(Application.dataPath, "*.asset", SearchOption.AllDirectories);

        foreach (string fullPath in assetFullPaths)
        {
            string assetPath = MyAssetUtil.GetAssetsBackPath(fullPath);
            SMSceneConfigurationBase configuration = AssetDatabase.LoadAssetAtPath(assetPath, typeof(SMSceneConfigurationBase)) as SMSceneConfigurationBase;
            if (configuration != null)
            {
                allConfigurations.Add(configuration);
            }
        }
        return allConfigurations;
    }



    /// <summary>
    /// Ensures that the given configuration is activated. If it is already the active configuration this method
    /// will do nothing. Otherwise it will activate the given configuration and deactivate any other active
    /// configuration.
    /// </summary>
    /// <param name="configurationToBeActivated">
    /// A <see cref="SMSceneConfigurationBase"/> that is to be activated.
    /// </param>
    public static void EnsureActiveConfiguration(SMSceneConfigurationBase configurationToBeActivated, bool registerUndo)
    {
        List<SMSceneConfigurationBase> allConfigurations = FindConfigurations();
        if (registerUndo)
        {
            Undo.RegisterCompleteObjectUndo(allConfigurations.ToArray(), "Activate scene configuration");
        }

        foreach (SMSceneConfigurationBase configuration in allConfigurations)
        {
            configuration.activeConfiguration = configuration == configurationToBeActivated;
            EditorUtility.SetDirty(configuration);
        }
    }

    /// <summary>
    /// Syncronizes the build settings so that they resemble the list of scenes which are in the currently
    /// active scene configuration.
    /// </summary>	
    public static void SyncWithBuildSettings(SMSceneConfigurationBase configuration, Dictionary<string, string> lookup)
    {
        List<EditorBuildSettingsScene> newScenes = new List<EditorBuildSettingsScene>();

        if (!String.IsNullOrEmpty(configuration.firstScreen))
        {
            if (lookup.ContainsKey(configuration.firstScreen))
            {
                newScenes.Add(new EditorBuildSettingsScene(lookup[configuration.firstScreen], true));
            }
        }

        foreach (string screen in configuration.screens)
        {
            if (screen != configuration.firstScreen && lookup.ContainsKey(screen))
            {
                newScenes.Add(new EditorBuildSettingsScene(lookup[screen], true));
            }
        }

        foreach (string level in configuration.levels)
        {
            if (level != configuration.firstScreen && lookup.ContainsKey(level))
            {
                newScenes.Add(new EditorBuildSettingsScene(lookup[level], true));
            }
        }

        EditorBuildSettings.scenes = newScenes.ToArray();
    }









}