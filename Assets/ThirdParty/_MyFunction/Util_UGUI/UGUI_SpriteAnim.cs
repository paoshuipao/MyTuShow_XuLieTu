using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using PSPUtil.Attribute;
using PSPUtil.StaticUtil;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using Sirenix.OdinInspector;
#endif

[AddComponentMenu("我的组件/UI/UGUI_SpriteAnim(帧动画)", 2)]
public class UGUI_SpriteAnim : MonoBehaviour
{

    public void play()                      // 将动画重置为第0帧并激活它
    {
        mTimer = 0;
        this.Active = true;
        this.m_Index = 0;
        if (this.Target != null && this.l_Sprites.Count > 0)
        {
            this.Target.overrideSprite = this.l_Sprites[this.m_Index];
        }
    }



    public void ChangeAnim(Sprite[] l_Sps)  // 改变动画
    {
        l_Sprites.Clear();
        l_Sprites.AddRange(l_Sps);
        play();

    }


    #region 私有
    public Image Target;                         // 目标 Image

    [MyHead("true -> 马上播放  false -> 马上停止")]
    public bool Active = true;
    [MyHead("多少秒一帧")]
    public float FPS = 0.1f;
    [MyHead("是否循环")]
    public bool IsLoop = true;
#if UNITY_EDITOR
    [HideIf("IsLoop")]
    [MyHead("   循环的次数")]
    [Indent]
#endif
    public ushort PlayCount =1;


#if UNITY_EDITOR
    [HideIf("IsLoop")]
    [MyHead("   结束的图片索引， 0 表示 最后")]
    [Indent]
    [MinValue(0)]
#endif
    public int EndIndex = 0;




    [MyHead("是否暂停也能播放")]
    public bool IsUseUnscaledDeltaTime = true;



    public List<Sprite> l_Sprites = new List<Sprite>();       // 图片集合

    private float mTimer = 0f;
    private int m_Index = 0;


    #endregion

    void Reset()
    {
        Target = GetComponent<Image>();
    }


    void Start()
    {
        if (EndIndex >= l_Sprites.Count)
        {
            EndIndex = -1;
        }
    }



    void Update()                   // 使用 Update 来播放 
    {
        if (!Active || null == Target || l_Sprites.Count <1 || FPS < 0)          // 没激活的、没 Image的、没集合的、FPS 少于0 统统走开
        {
            return;
        }
        if (mTimer >= FPS)        // 到下一段了
        {
            Target.overrideSprite = l_Sprites[m_Index];     // 先设置图片进去
            m_Index++;
            if (m_Index >= l_Sprites.Count)      // 轮完一圏了
            {
                m_Index = 0;
                if (!IsLoop && PlayCount > 0)            // 如果不是循环
                {
                    PlayCount--;
                }
            }
            if (PlayCount == 0)
            {
                if (EndIndex < 0 || (EndIndex >= 0 && EndIndex == m_Index))
                {
                    Active = false;
                }
            }
            mTimer = 0;

        }
        else
        {
            mTimer += IsUseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
        }


    }

#if UNITY_EDITOR

    [Button("一键添加图片集合", ButtonSizes.Large)]
    [GUIColor(0.3f,0.8f,0.8f,1f)]
    private void AddTu()
    {
        l_Sprites.Clear();
        // 一般的动画图片都是放在一起，而且还是前缀相同的
        Sprite sp = Target.sprite;
        if (null == Target || null == sp)
        {
            MyLog.Red("先添加一个图片在 Image 上啊");
            return;
        }
        // 图片名：abc_01，abc_02,abc_03
        int lastIndex = sp.name.LastIndexOf("_", StringComparison.Ordinal);
        // 找到 abc_
        string sameName = sp.name.Substring(0, lastIndex+1);

        // Assets/GameAssets/_Sprite/Holo Atlas.png
        string aasetpath = AssetDatabase.GetAssetPath(sp);

        // 这个是加载图集中的
        Object[] objs = AssetDatabase.LoadAllAssetsAtPath(aasetpath);
        foreach (Object o in objs)
        {
            if (o.name.Contains(sameName))
            {
                Sprite spo = o as Sprite;
                if (null != spo)
                {
                    l_Sprites.Add(spo);
                }
            }
        }
        if (l_Sprites.Count > 1)       
        {
            return;

        }
        l_Sprites.Clear();
        // 表示还没有找到，那就在它的文件夹下面找
        lastIndex = aasetpath.LastIndexOf("/", StringComparison.Ordinal);
        string directionPath = aasetpath.Substring(0, lastIndex);

        string[] files = Directory.GetFiles(directionPath);

        foreach (string fileFullPath in files)
        {
            string fileName = MyAssetUtil.GetFileNameByFullName(fileFullPath);
            if (fileName.Contains(sameName) && !fileName.Contains(".meta"))
            {
                string assetPath = MyAssetUtil.GetAssetsBackPath(fileFullPath);
                Sprite objSp = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                l_Sprites.Add(objSp);
            }
        }


        /*        // 找到这个图片的 Asset 路径   
          

                // 找到目录路径
              
          
                Object[] objs = AssetDatabase.LoadAllAssetsAtPath(directionPath+"/");

                foreach (Object o in objs)
                {
                    MyLog.Red(o.name);
                }*/



    }
#endif
}
