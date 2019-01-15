using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CheckCanadaSIN
{
    class ConvertIntToList
    {
        public List<int> ConvertToList(int a)
        {
            List<int> digits = new List<int>();
            for (; a != 0; a /= 10)
            {
                digits.Add(a % 10);
            }
            digits.Reverse();
            return digits;
        }
    }
}
