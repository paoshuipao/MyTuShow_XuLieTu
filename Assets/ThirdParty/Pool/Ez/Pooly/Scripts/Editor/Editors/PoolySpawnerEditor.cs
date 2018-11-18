using System.Collections.Generic;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using QuickEditor;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Ez.Pooly
{
    [CustomEditor(typeof(PoolySpawner))]
    [DisallowMultipleComponent]
    public class PoolySpawnerEditor : QEditor
    {
        #region 私有
        private readonly string[] SpawnTypes = { "顺序", "随机" };
        private readonly Color LineColor = Color.yellow;                 // 场景那条线颜色


        PoolySpawner poolySpawner { get { return (PoolySpawner)target; } }

        SerializedProperty
            autoStart, despawnWhenFinished, spawnStartDelay,
            spawnCount, spawnForever,
            spawnPositions, spawnPoints,
            spawnInterval, spawnAtRandomIntervals, spawnAtRandomIntervalMinimum, spawnAtRandomIntervalMaximum,
            matchTransformRotation, matchTransformScale, reparentUnderTransform,
            useSpawnerAsSpawnLocation,
            prefabSpawnType, spawnAt, locationSpawnType,
            showOnSpawnStarted, OnSpawnStarted,
            showOnSpawnStopped, OnSpawnStopped,
            showOnSpawnResumed, OnSpawnResumed,
            showOnSpawnPaused, OnSpawnPaused,
            showOnSpawnFinished, OnSpawnFinished;

        AnimBool
            animBoolDespawnWhenFinished,
            animBoolSpawnRandomPrefab,
            animBoolRandomSpawnLocation,
            animBoolShowSpawnLocationsOptions,
            animBoolShowOnSpawnStarted, animBoolShowOnSpawnStopped, animBoolShowOnSpawnResumed, animBoolShowOnSpawnPaused, animBoolShowOnSpawnFinished;

        Color defaultHandlesColor;
        Color AccentColorOrange { get { return QUI.IsProSkin ? QColors.Orange.Color : QColors.OrangeLight.Color; } }
        Color AccentColorBlue { get { return QUI.IsProSkin ? QColors.Blue.Color : QColors.BlueLight.Color; } }
        Color AccentColorPurple { get { return QUI.IsProSkin ? QColors.Purple.Color : QColors.PurpleLight.Color; } }

        GUIContent tempContent;
        Vector2 tempContentSize;




        protected override void SerializedObjectFindProperties()
        {
            base.SerializedObjectFindProperties();

            autoStart = serializedObject.FindProperty("autoStart");
            despawnWhenFinished = serializedObject.FindProperty("despawnWhenFinished");
            spawnStartDelay = serializedObject.FindProperty("spawnStartDelay");
            spawnCount = serializedObject.FindProperty("spawnCount");
            spawnPositions = serializedObject.FindProperty("spawnPositions");
            spawnPoints = serializedObject.FindProperty("spawnPoints");
            spawnForever = serializedObject.FindProperty("spawnForever");
            spawnInterval = serializedObject.FindProperty("spawnInterval");
            spawnAtRandomIntervals = serializedObject.FindProperty("spawnAtRandomIntervals");
            spawnAtRandomIntervalMinimum = serializedObject.FindProperty("spawnAtRandomIntervalMinimum");
            spawnAtRandomIntervalMaximum = serializedObject.FindProperty("spawnAtRandomIntervalMaximum");
            matchTransformRotation = serializedObject.FindProperty("matchTransformRotation");
            matchTransformScale = serializedObject.FindProperty("matchTransformScale");
            reparentUnderTransform = serializedObject.FindProperty("reparentUnderTransform");
            useSpawnerAsSpawnLocation = serializedObject.FindProperty("useSpawnerAsSpawnLocation");
            prefabSpawnType = serializedObject.FindProperty("prefabSpawnType");
            spawnAt = serializedObject.FindProperty("spawnAt");
            locationSpawnType = serializedObject.FindProperty("locationSpawnType");
            showOnSpawnStarted = serializedObject.FindProperty("showOnSpawnStarted");
            OnSpawnStarted = serializedObject.FindProperty("OnSpawnStarted");
            showOnSpawnStopped = serializedObject.FindProperty("showOnSpawnStopped");
            OnSpawnStopped = serializedObject.FindProperty("OnSpawnStopped");
            showOnSpawnResumed = serializedObject.FindProperty("showOnSpawnResumed");
            OnSpawnResumed = serializedObject.FindProperty("OnSpawnResumed");
            showOnSpawnPaused = serializedObject.FindProperty("showOnSpawnPaused");
            OnSpawnPaused = serializedObject.FindProperty("OnSpawnPaused");
            showOnSpawnFinished = serializedObject.FindProperty("showOnSpawnFinished");
            OnSpawnFinished = serializedObject.FindProperty("OnSpawnFinished");
        }

        protected override void InitAnimBools()
        {
            base.InitAnimBools();

            animBoolDespawnWhenFinished = new AnimBool(autoStart.enumValueIndex == (int)PoolySpawner.AutoStart.OnSpawned, Repaint);
            animBoolSpawnRandomPrefab = new AnimBool(prefabSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random, Repaint);
            animBoolRandomSpawnLocation = new AnimBool(locationSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random, Repaint);
            animBoolShowSpawnLocationsOptions = new AnimBool(useSpawnerAsSpawnLocation.boolValue, Repaint);
            animBoolShowOnSpawnStarted = new AnimBool(showOnSpawnStarted.boolValue, Repaint);
            animBoolShowOnSpawnStopped = new AnimBool(showOnSpawnStopped.boolValue, Repaint);
            animBoolShowOnSpawnResumed = new AnimBool(showOnSpawnResumed.boolValue, Repaint);
            animBoolShowOnSpawnPaused = new AnimBool(showOnSpawnPaused.boolValue, Repaint);
            animBoolShowOnSpawnFinished = new AnimBool(showOnSpawnFinished.boolValue, Repaint);
        }


        private void GetInitialHandlesColors()
        {
            defaultHandlesColor = Handles.color;
        }

        public static Rect GetScreenRect(Vector2 screenPoint, float width, float height)
        {
            Rect rect = new Rect
            {
                x = GUIUtility.ScreenToGUIPoint(screenPoint).x,
                y = GUIUtility.ScreenToGUIPoint(screenPoint).y,
                width = width,
                height = height
            };
            return rect;
        }


        #endregion

        protected override void GenerateInfoMessages()
        {
            base.GenerateInfoMessages();

            infoMessage.Add("AutoStartNever", new InfoMessage()
            {
                title = "Auto Start Never", message = "这个 spawner 不会自动产生，您有责任为此 spawner 开始产生周期", show = new AnimBool(false, Repaint), type = InfoMessageType.Help
            });
            infoMessage.Add("SpawnForever", new InfoMessage()
            {
                title = "Spawn Forever", message = "spawner 会一直产生预制件 \n只有调用 StopSpawn 或 PauseSpawn 方法时它才会停止 \n你有责任 停止 或 暂停 这个 spawner 的产生周期", show = new AnimBool(false, Repaint), type = InfoMessageType.Help
            });
            infoMessage.Add("NoSpawnPoint", new InfoMessage()
            {
                title = "", message = "Set at least one spawn point by referencing a Transform from the scene or set Use Spawner As Spawn Location as true.", show = new AnimBool(false, Repaint), type = InfoMessageType.Info
            });
            infoMessage.Add("NoPrefabs", new InfoMessage()
            {
                title = "SPAWNER IS DISABLED", message = "Reference at least one prefab.", show = new AnimBool(false, Repaint), type = InfoMessageType.Error
            });
        }



        protected override void OnEnable()
        {
            base.OnEnable();

            requiresContantRepaint = true;

            GetInitialHandlesColors();

            tempContent = new GUIContent();
        }


        void OnSceneGUI()
        {
            if (useSpawnerAsSpawnLocation.boolValue)
            {
                return;
            }
            switch(poolySpawner.spawnAt)
            {
                case PoolySpawner.SpawnAt.Position:
                    if(poolySpawner.spawnPositions != null && poolySpawner.spawnPositions.Count > 0)
                    {
                        for(int i = 0; i < poolySpawner.spawnPositions.Count; i++)
                        {
                            Handles.Label(new Vector3(poolySpawner.spawnPositions[i].spawnPosition.x + 0.05f,
                                    poolySpawner.spawnPositions[i].spawnPosition.y - 0.05f,
                                    poolySpawner.spawnPositions[i].spawnPosition.z),
                                "产生的坐标位置 " + i + " " + poolySpawner.spawnPositions[i].spawnPosition);
                            QUI.BeginChangeCheck();
                            Vector3 updatedSpawnPosition = Handles.PositionHandle(poolySpawner.spawnPositions[i].spawnPosition, Quaternion.identity);
                            if(QUI.EndChangeCheck())
                            {
                                Undo.RecordObject(poolySpawner, "Changed Spawn Position " + i);
                                poolySpawner.spawnPositions[i].spawnPosition = updatedSpawnPosition.Round();
                            }
                            Handles.color = LineColor;
                            Handles.DrawDottedLine(poolySpawner.transform.position, poolySpawner.spawnPositions[i].spawnPosition, 4);
                            Handles.color = defaultHandlesColor;
                        }
                    }
                    break;
                case PoolySpawner.SpawnAt.Transform:
                    if(poolySpawner.spawnPoints != null && poolySpawner.spawnPoints.Count > 0)
                    {
                        for(int i = 0; i < poolySpawner.spawnPoints.Count; i++)
                        {
                            if(poolySpawner.spawnPoints[i].spawnPoint == null) { continue; }
                            Handles.Label(new Vector3(poolySpawner.spawnPoints[i].spawnPoint.position.x + 0.05f,
                                    poolySpawner.spawnPoints[i].spawnPoint.position.y - 0.05f,
                                    poolySpawner.spawnPoints[i].spawnPoint.position.z),
                                "产生的物体位置 " + i + " " + poolySpawner.spawnPoints[i].spawnPoint.position);
                            QUI.BeginChangeCheck();
                            Vector3 updatedSpawnPointPosition = Handles.PositionHandle(poolySpawner.spawnPoints[i].spawnPoint.position, Quaternion.identity);
                            if(QUI.EndChangeCheck())
                            {
                                Undo.RecordObject(poolySpawner, "Moved " + poolySpawner.spawnPoints[i].spawnPoint.name);
                                poolySpawner.spawnPoints[i].spawnPoint.position = updatedSpawnPointPosition.Round();
                            }
                            Handles.color = LineColor;
                            Handles.DrawDottedLine(poolySpawner.transform.position, poolySpawner.spawnPoints[i].spawnPoint.position, 4);
                            Handles.color = defaultHandlesColor;
                        }
                    }
                    break;
            }
        }

        public override void OnInspectorGUI()
        {
            MyCreate.AddSpace(5);
            serializedObject.Update();
            DrawMainSettings();
            DrawPrefabs();
            DrawLocations();
            DrawOnSpawnEvents();
            serializedObject.ApplyModifiedProperties();
        }
        private void DrawMainSettings()
        {
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.SetGUIBackgroundColor(AccentColorOrange);
                switch (autoStart.enumValueIndex)
                {
                    case (int)PoolySpawner.AutoStart.Start:
                        tempContent.text = "自动产生：Start 调用  ";
                        break;
                    case (int)PoolySpawner.AutoStart.OnSpawned:
                        tempContent.text = "自动产生：OnSpawned 调用";

                        break;
                    case (int)PoolySpawner.AutoStart.Never:
                        tempContent.text = "不自动产生，使用代码产生 ";
                        break;
                }
                QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                QUI.Popup(autoStart, 86);
                QUI.FlexibleSpace();
                if(autoStart.enumValueIndex != (int)PoolySpawner.AutoStart.Never)
                {
                    tempContent.text = "延迟";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.PropertyField(spawnStartDelay, 40);
                    if(spawnStartDelay.floatValue < 0) { spawnStartDelay.floatValue = 0; }
                    tempContent.text = "秒";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                }
                QUI.ResetColors();
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4 * infoMessage["AutoStartNever"].show.faded);
            animBoolDespawnWhenFinished.target = autoStart.enumValueIndex == (int)PoolySpawner.AutoStart.OnSpawned;
            if(QUI.BeginFadeGroup(animBoolDespawnWhenFinished.faded))
            {
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.SetGUIBackgroundColor(AccentColorOrange);
                    QUI.Toggle(despawnWhenFinished);
                    QUI.ResetColors();
                    QUI.Label("调用“Despawn” 当完成发射", Style.Text.Normal, WIDTH_420);
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();
            }
            QUI.EndFadeGroup();
            QUI.BeginHorizontal(WIDTH_420);
            {
                if(!spawnForever.boolValue)
                {
                    tempContent.text = "产生数量   ";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.SetGUIBackgroundColor(AccentColorOrange);
                    QUI.PropertyField(spawnCount, 90);
                    QUI.ResetColors();
                    if (spawnCount.intValue < 0)
                    {
                        spawnCount.intValue = 0;
                    }
                    QUI.FlexibleSpace();
                }
                QUI.SetGUIBackgroundColor(QColors.OrangeLight.Color);
                QUI.Toggle(spawnForever);
                QUI.ResetColors();
                tempContent.text = "是否一直循环产生";
                QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();

            // 固定间隔 还是随机间隔
            QUI.Space(SPACE_4 * infoMessage["SpawnForever"].show.faded);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.SetGUIBackgroundColor(AccentColorOrange);
                if(spawnAtRandomIntervals.boolValue)
                {
                    QUI.Toggle(spawnAtRandomIntervals);
                    tempContent.text = "随机产生：";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.Space(20);
                    tempContent.text = "Min";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.PropertyField(spawnAtRandomIntervalMinimum, 40);
                    if(spawnAtRandomIntervalMinimum.floatValue < 0) { spawnAtRandomIntervalMinimum.floatValue = 0; }
                    QUI.Label("-", Style.Text.Normal, 8);
                    tempContent.text = "Max";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.PropertyField(spawnAtRandomIntervalMaximum, 40);
                    if(spawnAtRandomIntervalMaximum.floatValue < spawnAtRandomIntervalMinimum.floatValue) { spawnAtRandomIntervalMaximum.floatValue = spawnAtRandomIntervalMinimum.floatValue; }
                    tempContent.text = "秒";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                }
                else
                {
                    tempContent.text = "Spawn Every";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.PropertyField(spawnInterval, 56);
                    tempContent.text = "秒";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.Space(45);
                    QUI.Toggle(spawnAtRandomIntervals);
                    tempContent.text = "使用随机时间间隔";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);

                }
                QUI.ResetColors();
            }
            QUI.EndHorizontal();

            if(useSpawnerAsSpawnLocation.boolValue ||
               (!useSpawnerAsSpawnLocation.boolValue && poolySpawner.spawnAt == PoolySpawner.SpawnAt.Transform))
            {
                QUI.SetGUIBackgroundColor(AccentColorOrange);
                QUI.BeginHorizontal(WIDTH_420);
                {
                    tempContent.text = "额外的 Spawn 设置";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                }
                QUI.EndHorizontal();

                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.Space(SPACE_8);
                    QUI.Toggle(matchTransformRotation);
                    tempContent.text = "匹配 " + (useSpawnerAsSpawnLocation.boolValue ? "Spawner" : "Target") + " Transform Rotation";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.Space(SPACE_8);
                    QUI.Toggle(matchTransformScale);
                    tempContent.text = "匹配 " + (useSpawnerAsSpawnLocation.boolValue ? "Spawner" : "Target") + " Transform Scale";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.Space(SPACE_8);
                    QUI.Toggle(reparentUnderTransform);
                    tempContent.text = "重新设置父级 " + (useSpawnerAsSpawnLocation.boolValue ? "Spawner" : "Target") + " Transform";
                    QUI.Label(tempContent.text, Style.Text.Normal, QStyles.CalcSize(tempContent, Style.Text.Normal).x);
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();
                QUI.ResetColors();
            }
        }


        private void DrawPrefabs()
        {
            // 先画个盒子，再提上去写文字
            QUI.Space(SPACE_8);
            QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Orange), WIDTH_420, 20);
            QUI.Space(-20);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Space(SPACE_4);
                QUI.Label("PREFAB" + ((poolySpawner.spawnPrefabs != null && poolySpawner.spawnPrefabs.Count > 1) ? "S" : "") + " TO SPAWN（拖预制体进来）", Style.Text.Normal, 200, HEIGHT_16);
                QUI.Space(SPACE_4);
                QUI.FlexibleSpace();
                if(poolySpawner.spawnPrefabs != null && poolySpawner.spawnPrefabs.Count > 1)
                {
                    QUI.Label("Spawn Type", Style.Text.Normal, 68);
                    QUI.SetGUIBackgroundColor(AccentColorOrange);
                    QUI.Popup(prefabSpawnType, 80, SpawnTypes);
                    QUI.ResetColors();
                }
                QUI.Space(SPACE_8);
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4);
            if(poolySpawner.spawnPrefabs == null || poolySpawner.spawnPrefabs.Count == 0) { poolySpawner.spawnPrefabs = new List<PoolySpawner.SpawnPrefab> { new PoolySpawner.SpawnPrefab(null) }; }
            if(poolySpawner.spawnPrefabs.Count == 1 && poolySpawner.prefabSpawnType == PoolySpawner.SpawnType.Random) { poolySpawner.prefabSpawnType = PoolySpawner.SpawnType.Sequential; }
            infoMessage["NoPrefabs"].show.target = !poolySpawner.HasPrefabs();
            // 画框框提示
            DrawInfoMessage("NoPrefabs", WIDTH_420-20);
            for(int i = 0; i < poolySpawner.spawnPrefabs.Count; i++)
            {
                QUI.Space(SPACE_2);
                QUI.BeginHorizontal(WIDTH_420);
                {
                    tempContent = new GUIContent(i.ToString());
                    tempContentSize = QStyles.CalcSize(tempContent, Style.Text.Small);
                    QUI.Label(tempContent.text, Style.Text.Small, tempContentSize.x);
                    QUI.BeginChangeCheck();
                    Transform prefabObject = poolySpawner.spawnPrefabs[i].prefab;
                    QUI.SetGUIBackgroundColor(AccentColorOrange);
                    prefabObject = (Transform)QUI.ObjectField(prefabObject, typeof(Transform), false, (WIDTH_420 - SPACE_2 - tempContentSize.x - SPACE_8 - SPACE_16) - 240 * animBoolSpawnRandomPrefab.faded);
                    QUI.ResetColors();
                    if(QUI.EndChangeCheck())
                    {
                        Undo.RecordObject(poolySpawner, "Changed Value For Prefab Slot " + i);
                        poolySpawner.spawnPrefabs[i].prefab = prefabObject;
                    }
                    if(QUI.ButtonMinus())
                    {
                        if(poolySpawner.spawnPrefabs.Count > 1)
                        {
                            Undo.RecordObject(poolySpawner, "Removed Prefab Slot " + i);
                            poolySpawner.spawnPrefabs.RemoveAt(i);
                        }
                        else if(poolySpawner.spawnPrefabs == null || poolySpawner.spawnPrefabs[0].prefab != null)
                        {
                            Undo.RecordObject(poolySpawner, "Reset Prefab Slot");
                            poolySpawner.spawnPrefabs = new List<PoolySpawner.SpawnPrefab> { new PoolySpawner.SpawnPrefab(null) };
                        }
                        QUI.SetDirty(poolySpawner);
                        QUI.ExitGUI();
                    }
                    animBoolSpawnRandomPrefab.target = prefabSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random;
                    if(poolySpawner.spawnPrefabs != null && poolySpawner.spawnPrefabs.Count > 1 && prefabSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random)
                    {
                        QUI.Space(SPACE_2);
                        QUI.Label("weight", Style.Text.Small, 50 * animBoolSpawnRandomPrefab.faded);
                        QUI.Space(-SPACE_8);
                        QUI.BeginChangeCheck();
                        int spawnPrefabWeight = poolySpawner.spawnPrefabs[i].weight;
                        QUI.SetGUIBackgroundColor(AccentColorOrange);
                        spawnPrefabWeight = EditorGUILayout.IntSlider(spawnPrefabWeight, 0, 100);
                        QUI.ResetColors();
                        if(QUI.EndChangeCheck())
                        {
                            Undo.RecordObject(poolySpawner, "Changed Weight Of Prefab " + i);
                            poolySpawner.spawnPrefabs[i].weight = spawnPrefabWeight;
                        }
                    }
                    QUI.FlexibleSpace();
                }
                QUI.EndHorizontal();
            }
            QUI.Space(SPACE_2);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.FlexibleSpace();
                if(QUI.ButtonPlus())
                {
                    Undo.RecordObject(poolySpawner, "Added New Prefab Slot");
                    poolySpawner.spawnPrefabs.Add(new PoolySpawner.SpawnPrefab(null));
                    QUI.SetDirty(poolySpawner);
                    QUI.ExitGUI();
                }
                QUI.Space(3 + 240 * animBoolSpawnRandomPrefab.faded);
            }
            QUI.EndHorizontal();
        }

        private void DrawLocations()
        {
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.SetGUIBackgroundColor(AccentColorBlue);
                QUI.BeginChangeCheck();
                QUI.Toggle(useSpawnerAsSpawnLocation);
                if(QUI.EndChangeCheck())
                {
                    HandleUtility.Repaint();
                    SceneView.RepaintAll();
                    Repaint();
                }
                QUI.ResetColors();
                if(useSpawnerAsSpawnLocation.boolValue && poolySpawner.spawnPositions != null && poolySpawner.spawnPositions.Count > 0)
                {
                    spawnPositions.ClearArray();
                    spawnPositions.InsertArrayElementAtIndex(0);
                    spawnPositions.GetArrayElementAtIndex(0).FindPropertyRelative("spawnPosition").vector3Value = new Vector3(0, 1, 0);

                    serializedObject.ApplyModifiedProperties();
                    HandleUtility.Repaint();
                    SceneView.RepaintAll();
                    Repaint();
                }
                if(useSpawnerAsSpawnLocation.boolValue && poolySpawner.spawnPoints != null && poolySpawner.spawnPoints.Count > 0)
                {
                    spawnPoints.ClearArray();
                    spawnPoints.InsertArrayElementAtIndex(0);

                    serializedObject.ApplyModifiedProperties();
                    HandleUtility.Repaint();
                    SceneView.RepaintAll();
                    Repaint();
                }
                QUI.Label("使用预制体的坐标作为产生点", Style.Text.Normal, 200);
            }
            QUI.EndHorizontal();
            if(useSpawnerAsSpawnLocation.boolValue) { return; }
            else { QUI.Space(-SPACE_4); }
            animBoolShowSpawnLocationsOptions.target = !useSpawnerAsSpawnLocation.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowSpawnLocationsOptions.faded))
            {
                QUI.Space(SPACE_8);
                QUI.BeginVertical();
                {
                    QUI.Space(SPACE_4);
                    QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Blue), WIDTH_420, 20);
                    QUI.Space(-20);
                    QUI.BeginHorizontal(WIDTH_420);
                    {
                        QUI.Space(SPACE_4);
                        QUI.Label("SPAWN AT", Style.Text.Normal, 60);
                        QUI.SetGUIBackgroundColor(AccentColorBlue);
                        QUI.BeginChangeCheck();
                        {
                            QUI.Popup(spawnAt, 70);
                        }
                        if(QUI.EndChangeCheck())
                        {

                            Undo.RecordObject(poolySpawner, "SpawnAt Change");

                            spawnPositions.ClearArray();
                            spawnPositions.InsertArrayElementAtIndex(0);
                            spawnPositions.GetArrayElementAtIndex(0).FindPropertyRelative("spawnPosition").vector3Value = new Vector3(0, 1, 0);

                            spawnPoints.ClearArray();
                            spawnPoints.InsertArrayElementAtIndex(0);
                            serializedObject.ApplyModifiedProperties();
                        }
                        QUI.ResetColors();
                        QUI.FlexibleSpace();
                        if((poolySpawner.spawnPositions != null && poolySpawner.spawnPositions.Count > 1 && poolySpawner.spawnAt == PoolySpawner.SpawnAt.Position) ||
                           (poolySpawner.spawnPoints != null && poolySpawner.spawnPoints.Count > 1 && poolySpawner.spawnAt == PoolySpawner.SpawnAt.Transform))
                        {
                            QUI.Label("Spawn Type", Style.Text.Normal, 68);
                            QUI.SetGUIBackgroundColor(AccentColorBlue);
                            QUI.Popup(locationSpawnType, 80, SpawnTypes);
                            QUI.ResetColors();
                        }
                        QUI.Space(SPACE_8);
                    }
                    QUI.EndHorizontal();
                    QUI.Space(SPACE_4);
                    switch(poolySpawner.spawnAt)
                    {
                        case PoolySpawner.SpawnAt.Position:
                            if(poolySpawner.spawnPositions == null || poolySpawner.spawnPositions.Count == 0) { poolySpawner.spawnPositions = new List<PoolySpawner.SpawnPosition> { new PoolySpawner.SpawnPosition(new Vector3(0, 1, 0)) }; }
                            if(poolySpawner.spawnPositions.Count == 1 && poolySpawner.locationSpawnType == PoolySpawner.SpawnType.Random) { poolySpawner.locationSpawnType = PoolySpawner.SpawnType.Sequential; }
                            for(int i = 0; i < poolySpawner.spawnPositions.Count; i++)
                            {
                                QUI.BeginHorizontal(WIDTH_420);
                                {
                                    tempContent = new GUIContent(i.ToString());
                                    tempContentSize = QStyles.CalcSize(tempContent, Style.Text.Small);
                                    QUI.Label(tempContent.text, Style.Text.Small, tempContentSize.x);
                                    QUI.BeginChangeCheck();
                                    Vector3 spawnPosition = poolySpawner.spawnPositions[i].spawnPosition;
                                    QUI.SetGUIBackgroundColor(AccentColorBlue);
                                    spawnPosition = QUI.Vector3(spawnPosition, (WIDTH_420 - SPACE_2 - tempContentSize.x - SPACE_8 - SPACE_16 - SPACE_4) - 240 * animBoolRandomSpawnLocation.faded);
                                    QUI.ResetColors();
                                    if(QUI.EndChangeCheck())
                                    {
                                        Undo.RecordObject(poolySpawner, "Changed Spawn Position " + i);
                                        poolySpawner.spawnPositions[i].spawnPosition = spawnPosition;
                                        QUI.SetDirty(poolySpawner);
                                    }
                                    if(QUI.ButtonMinus())
                                    {
                                        if(poolySpawner.spawnPositions.Count > 1)
                                        {
                                            Undo.RecordObject(poolySpawner, "Removed Spawn Position " + i);
                                            poolySpawner.spawnPositions.RemoveAt(i);
                                        }
                                        else if(poolySpawner.spawnPositions == null || poolySpawner.spawnPositions[0].spawnPosition != new Vector3(poolySpawner.transform.position.x, poolySpawner.transform.position.y + 1, poolySpawner.transform.position.z))
                                        {
                                            Undo.RecordObject(poolySpawner, "Reset Spawn Position");
                                            poolySpawner.spawnPositions = new List<PoolySpawner.SpawnPosition> { new PoolySpawner.SpawnPosition(new Vector3(poolySpawner.transform.position.x, poolySpawner.transform.position.y + 1, poolySpawner.transform.position.z)) };
                                        }
                                        QUI.SetDirty(poolySpawner);
                                        QUI.ExitGUI();
                                    }
                                    animBoolRandomSpawnLocation.target = locationSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random;
                                    if(poolySpawner.spawnPositions != null && poolySpawner.spawnPositions.Count > 1 && locationSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random)
                                    {
                                        QUI.Space(SPACE_2);
                                        QUI.Label("weight", Style.Text.Small, 40 * animBoolRandomSpawnLocation.faded);
                                        QUI.Space(-SPACE_8);
                                        QUI.BeginChangeCheck();
                                        int spawnPositionWeight = poolySpawner.spawnPositions[i].weight;
                                        QUI.SetGUIBackgroundColor(AccentColorBlue);
                                        spawnPositionWeight = EditorGUILayout.IntSlider(spawnPositionWeight, 0, 100);
                                        QUI.ResetColors();
                                        if(QUI.EndChangeCheck())
                                        {
                                            Undo.RecordObject(poolySpawner, "Changed Weight Of Spawn Position " + i);
                                            poolySpawner.spawnPositions[i].weight = spawnPositionWeight;
                                        }
                                    }
                                    QUI.FlexibleSpace();
                                    QUI.Space(SPACE_8);
                                }
                                QUI.EndHorizontal();
                                QUI.Space(1);
                            }
                            QUI.Space(SPACE_2);
                            QUI.BeginHorizontal(WIDTH_420);
                            {
                                QUI.FlexibleSpace();
                                if(QUI.ButtonPlus())
                                {
                                    Undo.RecordObject(poolySpawner, "Added Spawn Position");
                                    poolySpawner.spawnPositions.Add(new PoolySpawner.SpawnPosition(new Vector3(poolySpawner.transform.position.x, poolySpawner.transform.position.y + 1, poolySpawner.transform.position.z)));
                                    QUI.SetDirty(poolySpawner);
                                    QUI.ExitGUI();
                                }
                                QUI.Space(3 + 240 * animBoolRandomSpawnLocation.faded);
                            }
                            QUI.EndHorizontal();
                            break;
                        case PoolySpawner.SpawnAt.Transform:
                            if(poolySpawner.spawnPoints == null || poolySpawner.spawnPoints.Count == 0) { poolySpawner.spawnPoints = new List<PoolySpawner.SpawnPoint> { new PoolySpawner.SpawnPoint(null) }; }
                            if(poolySpawner.spawnPoints.Count == 1 && poolySpawner.locationSpawnType == PoolySpawner.SpawnType.Random) { poolySpawner.locationSpawnType = PoolySpawner.SpawnType.Sequential; }
                            infoMessage["NoSpawnPoint"].show.target = !poolySpawner.HasSpawnPoints();
                            // 画框框提示
                            DrawInfoMessage("NoSpawnPoint", WIDTH_420-20);
                            for(int i = 0; i < poolySpawner.spawnPoints.Count; i++)
                            {
                                QUI.BeginHorizontal(WIDTH_420);
                                {
                                    tempContent = new GUIContent(i.ToString());
                                    tempContentSize = QStyles.CalcSize(tempContent, Style.Text.Small);
                                    QUI.Label(tempContent.text, Style.Text.Small, tempContentSize.x);
                                    QUI.BeginChangeCheck();
                                    Transform spawnPoint = poolySpawner.spawnPoints[i].spawnPoint;
                                    QUI.SetGUIBackgroundColor(AccentColorBlue);
                                    spawnPoint = (Transform)QUI.ObjectField(spawnPoint, typeof(Transform), true, (WIDTH_420 - SPACE_2 - tempContentSize.x - SPACE_8 - SPACE_16 - SPACE_4) - 240 * animBoolRandomSpawnLocation.faded);
                                    QUI.ResetColors();
                                    if(QUI.IsPersistent(spawnPoint)) { spawnPoint = poolySpawner.spawnPoints[i].spawnPoint; }
                                    if(QUI.EndChangeCheck())
                                    {
                                        Undo.RecordObject(poolySpawner, "Changed Reference For Spawn Point Slot " + i);
                                        poolySpawner.spawnPoints[i].spawnPoint = spawnPoint;
                                        QUI.SetDirty(poolySpawner);
                                    }
                                    QUI.BeginVertical(16);
                                    {
                                        QUI.Space(SPACE_2);
                                        if(QUI.ButtonMinus())
                                        {
                                            if(poolySpawner.spawnPoints.Count > 1)
                                            {
                                                Undo.RecordObject(poolySpawner, "Removed Spawn Point Slot " + i);
                                                poolySpawner.spawnPoints.RemoveAt(i);
                                            }
                                            else if(poolySpawner.spawnPoints == null || poolySpawner.spawnPoints[0].spawnPoint != null)
                                            {
                                                Undo.RecordObject(poolySpawner, "Reset Spawn Point Slot");
                                                poolySpawner.spawnPoints = new List<PoolySpawner.SpawnPoint> { new PoolySpawner.SpawnPoint(null) };
                                            }
                                            QUI.SetDirty(poolySpawner);
                                            QUI.ExitGUI();
                                        }
                                    }
                                    QUI.EndVertical();
                                    animBoolRandomSpawnLocation.target = locationSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random;
                                    if(poolySpawner.spawnPoints != null && poolySpawner.spawnPoints.Count > 1 && locationSpawnType.enumValueIndex == (int)PoolySpawner.SpawnType.Random)
                                    {
                                        QUI.Space(SPACE_2);
                                        QUI.Label("weight", Style.Text.Small, 40);
                                        QUI.Space(-SPACE_8);
                                        QUI.BeginChangeCheck();
                                        int spawnPointWeight = poolySpawner.spawnPoints[i].weight;
                                        QUI.SetGUIBackgroundColor(AccentColorBlue);
                                        spawnPointWeight = EditorGUILayout.IntSlider(spawnPointWeight, 0, 100);
                                        QUI.ResetColors();
                                        if(QUI.EndChangeCheck())
                                        {
                                            Undo.RecordObject(poolySpawner, "Changed Weight Of Spawn Point " + i);
                                            poolySpawner.spawnPoints[i].weight = spawnPointWeight;
                                        }
                                    }
                                    QUI.FlexibleSpace();
                                    QUI.Space(SPACE_8);
                                }
                                QUI.EndHorizontal();
                                QUI.Space(1);
                            }
                            QUI.Space(SPACE_2);
                            QUI.BeginHorizontal(WIDTH_420);
                            {
                                QUI.FlexibleSpace();
                                if(QUI.ButtonPlus())
                                {
                                    Undo.RecordObject(poolySpawner, "Added Spawn Point Slot");
                                    poolySpawner.spawnPoints.Add(new PoolySpawner.SpawnPoint(null));
                                    QUI.SetDirty(poolySpawner);
                                    QUI.ExitGUI();
                                }
                                QUI.Space(3 + 240 * animBoolRandomSpawnLocation.faded);
                            }
                            QUI.EndHorizontal();
                            break;
                    }
                }
                QUI.EndVertical();
            }
            QUI.EndFadeGroup();
        }

        private void DrawOnSpawnEvents()
        {
            QUI.Space(SPACE_8);
            QUI.Box(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Purple), WIDTH_420, 40);
            QUI.Space(-40);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Space(SPACE_4);
                QUI.Label("回调事件", Style.Text.Title, 240, HEIGHT_16);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Space(SPACE_8+3);
                QUI.Toggle(showOnSpawnStarted);
                QUI.Space(-SPACE_2);
                tempContent.text = "Started";
                QUI.Label(tempContent.text, Style.Text.Small, QStyles.CalcSize(tempContent, Style.Text.Small).x);


                QUI.Space(SPACE_8);

                QUI.Toggle(showOnSpawnStopped);
                QUI.Space(-SPACE_2);
                tempContent.text = "Stopped";
                QUI.Label(tempContent.text, Style.Text.Small, QStyles.CalcSize(tempContent, Style.Text.Small).x);

                QUI.Space(SPACE_8);

                QUI.Toggle(showOnSpawnPaused);
                QUI.Space(-SPACE_2);
                tempContent.text = "Paused";
                QUI.Label(tempContent.text, Style.Text.Small, QStyles.CalcSize(tempContent, Style.Text.Small).x);

                QUI.Space(SPACE_8);

                QUI.Toggle(showOnSpawnResumed);
                QUI.Space(-SPACE_2);
                tempContent.text = "Resumed";
                QUI.Label(tempContent.text, Style.Text.Small, QStyles.CalcSize(tempContent, Style.Text.Small).x);

                QUI.Space(SPACE_8);

                QUI.Toggle(showOnSpawnFinished);
                QUI.Space(-SPACE_2);
                tempContent.text = "Finished";
                QUI.Label(tempContent.text, Style.Text.Small, QStyles.CalcSize(tempContent, Style.Text.Small).x);

                QUI.Space(SPACE_8);

                QUI.ResetColors();
            }
            QUI.EndHorizontal();
            if(showOnSpawnStarted.boolValue || showOnSpawnPaused.boolValue || showOnSpawnFinished.boolValue)
            {
                QUI.Space(SPACE_4);
            }
            QUI.SetGUIBackgroundColor(AccentColorPurple);
            animBoolShowOnSpawnStarted.target = showOnSpawnStarted.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowOnSpawnStarted.faded))
            {
                QUI.PropertyField(OnSpawnStarted, new GUIContent("OnSpawnStarted"), WIDTH_420 - 5);
            }
            QUI.EndFadeGroup();
            animBoolShowOnSpawnStopped.target = showOnSpawnStopped.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowOnSpawnStopped.faded))
            {
                QUI.PropertyField(OnSpawnStopped, new GUIContent("OnSpawnStopped"), WIDTH_420 - 5);
            }
            QUI.EndFadeGroup();
            animBoolShowOnSpawnPaused.target = showOnSpawnPaused.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowOnSpawnPaused.faded))
            {
                QUI.PropertyField(OnSpawnPaused, new GUIContent("OnSpawnPaused"), WIDTH_420 - 5);
            }
            QUI.EndFadeGroup();
            animBoolShowOnSpawnResumed.target = showOnSpawnResumed.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowOnSpawnResumed.faded))
            {
                QUI.PropertyField(OnSpawnResumed, new GUIContent("OnSpawnResumed"), WIDTH_420 - 5);
            }
            QUI.EndFadeGroup();
            animBoolShowOnSpawnFinished.target = showOnSpawnFinished.boolValue;
            if(QUI.BeginFadeGroup(animBoolShowOnSpawnFinished.faded))
            {
                QUI.PropertyField(OnSpawnFinished, new GUIContent("OnSpawnfinished"), WIDTH_420 - 5);
            }
            QUI.EndFadeGroup();
            QUI.ResetColors();
        }


    }
}
