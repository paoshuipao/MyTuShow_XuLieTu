/*
using System.IO;
using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class MusicContrl : MonoBehaviour
{



    void Awake()
    {
        MyEventCenter.AddListener<Text,FileInfo,bool>(E_GameEvent.ShowMusicInfo, E_OnShow);
        MyEventCenter.AddListener(E_GameEvent.CloseMusicInfo, E_OnClose);

    }

    void OnDestroy()
    {
        MyEventCenter.RemoveListener<Text,FileInfo, bool>(E_GameEvent.ShowMusicInfo, E_OnShow);
        MyEventCenter.RemoveListener(E_GameEvent.CloseMusicInfo, E_OnClose);
    }



    private void E_OnShow(Text txName,FileInfo file,bool isNeedDaoRu)       // 显示
    {
        gameObject.SetActive(true);
    }



    private void E_OnClose()                  // 关闭
    {
        gameObject.SetActive(false);


    }






}
*/
