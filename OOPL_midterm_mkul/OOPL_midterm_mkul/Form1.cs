// MIDTERM
// OOPL for Programmers - Spring 2020
//
// This program creates a user interface to perform encryption and decryption 
// 
// by Marisha Kulseng
// March 31, 2020

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPL_midterm_mkul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            tb_input.Text = "";
            tb_output.Text = "";
        }

        private void bt_encrypt_Click(object sender, EventArgs e)
        {
            if(isValidInput(tb_input.Text))
                tb_output.Text = encryptInput(tb_input.Text);
        }

        private void bt_decrypt_Click(object sender, EventArgs e)
        {
            if(isValidInput(tb_input.Text))
                tb_output.Text = decryptInput(tb_input.Text);
        }


        static bool isValidInput(string data)
        {
            int test;
            bool isNotInt = false, isNotCorrectSize = false, 
                isEmpty = false, showError = false;
            string errorMsg = "";

            if (data.Equals(""))
            {
                isEmpty = true;
                showError = true;
            }
            if (!Int32.TryParse(data, out test)) {
                isNotInt = true;
                showError = true;
            }
            if (data.Length != 4)
            {
                isNotCorrectSize = true;
                showError = true;
            }

            if (showError)
            {
                if (isEmpty)
                {
                    errorMsg += (isEmpty ? " NOT be empty" : "");
                }
                else {                    
                    errorMsg += (isNotInt ? " be NUMERIC" : "");
                    errorMsg += (isNotCorrectSize ? " be FOUR digits" : "");
                }
                                               
                MessageBox.Show("Input must" + errorMsg + "!", "Error");

                //cleanup section
                showError = false;
                return false;
            }
            return true;
        }

        static int encryptDigit(int n)
        {
            return ((n + 7) % 10);
        }

        static int decryptDigit(int n)
        {
            return ((n + 3) % 10);
        }

        static string changeOrder(string data) // works as expected
        {
            string result = "";
            result = data[2].ToString() + data[3].ToString() + data[0].ToString() + data[1].ToString();
            return result;
        }

        static int parseInt(string data, int position)
        {
            return data[position] - '0';
        }

        static char convertToChar(int num)
        {
            return (char)(num + '0');
        }

        static string encryptInput(string data)
        {
            string result = "";
            int tempInt;
            string newOrder = changeOrder(data);

            for (int i = 0; i < 4; i++)
            {
                tempInt = encryptDigit(parseInt(newOrder, i));
                result += tempInt;
            }
            return result;
        }

        static string decryptInput(string data)
        {
            string result = "";
            int tempInt;
            string newOrder = changeOrder(data);

            for (int i = 0; i < 4; i++)
            {
                tempInt = decryptDigit(parseInt(newOrder, i));
                result += tempInt;
            }
            return result;
        }




    }
}
