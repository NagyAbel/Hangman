using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace NagyAbel.Utils
{
    public static class Globals
    {
        public const int normal = 70;
        public const int fast = 40;
        public const int slow = 100;


        public static int lettersToReveal(int length)
        {
            if (length <= 3)
                return 0;
            else if (length <= 5)
                return 1;
            else if (length <= 8)
                return 2; 
            else
                return 3;
        }

    }
}
