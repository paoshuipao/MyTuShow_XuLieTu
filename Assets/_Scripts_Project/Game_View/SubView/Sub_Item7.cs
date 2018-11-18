using UnityEngine;

public class Sub_Item7 : SubUI            // 包含全部的内容
{

    public void Show()
    {
        mUIGameObject.SetActive(true);

    }


    public void Close()
    {
        mUIGameObject.SetActive(false);
    }




    protected override void OnStart(Transform root)
    {




    }


    #region 私有


    public override string GetUIPathForRoot()
    {
        return "Right/EachContant/Item7";
    }


    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }

    #endregion









}
