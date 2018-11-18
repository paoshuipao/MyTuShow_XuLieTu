using PSPUtil.Singleton;
using UnityEngine;

public abstract class ModelBase<T> : Singleton_Mono<T> where T:MonoBehaviour
{


    protected abstract string GetFileName();     // 文件名


    protected abstract void InitData();         // 开始加载数据


    protected abstract void SaveData();         // 退出保存数据



    private string mFileName;


    protected override void OnAwake()
    {
        base.OnAwake();
        mFileName = GetFileName();
        InitData();
    }


    void OnApplicationQuit()
    {
        SaveData();
    }


    //————————————————————————————————————

    protected bool IsExit(string key)
    {
        return ES3.KeyExists(key, mFileName);
    }


    protected R Load<R>(string key)
    {
        return ES3.Load<R>(key, mFileName);
    }


    protected R Load<R>(string key, R defaultValue)
    {
        return ES3.Load(key, mFileName, defaultValue);
    }


    protected void Save<R>(string key,R value)
    {
        ES3.Save<R>(key, value, mFileName);
    }


}
