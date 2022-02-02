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
    public partial class Form2 : Form
    {
        public static string dano, resh;
        public static string spl_str;
        List<string> list = new List<string>();
        //string[] spl = new string[dano.Length];
        int dis = 0;
        int con = 0;
        int dis_tmp = 0;
        int zap = 0;
        int flag = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dano = dano.Replace(" &", ",").Replace("(","").Replace(")", "").Replace(" ","");
            resh = resh.Replace("v", ",").Replace("(", "").Replace(")", "").Replace(" ", "");
            list.Add(dano);
            System.Console.WriteLine("Начальная строка: " + dano +  resh);
            Label par = new Label();
            par.Size = new Size(100, 30);
            par.Font = new Font("Tobota", 9, FontStyle.Regular);
            par.Text = Convert.ToString(dano + " -> " + resh);
            par.TextAlign = ContentAlignment.TopCenter;
            this.tableLayoutPanel1.Controls.Add(par, 1, 0);
            for (int i = 0; i < dano.Length; i++)
                if (dano[i] == 'v')
                    dis++;
            for (int i = 0; i < dano.Length; i++)
            {
                if (dano[i] == ',')
                    zap++;
            }
            this.tableLayoutPanel1.RowCount = dis;
            this.tableLayoutPanel1.ColumnCount = dis;
            string[] tmp = new string[zap + 1];
            string str_zap = "";
            System.Console.WriteLine(1 + " уровень: ");
            System.Console.WriteLine(list[0]);
            int del = 0;
            int col = -1;
            for (int i = 0; i < list.Count; i++)
            {
                tmp = list[i].Split(',');
                for (int k = 0; k < tmp.Length; k++)
                {
                    dis_tmp = 0;
                    if (tmp[k].Contains('v'))
                    {
                        //System.Console.WriteLine(col.ToString() + " колонка последняя: ");
                        System.Console.WriteLine((k + 1).ToString() +  " уровень: ");
                        string str_tmp = tmp[k];
                        for (int z = 0; z < str_tmp.Length; z++)
                            if (str_tmp[z] == 'v')
                                dis_tmp++;
                        string[] s1 = new string[dis_tmp];
                        s1 = tmp[k].Split('v');
                        for (int p = 0; p < s1.Length; p++)
                        {
                            string rez_tmp = resh;
                            str_zap = "";
                            for (int j = 0; j < tmp.Length; j++)
                            {
                                string s_tmp = s1[p];
                                string s1_tmp = tmp[j];
                                if (j == k)
                                {
                                    if (k == tmp.Length - 1)
                                    {
                                        if (s_tmp.Contains('-') && !s_tmp.Contains('v'))
                                        {
                                            for (int pp = 0; pp < s1[p].Length; pp++)
                                            {
                                                if (s1[p].ElementAt(pp) == '-')
                                                {
                                                    rez_tmp += "," + s1[p].ElementAt(pp + 1);
                                                    s_tmp = s_tmp.Remove(pp, s1[p].Length);
                                                }
                                            }
                                        }
                                        else
                                            str_zap += s1[p] + ",";
                                    }
                                    else
                                        str_zap += s1[p] + ",";
                                }
                                else
                                {
                                    if (k == tmp.Length - 1)
                                    {
                                        if (tmp[j].Contains('-') && !tmp[j].Contains('v'))
                                        {
                                            for (int pp = 0; pp < tmp[j].Length; pp++)
                                            {
                                                if (tmp[j].ElementAt(pp) == '-')
                                                {
                                                    rez_tmp += "," + tmp[j].ElementAt(pp + 1);
                                                    s1_tmp = s1_tmp.Remove(pp, tmp[j].Length);
                                                }
                                            }
                                        }
                                        else
                                            str_zap += tmp[j] + ",";
                                    }
                                    else
                                        str_zap += tmp[j] + ",";
                                }
                            }
                            str_zap = str_zap.Remove(str_zap.Length - 1, 1);
                            list.Add(str_zap);
                            System.Console.WriteLine("Строка замены: " + str_zap + " -> " + rez_tmp);
                            if (k != tmp.Length - 1)
                            {
                                Label par1 = new Label();
                                par1.Size = new Size(100, 30);
                                par1.Font = new Font("Tobota", 9, FontStyle.Regular);
                                par1.Text = Convert.ToString(str_zap + " -> " + rez_tmp);
                                par1.TextAlign = ContentAlignment.TopCenter;
                                this.tableLayoutPanel1.Controls.Add(par1, p, (k + 1));
                            }
                            else
                            {
                                Label par1 = new Label();
                                par1.Size = new Size(100, 30);
                                par1.Font = new Font("Tobota", 9, FontStyle.Regular);
                                par1.Text = Convert.ToString(str_zap + " -> " + rez_tmp);
                                par1.TextAlign = ContentAlignment.TopCenter;
                                this.tableLayoutPanel1.Controls.Add(par1, col, (k + 1 + p));
                            }
                            string str_srav = rez_tmp;
                            if (k == tmp.Length - 1)
                            {
                                for (int q = 0; q < rez_tmp.Length; q += 2)
                                {
                                    for (int qq = q + 2; qq < rez_tmp.Length; qq += 2)
                                    {
                                        if (Convert.ToInt32(rez_tmp[q]) > Convert.ToInt32(rez_tmp[qq]))
                                        {
                                            char tmp_sort_q = rez_tmp[q];
                                            char tmp_sort_qq = rez_tmp[qq];
                                            rez_tmp = rez_tmp.Replace(tmp_sort_q, 'э').Replace(tmp_sort_qq, tmp_sort_q).Replace('э', tmp_sort_qq);
                                        }
                                    }
                                }
                                for (int q = 0; q < str_zap.Length; q += 2)
                                {
                                    for (int qq = q + 2; qq < str_zap.Length; qq += 2)
                                    {
                                        if (Convert.ToInt32(str_zap[q]) > Convert.ToInt32(str_zap[qq]))
                                        {
                                            char tmp_sort_q = str_zap[q];
                                            char tmp_sort_qq = str_zap[qq];
                                            str_zap = str_zap.Replace(tmp_sort_q, 'э').Replace(tmp_sort_qq, tmp_sort_q).Replace('э', tmp_sort_qq);
                                        }
                                    }
                                }
                                if (str_zap.Equals(rez_tmp))
                                {
                                    MessageBox.Show("Решение: " + "\n" + str_zap + " -> " + rez_tmp, "Доказано");
                                    flag = 1;
                                }
                            }
                            rez_tmp = resh;
                        }
                        col++;
                        break;
                    }
                }
            }
            if (flag == 0)
                MessageBox.Show("Формула является неверной \nДоказательства нет", "Ошибка");
            /*System.Console.WriteLine("Первая строка: " + s2[0] + ", " + s2[1] + ", " + s3[1]);
            System.Console.WriteLine("Вторая строка: " + s2[0] + ", " + s3[0] + ", " + s3[1]);*/

        }
    }
}
