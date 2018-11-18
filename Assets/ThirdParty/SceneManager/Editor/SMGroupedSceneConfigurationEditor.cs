using System;
using System.Collections.Generic;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SMGroupedSceneConfiguration))]              // 编辑 Group 配置文件
public class SMGroupedSceneConfigurationEditor : SMSceneConfigurationEditorBase<SMGroupedSceneConfiguration>
{

    [MenuItem("Assets/Create/Grouped Scene 配置文件")]
    public static void AddConfiguration()
    {
        var configuration = CreateConfiguration<SMGroupedSceneConfiguration>();
        SMGroupedSceneConfigurationOperation.Build(configuration).AddGroup("Default").Apply(configuration);
    }


    public string[] WorkflowStrs = {"加载下个关卡", "加载标记场景" };

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
        int workWidth = Screen.width / 3 - 34;
        WorkflowActionEnum targetWork = Target.actionAfterGroup;
        bool isLevel = targetWork == WorkflowActionEnum.LoadNextLevel;
        MyGUI.Heng(() =>
        {
            MyGUI.Text("组结束,加载:");
            MyGUI.Button(isLevel?"[下一关卡]".AddGreen(): "下一关卡".AddLightGreen(), workWidth, () =>
            {
                if (!isLevel)
                {
                    ChangeToWorkflowAction(WorkflowActionEnum.LoadNextLevel);
                }
            });
            MyGUI.AddSpace(2);
            MyGUI.Button(isLevel ? "标记场景".AddLightGreen() : "[标记场景]".AddGreen(), workWidth, () =>
            {
                if (isLevel)
                {
                    ChangeToWorkflowAction(WorkflowActionEnum.LoadScreen);
                }
            });
            MyGUI.AddSpace();
            GUI.enabled = sceneListData.Selection.Count == 1;
            MyGUI.Button("打开", workWidth - 25 , () =>
            {
                OpenScene(sceneListData);
            });
            GUI.enabled = true;
        });


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
            MyCreate.Heng(() =>
            {
                MyGUI.Button("开始场景", width, ChangeToFirstScreen);
                MyGUI.Button("关卡完成后场景", width, ChangeToFirstScreenAfterLevel);
                GUI.enabled = GUI.enabled && Target.actionAfterGroup == WorkflowActionEnum.LoadScreen;// 是否选择了标记场景
                MyGUI.Button("完成组后场景", width, ChangeToFirstScreenAfterGroup);
            });

        });

        MyGUI.AddSpace(4);
        GUI.enabled = true;
   
        MyCreate.Box(() =>
        {
            levelListHeight = CUResizableContainer.BeginVertical(levelListHeight);
            EditorGUILayout.BeginHorizontal();
            groupListWidth = CUResizableContainer.BeginHorizontal(groupListWidth);
            int lastGroup = groupListData.First;
            groupListData = CUListControl.SelectionList(groupListData, Target.groups, groupRenderer, "组");
            if (lastGroup != groupListData.First)
            {
                levelListData.ClearSelection();
            }

            CUResizableContainer.EndHorizontal();
            GUI.enabled = SelectedGroup != null;
            levelListData = CUListControl.SelectionList(levelListData, currentGroupLevels, levelRenderer, "关卡");
            GUI.enabled = true;
            EditorGUILayout.EndHorizontal();
            CUResizableContainer.EndVertical();

            MyGUI.Heng(() =>
            {
                MyGUI.Button("+", AddGroup);
                GUI.enabled = !groupListData.Empty && Target.groups.Length > 1;
                MyGUI.Button("-", RemoveGroup);
                GUI.enabled = !groupListData.Empty;
                MyGUI.Button("改名", RenameGroup);
                GUI.enabled = true;
                MyGUI.AddSpace();
                GUI.enabled = !levelListData.Empty;
                MyGUI.Button("First", MoveToFirst);
                MyGUI.Button("↑", MoveUp);
                MyGUI.Button("↓", MoveDown);
                MyGUI.Button("Last", MoveToLast);
                GUI.enabled = true;

            });
        });


    }



    #region 私有

    private GUISkin m_GUISkin;
    private const string SceneListHeight = "SMGroupedSceneConfigurationEditor.sceneListHeight";
    private const string LevelListHeight = "SMGroupedSceneConfigurationEditor.LevelListHeight";
    private const string GroupListWidth = "SMGroupedSceneConfigurationEditor.GroupListWidth";
    private SMLevelRenderer levelRenderer;
    private SMGroupRenderer groupRenderer;
    private SMSceneRenderer sceneRenderer;
    private CUListData sceneListData = new CUListData(true);
    private CUListData groupListData = new CUListData(false);
    private CUListData levelListData = new CUListData(true);
    private float sceneListHeight = 200f;
    private float levelListHeight = 200f;
    private float groupListWidth = 200f;
    private bool initStyle = true;
    private GUIStyle boxStyle;
    private GUIStyle warnIconStyle;



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
            groupListData.ClearSelection();
            CheckConfiguration();
        }
        RebuildLevelOfCurrentGroup();
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


    private string[] currentGroupLevels;


    public override void OnEnable()
    {
        if (null == m_GUISkin)
        {
            m_GUISkin = LoadRes.ResourcesSkin;
        }
        sceneListHeight = EditorPrefs.GetFloat(SceneListHeight, 200f);
        levelListHeight = EditorPrefs.GetFloat(LevelListHeight, 200f);
        groupListWidth = EditorPrefs.GetFloat(GroupListWidth, 200f);
        levelRenderer = new SMLevelRenderer();
        groupRenderer = new SMGroupRenderer();
        sceneRenderer = new SMSceneRenderer(Target);

        sceneListData.DragSource = new SMSceneListDragSource();
        sceneListData.DropTarget = new SMSceneListDropTarget(DropLevelInScenes);
        groupListData.DragSource = new SMGroupListDragSource();
        groupListData.DropTarget = new SMGroupListDropTarget(DropGroup, DropScenesInGroup);
        levelListData.DragSource = new SMLevelListDragSource();
        levelListData.DropTarget = new SMLevelListDropTarget(DropScenesInLevels);

        base.OnEnable();
    }

    public void OnDisable()
    {
        EditorPrefs.SetFloat(SceneListHeight, sceneListHeight);
        EditorPrefs.SetFloat(LevelListHeight, levelListHeight);
        EditorPrefs.SetFloat(GroupListWidth, groupListWidth);
    }


    protected override void FixInvalidScenes()
    {
        SMGroupedSceneConfigurationOperation.Build(Target).Ignore(invalidScreens).Ignore(invalidLevels).Apply(Target);
    }



    private string SelectedGroup
    {
        get
        {
            return groupListData.Empty && groupListData.First < Target.groups.Length
                ? null
                : Target.groups[groupListData.First];
        }
    }

    private void RebuildLevelOfCurrentGroup()
    {
        currentGroupLevels = new string[0];
        string currentGroup = SelectedGroup;
        if (currentGroup != null)
        {
            for (int i = 0; i < Target.groups.Length; i++)
            {
                if (Target.groups[i] == currentGroup)
                {
                    int start = Target.groupOffset[i];
                    int end = (i + 1 == Target.groups.Length) ? Target.levels.Length : Target.groupOffset[i + 1];
                    int length = end - start;
                    currentGroupLevels = new string[length];
                    Array.Copy(Target.levels, start, currentGroupLevels, 0, length);
                }
            }
        }
    }

    private bool VerifyGroupName(string name)
    {
        // name required
        if (String.IsNullOrEmpty(name))
        {
            return false;
        }

        // unique name
        if (Array.IndexOf(Target.groups, name) != -1)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Adds a new group to the configuration
    /// </summary>
    private void AddGroup()
    {
        // save position before opening the dialog. otherwise the position will be resetted
        Vector2 position = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
        CUTextInputDialog.ShowDialog("Name", "", AddGroup, VerifyGroupName).CenterAt(position);
        GUIUtility.ExitGUI();
    }

    private void AddGroup(string name)
    {
        BeforeChange("Add group");
        SMGroupedSceneConfigurationOperation.Build(Target).AddGroup(name).Apply(Target);
        groupListData.SetSelectedItems(Target.groups, new string[] {name});
        levelListData.ClearSelection();
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Removes the group from the configuration
    /// </summary>
    private void RemoveGroup()
    {
        BeforeChange("Remove group");
        SMGroupedSceneConfigurationOperation.Build(Target).RemoveGroup(SelectedGroup).Apply(Target);
        groupListData.ClearSelection();
        levelListData.ClearSelection();
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Changes the name of a group
    /// </summary>
    private void RenameGroup()
    {
        // save position before opening the dialog. otherwise the position will be resetted
        Vector2 position = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
        CUTextInputDialog.ShowDialog("Name", SelectedGroup, RenameGroup, VerifyGroupName).CenterAt(position);
        GUIUtility.ExitGUI();
    }

    private void RenameGroup(string name)
    {
        BeforeChange("Rename group");
        SMGroupedSceneConfigurationOperation.Build(Target).RenameGroup(name, SelectedGroup).Apply(Target);
        groupListData.SetSelectedItems(Target.groups, new string[] {name});
        levelListData.ClearSelection();
        EditorUtility.SetDirty(Target);
    }

    private void ChangeToIgnore()
    {
        BeforeChange("Change scenes to ignore");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMGroupedSceneConfigurationOperation.Build(Target).Ignore(selectedScenes).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    private void ChangeToScreen()
    {
        BeforeChange("Change scenes to screen");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMGroupedSceneConfigurationOperation.Build(Target).Screen(selectedScenes).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    private void ChangeToLevel()
    {
        BeforeChange("Change scenes to level");
        IList<string> selectedScenes = sceneListData.GetSelectedItems(scenes);
        SMGroupedSceneConfigurationOperation.Build(Target).Level(selectedScenes, SelectedGroup).Apply(Target);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Makes the currently selected scene the first screen of the game.
    /// </summary>
    private void ChangeToFirstScreen()
    {
        string scene = scenes[sceneListData.First];
        if (Target.firstScreen != scene)
        {
            BeforeChange("Change scene to be first screen");
            SMGroupedSceneConfigurationOperation.Build(Target).FirstScreen(scene).Apply(Target);
            SyncBuildSettingsIfRequired();
            EditorUtility.SetDirty(Target);
        }
    }

    /// <summary>
    /// Makes the currently selected scene the first screen after the last level of the game.
    /// </summary>
    private void ChangeToFirstScreenAfterLevel()
    {
        string scene = scenes[sceneListData.First];
        if (Target.firstScreenAfterLevel != scene)
        {
            BeforeChange("Change scene to be first screen after last level");
            SMGroupedSceneConfigurationOperation.Build(Target).FirstScreenAfterLevel(scene).Apply(Target);
            SyncBuildSettingsIfRequired();
            EditorUtility.SetDirty(Target);
        }
    }

    /// <summary>
    /// Makes the currently selected scene the first screen after each group of the game.
    /// </summary>
    private void ChangeToWorkflowAction(WorkflowActionEnum action)
    {
        BeforeChange("Change action after group");
        SMGroupedSceneConfigurationOperation.Build(Target).ActionAfterGroup(action).Apply(Target);
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Makes the currently selected scene the first screen after each group of the game.
    /// </summary>
    private void ChangeToFirstScreenAfterGroup()
    {
        string scene = scenes[sceneListData.First];
        if (Target.firstScreenAfterGroup != scene)
        {
            BeforeChange("Change scene to be first screen after group");
            SMGroupedSceneConfigurationOperation.Build(Target).FirstScreenAfterGroup(scene).Apply(Target);
            SyncBuildSettingsIfRequired();
            EditorUtility.SetDirty(Target);
        }
    }

    /// <summary>
    /// Moves the selected level into the top position making it the first level.
    /// </summary>
    private void MoveToFirst()
    {
        BeforeChange("Move level to first position");
        IList<string> selectedLevels = levelListData.GetSelectedItems(currentGroupLevels);
        SMGroupedSceneConfigurationOperation.Build(Target).MoveLevelToTop(selectedLevels, SelectedGroup).Apply(Target);
        RebuildLevelOfCurrentGroup();
        levelListData.SetSelectedItems(currentGroupLevels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Moves the selected level one position up.
    /// </summary>
    private void MoveUp()
    {
        BeforeChange("Move level up");
        IList<string> selectedLevels = levelListData.GetSelectedItems(currentGroupLevels);
        SMGroupedSceneConfigurationOperation.Build(Target).MoveLevelUp(selectedLevels, SelectedGroup).Apply(Target);
        RebuildLevelOfCurrentGroup();
        levelListData.SetSelectedItems(currentGroupLevels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Moves the selected level one position down.
    /// </summary>
    private void MoveDown()
    {
        BeforeChange("Move level down");
        IList<string> selectedLevels = levelListData.GetSelectedItems(currentGroupLevels);
        SMGroupedSceneConfigurationOperation.Build(Target).MoveLevelDown(selectedLevels, SelectedGroup).Apply(Target);
        RebuildLevelOfCurrentGroup();
        levelListData.SetSelectedItems(currentGroupLevels, selectedLevels);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    ///  Moves the selected level to the last position, making it the last level of the game.
    /// </summary>
    private void MoveToLast()
    {
        BeforeChange("Move level to last position");
        IList<string> selectedLevels = levelListData.GetSelectedItems(currentGroupLevels);
        SMGroupedSceneConfigurationOperation.Build(Target).MoveLevelToBottom(selectedLevels, SelectedGroup)
            .Apply(Target);
        RebuildLevelOfCurrentGroup();
        levelListData.SetSelectedItems(currentGroupLevels, selectedLevels);
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
            SMGroupedSceneConfigurationOperation.Build(Target).Level(selectedScenes, SelectedGroup)
                .MoveLevelToPosition(selectedScenes, index, SelectedGroup).Apply(Target);
            RebuildLevelOfCurrentGroup();
            levelListData.SetSelectedItems(currentGroupLevels, selectedScenes);
            SyncBuildSettingsIfRequired();
        }
        else
        {
            BeforeChange("Move level");
            IList<string> selectedLevel = ListOperation<string>.FilterList(currentGroupLevels, sceneIndices);
            SMGroupedSceneConfigurationOperation.Build(Target).MoveLevelToPosition(selectedLevel, index, SelectedGroup)
                .Apply(Target);
            RebuildLevelOfCurrentGroup();
            levelListData.SetSelectedItems(currentGroupLevels, selectedLevel);
        }
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Drop levels from the level list into the scene list
    /// </summary>
    private void DropLevelInScenes(IList<int> levelIndices)
    {
        BeforeChange("Remove levels");
        IList<string> selectedLevels = ListOperation<string>.FilterList(currentGroupLevels, levelIndices);
        SMGroupedSceneConfigurationOperation.Build(Target).Ignore(selectedLevels).Apply(Target);
        RebuildLevelOfCurrentGroup();
        sceneListData.SetSelectedItems(scenes, selectedLevels);
        levelListData.ClearSelection();
        SyncBuildSettingsIfRequired();
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Move groups inside the group list
    /// </summary>
    private void DropGroup(int group, int index)
    {
        BeforeChange("Move group");
        string selectedGroup = Target.groups[group];
        SMGroupedSceneConfigurationOperation.Build(Target).MoveGroupToPosition(selectedGroup, index).Apply(Target);
        RebuildLevelOfCurrentGroup();
        groupListData.SetSelectedItem(Target.groups, selectedGroup);
        EditorUtility.SetDirty(Target);
    }

    /// <summary>
    /// Drop scenes from the scene list or levels from the level list into the group list
    /// </summary>
    private void DropScenesInGroup(IList<int> sceneIndices, int index, Type dragSource)
    {
        if (dragSource.Equals(typeof(SMSceneListDragSource)))
        {
            BeforeChange("Add scenes as level");
            IList<string> selectedScenes = ListOperation<string>.FilterList(scenes, sceneIndices);
            SMGroupedSceneConfigurationOperation.Build(Target).Level(selectedScenes, Target.groups[index])
                .Apply(Target);
            RebuildLevelOfCurrentGroup();
            levelListData.ClearSelection();
            SyncBuildSettingsIfRequired();
        }
        else
        {
            BeforeChange("Move level");
            IList<string> selectedLevel = ListOperation<string>.FilterList(currentGroupLevels, sceneIndices);
            SMGroupedSceneConfigurationOperation.Build(Target).Level(selectedLevel, Target.groups[index]).Apply(Target);
            RebuildLevelOfCurrentGroup();
            levelListData.ClearSelection();
        }
        EditorUtility.SetDirty(Target);
    }


    #endregion



}