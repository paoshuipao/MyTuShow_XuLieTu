using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using UnityEngine;

namespace UnityEditor
{
    public class Language_Lua : AbstractKuang<Language_Lua>
    {
        protected override void OnEditorGUI()
        {
            DrawNo();
            DrawWeb();
            DrawZero();
            DrawBianLiang();
            DrawYuJu();
            DrawTable();
            DrawMethod();
            DrawTableMethods();
            DrawString();
            DrawOPP();
            m_Tools.BiaoTi_O("8.一个类怎么样调用其他的类", true);
            MyCreate.Box_Hei(() =>
            {
                m_Tools.TextText_HG("Require( Common/define )","// 不同级的要用分隔");
            });
        }

         
        private void DrawNo()                                    // 总结
        {
            m_Tools.BiaoTi_O("总结");
            MyCreate.Box(() =>
            { 
                m_Tools.Text_Y("null 变成->".AddHui()," nil", "       != 变成->".AddHui(), " ~=");
                m_Tools.Text_H("PanelNames".AddLightGreen()," ={”PromptPanel“，”MessagePanel“ }");
                m_Tools.Text_H("Game".AddWhite()," = {}");
                m_Tools.Text_H("local".AddBlue()+" this = "+"Game".AddWhite(), "      // 方便自己调用方法 this.InitViewPanels()".AddGreen());
                m_Tools.Text_H("function"," Game".AddWhite(), ".InitViewPanels()", "    // 相当于 public 方法了".AddGreen());
                m_Tools.Text_H("    for i = 1, ","#".AddBlue(),"PanelNames".AddLightGreen()," do");
                m_Tools.Text_H("        require".AddBlue()," (\"View / \"..tostring(","PanelNames".AddLightGreen(),"[i]))  ","//注入Lua类".AddGreen());
                m_Tools.Text_H("    end");
                m_Tools.Text_H("end");

            });
        }

        private void DrawWeb()                                   // 网址、编辑工具
        {
            m_Tools.Text_G("网址、编辑工具", ref isDes, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.GuangFangWenDan("http://www.lua.org/manual/5.3/","方法函数");
                    MyCreate.FenGeXian("Lua学习的论坛".PadLeft(75), () =>
                    {
                        Application.OpenURL("http://www.luaer.cn/");
                    });
                    m_Tools.TextButton_Open("  我电脑 Lua 编辑工具 ".AddHui() + "（保存文档一定要 .lua 结尾）".AddGreen(), () =>
                    {
                        Application.OpenURL(@"C:\Program Files (x86)\Lua\5.1\SciTE\SciTE.exe");
                    });

                });
            });
            AddSpace_3();
        }

        private void DrawZero()                                  // 0.注意的 （注释、打印、格式）
        {
            m_Tools.BiaoTi_O("0.注意的" + "（注释、打印、格式）".AddYellow(), ref isZero, () =>
            {
                MyCreate.Box(() =>
                {
                    m_Tools.TextText_BH("单行注释" + " --xx".AddGreen(), "-- print(\"Hello wrold\")");
                    m_Tools.TextText_BH("多行注释" + " --[[xx]]--".AddGreen(), "--[[age=100");
                    m_Tools.TextText_BH("", "print(age)]]--");
                    m_Tools.TextText_BH("打印" + " print".AddGreen(), "print(\"Hello wrold\")");
                    m_Tools.Text_B("格式：" + "可以没有分号、每行就是一个语句".AddLightBlue());
                });
            });
        }

        private void DrawBianLiang()                             // 1.变量
        {
            m_Tools.BiaoTi_O("1.变量" + "(定义变量、哪些变量)".AddYellow() + "、运算符", ref isOne, () =>
            {
                AddSpace();
                MyCreate.Window("说明", () =>
                {
                    m_Tools.Text_L("1. 定义变量", "不需要类型".AddBlue(), "，根据存储什么数据来决定是什么类型");
                    m_Tools.Text_L("2. 直接表示", "全局变量".AddBlue(), "   3.不能以数字作为开头（", "正常命名即可".AddBlue(), "）");
                    m_Tools.Text_L("4. 除了上面三种类型还有 ", "nil 表示空数据、table表类型".AddBlue());
                    m_Tools.Text_L("5. 添加 ", "local".AddBlue(), " 表示局部变量");
                });
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("age = 100     name = “PSP”    isBool = false " + "(加 local 表局部变量)".AddLightGreen());
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_L(" +-*/% >= == > ", "（没有 ++ 这样的运算行）".AddGreen());
                m_Tools.Text_L(" and or not", " （与 或 非）".AddGreen(), "   //相当于 && || ！".AddLightGreen());
            });
        }

        private void DrawYuJu()                                  // 2.控制语句 
        {
            m_Tools.BiaoTi_O("2.控制语句 "+ ("可以使用break跳出，没有"+"continue".AddHui()+"、没有"+"switch case".AddHui()).AddYellow(), true);
            MyCreate.Box(() =>
            {
                m_Tools.Text_B("判断 If " + "(if then end)".AddLightBlue(), ref isIf, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_HG("if hp < 0 then", "// 不需要加括号");
                        m_Tools.TextText_HG("    ...", "// 执行语句");
                        m_Tools.Text_H("else if hp < 10");
                        m_Tools.Text_H("    ...");
                        m_Tools.Text_H("else");
                        m_Tools.Text_H("    ...");
                        m_Tools.Text_H("end");
                    });
                });
                m_Tools.Text_B("循环 for "+"（for index = [start]，[end] do）".AddLightBlue(),ref isFor, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                       m_Tools.TextText_HG("for i = 1 ,100 do","// for(int i = 1,i <= 100)");
                       m_Tools.Text_H("   print( i )");
                       m_Tools.Text_H("end");
                    });
                });
                m_Tools.Text_B("遍历 foreach "+ "for k,v in ipairs/pairs(array) do".AddLightBlue(),ref isforeach, () =>
                {
                    MyCreate.TextCenter("迭代table元素的(pairs)，迭代数组元素的(ipairs)");
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_HG("array = {\"Lua\", \"Tutorial\"}", "// 数组元素");
                        m_Tools.TextText_HG("for k,v in ipairs(array) do", "// 用 ipairs 遍历数组元素");
                        m_Tools.Text_H("    print(k, v)");
                        m_Tools.Text_H("end");
                    });
                });
                m_Tools.Text_B("循环 While" + "（while do end）".AddLightBlue(), ref isWhile, () =>
                {
                    AddSpace();
                    MyCreate.Window("while ",() =>
                    {
                        m_Tools.TextText_HG("while hp < 0 do", "// 不需要加括号");
                        m_Tools.TextText_HG("    ...", "// 执行语句");
                        m_Tools.Text_H("end");
                    });
                    AddSpace();
                    AddSpace();
                    MyCreate.Window("do while", () =>
                    {
                        m_Tools.TextText_HG("repeat", "// do", 30);
                        m_Tools.Text_H("    ...");
                        m_Tools.TextText_HG("util 判断","// while ( 判断 )", 30);
                    });

                });

            });

        }


        private void DrawTable()                                 // 3.数组、字典
        {
            m_Tools.BiaoTi_O("3.可用作数组、字典、集合的" + " table 表 ".AddRed() + "（索引从 1 开始）".AddGreen(), ref isTable, () =>
            {
                m_Tools.Text_G("table 类似 C# 的字典"+" (key - value 键值对)".AddLightGreen());
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("1.table 的空创建");
                    m_Tools.TextText_HG("myTable = {}","// new 一个空的表");
                    MyCreate.Text("table 的赋值");
                    m_Tools.TextText_HG("myTable[1] = 10","// key =1 ，value =10");
                    m_Tools.TextText_HG("myTable[“name”] = “abc”","// key =name ，value =abc");
                    MyCreate.Text("table 的访问");
                    m_Tools.TextText_HG("print( myTable[\"aa\"]，myTable[1]，myTable[2])", "// abc,10,nil");
                });
                AddSpace();
                AddSpace_3();
                MyCreate.Window("table 的创建还有二种方式", () =>
                {
                    MyCreate.Text("2.创建可以直接赋值：");
                    m_Tools.Text_H("myTable = {name =“abc”，age =18 ,isMan =false}");
                    MyCreate.Text("3.：类似数组使用");
                    m_Tools.TextText_HG("myTable = {2，5，“第三个”}","// Key 从 "+"1 开始".AddRed()+ " myTable[1] 等于 2");
                });
                AddSpace();
                AddSpace_3();
                MyCreate.Window("table 的遍历", () =>
                {
                    m_Tools.Text_H("for key，value in pairs( 表名 ) do");
                    m_Tools.Text_H("    ...");
                    m_Tools.Text_H("end");

                });
            });
        }

        private void DrawMethod()                                // 4.函数 
        {
            m_Tools.BiaoTi_O("4.函数 " + "（ 常用标准函数 ）".AddGreen(), ref isMethods, () =>
            {
                MyCreate.Box(() =>
                {
                    MyCreate.Text("1.数据处理的 " + "math ".AddGreen() + "相关函数");
                    m_Tools.Text_Y("math.abs", "绝对值".AddHui(), "   math.max/min ", "最大/最小".AddHui(), "   math.random", "随机值".AddHui());
                    m_Tools.Text_Y("math.sqrt","平均值".AddHui(), "   math.sin/cos/tan","正弦/余弦/正切".AddHui());
                    MyCreate.Text("2.表处理的 table 相关函数");
                    MyCreate.Text("3.文件操作的 io 相关函数");

                });
            });
            MyCreate.Box_Hei(() =>
            {
                m_Tools.Text_H("function 方法名（ num1，num2 ）");
                m_Tools.Text_H("    return num1 + num2");
                m_Tools.Text_H("end");
            });
        }


        private void DrawTableMethods()                          // 5.表相关函数
        {
            m_Tools.BiaoTi_O("5.表相关函数 ",ref isTableMethod,() =>
            {
                MyCreate.StaticMethodWindow(() =>
                {
                    MyCreate.Text("增");
                    m_Tools.Method_BL("table.insert", "表，int，值", "插入一个数据", "", -20);

                    MyCreate.Text("删");
                    m_Tools.Method_BL("table.remove", "表", "移除指定位置的数据", "", -20);
                    MyCreate.Text("改");
                    m_Tools.Method_BL("table.move", "表", "移动数据", "", -20);
                    MyCreate.Text("其他" + "（只针对数组有用，不规则的无效）".AddGreen());
                    m_Tools.Method_BL("table.concat", "表", "把表中所有数据连成 string","string",-20);
                    m_Tools.Method_BL("table.sort", "表", "排序", "", -20);
                });   

            });
        }

        private void DrawString()                                // 6.字符串操作
        {
            m_Tools.BiaoTi_O("6.字符串操作  "+"（字符串相加 .. 代替 +）".AddYellow(), ref isString, () =>
            {
                 MyCreate.StaticMethodWindow(() =>
                 {
                     m_Tools.Method_BL("string.find","","查找指定字符串");
                     MyCreate.Text("与 C# 相同");
                     m_Tools.Method_BL("string.format","","格式化");
                     m_Tools.Method_BL("string.sub","string，int 开始，int 长度","");
                     m_Tools.Method_BL("string.lower/upper", "","全部转成小写/大写");
                 });
                MyCreate.MethodWindow(() =>
                {
                     m_Tools.Method_BL("tostring","int","数字 —> 字符串","字符串");
                     m_Tools.Method_BL("tonumber","", "字符串 —> 数字", "数字");

                });
            });
        }


        private void DrawOPP()                                   // 7.面对对象编程
        {
            m_Tools.BiaoTi_O("7.通过表来实现面对对象 ", ref isOpp, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    MyCreate.Text("// 声明".AddGreen());
                    m_Tools.TextText_HG("myTable = {}","// 申明对象");
                    m_Tools.TextText_HG("local this =myTable","// 声明 this 代表当前对象");
                    MyCreate.Text("// 赋值属性和方法".AddGreen());
                    m_Tools.TextText_HG("myTable.name = “ABC”", "// 属性名为 ABC");
                    m_Tools.TextText_HG("myTable.age =10", "// 属性年龄为 10");
                    m_Tools.TextText_HG("myTable.Move = function()","// 声明 Action");
                    m_Tools.Text_H("   print（“Action方法体”）");
                    m_Tools.Text_H("end");
                    MyCreate.Text("// 暴露个 public 方法".AddGreen());
                    m_Tools.TextText_HG("function myTable.Attack", "// public var Attack()");
                    m_Tools.TextText_HG("    print（this.name）","// 调用 name 属性");
                    m_Tools.TextText_HG("    this.Move()", "// 调用 Move 方法体");
                    m_Tools.Text_H("end");

                });

            });

        }

        #region 私有

        private bool isDes,isZero,isOne,isIf,isFor,isWhile,isMethods,isString,isTable,isTableMethod,isOpp;
        private bool isforeach;

        [MenuItem(LearnMenu.OtherLanguage2)]
        public static void ShowWindow()
        {
            CreateWindow("Lua", 485, 500);
        }

        protected override string Tittle()
        {
            return "";
        }

        #endregion


    }
}


