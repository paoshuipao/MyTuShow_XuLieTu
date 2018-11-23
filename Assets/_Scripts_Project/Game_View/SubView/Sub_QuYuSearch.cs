using System.Collections;
using PSPUtil;
using PSPUtil.Control;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;

public class Sub_QuYuSearch : SubUI 
{

    public void Show()
    {
        mUIGameObject.SetActive(true);
        addIndex = 0;
        for (ushort i = 0; i < 8; i++)
        {
            l_LeftTittleNames[i].text = Ctrl_ContantInfo.Instance.LeftItemNames[i];
            for (ushort j = 0; j < 5; j++)
            {
                l_BottomNames[i][j].text = Ctrl_ContantInfo.Instance.BottomName[i][j];
                int count = Ctrl_XuLieTu.Instance.GetEachCount(i, j);
                string numStr = "";
                if (count > 40)
                {
                    numStr = (count + " 张").AddRed();
                }
                else if (count > 30)
                {
                    numStr = (count + " 张").AddOrange();
                }
                else if (count > 20)
                {
                    numStr = (count + " 张").AddYellow();
                }
                else if (count > 10)
                {
                    numStr = (count + " 张").AddBlue();
                }
                else if (count > 0)
                {
                    numStr = (count + " 张").AddGreen();
                }

                l_Counts[i][j].text = numStr;
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

        
        for (ushort i = 0; i < 8; i++)
        {
            l_LeftTittleNames[i] = Get<Text>("TopGrid/Tittle/LeftName" + i+"/LeftName");
            Text[] l_EachBottoms = new Text[5];
            Text[] l_EachCounts= new Text[5];
            for (ushort j = 0; j < 5; j++)
            {
                l_EachBottoms[j] = Get<Text>("TopGrid/Contant/LeftItem"+i+"/BottomItem"+j+"/TxName");
                l_EachCounts[j] = Get<Text>("TopGrid/Contant/LeftItem"+i+"/BottomItem"+j+ "/TxNum");

                ushort bigIndex = i;
                ushort bottomIndex = j;
                AddButtOnClick("TopGrid/Contant/LeftItem" + i + "/BottomItem" + j, () =>
                {
                    MyEventCenter.SendEvent(E_GameEvent.ChangeLeftItem, bigIndex, bottomIndex);
                });
            }
            l_BottomNames[i] = l_EachBottoms;
            l_Counts[i] = l_EachCounts;
        }



        AddButtOnClick("Bottom/BtnDeleteAllClick", Btn_DeleteAll);
    }




    #region 私有


    private readonly Text[] l_LeftTittleNames = new Text[8];
    private readonly Text[][] l_BottomNames = new Text[8][];
    private readonly Text[][] l_Counts = new Text[8][];



    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/QuYuSearch";
    }


    public override void OnEnable()
    {

    }


    public override void OnDisable()
    {
    }



    #endregion


    //————————————————————————————————————

    private ushort addIndex = 0;

    private void Btn_DeleteAll()            // 点击 准备清除所有(要点击5次)
    {
        if (addIndex>=5)
        {
            MyEventCenter.SendEvent(E_GameEvent.ShowBeforeClick, EBeforeShow.DeleteAllSure);
            addIndex = 0;
        }
        else
        {
            addIndex++;
        }
    }




    //—————————————————— 事件 ——————————————————

    private void E_SureDeleteAll()            // 确定 删除所有
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                l_Counts[i][j].text = "";
            }
        }
    }



}
