using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor
{
    public class Tools_UGUI : AbstractChooseKuang<Tools_UGUI>
    {
        protected override void OnEditorGUI()
        {
            switch (m_FenLie)
            {
                case UGongJuType.其他:
                    DrawKey();
                    break;
                case UGongJuType.调整UI:
                    DrawTiaoZhen();
                    break;
                case UGongJuType.电脑加载图片:
                    DrawTieXu();
                    break;
                case UGongJuType.图片变成精灵:
                    DrawChangeSprite();
                    break;
            }
            MyCreate.AddSpace();

        }



        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (pathK_ImageV.Count > 0)
            {
                foreach (Image image in pathK_ImageV.Values)
                {
                    bool isTi = EditorUtility.DisplayDialog("没有保存的电脑图片", string.Format("Image {0} 中有没有保存的电脑图片 {1}", image, image.sprite), "保存", "不要了");
                    if (isTi)
                    {
                        SaveTu();
                    }
                    else
                    {
                        image.sprite = null;
                    }
                }
            }
            pathK_ImageV.Clear();

        }


        #region 私有

        private readonly string[] tuFilters = { "Image files", "png,jpg,jpeg", "All files", "*" };
        private static readonly Vector2 HalfVec = new Vector2(0.5f, 0.5f);
        private readonly Dictionary<string, Image> pathK_ImageV = new Dictionary<string, Image>();

        public enum UGongJuType
        {
            其他,
            调整UI,
            电脑加载图片,
            图片变成精灵,
        }


        [GUIColor(0.1f, 0.8f, 0.8f)]
        [HideLabel]
        [EnumToggleButtons(true, 80)]
        public UGongJuType m_FenLie = UGongJuType.调整UI;



        [MenuItem(LearnMenu.GONGJU_UGUI)]
        public static void ShowWindow()
        {
            CreateWindow("实用工具", 420, 420);
        }


        #endregion




        private void DrawKey()                                  // 快捷键
        {
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Ctrl + W", "复制 UGUI 名到剪切版", -50);
                m_Tools.Text_G("使用它，再也不用烦找名字的痛苦了");

            });
            AddSpace();


            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("先点击选择多个图片，给它们添加前缀");
                Texture2D[] texs = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);
                bool isCanClick = (null == texs || texs.Length <= 0);
                GUI.enabled = !isCanClick;
                MyCreate.Button("    一键添加前缀", () =>
                {
                    foreach (Texture2D texture2 in texs)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(texture2);
                        string fullPath = MyAssetUtil.GetFullPath(assetPath);
                        string fileName = MyAssetUtil.GetFileNameByFullName(fullPath);
                        MyIO.FileRename(fullPath, "EX_" + fileName);
                    }

                    AssetDatabase.Refresh();
                });


                GUI.enabled = true;

            });

        }

        private void DrawTiaoZhen()                              // 调整UI
        {

            Transform[] curSelect = Selection.GetTransforms(SelectionMode.TopLevel);
            int length = curSelect.Length;

            #region 选择一个 GameObject 控制其上下位置

            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + " 选择一个 GameObject 控制其上下位置".AddGreen());
                m_Tools.Text_H("  点击 1 个");
                GUI.enabled = length == 1;
                FourButton("  上一格 ↑", "  下一格 ↓", "  最里层 ↑↑↑", "  最外层 ↓↓↓", () =>
                {
                    //上一格
                    int curIndex = curSelect[0].GetSiblingIndex();
                    if (curIndex > 0)
                        curSelect[0].SetSiblingIndex(curIndex - 1);

                }, () =>
                {
                    // 下一格
                    int curIndex = curSelect[0].GetSiblingIndex();
                    int child_num = curSelect[0].parent.childCount;
                    if (curIndex < child_num - 1)
                        curSelect[0].SetSiblingIndex(curIndex + 1);
                }, () =>
                {
                    //最里层
                    curSelect[0].SetAsFirstSibling();
                }, () =>
                {
                    //最外层
                    curSelect[0].SetAsLastSibling();
                });
                GUI.enabled = true;

            });

            #endregion

            #region 水平/垂直 均匀排布

            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + " 水平/垂直 均匀排布".AddGreen());
                m_Tools.Text_H("  需要点击 3 个或以上");
                GUI.enabled = length > 2;
                ThreeButton("    水平均匀  |||", "    垂直均匀  ☰", "    水平 + 垂直", () =>
                {
                    // 水平均匀 |||
                    ShuiPin(length);
                }, () =>
                {
                    // 垂直均匀  ☰
                    ShuZhi(length);

                }, () =>
                {
                    // 水平 + 垂直
                    ShuiPin(length);
                    ShuZhi(length);
                });
                GUI.enabled = true;
            });

            #endregion

            #region 设置一样大小

            MyCreate.Box(() =>
            {
                GUI.enabled = length > 1;
                MyCreate.Text("功能：".AddYellow() + " 设置一样大小".AddGreen());
                m_Tools.Text_H("  需要点击 2 个或以上，一样大按最大的来算");
                GUI.enabled = length > 1;
                m_Tools.TwoButton("一样大 ■", "一样小 ▪", () =>
                {
                    float height = Mathf.Max(Selection.gameObjects.Select(obj => ((RectTransform)obj.transform).sizeDelta.y).ToArray());
                    float width = Mathf.Max(Selection.gameObjects.Select(obj => ((RectTransform)obj.transform).sizeDelta.x).ToArray());
                    foreach (GameObject gameObject in Selection.gameObjects)
                    {
                        ((RectTransform)gameObject.transform).sizeDelta = new Vector2(width, height);
                    }
                }, () =>
                {
                    float height = Mathf.Min(Selection.gameObjects.Select(obj => ((RectTransform)obj.transform).sizeDelta.y).ToArray());
                    float width = Mathf.Min(Selection.gameObjects.Select(obj => ((RectTransform)obj.transform).sizeDelta.x).ToArray());
                    foreach (GameObject gameObject in Selection.gameObjects)
                    {
                        ((RectTransform)gameObject.transform).sizeDelta = new Vector2(width, height);
                    }
                });
                GUI.enabled = true;
            });


            #endregion

            #region 设置一样字体大小

            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + " 设置一样字体大小".AddGreen());
                m_Tools.Text_H("  需要点击 2 个或以上的 Text");

                Text[] texts = Selection.GetFiltered<Text>(SelectionMode.TopLevel);
                GUI.enabled = texts.Length > 1;
                m_Tools.TwoButton("一样大字号", "一样小字号", () =>
                {
                    int maxSiz = 0;
                    foreach (Text text in texts)
                    {
                        if (text.fontSize < maxSiz)
                        {
                            text.fontSize = maxSiz;
                        }
                        else
                        {
                            maxSiz = text.fontSize;
                        }
                    }
                }, () =>
                {
                    int minSiz = 100;
                    foreach (Text text in texts)
                    {
                        if (text.fontSize > minSiz)
                        {
                            text.fontSize = minSiz;
                        }
                        else
                        {
                            minSiz = text.fontSize;
                        }
                    }
                });
                GUI.enabled = true;
            });
            #endregion

        }


        private void DrawTieXu()                                 // 电脑加载图片
        {
            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + " 直接加载个 电脑上的 图片".AddGreen());
                m_Tools.Text_H("1. 可以先点击中一个 Image");
                m_Tools.Text_H("2. 也可以不点，会直接生成一个 Image");

                MyCreate.Button("加载电脑图片".PadLeft(36), () =>
                {
                    Image iamge = null;
                    Transform click = Selection.activeTransform;
                    if (null != click)
                    {
                        iamge = click.GetComponent<Image>();
                    }
                    if (null != iamge)
                    {
                        if (null != iamge.sprite)
                        {
                            bool isTi = EditorUtility.DisplayDialog("是否替换", string.Format("选择的 Image 中带有图片 {0}，是否替换？", iamge.sprite.name), "确定", "取消");
                            if (isTi)
                            {
                                LoadWaiTu(iamge);
                            }
                        }
                        else
                        {
                            LoadWaiTu(iamge);
                        }
                    }
                    else
                    {
                        LoadWaiTu(CreateImage("从电脑加载的图片"));
                    }

                });
            });


            if (pathK_ImageV.Count > 0)
            {
                AddSpace();
                MyCreate.Box(() =>
                {
                    MyCreate.Text("功能：".AddYellow() + " 保存上面加载了的电脑图片到 Assets 中".AddGreen());
                    m_Tools.Text_H("1. 保存到 GameAssets/Sprite 文件夹上");
                    m_Tools.Text_H("2. 一键全部保存");
                    MyCreate.Button("保存".PadLeft(36), () =>
                    {
                        SaveTu();
                    });

                });
            }


        }



        private void DrawChangeSprite()                          // 图片变成精灵
        {
            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + "  将所有图片转化成 Sprite 格式".AddGreen());
                m_Tools.Text_H("1. 先选择 Texture 图片（可多选）");
                m_Tools.Text_H("2. 一键全部转换");
                Texture2D[] texts = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);
                GUI.enabled = texts.Length > 0;
                MyCreate.Button("转成 Sprite".PadLeft(38), () =>
                {
                    foreach (Texture2D texture2D in texts)
                    {
                        string path = AssetDatabase.GetAssetPath(texture2D);
                        Texture2DChangeSprite(path);
                    }
                });
                GUI.enabled = true;
            });


            AddSpace_15();
            MyCreate.Box(() =>
            {
                MyCreate.Text("功能：".AddYellow() + "  将所有图片转化成回 Default 格式".AddGreen());
                m_Tools.Text_H("同上");
                Texture2D[] texts = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);

                GUI.enabled = texts.Length > 0;
                MyCreate.Button("转成 Default".PadLeft(38), () =>
                {
                    foreach (Texture2D texture2D in texts)
                    {
                        string path = AssetDatabase.GetAssetPath(texture2D);
                        DChangeTexture(path);
                    }
                });
                GUI.enabled = true;

            });

        }




        //——————————————————特殊功能——————————————————


        private void LoadWaiTu(Image image)                      // 加载外部图片
        {
            string spr_path = EditorUtility.OpenFilePanelWithFilters("加载外部图片", @"E:\000资源\静态图\散图", tuFilters);
            if (!string.IsNullOrEmpty(spr_path))
            {
                Texture2D texture = LoadTextureInLocal(spr_path);
                //创建Sprite
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), HalfVec);
                image.sprite = sprite;
                image.SetNativeSize();
                pathK_ImageV.Add(spr_path, image);
            }

        }

        private void SaveTu()                                    // 保存图片
        {
            foreach (string path in pathK_ImageV.Keys)
            {
                string resPath = Application.dataPath + "/GameAssets/Sprite/" + MyAssetUtil.GetFileNameByFullName(path);
                // 将图片复制 "/GameAssets/Sprite/" 文件夹下
                MyIO.FileCopy(path, resPath);
                string assetPath = MyAssetUtil.GetAssetsBackPath(resPath);
                AssetDatabase.Refresh();
                // 转化成 Sprite
                Texture2DChangeSprite(assetPath);
                ; Sprite sp = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                pathK_ImageV[path].sprite = sp;
            }
            pathK_ImageV.Clear();
        }



        private void Texture2DChangeSprite(string texturePath)   // 转成 Sprite
        {
            TextureImporter improter = AssetImporter.GetAtPath(texturePath) as TextureImporter;
            if (null == improter)
            {
                MyLog.Red("为空？—— " + texturePath);
                return;
            }
            improter.textureType = TextureImporterType.Sprite;
            improter.spritePixelsPerUnit = 100;
            improter.mipmapEnabled = false;
            improter.textureCompression = TextureImporterCompression.Compressed;
            improter.crunchedCompression = true;
            improter.compressionQuality = 50;
            AssetDatabase.ImportAsset(texturePath);
            AssetDatabase.Refresh();
        }

        private void DChangeTexture(string texturePath)          // 转成回 Texture
        {
            TextureImporter texture = AssetImporter.GetAtPath(texturePath) as TextureImporter;
            if (null == texture)
            {
                MyLog.Red("为空？—— " + texturePath);
                return;
            }
            texture.textureType = TextureImporterType.Default;
            texture.mipmapEnabled = false;
            texture.crunchedCompression = true;
            texture.compressionQuality = 80;
            AssetDatabase.ImportAsset(texturePath);
            AssetDatabase.Refresh();
        }



        private void ShuiPin(int count)                         //  水平均匀  |||
        {
            float firstX = Mathf.Min(Selection.gameObjects.Select(obj => obj.transform.localPosition.x).ToArray());
            float lastX = Mathf.Max(Selection.gameObjects.Select(obj => obj.transform.localPosition.x).ToArray());
            float distance = (lastX - firstX) / (count - 1);
            var objects = Selection.gameObjects.ToList();
            objects.Sort((x, y) => (int)(x.transform.localPosition.x - y.transform.localPosition.x));
            for (int i = 0; i < count; i++)
            {
                objects[i].transform.localPosition = new Vector3(firstX + i * distance, objects[i].transform.localPosition.y);
            }
        }

        private void ShuZhi(int count)                          // 垂直均匀  ☰
        {
            float firstY = Mathf.Min(Selection.gameObjects.Select(obj => obj.transform.localPosition.y).ToArray());
            float lastY = Mathf.Max(Selection.gameObjects.Select(obj => obj.transform.localPosition.y).ToArray());
            float distance = (lastY - firstY) / (count - 1);
            var objects = Selection.gameObjects.ToList();
            objects.Sort((x, y) => (int)(x.transform.localPosition.y - y.transform.localPosition.y));
            for (int i = 0; i < count; i++)
            {
                objects[i].transform.localPosition = new Vector3(objects[i].transform.localPosition.x, firstY + i * distance);
            }
        }



    }
}


