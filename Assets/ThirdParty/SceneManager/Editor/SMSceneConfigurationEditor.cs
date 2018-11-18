using System;
using System.Collections.Generic;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SMSceneConfiguration))]                     // 编辑简单场景配置文件
public class SMSceneConfigurationEditor : SMSceneConfigurationEditorBase<SMSceneConfiguration>
{

    [MenuItem("Assets/Create/Scene 配置文件")]
    public static void AddConfiguration()
    {
        CreateConfiguration<SMSceneConfiguration>();
    }

    public override void OnInspectorGUI()                        // 画 GUI
    {
        ProDraw();
        if (Target.activeConfiguration)
        {
            GUILayout.Label("游戏使用该配置".AddYellow());
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("游戏不是使用这个配置");
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("使用该配置"))
            {
                SMSceneConfigurationUtil.EnsureActiveConfiguration(Target, true);
                SyncBuildSettingsIfRequired();
            }
            EditorGUILayout.EndHorizontal();
        }

        MyCreate.Box(() =>
        {
            sceneListHeight = CUResizableContainer.BeginVertical(sceneListHeight);
            sceneListData = CUListControl.SelectionList(sceneListData, scenes, sceneRenderer);
            CUResizableContainer.EndVertical();

            bool isChooseScene = !sceneListData.Empty;
            GUI.enabled = isChooseScene;                                          // 判断有没有点击场景
            int width = Screen.width / 3 - 10;
            MyGUI.Heng(() =>
            {
                MyGUI.Button(isChooseScene ? "关卡".AddGreen() : "关卡", width, ChangeToLevel);
                MyGUI.Button(isChooseScene ? "场景".AddOrange() : "关卡", width, ChangeToScreen);
                MyGUI.Button("Ignore", width, ChangeToIgnore);
            });
            GUI.enabled = !sceneListData.Empty && IsScreen(scenes[sceneListData.First]);// 判断点击的场景是否标记 Screen
            MyGUI.Heng(() =>
            {
                MyGUI.Button("开始场景", width, ChangeToFirstScreen);
                MyGUI.Button("关卡完成后场景", width, ChangeToFirstScreenAfterLevel);
                GUI.enabled = sceneListData.Selection.Count == 1;
                MyGUI.Button("打开", width, () =>
                {
                    OpenScene(sceneListData);
                });
            });

        });
        MyGUI.AddSpace(4);
        GUI.enabled = true;
        MyCreate.Box(() =>
        {
            levelListHeight = CUResizableContainer.BeginVertical(levelListHeight);
            levelListData = CUListControl.SelectionList(levelListData, Target.levels, levelRenderer, "关卡");
            CUResizableContainer.EndVertical();

            GUI.enabled = !levelListData.Empty;
            MyGUI.Heng(() =>
            {
                MyGUI.AddSpace();
                MyGUI.Button("First", MoveToFirst);
                MyGUI.Button("↑", MoveUp);
                MyGUI.Button("↓", MoveDown);
                MyGUI.Button("Last", MoveToLast);
            });
            GUI.enabled = true;
        });

    }


    #region 私有

    private GUISkin m_GUISkin;
    private const string SceneListHeight = "SMSceneConfigurationEditor.sceneListHeight";
    private const string LevelListHeight = "SMSceneConfigurationEditor.LevelListHeight";
    private SMLevelRenderer levelRenderer;
    private SMSceneRenderer sceneRenderer;
    private CUListData sceneListData = new CUListData(true);
    private CUListData levelListData = new CUListData(true);
    private float sceneListHeight = 200f;
    private float levelListHeight = 200f;
    private bool initStyle = true;
    private GUIStyle boxStyle;
    private GUIStyle warnIconStyle;

    public override void OnEnable()
    {
        if (null == m_GUISkin)
        {
            m_GUISkin = LoadRes.ResourcesSkin;
        }
        sceneListHeight = EditorPrefs.GetFloat(SceneListHeight, 200f);
        levelListHeight = EditorPrefs.GetFloat(LevelListHeight, 200f);
        levelRenderer = new SMLevelRenderer();
        sceneRenderer = new SMSceneRenderer(Target);

        sceneListData.DragSource = new SMSceneListDragSource();
        sceneListData.DropTarget = new SMSceneListDropTarget(DropLevelInScenes);
        levelListData.DragSource = new SMLevelListDragSource();
        levelListData.DropTarget = new SMLevelListDropTarget(DropScenesInLevels);

        base.OnEnable();
    }


    public void OnDisable()
    {
        EditorPrefs.SetFloat(SceneListHeight, sceneListHeight);
        EditorPrefs.SetFloat(LevelListHeight, levelListHeight);
    }

    private void ProDraw()
    {
        GUI.skin = m_GUISkin;
        if (initStyle)
        {
            boxStyle = "GroupBox";
            warnIconStyle = "CN EntryWarn";
            initStyle = false;
        }

        if (Target._guid != configurationGuid)
        {
            sceneListData.ClearSelection();
            levelListData.ClearSelection();
            CheckConfiguration();
        }
        if (Invalid)
        {
            EditorGUILayout.BeginHorizontal(boxStyle);
            GUILayout.Label(string.Empty, warnIconStyle);
            GUILayout.Label("这个配置文件是无效的".AddRed());
            if (GUILayout.Button("修复配置"))
            {
                FixConfiguration();
            }
            EditorGUILayout.EndHorizontal();
        }
    }

    protected override void FixInvalidScenes()
    {
        SMSceneConfigurationOperation.Build(Target).Ignore(invalidScreens).Ignore(invalidLevels).Apply(Target);
    }



    /// <summary>
    /// Moves the selected level into the top position making it the first level.
    /// </summary>
    private void MoveToFirst()
    {
        BeforeChange("Move level to first position");
        IList<string> selectedLevels = levelListData.GetSelectedItems(Target.levels);
        SMSceneConfigurationOperation.Build(Target).MoveLevelToTop(selectedLevels).Apply(Target);
        levelListData.SetSelectedItems(Target.levels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Moves the selected level one position up.
    /// </summary>
    private void MoveUp()
    {
        BeforeChange("Move level up");
        IList<string> selectedLevels = levelListData.GetSelectedItems(Target.levels);
        SMSceneConfigurationOperation.Build(Target).MoveLevelUp(selectedLevels).Apply(Target);
        levelListData.SetSelectedItems(Target.levels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Moves the selected level one position down.
    /// </summary>
    private void MoveDown()
    {
        BeforeChange("Move level down");
        IList<string> selectedLevels = levelListData.GetSelectedItems(Target.levels);
        SMSceneConfigurationOperation.Build(Target).MoveLevelDown(selectedLevels).Apply(Target);
        levelListData.SetSelectedItems(Target.levels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    ///  Moves the selected level to the last position, making it the last level of the game.
    /// </summary>
    private void MoveToLast()
    {
        BeforeChange("Move level to last position");
        IList<string> selectedLevels = levelListData.GetSelectedItems(Target.levels);
        SMSceneConfigurationOperation.Build(Target).MoveLevelToBottom(selectedLevels).Apply(Target);
        levelListData.SetSelectedItems(Target.levels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Drop scenes from the scene list into the level list or move levels inside the level list
    /// </summary>
    private void DropScenesInLevels(IList<int> sceneIndices, int index, Type dragSource)
    {
        if (dragSource.Equals(typeof(SMSceneListDragSource)))
        {
            BeforeChange("Add scenes as level");
            IList<string> selectedScenes = ListOperation<string>.FilterList(scenes, sceneIndices);
            SMSceneConfigurationOperation.Build(Target).Level(selectedScenes).MoveLevelToPosition(selectedScenes, index)
                .Apply(Target);
            levelListData.SetSelectedItems(Target.levels, selectedScenes);
            SyncBuildSettingsIfRequired();
        }
        else
        {
            BeforeChange("Move level");
            IList<string> selectedLevel = ListOperation<string>.FilterList(Target.levels, sceneIndices);
            SMSceneConfigurationOperation.Build(Target).MoveLevelToPosition(selectedLevel, index).Apply(Target);
            levelListData.SetSelectedItems(Target.levels, selectedLevel);
        }
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Drop levels from the level list into the scene list
    /// </summary>
    private void DropLevelInScenes(IList<int> levelIndices)
    {
        BeforeChange("Remove levels");
        IList<string> selectedLevels = ListOperation<string>.FilterList(Target.levels, levelIndices);
        SMSceneConfigurationOperation.Build(Target).Ignore(selectedLevels).Apply(Target);
        sceneListData.SetSelectedItems(scenes, selectedLevels);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }
    #endregion



    private void ChangeToScreen()                                // 标记成场景
    {
        BeforeChange("Change scenes to screen");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMSceneConfigurationOperation.Build(Target).Screen(selectedScenes).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    private void ChangeToLevel()                                 // 标记成 Level
    {
        BeforeChange("Change scenes to level");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMSceneConfigurationOperation.Build(Target).Level(selectedScenes).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }


    private void ChangeToIgnore()                                // 不作标记
    {
        BeforeChange("Change scenes to ignore");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMSceneConfigurationOperation.Build(Target).Ignore(selectedScenes).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }
    private void ChangeToFirstScreen()                           // 标记成开始场景
    {
        string scene = scenes[sceneListData.First];
        if (Target.firstScreen != scene)
        {
            BeforeChange("Change scene to be first screen");
            SMSceneConfigurationOperation.Build(Target).FirstScreen(scene).Apply(Target);
            SyncBuildSettingsIfRequired();
            EditorUtility.SetDirty(Target);
        }
    }

    private void ChangeToFirstScreenAfterLevel()                 // 关卡结束跳转场景
    {
        string scene = scenes[sceneListData.First];
        if (Target.firstScreenAfterLevel != scene)
        {
            BeforeChange("Change scene to be first screen after last level");
            SMSceneConfigurationOperation.Build(Target).FirstScreenAfterLevel(scene).Apply(Target);
            SyncBuildSettingsIfRequired();
            EditorUtility.SetDirty(Target);
        }
    }



}