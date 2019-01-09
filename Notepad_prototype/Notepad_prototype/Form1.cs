using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_prototype
{
    public partial class NoteApp : Form
    {
        Boolean alreadySavedOnce = false; //flag to check whether file was saved previously
        Boolean alreadyOpenedOnce = false;//flag to check whether file was opened previously
        public NoteApp()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Shows the openFileDialog
            openFileDialog1.ShowDialog();
           
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alreadySavedOnce == false) //if the file hasn't already been saved, the saveFile dialog should be opened to give it a filename
            {
                saveFileDialog1.ShowDialog();
            }


            else if (alreadyOpenedOnce) //if the open dialog has been opened, the FileName in openFileDialog1 will exist (so no need to open a dialog box)
            {
                //Determines the text file to save to

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);
                //Writes the text to the file
                SaveFile.WriteLine(richTextBox1.Text);
                //Closes the proccess
                alreadySavedOnce = true;
                SaveFile.Close();
            }

            else //if the file hasn't been opened, but has been saved, just save the file
            {
                //Determines the text file to save to

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
                //Writes the text to the file
                SaveFile.WriteLine(richTextBox1.Text);
                //Closes the proccess
                alreadySavedOnce = true;
                SaveFile.Close();
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the saveFileDialog
            saveFileDialog1.ShowDialog();
            //Determines the text file to save to


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) //runs if "Open" is clicked in the Open Dialog Box
        {
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            //Displays the text file in the textBox
            richTextBox1.Text = OpenFile.ReadToEnd();
            alreadyOpenedOnce = true;
            //Closes the proccess
            OpenFile.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)//runs if "Save" is clicked in the Save As Dialog Box
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            //Writes the text to the file
            SaveFile.WriteLine(richTextBox1.Text);
            //Closes the proccess
            alreadySavedOnce = true;
            SaveFile.Close();
        }
    }
}