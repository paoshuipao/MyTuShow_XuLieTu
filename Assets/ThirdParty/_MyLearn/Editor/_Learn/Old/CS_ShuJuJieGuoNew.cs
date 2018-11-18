using System.Text;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using Sirenix.OdinInspector;

namespace UnityEditor
{
    public class CS_ShuJuJieGuoNew : AbstractChooseKuang<CS_ShuJuJieGuoNew>    // 数据结构
    {
        protected override void OnEditorGUI()
        {
            m_Tools.BiaoTi_B(_FenLie.ToString().TitleCase_ChinaFormat());

            switch (_FenLie)
            {
                case SJSGType.总结:
                    DrawZhongJie();
                    break;
                case SJSGType.相互区别:
                    DrawJieKou();
                    break;
                case SJSGType.数组:
                    DrawArray();
                    break;
                case SJSGType.ArrayList:
                    DrawArrayList();
                    break;
                case SJSGType.List_T:
                    DrawList();
                    break;
                case SJSGType.HashSet_T:
                    DrawHashSet();
                    break;
                case SJSGType.Dictionary_KV:
                    DrawDic();
                    break;
                case SJSGType.Hshtable:
                    DrawHashtable();
                    break;
                case SJSGType.Stack_T:
                    DrawStack();
                    break;
                case SJSGType.Queue:
                    DrawQueue();
                    break;
                case SJSGType.其他不常用:
                    DrawOtherNoUse();
                    break;
                case SJSGType.我创建的:
                    DrawMyCreate();
                    break;
            }
            MyCreate.AddSpace();

        }

        private void DrawZhongJie()                              // 总结
        {

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("1. 都实现了 "+"IEnumerable(fooreach)、ICollection（集合大小）".AddLightBlue());
                m_Tools.Text_H("2. 可以索引搜索取、插入操作："+"Array、List<T>、ArrayList".AddLightBlue());
                m_Tools.Text_H("3. 键/值对操作："+"Dictionary<K,V>、Hashtable".AddLightBlue());
                m_Tools.Text_H("4. 没有增(Add)删(Remove)，特殊增删取的集合："+"Stack、Queue".AddLightBlue());
                m_Tools.Text_H("5. 孤儿，只有 ICollection<T> 增删包含，没有单取：" + "HashSet<T>".AddLightBlue());

            });
            OneLine("IEnumerable","实现"+" foreach".AddWhite(),MyEnumColor.Orange, ArrayStr, ListStr, ArrayListStr, HashSetStr, DicStr, HashtableStr, StackStr, QueueStr);
            OneLine("IEnumerable<T>", "实现 T 类型的" + " foreach".AddWhite(), MyEnumColor.Orange, ListStr, HashSetStr);
            AddSpace_15();

            OneLine("ICollection", "表示集合" + "大小(Count)".AddWhite(), MyEnumColor.Yellow, ArrayStr, ListStr, ArrayListStr, DicStr, HashtableStr, StackStr, QueueStr);
            OneLine("ICollection<T>", "表示操作泛型集合 " + "大小、增(Add)删清除包含".AddWhite(), MyEnumColor.Yellow, ListStr, HashSetStr);
            OneLine("ICollection<KeyValuePair<TKey, TValue>>", "就是 ICollection<"+"T".AddYellow()+">", MyEnumColor.Yellow, DicStr);
            AddSpace_15();
            OneLine("IList", "表示可按照"+"索引".AddWhite()+"单独访问的对象的集合 "+"索引器、插入、索引搜索".AddWhite(), MyEnumColor.Orange, ArrayStr, ListStr, ArrayListStr);
            OneLine("IList<T>", "上面是 Object、这里是泛型索引集合", MyEnumColor.Orange, ListStr);
            AddSpace_15();
            OneLine("IDictionary", "表示"+"键/值对".AddWhite()+"集合,"+ "增删改清除包含  ICollection Keys".AddWhite(), MyEnumColor.Yellow, DicStr, HashtableStr);
            OneLine("IDictionary<K, V>", "上面的泛型，"+"增删改清除包含 K Keys  V Values".AddWhite(), MyEnumColor.Yellow, DicStr);
            AddSpace_15();
            OneLine("ICloneable", "Clone".AddWhite() + " 克隆的支持", MyEnumColor.Orange, ArrayStr, ArrayListStr, HashtableStr, StackStr, QueueStr);
            OneLine("ISerializable", "允许对象以控制其自己的序列化和反序列化", MyEnumColor.Orange, HashSetStr, DicStr, HashtableStr);
            OneLine("IDeserializationCallback", "指示已完成反序列化整个对象时 ", MyEnumColor.Orange, HashSetStr, DicStr, HashtableStr);
            AddSpace_15();
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text("1. 不带泛型的都是使用" + " object ".AddGreen() + ",即类型可以任意");
                m_Tools.Text("2. "+"ICollection".AddHui()+" 与"+" IEnumerable<T> ".AddHui()+"不适应上面的规则");
                m_Tools.Text_H("    ICollection 只表示集合大小，IEnumerable<T> 有大小还有增删改查");
                m_Tools.Text("3. 带 Hash 的表示使用 Hash 算法排序的，" + "不能用索引访问".AddGreen());

            });
        }


        private void DrawJieKou()                                // 相互区别
        {
            MyCreate.AddSpace(13);
            MyCreate.Window("IEnumerable"+"（遍历）".AddGreen()+"与 IEnumerator"+"（一层一层、协程）".AddGreen(), () =>
            {
                m_Tools.TextText_BL("IEnumerable","    接口" + "(I)".AddWhite() + "枚举" + "(Enumer)".AddWhite() + "可以遍历" + "(able)".AddWhite(), -50);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("1.要实现 foreach 就继承".AddYellow() + " IEnumerable".AddGreen());
                    MyCreate.Text("2.实际上主要是这个方法".AddYellow() + " public IEnumerator GetEnumerator() ".AddGreen());
                    MyCreate.Text("3.使用 ".AddYellow() + "yied return 想要返回的数据".AddGreen());
//                    m_Tools.TextButton_Open("4.使用 IEnumerable 的 "+"LINQ查询".AddGreen(), CS_CSharpZhongJie.ShowWindow);
                });
                m_Tools.TextText_BL("IEnumerator","    接口" + "(I)".AddWhite() + "枚举" + "(Enumer)".AddWhite() + "一只" + "(ator)".AddWhite(), -50);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("1. foreach 使用 yied return 一层一层地返回 IEnumerator => 动作".AddYellow());
                    MyCreate.Text("2. 协程类同 foreach ，也是 一层一层地返回 IEnumerator => 动作".AddYellow());
                });
            });
            MyCreate.AddSpace(20);
            MyCreate.Window("索引集合：Array、List<T>、ArrayList", () =>
            {
                m_Tools.Text_H("");
            });
            MyCreate.AddSpace(20);
            MyCreate.Window("键/值对：Dictionary<K,V>、Hashtable", () =>
            {
                m_Tools.Text_Y("▪ " + "Dictionary<T,T>".AddHui() , " 定死泛型的，而 ", "Hashtable".AddHui() ," 使用 " + "Object".AddGreen());
                AddSpace();
                m_Tools.Text_Y("▪ " + "dic".AddHui() , "[不存在] -> " , "报错".AddRed() , "，" + "hashtable".AddHui(), "[不存在] -> " + "null".AddGreen());
                AddSpace();
                m_Tools.Text_Y("▪ foreach 时 ", "Dictionary".AddHui() ," 是按照添加进入的元素进行排序");
                m_Tools.Text_Y("   而 " , "Hashtable ".AddHui(), "是按照 key 中 的 hashcode 来查找的");
                AddSpace();
                m_Tools.Text_Y("▪ ", "Dictionary".AddHui()," 继承IEnumerable<T>，拥有其扩展方法");
            });
            MyCreate.AddSpace(20);
            MyCreate.Window("特殊增删取的集合：Statck、Queue", () =>
            {
                m_Tools.TextText_BL("Stack  堆栈", "顶部 Push 进，顶部 Pop 删除", -80);
                m_Tools.TextText_BL("Queue 队列", "顶部 Enqueue 进，尾部 Dequeue 删除", -80);
                m_Tools.Text_W("同：可泛型，也可 Object，使用 Peek 返回顶部元素");
            });
            MyCreate.AddSpace(20);
            MyCreate.Window("List<T> 与 孤儿 HashSet<T> 对比", () =>
            {
                m_Tools.Text_Y("■ HashSet " + "检索性能".AddGreen() + "（" + "如 Contains".AddHui() + "）比 List " + "强".AddGreen());
                m_Tools.Text_Y("  List 数据量越大速度越巨慢，而 HashSet 不受数据量的影响");
                m_Tools.Text_Y("■ HashSet 没有索引器，在单独元素访问上，有很大的限制");
                m_Tools.Text_Y("■ HashSet 用来" + "存储集合".AddGreen() + "，非单独索引排列集合");
                m_Tools.Text_Y("■ 可做" + "高性能两个集合运算".AddGreen() + "，例如两个集合求交集、并集、差集");
            });
        }


        private void DrawArray()                                 // 数组
        {

        }

        private void DrawArrayList()                             // ArrayList
        {

        }

        private void DrawList()                                  // List
        {
//            m_Tools.GuangFangWenDan(LearnPath.ListUrl);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable, IEnumerable<T>");
                m_Tools.Text_H("       ICollection，ICollection<T>，IList，IList<T>");
            });


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
                    m_Tools.Method_YG(ZhongZai + "Insert", "int , IEnumerable<T>", "在index位置插入一整组元素");
                });

                MyCreate.Text("删除");
                m_Tools.Method_YG("Clear", "", "删除所有元素");
                m_Tools.Method_YG("Remove", "T item", "删除一个元素");
                m_Tools.Method_YG("RemoveAt", "int index", "删除下标为index的元素");
                m_Tools.Method_YG("RemoveRange", "int 索引,int 长度", "删除一整组元素");
                m_Tools.Method_YG("RemoveAll ", "Func<T,bool>", "删除所有相匹配的元素");

                MyCreate.Text("查");
                m_Tools.Method_YG("Contains", "T item", "是否" + "包含".AddYellow() + "这个元素", "bool");
                m_Tools.Method_YG("TrueForAll", "Func<T,bool>", "是否所有元素都符合这个条件", "bool");
                m_Tools.Method_YG("BinarySearch", "T item", "二分法查找这个元素的" + "索引".AddYellow(), "int", ref isBinarySearch, () =>
                {
                    m_Tools.Method_YG(ZhongZai + "BinarySearch", "T ,IComparer<T>", "指定比较器查找索引", "int");
                    m_Tools.Method_YG(ZhongZai + "BinarySearch", "int 索引,int 长度,T ,IComparer<T>", "", "int");
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


                    m_Tools.Method_YG(ZhongZai + "Sort ", "Comparer<T>", "使用指定比较器排序");
                    m_Tools.Method_YG(ZhongZai + "Sort ", "IComparer<T>", "同上");
                    m_Tools.Method_YG(ZhongZai + "Sort ", "int 索引,int 长度,IComparer<T>", "使用指定比较器区域排序");
                });
                m_Tools.Method_YG("Reverse  ", "", "将集合反转");

                MyCreate.Text("获取");
                m_Tools.Method_YG("Take", "int n", " 获得前 n 行", "IEnumetable<T>");
                m_Tools.Method_YG("AsReadOnly", "", "获得只读集合", "ReadOnlyCollection<T>", -40);
            });
        }

        private void DrawHashSet()                               // HashSet
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/bb359438(v=vs.110).aspx");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable, IEnumerable<T>,ICollection<T>");
                m_Tools.Text_H("        ISerializable，IDeserializationCallback");
            });


            MyCreate.TextCenter("用来存储集合、集运算、大数据查询使用 HashSet");

            MyCreate.Text("增");
            m_Tools.Method_YG("Add", "T", "重复返回 false", "bool");
            MyCreate.Text("两集合运算");
            m_Tools.Method_YG("IntersectWith", "IEnumerable<T>", "交集", "void", 20);
            m_Tools.Method_YG("UnionWith", "IEnumerable<T>", "并集", "void", 20);
            m_Tools.Method_YG("ExceptWith ", "IEnumerable<T>", "排除", "void", 20);
        }

        private void DrawDic()                                  // Dictionary<K, V> 
        {
//            m_Tools.GuangFangWenDan(LearnPath.DictionaryUrl);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable，IEnumerable<KeyValuePair<K, V>>");
                m_Tools.Text_H("       IDictionary，IDictionary<K, V>");
                m_Tools.Text_H("       ICollection，ICollection<KeyValuePair<K, V>>");
                m_Tools.Text_H("       ISerializable，IDeserializationCallback");
            });

        }

        private void DrawHashtable()                             // Hashtable
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.collections.hashtable(v=vs.110).aspx");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable, ICollection, ICloneable,IDictionary");
                m_Tools.Text_H("        ISerializable, IDeserializationCallback");
            });

        }

        private void DrawStack()                                 // Stack
        {
            m_Tools.Text_G("可以直接用泛型，也可以不使用");

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable<T>, ICollection, ICloneable");
            });

            MyCreate.Text("添加");
            m_Tools.Method_YG("Push", "", "在" + "顶部".AddGreen() + "放一个元素", "", -50);
            MyCreate.Text("删除");
            m_Tools.Method_YG("Pop", "", "删除" + "顶部".AddGreen() + "元素,返回删除的元素", "T", -50);
            MyCreate.Text("查");
            m_Tools.Method_YG("Peek", "", "查询" + "顶部".AddGreen() + "的元素", "T", -50);
            m_Tools.Text_Y("foreach、Contains、Clear、Clone");
        }

        private void DrawQueue()                                 // Queue
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.collections.queue(v=vs.110).aspx", "表示对象先进先出集合");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("继承  IEnumerable, ICloneable, ICollection");
            });
            m_Tools.Text_G("可以直接用泛型，也可以不使用");

            MyCreate.Text("添加");
            m_Tools.Method_YG("Enqueue", "", "在" + "顶部".AddGreen() + "放一个元素", "", -50);
            MyCreate.Text("删除");
            m_Tools.Method_YG("Dequeue", "", "删除" + "尾部".AddGreen() + "元素,返回删除的元素", "object", -50);
            MyCreate.Text("查");
            m_Tools.Method_YG("Peek", "", "查询" + "顶部".AddGreen() + "的元素", "object", -50);
            m_Tools.Text_Y("foreach、Contains、Clear、Clone");

        }

        private void DrawOtherNoUse()                            // 其他不常用
        {
            

        }

        private void DrawMyCreate()                              // 我创建的
        {
            

        }


        #region 私有

        private bool isAdd, isSort, isWhere, isFind, isBinarySearch, isInsert, isConstructors;

        private static readonly string ListStr = "List<T>";
        private static readonly string HashSetStr = "HashSet<T>";
        private static readonly string DicStr = "Dictionary<K, V>";
        private static readonly string HashtableStr = "Hashtable";
        private static readonly string StackStr = "Stack";
        private static readonly string QueueStr = "Queue";
        private static readonly string ArrayStr = "Array";
        private static readonly string ArrayListStr = "ArrayList";
        private static readonly string Point = " 、";

        public enum SJSGType
        {
            总结,
            相互区别,
            数组,
            ArrayList,
            List_T,
            HashSet_T,
            Dictionary_KV,
            Hshtable,
            Stack_T,
            Queue,
            其他不常用,
            我创建的
        }

        [HideLabel]
        [EnumToggleButtons(true,140)]
        public SJSGType _FenLie = SJSGType.总结;


//        [MenuItem(LearnMenu.CSJiChu + "数据结构")]
        public static void ShowWindow()
        {
            CreateWindow("数据结构", 510, 550);
        }




        private void OneLine(string str,string des, MyEnumColor color, params string[] strs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" ── ").Append(str.AddColor(color, false)).Append("  (").Append(des.AddGreen()).Append(")");
            MyCreate.Text(sb.ToString());

            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace(18);

                MyCreate.Box(() =>
                {
                    sb.Length = 0;
                    sb.Append(" ");
                    if (strs.Length <= 5)
                    {
                        for (int i = 0; i < strs.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                sb.Append(strs[i].AddBlue());
                            }
                            else
                            {
                                sb.Append(strs[i].AddLightBlue());
                            }
                            if (i != strs.Length - 1)
                            {
                                sb.Append(Point);
                            }
                        }
                        MyCreate.Text(sb.ToString());
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (i % 2 == 0)
                            {
                                sb.Append(strs[i].AddBlue());
                            }
                            else
                            {
                                sb.Append(strs[i].AddLightBlue());
                            }
                            if (i != strs.Length - 1)
                            {
                                sb.Append(Point);
                            }
                        }
                        MyCreate.Text(sb.ToString());
                        sb.Length = 0;
                        sb.Append(" ");
                        for (int i = 5; i < strs.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                sb.Append(strs[i].AddBlue());
                            }
                            else
                            {
                                sb.Append(strs[i].AddLightBlue());
                            }
                            if (i != strs.Length - 1)
                            {
                                sb.Append(Point);
                            }
                        }
                        MyCreate.Text(sb.ToString());

                    }

                });
            });
        }




        #endregion





    }

}

