using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Finalproject
{
    
    public partial class Form3 : Form 
    {
        //List เพื่อเก็บสินค้าในตะกร้า
        private List<Product> addedProducts = new List<Product>();
        
        private Login objLogin;
        private ProductDatabase productDatabase;
        private double totalPrice = 0;
        private string productCode; 
        private bool productFound;
        public double PromotionValue = 0 ;
        double recieve;
        double tangtorn;


        public Form3(Login paa,double value1)
        {
            InitializeComponent();
            objLogin = paa;//เก็บข้อมูลการเข้าสู่ระบบของผู้ใช้
            productDatabase = new ProductDatabase(); // สร้างฐานข้อมูลสินค้าขึ้นมาใหม่

            PromotionValue = value1;



        }
        public void UpdatePromotionValue(double newPromotionValue)
        {
            PromotionValue = newPromotionValue; //อัปเดทค่าโปรโมชั่น
            


        }
        double discountedTotalPrice;
        
        //คำนวณราคาสินค้าหลังหักส่วนลด
        public void calculate()
        {
           discountedTotalPrice = 0;

            foreach (var product in addedProducts)//วนลูปสินค้าที่เพิ่มเข้ามาในตระกร้า
            {
                double discountedPrice = product.Price*(1 - PromotionValue);
                discountedTotalPrice += discountedPrice; //คำนวณสินค้าหลังหักส่วนลด
            }
            
            label3.Text = "ราคาหลังหักส่วนลด: " + discountedTotalPrice.ToString("C"); //แสดงราคาผ่านlabel
        }

        public void process()//method สำรหับการประมวณผลรหัสสินค้าที่ผู้ใช้กรอก
        {
            
            productCode = textBox2.Text;
            

            foreach (var product in productDatabase.Products)//วนลูปผ่านสินค้าทุกตัวในฐานข้อมูล
            {
                if (product.ProductCode == productCode)//ถ้าเจอสินค้าที่รหัสกับสินค้าในฐานข้อมูล
                {
                    
                    textBox1.Text = product.ProductName;
                    textBox3.Text = product.Price.ToString();


                    addedProducts.Add(product);//เพิ่มสินค้าในรายการสินค้าที่เลือก

                    string productDetails = product.ProductCode + " - " + product.ProductName + " - " + product.Price.ToString("C");
                    listBox1.Items.Add(productDetails);//สินค้าที่ถูกเพิ่มจะแสดงออกที่นี่
                    totalPrice += product.Price;
                    label7.Text = "ราคารวม = " + totalPrice;
                    productFound = true;//ตั้งค่า productFound เป็น จริง เนื่องจากพบสินคาที่ตรงกัน
                    break;
                }
                
            }

            if (!productFound)//ถ้าไม่เจอสินค้า
            {

                MessageBox.Show("ไม่พบสินค้าตามรหัสที่กรอก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //เคลียร์ค่าให้textboxว่างเปล่า
                textBox1.Clear();
                textBox3.Clear();

            }
            //เคลียร์ค่าให้textboxว่างเปล่า
            textBox2.Clear();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

            label1.Text = "ชื่อพนักงงาน: " + objLogin.Name;
            pictureBox1.ImageLocation = Application.StartupPath + "\\ploy.PNG";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            process();
            calculate();

        }


        private void button3_Click(object sender, EventArgs e)//ปุ่มเพื่อกดเคลียร์ค่าทั้งหมด
        {
            //เคลียร์ค่าให้textboxว่างเปล่า
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox3.Clear();
            label3.Text = "";
            totalPrice = 0;
            label7.Text = "";
            textBox5.Clear();


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//กรณีเวลากดEnter
            {
                if (!string.IsNullOrEmpty(textBox2.Text))//เมื่อtextbox ไม่ว่าง
                {
                    process();
                    calculate();
                    e.Handled = true;// ป้องกันไม่ให้เกิดการพิมพ์ค่าของ Enter ลงใน TextBox
                }
            }

        }
        //เมื่อกดปุ่มโปรโมชั่น
        private void button2_Click(object sender, EventArgs e)
        {
            //เปิดหน้าฟอร์ม5
            Form5 form5 = new Form5(this);
            form5.ShowDialog();
        }
        //เมื่อกดปุ่มออกจากระบบ
        private void button4_Click(object sender, EventArgs e)
        {
            //ปิดหน้าฟอร์ม3เปิดหน้าฟอร์ม2(ที่เป็นหน้าlogin)
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
        //เมื่อกดปุ่มพิมพ์ใบเสร็จ
        private void button5_Click(object sender, EventArgs e)
        {
            if (addedProducts.Count == 0)//เมื่อรายการสินค้าว่างเปล่า
            {
                MessageBox.Show("ไม่มีสินค้าในรายการ!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form6 form6 = new Form6(addedProducts, discountedTotalPrice);//ส่งค่าไปต่อที่ฟอร์ม6
            form6.ShowDialog();//เปิดฟอร์ม6
        }
        //เมื่อกดปุ่มออกจากโปรแกรม
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();//ปิดโปรแกรม
        }
        //คำนวณเงินทอน
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)//ตั้งค่าดป็นกดenter แทน กดปุ่ม
        {
             recieve = 0;
            if (e.KeyChar == (char)13)//กรณีเวลากดEnter
            {
                recieve = 0;
                if (productFound)//เมื่อมีสินค้าในlistboxให้เริ่มคำนวณเงินทอนได้
                {
                    recieve = Convert.ToInt64(textBox4.Text);
                    tangtorn = recieve - discountedTotalPrice;
                    textBox5.Text = tangtorn.ToString();
                    
                }
                else
                {
                    MessageBox.Show("กรุณากรอกสินค้า");
                }
                textBox4.Clear();
            }
        }
    }
}
 

    


