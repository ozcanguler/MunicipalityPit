using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalityPit
{
    public partial class Form1 : Form
    {
       
     
        int[,] arry;
        int start;
        public int x =3, y = 4;            // y must be greater than x 
        int soul = 3;

        internal void receiveData(int newName)
        {
            x = newName;
            y = newName + 1;
            //MessageBox.Show("Items count:" + names.Count);
        }
        private void clickButton(object sender, EventArgs e)
        {
            
            Button btnclick = (Button)sender;
            /* label2.Text = btnclick.Name; */     //BTN_0_0 
            string[] numbers = btnclick.Name.Split('_');
            int i = Convert.ToInt32(numbers[1]);//0. indiste btn 1 de x 2 de y var. 
            int j = Convert.ToInt32(numbers[2]);
            //label2.Text = i+j.ToString();
            /*label2.Text = arry[i,j].ToString(); */    //indeksin içinde ne varsa onu yazar.Yani 0 veya 1

            progressBar1.Maximum = x;



            if (soul > 0)
            {

            

            if (arry[i, j] == 0)        //0.değeri seçersek seviyeyi arttır   //arry[0,0]=0 veya 1 olabilir en aşağıdaki kodda random atanır.
            {
                    start++;
                    label2.Text = start + 1 + ".level";
                    progressBar1.Value = start;
                foreach (var _find in this.Controls.OfType<Button>())   //tüm buttonları dolaşır.                    
                {
                        BTN_99_99.Enabled = true;
                        numbers = _find.Name.Split('_');
                    int sec_i = Convert.ToInt32(numbers[1]);
                    int sec_j = Convert.ToInt32(numbers[2]);//sec_j her satırın numarası eklenir.Bu numarayla hangi seviyede olduğumuzu tutarız.


                    if (x == start) { label2.Text = "Congratulations"; _find.Enabled = false; /*btnclick.BackColor = Color.Green;*/
                            btnclick.BackgroundImage = (Properties.Resources.smiley); btnclick.BackgroundImageLayout = ImageLayout.Center; btnclick.Text = "";
                        }
                    else if (sec_i == start)     //satır numaramız o anki seviyeye eşitse  demekki doğru seçim yapmışız bu yüzden o satırdaki butonları aktif et.
                    {
                        _find.Enabled = true;
                            //btnclick.BackColor = Color.Green;
                            btnclick.BackgroundImage = (Properties.Resources.smiley); btnclick.BackgroundImageLayout = ImageLayout.Center;
                            btnclick.Text = "";

                        }
                    else _find.Enabled = false;      //seviye numaramız ile satır numaramız eşit değilse o satır numaralarındaki butonları pasif yap.

                }


            }
                else
                {
                    soul--;
                    label3.Text = "Healty points:" + soul.ToString();
                    btnclick.Enabled = false;
                    //btnclick.BackColor = Color.Red;
                    btnclick.BackgroundImage = (Properties.Resources.angry); btnclick.BackgroundImageLayout = ImageLayout.Center;
                    btnclick.Text = "";


                }






            }
            //else
            //{          //1.değeri seçtik tüm butonları dolaşıp pasif yap 
            //    foreach (var _bul in this.Controls.OfType<Button>())   //tüm buttonları dolaşır.                    
            //    {

            //        _bul.Enabled = false;
            //        //        btnRestart.Enabled = true;

            //        //    }
            //        label2.Text = start + 1 + ".seviyede Oyun Bitti";
            //        btnclick.BackColor = Color.Red;

            //    }
            //}

            if(soul==0)
            {          //1.değeri seçtik tüm butonları dolaşıp pasif yap 
                foreach (var _bul in this.Controls.OfType<Button>())   //tüm buttonları dolaşır.                    
                {

                    _bul.Enabled = false;
                    BTN_99_99.Enabled = true;

                }

                    label2.Text = start + 1 + ".level Game Over";
                    //btnclick.BackColor = Color.Red;
                    label3.Text = "Healty points" + soul.ToString();
                
            }
          
            



        }
        public Form1()
        {
           
            InitializeComponent();
            label2.Text = start + 1 + ".Level";
            label3.Text = "Healty points: " + soul.ToString();
           
        }

        private void BTN_99_99_Click(object sender, EventArgs e)
        {
            
            Form1 f1 = new Form1();
            Application.DoEvents();
            //Application.Restart();
            //Environment.Exit(0);
            //this.Size = new Size(850, 450);
            Form1 f2 = new Form1();
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = f1.Location;
            f2.Size = f1.Size;
            f2.Show();
            this.Dispose(false);
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            //this.Size = new Size((x * 70) + 400, (y * 40) + 400);
            arry = new int[x, y];
            //start = 0;
            //arry[0, 0] = 0;
            //arry[0, 1] = 0;
            //arry[0, 2] = 0;
            //arry[0, 3] = 0;
            //arry[1, 0] = 0;
            //arry[1, 1] = 0;
            //arry[1, 2] = 0;
            //arry[1, 3] = 0;
            //arry[2, 0] = 0;
            //arry[2, 1] = 0;
            //arry[2, 2] = 0;
            //arry[2, 3] = 0;
            label1.Text = "";
            Random rndm = new Random();
            int choose;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < i+(y-x); j++)
                {                 
                    choose = rndm.Next(0, y);
                    
                    if (arry[i, choose] == 1)
                    {
                        j--;
                    }
                    else
                    {
                        arry[i, choose] = 1;
                    }
                   
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                   

                    label1.Text = label1.Text + arry[i, j].ToString();
                }
                label1.Text += "   ";
            }


            int bxno = 1; //Kutuların text numaralarını belirlemek için verilen değer

            for (int j = 0; j < x; j++)
            {
                for (int k = 0; k < y; k++)
                {

                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point( 10 + k * 55, 130 + j * 55);
                    btn.Name = "BTN_" + j.ToString() + "_" + k.ToString();                      //Formdan yeni eklediğimiz buttonlar bu karakterlerden oluşmalı BTN_?_? olmalı
                    btn.Size = new System.Drawing.Size(50, 50);
                    btn.Text =  bxno.ToString();
                    btn.Click += new System.EventHandler(clickButton);
                    this.Controls.Add(btn);
                    bxno++;
                    if (j > 0)     //Eğer ilk satırdaysak diğer satırlardaki butonları pasif yap.
                    {
                        btn.Enabled = false;        //Diğer seviyeye geçmek için tüm butonları aramamız lazım yukardaki koda geç

                    }

                }
            }
        }
    }
}
