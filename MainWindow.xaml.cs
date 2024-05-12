using H.NotifyIcon;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winui3_notifyicon_test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly IconClickedCommand IconClicked;
        public MainWindow()
        {
            this.InitializeComponent();

            IconClicked = new IconClickedCommand();

            // ウィンドウが閉じられたイベントに対するイベントハンドラを追加
            Closed += (sender, args) =>
            {
                // イベントを処理済みとしてマークして、デフォルトのハンドラへの伝播を阻止する。
                // デフォルトのハンドラはアクティブなウィンドウが1つもないとアプリケーションを終了させる。
                args.Handled = true;
                // ウィンドウを閉じる代わりに隠す。
                this.Hide();
            };
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }
    }

    // ワークアラウンド　H.NotifyIcon.WinUIがイベントハンドラとして普通のメソッドを受け付けるなら、このクラスは要らない。
    // WPF向けに作られたH.NotifyIconを無理やりWinUI3に対応させているようだから、ICommand型しか渡せない。
    // WinUI3が公式にNotifyIconに対応したら、このclassは消されるべきである。
    public class IconClickedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = null;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.MainWindow.Activate();
        }
    }
}
