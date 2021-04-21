using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hill_Cipher
{
    public static  class Alphabet
    {
        public static int getPosition(char c)
        {
            return (int)c - 64;
        }
        public static char getChar(int x)
        {
            return (char)(x + 64);
        }
        public static char Seed(int currentPos, int offset)
        {
            int c = (currentPos + offset) % 26;
            return (char)(c + 64);
        }
        public static string toList()
        {
            string str = null;
            for (int i = 0; i < 26; i++)
            {
                str += (char)(65 + i);
            }
            return str;
        }
    }
    
    
}
