﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;

namespace Chy.Utility.Tool.Controls.View.DateTimePicker
{
    /// <summary>
    /// DateTimePicker.xaml 的交互逻辑
    /// </summary>
    [ToolboxBitmap(typeof(Chy_DatePicker), "DateTimePicker.bmp")]
    public partial class Chy_DatePicker : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public Chy_DatePicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public Chy_DatePicker(string txt)
            : this()
        {
            // this.textBox1.Text = txt;

        }

        #region 事件

        /// <summary>
        /// 日历图标点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton1_Click(object sender, RoutedEventArgs e)
        {
            if (popChioce.IsOpen == true)
            {
                popChioce.IsOpen = false;
            }

            TDateView dtView = new TDateView(textBlock1.Text);// TDateTimeView  构造函数传入日期时间
            dtView.DateTimeOK += (dateTimeStr) => //TDateTimeView 日期时间确定事件
            {
                DateTime = Convert.ToDateTime(dateTimeStr);
                textBlock1.Text = DateTime.ToString("yyyy/MM/dd");
                popChioce.IsOpen = false;//TDateTimeView 所在pop  关闭

            };

            popChioce.Child = dtView;
            popChioce.IsOpen = true;
        }

        /// <summary>
        /// DateTimePicker 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DateTime != new DateTime()) { return; }
            DateTime dt = DateTime.Now;
            textBlock1.Text = dt.ToString("yyyy/MM/dd");//"yyyyMMddHHmmss"
            DateTime = dt;
            //  DateTime = Convert.ToDateTime(textBlock1.Text);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 日期时间
        /// </summary>
        public DateTime DateTime { get; set; }

        #endregion

        #region 对外暴露方法
        /// <summary>
        /// 设置控件的时间
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetDateTime(DateTime dateTime)
        {
            textBlock1.Text = dateTime.ToString("yyyy/MM/dd");//"yyyyMMddHHmmss"
            DateTime = dateTime;
        }
        #endregion
    }
}
