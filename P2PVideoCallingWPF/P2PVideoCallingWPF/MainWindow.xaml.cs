using P2PVideoCalling.IoC;
using System.Windows;

namespace P2PVideoCalling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var webCam = Controller.GetWebCamHandler();
            webCam.GetVideo();
            InitializeComponent();
        }
    }
}
