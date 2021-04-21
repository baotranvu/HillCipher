using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hill_Cipher.UI
{
    public partial class Encode : DevExpress.XtraEditors.XtraForm
    {
        private int Matrix_size;
        private Hill_Cipher.Hill hillcipher;
        public Encode()
        {
            InitializeComponent();
            

        }
        

            private void DrawMatrix(Hill_Cipher.Hill matrix, bool allowModifier)
        {
            //remove old item in matrix
            this.groupBox4.Controls.Clear();
            //show matrix
            var X_begin = 7;
            var Y_begin = 19;
            for (int i = 1; i <= Matrix_size; i++)
            {
                for (int j = 1; j <= Matrix_size; j++)
                {
                    TextBox txt = new TextBox();
                    txt.Location = new System.Drawing.Point(X_begin, Y_begin);
                    txt.Name = "txt" + i.ToString() + j.ToString();
                    txt.Size = new System.Drawing.Size(44, 20);
                    txt.Enabled = allowModifier;
                    txt.MaxLength = 1;
                    if (matrix != null)
                    {
                        txt.Text = hillcipher.Matrix.Get(i - 1, j - 1).ToString();
                    }
                    txt.TextChanged += Txt_TextChanged;
                    this.groupBox4.Controls.Add(txt);
                    X_begin += 52;
                }
                X_begin = 7;
                Y_begin += 32;
            }
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            var control = ((TextBox)sender);
            var name = control.Name;
            int i = Int32.Parse(name.Substring(3, 1)) - 1;
            int j = Int32.Parse(name.Substring(4, 1)) - 1;
            char c = control.Text == "" ? ' ' : control.Text.ToUpper()[0];
            hillcipher.Matrix.SetValueChar(i, j, c);        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            hillcipher.SetData(plain_txt.Text);
            var result = hillcipher.Encrypt();
            cipher_txt.Text = result;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup control = sender as RadioGroup; 
            switch (control.SelectedIndex)
            {

                case 0:
                    Matrix_size = 2;
                    break;
                case 1:
                    Matrix_size = 3;
                    break;
                case 2:
                    Matrix_size = 4;
                    break;
                case 3:
                    Matrix_size = 5;
                    break;
            }
            //init matrix
            hillcipher = new Hill_Cipher.Hill(Matrix_size);
            DrawMatrix(null, true);
        }
    }
    }
    
