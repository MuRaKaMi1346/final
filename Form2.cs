﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Finalproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        Login objLogin;
        private object value1;

        public void StartLoading()//method ปิดฟร์อมปัจจุบันและส่งค่าไปฟอร์มหน้าใหม่
        {
         


            this.Hide();// ซ่อนฟอร์มปัจจุบัน (Form2)
            Form3 form3 = new Form3(objLogin,0);//สร้างฟอร์มใหม่ Form3 โดยส่งอ็อบเจ็กต์ objLogin และค่า 0
            form3.ShowDialog();//เปิดฟอร์ม3
            this.Close();//ปิดหน้าฟอร์มปัจจุบัน

        }
        public void loginProcess()//method การรับค่าของLogin มาเก็บไว้ในตัวแปร
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            objLogin = new Login(name, password);//ส่งค่าnameและpassword ไปที่class Login
        }

        public void loginProcessEnter()//method เวลากดปุ่มlogin  ต้องกรอกข้อมูลให้ครบถ้วนก่อน
        {
            
                if (!(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)))
                //เมื่อ textbox ไม่ว่างmethod ก็จะถูกเรียกใช้
                {
                    loginProcess();
                    StartLoading();
                    
                }
                else
                //เมื่อ textbox ว่าง messageBoxก็จะโชว์
                {
                MessageBox.Show("กรอกข้อมูลให้ครบถ้วน");
                    
                }
            
        }

        public void updatestate()//method กำหนดการทำงานของปุ่ม ปุ่มจะใช้งานได้ต่อเมื่อกรอกข้อมูลครบ
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            //เมื่อ textbox ไม่ว่างmethod ปุ่มก็จะปิดการใช้งาน
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            updatestate();//เรียกใช้ method การทำงานของปุ่ม
            

        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updatestate();//เรียกใช้ method การทำงานของปุ่ม
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            updatestate();//เรียกใช้ method การทำงานของปุ่ม
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            loginProcess();//เรียกใช้ method การรับค่าของLogin มาเก็บไว้ในตัวแปร
            StartLoading();//เรียกใช้ method ปิดฟร์อมปัจจุบันและส่งค่าไปฟอร์มหน้าใหม่
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//กรณีเวลากดEnter
            {
                loginProcessEnter();//เรียกใช้ method เวลากดปุ่มlogin  ต้องกรอกข้อมูลให้ครบถ้วนก่อน
                e.Handled = true;// ป้องกันไม่ให้เกิดการพิมพ์ค่าของ Enter ลงใน TextBox
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                loginProcessEnter();//เรียกใช้ method เวลากดปุ่มlogin  ต้องกรอกข้อมูลให้ครบถ้วนก่อน
                e.Handled = true;// ป้องกันไม่ให้เกิดการพิมพ์ค่าของ Enter ลงใน TextBox
            }
        }
    }
}

