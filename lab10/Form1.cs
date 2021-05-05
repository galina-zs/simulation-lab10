using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {

        //Пусть центр тяжести игрального кубика смещён на 6
        //Тогда пусть ряд распределения:
        //
        //    x | 1     2       3       4       5       6
        //    p | 0.05  0.1625  0.1625  0.1625  0.1625  0.3

        readonly double[] probabilitis = new double[6] { 0.05, 0.1625, 0.1625, 0.1625, 0.1625, 0.3 };

        double U = 1;
        const int p = 5087; // большое простое число
        int M = 2900;       // M = p - 3^n. Берем n = 7, потому что 3^8 > p
        double R;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Generator();
            double tempR = R;
            for (int i = 0; i < probabilitis.Length; i++)
            {
                tempR -= probabilitis[i];
                if (tempR <= 0)
                {
                    answerLabel.Text = (i + 1).ToString();
                    break;
                }
            }
        }

        private void Generator() // метод вычетов. Модификация Коробова
        {
            R = U / p;
            U = (U * M) % p;
        }
    }
}
