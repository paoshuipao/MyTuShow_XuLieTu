using System;
using System.Collections;
using System.Collections.Generic;
using PSPUtil.Control;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceLoad : ILoad
{
    public T LoadRes<T>(string path) where T : Object
    {
        if (pathK_PrefabK.ContainsKey(path))
        {
            return (T)pathK_PrefabK[path];
        }
        else
        {
            T t = Resources.Load<T>(path);
            if (null == t)
            {
                throw new Exception("Resources 加载 路径错误 —— " + path);
            }
            pathK_PrefabK.Add(path, t);
            return t;
        }
    }

    public T[] LoadResAll<T>(string path) where T : Object
    {
        if (pathK_ManyK.ContainsKey(path))
        {
            return (T[])pathK_ManyK[path];
        }
        else
        {
            T[] ts = Resources.LoadAll<T>(path);
            if (null == ts|| ts.Length ==0)
            {
                throw new Exception("Resources 加载所有 有误,path 应为目录 —— " + path);
            }
            pathK_ManyK.Add(path, ts);
            return ts;
        }
    }

    public GameObject LoadPrefab(string path)
    {
        return LoadPrefab(path, null);
    }

    public GameObject LoadPrefab(string path, Transform parent)
    {
        GameObject prefab =  LoadRes<GameObject>(path);      //  获得预制体
        GameObject objLoad = Instantiate(prefab, parent);    // 实例化到场景
        return objLoad;
    }

    public void LoadPrefabAsyn(string path, Action<GameObject> action)
    {
        LoadPrefabAsyn(path, null, action);
    }

    public void LoadPrefabAsyn(string path, Transform parent, Action<GameObject> action)
    {
        Ctrl_Coroutine.Instance.StartCoroutine(StartLoadPrefab(parent, path, action));
    }

    public GameObject LoadUI(string path, Transform parent)
    {
        GameObject go = LoadPrefab(path, parent);
        LoadUISame(go);
        return go;
    }

    public void LoadUIAsyn(string path, Transform parent, Action<GameObject> action)
    {
        LoadPrefabAsyn(path, parent, (go) =>
        {
            LoadUISame(go);
            if (null != action)
            {
                action(go);
            }
        });
    }

    public void DestroyPrefab(GameObject go)
    {
        Object.Destroy(go);
    }




    public void DestroyPrefabAll(string path, GameObject go)
    {
        pathK_PrefabK.Remove(path);
        Object.DestroyImmediate(go);

    }

    public void CLear()
    {
        pathK_PrefabK.Clear();
        pathK_ManyK.Clear();
    }




    public List<string> GetPrefabList()
    {
        List<string> tmp = new List<string>();

        foreach (string path in pathK_PrefabK.Keys)
        {
            tmp.Add(string.Format("路径 -> {0}  预制体(包含Res) -> {1}", path.AddBlue(), pathK_PrefabK[path].ToString().AddYellow()));
        }
        return tmp;
    }



    private readonly Dictionary<string,Object> pathK_PrefabK = new Dictionary<string, Object>();
    private readonly Dictionary<string,Object[]> pathK_ManyK = new Dictionary<string, Object[]>();

    private GameObject Instantiate(GameObject go, Transform parent)  // 实例化
    {
        GameObject objLoad = Object.Instantiate(go);
        if (null != parent)
        {
            objLoad.transform.SetParent(parent);
        }
        return objLoad;
    }



    IEnumerator StartLoadPrefab(Transform parent, string path, Action<GameObject> action)
    {
        GameObject prefab;
        if (pathK_PrefabK.ContainsKey(path))
        {
            prefab = (GameObject)pathK_PrefabK[path];
        }
        else
        {
            ResourceRequest rr = Resources.LoadAsync<GameObject>(path);
            yield return rr;
            if (null == rr.asset)
            {
                throw new Exception("Resources 加载 路径错误 —— " + path);
            }
            prefab = rr.asset as GameObject;
            if (null == prefab)
            {
                throw new Exception("Resources 加载 的资源不是 预制体？ " + path);
            }
            pathK_PrefabK.Add(path, prefab);
        }

        GameObject objLoad = Instantiate(prefab, parent);    // 实例化到场景
        if (null!= action)
        {
            action(objLoad);
        }

    }


    private void LoadUISame(GameObject go)           // 加载 UI 通用
    {
        Transform objTransform = go.transform;
        RectTransform rect = objTransform as RectTransform;
        if (null == rect)
        {
            throw new Exception("这个方法是加载 UI的 —— " + go.name);
        }
        go.layer = LayerMask.NameToLayer("UI");
        objTransform.localPosition = Vector3.zero;
        objTransform.localScale = Vector3.one;
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, 0);
        rect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 0);
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
    }


}
