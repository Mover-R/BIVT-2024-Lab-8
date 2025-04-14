using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    abstract class Purple
    {
        private string _input;
        protected char[] _separators = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        protected char[] _digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public string Input { get { return _input; } }
        public Purple(string input)
        {
            _input = input;
        }
        //

        protected bool IsSeparator(char c)
        {
            foreach(var s  in _separators) if (s == c) return true;
            return false;
        }
        protected bool HasDigit(string s)
        {
            foreach (var c in s) foreach(var d in _digits) if (d == c) return true;
            return false;
        }

        public abstract void Review();
        public abstract string ToString();
    }
}
