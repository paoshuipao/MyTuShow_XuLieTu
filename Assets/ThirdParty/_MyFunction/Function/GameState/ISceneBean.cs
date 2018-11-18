using PSPUtil;

public abstract class ISceneBean
{


    public abstract EF_JumpSceneAnim[] GetJumpAnim();           // 可一个或者多个 甚至没有也行



    public void Loading(float progress)                   // 进入中
    {
        OnLoading(progress);
    }



    public void Enter()                                  // 成功进入 -> 结束动画  ->Start
    {
        MyEventCenter.SendEvent(GetSceneMainUI());               // 发送进入这个状态的事件
        OnEnter();
        OnAddListener();
    }


    public void Start()                                // 
    {
        OnStart();
    }




    public void Exit()                                 // 离开
    {
        OnRemoveListener();
        OnExit();
    }






    protected abstract E_GameEvent GetSceneMainUI();             // 这个场景 的主 UI

    protected virtual void OnLoading(float progress)            // 如果需要知道从上一个场景到这场景的过程，就重写
    {
         
    }


    protected abstract void OnEnter();                           // 进入状态要做什么

    protected abstract void OnExit();                            // 退出要做什么


    protected abstract void OnAddListener();                       //游戏事件注册

    protected abstract void OnRemoveListener();                    //游戏事件注消


    protected abstract void OnStart();                             // 动画结束，真正进入




    public virtual void OnUpdate()                               // 每帧要做什么
    {

    }

}
