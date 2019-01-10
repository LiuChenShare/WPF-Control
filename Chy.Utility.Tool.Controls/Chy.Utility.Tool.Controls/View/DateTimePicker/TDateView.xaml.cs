using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Chy.Utility.Tool.Controls.View.DateTimePicker
{
    /// <summary>
    /// TDateTimeView.xaml 的交互逻辑
    /// </summary>
    [System.ComponentModel.DesignTimeVisible(false)]//在工具箱中 隐藏该窗体
    public partial class TDateView : UserControl
    {
        public TDateView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public TDateView(string txt)
            : this()
        {
            this.formerDateStr = txt;
        }

        #region 全局变量

        /// <summary>
        /// 从 DatePicker 传入的日期时间字符串
        /// </summary>
        private string formerDateStr = string.Empty;

        // private string selectDate = string.Empty;    

        #endregion   

        #region 事件

        /// <summary>
        /// TDateView 窗体登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //当前时间
            //DateTime dt = Convert.ToDateTime(this.formerDateTimeStr);
            //btnhh.Content = dt.Hour.ToString().PadLeft(2,'0');
            //btnmm.Content = dt.Minute.ToString().PadLeft(2, '0');
            //btnss.Content = dt.Second.ToString().PadLeft(2, '0');

            //00:00:00            
            // btnhh.Content = "00";
        }


        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iBtnCloseView_Click(object sender, RoutedEventArgs e)
        {
            OnDateTimeContent(this.formerDateStr);
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dt = new DateTime?();

            if (calDate.SelectedDate == null)
            {
                dt = DateTime.Now.Date;
            }
            else
            {
                dt = calDate.SelectedDate;
            }

            DateTime dtCal = Convert.ToDateTime(dt);

            string dateStr;
            dateStr = dtCal.ToString("yyyy/MM/dd HH:mm:ss");

            OnDateTimeContent(dateStr);

        }

        /// <summary>
        /// 当前按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNow_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            calDate.SelectedDate = dt;
        }

        /// <summary>
        /// 解除calendar点击后 影响其他按钮首次点击无效的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calDate_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }


        /// <summary>
        /// 时间选择控件数据变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = Convert.ToDateTime(sender.ToString());
            textDate.Text = dt.ToString("yyyy/MM/dd");
        }
        #endregion

        #region Action交互

        /// <summary>
        /// 时间确定后的传递事件
        /// </summary>
        public Action<string> DateTimeOK;

        /// <summary>
        /// 时间确定后传递的时间内容
        /// </summary>
        /// <param name="dateTimeStr"></param>
        protected void OnDateTimeContent(string dateTimeStr)
        {
            if (DateTimeOK != null)
                DateTimeOK(dateTimeStr);
        }

        #endregion

    }
}
