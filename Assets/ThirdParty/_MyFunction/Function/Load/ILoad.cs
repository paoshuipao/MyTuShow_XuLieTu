using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public interface ILoad  
{


    //——————————————————加载其他 Asset 资源（如文本）——————————————————

    T LoadRes<T>(string path)       where T : Object;      // 加载单个


    T[] LoadResAll<T>(string path)   where T : Object;     // 加载多个



    //——————————————————加载 prefab ( UI 也算是) ——————————————————


    GameObject LoadPrefab(string path);

    GameObject LoadPrefab(string path, Transform parent);

    void LoadPrefabAsyn(string path, Action<GameObject> action);

    void LoadPrefabAsyn(string path, Transform parent, Action<GameObject> action);

    GameObject LoadUI(string path, Transform parent);

    void LoadUIAsyn(string path, Transform parent, Action<GameObject> action);



    void DestroyPrefab(GameObject go);                      // 删除场景上已实例化的（预制体不会删除）


    void DestroyPrefabAll(string path, GameObject go);



    void CLear();                                           // 删除所有（跳场景时调用）



    List<string> GetPrefabList();
}
