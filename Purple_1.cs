using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output = null;
        public string Output => _output;
        public Purple_1(string input) : base(input) { }
        public override void Review()
        {
            _output = ToString();
        }
        public override string ToString()
        {
            var s = Input;
            string[] words = new string[0];
            string word = "";
            foreach (var letter in s)
            {
                if (IsSeparator(letter) || letter == ' ')
                {
                    if (word.Length != 0)
                    {
                        int bebra = 0;
                        if (HasDigit(word))
                        {
                            Append(ref words, word);
                        } else Append(ref words, new string(word.Reverse().ToArray()));
                    }
                    Append(ref words, letter.ToString());
                    word = "";
                }
                else
                {
                    word += letter;
                }
            }

            if (word.Length != 0) Append(ref words, new string(word.Reverse().ToArray()));

            string res = "";
            foreach (var w in words)
            {
                res += w;
            }

            return res;
        }
        private void Append(ref string[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = word;
        }
    }
}
