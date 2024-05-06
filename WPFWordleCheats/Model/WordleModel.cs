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

        private enum Color
        {
            Gray,
            Yellow,
            Green
        };

        public WordleModel()
        {
            this.InitializePossibleWords();
        }

        public void UpdateModel(WordleState state)
        {
            int index = 0;
            var map = state.State;
            foreach (Tuple<char, char> stateTuple in map)
            {
                if (stateTuple.Item2 == 'D')
                    RemoveGrayLetterWords(stateTuple.Item1);
                if (stateTuple.Item2 == 'Y')
                    RemoveYellowLetters(stateTuple.Item1, index);
                if (stateTuple.Item2 == 'G')
                    RemoveGreenLetterWords(stateTuple.Item1, index);    

                index++;
            }

            OnPropertyChanged(nameof(PossibleWords));
        }

        public bool IsGuessValid(string word)
        {
            return possibleWords.Contains(word);
        }

        public List<String> PossibleWords => possibleWords.ToList();

        private void InitializePossibleWords()
        {
            try
            {
                var dictionaryLines = File.ReadAllLines(DictionaryFileName);
                foreach (var dictionaryLine in dictionaryLines)
                    possibleWords.Add(dictionaryLine.ToUpper());
            }
            catch { }
        }

        private void RemoveGrayLetterWords(char letter)
        {
            foreach (var word in possibleWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (letter == word[i])
                    {
                        possibleWords.Remove(word);
                        continue;
                    }
                }
            }
        }

        private void RemoveYellowLetters(char letter, int index)
        {
            foreach (var word in possibleWords)
            {
                // We only want to keep words that contain the yellow letter, but are not at the same index
                if (word.Contains(letter) && word.IndexOf(letter) != index)
                    continue;
                else
                    possibleWords.Remove(word); 
            }
        }

        private void RemoveGreenLetterWords(char letter, int index)
        {
            foreach (var word in possibleWords)
            {
                // Remove words that don't have the green letter at the specified index
                if (word.Contains(letter) && word.IndexOf(letter) == index)
                    continue;
                else
                    possibleWords.Remove(word);
            }
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
