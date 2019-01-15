using System;
using System.Collections.Generic;
using System.Text;

namespace CheckCanadaSIN
{
    class CheckSINTrue
    {
        public Boolean checkSIN(List<int> intArr)
        {
            int b = intArr[0] + intArr[2] + intArr[4] + intArr[6];
            int b1 = intArr[1] + intArr[1];
            int b2 = intArr[3] + intArr[3];
            int b3 = intArr[5] + intArr[5];
            int b4 = intArr[7] + intArr[7];
            int c1 = b1 / 10 + b1 % 10;
            int c2 = b2 / 10 + b2 % 10;
            int c3 = b3 / 10 + b3 % 10;
            int c4 = b4 / 10 + b4 % 10;
            int sum = b + c1 + c2 + c3 + c4 + intArr[8];
            if(sum%10 == 0)
            {
                return true;
            } else
            {
                return false;
            }

        }
    }
}
