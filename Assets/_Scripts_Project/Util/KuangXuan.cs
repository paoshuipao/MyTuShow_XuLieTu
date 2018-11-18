using System.Collections.Generic;
using UnityEngine;

public class KuangXuan : MonoBehaviour
{


    public void Init(Dictionary<GameObject, GameObject> dic)
    {
        chooseGOK_BgV = dic;
    }

    public void OnClickDown()           // 按下
    {
        isClickUp = false;
    }


    public void OnClickUp()             // 抬起
    {
        isClickUp = true;
    }



    private bool isClickUp = false;

    private Dictionary<GameObject, GameObject> chooseGOK_BgV;


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        if (!chooseGOK_BgV.ContainsKey(go))
        {
            GameObject go_Bg = go.transform.Find("Bg").gameObject;
            go_Bg.SetActive(true);
            chooseGOK_BgV.Add(go, go_Bg);
        }

    }



    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (!isClickUp && chooseGOK_BgV.ContainsKey(go))
        {
            chooseGOK_BgV[go].SetActive(false);
            chooseGOK_BgV.Remove(go);
        }
    }







}
