using QuickEditor;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Ez.Pooly
{
    [CustomEditor(typeof(PoolyDespawner))]
    [CanEditMultipleObjects]
    public class PoolyDespawnerEditor : QEditor
    {

        #region 私有
        protected override void OnEnable()
        {
            base.OnEnable();

            requiresContantRepaint = true;
        }


        PoolyDespawner poolyDespawner { get { return (PoolyDespawner)target; } }

        SerializedProperty
          OnDespawn,
          despawnAfter,
          autoStart,
          duration,
          //randomDuration, randomDuraionMinimum, randomDurationMaximum,
          useParticleSystemDuration,
          useParticleSystemStartDelay,
          useParticleSystemStartLifetime,
          extraTime,
          playOnSpawn,
          orDespawnAfterTime,
          onlyWithTag, targetTag,
          despawnOnCollisionEnter, despawnOnCollisionStay, despawnOnCollisionExit,
          despawnOnTriggerEnter, despawnOnTriggerStay, despawnOnTriggerExit,
          despawnOnCollisionEnter2D, despawnOnCollisionStay2D, despawnOnCollisionExit2D,
          despawnOnTriggerEnter2D, despawnOnTriggerStay2D, despawnOnTriggerExit2D,
          useRealTime;

        Color accentColorPurple { get { return QUI.IsProSkin ? QColors.Purple.Color : QColors.PurpleLight.Color; } }

        #endregion

        protected override void GenerateInfoMessages()
        {
            base.GenerateInfoMessages();

            infoMessage.Add("duration.floatValue", new InfoMessage()
            {
                title = "不能少于 0",
                message = "为 0 或者负数有什么鬼意思？",
                show = new AnimBool(false, Repaint),
                type = InfoMessageType.Error
            });

            infoMessage.Add("poolyDespawner.aSource", new InfoMessage()
            {
                title = "找不到播放器和音频",
                message = "添加 AudioSource + AudioClip 引用（可放在子类）",
                show = new AnimBool(false, Repaint),
                type = InfoMessageType.Error
            });

            infoMessage.Add("poolyDespawner.aSource.clip", new InfoMessage()
            {
                title = "找不到音频",
                message = "添加 AudioClip 引用到播放器中",
                show = new AnimBool(false, Repaint),
                type = InfoMessageType.Error
            });

            infoMessage.Add("poolyDespawner.pSystem", new InfoMessage()
            {
                title = "找不到粒子特效",
                message = "添加 ParticleSystem （可放在子类）",
                show = new AnimBool(false, Repaint),
                type = InfoMessageType.Error
            });
        }


        protected override void SerializedObjectFindProperties()
        {
            base.SerializedObjectFindProperties();

            OnDespawn = serializedObject.FindProperty("OnDespawn");
            despawnAfter = serializedObject.FindProperty("despawnAfter");
            autoStart = serializedObject.FindProperty("autoStart");
            duration = serializedObject.FindProperty("duration");
            useParticleSystemDuration = serializedObject.FindProperty("useParticleSystemDuration");
            useParticleSystemStartDelay = serializedObject.FindProperty("useParticleSystemStartDelay");
            useParticleSystemStartLifetime = serializedObject.FindProperty("useParticleSystemStartLifetime");
            extraTime = serializedObject.FindProperty("extraTime");
            playOnSpawn = serializedObject.FindProperty("playOnSpawn");
            orDespawnAfterTime = serializedObject.FindProperty("orDespawnAfterTime");
            onlyWithTag = serializedObject.FindProperty("onlyWithTag");
            targetTag = serializedObject.FindProperty("targetTag");
            despawnOnCollisionEnter = serializedObject.FindProperty("despawnOnCollisionEnter");
            despawnOnCollisionStay = serializedObject.FindProperty("despawnOnCollisionStay");
            despawnOnCollisionExit = serializedObject.FindProperty("despawnOnCollisionExit");
            despawnOnTriggerEnter = serializedObject.FindProperty("despawnOnTriggerEnter");
            despawnOnTriggerStay = serializedObject.FindProperty("despawnOnTriggerStay");
            despawnOnTriggerExit = serializedObject.FindProperty("despawnOnTriggerExit");
            despawnOnCollisionEnter2D = serializedObject.FindProperty("despawnOnCollisionEnter2D");
            despawnOnCollisionStay2D = serializedObject.FindProperty("despawnOnCollisionStay2D");
            despawnOnCollisionExit2D = serializedObject.FindProperty("despawnOnCollisionExit2D");
            despawnOnTriggerEnter2D = serializedObject.FindProperty("despawnOnTriggerEnter2D");
            despawnOnTriggerStay2D = serializedObject.FindProperty("despawnOnTriggerStay2D");
            despawnOnTriggerExit2D = serializedObject.FindProperty("despawnOnTriggerExit2D");
            useRealTime = serializedObject.FindProperty("useRealTime");
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            switch(poolyDespawner.despawnAfter)
            {
                case PoolyDespawner.DespawnAfter.Time:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerTime.texture, WIDTH_420, 42);
                    DrawTime();
                    break;
                case PoolyDespawner.DespawnAfter.SoundPlayed:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerSoundPlayed.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawSound();
                    break;
                case PoolyDespawner.DespawnAfter.EffectPlayed:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerEffectPlayed.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawEffect();
                    break;
                case PoolyDespawner.DespawnAfter.Collision:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerCollider.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawCollision();
                    break;
                case PoolyDespawner.DespawnAfter.Trigger:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerTrigger.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawTrigger();
                    break;
                case PoolyDespawner.DespawnAfter.Collision2D:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerCollider2D.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawCollision2D();
                    break;
                case PoolyDespawner.DespawnAfter.Trigger2D:
                    DrawHeader(EZResources.editorHeaderPoolyDespawnerTrigger2D.texture, WIDTH_420, 42);
                    useRealTime.boolValue = false;
                    DrawTrigger2D();
                    break;
            }
            QUI.Space(SPACE_4);
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.PropertyField(OnDespawn, new GUIContent("OnDespawn"), WIDTH_420);
            QUI.ResetColors();
            QUI.Space(SPACE_4);
            serializedObject.ApplyModifiedProperties();
            QUI.Space(SPACE_4);
        }

        void DrawTime()                                    // 画自定义时间消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();
                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                QUI.Label("Auto Start", Style.Text.Normal, 55);
                QUI.BeginChangeCheck();
                QUI.PropertyField(autoStart, 90);


                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.autoStart = (PoolyDespawner.AutoStart)autoStart.enumValueIndex;
                        }
                    }
                }

            }
            QUI.EndHorizontal();
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Label("Duration", Style.Text.Normal, 52);
                QUI.BeginChangeCheck();
                QUI.PropertyField(duration, 40);
                if (duration.floatValue <= 0)
                {
                    duration.floatValue = 0;
                }
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.duration = duration.floatValue;
                        }
                    }
                }
                QUI.Space(30);
                QUI.BeginChangeCheck();
                QUI.Toggle(useRealTime);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.useRealTime = useRealTime.boolValue;
                        }
                    }
                }
                QUI.Label("使用 真实时间 代替 游戏时间", Style.Text.Normal);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
            infoMessage["duration.floatValue"].show.target = duration.floatValue <= 0;
            DrawInfoMessage("duration.floatValue", WIDTH_420);
        }

        void DrawSound()                                   // 音频结束后消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();
                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                QUI.BeginChangeCheck();
                QUI.Toggle(playOnSpawn);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.playOnSpawn = playOnSpawn.boolValue;
                        }
                    }
                }
                QUI.Label("Play On Spawn", Style.Text.Normal, 84);
            }
            QUI.EndHorizontal();
            if(poolyDespawner.aSource == null)
            {
                QUI.Label("AudioSource: Not Found", Style.Text.Normal, WIDTH_420);
                infoMessage["poolyDespawner.aSource"].show.target = true;
                infoMessage["poolyDespawner.aSource.clip"].show.target = false;
            }
            else if(poolyDespawner.aSource.clip == null)
            {
                QUI.Label("AudioSource: " + poolyDespawner.aSource.gameObject.name, Style.Text.Normal, WIDTH_420);
                QUI.Label("AudioClip: Not Found", Style.Text.Normal, WIDTH_420);
                infoMessage["poolyDespawner.aSource"].show.target = false;
                infoMessage["poolyDespawner.aSource.clip"].show.target = true;
            }
            else
            {
                QUI.Label("AudioSource 对象      ->  " + poolyDespawner.aSource.gameObject.name, Style.Text.Normal, WIDTH_420);
                QUI.Label("使用的音频文件名      ->  " + poolyDespawner.aSource.clip.name, Style.Text.Normal, WIDTH_420);
                QUI.Label("总共持续时间为          ->  " + poolyDespawner.aSource.clip.length + " 秒", Style.Text.Normal, WIDTH_420);
                infoMessage["poolyDespawner.aSource"].show.target = false;
                infoMessage["poolyDespawner.aSource.clip"].show.target = false;
            }
            QUI.ResetColors();
            DrawInfoMessage("poolyDespawner.aSource", WIDTH_420);
            DrawInfoMessage("poolyDespawner.aSource.clip", WIDTH_420);
        }

        void DrawEffect()                                  // 粒子特效结束后消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();
                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                QUI.BeginChangeCheck();
                QUI.Toggle(playOnSpawn);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.playOnSpawn = playOnSpawn.boolValue;
                        }
                    }
                }
                QUI.Label("Play On Spawn", Style.Text.Normal, 84);
            }
            QUI.EndHorizontal();
            if(poolyDespawner.pSystem == null)
            {
                QUI.Label("ParticleSystem 对象 ->  没找到", Style.Text.Normal, WIDTH_420);
                infoMessage["poolyDespawner.pSystem"].show.target = true;
            }
            else
            {
                QUI.Label("ParticleSystem 对象 ->  " + poolyDespawner.pSystem.gameObject.name, Style.Text.Normal, WIDTH_420);
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(useParticleSystemDuration, 12);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.useParticleSystemDuration = useParticleSystemDuration.boolValue;
                            }
                        }
                    }
                    QUI.Label("Duration           -> " + poolyDespawner.pSystem.main.duration + " 秒", Style.Text.Normal, WIDTH_420 - 12);
                }
                QUI.EndHorizontal();
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(useParticleSystemStartDelay, 12);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.useParticleSystemStartDelay = useParticleSystemStartDelay.boolValue;
                            }
                        }
                    }
                    QUI.Label("Start Delay       -> " + poolyDespawner.pSystem.main.startDelay.constant + " 秒", Style.Text.Normal, WIDTH_420);
                }
                QUI.EndHorizontal();
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(useParticleSystemStartLifetime, 12);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.useParticleSystemStartLifetime = useParticleSystemStartLifetime.boolValue;
                            }
                        }
                    }
                    QUI.Label("Start Lifetime  -> " + poolyDespawner.pSystem.main.startLifetime.constant + " 秒", Style.Text.Normal, WIDTH_420);
                }
                QUI.EndHorizontal();
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.Label("需要额外增加时间", Style.Text.Normal, 65);
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(extraTime, 40);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.extraTime = extraTime.floatValue;
                            }
                        }
                    }
                    QUI.Label(" 秒", Style.Text.Normal, 50);
                }
                QUI.EndHorizontal();
                QUI.Space(SPACE_2);
                QUI.Button(QStyles.GetBackgroundStyle(Style.BackgroundType.Low, QColors.Color.Purple), WIDTH_420, 20);
                QUI.Space(-20);
                QUI.BeginHorizontal(WIDTH_420);
                {
                    QUI.Space(2);
                    QUI.Label("开始到消失总时间长: " + poolyDespawner.pSystemTotalDuration + " 秒", Style.Text.Normal, WIDTH_420);
                }
                QUI.EndHorizontal();
                infoMessage["poolyDespawner.pSystem"].show.target = false;
            }
            QUI.ResetColors();
            DrawInfoMessage("poolyDespawner.pSystem", WIDTH_420);
        }

        void DrawCollision()                               // 3D碰撞后消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();
                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                if(!orDespawnAfterTime.boolValue)
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 50);
                }
                else
                {
                    QUI.FlexibleSpace();
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 30);
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(duration, 40);
                    if(duration.floatValue <= 0) { duration.floatValue = 0; }
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.duration = duration.floatValue;
                            }
                        }
                    }
                    QUI.Label("秒", Style.Text.Normal, 50);
                }
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
            infoMessage["duration.floatValue"].show.target = duration.floatValue <= 0 && orDespawnAfterTime.boolValue;
            DrawInfoMessage("duration.floatValue", WIDTH_420);
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Label("碰撞后，“消失”在那调用：", Style.Text.Normal, 138);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionEnter);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionEnter = despawnOnCollisionEnter.boolValue;
                        }
                    }
                }
                QUI.Label("Enter", Style.Text.Normal, 34);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionStay);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionStay = despawnOnCollisionStay.boolValue;
                        }
                    }
                }
                QUI.Label("Stay", Style.Text.Normal, 28);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionExit);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionExit = despawnOnCollisionExit.boolValue;
                        }
                    }
                }
                QUI.Label("Exit", Style.Text.Normal, 24);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.PropertyField(onlyWithTag, 12);
                QUI.Label("仅和 tag 碰撞", Style.Text.Normal, 120);
                QUI.BeginChangeCheck();
                targetTag.stringValue = EditorGUILayout.TagField(targetTag.stringValue);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.targetTag = targetTag.stringValue;
                        }
                    }
                }
                QUI.Space(SPACE_4);
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
        }



        void DrawTrigger()                                 // 3D触碰后消失
        {
            QUI.SetGUIBackgroundColor(QColors.PurpleLight.Color);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();
                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                if(!orDespawnAfterTime.boolValue)
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 50);
                  
                }
                else
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 30);
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(duration, 40);
                    if(duration.floatValue <= 0) { duration.floatValue = 0; }
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.duration = duration.floatValue;
                            }
                        }
                    }
                    QUI.Label("秒", Style.Text.Normal, 50);
                }
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
            infoMessage["duration.floatValue"].show.target = duration.floatValue <= 0 && orDespawnAfterTime.boolValue;
            DrawInfoMessage("duration.floatValue", WIDTH_420);
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Label("接触后，“消失”在那调用：", Style.Text.Normal, 138);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerEnter);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerEnter = despawnOnTriggerEnter.boolValue;
                        }
                    }
                }
                QUI.Label("Enter", Style.Text.Normal, 34);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerStay);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerStay = despawnOnTriggerStay.boolValue;
                        }
                    }
                }
                QUI.Label("Stay", Style.Text.Normal, 28);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerExit);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerExit = despawnOnTriggerExit.boolValue;
                        }
                    }
                }
                QUI.Label("Exit", Style.Text.Normal, 24);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.PropertyField(onlyWithTag, 12);
                QUI.Label("仅和 tag 碰撞", Style.Text.Normal, 120);
                QUI.BeginChangeCheck();
                targetTag.stringValue = EditorGUILayout.TagField(targetTag.stringValue);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.targetTag = targetTag.stringValue;
                        }
                    }
                }
                QUI.Space(SPACE_4);
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
        }

        void DrawCollision2D()                             // 2D碰撞后消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();

                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                if(!orDespawnAfterTime.boolValue)
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 50);
                }
                else
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 30);
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(duration, 40);
                    if(duration.floatValue <= 0) { duration.floatValue = 0; }
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.duration = duration.floatValue;
                            }
                        }
                    }
                    QUI.Label("秒", Style.Text.Normal, 50);
                }
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
            infoMessage["duration.floatValue"].show.target = duration.floatValue <= 0 && orDespawnAfterTime.boolValue;
            DrawInfoMessage("duration.floatValue", WIDTH_420);
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Label("碰撞后，“消失”在那调用", Style.Text.Normal, 130);
                QUI.Space(SPACE_8);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionEnter2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionEnter2D = despawnOnCollisionEnter2D.boolValue;
                        }
                    }
                }
                QUI.Label("Enter2D", Style.Text.Normal, 46);
                QUI.Space(3);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionStay2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionStay2D = despawnOnCollisionStay2D.boolValue;
                        }
                    }
                }
                QUI.Label("Stay2D", Style.Text.Normal, 40);
                QUI.Space(3);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnCollisionExit2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnCollisionExit2D = despawnOnCollisionExit2D.boolValue;
                        }
                    }
                }
                QUI.Label("Exit2D", Style.Text.Normal, 40);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.PropertyField(onlyWithTag, 12);
                QUI.Label("仅和 tag 碰撞", Style.Text.Normal, 120);
                QUI.BeginChangeCheck();
                targetTag.stringValue = EditorGUILayout.TagField(targetTag.stringValue);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.targetTag = targetTag.stringValue;
                        }
                    }
                }
                QUI.Space(SPACE_4);
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
        }

        void DrawTrigger2D()                               // 2D触碰后消失
        {
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                XiaoShiType();

                if (QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnAfter = (PoolyDespawner.DespawnAfter)despawnAfter.enumValueIndex;
                        }
                    }
                }
                QUI.FlexibleSpace();
                if(!orDespawnAfterTime.boolValue)
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 30);
                }
                else
                {
                    QUI.BeginChangeCheck();
                    QUI.Toggle(orDespawnAfterTime);
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.orDespawnAfterTime = orDespawnAfterTime.boolValue;
                            }
                        }
                    }
                    QUI.Label("延时", Style.Text.Normal, 50);
                    QUI.BeginChangeCheck();
                    QUI.PropertyField(duration, 40);
                    if(duration.floatValue <= 0) { duration.floatValue = 0; }
                    if(QUI.EndChangeCheck())
                    {
                        if(serializedObject.isEditingMultipleObjects)
                        {
                            Undo.RecordObjects(targets, "Multiple Edit");
                            for(int i = 0; i < targets.Length; i++)
                            {
                                PoolyDespawner despawner = (PoolyDespawner)targets[i];
                                despawner.duration = duration.floatValue;
                            }
                        }
                    }
                    QUI.Label("秒", Style.Text.Normal, 50);
                }
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
            infoMessage["duration.floatValue"].show.target = duration.floatValue <= 0 && orDespawnAfterTime.boolValue;
            DrawInfoMessage("duration.floatValue", WIDTH_420);
            QUI.SetGUIBackgroundColor(accentColorPurple);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.Label("接触后，“消失”在那调用", Style.Text.Normal, 130);

                QUI.Space(3);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerEnter2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerEnter2D = despawnOnTriggerEnter2D.boolValue;
                        }
                    }
                }
                QUI.Label("Enter2D", Style.Text.Normal, 46);
                QUI.Space(3);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerStay2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerStay2D = despawnOnTriggerStay2D.boolValue;
                        }
                    }
                }
                QUI.Label("Stay2D", Style.Text.Normal, 40);
                QUI.Space(3);
                QUI.BeginChangeCheck();
                QUI.Toggle(despawnOnTriggerExit2D);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.despawnOnTriggerExit2D = despawnOnTriggerExit2D.boolValue;
                        }
                    }
                }
                QUI.Label("Exit2D", Style.Text.Normal, 40);
                QUI.FlexibleSpace();
            }
            QUI.EndHorizontal();
            QUI.Space(SPACE_4);
            QUI.BeginHorizontal(WIDTH_420);
            {
                QUI.PropertyField(onlyWithTag, 12);
                QUI.Label("仅和 tag 碰撞", Style.Text.Normal, 120);
                QUI.BeginChangeCheck();
                targetTag.stringValue = EditorGUILayout.TagField(targetTag.stringValue);
                if(QUI.EndChangeCheck())
                {
                    if(serializedObject.isEditingMultipleObjects)
                    {
                        Undo.RecordObjects(targets, "Multiple Edit");
                        for(int i = 0; i < targets.Length; i++)
                        {
                            PoolyDespawner despawner = (PoolyDespawner)targets[i];
                            despawner.targetTag = targetTag.stringValue;
                        }
                    }
                }
                QUI.Space(SPACE_4);
            }
            QUI.EndHorizontal();
            QUI.ResetColors();
        }




        //————————————————————————————————————

        private void XiaoShiType()                         // 消失类型
        {
            QUI.Label("消失类型    ", Style.Text.Normal, 50);
            QUI.BeginChangeCheck();
            QUI.PropertyField(despawnAfter, 120);
        }

    }
}
