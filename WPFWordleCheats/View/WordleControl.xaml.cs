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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFWordleCheats.Model;
using WPFWordleCheats.ViewModel;

namespace WPFWordleCheats.View
{
    /// <summary>
    /// Interaction logic for WordleControl.xaml
    /// </summary>
    public partial class WordleControl : UserControl
    {
        private WordleTextBox _textbox1;
        private WordleTextBox _textbox2;
        private WordleTextBox _textbox3;
        private WordleTextBox _textbox4;
        private WordleTextBox _textbox5;
        private WordleTextBox _textbox6;
        private List<WordleTextBox> _words;

        private WordleModel _currentModel;

        public WordleControl()
        {
            InitializeComponent();
            _textbox1 = (WordleTextBox)this.FindName("_wordBox1");
            _textbox2 = (WordleTextBox)this.FindName("_wordBox2");
            _textbox3 = (WordleTextBox)this.FindName("_wordBox3");
            _textbox4 = (WordleTextBox)this.FindName("_wordBox4");
            _textbox5 = (WordleTextBox)this.FindName("_wordBox5");
            _textbox6 = (WordleTextBox)this.FindName("_wordBox6");
            _words = new List<WordleTextBox> { _textbox1, _textbox2, _textbox3, _textbox4, _textbox5, _textbox6 };
        }

        private void OnConfirmEntryClick(object sender, RoutedEventArgs e)
        {
            foreach(var word in _words)
            {
                if (word.TextBoxFilled && !word.HasBeenProcessed)
                {
                    var viewModel = (WordleViewModel)DataContext;
                    viewModel.WordleModel.UpdateModel(word.TextboxState);
                    word.HasBeenProcessed = true;
                }
            }
        }
    }
}
