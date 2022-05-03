using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Church
{
    public partial class Form1 : Form
    {
        String nf;
        String np;
        string picp;
        string[] back = new string[30];
        public Form1()
        {
            InitializeComponent();

            LoadData();

        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("О программе");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла

            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;

                    nf = Path.GetFileName(open_dialog.FileName);
                    np = @Environment.CurrentDirectory + @"\res\" + nf;
                    System.IO.File.Copy(open_dialog.FileName, np);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")|| (textBox2.Text == "")|| (textBox3.Text == ""))
            {
                MessageBox.Show("Форма не заполнена");
            }
            else
            {

                using (var connection = new SqliteConnection("Data Source=book.db"))
                {
                    connection.Open();

                    string pic = nf;
                    string f = textBox1.Text;
                    string i = textBox2.Text;
                    string o = textBox3.Text;
                    string b = Convert.ToString(dateTimePicker1.Value.ToString("yyyy-MM-dd"));                   
                    string s;
                    if (radioButton1.Checked == true) { s = "M"; } else { s = "F"; }
                    string fam = comboBox1.Text;
                    string famd;
                    if (comboBox1.Text== "Не женат/Не замужем") { famd = null; } else { famd = Convert.ToString(dateTimePicker7.Value.ToString("yyyy-MM-dd")); }                        
                    string city = textBox4.Text;
                    string adr = textBox5.Text;
                    string pho = textBox6.Text;
                    string em = textBox7.Text;
                    string dr;                  
                    if (checkBox2.Checked == false) { dr = Convert.ToString(dateTimePicker2.Value.ToString("yyyy-MM-dd")); } else { dr = null; }                        
                    string dm = null;
                    string dk;
                    if (checkBox3.Checked == false) { dk = Convert.ToString(dateTimePicker3.Value.ToString("yyyy-MM-dd")); } else { dk = null; }
                    string df;
                    if (checkBox6.Checked == false) { df = Convert.ToString(dateTimePicker10.Value.ToString("yyyy-MM-dd")); } else { df = null; }
                    string fiok = textBox8.Text;
                    string gr = textBox9.Text;
                    string lgr = textBox10.Text;
                    string serv = comboBox2.Text;

                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO chucrh (PIC, F,I,O,BORN,CITY,ADRES,PHONE,EMAIL,MALE,MARY,MARYDATE,REG,DATEFIRTST,DATEMEM,BAPT,BAPTER,GRUP,CHEIF,SERVICE) " +
           "VALUES ('" + pic + "','" + f + "','" + i + "','" + o + "','" + b + "','" + city + "','" + adr + "','" + pho + "','" + em + "','" + s + "','" + fam + "','" + famd + "','" + dr + "','" + df + "','" + dm + "','" + dk + "','" + fiok + "','" + gr + "','" + lgr + "','" + serv + "')";
                    command.ExecuteNonQuery();

                    MessageBox.Show("Зарегистрирован");

                    connection.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "Владивосток";
                    textBox5.Text = "";
                    textBox6.Text = "+7";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                }
            }
        }

        private void LoadData()
        {
            string sqlExpression = "SELECT * FROM chucrh";

            using (var connection1 = new SqliteConnection("Data Source=book.db"))
            {
                connection1.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection1);

                List<string[]> data = new List<string[]>();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            data.Add(new string[21]);

                            data[data.Count - 1][0] = reader[0].ToString();
                            data[data.Count - 1][1] = reader[1].ToString();
                            data[data.Count - 1][2] = reader[2].ToString();
                            data[data.Count - 1][3] = reader[3].ToString();
                            data[data.Count - 1][4] = reader[4].ToString();
                            data[data.Count - 1][5] = reader[5].ToString();
                            data[data.Count - 1][6] = reader[6].ToString();
                            data[data.Count - 1][7] = reader[7].ToString();
                            data[data.Count - 1][8] = reader[8].ToString();
                            data[data.Count - 1][9] = reader[9].ToString();
                            data[data.Count - 1][10] = reader[10].ToString();
                            data[data.Count - 1][11] = reader[11].ToString();
                            data[data.Count - 1][12] = reader[12].ToString();
                            data[data.Count - 1][13] = reader[13].ToString();
                            data[data.Count - 1][14] = reader[14].ToString();
                            data[data.Count - 1][15] = reader[15].ToString();
                            data[data.Count - 1][16] = reader[16].ToString();
                            data[data.Count - 1][17] = reader[17].ToString();
                            data[data.Count - 1][18] = reader[18].ToString();
                            data[data.Count - 1][19] = reader[19].ToString();
                            data[data.Count - 1][20] = reader[20].ToString();
                        }

                        reader.Close();

                        connection1.Close();

                        foreach (string[] s in data)
                            dataGridView1.Rows.Add(s);
                    }
                }
            }

            //
            string sqlExpression2 = "SELECT * FROM thelost";
            using (var connection2 = new SqliteConnection("Data Source=book.db"))
            {
                connection2.Open();

                SqliteCommand command2 = new SqliteCommand(sqlExpression2, connection2);

                List<string[]> data2 = new List<string[]>();

                using (SqliteDataReader reader2 = command2.ExecuteReader())
                {
                    if (reader2.HasRows) // если есть данные
                    {
                        while (reader2.Read())   // построчно считываем данные
                        {
                            data2.Add(new string[24]);

                            data2[data2.Count - 1][0] = reader2[0].ToString();
                            data2[data2.Count - 1][1] = reader2[1].ToString();
                            data2[data2.Count - 1][2] = reader2[2].ToString();
                            data2[data2.Count - 1][3] = reader2[3].ToString();
                            data2[data2.Count - 1][4] = reader2[4].ToString();
                            data2[data2.Count - 1][5] = reader2[5].ToString();
                            data2[data2.Count - 1][6] = reader2[6].ToString();
                            data2[data2.Count - 1][7] = reader2[7].ToString();
                            data2[data2.Count - 1][8] = reader2[8].ToString();
                            data2[data2.Count - 1][9] = reader2[9].ToString();
                            data2[data2.Count - 1][10] = reader2[10].ToString();
                            data2[data2.Count - 1][11] = reader2[11].ToString();
                            data2[data2.Count - 1][12] = reader2[12].ToString();
                            data2[data2.Count - 1][13] = reader2[13].ToString();
                            data2[data2.Count - 1][14] = reader2[14].ToString();
                            data2[data2.Count - 1][15] = reader2[15].ToString();
                            data2[data2.Count - 1][16] = reader2[16].ToString();
                            data2[data2.Count - 1][17] = reader2[17].ToString();
                            data2[data2.Count - 1][18] = reader2[18].ToString();
                            data2[data2.Count - 1][19] = reader2[19].ToString();
                            data2[data2.Count - 1][20] = reader2[20].ToString();
                            data2[data2.Count - 1][21] = reader2[21].ToString();
                            data2[data2.Count - 1][22] = reader2[22].ToString();
                            data2[data2.Count - 1][23] = reader2[23].ToString();

                        }

                        reader2.Close();

                        connection2.Close();

                        foreach (string[] s2 in data2)
                            dataGridView2.Rows.Add(s2);
                    }
                }
            }

        }

            private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label36.Text = "Запись по ID: ";
            label20.Text = "Фамилия: ";
            label21.Text = "Имя: ";
            label22.Text = "Отчество: ";
            label23.Text = "Дата рождения: ";
            label24.Text = "Пол: ";
            label25.Text = "Семейное положение: ";
            label26.Text = "Город: ";
            label27.Text = "Адрес: ";
            label28.Text = "Телефон: ";
            label29.Text = "Email: ";
            label30.Text = "Дата регистрации: ";
            label31.Text = "Дата крещения: ";
            label32.Text = "Креститель: ";
            label33.Text = "Группа: ";
            label34.Text = "Лидер группы: ";
            label35.Text = "Служение: ";
            label58.Text = "Дата свадьбы: ";
            label60.Text = "Дата членства: ";
            label86.Text = "Дата первого посещения: ";


            panel1.Visible = true;

            if (radioButton3.Checked==true)
            {
                string sqlExpression = "SELECT * FROM chucrh WHERE id='" + Convert.ToInt32(textBox11.Text) + "'";

                using (var connection2 = new SqliteConnection("Data Source=book.db"))
                {
                    connection2.Open();

                    SqliteCommand command = new SqliteCommand(sqlExpression, connection2);
                  

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {                               
                                label36.Text += reader[0].ToString();                             
                                
                                label20.Text += reader[2].ToString();
                                label21.Text += reader[3].ToString();
                                label22.Text += reader[4].ToString();
                                label23.Text += reader[5].ToString();
                                label24.Text += reader[10].ToString();
                                label25.Text += reader[11].ToString();
                                label58.Text += reader[12].ToString();
                                label26.Text += reader[6].ToString();
                                label27.Text += reader[7].ToString();
                                label28.Text += reader[8].ToString();
                                label29.Text += reader[9].ToString();
                                label86.Text += reader[14].ToString();
                                label30.Text += reader[13].ToString();
                                label60.Text += reader[15].ToString();
                                label31.Text += reader[16].ToString();
                                label32.Text += reader[17].ToString();
                                label33.Text += reader[18].ToString();
                                label34.Text += reader[19].ToString();
                                label35.Text += reader[20].ToString();
                                


                                try
                                {
                                    pictureBox2.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader[1].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader[1].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }
                            }

                            reader.Close();

                            connection2.Close();

                        }
                    }
                }
            }

            if (radioButton4.Checked==true)
            {
                string sqlExpression = "SELECT * FROM chucrh WHERE F='" + textBox11.Text + "'";

                using (var connection2 = new SqliteConnection("Data Source=book.db"))
                {
                    connection2.Open();

                    SqliteCommand command = new SqliteCommand(sqlExpression, connection2);


                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {

                                label36.Text += reader[0].ToString();

                                label20.Text += reader[2].ToString();
                                label21.Text += reader[3].ToString();
                                label22.Text += reader[4].ToString();
                                label23.Text += reader[5].ToString();
                                label24.Text += reader[10].ToString();
                                label25.Text += reader[11].ToString();
                                label58.Text += reader[12].ToString();
                                label26.Text += reader[6].ToString();
                                label27.Text += reader[7].ToString();
                                label28.Text += reader[8].ToString();
                                label29.Text += reader[9].ToString();
                                label86.Text += reader[14].ToString();
                                label30.Text += reader[13].ToString();
                                label60.Text += reader[15].ToString();
                                label31.Text += reader[16].ToString();
                                label32.Text += reader[17].ToString();
                                label33.Text += reader[18].ToString();
                                label34.Text += reader[19].ToString();
                                label35.Text += reader[20].ToString();

                                try
                                {
                                    pictureBox2.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader[1].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader[1].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }
                            }

                            reader.Close();

                            connection2.Close();

                        }
                    }
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {           

            label56.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";                     
            comboBox3.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";        
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            comboBox4.Text = "";

            panel2.Visible = true;

            if (radioButton5.Checked == true)
            {
                string sqlExpression = "SELECT * FROM chucrh WHERE id='" + Convert.ToInt32(textBox12.Text) + "'";

                using (var connection3 = new SqliteConnection("Data Source=book.db"))
                {
                    connection3.Open();

                    SqliteCommand command = new SqliteCommand(sqlExpression, connection3);


                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        string sex;                       
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {
                             
                                label56.Text = reader[0].ToString();
                                picp = reader[1].ToString();

                                textBox13.Text += reader[2].ToString();
                                textBox14.Text += reader[3].ToString();
                                textBox15.Text += reader[4].ToString();
                                dateTimePicker4.Text = reader[5].ToString();  

                                sex = reader[10].ToString();
                                if (sex== "M") { radioButton7.Checked = true; }
                                if (sex == "F") { radioButton8.Checked = true; }

                                comboBox3.Text += reader[11].ToString();                              
                                dateTimePicker8.Text = reader[12].ToString();                           
                                textBox16.Text += reader[6].ToString();
                                textBox17.Text += reader[7].ToString();
                                textBox18.Text += reader[8].ToString();
                                textBox19.Text += reader[9].ToString();

                                string dt11 = reader[14].ToString();
                                if (dt11 == "") { checkBox7.Checked = true; } else { checkBox7.Checked = false; }
                                dateTimePicker11.Text = reader[14].ToString();

                                string dt5 = reader[13].ToString();
                                if (dt5 == "") { checkBox4.Checked = true; } else { checkBox4.Checked = false; }
                                dateTimePicker5.Text = reader[13].ToString();

                                string mem= reader[15].ToString();
                                if (mem=="") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
                                dateTimePicker9.Text = reader[15].ToString();

                                string dt6 = reader[16].ToString();
                                if (dt6 == "") { checkBox5.Checked = true; } else { checkBox5.Checked = false; }
                                dateTimePicker6.Text = reader[16].ToString();

                                textBox20.Text += reader[17].ToString();
                                textBox21.Text += reader[18].ToString();
                                textBox22.Text += reader[19].ToString();
                                comboBox4.Text += reader[20].ToString();

                                try
                                {
                                    pictureBox3.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader[1].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader[1].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }
                            }

                            reader.Close();

                            connection3.Close();

                        }
                    }
                }
            }

            if (radioButton6.Checked == true)
            {
                string sqlExpression = "SELECT * FROM chucrh WHERE F='" + textBox12.Text + "'";

                using (var connection3 = new SqliteConnection("Data Source=book.db"))
                {
                    connection3.Open();

                    SqliteCommand command = new SqliteCommand(sqlExpression, connection3);


                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        string sex;
                        if (reader.HasRows) // если есть данные
                        {
                            while (reader.Read())   // построчно считываем данные
                            {
                                label56.Text = reader[0].ToString();
                                picp = reader[1].ToString();

                                textBox13.Text += reader[2].ToString();
                                textBox14.Text += reader[3].ToString();
                                textBox15.Text += reader[4].ToString();
                                dateTimePicker4.Text = reader[5].ToString();

                                sex = reader[10].ToString();
                                if (sex == "M") { radioButton7.Checked = true; }
                                if (sex == "F") { radioButton8.Checked = true; }

                                comboBox3.Text += reader[11].ToString();
                                dateTimePicker8.Text = reader[12].ToString();
                                textBox16.Text += reader[6].ToString();
                                textBox17.Text += reader[7].ToString();
                                textBox18.Text += reader[8].ToString();
                                textBox19.Text += reader[9].ToString();

                                string dt11 = reader[14].ToString();
                                if (dt11 == "") { checkBox7.Checked = true; } else { checkBox7.Checked = false; }
                                dateTimePicker11.Text = reader[14].ToString();

                                string dt5 = reader[13].ToString();
                                if (dt5 == "") { checkBox4.Checked = true; } else { checkBox4.Checked = false; }
                                dateTimePicker5.Text = reader[13].ToString();

                                string mem = reader[15].ToString();
                                if (mem == "") { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
                                dateTimePicker9.Text = reader[15].ToString();

                                string dt6 = reader[16].ToString();
                                if (dt6 == "") { checkBox5.Checked = true; } else { checkBox5.Checked = false; }
                                dateTimePicker6.Text = reader[16].ToString();

                                textBox20.Text += reader[17].ToString();
                                textBox21.Text += reader[18].ToString();
                                textBox22.Text += reader[19].ToString();
                                comboBox4.Text += reader[20].ToString();

                                try
                                {
                                    pictureBox3.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader[1].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader[1].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }
                            }

                            reader.Close();

                            connection3.Close();

                        }
                    }
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //
            DialogResult res = MessageBox.Show("Вы действительно хотите обновить запись?", "Подтвердите действие", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                using (var connection4 = new SqliteConnection("Data Source=book.db"))
                {
                    connection4.Open();

                    string pic = nf;
                    string f = textBox13.Text;
                    string i = textBox14.Text;
                    string o = textBox15.Text;
                    string b = Convert.ToString(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                    string s;
                    if (radioButton7.Checked == true) { s = "M"; }
                    else { s = "F"; }
                    string fam = comboBox3.Text;
                    string famd;
                    if (comboBox3.Text == "Не женат/Не замужем") { famd = null; } else { famd = Convert.ToString(dateTimePicker8.Value.ToString("yyyy-MM-dd")); }
                    string city = textBox16.Text;
                    string adr = textBox17.Text;
                    string pho = textBox18.Text;
                    string em = textBox19.Text;
                    string df;
                    if (checkBox7.Checked == false) { df = Convert.ToString(dateTimePicker11.Value.ToString("yyyy-MM-dd")); } else { df = null; }
                    string dr;
                    if (checkBox4.Checked == false) { dr = Convert.ToString(dateTimePicker5.Value.ToString("yyyy-MM-dd")); } else { dr = null; }
                    string dm;
                    if (checkBox1.Checked == false) { dm = Convert.ToString(dateTimePicker9.Value.ToString("yyyy-MM-dd")); } else { dm=null; }
                    string dk;
                    if (checkBox5.Checked == false) { dk = Convert.ToString(dateTimePicker6.Value.ToString("yyyy-MM-dd")); } else { dk = null; }
                    string fiok = textBox20.Text;
                    string gr = textBox21.Text;
                    string lgr = textBox22.Text;
                    string serv = comboBox4.Text;

                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection4;
                    command.CommandText = "UPDATE chucrh SET PIC='"+ pic +"',F='" + f + "',I='" + i + "',O='" + o + "',BORN='" + b + "',CITY='" + city + "',ADRES='" + adr + "',PHONE='" + pho + "',EMAIL='" + em + "',MALE='" + s + "',MARY='" + fam + "',MARYDATE='" + famd + "',REG='" + dr + "',DATEFIRTST='" + df + "',DATEMEM='"+dm+"',BAPT='" + dk + "',BAPTER='" + fiok + "',GRUP='" + gr + "',CHEIF='" + lgr + "',SERVICE='" + serv + "' WHERE ID= '" + label56.Text + "'";

                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись обновлена");

                    connection4.Close();
                }
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
            }
            //         
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //
            DialogResult res = MessageBox.Show("Вы действительно хотите предать его анафеме?", "Подтвердите действие", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //
                DialogResult res2 = MessageBox.Show("Введите Yes - ушел в другую церковь, No - смерть, Cancel - вероотступничество или тяжкий грех", "Причина?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res2 == DialogResult.Yes)
                {
                    using (var connection5 = new SqliteConnection("Data Source=book.db"))
                    {
                        connection5.Open();

                        //
                        string pic = picp;
                        string old = label56.Text;
                        string f = textBox13.Text;
                        string i = textBox14.Text;
                        string o = textBox15.Text;
                        string b = Convert.ToString(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                        string s;
                        if (radioButton7.Checked == true) { s = "M"; }
                        else { s = "F"; }
                        string fam = comboBox3.Text;
                        string famd;
                        if (comboBox3.Text == "Не женат/Не замужем") { famd = null; } else { famd = Convert.ToString(dateTimePicker8.Value.ToString("yyyy-MM-dd")); }
                        string city = textBox16.Text;
                        string adr = textBox17.Text;
                        string pho = textBox18.Text;
                        string em = textBox19.Text;
                        string df;
                        if (checkBox7.Checked == false) { df = Convert.ToString(dateTimePicker11.Value.ToString("yyyy-MM-dd")); } else { df = null; }
                        string dr = Convert.ToString(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                        string dm;
                        if (checkBox1.Checked == false) { dm = Convert.ToString(dateTimePicker9.Value.ToString("yyyy-MM-dd")); } else { dm = null; }
                        string dk = Convert.ToString(dateTimePicker6.Value.ToString("yyyy-MM-dd"));
                        string fiok = textBox20.Text;
                        string gr = textBox21.Text;
                        string lgr = textBox22.Text;
                        string serv = comboBox4.Text;
                        string reas = "ушел в другую церковь";
                        DateTime now = DateTime.Now;
                        string ld = now.ToString("d");
                        SqliteCommand command1 = new SqliteCommand();
                        command1.Connection = connection5;
                        

                        command1.CommandText = "INSERT INTO thelost (OLD, PIC, F,I,O,BORN,CITY,ADRES,PHONE,EMAIL,MALE,MARY,MARYDATE,REG,DATEFIRTST,DATEMEM,BAPT,BAPTER,GRUP,CHEIF,SERVICE,REASON,LOSTDATE) " +
           "VALUES ('" + old + "','" + pic + "','" + f + "','" + i + "','" + o + "','" + b + "','" + city + "','" + adr + "','" + pho + "','" + em + "','" + s + "','" + fam + "','" + famd + "','" + dr + "','" + df + "','" + dm + "','" + dk + "','" + fiok + "','" + gr + "','" + lgr + "','" + serv + "','" + reas + "','" + ld + "')";

                        command1.ExecuteNonQuery();
                        //

                        string fi = textBox13.Text;
                        string im = textBox14.Text;
                        string ot = textBox15.Text;

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection5;
                        command.CommandText = "DELETE FROM chucrh WHERE ID= '" + label56.Text + "'";

                        command.ExecuteNonQuery();

                        MessageBox.Show(fi + " " + im + " " + ot + " изгнан из церкви");

                        connection5.Close();
                    }
                }
                if (res2 == DialogResult.No)
                {
                    using (var connection5 = new SqliteConnection("Data Source=book.db"))
                    {
                        connection5.Open();

                        //
                        string pic = picp;
                        string old = label56.Text;
                        string f = textBox13.Text;
                        string i = textBox14.Text;
                        string o = textBox15.Text;
                        string b = Convert.ToString(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                        string s;
                        if (radioButton7.Checked == true) { s = "M"; }
                        else { s = "F"; }
                        string fam = comboBox3.Text;
                        string famd;
                        if (comboBox3.Text == "Не женат/Не замужем") { famd = null; } else { famd = Convert.ToString(dateTimePicker8.Value.ToString("yyyy-MM-dd")); }
                        string city = textBox16.Text;
                        string adr = textBox17.Text;
                        string pho = textBox18.Text;
                        string em = textBox19.Text;
                        string df = Convert.ToString(dateTimePicker11.Value.ToString("yyyy-MM-dd"));
                        string dr = Convert.ToString(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                        string dm;
                        if (checkBox1.Checked == false) { dm = Convert.ToString(dateTimePicker9.Value.ToString("yyyy-MM-dd")); } else { dm = null; }
                        string dk = Convert.ToString(dateTimePicker6.Value.ToString("yyyy-MM-dd"));
                        string fiok = textBox20.Text;
                        string gr = textBox21.Text;
                        string lgr = textBox22.Text;
                        string serv = comboBox4.Text;
                        string reas = "смерть";
                        DateTime now = DateTime.Now;
                        string ld = now.ToString("d");
                        SqliteCommand command1 = new SqliteCommand();
                        command1.Connection = connection5;


                        command1.CommandText = "INSERT INTO thelost (OLD, PIC, F,I,O,BORN,CITY,ADRES,PHONE,EMAIL,MALE,MARY,MARYDATE,REG,DATEFIRTST,DATEMEM,BAPT,BAPTER,GRUP,CHEIF,SERVICE,REASON,LOSTDATE) " +
           "VALUES ('" + old + "','" + pic + "','" + f + "','" + i + "','" + o + "','" + b + "','" + city + "','" + adr + "','" + pho + "','" + em + "','" + s + "','" + fam + "','" + famd + "','" + dr + "','" + df + "','" + dm + "','" + dk + "','" + fiok + "','" + gr + "','" + lgr + "','" + serv + "','" + reas + "','" + ld + "')";

                        command1.ExecuteNonQuery();
                        //

                        string fi = textBox13.Text;
                        string im = textBox14.Text;
                        string ot = textBox15.Text;

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection5;
                        command.CommandText = "DELETE FROM chucrh WHERE ID= '" + label56.Text + "'";

                        command.ExecuteNonQuery();

                        MessageBox.Show(fi + " " + im + " " + ot + " изгнан из церкви");

                        connection5.Close();
                    }

                }
                if (res2 == DialogResult.Cancel)
                {
                    using (var connection5 = new SqliteConnection("Data Source=book.db"))
                    {
                        connection5.Open();

                        //
                        string pic = picp;
                        string old = label56.Text;
                        string f = textBox13.Text;
                        string i = textBox14.Text;
                        string o = textBox15.Text;
                        string b = Convert.ToString(dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                        string s;
                        if (radioButton7.Checked == true) { s = "M"; }
                        else { s = "F"; }
                        string fam = comboBox3.Text;
                        string famd;
                        if (comboBox3.Text == "Не женат/Не замужем") { famd = null; } else { famd = Convert.ToString(dateTimePicker8.Value.ToString("yyyy-MM-dd")); }
                        string city = textBox16.Text;
                        string adr = textBox17.Text;
                        string pho = textBox18.Text;
                        string em = textBox19.Text;
                        string df = Convert.ToString(dateTimePicker11.Value.ToString("yyyy-MM-dd"));
                        string dr = Convert.ToString(dateTimePicker5.Value.ToString("yyyy-MM-dd"));
                        string dm;
                        if (checkBox1.Checked == false) { dm = Convert.ToString(dateTimePicker9.Value.ToString("yyyy-MM-dd")); } else { dm = null; }
                        string dk = Convert.ToString(dateTimePicker6.Value.ToString("yyyy-MM-dd"));
                        string fiok = textBox20.Text;
                        string gr = textBox21.Text;
                        string lgr = textBox22.Text;
                        string serv = comboBox4.Text;
                        string reas = "вероотступничество или тяжкий грех";
                        DateTime now = DateTime.Now;
                        string ld = now.ToString("d");
                        SqliteCommand command1 = new SqliteCommand();
                        command1.Connection = connection5;


                        command1.CommandText = "INSERT INTO thelost (OLD, PIC, F,I,O,BORN,CITY,ADRES,PHONE,EMAIL,MALE,MARY,MARYDATE,REG,DATEFIRTST,DATEMEM,BAPT,BAPTER,GRUP,CHEIF,SERVICE,REASON,LOSTDATE) " +
           "VALUES ('" + old + "','" + pic + "','" + f + "','" + i + "','" + o + "','" + b + "','" + city + "','" + adr + "','" + pho + "','" + em + "','" + s + "','" + fam + "','" + famd + "','" + dr + "','" + df + "','" + dm + "','" + dk + "','" + fiok + "','" + gr + "','" + lgr + "','" + serv + "','" + reas + "','" + ld + "')";

                        command1.ExecuteNonQuery();
                        //

                        string fi = textBox13.Text;
                        string im = textBox14.Text;
                        string ot = textBox15.Text;

                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection5;
                        command.CommandText = "DELETE FROM chucrh WHERE ID= '" + label56.Text + "'";

                        command.ExecuteNonQuery();

                        MessageBox.Show(fi + " " + im + " " + ot + " изгнан из церкви");

                        connection5.Close();
                    }
                }
                //               
            }
            if (res == DialogResult.Cancel)
            {            
                MessageBox.Show("Действие отменено");
            }              
                panel2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Не женат/Не замужем") { dateTimePicker7.Visible = false; } else { dateTimePicker7.Visible = true; }
        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Не женат/Не замужем") { dateTimePicker8.Visible = false; } else { dateTimePicker8.Visible = true; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {            
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (dataGridView1.SelectedCells[i].Style.BackColor == Color.Blue)
                {
                    dataGridView1.SelectedCells[i].Style.BackColor = Color.White;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
                    textBox11.Text = Convert.ToString(dataGridView1.SelectedCells[0].Value);
                    radioButton3.Checked = true;
                    button3_Click(null, null);
                    //
                    textBox12.Text = Convert.ToString(dataGridView1.SelectedCells[0].Value);
                    radioButton5.Checked = true;
                    button4_Click(null, null);
                }
                else
                {
                    dataGridView1.SelectedCells[i].Style.BackColor = Color.Blue;
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
            }          
           
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { dateTimePicker9.Visible = false; } else { dateTimePicker9.Visible = true; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            label64.Text = "Потерянный по ID: ";
            label82.Text = "Фамилия:";
            label81.Text = "Имя:";
            label80.Text = "Отчество:";
            label79.Text = "Дата рождения:";
            label78.Text = "Пол:";
            label77.Text = "Семейное положение:";
            label76.Text = "Дата свадьбы:";
            label75.Text = "Город:";
            label74.Text = "Адрес:";
            label73.Text = "Телефон:";
            label72.Text = "Email:";
            label71.Text = "Дата регистрации:";
            label65.Text = "Дата членства:";
            label70.Text = "Дата крещения:";
            label69.Text = "Креститель:";
            label68.Text = "Группа:";
            label66.Text = "Служение:";
            label69.Text = "Креститель:";
            label67.Text = "Лидер группы:";
            label83.Text = "Причина ухода:";
            label84.Text = "Дата ухода:";
            label88.Text = "Дата первого посещения:";

            if (radioButton9.Checked == true)
            {
                string sqlExpression10 = "SELECT * FROM thelost WHERE id='" + Convert.ToInt32(textBox23.Text) + "'";
                using (var connection10 = new SqliteConnection("Data Source=book.db"))
                {
                    connection10.Open();

                    SqliteCommand command10 = new SqliteCommand(sqlExpression10, connection10);

                    List<string[]> data10 = new List<string[]>();

                    using (SqliteDataReader reader10 = command10.ExecuteReader())
                    {
                        if (reader10.HasRows) // если есть данные
                        {
                            while (reader10.Read())   // построчно считываем данные
                            {
                                data10.Add(new string[23]);
                                                                         
                                label64.Text += reader10[0].ToString(); back[1] = reader10[3].ToString();

                                label82.Text += reader10[3].ToString(); back[2] = reader10[4].ToString();
                                label81.Text += reader10[4].ToString(); back[3] = reader10[5].ToString();
                                label80.Text += reader10[5].ToString(); back[4] = reader10[6].ToString();
                                label79.Text += reader10[6].ToString(); back[5] = reader10[7].ToString();
                                label78.Text += reader10[11].ToString(); back[6] = reader10[8].ToString();
                                label77.Text += reader10[12].ToString(); back[7] = reader10[9].ToString();
                                label76.Text += reader10[13].ToString(); back[8] = reader10[10].ToString();
                                label75.Text += reader10[7].ToString(); back[9] = reader10[11].ToString();
                                label74.Text += reader10[8].ToString(); back[10] = reader10[12].ToString();
                                label73.Text += reader10[9].ToString(); back[11] = reader10[13].ToString();
                                label72.Text += reader10[10].ToString(); back[12] = reader10[14].ToString();

                                label88.Text += reader10[15].ToString(); back[21] = reader10[15].ToString();
                                label71.Text += reader10[14].ToString(); back[13] = reader10[16].ToString(); //
                                label70.Text += reader10[17].ToString(); back[14] = reader10[17].ToString();
                                label65.Text += reader10[16].ToString(); back[15] = reader10[18].ToString(); // 
                                label67.Text += reader10[20].ToString(); back[16] = reader10[19].ToString(); //
                                label68.Text += reader10[19].ToString(); back[17] = reader10[20].ToString(); //
                                label66.Text += reader10[21].ToString(); back[18] = reader10[21].ToString();
                                label69.Text += reader10[18].ToString();
                                label83.Text += reader10[22].ToString(); back[20] = reader10[0].ToString();
                                label84.Text += reader10[23].ToString();

                                try
                                {
                                    back[0] = reader10[2].ToString();
                                    pictureBox4.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader10[2].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader10[2].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }

                            }

                            reader10.Close();

                            connection10.Close();

                           
                        }
                    }
                }

            }
            if (radioButton10.Checked == true)
            {
                string sqlExpression10 = "SELECT * FROM thelost WHERE F='" + textBox23.Text + "'";
                using (var connection10 = new SqliteConnection("Data Source=book.db"))
                {
                    connection10.Open();

                    SqliteCommand command10 = new SqliteCommand(sqlExpression10, connection10);

                    List<string[]> data10 = new List<string[]>();

                    using (SqliteDataReader reader10 = command10.ExecuteReader())
                    {
                        if (reader10.HasRows) // если есть данные
                        {
                            while (reader10.Read())   // построчно считываем данные
                            {
                                data10.Add(new string[23]);

                                label64.Text += reader10[0].ToString(); back[1] = reader10[3].ToString();

                                label82.Text += reader10[3].ToString(); back[2] = reader10[4].ToString();
                                label81.Text += reader10[4].ToString(); back[3] = reader10[5].ToString();
                                label80.Text += reader10[5].ToString(); back[4] = reader10[6].ToString();
                                label79.Text += reader10[6].ToString(); back[5] = reader10[7].ToString();
                                label78.Text += reader10[11].ToString(); back[6] = reader10[8].ToString();
                                label77.Text += reader10[12].ToString(); back[7] = reader10[9].ToString();
                                label76.Text += reader10[13].ToString(); back[8] = reader10[10].ToString();
                                label75.Text += reader10[7].ToString(); back[9] = reader10[11].ToString();
                                label74.Text += reader10[8].ToString(); back[10] = reader10[12].ToString();
                                label73.Text += reader10[9].ToString(); back[11] = reader10[13].ToString();
                                label72.Text += reader10[10].ToString(); back[12] = reader10[14].ToString();

                                label88.Text += reader10[15].ToString(); back[21] = reader10[15].ToString();
                                label71.Text += reader10[14].ToString(); back[13] = reader10[16].ToString(); //
                                label70.Text += reader10[17].ToString(); back[14] = reader10[17].ToString();
                                label65.Text += reader10[16].ToString(); back[15] = reader10[18].ToString(); // 
                                label67.Text += reader10[20].ToString(); back[16] = reader10[19].ToString(); //
                                label68.Text += reader10[19].ToString(); back[17] = reader10[20].ToString(); //
                                label66.Text += reader10[21].ToString(); back[18] = reader10[21].ToString();
                                label69.Text += reader10[18].ToString();
                                label83.Text += reader10[22].ToString(); back[20] = reader10[0].ToString();
                                label84.Text += reader10[23].ToString();

                                try
                                {
                                    back[0] = reader10[2].ToString();
                                    pictureBox4.Image = Image.FromFile(@Environment.CurrentDirectory + @"\res\" + reader10[2].ToString());
                                }
                                catch
                                {
                                    Console.WriteLine("Фото: '" + reader10[2].ToString() + "' было удалено из базы");
                                }
                                finally
                                {
                                    Console.WriteLine("Фото было удалено из базы");
                                }

                            }

                            reader10.Close();

                            connection10.Close();


                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection("Data Source=book.db"))
            {
                connection.Open();

                //
                SqliteCommand commandnext = new SqliteCommand();
                commandnext.Connection = connection;
                commandnext.CommandText = "DELETE FROM thelost WHERE ID= '" + back[20] + "'";

                commandnext.ExecuteNonQuery();
                //

                MessageBox.Show("Предан анафеме");

                connection.Close();

                panel3.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var connection = new SqliteConnection("Data Source=book.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO chucrh (PIC, F,I,O,BORN,CITY,ADRES,PHONE,EMAIL,MALE,MARY,MARYDATE,REG,DATEFIRTST,DATEMEM,BAPT,BAPTER,GRUP,CHEIF,SERVICE) " +
       "VALUES ('" + back[0] + "','" + back[1] + "','" + back[2] + "','" + back[3] + "','" + back[4] + "','" + back[5] + "','" + back[6] + "','" + back[7] + "','" + back[8] + "','" + back[9] + "','" + back[10] + "','" + back[11] + "','" + back[12] + "','" + back[21] + "','" + back[13] + "','" + back[14] + "','" + back[15] + "','" + back[16] + "','" + back[17] + "','" + back[18] + "')";
                command.ExecuteNonQuery();

                //
                SqliteCommand commandnext = new SqliteCommand();
                commandnext.Connection = connection;
                commandnext.CommandText = "DELETE FROM thelost WHERE ID= '" + back[20] + "'";

                commandnext.ExecuteNonQuery();
                //

                MessageBox.Show("Восстановлен");

                connection.Close();

                panel3.Visible = false;

                
            }
        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView2.SelectedCells.Count; i++)
            {
                if (dataGridView2.SelectedCells[i].Style.BackColor == Color.Blue)
                {
                    dataGridView2.SelectedCells[i].Style.BackColor = Color.White;
                    dataGridView2.DefaultCellStyle.SelectionBackColor = Color.White;
                    //
                    textBox23.Text = Convert.ToString(dataGridView2.SelectedCells[0].Value);
                    radioButton9.Checked = true;
                    button7_Click(null, null);
                }
                else
                {
                    dataGridView2.SelectedCells[i].Style.BackColor = Color.Blue;
                    dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Церковная база данных\n\nРазработано в 2022", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            LoadData();
        }

        private void clearTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения

            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла

            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;

                    nf = Path.GetFileName(open_dialog.FileName);
                    np = @Environment.CurrentDirectory + @"\res\" + nf;
                    System.IO.File.Copy(open_dialog.FileName, np);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { dateTimePicker2.Visible = false; } else { dateTimePicker2.Visible = true; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) { dateTimePicker3.Visible = false; } else { dateTimePicker3.Visible = true; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { dateTimePicker5.Visible = false; } else { dateTimePicker5.Visible = true; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) { dateTimePicker6.Visible = false; } else { dateTimePicker6.Visible = true; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true) { dateTimePicker11.Visible = false; } else { dateTimePicker11.Visible = true; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBox6.Checked == true) { dateTimePicker10.Visible = false; } else { dateTimePicker10.Visible = true; }
        }
    }
}
