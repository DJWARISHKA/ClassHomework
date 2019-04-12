using System.Text;

namespace ClassHomework
{
    internal class MyString
    {
        private StringBuilder _Line;
        private int n;

        public int Length { get => n; }

        public string Line
        {
            get => _Line.ToString();
            set
            {
                _Line = new StringBuilder(value);
                n = value.Length;
            }
        }

        public MyString(string str)
        {
            _Line = new StringBuilder(str, str.Length);
            n = str.Length;
        }

        public MyString(MyString str)
        {
            _Line = new StringBuilder(str.Line.Length);
            _Line = _Line.Append(str.Line);
            n = str.Length;
        }

        public MyString(StringBuilder str)
        {
            _Line = new StringBuilder(str.MaxCapacity);
            _Line = _Line.Append(str);
            n = str.MaxCapacity;
        }

        public MyString(string str, int length)
        {
            _Line = new StringBuilder(str, length);
            n = str.Length;
        }

        public int SpaceCount()
        {
            return _Line.ToString().Split(' ').Rank - 1;
        }

        public string ToLower()
        {
            return _Line.ToString().ToLower();
        }

        public string DelSigns()
        {
            for (int i = 0; i < n; i++)
                if (_Line[i] != '.' && _Line[i] != ',' && _Line[i] != '!' && _Line[i] != '?')
                    _Line = _Line.Append(_Line[i]);
            return _Line.ToString();
        }
    }
}