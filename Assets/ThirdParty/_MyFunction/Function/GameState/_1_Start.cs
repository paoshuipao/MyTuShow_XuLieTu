
using PSPUtil;
using UnityEngine;
using UnityEngine.UI;

public class _1_Start : ISceneBean
{

    protected override void OnEnter()                    // 进入了
    {



    }
    protected override void OnStart()
    {
        GameObject go = Resources.Load<GameObject>("MusicContrl");
        GameObject go_MusicContrl = Object.Instantiate(go);
        go_MusicContrl.SetActive(false);
    }



    protected override void OnAddListener()
    {

    }

    protected override void OnRemoveListener()
    {

    }




    #region 私有



    public override EF_JumpSceneAnim[] GetJumpAnim()      // 进入 Start 场景用什么动画
    {
        return new[]
        {
            EF_JumpSceneAnim.FadeAnim,
        };
    }


    protected override E_GameEvent GetSceneMainUI()       // 进入了这个场景用那一个主UI
    {
        return E_GameEvent.ShowStartGameUI;
    }





    protected override void OnExit()                     // 离开了
    {


    }


    #endregion







}

