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

            // �E�B���h�E������ꂽ�C�x���g�ɑ΂���C�x���g�n���h����ǉ�
            Closed += (sender, args) =>
            {
                // �C�x���g�������ς݂Ƃ��ă}�[�N���āA�f�t�H���g�̃n���h���ւ̓`�d��j�~����B
                // �f�t�H���g�̃n���h���̓A�N�e�B�u�ȃE�B���h�E��1���Ȃ��ƃA�v���P�[�V�������I��������B
                args.Handled = true;
                // �E�B���h�E��������ɉB���B
                this.Hide();
            };
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }
    }

    // ���[�N�A���E���h�@H.NotifyIcon.WinUI���C�x���g�n���h���Ƃ��ĕ��ʂ̃��\�b�h���󂯕t����Ȃ�A���̃N���X�͗v��Ȃ��B
    // WPF�����ɍ��ꂽH.NotifyIcon�𖳗����WinUI3�ɑΉ������Ă���悤������AICommand�^�����n���Ȃ��B
    // WinUI3��������NotifyIcon�ɑΉ�������A����class�͏������ׂ��ł���B
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
