using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;

namespace DataEntryWithVoiceCommands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabled();
            colormethod();
        }
        DbProductAIEntities db = new DbProductAIEntities();
        public void ProductList()
        {
            var products = db.TblProduct.ToList();
            dataGridView1.DataSource = products;
        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }
        void enabled()
        {
            txtName.Enabled = false;
            txtBrand.Enabled = false;
            txtStock.Enabled = false;
            txtBuyPrice.Enabled = false;
            txtSalePrice.Enabled = false;
            txtCategory.Enabled = false;
            maskedTextDate.Enabled = false;
            comboBoxCase.Enabled = false;
        }
        void colormethod()
        {
            txtName.BackColor = Color.White;
            txtBrand.BackColor = Color.White;
            txtStock.BackColor = Color.White;
            txtBuyPrice.BackColor = Color.White;
            txtSalePrice.BackColor = Color.White;
            txtCategory.BackColor = Color.White;
            maskedTextDate.BackColor = Color.White;
            comboBoxCase.BackColor = Color.White;
        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine SR = new SpeechRecognitionEngine();
            Grammar G = new DictationGrammar();
            SR.LoadGrammar(G);
            try
            {
                BtnSpeak.Text = "Please Speak";
                SR.SetInputToDefaultAudioDevice();
                RecognitionResult Result = SR.Recognize();
                richTextBox1.Text = Result.Text;

            }
            catch (Exception)
            {

                BtnSpeak.Text = "Error, Please Try Again...";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtName.BackColor == Color.PowderBlue && txtName.Enabled == true)
            {
                txtName.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (txtBrand.BackColor == Color.PowderBlue && txtBrand.Enabled == true)
            {
                txtBrand.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (txtStock.BackColor == Color.PowderBlue && txtStock.Enabled == true)
            {
                txtStock.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (txtBuyPrice.BackColor == Color.PowderBlue && txtBuyPrice.Enabled == true)
            {
                txtBuyPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (txtSalePrice.BackColor == Color.PowderBlue && txtSalePrice.Enabled == true)
            {
                txtSalePrice.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (txtCategory.BackColor == Color.PowderBlue && txtCategory.Enabled == true)
            {
                txtCategory.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }
            if (maskedTextDate.BackColor == Color.PowderBlue && maskedTextDate.Enabled == true)
            {
                enabled();
                colormethod();
            }
            if (comboBoxCase.BackColor == Color.PowderBlue && comboBoxCase.Enabled == true)
            {
                enabled();
                colormethod();
            }
            if (richTextBox1.Text == "Products list" || richTextBox1.Text == "List of products")
            {
                ProductList();
            }
            if (richTextBox1.Text == "Add")
            {
                TblProduct t = new TblProduct();
                t.NAME = txtName.Text;
                t.BRAND = txtBrand.Text;
                t.STOCK = short.Parse(txtStock.Text);
                t.BUYPRICE = decimal.Parse(txtBuyPrice.Text);
                t.SELLPRICE = decimal.Parse(txtSalePrice.Text);
                t.CATEGORY = txtCategory.Text;
                t.DATEADDPRO = DateTime.Parse(maskedTextDate.Text);
                t.PRODUCTCASE = true;
                db.TblProduct.Add(t);
                db.SaveChanges();
                label10.Text = "The products have been saved in the database.";
            }
            if (richTextBox1.Text == "Products name" || richTextBox1.Text == "Name" || richTextBox1.Text == "Main")
            {
                txtName.Focus();
                txtName.BackColor = Color.PowderBlue;
                txtName.Enabled = true;
            }
            if (richTextBox1.Text == "Brand" || richTextBox1.Text == "Mark")
            {
                txtBrand.Focus();
                txtBrand.BackColor = Color.PowderBlue;
                txtBrand.Enabled = true;
            }
            if (richTextBox1.Text == "Stock" || richTextBox1.Text == "Stoke")
            {
                txtStock.Focus();
                txtStock.BackColor = Color.PowderBlue;
                txtStock.Enabled = true;
            }
            if (richTextBox1.Text == "Buying price" || richTextBox1.Text == "Buying" || richTextBox1.Text == "By")
            {
                txtBuyPrice.Focus();
                txtBuyPrice.BackColor = Color.PowderBlue;
                txtBuyPrice.Enabled = true;
            }
            if (richTextBox1.Text == "Sale price" || richTextBox1.Text == "Sales price")
            {
                txtSalePrice.Focus();
                txtSalePrice.BackColor = Color.PowderBlue;
                txtSalePrice.Enabled = true;
            }
            if (richTextBox1.Text == "Category" || richTextBox1.Text == "a" || richTextBox1.Text == "b")
            {
                txtCategory.Focus();
                txtCategory.BackColor = Color.PowderBlue;
                txtCategory.Enabled = true;
            }
            if (richTextBox1.Text == "Date" || richTextBox1.Text == "They")
            {
                maskedTextDate.Focus();
                maskedTextDate.BackColor = Color.PowderBlue;
                maskedTextDate.Enabled = true;
            }
            if (richTextBox1.Text == "Case" || richTextBox1.Text == "Kenneth")
            {
                comboBoxCase.Focus();
                comboBoxCase.BackColor = Color.PowderBlue;
                comboBoxCase.Enabled = true;
            }
            if (richTextBox1.Text == "Exit application" ||
                richTextBox1.Text == "Exits application" ||
                richTextBox1.Text == "Exit")
            {
                Application.Exit();
            }
            if (richTextBox1.Text == "Paint")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }

        }
        private void maskedTextDate_BackColorChanged(object sender, EventArgs e)
        {
            if (maskedTextDate.BackColor == Color.PowderBlue)
            {
                maskedTextDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void comboBoxCase_BackColorChanged(object sender, EventArgs e)
        {
            if (comboBoxCase.BackColor == Color.PowderBlue)
            {
                comboBoxCase.Text = "Active";
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label10.Text);
        }


    }
    
}
