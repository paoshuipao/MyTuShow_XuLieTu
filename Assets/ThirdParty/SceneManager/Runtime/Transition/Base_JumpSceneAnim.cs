using System;
using System.Collections;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Base_JumpSceneAnim : MonoBehaviour
{

    public bool IsOut { get; set; }                                 // �Ƿ��˳�������false ���ǽ����³�����


    public virtual void OnReady2Do() { }                           // ׼��������ǰ��ʲô 

    public abstract bool OnProcessAnim(float elapsedTime);          // ��������



    protected virtual void OnLastRenderer2Do() { }                  // ���������һ֡��Ⱦ�͵����������


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