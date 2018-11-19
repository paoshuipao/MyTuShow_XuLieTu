using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using PSPUtil.Control;
using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.UI;


public class ResultBean
{

    public Sprite SP;
    public float Width;
    public float Height;
    public FileInfo File;

    public ResultBean(Sprite sp,FileInfo fileInfo, float width, float height)
    {
        SP = sp;
        File = fileInfo;
        Width = width;
        Height = height;
    }


    public ResultBean()
    {
    }
}


public static class MyLoadTu
{


    private static void GetShouFan(ref int width,ref int height)          // 设置范围（每个不能超过340）
    {
        if (width == height && width >= 340)         // 等边且比较大
        {
            width = 335;
            height = 335;
        }
        else if (width > height && width >= 340)     // 宽大于高且比较大
        {

            height = height / (width / 335);
            width = 335;

        }
        else if (height > width && height >= 340)    // 高大于宽且比较大
        {

            width = width / (height / 335);
            height = 335;
        }
        else         // 不大于 340 的情况，全部缩小 1.1 倍吧
        {
            width = (int)(width / 1.1f);
            height = (int)(height / 1.1f);
        }

    }



    //—————————————————— 加载单个图片 ——————————————————

    public static void LoadSingleTu(FileInfo fileInfo,Action<ResultBean> callBack)
    {
        Ctrl_Coroutine.Instance.StartCoroutine(WaitForImage(fileInfo, callBack));
    }

    static IEnumerator WaitForImage(FileInfo fileInfo, Action<ResultBean> callBack)
    {
        System.Drawing.Image image = null;
        System.Drawing.Image image_Gai = null;
        // 开个线程
        new Thread(() =>
        {
            image = System.Drawing.Image.FromFile(fileInfo.FullName);
            int saveWidth = image.Width;
            int saveHeight = image.Height;
            GetShouFan(ref saveWidth,ref saveHeight);
            image_Gai = image.GetThumbnailImage(saveWidth, saveHeight, () => false, System.IntPtr.Zero);

        }).Start();
        while (null == image)
        {
            yield return 0;
        }
        while (null == image_Gai)
        {
            yield return 0;
        }
        using (MemoryStream ms = new MemoryStream())
        {
            image_Gai.Save(ms, ImageFormat.Png);
            yield return 0;
            Texture2D tex = new Texture2D(8, 8);
            tex.LoadImage(ms.ToArray());
            yield return 0;
            Sprite sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            sp.name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            if (null!= callBack)
            {
                ResultBean result = new ResultBean(sp, fileInfo, image.Width, image.Height);
                callBack(result);
            }
        }

    }



    //——————————————— 加载多个图片 2 —————————————————————




    public static void LoadMultipleTu(List<FileInfo> l_FileInfos, Action<ResultBean[]> callBack)
    {

        for (int i = 0; i < l_FileInfos.Count; i++)
        {
            if (!l_FileInfos[i].Exists)
            {
                MyLog.Red("不可能吧，之前已经判断过了 —— " + l_FileInfos[i].FullName);
                l_FileInfos.RemoveAt(i);
            }
        }

        Ctrl_Coroutine.Instance.StartCoroutine(WaitForImage(l_FileInfos, callBack));

    }


    static IEnumerator WaitForImage(List<FileInfo> fileInfos, Action<ResultBean[]> callBack)
    {
        System.Drawing.Image[] l_UseImages = new System.Drawing.Image[fileInfos.Count];     // 改的图
        ResultBean[] resList = new ResultBean[fileInfos.Count];

        // 开个线程
        new Thread(() =>
        {
       
            for (int i = 0; i < fileInfos.Count; i++)
            {

                System.Drawing.Image yuanImage = System.Drawing.Image.FromFile(fileInfos[i].FullName);

                int width = yuanImage.Width;
                int height = yuanImage.Height;
                GetShouFan(ref width, ref height);
                System.Drawing.Image useImage = yuanImage.GetThumbnailImage(width, height, () => false, System.IntPtr.Zero);
                ResultBean bean = new ResultBean();
                bean.Width = yuanImage.Width;
                bean.Height = yuanImage.Height;
                resList[i] = bean;
                l_UseImages[i] = useImage;
            }



        }).Start();


        for (int i = 0; i < fileInfos.Count; i++)
        {
            while (null == l_UseImages[i])
            {
                yield return 0;
            }
            using (MemoryStream ms = new MemoryStream())
            {

                l_UseImages[i].Save(ms, ImageFormat.Png);
                yield return 0;
                Texture2D tex = new Texture2D(8, 8);
                tex.LoadImage(ms.ToArray());
                yield return 0;
                Sprite sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                sp.name = Path.GetFileNameWithoutExtension(fileInfos[i].FullName);

                resList[i].SP = sp;
                resList[i].File = fileInfos[i];
            }

        }

        if (null!=callBack)
        {
            callBack(resList);
        }
    }



    //————————————————————————————————————

    public static void LoadSingleTu_Quick(FileInfo fileInfo, Action<ResultBean> callBack)    // 原图，大图可以考虑用这个（不卡，但大小不可控）
    {
        MyWebDownLoader.DownTexture("file://"+fileInfo.FullName, (tu) =>
        {

            Sprite sp = Sprite.Create(tu, new Rect(0, 0, tu.width, tu.height), new Vector2(0.5f, 0.5f));
            ResultBean bean = new ResultBean(sp,fileInfo, tu.width, tu.height);
            if (null!= callBack)
            {
                callBack(bean);
            }
        });
    }


}