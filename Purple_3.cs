using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output = null;
        private (string, char)[] _codes = new (string, char)[5];
        private int _index = 0;
        public string Output => _output;
        public (string, char)[] Codes
        {
            get {
                if (_codes == null) return null;
                return ((string, char)[])_codes.Clone();
            }
        }

        public Purple_3(string input) : base(input) { 
            (string, char)[] _codes = new (string, char)[5];
        }
        public override void Review()
        {
            if (_index >= 5) return;
            string s = Input;
            string[] topPairs = CntPair(Input);

            for (int i = 32; i<=126; i++)
            {
                if (s.IndexOf((char)i) == -1)
                {
                    if (_index >= 5) break;
                    _codes[_index] = (topPairs[_index], (char)i);
                    _index++;
                }
            }
            _output = Compress();
        }
        public override string ToString()
        {
            return Compress();
        }
        private string Compress()
        {
            string compressed = Input;
            foreach (var c in _codes)
            {
                //Console.WriteLine($"{c.Item1}   {c.Item2}");
                compressed = compressed.Replace(c.Item1, c.Item2.ToString());
            }

            return compressed;
        }
        private string[] CntPair(string s)
        {
            var topPairs = Enumerable.Range(0, s.Length - 1)
                .Select(i => s.Substring(i, 2))
                .Where(let => char.IsLetter(let[0]) && char.IsLetter(let[1]))
                .GroupBy(p => p)
                .OrderByDescending(g => g.Count())
                .ThenBy(ind => s.IndexOf(ind.Key))
                .Select(g => g.Key)
                .Take(5)
                .ToArray();
            return topPairs;
        }
        private void Append(ref string[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = word;
        }
    }
}
