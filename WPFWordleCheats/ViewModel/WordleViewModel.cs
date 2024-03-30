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


        public WordleModel Model => new WordleModel(this.Word, this.ColorState.ToCharArray());

        public override string ViewModelTitle => "Wordle Cheats";
    }
}
