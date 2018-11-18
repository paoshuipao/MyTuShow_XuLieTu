//-----------------------------------------------------------------------
// <copyright file="TitleAttribute.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using PSPUtil.StaticUtil;

namespace Sirenix.OdinInspector
{
    using System;

    /// <summary>
    /// <para>Title is used to make a bold header above a property.</para>
    /// </summary>
    /// <example>
    /// The following example shows how Title is used on different properties.
    /// <code>
    /// public class TitleExamples : MonoBehaviour
    /// {
    ///     [Title("Titles and Headers")]
    ///     [InfoBox(
    ///         "The Title attribute has the same purpose as Unity's Header attribute," +
    ///         "but it also supports properties, and methods." +
    ///         "\n\nTitle also offers more features such as subtitles, options for horizontal underline, bold text and text alignment." +
    ///         "\n\nBoth attributes, with ODIN, supports either static strings, or refering to members strings by adding a $ in front.")]
    ///     public string MyTitle = "My Dynamic Title";
    ///     public string MySubtitle = "My Dynamic Subtitle";
    /// 
    ///     [Title("Static title")]
    ///     public int C;
    ///     public int D;
    /// 
    ///     [Title("Static title", "Static subtitle")]
    ///     public int E;
    ///     public int F;
    /// 
    ///     [Title("$MyTitle", "$MySubtitle")]
    ///     public int G;
    ///     public int H;
    /// 
    ///     [Title("Non bold title", "$MySubtitle", bold: false)]
    ///     public int I;
    ///     public int J;
    /// 
    ///     [Title("Non bold title", "With no line seperator", horizontalLine: false, bold: false)]
    ///     public int K;
    ///     public int L;
    /// 
    ///     [Title("$MyTitle", "$MySubtitle", TitleAlignments.Right)]
    ///     public int M;
    ///     public int N;
    /// 
    ///     [Title("$MyTitle", "$MySubtitle", TitleAlignments.Centered)]
    ///     public int O;
    ///     public int P;
    /// 
    ///     [Title("$Combined", titleAlignment: TitleAlignments.Centered)]
    ///     public int Q;
    ///     public int R;
    /// 
    ///     [ShowInInspector]
    ///     [Title("Title on a Property")]
    ///     public int S { get; set; }
    /// 
    ///     [Title("Title on a Method")]
    ///     [Button]
    ///     public void DoNothing()
    ///     { }
    /// 
    ///     public string Combined { get { return this.MyTitle + " - " + this.MySubtitle; } }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="ButtonAttribute"/>
    /// <seealso cref="LabelTextAttribute"/>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [DontApplyToListElements]
    public class TitleAttribute : Attribute
    {
        public TitleAttribute(string title, string subtitle = null, TitleAlignments titleAlignment = TitleAlignments.Left, bool horizontalLine = true, bool bold = true)
        {
            this.Title = title ?? "null";
            this.Subtitle = subtitle;
            this.Bold = bold;
            this.TitleAlignment = titleAlignment;
            this.HorizontalLine = horizontalLine;
            TextColor=MyEnumColor.Green;
        }


        public TitleAttribute(string title, MyEnumColor color)
        {
            Title = title ?? "null";
            Subtitle = null;
            TextColor = color;
            TitleAlignment = TitleAlignments.Left;
            HorizontalLine = true;
            Bold = true;
        }


        public TitleAttribute(string title, MyEnumColor color, bool horizontalLine)
        {
            Title = title ?? "null";
            Subtitle = null;
            TextColor = color;
            TitleAlignment = TitleAlignments.Left;
            HorizontalLine = horizontalLine;
            Bold = true;
        }


        public TitleAttribute(string title, bool isBold)
        {
            Title = title ?? "null";
            Subtitle = null;
            TextColor = MyEnumColor.Green;
            TitleAlignment = TitleAlignments.Left;
            HorizontalLine = false;
            Bold = isBold;
        }


        public string Title { get; private set; }                              // �Ϸ��ı���

        public string Subtitle { get; private set; }                           // ��ѡ����˵��

		public bool Bold { get; private set; }                                 // �Ƿ�Ӵ֣�Ĭ���ǣ�


		public bool HorizontalLine { get; private set; }                       // �Ƿ��ڱ����»���ˮƽ��(Ĭ����)


        public TitleAlignments TitleAlignment { get; private set; }            // ������루Ĭ������룩



        public MyEnumColor TextColor { get; private set; }                     // ��ɫ����ɫ��
         

    }
}