using System;
using System.Collections.Generic;
using PSPUtil.StaticUtil;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class for all scene configuration editors
/// </summary>
public abstract class SMSceneConfigurationEditorBase<T> : Editor where T : SMSceneConfigurationBase
{

    public static void VerifyConfigurations()                    // 修改配置文件
    {
        bool successful = true;
        List<SMSceneConfigurationBase> configurations = SMSceneConfigurationUtil.FindConfigurations();
        Dictionary<string, string> lookup = SMSceneConfigurationUtil.FindAllUnityScene();

        HashSet<string> validScenes = new HashSet<string>();
        foreach (string scene in lookup.Keys)
        {
            validScenes.Add(scene);
        }

        SMSceneConfigurationBase activeConfiguration = null;
        int activeConfigurations = 0;
        foreach (SMSceneConfigurationBase configuration in configurations)
        {
            successful &= configuration.IsValid(validScenes);

            if (configuration.activeConfiguration)
            {
                activeConfigurations++;
                activeConfiguration = configuration;
            }
        }

        if (activeConfigurations == 0)
        {
            Debug.LogWarning("Currently no scene configuration is active. This will lead to issues when your game is " +
                             "started as Scene Manager doesn't know which scene configuration it should load. Please activate one " +
                             "of your scene configurations. To activate a scene configuration, select it in the project view " +
                             "and then click on the 'Activate' button in the inspector.");
            successful = false;
        }
        else if (activeConfigurations > 1)
        {
            Debug.LogWarning(
                "Currently more than one scene configuration is active. This will lead to issues when your game is " +
                "started as Scene Manager doesn't know which scene configuration it should load. Please select the configuration you " +
                "want to keep active in the project view and then press the 'Fix Configuration' button in the inspector. This will deactivate all other " +
                "scene configurations. To activate another scene configuration, select it in the project view " +
                "and then click on the 'Activate' button in the inspector.");
            successful = false;
        }
        else
        {
            SMSceneConfigurationUtil.SyncWithBuildSettings(activeConfiguration, lookup);
        }

        if (successful)
        {
            Debug.Log("All your scene configurations are valid.");
        }
    }


    protected string[] scenes;
    protected Dictionary<string, string> sceneLookup;
    protected string configurationGuid;

    private bool fixActiveState;
    protected string[] invalidScreens;
    protected string[] invalidLevels;

    /// <summary>
    /// Creates a new scene configuration and changes the selection to the new object
    /// </summary>
    /// <returns>
    /// The created configuration
    /// </returns>
    /// <typeparam name='C'>
    /// The type of configuration we want to create
    /// </typeparam>
    protected static C CreateConfiguration<C>() where C : SMSceneConfigurationBase
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        C configuration = ScriptableObject.CreateInstance<C>();
        AssetDatabase.CreateAsset(configuration,
            AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(C).Name + ".asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = configuration;

        if (SMSceneConfigurationUtil.FindConfigurations().Count == 1)
        {
            configuration.activeConfiguration = true;
            EditorBuildSettings.scenes = new EditorBuildSettingsScene[0];
        }

        return configuration;
    }

    public virtual void OnEnable()
    {
        sceneLookup = SMSceneConfigurationUtil.FindAllUnityScene();
        List<string> sceneNames = new List<string>(sceneLookup.Keys);
        sceneNames.Sort();
        scenes = sceneNames.ToArray();
        CheckConfiguration();
    }

    /// <summary>
    /// The scene configuration that is currently being edited.
    /// </summary>
    protected T Target
    {
        get { return (T) target; }
    }

    protected void CheckConfiguration()
    {
        invalidScreens = Array.FindAll(Target.screens, screen => !sceneLookup.ContainsKey(screen));
        invalidLevels = Array.FindAll(Target.levels, level => !sceneLookup.ContainsKey(level));
        if (Target.activeConfiguration)
        {
            fixActiveState = SMSceneConfigurationUtil.FindConfigurations().Exists(configuration =>
                configuration.activeConfiguration && configuration != Target);
        }
        UpdateGuid();
    }

    protected bool Invalid
    {
        get
        {
            return (invalidScreens != null && invalidScreens.Length > 0) ||
                   (invalidLevels != null && invalidLevels.Length > 0) || fixActiveState;
        }
    }

    private void UpdateGuid()
    {
        string guid = Guid.NewGuid().ToString();
        Target._guid = guid;
        configurationGuid = guid;
    }


    protected bool IsScreen(string scene)
    {
        return Array.IndexOf(Target.screens, scene) > -1;
    }

    protected bool IsLevel(string scene)
    {
        return Array.IndexOf(Target.levels, scene) > -1;
    }

    /// <summary>
    /// Fixes configuration issues such as multiple active configurations or removed scenes
    /// </summary>
    protected void FixConfiguration()
    {
        List<UnityEngine.Object> objects =
            new List<UnityEngine.Object>(SMSceneConfigurationUtil.FindConfigurations().ToArray());
        Undo.RegisterCompleteObjectUndo(objects.ToArray(), "Fixing configuration");
        UpdateGuid();

        FixInvalidScenes();

        if (fixActiveState)
        {
            SMSceneConfigurationUtil.EnsureActiveConfiguration(Target, false);
        }

        invalidScreens = null;
        invalidLevels = null;
        fixActiveState = false;
        EditorUtility.SetDirty(Target);
    }

    protected abstract void FixInvalidScenes();


    /// <summary>
    /// Syncs the settings back to the scene configuration when the scene configuration is modified.
    /// </summary>
    protected void SyncBuildSettingsIfRequired()
    {
        if (Target.activeConfiguration)
        {
            SMSceneConfigurationUtil.SyncWithBuildSettings(Target, sceneLookup);
        }
    }

    /// <summary>
    ///  Called before anything is changed on the scene configuration. This will register an undo state
    ///  for the scene configuration.
    /// </summary>
    /// <param name="operation">the performed operation. this is placed in the undo menu.</param>
    protected void BeforeChange(string operation)
    {
        Undo.RegisterCompleteObjectUndo(Target, operation);
        // TODO: undo for the build settings?  
    }


    protected void OpenScene(CUListData sceneListData)            // 打开这个场景 
    {
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        if (selectedScenes.Count != 1)
        {
            return;
        }
        string sceneName = selectedScenes[0];
        if (sceneLookup.ContainsKey(sceneName))
        {
            string assetPath = sceneLookup[sceneName];
            Scene currentScene = SceneManager.GetActiveScene();  // 当前场景

            if (currentScene.path.Equals(assetPath.Replace('\\', '/')))
            {
                MyLog.Green("当前就是这个场景，打开什么");
                return;
            }
            EditorSceneManager.SaveScene(currentScene);
            EditorSceneManager.OpenScene(assetPath);
        }

    }
}