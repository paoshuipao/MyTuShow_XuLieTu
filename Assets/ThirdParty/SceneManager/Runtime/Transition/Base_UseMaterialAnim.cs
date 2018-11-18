/*using System.Collections;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using UnityEngine;

public abstract class Base_UseMaterialAnim : Base_JumpSceneAnim                // 需要使用材质渲染的场景动画
{


    #region 私有

    private bool isRender;

    /// <summary>
    /// 在每个帧的末尾调用
    /// </summary>
    protected abstract void OnLastFrameRender();


    protected override void OnDestroy2Do()
    {
        base.OnDestroy2Do();
        isRender = false;
    }

    #endregion



    protected override void OnReady2Do()                         // 准备工作
    {
        base.OnReady2Do();

        if (!isRender)
        {
            StartCoroutine(DoInLastFrame());
        }
        isRender = true;

    }


    IEnumerator DoInLastFrame()                                  // 在最后一帧调用一下 OnLastFrameRender()
    {
        while (isRender)
        {
            yield return new WaitForEndOfFrame();
            OnLastFrameRender();
        }
    }






}*/