using System;
using System.Collections;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Base_JumpSceneAnim : MonoBehaviour
{

    public bool IsOut { get; set; }                                 // 是否退出场景，false 就是进入新场景啦


    public virtual void OnReady2Do() { }                           // 准备跳场景前做什么 

    public abstract bool OnProcessAnim(float elapsedTime);          // 处理动画啊



    protected virtual void OnLastRenderer2Do() { }                  // 打算在最后一帧渲染就调用这个方法


    private bool isRender;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        isRender = true;
    }

    void OnDestroy()
    {
        isRender = false;
        OnDestroy2Do();
    }




    protected virtual void OnDestroy2Do(){ }





    public IEnumerator DoLastRenderer()
    {
        while (isRender)
        {
            yield return new WaitForEndOfFrame();
            if (isRender)
            {
                OnLastRenderer2Do();
            }
        }
    }




}