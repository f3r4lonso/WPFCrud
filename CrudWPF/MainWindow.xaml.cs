using System.Windows;
using System.Windows.Controls;

namespace CrudWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame StaticMainFrame;
        public MainWindow()
        {
            InitializeComponent();
            StaticMainFrame = MainFrame;
        }
    }
}
