using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Finalproject
{
    public partial class Form5 : Form
    {
        private Form3 form3;//ประกาศตัวแปรเพื่อเชื่อมต่อกับฟอร์ม3


        public double discount1;

        public Form5(Form3 linkedForm3)//เชื่อมต่อกับฟอร์ม3
        {
            InitializeComponent();
            form3 = linkedForm3;//เก็บอ้างอิงของform3ที่ถูกส่งมา
           
        }
        public void sentvalue()//สร้างmethod เพื่อส่งค่ากลับไปที่ฟอร์ม3 และ การทำงาน
        {
            form3.UpdatePromotionValue(discount1);//ดึงmethod อัปเดทส่วนลดและส่งค่ากลับไป
            form3.calculate();//เริ่มmethod คำนวณราคาสินค้าหลังหักส่วนลด ในฟอร์ม3 
            this.Close();//ปิดหน้าฟอร์ม
        }
        //ปุ่มลด10%
        private void button1_Click(object sender, EventArgs e)
        {
            discount1 = 0.1;
            sentvalue();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            
        }
        //ปุ่มลด15%
        private void button2_Click(object sender, EventArgs e)
        {
            discount1 = 0.15;
            sentvalue();
        }
        //ปุ่มลด20%
        private void button3_Click(object sender, EventArgs e)
        {
            discount1 = 0.20;
            sentvalue();
        }
        //ปุ่มลด30%
        private void button4_Click(object sender, EventArgs e)
        {
            discount1 = 0.30;
            sentvalue();
        }
        //ปุ่มลด40%
        private void button5_Click(object sender, EventArgs e)
        {
            discount1 = 0.40;
            sentvalue();
        }
        //ปุ่มลด50%
        private void button6_Click(object sender, EventArgs e)
        {
            discount1 = 0.50;
            sentvalue();
        }
    }
}
