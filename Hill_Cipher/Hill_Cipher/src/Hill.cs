using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
namespace Hill_Cipher
{
    public class Hill
    {
        public string Data;
        public HillKey Matrix;
        public Hill(int n)
        {
            this.Matrix = new HillKey(n);
        }
        private bool Validate()
        {
            //convert lower to upper character
            Data = Data.ToUpper();
            //delete whitespace in data
            int i = 0;
            while (i < Data.Length)
            {
                if (Data[i] == ' ')
                {
                    Data = Data.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

            //add 'Z' character 
            i = Data.Length % Matrix.size_matrix;
            if (i != 0) //don't enough character
            {
                for (int j = 1; j <= Matrix.size_matrix - i; i++)
                {
                    Data = Data.Insert(Data.Length, "Z");
                }
            }
            return true;
        }



        public char[] Encrypt_N_Char(char[] n_char)

        {
            
                int i = 0;
                List<char> data_return = new List<char>();
                while (i < Matrix.size_matrix)
                {

                    int j = 0, temp = 0;
                    while (j < Matrix.size_matrix)
                    {

                        temp += (Alphabet.getPosition(n_char[j]) - 1) * Matrix.matrix_int.Get(i, j); //A = 0
                        j++;
                    }
                    data_return.Add(Alphabet.getChar(temp % 26 + 1));
                    i++;
                }
                return data_return.ToArray();
         
            
               
            
        }
        public char[] Decrypt_N_Char(char[] n_char)
        {
            
                int i = 0;
                List<char> data_return = new List<char>();
                while (i < Matrix.size_matrix)
                {

                    int j = 0, temp = 0;
                    while (j < Matrix.size_matrix)
                    {

                        temp += (Alphabet.getPosition(n_char[j]) - 1) * Matrix.matrix_int.GetInverse(i, j);
                        j++;
                    }
                    data_return.Add(Alphabet.getChar(temp % 26 + 1));
                    i++;
                }
                return data_return.ToArray();
            
            
                
            }



        /// <summary>
        /// Encrypt plain text
        /// </summary>
        /// <returns>cypher text</returns>
        public string Encrypt()
        {
            
                int i = 0;
                string data_return = "";
                while (i < Data.Length)
                {
                    //encrypt one-to-one group character
                    string x = Data.Substring(i, Matrix.size_matrix);
                    char[] encrypt_n_char = Encrypt_N_Char(x.ToCharArray());
                    foreach (char temp in encrypt_n_char)
                    {
                        data_return += temp;
                    }
                    i += Matrix.size_matrix;
                }
                return data_return;
            }
           
        
        public string Decrypt()
        {
            bool check = this.Matrix.IsValidMatrix();
            if (check)
            {
                int i = 0;
                string data_return = "";
                while (i < Data.Length)
                {
                    //encrypt one-to-one group character
                    string x = Data.Substring(i, Matrix.size_matrix);
                    char[] Decrypt_n_char = Decrypt_N_Char(x.ToCharArray());
                    foreach (char temp in Decrypt_n_char)
                    {
                        data_return += temp;
                    }
                    i += Matrix.size_matrix;
                }
                return data_return;
            }
            else
            {
                XtraMessageBox.Show("Invalid Matrix");
                return null;
            }
        }

        public void SetData(string value)
        {
            Data = value;
            if (!Validate())
            {
                Data = "";
                throw new Exception("Error when validate Plain Text");
            }
        }

    }
}
    



