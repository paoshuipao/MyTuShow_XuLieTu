using UnityEngine;

public class Sub_Setting : SubUI 
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
        return "Right/EachContant/Setting";
    }



    public override void OnEnable()
    {
    }

    public override void OnDisable()
    {
    }



    #endregion

}
