using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediaregister.model;

namespace Mediaregister
{
    public partial class Form1 : Form
    {

        private List<Media> allMedia = new List<Media>();

        public Form1()
        {
            InitializeComponent();
        }

        private bool Input(TextBox titleBox, TextBox writerBox, NumericUpDown length)
        {
            bool returnValue = true;
            
            if (String.IsNullOrWhiteSpace(titleBox.Text)) 
            {
                titleBox.Text = "";
                returnValue = false;
            }
            if (String.IsNullOrWhiteSpace(writerBox.Text)) 
            {
                writerBox.Text = "";
                returnValue = false;
            }
            if (length.Value <= 0) 
            {
                length.Value = length.Minimum;
                returnValue = false;
            }

            return returnValue;
        }
        

        
        private void AddBookButton_Click(object sender, EventArgs e)
        {


            if (Input(BookBoxTitle, AoutherBoxTitle, Pagenummber))
            {
               
                string title = BookBoxTitle.Text.Trim();
                string author = AoutherBoxTitle.Text.Trim();
                int nrPages = (int)Pagenummber.Value;
                
                allMedia.Add(new Book(title, author, nrPages));

                
                BookBoxTitle.Text = "";
                AoutherBoxTitle.Text = "";
                Pagenummber.Value = Pagenummber.Minimum;
            }
            else
            {
                SendErrorMessage("Ogiltlig input");
            }
            UpdateList();

        }

        private void AddFilmButton_Click(object sender, EventArgs e)
        {

            if (Input(FilmBoxTitle, DirectorBoxTitle, Lengthnummber))
            {
                
                string title = FilmBoxTitle.Text.Trim();
                string director = DirectorBoxTitle.Text.Trim();
                int length = (int)Lengthnummber.Value;
                
                allMedia.Add(new Film(title, director, length));

                
                FilmBoxTitle.Text = "";
                DirectorBoxTitle.Text = "";
                Lengthnummber.Value = Lengthnummber.Minimum;

            }
            else
            {
                SendErrorMessage("Ogiltlig input");
            }
            UpdateList();

        }


        private void UpdateList()
        {

            string[] newLines = new string[allMedia.Count]; 
            int index = 0; 

            for (int i = 0; i < newLines.Length; i++)
            {
                
                Media media = allMedia[i];

                if (AllBooksButton.Checked)
                {
                    media = allMedia[i] as Book; 
                }
                else if (AllFilmsButton.Checked)
                {
                    media = allMedia[i] as Film; 
                }


                if (media != null) 
                {
                    newLines[index] = media.ToString();
                    index++;
                }
                
            }
            MediaListBox.Lines = newLines;

        }

        private void ShowRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void BookTitleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void SendErrorMessage(string message)
        {
            string caption = "Error!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;


            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
        }
    }
}
