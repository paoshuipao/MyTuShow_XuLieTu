using System;
using PSPUtil;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public enum EBeforeShow
{
    Color1 = 0,
    Color2,
    Color3,
    Color4,
    Color5,
    Color6,
    Color7,
    Color8,
    DeleteAllSure,

}




public class Sub_BeforeClick : SubUI 
{



    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener<EBeforeShow>(E_GameEvent.ShowBeforeClick, E_Show);


        // 颜色
        l_ColorsStr[0] = "white";
        l_ColorsStr[1] = "red";
        l_ColorsStr[2] = "#ff00ffff";
        l_ColorsStr[3] = "blue";
        l_ColorsStr[4] = "green";
        l_ColorsStr[5] = "yellow";

        Get<Button>().onClick.AddListener(Btn_OnBigClick);


        for (int i = 0; i < 8; i++)
        {
            GameObject go = GetGameObject("Left/Item"+(i+1)+"/ColorContrl");
            l_GoColors[i] = go;
            for (int j = 0; j < 6; j++)
            {
                string colorStr = l_ColorsStr[j];
                go.transform.Find("Color"+(j+1)).GetComponent<Button>().onClick.AddListener(() =>
                {
                    MyEventCenter.SendEvent(E_GameEvent.OnClickChangeColor, (ushort)mCurrentType ,colorStr);
                    Btn_OnBigClick();
                });
            }
        }


        // 删除所有
        go_DeleteAll = GetGameObject("Right/DeleteAll");
        AddButtOnClick("Right/DeleteAll/Contant/Btn", Btn_DeleteSure);

    }


    #region 私有

    // 颜色
    private EBeforeShow mCurrentType;
    private readonly GameObject[] l_GoColors = new GameObject[8];
    private readonly string[] l_ColorsStr = new string[6];
    private GameObject mCurrentShowGO;

    // 删除所有
    private GameObject go_DeleteAll;



    public override string GetUIPathForRoot()
    {
        return "BeforeClick";
    }


    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }


    #endregion

    private void Btn_OnBigClick()          // 点击了最大的按钮
    {
        mUIGameObject.SetActive(false);
        mCurrentShowGO.SetActive(false);
        mCurrentShowGO = null;
    }



    private void Btn_DeleteSure()           // 点击 确定删除
    {
        MyEventCenter.SendEvent(E_GameEvent.OnClickSureDeleteAll);
        Btn_OnBigClick();
    }




    //—————————————————— 事件——————————————————


    private void E_Show(EBeforeShow showWhich)
    {
        mCurrentType = showWhich;
        mUIGameObject.SetActive(true);

        switch (showWhich)
        {
            case EBeforeShow.Color1:
            case EBeforeShow.Color2:
            case EBeforeShow.Color3:
            case EBeforeShow.Color4:
            case EBeforeShow.Color5:
            case EBeforeShow.Color6:
            case EBeforeShow.Color7:
            case EBeforeShow.Color8:
                mCurrentShowGO = l_GoColors[(ushort)showWhich];
                break;
            case EBeforeShow.DeleteAllSure:
                mCurrentShowGO = go_DeleteAll;
                break;
            default:
                throw new Exception("未定义");
        }

        mCurrentShowGO.SetActive(true);


    }


}
