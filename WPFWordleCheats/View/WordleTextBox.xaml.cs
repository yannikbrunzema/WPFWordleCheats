using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPFWordleCheats.View
{
    /// <summary>
    /// Interaction logic for WordleTextBox.xaml
    /// </summary>
    public partial class WordleTextBox : UserControl, INotifyPropertyChanged
    {
        private string _text1;
        private string _text2;
        private string _text3;
        private string _text4;
        private string _text5;
        private string _inputText;

        /// <summary>
        /// Property to let other controls know that the textbox has been populated
        /// </summary>
        public bool TextBoxFilled => Text1?.Length == 1 && Text2?.Length == 1 && Text3?.Length == 1 && Text4?.Length == 1 && Text5?.Length == 1;

        public static readonly DependencyProperty WorldeStateDependencyProperty = DependencyProperty.Register(nameof(TextboxState),
                                                                                                        typeof(WordleState),
                                                                                                        typeof(WordleTextBox), new FrameworkPropertyMetadata(null));

        public string InputText
        {
            get { return _inputText; }
            set
            {
                if (_inputText != value)
                {
                    _inputText = value.ToUpper();
                    OnPropertyChanged(nameof(InputText));
                    UpdateTextBlocks();
                }
            }
        }

        public string Text1
        {
            get { return _text1; }
            set
            {
                if (_text1 != value)
                {
                    _text1 = value;
                    OnPropertyChanged(nameof(Text1));
                }
            }
        }

        public string Text2
        {
            get { return _text2; }
            set
            {
                if (_text2 != value)
                {
                    _text2 = value;
                    OnPropertyChanged(nameof(Text2));
                }
            }
        }

        public string Text3
        {
            get { return _text3; }
            set
            {
                if (_text3 != value)
                {
                    _text3 = value;
                    OnPropertyChanged(nameof(Text3));
                }
            }
        }

        public string Text4
        {
            get { return _text4; }
            set
            {
                if (_text4 != value)
                {
                    _text4 = value;
                    OnPropertyChanged(nameof(Text4));
                }
            }
        }

        public string Text5
        {
            get { return _text5; }
            set
            {
                if (_text5 != value)
                {
                    _text5 = value;
                    OnPropertyChanged(nameof(Text5));
                }
            }
        }



        private Dictionary<Brush, char> BrushCharMap = new Dictionary<Brush, char>()
        {
            { Brushes.DarkGray, 'D' },
            { Brushes.Yellow, 'Y' },
            { Brushes.Green, 'G' },
        };

        public WordleState TextboxState
        {
            get { return (WordleState)GetValue(WorldeStateDependencyProperty); }
            set { SetValue(WorldeStateDependencyProperty, value); }
        }

        public bool HasBeenProcessed { get; set; }

        public WordleTextBox()
        {
            InitializeComponent();
        }

        private string GetCurrentColorState()
        {
            char[] temp =
            [
                GetColor(_firstChar.Background),
                GetColor(_secondChar.Background),
                GetColor(_thirdChar.Background),
                GetColor(_fourthChar.Background),
                GetColor(_fifthChar.Background),
            ];

            return new string(temp);
        }

        private char GetColor(Brush brush)
        {
            if(BrushCharMap.ContainsKey(brush))
                return BrushCharMap[brush];
            return 'D';
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateTextBlocks()
        {
            if (InputText.Length >= 1)
                Text1 = InputText.Substring(0, 1);
            else
                Text1 = "";

            if (InputText.Length >= 2)
                Text2 = InputText.Substring(1, 1);
            else
                Text2 = "";

            if (InputText.Length >= 3)
                Text3 = InputText.Substring(2, 1);
            else
                Text3 = "";

            if (InputText.Length >= 4)
                Text4 = InputText.Substring(3, 1);
            else
                Text4 = "";

            if (InputText.Length >= 5)
                Text5 = InputText.Substring(4, 1);
            else
                Text5 = "";

            OnPropertyChanged(nameof(TextBoxFilled));
            if(TextboxState != null)
                TextboxState.UpdateState(new WordleState(InputText, GetCurrentColorState()));
            else
                TextboxState = new WordleState(InputText, GetCurrentColorState());
        }


    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _inputTextBox.Focus();
            var button = (Button)sender;
            string textBoxName = button.Tag.ToString();
            var charTextBox = (TextBox)this.FindName(textBoxName);
            if (charTextBox != null)
            {
                if (charTextBox.Background == Brushes.DarkGray)
                    charTextBox.Background = Brushes.Yellow;
                else if (charTextBox.Background == Brushes.Yellow)
                    charTextBox.Background = Brushes.Green;
                else if (charTextBox.Background == Brushes.Green)
                    charTextBox.Background = Brushes.DarkGray;
                else
                    charTextBox.Background = Brushes.DarkGray;
            }
            if(!String.IsNullOrEmpty(InputText))
            {
                if(TextboxState != null)
                    TextboxState.UpdateState(new WordleState(InputText, GetCurrentColorState()));
                else
                    TextboxState = new WordleState(InputText, GetCurrentColorState());
            }
        }

        /// <summary>
        /// Prevents non character input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Allow only numbers and letters
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"^[a-zA-Z]+$"))
            {
                e.Handled = true;
            }
        }
    }
}
