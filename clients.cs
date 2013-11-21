//Popescu Ionut Cosmin, 321AC
//10/11/2013
//first create  C:\poo

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace tema_poo
{
    public partial class clienti : Form
    {
        

        public clienti()
        {
            InitializeComponent();

        }

       // private void textBox1_TextChanged(object sender, EventArgs e)//da erare daca se sterge
       // {

        //}

       // private void listBox1_SelectedIndexChanged(object sender, EventArgs e)// la fel ca mai sus
      //  {
            
        //}

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            combina();//method
        }

        private void button1_Click(object sender, EventArgs e)
        {
            combina();//as above
        }

        public void combina()//concatenez datele
        {
            textBox8.Text = textBox1.Text + "---" + textBox2.Text + "---" + textBox3.Text +"---"
                +  textBox4.Text + "---" +  textBox5.Text + "---" + textBox6.Text + "---" + textBox7.Text;
        }

        private void button5_Click(object sender, EventArgs e)//code for saving data from textbox8
        {
            string file_name = @"C:\poo\clienti.txt";
            System.IO.StreamWriter obj_Writer;
            obj_Writer = new System.IO.StreamWriter(file_name,true);
            obj_Writer.Write(textBox8.Text);
            obj_Writer.Write(Environment.NewLine);
            obj_Writer.Close();
            MessageBox.Show("Done !!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new_instance();
        }

        public void new_instance()//delete all textboxes
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            
        }
        public void populate_listbox()//adding elements in list line by line 
        {
            var lines = System.IO.File.ReadAllLines(@"C:\poo\clienti.txt");
            int i;
            for (i = 0; i < lines.Length; i++)
            {
                var field = lines[i];

                if (!listBox1.Items.Contains(lines[i]) )
                {
                    listBox1.Items.Add(lines[i]);
                }
                
              
            }
        } 

        private void button6_Click(object sender, EventArgs e)
        {
            populate_listbox();
        }

        private void button3_Click(object sender, EventArgs e)//delete elements from list
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button7_Click(object sender, EventArgs e)//delete file content 
        {
            using (StreamWriter sw = new StreamWriter(@"C:\poo\clienti.txt"))
            {
                sw.Write("");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate_listbox();
        }

        private void button8_Click(object sender, EventArgs e)//checking for banklines in file and deleting them
        {
            var lines = File.ReadAllLines(@"C:\poo\clienti.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(@"C:\poo\clienti.txt", lines);
        }

        private void clienti_Load(object sender, EventArgs e)
        {

        }

    
    }
}



