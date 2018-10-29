using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFToolKitDateTimePicker
{
    [ToolboxBitmap(typeof(DateTimePicker), "DateTimePicker.bmp")]
    /// <summary>
    /// DateTimePicker.xaml 的交互逻辑
    /// </summary>    
    public partial class DateTimePicker : UserControl
    {
        TDateTimeView dtView = null;
        public DateTimePicker()
        {
            InitializeComponent();
            dtView = new TDateTimeView(textBlock1.Text);// TDateTimeView  构造函数传入日期时间
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="txt"></param>
        public DateTimePicker(string txt)
            : this()
        {
            dtView = new TDateTimeView(txt);// TDateTimeView  构造函数传入日期时间
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
            string[] times = this.textBlock1.Text.Split(' ')[1].Split(':');

            dtView.textBlockhh.Text = times[0];
            dtView.textBlockmm.Text = times[1];
            dtView.textBlockss.Text = times[2];

            dtView.DateTimeOK = (dateTimeStr) => //TDateTimeView 日期时间确定事件
            {

                textBlock1.Text = dateTimeStr;
                DateTime = Convert.ToDateTime(dateTimeStr);
                popChioce.IsOpen = false;//TDateTimeView 所在pop  关闭
                if (ClosingPopupDateTimePicker != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        ClosingPopupDateTimePicker.Invoke();
                    }), System.Windows.Threading.DispatcherPriority.Normal);
                }

            };

            popChioce.Child = dtView;
            popChioce.IsOpen = true;
        }
        #endregion

        #region 属性

        private DateTime dateTime = DateTime.Now;

        public Action ClosingPopupDateTimePicker;

        /// <summary>
        /// 日期时间
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(textBlock1.Text);
            }
            set
            {
                dateTime = value;
                textBlock1.Text = dateTime.ToString("yyyy/MM/dd HH:mm:ss");//"yyyyMMddHHmmss"
            }
        }

        #endregion
    }
}