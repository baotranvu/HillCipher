using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hill_Cipher
{
    public class Matrix
    {
        public char[,] matrix;
        public int size_matrix;

        public Matrix(int n)
        {
            size_matrix = n;
            matrix = new char[size_matrix, size_matrix];

        }
        public char Get(int i,int j)
        {
            return matrix[i, j];
        }
        public char Get(Coordinate cor)
        {
            return matrix[cor.I, cor.J];
        }
        
        public void Set(int i ,int j, char value)
        {
            matrix[i, j] = value.ToString().ToUpper()[0];
        }

    }
}
