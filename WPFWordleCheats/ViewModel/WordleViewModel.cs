using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFWordleCheats.Model;

namespace WPFWordleCheats.ViewModel
{
    public class WordleViewModel : ViewModelBase
    {
        private string _word = string.Empty;
        private string _colorState = string.Empty;

        public WordleState State1 { get; set; }
        public WordleState State2 { get; set; }
        public WordleState State3 { get; set; }
        public WordleState State4 { get; set; }
        public WordleState State5 { get; set; }
        public WordleState State6 { get; set; }

        public WordleViewModel() : base() 
        {
            
        }
        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
                OnPropertyChanged(nameof(Model));
            }
        }

        public string ColorState
        {
            get => _colorState;
            set
            {
                _colorState = value;    
                OnPropertyChanged(nameof(ColorState));
                OnPropertyChanged(nameof(Model));
            }
        }

        public override string ViewModelTitle => "Wordle Cheats";
    }
}
