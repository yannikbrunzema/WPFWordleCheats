using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWordleCheats.Model
{
    public class WordleModel : INotifyPropertyChanged
    {
        private static readonly string _projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static readonly string DictionaryFileName = Path.Combine(_projectDirectory, "Resources\\wordledictionary.txt");
        private string _word;

        private HashSet<string> possibleWords = new HashSet<string>();

        public WordleModel(WordleState state)
        {
            this._word = state.Guess;
            this.InitializePossibleWords();
        }

        private void InitializePossibleWords()
        {
            try
            {
                var dictionaryLines = File.ReadAllLines(DictionaryFileName);
                foreach (var dictionaryLine in dictionaryLines)
                    possibleWords.Add(dictionaryLine);
            }
            catch { }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Word
        {
            get => _word;
            set
            {
                _word = value;
                OnPropertyChanged(nameof(Word));
            }
        }
    }
}
