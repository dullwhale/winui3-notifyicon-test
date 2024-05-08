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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace winui3_notifyicon_test
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

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

    // 元のイベントハンドラ
    //protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    //{
    //    m_window = new MainWindow();
    //    m_window.Activate();
    //}
}
