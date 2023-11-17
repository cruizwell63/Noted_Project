using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noted_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("hh:mm tt");
            toolStripStatusLabel2.Text = "Words : " + words(richTextBox1.Text).ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e){  // to prompt save before  exit

            base.OnFormClosing(e);

            if (richTextBox1.Text  == "") { // if textbox is empty, can close right away
                Dispose(true);
                Application.Exit();
            }
            else
            {
                if (PreClosingConfirmation() == DialogResult.Yes) //if  textbox is not empty,  prompt dialog
                {

                    SaveFileDialog op = new SaveFileDialog();
                    op.Title = "Save";
                    op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
                    if (op.ShowDialog() == DialogResult.OK)
                        richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = op.FileName;

                }
                else { //  if  dialog = no,  exit
                    Dispose(true);
                    Application.Exit();
                }
            }       
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = MessageBox.Show("Do you want to save your files before closing?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return res;
        }

        private int words(string text) {
            int num_words = 0;
            int i = 0;

            while (i <= text.Length-1 )
            {
                if (text[i] == ' ' || text[i] == '\n' || text[i] == '\t') {
                    num_words++;
                }
                i++;
            }
            return num_words;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "open";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save

            SaveFileDialog op = new SaveFileDialog();
            op.Title = "Save";
            op.Filter = "Text Document(*.txt)|*.txt| All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit

            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

            //else
            //{
            //    //Modify this code..
            //    MessageBox.Show("Ok", "Ok", MessageBoxButtons.OK);
            //}

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Undo
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Redo
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Copy
            richTextBox1.Copy();

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Paste
            richTextBox1.Paste();

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cut
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SelectAll
            richTextBox1.SelectAll();

        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Date Time
            richTextBox1.Text = System.DateTime.Now.ToString();

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Font
            FontDialog op = new FontDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = op.Font;

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Color
            ColorDialog op = new ColorDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = op.Color;

        }

        private void TimeStrip_Click(object sender, EventArgs e)
        {
            TimeStrip.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) //word  counter
        {
            toolStripStatusLabel2.Text = "Words " + words(richTextBox1.Text).ToString();
        }
    }
}