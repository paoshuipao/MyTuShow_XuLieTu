using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class Sub_Setting : SubUI 
{

    public void Show()
    {
        mUIGameObject.SetActive(true);
        for (ushort i = 0; i < 8; i++)
        {
            l_LeftTittleNames[i].text = Ctrl_ContantInfo.Instance.LeftItemNames[i];
            for (ushort j = 0; j < 5; j++)
            {
                l_BottomNames[i][j].text = Ctrl_ContantInfo.Instance.BottomName[i][j];
                l_Counts[i][j].text = Ctrl_XuLieTu.Instance.GetEachCount(i, j) + " 张";
            }
        }
    }


    public void Close()
    {
        mUIGameObject.SetActive(false);
    }




    protected override void OnStart(Transform root)
    {

        MyEventCenter.AddListener(E_GameEvent.OnClickSureDeleteAll, E_SureDeleteAll);

        
        for (int i = 0; i < 8; i++)
        {
            l_LeftTittleNames[i] = Get<Text>("TopGrid/Tittle/LeftName" + i+"/LeftName");
            Text[] l_EachBottoms = new Text[5];
            Text[] l_EachCounts= new Text[5];
            for (int j = 0; j < 5; j++)
            {
                l_EachBottoms[j] = Get<Text>("TopGrid/Contant/LeftItem"+i+"/BottomItem"+j+"/TxName");
                l_EachCounts[j] = Get<Text>("TopGrid/Contant/LeftItem"+i+"/BottomItem"+j+ "/TxNum");
            }
            l_BottomNames[i] = l_EachBottoms;
            l_Counts[i] = l_EachCounts;
        }

        AddButtOnClick("Bottom/DeleteAll/Button", Btn_DeleteAll);

    }


    public override void OnEnable()
    {

    }


    #region 私有


    private readonly Text[] l_LeftTittleNames = new Text[8];
    private readonly Text[][] l_BottomNames = new Text[8][];
    private readonly Text[][] l_Counts = new Text[8][];



    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/Setting";
    }





    public override void OnDisable()
    {
    }



    #endregion



    private void Btn_DeleteAll()            // 点击 准备清除所有
    {

        MyEventCenter.SendEvent(E_GameEvent.ShowBeforeClick, EBeforeShow.DeleteAllSure);

    }



    private void E_SureDeleteAll()            // 确定 删除所有
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                l_Counts[i][j].text = "0 张";
            }
        }
    }



}
