using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static WPFWordleCheats.View.WordleTextBox;

namespace WPFWordleCheats.Model
{
    public class WordleState
    {
        private string _guess;
        private string _colors;

        public bool IsValidWord
        { 
            get
            {
                var model = new WordleModel();
                return model.IsGuessValid(Guess);
            }
        }

        public Dictionary<Brush, char> BrushCharMap = new Dictionary<Brush, char>()
        {
            { Brushes.DarkGray, 'D' },
            { Brushes.Yellow, 'Y' },
            { Brushes.Green, 'G' },
        };

        /// <summary>
        /// Property for getting the guess as a string
        /// </summary>
        public string Guess => _guess;

        /// <summary>
        /// Property for getting the colors as a string
        /// </summary>
        public string Color => _colors;

        /// <summary>
        /// Property representing whether or not the guess is a complete guess or not
        /// </summary>
        public bool GuessComplete => Guess.Length == 5;

        /// <summary>
        /// The current wordle state, the data structure used to represent this is a list of touples
        /// where T1 is the character, and T2 is the color mapped by <see cref="BrushCharMap"/>
        /// </summary>
        public List<Tuple<char, char>> State = new List<Tuple<char, char>>();   

        public void UpdateState(WordleState state)
        {
            this._colors = state.Color; 
            this._guess = state.Guess;
            State.Clear();
            for (int i = 0; i < _guess.Length; i++)
            {
                var letterColorTouple = new Tuple<char, char>(_guess[i], _colors[i]);
                State.Add(letterColorTouple);
            }
        }
     
        public WordleState(string guess, string colors)
        {
            this._guess = guess;
            this._colors = colors;
            for (int i = 0; i < guess.Length; i++)
            { 
                var letterColorTouple = new Tuple<char, char>(guess[i], colors[i]);
                State.Add(letterColorTouple);   
            }
        }
    }
}
