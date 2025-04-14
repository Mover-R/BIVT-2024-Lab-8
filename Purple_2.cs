using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output = null;
        private string _tostring = null;
        private int _len = 50;
        public string[] Output
        {
            get
            {
                return _output;
            }
        }
        public Purple_2(string input) : base(input) { }
        public override void Review()
        {
            string[] s = ToArray();
            _output = s;
                string res = "";
                foreach (string w in s)
                {
                    //Console.WriteLine(w);
                    res += (w + "\r\n");
                }
                //res =  res.Substring(0, res.Length - 4);
                _tostring = res;
        }
        public override string ToString()
        {
            return _tostring;
        }
        public string[] ToArray()
        {
            string s = Input;
            string[] words = Words(s);
            string[] res = new string[0];
            string[] now = new string[0];
            int cnt = 0;
            foreach (string word in words)
            {
                if (now.Length == 0)
                {
                    Append(ref now, word);
                    cnt += word.Length;
                    continue;
                }
                if (cnt + word.Length + 1 <= _len)
                {
                    Append(ref now, word);
                    cnt+= word.Length + 1;
                } 
                else
                {
                    Append(ref res, Normalize(now));
                    now = new string[0]; cnt = 0; 
                    Append(ref now, word);
                    cnt += word.Length;
                }
            }
            //Append(ref res, string.Join(" ", now));
            //foreach (string word in now) Console.WriteLine($"{word}  {word.Length}");
            Append(ref res, Normalize(now));
            //Console.WriteLine(Normalize(now));

            return res;
        }
        private string Normalize(string[] s)
        {
            int cnt = s.Length;
            int len = 0;
            foreach (string word in s) len += word.Length;
            int need = _len - len;
            if (cnt == 1)
            {
                var r = new StringBuilder();
                foreach (var word in s)
                {
                    r.Append(word);
                    r.Append(new string(' ', need));
                }
                return r.ToString();
            }
            //foreach (string word in s) Console.WriteLine(word);
            int basic = need / (cnt - 1), extra = need % (cnt - 1);
            //Console.WriteLine($"{len},  {_len}, {cnt},  {need}, {basic}, {extra}");
            var res = new StringBuilder();
            foreach (var word in s)
            {
                res.Append(word);
                res.Append(new string(' ', basic + (extra <= 0 ? 0 : 1)));
                extra--;
            }
            return res.ToString();
        }
        private string[] Words(string s)
        {
            string[] words = new string[0];
            string word = "";
            foreach (var letter in s)
            {
                if (letter == ' ' || letter == '\n' || letter == '\r')
                {
                    if (word.Length > 0) Append(ref words, word);
                    word = "";
                }
                else
                {
                    word += letter;
                }
            }
            if (word.Length > 0) Append(ref words, word);
            return words;
        }
        private void Append(ref string[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = word;
        }

    }
}
