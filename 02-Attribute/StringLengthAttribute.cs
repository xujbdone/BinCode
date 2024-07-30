using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Attribute
{
    public class StringLengthAttribute : Attribute
    {
        private int _maxLenth;

        public StringLengthAttribute(int maxStringLength)
        {
            _maxLenth = maxStringLength;
        }

        public int MaxNumLength
        {
            get
            {
                return _maxLenth;
            }
        }
    }
}
