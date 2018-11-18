using PSPEditor.EditorUtil;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace UnityEditor
{
    public class Language_Python : AbstractKuang<Language_Python>
    {
        protected override void OnEditorGUI()
        {
            MyCreate.Button("            【将所有 cs 文件转化 utf-8 格式】 点击运行", () =>
            {
                string path = MyAssetUtil.GetApplicationDataPathNoAssets() + "/Python/Run.bat";
                Application.OpenURL(path);

            });
            AddSpace();
            DrawZhongJie();
            DrawZero();
            DrawFirst();
            DrawWhile();
            DrawList();
            DrawDef();
            DrawString();
            DrawSix();
        }

        private void DrawZhongJie()                              // 总结
        {
            m_Tools.BiaoTi_O("总结");
            MyCreate.Box(() =>
            {
                m_Tools.Text_Y("1. 以 ","冒号 : ".AddGreen(),"开始，以"," 缩进式 ".AddGreen(),"表示每个段落");
                m_Tools.Text_Y("2. 特殊用法 ","[ : 2]".AddGreen()," 截取 0 到 2", "，    [ 2: -1]".AddGreen(), " 截取 2 到 最后");
                m_Tools.Text_Y("3. 开头加个编码模式："+"# coding:utf-8".AddHui());
            });
            AddSpace_3();

        }

        private void DrawZero()                                  // 0.注意的
        {
            m_Tools.BiaoTi_B("0.注意的" + "（注释、打印、格式、注意事项）", ref _isZero, () =>
            {

                MyCreate.AddSpace(12);
                MyCreate.Window("注意事项", () =>
                {
                    m_Tools.Text_L("以 ", "缩进式".AddGreen(), " 区分代码模块", "(都使用 Tab,不使用空格)".AddLightGreen());
                    m_Tools.Text_R("报 IndentationError 错误");
                });
                AddSpace_3();
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("# coding:utf-8", "// 下面代码使用编码 utf-8，文本不需要改动");
                    m_Tools.TextText_BH("打印" + " print".AddGreen(), "print\"Hello wrold\"");
                    m_Tools.TextText_BH("注释" + " # xx".AddGreen(), "# print\"Hello wrold\"");
                });
                MyCreate.AddSpace(12);
                MyCreate.Window("为什么使用 Python", () =>
                {
                    m_Tools.Text_L("1. Python 跨平台");
                    m_Tools.Text_L("2. Python 可以直接转换成 exe");
                    m_Tools.Text_L("3. Python 可以调用任何的 exe 程序，linux 可以调用linux相关执行程序");
                    m_Tools.Text_L("    例如搜索文件快、去修改数据库、把apk资源全部搜索出来");
                });


            });
            AddSpace_3();
        }


        private void DrawFirst()                                 // 1.变量、运算符
        {
            m_Tools.BiaoTi_B("1.变量、运算符", ref _isBianLiang, () =>
            {
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.Text_H("a = 9");
                    m_Tools.Text_H("b = 4");
                    m_Tools.Text_H("a * b ", "为 9 的 4 次方".AddGreen());
                    m_Tools.Text_H("a // b", "为 9 整除 4 结果为 2".AddGreen());
                });
            });
            MyCreate.Box(() =>
            {
                m_Tools.Text_G("变量/逻辑运算符（and or not）", "  与 Lua 相同".AddHui());
                MyCreate.Text("Lua 没有的：");
                m_Tools.Text_G("**", " 幂 返回x的y次幂".AddLightBlue(), "      //", "  取整除，返回商的整数部分".AddLightBlue());
                m_Tools.Text_G("可以使用 is、+= 、-= 、*= 、/= 、%= 、**= 、//=");
            });
            AddSpace_3();
        }

        private void DrawWhile()                                 // 2.控制语句
        {
            m_Tools.BiaoTi_B("2.控制语句", true);
            MyCreate.Box(() =>
            {
                m_Tools.Text("If else" + "（if 判断:/ elif 判断: / else:）".AddYellow(), ref _isIf, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("num = 5");
                        m_Tools.TextText_HG("if num == 3:", "# 使用冒号");
                        m_Tools.TextText_HG("    ...", "# Tab 空格");
                        m_Tools.Text_H("elif num == 2:");
                        m_Tools.Text_H("    ...");
                        m_Tools.Text_H("else:");
                        m_Tools.Text_H("    ...");
                    });
                });
                m_Tools.Text("For" + "(for i int list：)".AddYellow(), ref _for, () =>
                {
                    m_Tools.Text_L("list = {‘ab’,'cd','ef'}");
                    MyCreate.Text("foreach");
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.TextText_HG("for index in list:", "# 不要忘记冒号");
                        m_Tools.Text_H("print '当前字母：',index");
                    });
                    AddSpace_3();
                    MyCreate.Text("for(int i = 0; i<10; i++)");
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("for index in range(len(list)):");
                        m_Tools.Text_H("    print '当前字母：',list[index]");
                    });

                });
                m_Tools.Text("While" + "(while 判断: )".AddYellow(), ref _isWhile, () =>
                {
                    MyCreate.Box_Hei(() =>
                    {
                        m_Tools.Text_H("count = 0");
                        m_Tools.Text_H("while（count < 9）：");
                        m_Tools.Text_H("    ...");
                        m_Tools.TextText_HG("    count = count +1", "# 同样没有 ++");
                    });
                });
            });
            AddSpace_3();
        }

        private void DrawList()                                  // 3.数组、集合、字典
        {
            m_Tools.BiaoTi_B("3.数组、集合、字典", ref _isList, () =>
            {
                MyCreate.AddSpace(14);
                MyCreate.Window("元组（可读数组），使用"+" 小括号".AddYellow(), () =>
                {
                    m_Tools.Text_G("1. 创建 ","tmp =　(“12”，“34”)".AddHui());
                    m_Tools.Text_G("2. 使用 用法相同 ", "tmp[1] 或者 for".AddHui());
                    m_Tools.Text_G("3. 但是不能修改，不能删除 ", "这是错误的 tmp[1] = “a”".AddRed());

                });
                MyCreate.AddSpace(14);
                MyCreate.Window("列表[可增删改查]，使用 "+"中括号".AddYellow(), () =>
                {
                    m_Tools.Text_G("1. 创建 ", "tmp =　[“12”，“34”]".AddHui());
                    m_Tools.Text_G("2. 使用 用法相同,可以修改");
                    m_Tools.Text_G("3. 删除  ", "del tmp[1]".AddHui()," # 删除第2个数据");
                    m_Tools.Text_G("4. 增加  ", "tmp.append(123)".AddHui()," # 在最后增加，而且可以混合");
                    m_Tools.Text_G("4. 插入  ", "tmp.insert(1,234)".AddHui());
                });
                MyCreate.AddSpace(14);
                MyCreate.Window("字典{ key: value，key.:value2 }，使用"+" 大括号".AddYellow(), () =>
                {
                    m_Tools.Text_G("1. 创建 ", "tmp =　['Name':'Zero'，'Age'：7]".AddHui());
                    m_Tools.Text_G("2. 访问 ", "tmp['Name']".AddHui());
                    m_Tools.Text_G("3. 修改 ", "tmp['Name'] =  'Change'".AddHui());
                    m_Tools.Text_G("4. 删除 ", "del tmp['Name']".AddHui());
                    m_Tools.Text_G("5. 清空 ", "tmp.clear()".AddHui());
                });


            });
            AddSpace_3();
        }

        private void DrawDef()                                   // 4.函数
        {
            m_Tools.BiaoTi_B("4.函数（定义、如何传参数）"+" def 函数名字 :".AddYellow(), true);
            AddSpace_3();
        }

        private void DrawString()                                // 5.字符串操作
        {
            m_Tools.BiaoTi_B("5.字符串操作", ref _isString, () =>
            {
                m_Tools.Text_L("单引号与双引号都可以表示字符串");
                m_Tools.Text_L("相加使用 +");
                MyCreate.Text("下面以 str = “ Hello ” 作为例子：");
                MyCreate.Box_Hei(() =>
                {
                    m_Tools.TextText_HG("str[0]", "# H   ");
                    m_Tools.TextText_HG("str[0,3]", "# Hel   截取");
                    m_Tools.TextText_HG("str * 2", "# HelloHello   重复字符");
                    m_Tools.TextText_HG("str in “e”", "# true   判断是否这个字符");
                    m_Tools.TextText_HG("str not in “e”", "# false   ");
                    m_Tools.TextText_HG("u“ 中文或者有问题的字符 ”", "# 相当于 @");
                });
            });
            AddSpace_3();

        }


        private void DrawSix()                                   // 6.一个类怎么样调用其他的类
        {
            m_Tools.BiaoTi_B("6.一个类怎么样调用其他的类", true);
            MyCreate.Box(() =>
            {
                 m_Tools.Text_L("与 lua 类似，但不是字符串，直接名：","使用 import py名".AddHui());
            });
            MyCreate.AddSpace(14);
            MyCreate.Window("创建 bat 运行 py"+"（注意路径）".AddGreen(), () =>
            {
                m_Tools.TextText_HG("1. python 文件名.py","// 同工作路径情况下");
                m_Tools.TextText_HG("1. python ./Python/test.py", "// UnityEditor 调用的话");
                m_Tools.TextText_HG("2. pause","// 暂停");
            });



        }




        #region 私有

        private bool _isZero,_isString,_isBianLiang,_isList, _isIf,_isWhile,_for;


        [MenuItem(LearnMenu.OtherLanguage3)]
        public static void ShowWindow()
        {
            CreateWindow("Python", 480, 500);
        }

        protected override string Tittle()
        {
            return "";
        }

        #endregion



    }
}


