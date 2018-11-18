using System;
using System.Collections.Generic;
using DG.Tweening;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityEditor
{
    public class Tools_Unity : AbstractChooseKuang<Tools_Unity>
    {
        protected override void OnEditorGUI()
        {
            switch (m_FenLie)
            {
                case UGongJuType.查找丢失脚本:
                    DrawMiss();
                    break;
                case UGongJuType.名称找路径:
                    DrawDaBao();
                    break;
                case UGongJuType.DoTween工具:
                    DrawDoTween();
                    break;
                case UGongJuType.运行查看:
                    DrawRunning();
                    break;
            }
        }


        #region 私有


        [GUIColor(0.1f, 0.8f, 0.8f)]
        [HideLabel]
        [EnumToggleButtons(true, 80)]
        public UGongJuType m_FenLie = UGongJuType.查找丢失脚本;

        public enum UGongJuType
        {
            查找丢失脚本,
            名称找路径,
            DoTween工具,
            运行查看
        }


        [MenuItem(LearnMenu.GONGJU_Unity)]
        public static void ShowWindow()
        {
            CreateWindow("实用工具", 420, 420);
        }



        private List<DOTweenAnimation> l_DoTweens =new List<DOTweenAnimation>();
        protected override void OnInit()
        {
            base.OnInit();
            ShuaiXinList();
        }


        private void ShuaiXinList()
        {
            l_DoTweens.Clear();
            DOTweenAnimation[] list = FindObjectsOfType<DOTweenAnimation>();
            foreach (DOTweenAnimation animation in list)
            {
                l_DoTweens.Add(animation);
            }
        }


        private void FindMiss(GameObject[] gos)
        {

            if (gos.Length == 0)
            {
                m_Tools.Text_L("Resources 都没有东西");
            }
            else
            {
                bool isNull = true;
                foreach (GameObject go in gos)
                {
                    MonoBehaviour[] cs = go.GetComponents<MonoBehaviour>();

                    foreach (MonoBehaviour component in cs)
                    {
                        if (null == component)
                        {
                            MyCreate.SelectText(go.name);
                            isNull = false;
                        }
                    }
                }
                if (isNull)
                {
                    m_Tools.Text_L("没有");
                }
            }
        }




        private void DrawText(string str1, string str2, string tip, Transform t)
        {
            MyCreate.Heng(() =>
            {
                if (!string.IsNullOrEmpty(tip))
                {
                    tip = ("(" + tip + ")").AddLightBlue();
                }
                m_Tools.TextText_BY(str1, str2 + tip, -40);
                MyCreate.AddSpace();
                MyCreate.Button(" ◀ ", 28, () =>
                {
                    Selection.activeTransform = t;
                });

            });


        }
        #endregion


        private void DrawMiss()                           // 查找丢失的脚本
        {

            m_Tools.BiaoTi_B("查找 Resources 下的有没有丢失脚本");
            MyCreate.Box(() =>
            {
                GameObject[] gos = Resources.FindObjectsOfTypeAll<GameObject>();
                FindMiss(gos);

            });
            AddSpace();
            m_Tools.BiaoTi_B("查找 场景 中的有没有丢失脚本");
            MyCreate.Box(() =>
            {
                GameObject[] gos = GameObject.FindObjectsOfType<GameObject>();
                FindMiss(gos);
            });

            MyCreate.AddSpace();

        }



        private void DrawDaBao()                          // 打包
        {

            m_Tools.TextButton_Open("打开 persistentDataPath ", Application.persistentDataPath);


        }



        private void DrawDoTween()                       // DoTween 工具
        {

            for (int i = 0; i < l_DoTweens.Count; i++)
            {
                DrawText(l_DoTweens[i].name, l_DoTweens[i].animationType.ToString(), l_DoTweens[i].tipStr, l_DoTweens[i].transform);
            }
            MyCreate.AddSpace();
            MyCreate.Button("           刷新一下", ShuaiXinList);
        }




        private void DrawRunning()                       // 运行工具
        {
            if (Application.isPlaying)
            {
                LoadManager load = Manager.Get<LoadManager>(EF_Manager.Load);
//                List<string> l_Res = load.GetResList();
//                m_Tools.BiaoTi_B("产生的资源");
//                MyCreate.Box(() =>
//                {
//                    if (l_Res.Count == 0)
//                    {
//                        m_Tools.Text_H("没有产生 资源文件");
//                    }
//                    else
//                    {
//                        foreach (string res in l_Res)
//                        {
//                            m_Tools.Text_H(res);
//                        }
//                    }
//                });
//

                List<string> l_Prefabs = load.GetPrefabList();

                m_Tools.BiaoTi_B("产生的预制体");
                MyCreate.Box(() =>
                {
                    if (l_Prefabs.Count == 0)
                    {
                        m_Tools.Text_H("没有产生 预制体 到场景");
                    }
                    else
                    {
                        foreach (string prefab in l_Prefabs)
                        {
                            m_Tools.Text_H(prefab);
                        }
                    }
                });

            }
            else
            {
                m_Tools.Text_L("没有运行");
            }


        }



    }
}