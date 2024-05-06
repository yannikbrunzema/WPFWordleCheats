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
        public WordleModel WordleModel { get; }
        private WordleState _state1;
        private WordleState _state2;
        private WordleState _state3;
        private WordleState _state4;
        private WordleState _state5;
        private WordleState _state6;

        public WordleState State1 { get; set; }
        public WordleState State2 { get; set; }
        public WordleState State3 { get; set; }
        public WordleState State4 { get; set; }
        public WordleState State5 { get; set; }
        public WordleState State6 { get; set; }

        public WordleViewModel() : base() 
        {
            WordleModel = new WordleModel();
        }
       
        public override string ViewModelTitle => "Wordle Cheats";
    }
}
