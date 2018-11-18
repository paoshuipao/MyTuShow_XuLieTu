using Ez;
using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using QuickEditor;
using UnityEngine;

namespace UnityEditor
{
    public class Learn_CSharp : AbstactNewKuang
    {
        [MenuItem(LearnMenu.CSZhongJie, false, LearnMenu.CS_INDEX)]
        static void Init()
        {
            Learn_CSharp instance = GetWindow<Learn_CSharp>(false, "");
            instance.SetupWindow();
        }

        protected override void DrawLeft()                           // 画 左边 的各个类型
        {

            #region 基础类型(2)
            bool isJieChu = (type == EType.JieChu || type == EType.JieChu1 || type == EType.JieChu2 || type == EType.JieChu3 || type == EType.enFlags);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "基础类型";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.JieChu ? EZStyles.General.SideButtonSelected2 : EZStyles.General.SideButton2), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.JieChu);
            }
            if (isJieChu)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieChu1 ? " Enum".AddBlue() : " Enum");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieChu1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.enFlags ? " Enum + Flags".AddBlue() : " Enum + Flags");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.enFlags);
                }


                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieChu2 ? " KeyValuePair".AddBlue() : " KeyValuePair");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieChu2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.JieChu3 ? " 值传递与引用传递".AddBlue() : " 值传递与引用传递");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.JieChu3);
                }



            }


            #endregion

            AddSpace_3();

            #region 字符串 String(7)

            bool isString = (type == EType.ZiString || type == EType.string2 || type == EType.string3 || type == EType.strintOther || type == EType.stringDes);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "字符串 String";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.ZiString ? EZStyles.General.SideButtonSelected7 : EZStyles.General.SideButton7), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.ZiString);
            }
            if (isString)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.strintOther ? "string 其他 Api".AddBlue() : "string 其他 Api");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.strintOther);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.stringDes ? "string 格式化".AddBlue() : "string 格式化");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.stringDes);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.string2 ? "与其他类型相互转换".AddBlue() : "与其他类型相互转换");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.string2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.string3 ? "StringBuilder".AddBlue() : "StringBuilder");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.string3);
                }
            }



            #endregion

            AddSpace_3();

            #region 数据结构(3)

            bool tmpList = (type == EType.List || type == EType.List1 || type == EType.List2 || type == EType.List3 || type == EType.List4 || type == EType.List5 || type == EType.List6);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "数据结构";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.List ? EZStyles.General.SideButtonSelected3 : EZStyles.General.SideButton3), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.List);
            }
            if (tmpList)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List1 ? "IEnumerable、接口".AddBlue() : "IEnumerable、接口");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List2 ? "数组、Array".AddBlue() : "数组、Array");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List3 ? "List<T>".AddBlue() : "List<T>");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List3);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List4 ? "HashSet".AddBlue() : "HashSet");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List5 ? "键值对集合".AddBlue() : "键值对集合");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List5);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.List6 ? "Stack、Queue".AddBlue() : "Stack、Queue");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.List6);
                }


            }


            #endregion

            AddSpace_3();

            #region IO 操作(8)

            bool isIo = (type == EType.IO || type == EType.IO1 || type == EType.IO2 || type == EType.IO3 || type == EType.IO4 || type == EType.IO5);
            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "IO 操作";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.IO ? EZStyles.General.SideButtonSelected8 : EZStyles.General.SideButton8), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.IO);

            }
            if (isIo)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO1 ? "  File".AddBlue() : "  File");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO2 ? "  Directory".AddBlue() : "  Directory");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO3 ? "  Path".AddBlue() : "  Path");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO4 ? "  实例对象".AddBlue() : "  实例对象");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO4);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO5 ? "  读写流".AddBlue() : "  读写流");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO5);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.IO6 ? "  用到的枚举".AddBlue() : "  用到的枚举");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.IO6);
                }

            }


            #endregion

            AddSpace_3();

            #region Static 工具类(1)


            bool isStatic = (type == EType.StaticLie || type == EType.StaticLie1 || type == EType.StaticLie2 || type == EType.StaticLie3 || type == EType.StaticLie4);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "Static 工具类";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(isStatic ? EZStyles.General.SideButtonSelected1 : EZStyles.General.SideButton1), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.StaticLie1);

            }

            if (isStatic)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.StaticLie1 ? "  Convert".AddBlue() : "  Convert");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.StaticLie1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.StaticLie2 ? "  Encoding".AddBlue() : "  Encoding");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.StaticLie2);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.StaticLie3 ? "  BitConverter".AddBlue() : "  BitConverter");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.StaticLie3);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.StaticLie4 ? "  StringBuilder".AddBlue() : "  StringBuilder");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.StaticLie4);
                }

            }


            #endregion

            AddSpace_3();

            #region 反射相关(4)
            bool isFan = (type == EType.FanShe || type == EType.FanShe1 || type == EType.FanShe2 || type == EType.FanShe3);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "反射";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.FanShe ? EZStyles.General.SideButtonSelected4 : EZStyles.General.SideButton4), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.FanShe);
            }

            if (isFan)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FanShe1 ? "  Type".AddBlue() : "  Type");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FanShe1);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FanShe2 ? "  枚举反射例子".AddBlue() : "  枚举反射例子");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FanShe2);
                }

                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.FanShe3 ? "  反射创建实例".AddBlue() : "  反射创建实例");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.FanShe3);
                }
            }


            #endregion

            AddSpace_3();


            #region 线程(5)

            bool isThread = (type == EType.Thread || type == EType.Thread1 || type == EType.Thread2);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "线程";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.Thread ? EZStyles.General.SideButtonSelected5 : EZStyles.General.SideButton5), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.Thread);
            }

            if (isThread)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Thread1 ? "  线程池".AddBlue() : "  线程池");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Thread1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.Thread2 ? "  Semaphore".AddBlue() : "  Semaphore");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.Thread2);
                }
            }


            #endregion


            AddSpace_3();


            #region LINQ、关键字(6)

            bool isOther = (type == EType.LinqAndKey || type == EType.LinqAndKey1 || type == EType.LKPartial || type == EType.LKInternal || type == EType.LKChecked || type == EType.LKNew);

            tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : "LINQ、关键字";
            if (QUI.Button(tempLabel, EZStyles.GetStyle(type == EType.LinqAndKey ? EZStyles.General.SideButtonSelected6 : EZStyles.General.SideButton6), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
            {
                SetTheSame(EType.LinqAndKey1);
            }
            if (isOther)
            {
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LinqAndKey1 ? "  LINQ".AddBlue() : "  LINQ");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LinqAndKey1);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LKPartial ? "  partial".AddBlue() : "  partial");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LKPartial);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LKInternal ? "  internal".AddBlue() : "  internal");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LKInternal);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LKChecked ? "  checked".AddBlue() : "  checked");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LKChecked);
                }
                tempLabel = mWindowSettings.sidebarIsExpanded.faded < 0.6f ? "" : (type == EType.LKNew ? "  new".AddBlue() : "  new");
                if (QUI.Button(tempLabel, EZStyles.GetStyle(EZStyles.General.SideButtonBlue), mWindowSettings.SidebarCurrentWidth, mWindowSettings.sidebarButtonHeight))
                {
                    SetTheSame(EType.LKNew);
                }
            }
            #endregion


        }


        protected override void DrawRight()                          // 画 右边 的各个页面
        {
            switch (type)
            {
                case EType.JieChu: DrawRightPage1(DrawJiChuLie); break;
                case EType.JieChu1: DrawRightPage3(DrawJiEnum); break;
                case EType.JieChu2: DrawRightPage5(DrawKeyValuePair); break;
                case EType.enFlags: DrawRightPage6(DrawEnumFlags); break;

                case EType.ZiString: DrawRightPage3(DrawString); break;
                case EType.string2: DrawRightPage4(DrawZhuangHuang); break;
                case EType.string3: DrawRightPage5(DrawStringOther); break;
                case EType.strintOther: DrawRightPage1(DrawOtherApi); break;
                case EType.stringDes: DrawRightPage3(DrawStringFormat); break;

                case EType.List: DrawRightPage6(DrawShuJu); break;
                case EType.List1: DrawRightPage7(DrawIEnumerable); break;
                case EType.List2: DrawRightPage8(DrawArrayList); break;
                case EType.List3: DrawRightPage1(DrawList); break;
                case EType.List4: DrawRightPage3(DrawHashSet); break;
                case EType.List5: DrawRightPage4(DrawDic); break;
                case EType.List6: DrawRightPage5(DrawStack); break;

                case EType.IO: DrawRightPage6(DrawIO); break;
                case EType.IO1: DrawRightPage7(DrawFile); break;
                case EType.IO2: DrawRightPage8(DrawDirectory); break;
                case EType.IO3: DrawRightPage1(DrawPath); break;
                case EType.IO4: DrawRightPage3(DrawShiLi); break;
                case EType.IO5: DrawRightPage4(DrawXieRu); break;
                case EType.IO6: DrawRightPage1(DrawEnum); break;

                case EType.FanShe: DrawRightPage2(DrawFanShe); break;
                case EType.FanShe1: DrawRightPage5(DrawType); break;
                case EType.FanShe2: DrawRightPage6(DrawEnumType); break;
                case EType.FanShe3: DrawRightPage8(DrawFanShe2); break;

                case EType.StaticLie1: DrawRightPage1(DrawConvert); break;
                case EType.StaticLie2: DrawRightPage3(DrawEncoding); break;
                case EType.StaticLie3: DrawRightPage4(DrawBitConverter); break;
                case EType.StaticLie4: DrawRightPage5(DrawStringBuilder); break;



                case EType.Thread: DrawRightPage3(DrawThread); break;
                case EType.Thread1: DrawRightPage4(DrawThreadPool); break;
                case EType.Thread2: DrawRightPage5(DrawSemaphore); break;


                case EType.LinqAndKey1: DrawRightPage8(DrawLINQ); break;
                case EType.LKPartial: DrawRightPage1(Drawpartial); break;
                case EType.LKChecked: DrawRightPage3(Drawchecked); break;
                case EType.LKInternal: DrawRightPage4(Drawinternal); break;
                case EType.LKNew: DrawRightPage5(Drawnew); break;


            }

        }


        protected override void DrawRightSize()                      // 如果单个页面需要变大/小，就在这里修改
        {
            switch (type)
            {
                case EType.JieChu:
                    mWindowSettings.pageWidthExtraSpace.target = 5;
                    break;
                case EType.ZiString:
                    mWindowSettings.pageWidthExtraSpace.target = 15;
                    break;
                case EType.List6:
                    mWindowSettings.pageWidthExtraSpace.target = -40;
                    break;
                case EType.List:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.List3:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.List4:
                    mWindowSettings.pageWidthExtraSpace.target = 60;
                    break;
                case EType.LKPartial:
                    mWindowSettings.pageWidthExtraSpace.target = 35;
                    break;
                case EType.IO2:
                    mWindowSettings.pageWidthExtraSpace.target = 5;
                    break;
                case EType.FanShe:
                    mWindowSettings.pageWidthExtraSpace.target = -15;
                    break;
                case EType.FanShe2:
                    mWindowSettings.pageWidthExtraSpace.target = 50;
                    break;
                case EType.LKChecked:
                    mWindowSettings.pageWidthExtraSpace.target = 10;
                    break;
                case EType.LKNew:
                    mWindowSettings.pageWidthExtraSpace.target = 30;
                    break;
                default:
                    mWindowSettings.pageWidthExtraSpace.target = 0;
                    break;
            }
        }



        #region 私有

        private bool isThread, isThreadState, isEnum;
        private bool isCreate, isGetFiles, isGetDirectories;
        private bool isParse, isEncoding, isConcat, isJoin, isReplace, isToUpper;
        private bool isGetEvent, isBindingFlags, isGetField, isGetMethod, isShu2, isToString;
        private bool isDictionary, isForeach2, isHashtable, isForeach;
        private bool isGetProperty, isGetMember, isMethodInfo, isShu, isInvoke, isFieldInfo;
        private bool isWhere, isFind, isBinarySearch, isConstructors;
        private static readonly string LiJian = "条件".AddGreen();


        private enum EType
        {
            JieChu, JieChu1, JieChu2, JieChu3, enFlags,

            ZiString, string2, string3, strintOther, stringDes,

            List, List1, List2, List3, List4, List5, List6,

            IO, IO1, IO2, IO3, IO4, IO5, IO6,

            StaticLie, StaticLie1, StaticLie2, StaticLie3, StaticLie4,

            FanShe, FanShe1, FanShe2, FanShe3,

            Thread, Thread1, Thread2,

            LinqAndKey, LinqAndKey1, LKPartial, LKInternal, LKChecked, LKNew,





        }

        private EType type = EType.JieChu;

        private void SetTheSame(EType t)
        {
            if (type != t)
            {
                type = t;
                ResetPageView();
            }

        }

        protected override string Tittle()                           // 标题
        {
            return "C# 总结";
        }


        protected override bool OnIsEasy()
        {
            return true;
        }



        private void LINQ()
        {
            MyCreate.Box(() =>
            {
                MyCreate.Text("题目:".AddOrange() + " int[] nums ={1，15，2，30，90，5} ".AddHui() + "—> 求低于20的集合".AddLightBlue());
                m_Tools.BiaoTi_B("1. 查询语法：" + "（类似 SQL 语句）".AddLightGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("IEnumerable<int> res = from n in nums", "// foreach( n in 数据)", 68);
                    m_Tools.TextText_HG("                                where n < 20", "//  if ( n < 20)", 68);
                    m_Tools.TextText_HG("                                select n;", "//  true ：选择", 68);
                });
                m_Tools.BiaoTi_B("2. 方法语法： " + "（匿名方法调用）".AddLightGreen());
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("IEnumerable<int> res = nums.Where(x => x < 20);");
                });
            });
        }


        #endregion


        #region 基础类型

        private void DrawJiChuLie()                              // 基础类型
        {
            m_Tools.BiaoTi_Y("值类型：" + "枚举、结构体(基本类型+自定义结构体)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("①. 枚举：".AddBlue() + "enum ".AddYellow() + "（派生于 System.Enum）".AddBlue());
                MyCreate.Text("②. 结构体：（派生于 System.ValueType）".AddBlue());
                m_Tools.Text_L("♦ 数值类型");
                m_Tools.Text_H("    ▪ 整型：", "sbyte、byte、char、short、ushort、uint、int、long、ulong".AddYellow());
                m_Tools.Text_H("    ▪ 浮点型：", "float、double".AddYellow());
                m_Tools.Text_H("    ▪ 用于财务计算的高精度decimal型：", "decimal".AddYellow());
                m_Tools.Text_L("♦ 布尔型：", "bool".AddYellow());
                m_Tools.Text_L("♦ 自定义的结构体 ", "struct".AddYellow());
            });

            AddSpace_3();

            m_Tools.BiaoTi_Y("引用类型：" + "数组、object、string、接口、类、委托".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("①. ".AddBlue() + "数组".AddYellow() + "（派生于 System.Array）".AddBlue());
                MyCreate.Text("②. ".AddBlue() + "object".AddYellow() + "（System.Object的别名）".AddBlue());
                MyCreate.Text("③. 字符串：".AddBlue() + "string ".AddYellow() + "（System.String的别名)".AddBlue());
                MyCreate.Text("④. 自定义的类型".AddBlue());
                m_Tools.Text_L(" ♦ 接口：", "interface".AddYellow());
                m_Tools.Text_L(" ♦ 类：", "class".AddYellow(), "（派生于System.Object）");
                m_Tools.Text_L(" ♦ 委托：", "delegate".AddYellow(), "（派生于System.Delegate）");
            });

            AddSpace();
            m_Tools.BiaoTi_B("[引用类型] 与 [值类型] " + "特性".AddGreen());
            MyCreate.Box(() =>
            {
                AddSpace();
                MyCreate.Window("值类型 特性", () =>
                {
                    m_Tools.Text_H("1.值类型变量", "不能为 null".AddGreen(), "。必须具有一个确定的值");
                    m_Tools.Text_H("2.值类型在应用中是" + "传递或得到一个值的副本".AddGreen());
                    m_Tools.Text_H("1.值类型变量一般都存储在线程", "堆栈中".AddGreen());

                });
                AddSpace_15();
                MyCreate.Window("引用类型 特性", () =>
                {
                    m_Tools.Text_H("1.引用类型被赋值前的值都是" + " null".AddGreen());
                    m_Tools.Text_H("2.引用类型在应用中是" + "传递或得到一个引用".AddGreen());
                    m_Tools.Text_H("3.必须在托管堆中为引用类型变量" + "分配内存".AddGreen());
                });
            });

            AddSpace_3();
            m_Tools.BiaoTi_B("[值类型] " + "范围".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BL("C# Type", ".NET Type", "Description", "Size(bytes)");
                MyCreate.Text("布尔型");
                m_Tools.Method_OW("bool", "Boolean", "true/false", "1");
                MyCreate.Text("整型");
                m_Tools.Method_OW("byte", "Byte", "0～255" + "  (2⁸)".AddGreen(), "1");
                m_Tools.Method_OW("sbyte", "SByte", "-128～127 ", "1");
                m_Tools.Method_OW("char", "Char", "单一字符", "2");
                m_Tools.Method_OW("ushort", "UInt16", "0～65535" + "  (2¹⁶)".AddGreen(), "2");
                m_Tools.Method_OW("short", "Int16", "-32768～32767", "2");
                m_Tools.Method_OW("uint", "UInt32", "0～4,294,967,295" + "  (2³²)".AddGreen(), "4");
                m_Tools.Method_OW("int", "Int32", "-2,147,483,648～2,147,483,647", "4");
                m_Tools.Method_OW("ulong", "UInt64", "0～18(18个零)" + "  (2⁶⁴)".AddGreen(), "8");
                m_Tools.Method_OW("long", "Int64", "-9(18个零)～9(18个零)", "8");
                MyCreate.Text("浮点型 (精度是指多少位不会省略)");
                m_Tools.Method_OW("float", "Single", "小数±1.5 × 10㆒⁴⁵|±3.4 × 10³⁸ " + "7位精度".AddGreen(), "4");
                m_Tools.Method_OW("double", "Double", "±5 × 10㆒³²⁴|±1.7 × 10³º⁸ " + "15/16位精度".AddGreen(), "8");
                m_Tools.Method_OW("decimal", "Decimal", "±1 × 10㆒²⁸ to ±7.9 × 10²⁸ " + "28位精度".AddGreen(), "16");
            });
        }


        private void DrawJiEnum()                                // Enum
        {

            m_Tools.BiaoTi_L("Enum 有几个实用的 " + "Static 方法".AddGreen(), ref isEnum, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.Text_H("    public 枚举类型 枚举名 { 枚举分量名 = 值 }");
                    m_Tools.Text_H("    枚举类型.枚举分量名    ->  这个就是 枚举对象");

                });
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("public enum " + EEnumStr + "｛ 分量1 = 0，分量2 = 19，分量3 ｝" + "  ->  作为例子".AddHui());
            });


            AddSpace();

            m_Tools.BiaoTi_B("获得对应值、对应枚举分量名称、枚举对象");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("Format", "", "从 枚举对象 获得 -> 值 名称", "string");
                m_Tools.TextText_LG("     Enum.Format(typeof(" + EEnumStr + ")," + EEnumStr + ".分量3,”D“)", "-> 20", 150);
            });

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("GetName", "", "从 值 反获得 -> 枚举分量名", "string");
                m_Tools.TextText_LG("     Enum.GetName(typeof(" + EEnumStr + "), 19)", "-> 分量2", 150);
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("IsDefined", "", "通过 值 判断是否有这个 枚举分量名", "bool");
                m_Tools.TextText_LG("     Enum.IsDefined(typeof(" + EEnumStr + "), 2)", "-> false", 150);
                m_Tools.TextText_LG("     Enum.IsDefined(typeof(" + EEnumStr + "), 19)", "-> true", 150);
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("Parse", "", "从 字符串 获得 -> 枚举对象", "object");
                m_Tools.TextText_LG("     (" + EEnumStr + ")Enum.Parse(typeof(" + EEnumStr + "), “分量2”)", "-> E枚举.Enum2", 150);
            });


            m_Tools.BiaoTi_B("获得数组");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("GetNames", "", "获得所有 枚举分量 名称", "string[]");
                m_Tools.Text_L("     foreach (string str in Enum.GetNames(typeof(", EEnumStr, ")))");
                m_Tools.Text_L("          str  ->  ", "“分量1”、“分量2”、“分量3”".AddGreen());
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BO("GetValues", "", "获得所有 枚举对象", "Array");
                m_Tools.Text_L("     foreach (", EEnumStr, " e in Enum.GetValues(typeof(", EEnumStr, ")))");
                m_Tools.Text_L("          e  ->  ", "E枚举.分量1、E枚举.分量2、E枚举.分量3".AddGreen());
            });
        }


        private void DrawEnumFlags()
        {

            m_Tools.BiaoTi_B("注意：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("1. 枚举分量必须标明 1  2  4  8 ......");
                m_Tools.Text_G("2. 使用 & 来判断");
            });

            m_Tools.BiaoTi_B("例子");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("[Flags]");
                m_Tools.Text_H("enum EnumTest");
                m_Tools.Text_H("{");
                m_Tools.TextText_HG("     Test01 = 1,", "// 必须，必须，必须从 1 开始");
                m_Tools.Text_H("     Test02 = 2,");
                m_Tools.Text_H("     Test03 = 4 ");
                m_Tools.Text_H("}");
                AddSpace();
                m_Tools.Text_H("private EnumTest test = EnumTest.Test01 | EnumTest.Test03;");
                AddSpace();
                m_Tools.TextText_YG("(test & EnumTest.Test01) !=0", "true", 50);
                m_Tools.TextText_YG("(test & EnumTest.Test02) !=0", "false", 50);
                m_Tools.TextText_YG("(test & EnumTest.Test03) !=0", "true", 50);


            });

        }


        private void DrawKeyValuePair()                          // KeyValuePair
        {
            m_Tools.BiaoTi_B("KeyValuePair<TKey, TValue> " + "(可读可写的键/值对)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("    1. 这是个", " 结构体".AddYellow(), "，可以 new 出来");
                m_Tools.Text_L("    2. ", "Dictionary 字典".AddYellow(), "内部就是使用这个 结构体");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("foreach( KeyValuePair<string, string> kvp in myDictionary )");
                    m_Tools.Text_G("// foreach 语句是允许唯一读取、 不写入集合的枚举器周围的包装");
                });
            });
            AddSpace();

            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Text4_B("Key", "键", "Value", "值");
            });

        }




        #endregion



        #region 字符串 String

        private void DrawString()                                // 字符串 String
        {
            m_Tools.BiaoTi_B("static 方法");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BL("IsNullOrWhiteSpace", "string", "字符是否 null、“”、“全空格”", "bool", 15);
                m_Tools.Method_BL("Concat", "params string[]", "连接 ".AddGreen() + "(“A”,“B”，“C” -> “ABC”)", "string", ref isConcat, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "Concat", "IEnumerable<String>", "", "string", 15);
                    m_Tools.Method_BL(ZhongZai + "Concat", "params object[]", "", "string", 15);
                }, 15);
                m_Tools.Method_BL("Join", "String ,Object[]", "string为分隔符,把" + "数组合并".AddGreen() + "成字符串", "string", ref isJoin, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "Join", "String ,IEnumerable<String>", "");
                    m_Tools.Method_BL(ZhongZai + "Join", "String ,string[]", "");

                }, 15);
                m_Tools.Method_BL("Format", "“ {0} ”,object", "格式化字体串", "string", 15);
                m_Tools.Method_BL("Compare", "string ,string", "比较".AddGreen() + "两个字符的先后位置", "int", 15);
            });
            AddSpace_3();
            m_Tools.BiaoTi_B("方法");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("增".AddOrange());
                m_Tools.Method_BL("Insert", "int,string", "在指定的索引位置处" + "插入".AddOrange() + "string", "string", 15);
                m_Tools.Method_BL("PadLeft", "int", "字符左边" + "填充".AddOrange() + "字符" + "(默认空格)".AddWhite(), "string", 15);
                m_Tools.Method_BL(ZhongZai + "PadRight", "int，char", "同上+重载".AddWhite() + "，可填充指定字符", "string", 15);
                MyCreate.Text("删".AddOrange());
                m_Tools.Method_BL("Remove", "int 索引,int 长度", "删除".AddOrange() + "对应长度", "string", 15);
                m_Tools.Method_BL(ZhongZai + "Remove", "int 索引", "删除索引到结尾全部", "string", 15);
                m_Tools.Method_BL("Trim", "", "清除".AddOrange() + "两边空格" + "(默认空格)".AddHui(), "string", 15);
                m_Tools.Method_BL(ZhongZai + "Trim", "char[]", "清除两边(char 字符)，直到没有为止", "string", 15);
                m_Tools.Method_BL("TrimStart", "char[]", "清除开头".AddOrange() + "所有(char 字符)", "string", 15);
                m_Tools.Method_BL("TrimEnd", "char[]", "同上,清除结尾".AddHui(), "string", 15);

                MyCreate.Text("改".AddOrange());
                m_Tools.Method_BL("Replace", "string a，string b", "在字符串中找到所有 a " + "替换".AddOrange() + "成 b", "string", ref isReplace, () =>
                {
                    m_Tools.Method_BL(ZhongZai + "Replace", "char a，char b", "string");
                }, 15);
                m_Tools.Method_BL("Substring", "int 索引, int 长度", "截取".AddOrange() + "对应长度", "string", 15);
                m_Tools.Method_BL("ToUpper", "", "全部" + "修改成大写".AddOrange(), "string", ref isToUpper, () =>
                {
                    m_Tools.Method_BL("ToUpperInvariant", "", "给" + "特殊字母大写".AddGreen() + " 如：“Τρίτם שלישי", "string", 15);
                }, 15);
                m_Tools.Method_BL("ToLower", "", "全部修改成小写", "string", 15);
                MyCreate.Text("分割".AddYellow());
                m_Tools.Method_BL("Split", "Char[]", "按特定的字符" + "分割成多个子字符串".AddYellow(), "string[]", 15);
                m_Tools.Method_BL(ZhongZai + "Split", "string[]，StringSplitOptions 枚举", "", "string[]", 15);
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_LH("   None", "包含一个空字符串 + string[]", 40);
                    m_Tools.TextText_LH("   RemoveEmptyEntries", "string[]", 40);
                });

                MyCreate.Text("判断".AddWhite());
                m_Tools.Method_BL("StartsWith", "string", "开头是否".AddWhite() + "这个字符", "bool", 15);
                m_Tools.Method_BL("EndsWith", "string", "结尾是否".AddWhite() + "这个字符", "bool", 15);
                MyCreate.Text("获取索引".AddGreen());
                m_Tools.Method_BL("IndexOf", "string", "string在原字符串" + "第一次出现的索引".AddGreen(), "int", 15);
                m_Tools.Method_BL("LastIndexOf", "string", "string在原字符串" + "最后一次出现的索引".AddGreen(), "int", 15);
                m_Tools.Method_BL("IndexOfAny", "Char[]", "(char 集合中任意一个)".AddGreen() + "第一次出现的索引", "int", 15);
                m_Tools.Method_BL("LastIndexOfAny", "Char[]", "(char 集合中任意一个)".AddGreen() + "最后一次出现的索引", "int", 15);
            });
        }

        private void DrawZhuangHuang()                           // 与其他类型相互转换
        {
            m_Tools.BiaoTi_B("string 与 基本类型 互换");
            MyCreate.Box(() =>
            {
                MyCreate.Text("string 转 int、bool、byte 等所有基本类型都可用 " + "（下面以 int 为例）:".AddGreen());
                m_Tools.Method_OY("int.Parse", "string", "非 int 会报错", "int");
                m_Tools.Method_OY("int.Parse", "string,NumberStyles", "NumberStyles 数字类型（枚举）", "int", ref isParse, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.globalization.numberstyles(v=vs.110).aspx");
                        m_Tools.TextText_YG("AllowCurrencySymbol", "可以包含货币符号");
                        m_Tools.TextText_YG("AllowDecimalPoint", "可以有一个小数点");
                        m_Tools.TextText_YG("AllowExponent", "可以在指数记数法");
                        m_Tools.TextText_YG("AllowHexSpecifier", "表示十六进制值的字符串");
                        m_Tools.TextText_YG("AllowLeadingSign", "可以具有前导符号");
                        m_Tools.TextText_YG("AllowLeadingWhite", "前导空白字符可出现在所分析的字符串");
                        m_Tools.TextText_YG("AllowParentheses", "可以有一对括号内包含数");
                        m_Tools.TextText_YG("AllowThousands", "具有组分隔符");
                        m_Tools.TextText_YG("AllowTrailingSign", "具有结尾的符号字符");
                        m_Tools.TextText_YG("AllowTrailingWhite", "随空白字符可出现在所分析的字符串");
                        m_Tools.TextText_YG("Any", "");
                        m_Tools.TextText_YG("Currency", "");
                        m_Tools.TextText_YG("Float", "");
                        m_Tools.TextText_YG("HexNumber", "");
                        m_Tools.TextText_YG("Integer", "");
                        m_Tools.TextText_YG("None", "");
                        m_Tools.TextText_YG("Number", "");
                    });
                });
                m_Tools.Method_OY("int.TryParse", "string,out int", "转化 int 成功返回 true", "bool");
                MyCreate.Text("string 转 char 除了上面方法" + "（还可以使用 string 索引器）:".AddGreen());
                m_Tools.Method_OY("string 索引器", "", "例： str[1]", "char");
                MyCreate.FenGeXian();
                MyCreate.Text("基本类型 转 string " + "( ToString)，".AddGreen() + "（下面为特殊格式说明符以 int 为例）".AddLightGreen());
                m_Tools.Method_OY("int i=1000 ;   i.ToString", "string 正则", "  规定格式", "string", ref isToString, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BY("i.ToString(" + "“C”".AddGreen() + ") ", "$1，000.00" + "    带 $ 符号".AddLightBlue());
                        m_Tools.TextText_BY("i.ToString(" + "“D8”".AddGreen() + ") ", "00001000" + "    保证多少位，不足用0补".AddLightBlue());
                        m_Tools.TextText_BY("i.ToString(" + "“E4”".AddGreen() + ") ", "1.0000E+003");
                        m_Tools.TextText_BY("i.ToString(" + "“e3”".AddGreen() + ") ", "1.000e+003");
                        m_Tools.TextText_BY("i.ToString(" + "“F”".AddGreen() + ") ", "1000.00");
                        m_Tools.TextText_BY("i.ToString(" + "“N”".AddGreen() + ") ", "1,000.00");
                        m_Tools.TextText_BY("i.ToString(" + "“P”".AddGreen() + ") ", "100,000.00 %" + "    百分号".AddLightBlue());
                        m_Tools.TextText_BY("i.ToString(" + "“X”".AddGreen() + ") ", "3E8" + "    十六进制".AddLightBlue());
                        m_Tools.TextText_BY("i.ToString(" + "“0,0.000”".AddGreen() + ") ", "1，000.000");
                        m_Tools.TextText_BY("i.ToString(" + "“#,#.00#;(#,#.00#”".AddGreen() + ") ", "1，000.00");

                        MyCreate.Text("应用例如：一个 int 转 string 必须 3位数以上，不足用 0 补上".AddGreen());
                        m_Tools.Text_G("这时这样写即可： " + ("string str = i.ToString(" + "“D3”".AddGreen() + ") ").AddHui());

                    });
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("string、" + "char[]".AddGreen() + "、" + "byte[]  ".AddGreen() + "互转");
            MyCreate.Box(() =>
            {
                MyCreate.Text("string 与 char[]".AddHui());
                m_Tools.Method_OY("str.ToCharArray()", "", "str 转 char[]", "char[]", 60);
                m_Tools.Method_OY(ZhongZai + "str.ToCharArray", "int 索引，int 长度", "", "char[]", 60);
                m_Tools.Method_OY("new string", "char[]", "char[] 转 string", "string", 60);
                MyCreate.Text("string 与 byte[]".AddHui());
                m_Tools.Method_OY("Encoding.UTF8.GetBytes", "string", "", "byte[]", ref isEncoding, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.text.encoding(v=vs.110).aspx", "Encoding");
                        m_Tools.TextText_BL("Encoding.Default", "获取操作系统的当前 ANSI 代码页的编码", -20);
                        m_Tools.TextText_BL("Encoding.ASCII", "ASCII 码", -20);
                        m_Tools.TextText_BL("Encoding.Unicode", "Little-Endian 字节 UTF-16 格式编码", -20);
                        m_Tools.TextText_BL("Encoding.UTF8", "UTF-8 格式的编码", -20);
                    });
                }, 60);

                m_Tools.Method_OY("Encoding.UTF8.GetString", "byte[]", "", "string");

                MyCreate.Text("byte[] 与 char[]".AddHui());
                m_Tools.Method_OY("Encoding.ASCII.GetChars", "byte[]", "", "char[]");
                m_Tools.Method_OY("Encoding.ASCII.GetBytes", "char[]", "", "byte[]");
            });

            AddSpace();
            m_Tools.BiaoTi_B("string 转 其他( " + "IPAddress".AddGreen() + " )");
            MyCreate.Box(() =>
            {
                MyCreate.Text("string 转 IPAddress IP地址".AddHui());
                m_Tools.Method_OY("IPAddress", "string", "string 要满足“ 127.0.0.1 ”格式", "IPAddress", -20);

            });
        }

        private void DrawStringOther()                           // StringBuilder
        {
            m_Tools.BiaoTi_B("StringBuilder".AddYellow() + "可变字符字符串");
            MyCreate.Box(() =>
            {
                m_Tools.BiaoTi_L("方法");
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("增加");
                    m_Tools.Method_BL("Append", "基础类型/string", "追加".AddGreen() + " 任意类型", "StringBuilder", 30);
                    m_Tools.Method_BL("AppendLine", "", "追加".AddGreen() + " 默认的行终止符", "StringBuilder", 30);
                    m_Tools.Method_BL(ZhongZai + "AppendLine", "string", "追加 字符串 + 行终止符", "StringBuilder", 30);
                    m_Tools.Method_BL("Insert", "int 索引，基础类型/string", "插入".AddGreen() + " 任意类型", "StringBuilder", 30);
                    MyCreate.Text("删除");
                    m_Tools.Method_BL("Remove", "int 索引，int 长度", "", "StringBuilder", 30);
                    MyCreate.Text("修改");
                    m_Tools.Method_BL("Replace", "string 旧，string 新", "将旧" + "替换".AddGreen() + "成新的", "StringBuilder", 30);
                });
                m_Tools.BiaoTi_L("清空数据");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1. 可以用", " Remove（0，sb.Length） ".AddWhite(), "清空");
                    m_Tools.Text_H("2. 可以用", " sb.Length = 0 ".AddWhite(), "清空");
                });
            });
        }


        private void DrawOtherApi()                              // string 其他Api
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.string.aspx");


            m_Tools.BiaoTi_B("属性");
            MyCreate.Box(() =>
            {
                m_Tools.Method_LW("this[int]", "", "索引器", "Char", 15);
                m_Tools.Method_LW("Length", "", "长度", "int", 15);
            });

        }

        private static readonly string JIA = "   + ".AddGreen();
        private float mFolat = 2.5f;
        private float mFolat2 = 1050.5f;
        private int mInt = 5;
        private void DrawStringFormat()                          // string 格式化
        {

            m_Tools.BiaoTi_B("1. 使用 ToString() " + "(其他类型 格式化成-> string)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                mFolat = m_Tools.TextFloat_Y("能 float值   ->", mFolat, -5, 5);
                m_Tools.TextText_BL("   ToString(“C”)   " + "     // 货币".AddGreen(), mFolat.ToString("C"), 100);
                m_Tools.TextText_BL(JIA + "ToString(“C3”)   ", mFolat.ToString("C3"), 100);
                m_Tools.TextText_BL("   ToString(“F1”)   " + "   // 固定点".AddGreen(), mFolat.ToString("F1"), 100);
                m_Tools.TextText_BL(JIA + "ToString(“F3”)   ", mFolat.ToString("F3"), 100);
                m_Tools.TextText_BL("   ToString(“P”)   " + "     // 百分比".AddGreen(), mFolat.ToString("P"), 100);
                m_Tools.TextText_BL(JIA + "ToString(“P3”)   ", mFolat.ToString("P3"), 100);
                m_Tools.TextText_BL("   ToString(“0.0”)   ", mFolat.ToString("0.0"), 100);
                m_Tools.TextText_BL(JIA + "ToString(“0.000”)   ", mFolat.ToString("0.000"), 100);
                m_Tools.TextText_BL("   ToString(“0.#”)   ", mFolat.ToString("0.#"), 100);
                m_Tools.TextText_BL(JIA + "ToString(“0.###”)   ", mFolat.ToString("0.###"), 100);

                mFolat2 = m_Tools.TextFloat_Y("能 float值，用于大值才有体现  ->", mFolat2, -2000, 2000);
                m_Tools.TextText_BL("   ToString(“N”)   " + "    // 数字".AddGreen(), mFolat2.ToString("N"), 100);
                m_Tools.TextText_BL("   ToString(“E”)   " + "    // 科学型".AddGreen(), mFolat2.ToString("E"), 100);


                AddSpace();
                mInt = m_Tools.TextInt_Y("只能 int 值" + "(float 会报错)".AddRed() + "  ->", mInt, -2000, 2000);
                m_Tools.TextText_BL("   ToString(“D5”)   " + " // 十进制数".AddGreen(), mInt.ToString("D5"), 100);
                m_Tools.TextText_BL("   ToString(“X”)   " + "   // 十六进制".AddGreen(), mInt.ToString("X"), 100);


            });

            m_Tools.BiaoTi_B("2. String.Format()" + "(string 格式-> string)".AddGreen());


        }





        #endregion


        #region LINQ 与 关键字



        private void DrawLINQ()                                  // LINQ
        {
            m_Tools.BiaoTi_Y("LINQ " + "(查询 数组集合、XML文档、数据库)".AddGreen());
            LINQ();
        }

        private void Drawpartial()                               // 关键字  partial
        {

            m_Tools.BiaoTi_Y("其他关键字 ");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextSelectText_B("老是忘记的 接口", "interface");
                m_Tools.TextText_BL("sealed(密封)", "声明为密封类，不能被继承");

            });

            AddSpace();


            m_Tools.BiaoTi_B("partial " + "(局部) 将一个类分成几个部分,实现在不同 .cs 中".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("    ① 建一个类 A.cs ：", "partial  class  A".AddWhite());
                m_Tools.Text_L("    ② 再建一个类 B.cs 也写成：", "partial  class  A".AddWhite());
                m_Tools.Text_G("③ 最终 ->", " class  A ".AddWhite(), "就是 A.cs + B.cs 结合");
                MyCreate.Text("局部类型适用于以下情况：");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1. 类型特别大，不宜放在一个文件中实现");
                    m_Tools.Text_H("2. 一个类的代码为自动化工具生成的，不宜与编写的代码混合在一起");
                    m_Tools.Text_H("3. 需要多人合作编写一个类");
                });
                MyCreate.Text("局部类型的限制：");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("1. 局部类型只适用于", "类、接口、结构".AddGreen(), "，不支持委托和枚举");
                    m_Tools.Text_H("2. 同一个类型的各个部分必须都有修饰符 partial");
                    m_Tools.Text_H("3. 使用局部类型时，一个类型的各个部分必须位于相同的命名空间中");
                    m_Tools.Text_H("4. 一个类型的各个部分必须被同时编译");
                });
                MyCreate.Text("局部类型的应用特性：" + "累加".AddGreen());
                MyCreate.Text("局部类型上的修饰符：" + "必须一致".AddGreen());
            });
        }


        private void Drawinternal()                             // internal
        {
            m_Tools.BiaoTi_B("internal " + "(内部) 同一个 dll（当前项目）才能访问".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_WL("Public ", "所有都能访问，包含不同语言");
                m_Tools.TextText_WL("internal ", "在这个 dll 中都可以访问，到其他项目就不能用");
                m_Tools.TextText_WL("protected ", "只有派生类才能访问");
                m_Tools.TextText_WL("protected internal", "只有派生类且同一项目才能访问");
                m_Tools.TextText_WL("private", "只有自己才可以访问到");
                MyCreate.AddSpace(5);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("默认访问修饰符" + "（就是不添加的情况）".AddGreen());
                    m_Tools.TextText_BL("类 默认访问级别 : ".AddOrange() + "internal", "// 类 不加修饰符，同一项目都可以访问");
                    m_Tools.TextText_BL("方法默认访问级别 : ".AddOrange() + "private", "// 方法不加修饰符，只有自己可以访问");

                });
            });
        }


        private void Drawchecked()                              // checked
        {
            m_Tools.BiaoTi_B("checked " + "(检查) 检查数学运算是否溢出".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextUrl("                                                                         (这文章分析得不错)", "https://www.cnblogs.com/yukaizhao/archive/2011/08/09/csharp-checked-unchecked-keywords.html");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_RG("int a = int.MaxValue * 2", "// 编译不通过");
                    MyCreate.FenGeXian_Blue("");
                    m_Tools.Text_H("int temp = int.MaxValue");
                    m_Tools.TextText_HG("int a = temp * 2", "// a = -2，不报错，但结果却乱了");
                    MyCreate.AddSpace(8);
                    m_Tools.Text_H("try");
                    m_Tools.Text_H("{");
                    m_Tools.TextText_RG("     int a = checked(temp * 2)", "// 会报错,会给try catch 捕获到");
                    m_Tools.Text_H("}");
                    m_Tools.Text_H("catch ...");
                });
            });

        }



        private void Drawnew()                                  // new
        {

            m_Tools.BiaoTi_O("C# 中 new 的作用");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("1. new 运算符：用于创建对象和调用构造函数" + "// 常用".AddGreen());
                m_Tools.Text_L("2. new 约束：用于在泛型声明中约束可能用作类型参数的参数的类型  " + TWO);
                m_Tools.Text_L("3. new 修饰符：在用作修饰符时，new 关键字可以显式隐藏从基类继承的成员  " + THREE);
            });

            AddSpace();
            m_Tools.BiaoTi_B("用于泛型 T 约束  " + TWO);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("class 类名<T>", " where T : new()".AddGreen());
            });

            AddSpace();
            m_Tools.BiaoTi_B("用于修饰符" + "(new 和 override的区别)  ".AddLightBlue() + THREE);
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("override  -> 直接重写父类的方法 ", "// 加.base() 调用回父类方法".AddGreen());
                m_Tools.Text_Y("new   -> 调用的方法  ->  ", "声明是子类就是子类方法，声明父类就是父类方法".AddGreen());
                m_Tools.Text_G("用于 MonoBehaviour 的 Start 也一样是调用子类的 Start 方法，相当重写");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("public class 父类");
                    m_Tools.Text_H("     public virtual void 让子类继承的方法()");
                    m_Tools.Text_H("           MyLog.Rd(”", " 父类调用的方法".AddRed(), "“);");
                    AddSpace();
                    m_Tools.Text_H("public class 子类 : 父类");
                    m_Tools.Text_H("     public new void 让子类继承的方法()");
                    m_Tools.Text_H("           MyLog.Green(”", "new 写的方法".AddGreen(), "“);");
                    AddSpace();
                    m_Tools.Text_L("1. 声明是子类，就会调用子类的方法");
                    m_Tools.Text_H("    子类 zi = new 子类()");
                    m_Tools.TextText_HG("    zi.让子类继承的方法();", "// new 写的方法", 60);
                    m_Tools.Text_L("2. 声明是父类，就会调用父类的方法");
                    m_Tools.Text_H("    父类 fu = new 子类()");
                    m_Tools.TextText_HR("    fu.让子类继承的方法();", "// 父类调用的方法", 60);
                    m_Tools.Text_L("3. 不写，或者使用 var 都是调用子类方法");
                    m_Tools.TextText_HG("    new 子类().让子类继承的方法();", "// new 写的方法", 60);


                });

            });
        }





        struct Textstruct
        {

            public int ABC { get; private set; }

            public Textstruct(int abc) : this()
            {
                ABC = abc;
            }
        }



        #endregion

        #region 反射

        private void DrawFanShe()                                // Type反射
        {
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.type(v=vs.110).aspx", "Type");
            m_Tools.BiaoTi_O("所有类的都有的方法来获取 -> Type");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("1. object 的 GetType()", "", "实例化的对象.GetType()", "Type", 25);
                m_Tools.Method_BY("2. typeof(T)", "", "运算符关键字", "Type", 25);
            });
            m_Tools.BiaoTi_O("Type 的 Static 方法");
            m_Tools.Method_BY("3. Type.GetType", "string", "“ 命名空间.名称，xxx.dll ”", "Type", 25);
            m_Tools.Method_BY("    +".AddGreen() + "Type.GetType", "string , bool", "");
            m_Tools.Method_BY("    +".AddGreen() + "Type.GetType", "string , bool , bool", "");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("第一参数 string");
                m_Tools.TextText_YG("   “MyClass”", "// 不使用命名空间并且在Unity下", 30);
                m_Tools.TextText_YG("   “PSP.MyClass”", "// 使用命名空间 PSP", 30);
                m_Tools.TextText_YG("   “PSP.MyClass，PSPUtil.dll”", "// 在 PSPUtil 的 dll下的", 30);
                m_Tools.Text_Y("第二参数 bool ：".AddLightBlue(), "没找到是否报错 ", "    // 默认 true 报错".AddGreen());
                m_Tools.Text_Y("第三参数 bool ：".AddLightBlue(), "是否区分大小写 ", "    // 默认 false 区分大小写".AddGreen());
            });
            m_Tools.Method_BY("4. Type.GetTypeArray", "object[]", "获取数组中对象的类型", "Type[]", 30);
        }


        private void DrawFanShe2()                               // 反射创建实例
        {

            m_Tools.BiaoTi_B("Activator 的 Static 方法");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.activator(v=vs.110).aspx");
                m_Tools.Method_BY("CreateInstance<T>", "", "调用 T 的无参构造，没有报错", "T", -20);
                m_Tools.Method_BY(ZhongZai + "CreateInstance", "Type", "调用 T 的无参构造，没有报错", "object", -20);
                m_Tools.Method_BY(ZhongZai + "CreateInstance", "Type，bool", "默认 false" + "（只找 Public）".AddGreen(), "object", -20);
                m_Tools.Method_BY(ZhongZai + "CreateInstance", "Type，params Object[]", "加参数", "object", -20);
                m_Tools.Method_BY(ZhongZai + "CreateInstance", "Type,BindingFlags,Binder,Object[],CultureInfo", "", "object");
                MyCreate.Box(() =>
                {

                    m_Tools.TextText_OW("Type", "对象类型");
                    m_Tools.TextText_OW("BindingFlags", "搜索标志");
                    m_Tools.TextText_OW("Binder", "null 使用默认联编");
                    m_Tools.TextText_OW("Object[]", "参数");
                    m_Tools.TextText_OW("CultureInfo", "");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("Assembly ");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("Assembly.Load(”程序集名称“).CreateInstance（”命名空间.类名称“）");

                m_Tools.Text_H("Assembly.GetExecutingAssembly().GetName() -> ", "获得程序集名称".AddLightBlue());


            });
        }


        private static readonly string EEnumStr = "E枚举".AddYellow();
        private static readonly string EenumTypeStr = "enumType".AddBlue();


        private void DrawEnumType()                              // 枚举反射例子
        {
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("public enum ", EEnumStr, "                  ->  作为例子".AddHui());
                m_Tools.Text_L("{");
                m_Tools.Text_L("      [Header(“枚举分量 1”)]");
                m_Tools.Text_L("      Enum1，");
                m_Tools.Text_L("      [Header(“枚举分量 2”)]");
                m_Tools.Text_L("      Enum2，");
                m_Tools.Text_L("}");
            });
            AddSpace_3();
            m_Tools.BiaoTi_O("例子1. 遍历枚举每一个分量，然后实例化");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("foreach (", EEnumStr, " type in Enum.GetValues(typeof(", EEnumStr, ")))", " // 可换成 GetNames".AddGreen());
                m_Tools.Text_H("{");
                m_Tools.Text_H("    AssemblyName assName = Assembly.GetExecutingAssembly().GetName()");
                m_Tools.Text_H("    Assembly.Load(assName).CreateInstance(type.ToString())");
                m_Tools.Text_H("}");
            });
            m_Tools.BiaoTi_O("例子2. 找到每个分量中的 特性 Header 名称");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Type ", EenumTypeStr, " = typeof(", EEnumStr, ");");
                m_Tools.Text_H("foreach (string enumName in Enum.GetNames(", EenumTypeStr, "))");
                m_Tools.Text_H("{");
                m_Tools.Text_H("     FieldInfo eachfield = ", EenumTypeStr, ".GetField(enumName);");
                m_Tools.Text_H("     HeaderAttribute att = eachfield.GetAttribute<HeaderAttribute>();");
                m_Tools.Text_H("}");

            });


        }


        private void DrawType()                                 // Type
        {
            MyCreate.PropertiesWindow(() =>
            {
                m_Tools.BiaoTi_B("获取信息");
                m_Tools.Text_Y("Namespace", "命名空间   ".AddHui(), "Name", "名称   ".AddHui(), "FullName", "命名空间.名称".AddHui());
                m_Tools.Method_YG("BaseType", "", "获取继承的类型" + "（父类Type）".AddWhite(), "Type", -40);
                m_Tools.BiaoTi_B("判断是什么");
                m_Tools.Text_Y("IsInterface", "是否接口   ".AddHui(), "IsClass", "是否类   ".AddHui(), "IsAbstract", "是否抽象类".AddHui());
                m_Tools.Text_Y("IsEnum", "是否枚举  ".AddHui(), "IsArray", "是否数组  ".AddHui(), "IsPrimitive", "是否基本类型".AddHui() + "(int等)".AddLightGreen());
                m_Tools.BiaoTi_B("判断封闭性");
                m_Tools.Text_Y("IsNotPublic", "是否不是公开的  ".AddHui(), "IsPublic", "是否公开  ".AddHui(), "IsSealed", "是否密封".AddHui());
            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_YG("GetCustomAttributes", "bool", "所有特性" + "（true 父类也搜索）".AddGreen().AddSize(12), "object[]");
                m_Tools.BiaoTi_B("通过名字获取" + "(可用 BindingFlags改变搜索类型)".AddLightBlue() + "/获取全部");
                m_Tools.Method_YG("GetEvent", "string 名字,BindingFlags 搜索类型", "获取事件", "EventInfo", ref isGetEvent, () =>
                {
                    m_Tools.Method_YG(ZhongZai + "GetEvents", "BindingFlags", "所有事件", "EventInfo[]", 70);
                }, 70);
                m_Tools.Method_YG("GetMember", "string ,BindingFlags", "获取成员", "MemberInfo", ref isGetMember, () =>
                {
                    MyCreate.TextCenter("1.属性是指 {get set} ， 成员是指字段 + 属性 + 方法的抽象");
                    MyCreate.TextCenter("2.FieldInfo、PropertyInfo、MethodInfo 都是继承 MemberInfo");
                    m_Tools.Method_BY(ZhongZai + "GetMembers", "BindingFlags", "所有成员", "MemberInfo[]", 70);

                }, 70);
                m_Tools.Method_YG("GetField", "string ,BindingFlags", "获取字段", "FieldInfo", ref isGetField, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "GetFields", "BindingFlags", "所有字段", "FieldInfo[]", 70);

                }, 70);
                m_Tools.Method_YG("GetProperty", "string ,BindingFlags", "获取属性", "PropertyInfo", ref isGetProperty, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "GetProperty", "string ,Type 返回类型", "指定返回类型", "PropertyInfo", 70);
                    m_Tools.Method_BY(ZhongZai + "GetPropertys", "BindingFlags", "所有属性", "PropertyInfo[]", 70);

                }, 70);

                m_Tools.Method_YG("GetMethod", "string ,BindingFlags", "获取方法", "MethodInfo", ref isGetMethod, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "GetMethod", "string ,Type[] 参数的类型", "指定参数类型", "MethodInfo", 70);
                    m_Tools.Method_BY(ZhongZai + "GetMethods", "BindingFlags", "所有方法", "MethodInfo[]", 70);

                }, 70);

            });

            AddSpace();
            m_Tools.ButtonText("BindingFlags （枚举）", "特定搜索那个" + "（使用了 [Flags]）".AddGreen(), ref isBindingFlags, () =>
            {
                m_Tools.TextText_BL("CreateInstance", "由反射创建的实例", -20);
                m_Tools.TextText_BL("Instance", "new 出来的实例", -20);
                m_Tools.TextText_BL("Default", "未定义任何标志的", -20);
                m_Tools.TextText_BL("IgnoreCase", "不应考虑成员名称的大小写", -20);
                m_Tools.TextText_BL("NonPublic", "非公共成员", -20);
                m_Tools.TextText_BL("Public", "公共成员", -20);
                m_Tools.TextText_BL("Static", "静态成员", -20);
            });
            AddSpace_3();
            m_Tools.ButtonText("MethodInfo", "GetMethod 获得", ref isMethodInfo, () =>
            {
                m_Tools.Text_Y("属性", ref isShu, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BL("IsAbstract", "");
                        m_Tools.TextText_BL("IsConstructor", "是否为构造函数");
                        m_Tools.TextText_BL("IsFinal", "");
                        m_Tools.TextText_BL("IsGenericMethod", "是否使用泛型");
                        m_Tools.TextText_BL("IsPrivate", "");
                        m_Tools.TextText_BL("IsPublic", "");
                        m_Tools.TextText_BL("IsStatic", "");
                        m_Tools.TextText_BL("IsVirtual", "");
                        m_Tools.TextText_BL("ReturnType", "获取返回类型");
                        m_Tools.TextText_BL("ReturnTypeCustomAttributes", "获取自定义属性");
                    });
                });
                m_Tools.Text_Y("方法");
                MyCreate.Box(() =>
                {
                    m_Tools.Method_BY("Invoke", "object 实例,object[] 参数", "调用方法或构造函数", "object", ref isInvoke, () =>
                    {
                        MyCreate.Box(() =>
                        {
                            m_Tools.TextText_LG("第一个参数 object 实例", "如果为 Static 方法就写 null");
                            m_Tools.TextText_LG("第二个参数 object[] 参数", "如果没有参数就写 null");
                            m_Tools.Text_L("返回值 object            " + "方法的返回值，如果为 void 返回 null".AddGreen());
                        });
                    }, 20);

                    m_Tools.Method_BY("GetParameters", "", "获取参数", "ParameterInfo[]", 20);
                    m_Tools.Method_BY("GetCustomAttributes", "bool", "特性，true 搜索继承链", "object[]", 20);
                });
            });

            AddSpace();
            m_Tools.ButtonText("FieldInfo", "GetField 获得", ref isFieldInfo, () =>
            {
                m_Tools.Text_Y("属性", ref isShu2, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_BL("IsFamily", "是否 protected");
                        m_Tools.TextText_BL("IsInitOnly", "是否只能在构造函数主体中设置");
                        m_Tools.TextText_BL("IsPrivate", "");
                        m_Tools.TextText_BL("IsPublic", "");
                        m_Tools.TextText_BL("IsStatic", "");
                    });
                });
                m_Tools.Text_Y("方法");
                MyCreate.Box(() =>
                {
                    m_Tools.Method_BY("GetCustomAttributes", "bool", "特性，true 搜索继承链", "object[]", 20);
                    m_Tools.Method_BY("", "", "", "", 20);


                });
            });
        }


        #endregion


        #region Static 工具类

        private void DrawConvert()                               // Convert
        {
            m_Tools.BiaoTi_B("Convert  转变" + "（除了 byte[]都能转）".AddGreen());
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.convert_methods.aspx");
            MyCreate.Text("使用 int 和 int.Parse() 作区别".AddLightBlue());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BY("int.Pares", "string," + "IFormatprovider/Numberstyles 可选参数".AddLightGreen(), "", "int");
                m_Tools.Text_H("    1. 只有 string 转成 int");
                m_Tools.Text_H("    2. string 格式非 int " + "报错".AddRed());
                m_Tools.Text_H("    3. null " + "报错".AddRed());
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Method_BY("Convert.ToInt32", "bool/byte/char/float/Decimal/..", "基本类型", "int");
                m_Tools.Method_BY("Convert.ToInt32", "string/Object/DateTime/枚举  ", "对象、枚举", "int");
                m_Tools.Method_BY("Convert.ToInt32", "string/Object,IFormatProvider", "可格式信息", "int");
                m_Tools.Text_H("    1. 可多种形式，如 传 float -> 取整数");
                m_Tools.Text_H("    2. 如果传 string ，格式非 int 同样" + "报错".AddRed());
                m_Tools.Text_H("    3. null 不会报错，返回 " + "0".AddGreen());
                m_Tools.Text_H("    4. 特殊如：枚举、时间、Object 都可以作为参数");
            });
        }

        private void DrawEncoding()                              // Encoding
        {
            m_Tools.BiaoTi_B("Encoding  字符编码" + "（抽象类 string <-> byte[]）".AddGreen());

            MyCreate.Text("有以下的子类，但都不常用，实际只要用 Encoding 抽象类即可");
            m_Tools.Text_W("ASCIIEncoding、UTF8Encoding、UnicodeEncoding ...");
            MyCreate.StaticPropertiesWindow(() =>
            {
                m_Tools.Text_L("UTF8、UTF7、Default、BigEndianUnicode、ASCII、Unicode、UTF32");
                m_Tools.Text_W("如： Encoding.UTF8 -> Encoding    获取 UTF-8 格式的编码");
            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_BY("GetString", "byte[]", "byte[] 转-> string", "string");
                m_Tools.Method_BY(ZhongZai + "GetString", "byte[]，int 字节偏移，int 总数", "string");
                m_Tools.Method_BY("GetBytes", "string", "string/char[] 转-> byte[]", "byte[]");
                m_Tools.Method_BY(ZhongZai + "GetBytes", "string，int，int，byte[] 结果,int 前面结果插入的索引", "", "int 实际字节数");
                m_Tools.Method_BY(ZhongZai + "GetBytes", "char[]", "", "byte[]");
                m_Tools.Method_BY(ZhongZai + "GetBytes", "char[]，int，int", "", "byte[]");
                m_Tools.Method_BY(ZhongZai + "GetBytes", "char[]，int，int，byte[] 结果,int 前面结果插入的索引", "", "int 实际字节数");
            });
        }


        private void DrawBitConverter()                          // BitConverter
        {

            m_Tools.BiaoTi_B("BitConverter  " + "（基数据类型 <-> byte[]）".AddGreen());

            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("这个转换是根据类型本身字节大小是大小转换的");
                m_Tools.Text_H("int cout =11 ");
                m_Tools.Text_H("BitConverter.GetBytes(cout)  -> 4 个字节的 byte[]  ", "//int 占4个字节".AddGreen());
                m_Tools.Text_H("Encoding.UTF8.GetBytes(”11“) -> 2 个字节的 byte[] ", "//根据字母个数".AddGreen());
            });

            m_Tools.Method_BL("GetBytes", "bool、char、double、uint、int、long、float", "", "byte[]");
            m_Tools.Method_BL("ToInt32/ToDouble/ToSingle", "byte[] 结果，int 结果起始位置", "", "int 实际字节数");
        }


        private void DrawStringBuilder()                         // StringBuilder
        {
            m_Tools.BiaoTi_B("StringBuilder  " + "（可变字符字符串）".AddGreen());
            MyCreate.StaticMethodWindow(() =>
            {
                MyCreate.Text("增加");
                m_Tools.Method_BY("Append", "基础类型", "", "StringBuilder");
                m_Tools.Method_BY("AppendLine", "string", "", "StringBuilder");
                m_Tools.Method_BY("Insert", "int 索引，基础类型", "插入", "StringBuilder");
                MyCreate.Text("删除");
                m_Tools.Method_BY("Remove", "int 索引，int 长度", "", "StringBuilder");

                MyCreate.Text("修改");
                m_Tools.Method_BY("Replace", "string 旧，string 新", "将旧代换成新的", "StringBuilder");
            });

        }



        #endregion


        #region 数据结构

        private void DrawShuJu()                              // 数据结构
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("List", QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/6sh2ey19(v=vs.110).aspx");
                    }
                    if (QUI.GhostButton("HashSet", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/bb359438(v=vs.110).aspx");

                    }
                    if (QUI.GhostButton("Dictionary", QColors.Color.Blue, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/xfhwa508(v=vs.110).aspx");
                    }
                    if (QUI.GhostButton("Hashtable", QColors.Color.Purple, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.collections.hashtable(v=vs.110).aspx");
                    }
                }
            });
            m_Tools.BiaoTi_B("对接口的实现的总结");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("1. 都实现了 ", "IEnumerable".AddWhite(), "(fooreach)、", "ICollection".AddWhite(), "（集合大小）");
                m_Tools.Text_G("2. 可以".AddHui(), "索引搜索取、插入操作：", "Array、List<T>、ArrayList".AddBlue());
                m_Tools.Text_G("3. ".AddHui(), "键/值对操作：", "Dictionary<K,V>、Hashtable".AddBlue());
                m_Tools.Text_H("4. 没有增(Add)删(Remove)，", "特殊增删取的集合：".AddGreen(), "Stack、Queue".AddBlue());
                m_Tools.Text_H("5. 孤儿，只有 ICollection<T> 增删包含，没有单取：", "HashSet<T>".AddBlue());
            });

            MyCreate.Box(() =>
            {
                m_Tools.Text("1. 不带泛型的都是使用" + " object ".AddGreen() + ",即类型可以任意");
                m_Tools.Text("2. " + "ICollection".AddHui() + " 与" + " ICollection<T> ".AddHui() + "有点特殊");
                m_Tools.Text_H("    ICollection 只表示集合大小，ICollection<T> 有大小还有增删改查");
                m_Tools.Text("3. 带 Hash 的表示使用 Hash 算法排序的，" + "不能用索引访问".AddGreen());
            });

            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_YL("[] 数组", "固定长度", -30);
                m_Tools.TextText_YL("ArrayList", "可重复", -30);
                m_Tools.TextText_YL("List<T>", "可重复", -30);
                m_Tools.TextText_YL("HashSet<T>", "不可重复,添加不报错但" + "忽略添加".AddGreen() + "，没有索引器", -30);
                m_Tools.TextText_YL("Dictionary<K,V>", "key 不可重复，添加" + "重复报错".AddRed() + "，取" + "[不存在]报错".AddRed(), -30);
                m_Tools.TextText_YL("Hashtable", "key 不可重复，添加" + "重复报错".AddRed() + "，取" + "[不存在] Null".AddGreen() + "，没有索引器", -30);
                m_Tools.TextText_YL("Stack、Stack<T>", "可重复，只对顶部作操作，堆栈式" + "（后进先出）".AddGreen(), -30);
                m_Tools.TextText_YL("Queue、Queue<T>", "可重复，只对顶部作操作，队列式" + "（先进先出）".AddGreen(), -30);
            });



            m_Tools.BiaoTi_B("各数据结构实现了那些接口：");
            m_Tools.BiaoTi_Y("ArrayList");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable，ICollection", "//fooreach + 集合大小", 160);
                m_Tools.TextText_OG("IList", "// 可以索引搜索取、插入操作", 60);
                m_Tools.TextText_LG("ICloneable", "// 可复制克隆的", 60);
            });
            m_Tools.BiaoTi_Y("List<T>");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable,IEnumerable<T>,ICollection,ICollection<T>", "//fooreach +集合大小", 160);
                m_Tools.TextText_OG("IList，IList<T>", "// 可以索引搜索取、插入操作", 60);
            });
            m_Tools.BiaoTi_Y("HashSet<T>");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable，IEnumerable<T>，ICollection<T>", "//fooreach + 集合大小", 160);
                m_Tools.TextText_LG("ISerializable，IDeserializationCallback", "// 自定义序列化", 60);
            });
            m_Tools.BiaoTi_Y("Dictionary<K，V> ");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable，IEnumerable<KeyValuePair<K, V>>", "//foreach", 160);
                m_Tools.TextText_HLG("ICollection，ICollection<KeyValuePair<K, V>>", "//集合大小", 160);
                m_Tools.TextText_OG("IDictionary，IDictionary<K, V>", "// 键/值对操作", 60);
                m_Tools.TextText_LG("ISerializable，IDeserializationCallback", "// 自定义序列化", 60);
            });

            m_Tools.BiaoTi_Y("Hashtable");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable, ICollection", "//fooreach + 集合大小", 160);
                m_Tools.TextText_OG("IDictionary", "// 键/值对操作", 60);
                m_Tools.TextText_LG("ICloneable", "// 可复制克隆的", 60);
                m_Tools.TextText_LG("ISerializable, IDeserializationCallback", "// 自定义序列化", 60);
            });

            m_Tools.BiaoTi_Y("Stack、Stack<T>、Queue、Queue<T>");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HLG("IEnumerable<T>, ICollection", "//fooreach + 集合大小", 160);
                m_Tools.TextText_LG("ICloneable", "// 可复制克隆的", 60);
            });


        }


        private void DrawIEnumerable()
        {
            MyCreate.AddSpace(20);

            MyCreate.Window("IEnumerable" + "（遍历）".AddGreen() + "与 IEnumerator" + "（一层一层、协程）".AddGreen(), () =>
            {
                m_Tools.TextText_BL("IEnumerable", "    接口" + "(I)".AddWhite() + "枚举" + "(Enumer)".AddWhite() + "可以遍历" + "(able)".AddWhite(), -50);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("1.要实现 foreach 就继承".AddYellow() + " IEnumerable".AddGreen());
                    MyCreate.Text("2.实际上主要是这个方法".AddYellow() + " public IEnumerator GetEnumerator() ".AddGreen());
                    MyCreate.Text("3.使用 ".AddYellow() + "yied return 想要返回的数据".AddGreen());
                    MyCreate.Text("4.使用 IEnumerable 的 ".AddYellow() + "LINQ查询".AddGreen());
                    LINQ();
                });
                m_Tools.TextText_BL("IEnumerator", "    接口" + "(I)".AddWhite() + "枚举" + "(Enumer)".AddWhite() + "一只" + "(ator)".AddWhite(), -50);
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("1. foreach 使用 yied return 一层一层地返回 IEnumerator => 动作".AddYellow());
                    MyCreate.Text("2. 协程类同 foreach ，也是 一层一层地返回 IEnumerator => 动作".AddYellow());
                });
            });
        }


        private void DrawArrayList()                             // ArrayList
        {
            AddSpace();
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("Array", QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.array(v=vs.110).aspx");
                    }
                    if (QUI.GhostButton("ArrayList", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.collections.arraylist(v=vs.110).aspx");
                    }
                }
            });
            m_Tools.BiaoTi_Y("Array");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("固定长度，实例化需要声明容量");
                m_Tools.Text_H("    1. 使用", " new".AddLightBlue(), " 声明容量:  ", "int[] a = new int[]".AddWhite());
                m_Tools.Text_H("    2. 使用", "{ }".AddLightBlue(), " 直接定义数据: ", "int[] a = ｛1，2，3｝".AddWhite());
            });
            MyCreate.StaticMethodWindow(() =>
            {
                m_Tools.Method_BL("Array.IndexOf", "Array，Object", "搜索指定对象，返回首个索引", "int");
                m_Tools.Method_BL(ZhongZai + "Array.IndexOf", "Array，Object，int 搜索的起始索引", "", "int");
            });

            AddSpace_15();
            m_Tools.BiaoTi_Y("ArrayList");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("存储 Object 实例任意类型，使用时要装箱与拆箱操作");
                m_Tools.Text_H("能使用 List<T> 就用 List<T> 啊，为啥要用这个？");
            });

        }


        private void DrawList()                                  // List
        {
            m_Tools.BiaoTi_B("构造函数 " + "(无参、另一IEnumerable<T>、声明开始容量)".AddGreen(), ref isConstructors, () =>
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
            m_Tools.BiaoTi_B("方法", true);
            MyCreate.Box(() =>
            {
                MyCreate.Text("添加".AddOrange());
                m_Tools.Method_BL("Add", "T", "在末尾处添加元素", "", 30);
                m_Tools.Method_BL("AddRange", "IEnumerable<T>", "在末尾处添加" + "一整组".AddOrange() + "元素", "", 30);
                m_Tools.Method_BL("Insert", "int，T", "在索引处" + "插入".AddOrange() + "一个元素", "", 30);
                m_Tools.Method_BL(ZhongZai + "Insert", "int，IEnumerable<T>", "在索引处插入一整组元素", "", 30);

                MyCreate.Text("删除".AddOrange());
                m_Tools.Method_BL("Clear", "", "删除所有元素", "", 30);
                m_Tools.Method_BL("Remove", "T", "删除一个元素", "", 30);
                m_Tools.Method_BL("RemoveAt", "int", "删除下标索引的元素", "", 30);
                m_Tools.Method_BL("RemoveRange", "int 索引,int 长度", "删除一整组对应长度的元素", "", 30);
                m_Tools.Method_BL("RemoveAll ", "Func<T,bool>", "删除" + "所有相匹配".AddOrange() + "的元素", "", 30);

                MyCreate.Text("判断、查找".AddYellow());
                m_Tools.Method_LW("Contains", "T", "是否包含这个元素", "bool", 30);
                m_Tools.Method_LW("BinarySearch", "T item", "二分法查找这个元素的索引", "int", ref isBinarySearch, () =>
                {
                    m_Tools.Method_LW(ZhongZai + "BinarySearch", "T ,IComparer<T>", "指定比较器查找索引", "int");
                    m_Tools.Method_LW(ZhongZai + "BinarySearch", "int 索引,int 长度,T ,IComparer<T>", "", "int");
                }, 30);

                MyCreate.Text("判断、查找".AddYellow() + "（带条件）".AddGreen());
                m_Tools.Method_LW("TrueForAll", "Func<T,bool>", "是否所有元素都符合这个" + LiJian, "bool", 30);
                m_Tools.Method_LW("FindIndex", "Func<T,bool>", "返回" + LiJian + "相匹配的" + "第一个索引".AddYellow(), "int", 30);
                m_Tools.Method_LW("FindLastIndex ", "Func<T,bool>", "返回" + LiJian + "相匹配的最后一个索引", "int", 30);
                m_Tools.Method_LW("Find", "Func<T,bool>", "返回" + LiJian + "相匹配的" + "第一个元素".AddYellow(), "T", ref isFind, () =>
                {
                    m_Tools.Method_LW("FindAll", "Func<T,bool>", "与 Where 类似", "T");
                }, 30);
                m_Tools.Method_LW("Where<T>", "Func<T, bool>", "返回" + LiJian + "相匹配的" + "所有元素".AddYellow(), "IEnumerable<T>", ref isWhere, () =>
                {
                    m_Tools.Method_LW("Where<T>", "Func<T,int, bool>", "", "IEnumerable<T>");
                    m_Tools.Text_G("第二个参数为源元素的索引，第三个参数为返回值");
                }, 30);

                MyCreate.Text("排序、反转");
                m_Tools.Method("Sort".AddBlue(), "", "使用默认比较器按" + "从小到大排序".AddGreen(), "", 80);
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_G("按字符串长度来排序");
                    m_Tools.Text_H("list.Sort((str1, str2) =>");
                    m_Tools.Text_H(" {");
                    m_Tools.Text_H("      return str1.Length - str2.Length;");
                    m_Tools.Text_H("  });");
                });
                m_Tools.Method(ZhongZai + "Sort".AddBlue(), "(Comparer<T>)".AddHuiSize(11), "使用指定比较器排序", "", 80);
                m_Tools.Method(ZhongZai + "Sort".AddBlue(), "(IComparer<T>)".AddHuiSize(11), "同上", "", 80);
                m_Tools.Method(ZhongZai + "Sort".AddBlue(), "(int 索引,int 长度,IComparer<T>)".AddHuiSize(11), "使用指定比较器区域排序", "", 80);


                m_Tools.Method("Reverse".AddBlue(), "", "将集合" + "反转".AddGreen(), "", 80);

                MyCreate.Text("获取");
                m_Tools.Method("AsReadOnly".AddBlue(), "", "获得" + "只读集合".AddGreen(), "ReadOnlyCollection<T>", 80);
                m_Tools.Method("Take".AddBlue(), "(int n)".AddHuiSize(11), " 获得前 n 行", "IEnumetable<T>", 80);
            });
            AddSpace();
        }


        private void DrawHashSet()                               // HashSet<T>
        {
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_G("只是用来存储数据！没有单一取数据的！");
                m_Tools.Text_G("用来存储集合、集运算、大数据查询使用 HashSet");
            });

            m_Tools.BiaoTi_O("方法");
            MyCreate.Box(() =>
            {
                MyCreate.Text("增删查".AddLightBlue());
                m_Tools.Method_BL("Add", "T", "重复添加返回 false", "bool", 40);
                m_Tools.Method_BL("Remove", "T", "成功找到并移除该元素返回 true", "bool", 40);
                m_Tools.Text_B("Clear", "清除所有元素".AddLightBlue(), "          Contains(T)", "是否包含".AddLightBlue());

                MyCreate.Text("两集合运算".AddYellow());
                m_Tools.Method_BY("IntersectWith", "IEnumerable<T>", "修改当前 HashSet<T>,元素只剩".AddWhite() + "交集", "", 40);
                m_Tools.Method_BY("UnionWith", "IEnumerable<T>", "修改当前 HashSet<T>,元素增加".AddWhite() + "并集", "", 40);
                m_Tools.Method_BW("ExceptWith ", "IEnumerable<T>", "修改当前 HashSet<T>,元素" + "排除".AddYellow() + "另集合的元素", "", 40);

                MyCreate.Text("两集合判断".AddLightBlue());
                m_Tools.Method_BL("IsProperSubsetOf", "IEnumerable<T>", "是否为指定集合的真子集", "bool", 60);
                m_Tools.Method_BL("IsProperSupersetOf", "IEnumerable<T>", "是否为指定集合的真超集", "bool", 60);
                m_Tools.Method_BL("IsSubsetOf", "IEnumerable<T>", "是否为指定集合的子集", "bool", 60);
                m_Tools.Method_BL("IsSupersetOf", "IEnumerable<T>", "是否为指定集合的超集", "bool", 60);
            });
            AddSpace();
            m_Tools.BiaoTi_O("为什么要用 HashSet<T> 而不使用 List<T> 的情况：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("■ HashSet<T> 是高性能集合，", "检索性能".AddGreen(), "（" + "如 Contains".AddWhite(), "）比 List<T> ", "强很多".AddGreen());
                m_Tools.Text_W("   List 数据量越大速度越巨慢，而 HashSet " + "不受数据量的影响".AddGreen());
                m_Tools.Text_H("■ HashSet 没有索引器，在单独元素访问上，有很大的限制");
                m_Tools.Text_H("■ HashSet 用来" + "存储集合".AddGreen() + "，非单独索引排列集合");
                m_Tools.Text_H("■ 可做" + "高性能两个集合运算".AddGreen() + "，例如两个集合", "求交集、并集、差集".AddGreen());
            });
            AddSpace();


        }



        private void DrawDic()                                  // 键值对集合
        {
            MyCreate.Window("键/值对：Dictionary<K,V>、Hashtable", () =>
            {
                m_Tools.Text_Y("▪ " + "Dictionary<T,T>".AddHui(), " 定死泛型的，而 ", "Hashtable".AddHui(), " 使用 " + "Object".AddGreen());
                AddSpace();
                m_Tools.Text_Y("▪ " + "dic".AddHui(), "[不存在] -> ", "报错".AddRed(), "，" + "hashtable".AddHui(), "[不存在] -> " + "null".AddGreen());
                AddSpace();
                m_Tools.Text_Y("▪ foreach 时 ", "Dictionary".AddHui(), " 是按照添加进入的元素进行排序");
                m_Tools.Text_Y("   而 ", "Hashtable ".AddHui(), "是按照 key 中 的 hashcode 来查找的");
                AddSpace();
                m_Tools.Text_Y("▪ ", "Dictionary".AddHui(), " 继承IEnumerable<T>，拥有其扩展方法");
            });


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
                    m_Tools.Method_YG("TryGetValue", "K,out V", "通过key获取value，没有不报错", "bool");

                    m_Tools.Text_G("继承 IEnumerable<T>，都有它的扩展方法");

                });
            }, -60);

            AddSpace_3();

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
                    m_Tools.Method_YG("Add", "Object,Object", "添加");
                    m_Tools.Method_YG("Remove", "Object key", "根据 key 来删除");
                    m_Tools.Method_YG("ContainsKey", "Object key", "key 是否包含");
                    m_Tools.Method_YG("ContainsValue", "Object Value", "Value 是否包含");

                });
            }, -60);



        }

        private void DrawStack()                                 // Stack、Queue
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("Stack<T>", QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/3278tedw(v=vs.110).aspx");
                    }
                    if (QUI.GhostButton("Queue<T>", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/7977ey2c(v=vs.110).aspx");
                    }
                }
            });

            AddSpace_3();
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("Stack 和 Queue 能带泛型，或者不带（使用 Object）");
                m_Tools.Text_H("没有索引操作，没有任何索引器，只能对顶部进行操作");
                m_Tools.TextText_BL("Stack 堆栈", "后进先出，就是网页浏览器一样");
                m_Tools.TextText_BL("Queue 队列", "先进先出，就是隧道一样");
            });

            m_Tools.BiaoTi_Y("Stack<T>");
            MyCreate.Box(() =>
            {
                MyCreate.Text("添加".AddGreen());
                m_Tools.Method_BL("Push", "", "在" + "顶部".AddGreen() + "放一个元素", "", -50);
                MyCreate.Text("删除".AddGreen());
                m_Tools.Method_BL("Pop", "", "删除" + "顶部".AddGreen() + "元素,返回删除的元素", "T", -50);

            });
            m_Tools.BiaoTi_Y("Queue<T>");
            MyCreate.Box(() =>
            {
                MyCreate.Text("添加".AddGreen());
                m_Tools.Method_BL("Enqueue", "", "在" + "顶部".AddGreen() + "放一个元素", "", -50);
                MyCreate.Text("删除".AddGreen());
                m_Tools.Method_BL("Dequeue", "", "删除" + "尾部".AddGreen() + "元素,返回删除的元素", "object", -50);
            });
            m_Tools.BiaoTi_Y("两个相同的操作");
            MyCreate.Box(() =>
            {
                MyCreate.Text("查");
                m_Tools.Method_YG("Peek", "", "查询" + "顶部".AddGreen() + "的元素", "T", -50);
                MyCreate.Text("其他");
                m_Tools.Text_Y("foreach、Contains、Clear、Clone");
            });

        }





        #endregion


        #region IO 操作


        private void DrawIO()
        {
            MyCreate.Heng(() =>
            {
                MyCreate.AddSpace();
                if (QUI.GhostButton("官方文档", QColors.Color.Orange, 80, 20, editStats.target))
                {
                    editStats.target = !editStats.target;
                }
                if (editStats.faded > 0.05f)
                {
                    if (QUI.GhostButton("File", QColors.Color.Green, PS.databaseClearStatisticsButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.io.file.aspx");
                    }
                    if (QUI.GhostButton("Directory", QColors.Color.Gray, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.io.directory(v=vs.110).aspx");

                    }
                    if (QUI.GhostButton("FileInfo", QColors.Color.Blue, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.io.fileinfo(v=vs.110).aspx");
                    }
                    if (QUI.GhostButton("DirectoryInfo", QColors.Color.Purple, PS.databaseDeleteButtonWidth * editStats.faded, 20))
                    {
                        Application.OpenURL("https://msdn.microsoft.com/zh-cn/library/system.io.directoryinfo(v=vs.110).aspx");
                    }
                }
            });

            m_Tools.BiaoTi_B("工具类：" + "File、Directory、Path".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("File  文件 工具类".AddYellow());
                m_Tools.Text_H("创建文件、复制、移动、文件是否存在、删除文件、打开文件读/写");

                MyCreate.Text("Directory  文件夹 工具类".AddYellow());
                m_Tools.Text_H("创建文件夹、文件夹是否存在、删除文件夹、获得文件夹下文件/子文件夹的名");

                MyCreate.Text("Path  路径 工具类".AddYellow());
                m_Tools.Text_H("合成路径string、获得路径的文件名/扩展名/全路径名/上一级文件夹名/根目录");

            });
            AddSpace_15();
            m_Tools.BiaoTi_B("实例对象：" + "FileSystemInfo、FileInfo、DirectoryInfo".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("FileSystemInfo(抽象类) 衍生-> FileInfo、DirectoryInfo");
                m_Tools.TextText_BL("FileInfo", "文件 实例类，一个对象代表一个文件", -50);
                MyCreate.Box(() =>
                {
                    MyCreate.Text("属性：");
                    m_Tools.Text_W("扩展名、大小、是否只读、写入时间、一系列名称、父文件夹实例");
                    MyCreate.Text("方法：");
                    m_Tools.Text_W("创建、删除、复制、移动、写文本、打开文件读/写");
                });
                m_Tools.TextText_BL("DirectoryInfo", "文件夹 实例类，一个对象代表一个文件夹", -50);
                MyCreate.Box(() =>
                {
                    MyCreate.Text("属性：");
                    m_Tools.Text_W("一系列名称、写入时间、父文件夹实例");
                    MyCreate.Text("方法：");
                    m_Tools.Text_W("创建、删除、移动、获取此文件夹下所有文件/文件夹的实例对象");
                });


            });


        }

        private void DrawFile()                                  // File
        {
            m_Tools.BiaoTi_O("File " + "(文件工具类)".AddGreen());
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.file.aspx");
            MyCreate.StaticMethodWindow(() =>
            {
                MyCreate.Text("创建");
                m_Tools.Method_BY("Create", "string 全路径", "创建或覆盖文件", "FileStream", ref isCreate, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "Create", "string，int，FileOptions 如何覆盖文件", "");
                    m_Tools.Method_BY(ZhongZai + "Create", "string，int，FileOptions，FileSecurity 确定文件的访问控制", "");
                });
                m_Tools.Method_BY("CreateText", "string", "创建或打开UTF-8格式的文件", "StreamWriter");

                m_Tools.Method_BY("Copy", "string,string", "目标文件不能是一个目录或现有文件", "");
                m_Tools.Method_BY(ZhongZai + "Copy", "string 复制文件，string 目标文件，bool 能否覆盖", "", "");
                MyCreate.Box(() =>
                {
                    m_Tools.Text_G("1. true: 可以覆盖目标文件,反之为 false");
                    m_Tools.Text_G("2. 不添加 bool 默认 false");
                });

                m_Tools.Method_BY("Move", "string 移动文件，string 目标文件", "");

                MyCreate.Text("判断");
                m_Tools.Method_BY("Exists", "string", "文件是否存在", "bool");

                MyCreate.Text("删除");
                m_Tools.Method_BY("Delete", "string", "");

                MyCreate.Text("打开单一文件");
                m_Tools.Method_BY("Open", "string，FileMode 枚举", "打开文件", "FileStream", 10);
                m_Tools.Method_BY("OpenRead", "string", "打开文件只读", "FileStream", 10);
                m_Tools.Method_BY("OpenWrite", "string", "打开文件写入", "FileStream", 10);
                m_Tools.Method_BY("OpenText", "string", "UTF-8 格式的文件进行读取", "StreamReader", 10);


            });
        }

        private void DrawDirectory()                             // Directory
        {
            m_Tools.BiaoTi_O("Directory " + "文件夹工具类".AddGreen());
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.directory(v=vs.110).aspx");
            m_Tools.BiaoTi_B("Static Methods");
            MyCreate.Box(() =>
            {
                MyCreate.Text("创建");
                m_Tools.Method_BY("CreateDirectory", "string", "", "DirectoryInfo");
                m_Tools.Method_BY("Move", "string 旧路径,string 新路径", "");
                MyCreate.Text("判断");
                m_Tools.Method_BY("Exists", "string", "", "bool");
                MyCreate.Text("删除");
                m_Tools.Method_BY("Delete", "string", "默认false，不能删除空目录");
                m_Tools.Method_BY(ZhongZai + "Delete", "string,bool", "true：能删除子目录和文件");
                MyCreate.Text("获得");
                m_Tools.Method_BY("GetDirectories", "string", "此目录下所有子目录" + "(重载有选择)".AddGreen(), "string[]", ref isGetDirectories, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "GetDirectories", "string,string 目录的名称匹配的搜索字符串,非正则", "", "string[]");
                    m_Tools.Method_BY(ZhongZai + "GetDirectories", "string，string，SearchOption 搜索枚举", "", "string[]");
                }, 30);
                m_Tools.Method_BY("GetFiles", "string", "此目录下所有文件" + "(重载有选择)".AddGreen(), "string[]", ref isGetFiles, () =>
                {
                    m_Tools.Method_BY(ZhongZai + "GetFiles", "string,string 文件的名称匹配的搜索字符串,非正则", "", "string[]");
                    m_Tools.Method_BY(ZhongZai + "GetFiles", "string，string，SearchOption 搜索枚举", "", "string[]");
                }, 30);

                m_Tools.Method_BY("GetFileSystemEntries", "string", "所有文件和子目录" + "(重载相同上)".AddGreen(), "string[]", 30);

            });
            AddSpace();
            m_Tools.BiaoTi_B("例子");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("获得所有文件名,包含子文件夹下的文件名：");
                m_Tools.Text_H("Directory.GetFiles(path，\" * \"，SearchOption.AllDirectories)");
                AddSpace_3();
                MyCreate.Text("获得当前目录的所有 .exe 文件名");
                m_Tools.Text_H("Directory.GetFiles(path，“*.exe”)");

            });

        }


        private void DrawPath()                                  // Path
        {
            m_Tools.BiaoTi_O("Path " + "(包含文件或目录路径信息 string 操作工具类)".AddGreen());
            MyCreate.Text("操作");
            m_Tools.Method_BY("Combine", "params string[]", "合成一个路径", "string", 60);
            AddSpace_3();
            MyCreate.Text("获得信息");
            m_Tools.Method_BL("GetDirectoryName", "string 路径", "获得上一级的文件夹路径", "string", 60);
            m_Tools.Method_BL("GetFileName", "", "文件名+扩展名", "string", 60);
            m_Tools.Method_BL("GetRandomFileName", "", "随机文件夹或文件名", "string", 60);
            m_Tools.Method_BL("GetFileNameWithoutExtension", "", "文件名", "string", 60);
            m_Tools.Method_BL("GetFullPath", "", "全路径", "string", 60);
            AddSpace_3();
            MyCreate.Text("扩展名的操作" + "( .jpg)".AddGreen());
            m_Tools.Method_BY("HasExtension", "string 路径", "是否有扩展名", "bool", 60);
            m_Tools.Method_BY("GetExtension", "string 路径", "获得扩展名" + "(带 .)".AddGreen(), "string", 60);
            m_Tools.Method_BY("ChangeExtension", "string 路径,string", "更改路径的扩展名", "string", 60);
            AddSpace_3();
            MyCreate.Text("根目录的操作" + "( C:\\\\ )".AddGreen());
            m_Tools.Method_BY("IsPathRooted", "string", "是否包含根目录", "bool", 60);
            m_Tools.Method_BY("GetPathRoot", "stringg", "获得根目录 ", "string", 60);

        }

        private void DrawShiLi()                                 // 实例对象
        {
            m_Tools.BiaoTi_O("FileSystemInfo" + "（抽象类,FileInfo、DirectoryInfo 的父类）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.Text_L("属性包含：".AddBlue(), "完整名称、创建时间、写入时间、扩展名等");
                m_Tools.Text_L("方法包含：".AddBlue(), "删除", "Delete".AddHui(), "、刷新" + "Refresh".AddHui(), " 等");
            });

            AddSpace();
            m_Tools.BiaoTi_O("FileInfo" + "（文件实例类）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.fileinfo(v=vs.110).aspx");
                m_Tools.Text_G("构造：".AddGreen(), "new FileInfo(路径)".AddHui(), "，不存在不会创建,不会报错");
                m_Tools.Text_Y("属性".AddGreen(), ":是否存在", "Exists".AddHui(), "、扩展名", "Extension".AddHui(), "、父目录实例", "Directory".AddHui());
                m_Tools.Text_Y("       文件大小", "Length".AddHui(), "、是否只读" + "IsReadOnly".AddHui());
                MyCreate.MethodWindow(() =>
                {
                    MyCreate.Text("基本操作");
                    m_Tools.Text_Y("创建", "Create".AddHui(), "、删除", "Delete".AddHui(), "、复制", "CopyTo".AddHui(), "、移动", "MoveTo".AddHui());
                    MyCreate.Text("针对文本的");
                    m_Tools.Method_BY("CreateText", "", "追加写入文本", "StreamWriter");
                    m_Tools.Method_BY("AppendText", "", "创建写入新文本", "StreamWriter");
                    m_Tools.Method_BY("OpenText", "", "读取 UTF8 格式的文本", "StreamReader");
                });
            });
            AddSpace();
            m_Tools.BiaoTi_O("DirectoryInfo" + "（文件夹实例类）".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.directoryinfo(v=vs.110).aspx");
                m_Tools.Text_G("构造：".AddGreen(), "new DirectoryInfo(路径)".AddHui(), "，不存在不会创建,不会报错");
                m_Tools.Text_Y("属性".AddGreen(), ":是否存在", "Exists".AddHui(), "、父目录实例", "Directory".AddHui());
                MyCreate.MethodWindow(() =>
                {
                    MyCreate.Text("基本操作");
                    m_Tools.Text_Y("创建", "Create".AddHui(), "、删除", "Delete".AddHui(), "、移动", "MoveTo".AddHui());
                    MyCreate.Text("获取");
                    m_Tools.Method_BY("GetFiles", "", "此目录下所有文件", "FileInfo[]", ref isGetFiles, () =>
                    {
                        m_Tools.Text_G("GetFiles（“*.exe”） 搜索所有带exe的文件");
                        m_Tools.Method_BY("GetFiles", "string 文件的名称匹配的搜索字符串,非正则", "", "FileInfo[]");
                        m_Tools.Method_BY("GetFiles", "string，SearchOption 搜索枚举", "", "FileInfo[]");
                    });
                    m_Tools.Method_BY("GetDirectories", "", "此目录下所有子目录", "DirectoryInfo[]", ref isGetDirectories, () =>
                    {
                        m_Tools.Method_BY("GetDirectories", "string 目录的名称匹配的搜索字符串,非正则", "", "DirectoryInfo[]");
                        m_Tools.Method_BY("GetDirectories", "string，SearchOption 搜索枚举", "", "DirectoryInfo[]");
                    });
                    m_Tools.Method_BY("GetFileSystemInfos", "string", "所有文件和子目录", "FileSystemInfo[]");

                });
            });

        }


        private void DrawEnum()                                  // 用到的枚举
        {
            m_Tools.BiaoTi_B("FileMode " + "(指定打开文件的方式)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_BL("Append", "追加");
                m_Tools.TextText_BL("Create", "会覆盖旧文件");
                m_Tools.TextText_BL("CreateNew", "创建一个新的文件");
                m_Tools.TextText_BL("Open", "打开现有文件");
                m_Tools.TextText_BL("OpenOrCreate", "存在创建一个新文件");
            });
            AddSpace();
            m_Tools.BiaoTi_B("SearchOption " + "(指定是否搜索当前目录中，或当前目录和所有子目录)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.TextText_LW("AllDirectories", "当前目录及其所有的子目录", 10);
                m_Tools.TextText_LW("TopDirectoryOnly", "仅当前目录", 10);
            });
            AddSpace();
        }

        private void DrawXieRu()                                 // 写入读取流
        {

            m_Tools.BiaoTi_O("流操作，要不使用在 " + "using".AddGreen() + " 上，要不使用 " + "Flush() + Close()".AddGreen());
            m_Tools.BiaoTi_B("StreamWriter " + "(写入流)".AddGreen());
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.streamwriter(v=vs.110).aspx");
                m_Tools.BiaoTi_L("方法 " + "(任意类型：string、bool、int、float等都可以)".AddHui());
                MyCreate.MethodWindow(() =>
                {
                    m_Tools.Method_BL("Write", "任意类型", "跟着写", "", 10);
                    m_Tools.Method_BL("WriteLine", "任意类型", "写一行", "", 10);
                });
            });
            AddSpace();
            m_Tools.BiaoTi_B("StreamReader " + "(读取流)");
            MyCreate.Box(() =>
            {
                m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.io.streamreader(v=vs.110).aspx");
                m_Tools.Text_G("下个到末尾返回 -1");
                m_Tools.Method_BY("Peek", "", "下一个可用字符不会移动", "int");
                m_Tools.Method_BY("Read", "", "下一个字符并使移动位置到这个字符", "int");
                m_Tools.Text_G("下个到末尾返回 null");
                m_Tools.Method_BY("ReadLine", "", "输入流中的下一行", "string");
                m_Tools.Text_G("读到尾");
                m_Tools.Method_BY("ReadToEnd", "", "从当前位置到结尾", "string");
                m_Tools.Text_G("常规操作读取：");
                m_Tools.Text_H("string tmp;");
                m_Tools.Text_H("while ((tmp = sr.ReadLine()) != null)");
            });

            AddSpace_15();
            m_Tools.BiaoTi_O("Stream " + "(抽象类) -> FileStream、MemoryStream 衍生类".AddGreen());
            AddSpace();
            m_Tools.BiaoTi_L("例子：");
            MyCreate.Box_Hei(() =>
            {

            });

        }



        #endregion


        #region 线程


        private void DrawThread()                                // Thread
        {
            m_Tools.BiaoTi_O("Thread 类 " + "（创建和控制线程，设置其优先级并获取其状态）".AddGreen());
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.threading.thread(v=vs.110).aspx");
            m_Tools.BiaoTi_B("构造函数：");
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("▪ new Thread(Action 方法名)");
                m_Tools.Text_H("▪ new Thread(Action 方法名，int 最大堆栈)");
                m_Tools.Text_H("▪ new Thread(Action<Object> 也是方法名即可) -> Start(Object)开启", ref isThread, () =>
                {
                    MyCreate.Box(() =>
                    {
                        m_Tools.TextText_LG("Thread t = new Thread(E_Thread2Do)", "// 也是用方法名即可", 55);
                        m_Tools.TextText_LG("t.Start(obj参数)", "// 开启线程，参数在这里传", 55);

                        AddSpace();
                        m_Tools.Text_H("private void E_Thread2Do(object obj)  -> 带一个参数的方法");
                    });
                });
            });
            m_Tools.BiaoTi_B("属性、方法：");
            MyCreate.Box(() =>
            {
                MyCreate.Text("属性：");
                m_Tools.Method_BW("Priority", "", "优先级，越高越优先", "ThreadPriority", -30);
                m_Tools.Method_BW("Priority", "", "当前线程状态", "ThreadState", ref isThreadState, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        MyCreate.Text("当调用 Start 方法后，线程 -> 准备状态：");
                        m_Tools.TextText_OL("Unstarted", "准备，未开启状态", -10);
                        MyCreate.Text("当操作系统的线程调度器选择了要运行这个线程，线程 -> 运行状态");
                        m_Tools.TextText_OL("Running", "启动、运行状态", -10);
                        MyCreate.Text("当使用 Thread.Sleep() / Thread.Join() 方法后，线程 -> 休眠状态");
                        m_Tools.TextText_OL("WaitSleepJoin", "线程将受阻", -10);
                        MyCreate.Text("线程结束");
                        m_Tools.TextText_OL("Stopped", "该线程已停止", -10);
                        MyCreate.Text("其他状态：");
                        m_Tools.TextText_OL("Background", "作为后台线程而不是一个前台线程正在执行", -10);

                    });
                }, -30);
                m_Tools.Method_BW("IsBackground", "", "是否为后台线程" + "(默认前台)".AddGreen(), "", -30);
                MyCreate.Text("实例方法：");
                m_Tools.Method_BL("Start() / Start(object)", "", "开启线程", "", -10);
                m_Tools.Method_BL("Abort() / Abort(object)", "", "中止线程" + "并直接崩个错".AddRed() + "(try catch捕获)", "", -10);
                MyCreate.Text("static 方法：");
                m_Tools.Method_YL("Sleep", "int 毫秒数", "当前线程挂起", "", -10);
            });
            AddSpace();
            m_Tools.BiaoTi_O("后台线程 和 前台线程" + "(不是指 UI线程 与 后台)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_Y("前台线程：", "直接创建出来的 Thread 都是前台线程".AddHui());
                m_Tools.Text_Y("后台线程：", "thread.IsBackground = true -> 设置为后台线程".AddHui());
                MyCreate.Text("当 Main 结束，应用程序的进程仍然运行的，直到所有前台线程完成任务为止".AddRed());
                MyCreate.Text("当所有的前台线程运行完毕，所有后台线程即使没完成，也会中止掉".AddRed());
            });
            AddSpace();
            m_Tools.BiaoTi_O("线程争用问题  锁");
            MyCreate.Box(() =>
            {
                m_Tools.Text_H("就是 2 个以上的线程开启同一个方法 -> 出现争用问题");
                m_Tools.Text_Y("使用关键字 lock（引用对象）");

            });
        }

        private void DrawThreadPool()                            // 线程池
        {

            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.threading.threadpool(v=vs.110).aspx");
            m_Tools.BiaoTi_O("ThreadPool 工具类" + "(系统提供的线程池管理类)".AddGreen());
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L("创建线程需要时间，线程池 与 对象池意义相同");
                m_Tools.Text_H("ThreadPool:会在需要时增减池中线程的线程数,直到达到最大的线程数");
                m_Tools.Text_H("▪ 池中的最大线程数是可配置的");
                m_Tools.Text_H("▪ 通过线程池创建出来的线程默认 后台线程");
            });

            m_Tools.BiaoTi_B("例子：");
            MyCreate.Box_Hei(() =>
            {
                MyCreate.Text("DoThreadMethod 开启线程的方法");
                m_Tools.Text_H("private void DoThreadMethod1(object obj){  ...//线程1要做什么 }");
                m_Tools.Text_H("private void DoThreadMethod2(object obj){  ...//线程2要做什么 }");
                AddSpace();
                MyCreate.Text("Main -> 使用线程池开启多个");
                m_Tools.Text_L("ThreadPool.QueueUserWorkItem(DoThreadMethod1);");
                m_Tools.Text_L("ThreadPool.QueueUserWorkItem(DoThreadMethod2);");
                m_Tools.Text_G("// 就这样就可以了，已经创建了两个后台线程");
            });
            m_Tools.BiaoTi_B("Static 方法：");
            MyCreate.Box(() =>
            {
                m_Tools.Method_BY("QueueUserWorkItem", "方法名", "将方法排入队列执行", "bool true 此方法成功排队");
            });
            AddSpace();
            m_Tools.BiaoTi_B("使用线程池需要注意的事项：");
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("1. 线程池中都是", "后台线程".AddRed(), "(所有前台线程都结束了,所有后台线程就会停止)");
                m_Tools.Text_G("2. ", "不能".AddRed(), "把入池的线程改为前台线程");
                m_Tools.Text_G("3. ", "不能".AddRed(), "给入池的线程设置优先级或名称");
                m_Tools.Text_G("4. 入池的线程只能用于", "时间较短".AddRed(), "的任务(如一直运行，还是new个Thread 吧)");

            });

        }


        private void DrawSemaphore()                             // Semaphore
        {
            m_Tools.BiaoTi_O("Semaphore 类 " + "（限制可同时访问某一资源或资源池的线程数）".AddGreen());
            m_Tools.GuangFangWenDan("https://msdn.microsoft.com/zh-cn/library/system.threading.semaphore(v=vs.110).aspx");
            MyCreate.GouZaoWindow(() =>
            {
                m_Tools.Text_B("new Semaphore(int 初始请求数，int 最大请求数)");

            });
            MyCreate.MethodWindow(() =>
            {
                m_Tools.Method_BL("WaitOne", "", "限制线程的访问", "");
            });


        }

        #endregion



    }

}











