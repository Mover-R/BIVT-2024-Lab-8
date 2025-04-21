using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output = null;
        private (string, char)[] _codes = new (string, char)[5];
        private int _index = 0;
        public string Output => _output;
        private (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                return ((string, char)[])_codes.Clone();
            }
        }

        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _codes = codes;
        }
        public override void Review()
        {
            string uncompressed = Input;
            foreach (var c in _codes)
            {
                //Console.WriteLine($"{c.Item1}   {c.Item2}");
                uncompressed = uncompressed.Replace(c.Item2.ToString(), c.Item1);
            }
            _output = uncompressed;
        }
        public override string ToString()
        {
            return _output;
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
