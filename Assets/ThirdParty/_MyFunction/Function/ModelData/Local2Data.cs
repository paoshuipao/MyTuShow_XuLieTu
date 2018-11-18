/*
using PSPUtil.StaticUtil;
using UnityEngine;

public class Local2Data : IModel2Data            // 本地存储数据的方法
{
    public int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public float GetFloat(string key, float defaultValue = 0)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public bool GetBool(string key, bool defaultValue = false)
    {
        
        int intValue = GetInt(key, defaultValue?1:0);      // 0 -> false  1 - >true
        return intValue == 1;

    }

    public string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);

    }

    public T GetBean<T>(string key)                    // TODO 这个用 xml 存储 Bean
    {
        MyLog.Red("未实现");
        return default(T);
    }


    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key,value);
    }

    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key,value);
    }

    public void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value?1:0);

    }

    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public void SetBean<T>(string key, T value)      // TODO 这个用 xml 存储 Bean
    {
        MyLog.Red("未实现");

    }
}
*/
