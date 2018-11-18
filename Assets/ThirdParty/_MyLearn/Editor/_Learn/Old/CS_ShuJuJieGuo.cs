using System;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;

namespace UnityEditor
{
    public class CS_ShuJuJieGuo : AbstractKuang<CS_ShuJuJieGuo>                // 数据结构 API 旧版
    {
        protected override void OnEditorGUI()
        {

            DrawArray();

            DrawArrayList();
            QuBie2();
            DrawList();
            DrawHashSet();
            QuBie();
            DrawDictionary();
            DrawHashtable();
            m_Tools.BiaoTi_B("特殊的数据结构".AddGreen(),ref isTie, DrawSortedList);

            m_Tools.ButtonText("Stack<T>", "允许重复，只能对顶部作操作", ref isStack, () =>
            {

                m_Tools.Text_G("1.没有索引操作，没有任何索引器，只能对前后进行操作");
                m_Tools.Text_G("2.继承 IEnumerable<T>, ICollection, IEnumerable");
                m_Tools.Text_G("3.先前后出!");

                MyCreate.Text("添加");
                m_Tools.Method_YG("Push", "", "在"+"顶部".AddGreen()+"放一个元素","",-50);
                MyCreate.Text("删除");
                m_Tools.Method_YG("Pop", "", "删除" + "顶部".AddGreen()+"元素,返回删除的元素","T",-50);
                MyCreate.Text("查");
                m_Tools.Method_YG("Peek", "", "查询" + "顶部".AddGreen() + "的元素", "T", -50);
                m_Tools.Text_Y("foreach、Contains");
            }, -60);


            m_Tools.BiaoTi_B("我创建的数据结构".AddGreen(),ref isMy, () =>
            {
                m_Tools.ButtonText("MyHuoCheTou<R, T>","key不可重复，多个 Value",ref isMyHuoCheTou, () =>
                {
                    m_Tools.Text_G("图解",ref isTU, () =>
                    {
//                        ShowImage(LearnPath.MyHuoCheTouTu);
                    });

                });
                AddSpace();
            });

        }


        private void DrawArray()                                 //[ ] 数组
        {
            m_Tools.ButtonText("[ ] 数组", "固定".AddLightBlue() + "长度", ref isArray, () =>
            {
                m_Tools.Text_G("因为固定长度 所以实例要声明容量");
                m_Tools.Text("1. 使用" + " new".AddGreen() + " 声明容量 " + "int[] a=new int[4]".AddGreen());
                m_Tools.Text("2. 用" + "｛ ｝".AddGreen() + "直接定义数据 " + "int[] a=｛1，2，3｝".AddGreen());
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.array(v=vs.110).aspx");
                AddSpace();
                MyCreate.StaticMethodWindow(() =>
                {
                    m_Tools.Method_BY("Array.IndexOf", "Array 数组，Object", "搜索指定对象,返回首个索引", "int");
                    m_Tools.Method_BY("Array.IndexOf", "Array 数组，Object，int 搜索的起始索引", "", "int");
                });

            }, -60);
            AddSpace_3();
        }

        private void DrawArrayList()                             //ArrayList
        {
            m_Tools.ButtonText("ArrayList", "可重复" , ref isArrayList, () =>
            {
                m_Tools.Text_G("存储 object 实现任意类型的，所以使用时要转换");
            }, -60);
            AddSpace_3();
        }


        private void QuBie2()                                    //List<T> 与 HashSet<T> 区别
        {

        }


        private void DrawList()                                  //List<T> 
        {
            m_Tools.ButtonText("List<T>", "可重复", ref isList, () =>
             {
                 m_Tools.BiaoTi_O("构造函数 " + "(无参、另一IEnumerable<T>、声明开始容量)".AddYellow(), ref isConstructors, () =>
                  {
                      MyCreate.Box(() =>
                      {
                          m_Tools.Text_Y("1. 无参构造 " + "(容量按 0 4 8 16 32 ...递增)".AddGreen());
                          m_Tools.Text_Y("2. List<T> (IEnumerable<T>) " + " 加上一整组元素".AddGreen());
                          m_Tools.Text_Y("3. List<T> ( int " + "开始容量".AddGreen() + ")" + "   (超过开始容量 用最近的4倍数)".AddGreen());
                          MyCreate.Box(() =>
                          {
                              m_Tools.Text("1.添加的元素大于容量时会重新申请分配内存" + "（新建数组+复制）".AddLightBlue());
                              m_Tools.Text("2.list需要添加特别多的元素时会不断地消耗内存");
                              MyCreate.Text("所以".AddGreen());
                              m_Tools.Text_G("3.如果知道最大的Item元素，直接使用第三个构造函数");
                              m_Tools.Text("4.当 list中 remove 大量元素，内存占一部分不需要使用的空间");
                              m_Tools.Text("  可以使用" + " TrimExcess ".AddGreen() + "方法来释放多余的内存");
                          });
                      });
                  });
                 m_Tools.BiaoTi_O("方法", true);
                 MyCreate.Box(() =>
                 {
                     MyCreate.Text("添加");
                     m_Tools.Method_YG("Add", "T item", "在末尾处添加元素", "", ref isAdd, () =>
                     {
                         m_Tools.Method_YG("AddRange", "IEnumerable<T>", "在末尾处添加一整组元素");
                     });
                     m_Tools.Method_YG("Insert", "int index, T item", "在index位置插入一个元素", "", ref isInsert, () =>
                     {
                         m_Tools.Method_YG("Insert", "int , IEnumerable<T>", "在index位置插入一整组元素");
                     });

                     MyCreate.Text("删除");
                     m_Tools.Method_YG("Clear", "", "删除所有元素");
                     m_Tools.Method_YG("Remove", "T item", "删除一个元素");
                     m_Tools.Method_YG("RemoveAt", "int index", "删除下标为index的元素");
                     m_Tools.Method_YG("RemoveRange", "int 索引,int 长度", "删除一整组元素");
                     m_Tools.Method_YG("RemoveAll ", "Func<T,bool>", "删除所有相匹配的元素");

                     MyCreate.Text("查");
                     m_Tools.Method_YG("Contains", "T item", "是否"+"包含".AddYellow()+"这个元素", "bool");
                     m_Tools.Method_YG("TrueForAll", "Func<T,bool>", "是否所有元素都符合这个条件", "bool");
                     m_Tools.Method_YG("BinarySearch", "T item", "二分法查找这个元素的" + "索引".AddYellow(), "int", ref isBinarySearch, () =>
                        {
                            m_Tools.Method_YG("BinarySearch", "T ,IComparer<T>", "指定比较器查找索引", "int");
                            m_Tools.Method_YG("BinarySearch", "int 索引,int 长度,T ,IComparer<T>", "", "int");
                        });
                     m_Tools.Method_YG("FindIndex", "Func<T,bool>", "返回条件相匹配的" + "第一个索引".AddYellow(), "int");
                     m_Tools.Method_YG("FindLastIndex ", "Func<T,bool>", "返回条件相匹配的" + "最后一个索引".AddYellow(), "int");
                     m_Tools.Method_YG("Find", "Func<T,bool>", "返回条件相匹配的" + "第一个元素".AddYellow(), "T", ref isFind, () =>
                        {
                            m_Tools.Method_YG("FindAll", "Func<T,bool>", "与 Where 类似", "T");
                        });


                     m_Tools.Method_YG("Where<T>", "Func<T, bool>", "相匹配" + "所有元素".AddYellow(), "IEnumerable<T>", ref isWhere, () =>
                             {
                                 m_Tools.Method_YG("Where<T>", "Func<T,int, bool>", "", "IEnumerable<T>");
                                 m_Tools.Text_G("第二个参数为源元素的索引，第三个参数为返回值");
                             });

                     MyCreate.Text("排序、反转");
                     m_Tools.Method_YG("Sort ", "", "使用默认比较器按从小到大排序", "", ref isSort, () =>
                     {
                         MyCreate.Box(() =>
                         {
                             m_Tools.Text_G("按字符串长度来排序");
                             m_Tools.Text_H("list.Sort((str1, str2) =>");
                             m_Tools.Text_H(" {");
                             m_Tools.Text_H("       return str1.Length - str2.Length;");
                             m_Tools.Text_H("  });");
                         });


                         m_Tools.Method_YG("Sort ", "Comparer<T>", "使用指定比较器排序");
                         m_Tools.Method_YG("Sort ", "IComparer<T>", "同上");
                         m_Tools.Method_YG("Sort ", "int 索引,int 长度,IComparer<T>", "使用指定比较器区域排序");
                     });
                     m_Tools.Method_YG("Reverse  ", "", "将集合反转");

                     MyCreate.Text("获取");
                     m_Tools.Method_YG("Take", "int n", " 获得前 n 行", "IEnumetable<T>");
                     m_Tools.Method_YG("AsReadOnly", "", "获得只读集合", "ReadOnlyCollection<T>",-40);
                 });
            

             }, -60);
            AddSpace_3();
        }


        private void DrawHashSet()                               //HashSet<T>
        {
            m_Tools.ButtonText("HashSet<T>", "不可重复，添加重复不报错,没有索引器", ref isHashSet, () =>
            {
                MyCreate.TextCenter("只是用来存储数据！没有单一取数据的！".AddYellow());
                MyCreate.TextCenter("用来存储集合、集运算、大数据查询使用 HashSet");
                
                MyCreate.Text("增");
                m_Tools.Method_YG("Add", "T", "重复返回 false","bool");
                MyCreate.Text("两集合运算");
                m_Tools.Method_YG("IntersectWith", "IEnumerable<T>", "交集","void",20);
                m_Tools.Method_YG("UnionWith", "IEnumerable<T>", "并集", "void", 20);
                m_Tools.Method_YG("ExceptWith ", "IEnumerable<T>", "排除", "void", 20);


            }, -60);
            AddSpace_3();

        }

        private void QuBie()                                     //Dictionary 与 Hashtable 区别
        {
        }


        private void DrawDictionary()                            //Dictionary
        {
            m_Tools.ButtonText("Dictionary<k,v>", "Key不可重复，添加重复报错，取[不存在]报错", ref isDictionary, () =>
            {
                m_Tools.BiaoTi_O("foreach 的使用", ref isForeach2, () =>
                {
                    MyCreate.Window("用 KeyValuePair<int, string> 对象 声明", () =>
                    {
                        m_Tools.Text_Y("foreach (KeyValuePair<int, string> kvp in dic)");
                    });
                    AddSpace();
                    AddSpace();
                    MyCreate.Window("用 key/value 对象 声明", () =>
                    {
                        m_Tools.Text_Y("foreach ( T key in dic.Keys )");
                    });
                });

                m_Tools.BiaoTi_O("方法", true);
                MyCreate.Box(() =>
                {
                    MyCreate.Text("查");
                    m_Tools.Method_YG("ContainsKey", "K key", "key 是否包含");
                    m_Tools.Method_YG("ContainsValue", "V Value", "Value 是否包含");
                    MyCreate.Text("获取");
                    m_Tools.Method_YG("this", "K", "通过key获取value，没有报错", "V");
                    m_Tools.Method_YG("TryGetValue", "K,out V", "通过key获取value，没有不报错","bool");

                    m_Tools.Text_G("继承 IEnumerable<T>，都有它的扩展方法");

                });
            }, -60);

            AddSpace_3();
        }


        private void DrawHashtable()                             //Hashtable
        {
            m_Tools.ButtonText("Hashtable", "Key不可重复，添加重复报错，取[不存在]null", ref isHashtable, () =>
            {
                MyCreate.TextCenter("foreach 出来的结果不是按照顺序排列的");
                m_Tools.Text_G("1.Key 与 Dictionary 相同不可重复，区分大小写");
                m_Tools.Text_G("2.元素存储在DictionaryEntry对象中");
                m_Tools.BiaoTi_O("foreach 的使用", ref isForeach, () =>
                {
                    MyCreate.Window("用 DictionaryEntry 对象 声明", () =>
                    {
                        m_Tools.Text_Y("foreach ( DictionaryEntry de in hashtable )");
                    });
                    AddSpace();
                    AddSpace();
                    MyCreate.Window("用 key/value 对象 声明", () =>
                    {
                        m_Tools.Text_Y("foreach ( Object key in hashtable.Keys )");
                    });
                });

                m_Tools.BiaoTi_O("方法", true);
                MyCreate.Box(() =>
                {
                    m_Tools.Method_YG("Add","Object,Object","添加");
                    m_Tools.Method_YG("Remove", "Object key","根据 key 来删除");
                    m_Tools.Method_YG("ContainsKey", "Object key","key 是否包含");
                    m_Tools.Method_YG("ContainsValue", "Object Value", "Value 是否包含");

                });
            }, -60);
        }



        private void DrawSortedList()                            //SortedList<k,v> 、 Stack、Queue
        {

            m_Tools.ButtonText("SortedList<k,v>", "根据 key 来排序、类似 Dictionary", ref isDrawSortedList, () =>
            {
                MyCreate.TextCenter("foreach 出来的结果不是按照顺序排列的");
                m_Tools.BiaoTi_O("方法", true);
                MyCreate.Box(() =>
                {
                    m_Tools.Method_YG("Add", "Object,Object", "添加");

                });
            }, -60);

            m_Tools.ButtonText("Stack、Queue", "堆栈 （先前后出）、队列（先前先出）", ref isStackQueue, () =>
            {
            }, -60);
        }


        #region 私有

        private bool isList, isDictionary, isHashtable, isConstructors, isInsert, isArray,isMy, isHashSet;
        private bool isArrayList, isAdd, isSort, isBinarySearch, isWhere, isFind, isDrawSortedList;
        private bool isForeach, isForeach2,isTie, isStackQueue, isStack, isMyHuoCheTou,isTU;


//        [MenuItem(LearnMenu.CSJiChu + "数据结构 API")]
        public static void ShowWindow()
        {
            CreateWindow("数据结构", 480, 500);
        }

        protected override string Tittle()
        {
            return "数据结构 API";
        }


        protected override int OnChangeJianGe()
        {
            return 210;
        }

        #endregion



    }



}


