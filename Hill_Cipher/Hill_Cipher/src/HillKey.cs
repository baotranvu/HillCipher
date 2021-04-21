using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hill_Cipher
{
    public  class HillKey:Matrix
    {
        public Matrix_Int matrix_int;

        public HillKey(int n) : base(n)
        {
            this.size_matrix = n;
            matrix_int = new Matrix_Int(size_matrix);
        }

        
        /// <summary>
        /// Check d * (d)^(-1) == 1 module 26
        /// </summary>
        /// <returns></returns>
        public bool IsValidMatrix()
        {
            //Caculate value
            //if value * det(matrix) = 1 module 26
            int value = matrix_int.Multiplicative_Inverse();
            //caculator determinant module 26
            int det = matrix_int.Determinant() * value;
            if (det < 0) det = (det + (((Math.Abs(det) / 26) + 1) * 26)) % 26;
            if (det % 26 == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Set value for matrix int and update matrix char
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void SetValueInt(int i, int j, int value)
        {
            matrix_int.Set(i, j, value);
            //update matrix char
            char c = Alphabet.getChar(value+1); //in hill A start index 0
            Set(i, j, c);
        }

        /// <summary>
        /// Set value for matrix char and update matrix int
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void SetValueChar(int i, int j, char value)
        {
            char c = value.ToString().ToUpper()[0];
            base.Set(i, j, c);
            matrix_int.Set(i, j, Alphabet.getPosition(c) - 1);
        }
    }
}

