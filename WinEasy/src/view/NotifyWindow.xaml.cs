using ScreenCut.src.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScreenCut.src.view
{
    /// <summary>
    /// NotifyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NotifyWindow : Window
    {

        private NotifyEventListener listener;
        public NotifyWindow(string title,string content,NotifyEventListener listener)
        {
            
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            lbContent.Content = content;
            lbTitle.Content = title;
            this.listener = listener;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e) {
            base.DragMove();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            listener.onOkClicked();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            listener.onCancelClicked();
            this.Close();
        }
    }
}
