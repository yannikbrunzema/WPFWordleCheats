using System.Windows;
using WPFWordleCheats.Model;

namespace WPFWordleCheats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var test = new WordleModel("TESTS", new char[] { 'H', 'E', 'A', 'R', 'D' });
        }
    }
}