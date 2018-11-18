using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PSPUtil.StaticUtil;
using UnityEngine;
using Object = UnityEngine.Object;

public class LoadManager : Manager
{


    private readonly ILoad loadUI = new ResourceLoad();


    //——————————————————加载其他 Asset 资源（如文本）——————————————————


    public T LoadRes<T>(string path)                                         // 加载资源，非Prefab
        where T : Object
    {
       return loadUI.LoadRes<T>(path);
    }


    public T[] LoadResAll<T>(string path)
        where T : Object
    {
        return loadUI.LoadResAll<T>(path);
    }




    //——————————————————加载 prefab ( UI 也算是) ——————————————————

    public GameObject LoadPrefab(string path)
    {
        return loadUI.LoadPrefab(path);
    }

    public GameObject LoadPrefab(string path, Transform parent)     // 加载 Prefab
    {
        return loadUI.LoadPrefab(path,parent);
    }

    public void LoadPrefabAsyn(string path, [NotNull]Action<GameObject> action)
    {
        loadUI.LoadPrefabAsyn(path, action);
    }



    public void LoadPrefabAsyn(Transform parent, string path, [NotNull]Action<GameObject> action)
    {
        loadUI.LoadPrefabAsyn(path,parent, action);
    }



    public GameObject LoadUI(string path, Transform parent)
    {
        return loadUI.LoadUI(path, parent);
    }


    public void LoadUIAsyn(string path, Transform parent, [NotNull]Action<GameObject> action)
    {
        loadUI.LoadUIAsyn(path,parent,action);

    }

    //——————————————————清理——————————————————



    public void Destory(GameObject go)                     // 销毁 Prefab 通过 GameObject
    {
        loadUI.DestroyPrefab(go);
    }


    public void DestroyPrefabAll(string path,GameObject go)
    {
        loadUI.DestroyPrefabAll(path,go);
    }



    public void CLearRes()                                         // 清除所有资源
    {
        loadUI.CLear();
    }


    //——————————————————用来打印 Log 到 Editor 中——————————————————


    public List<string> GetPrefabList()
    {
        return loadUI.GetPrefabList();
    }




    //—————————————————— 获得 Sprite ——————————————————

    private readonly Dictionary<string,Sprite[]> pathK_SpsV = new Dictionary<string, Sprite[]>();


    public Sprite GetSprite(string path,string spName)
    {
        Sprite[] res;
        if (pathK_SpsV.ContainsKey(path))
        {
            res = pathK_SpsV[path];
        }
        else
        {
            res = loadUI.LoadResAll<Sprite>(path);
            pathK_SpsV.Add(path, res);
        }

        if (null == res || res.Length ==0)
        {
            throw new Exception("路径有误" + path);
        }

        for (int i = 0; i < res.Length; i++)
        {
            if (res[i].name == spName)
            {
                return res[i];
            }
        }

        throw new Exception(path+"  这个路径下的 Sprite 没有  "+ spName);


    }



}
