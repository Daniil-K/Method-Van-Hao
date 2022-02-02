using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Van_Hao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prov = textBox2.Text;
            string prov1 = textBox1.Text;
            int flag = 0;
            int flag1 = 0;
            int index = 0;
            for (int i = 0; i < prov.Length; i++)
            {
                if (prov[i] == '&' || prov[i] == '>')
                    flag = 1;
            }
            for (int i = 0; i < prov1.Length; i++)
            {
                if (prov1[i] == '>')
                {
                    flag1 = 1;
                    index = i;
                }
            }
            if (flag1 == 1)
            {
                MessageBox.Show("В поле 'Дано' не должно быть импликаций", "Ошибка");
                textBox1.Text = prov1.Replace('>', ',').Remove(index - 1, 1);
            }
            if (flag == 1)
            {
                MessageBox.Show("В поле 'Вывести' не должно быть конъюнкций и импликаций", "Ошибка");
                textBox2.Text = "";
            }
            else
            {
                Form2 newForm = new Form2();
                Form2.dano = textBox1.Text;
                Form2.resh = textBox2.Text;
                newForm.Show();
            }
            //this.Hide();
        }
    }
}
