/* UserInterface.cs
 * Author: Rod Howell
 */
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

namespace Ksu.Cis300.TextEditor
{
    /// <summary>
    /// A user interface for a simple text editor.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the "Open . . ." button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uxDisplay.Text = File.ReadAllText(uxOpenDialog.FileName);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Save As . . ." button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSaveAs_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(uxSaveDialog.FileName, uxDisplay.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Displayes the given exception.
        /// </summary>
        /// <param name="e">The exception to display.</param>
        private void ShowError(Exception e)
        {
            MessageBox.Show("The following error occurred: " + e);
        }
        /// <summary>
        /// 
        /// Encrypts the given string using a String
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWithString_Click(object sender, EventArgs e)
        {
            String text = uxDisplay.Text;
            String encrypted = "";


            for (int i = 0; i < text.Length; i++)
            {

                encrypted += singleChar(text[i]);
            }
            uxDisplay.Text = encrypted;
        }
        /// <summary>
        /// 
        /// Encrypts the given string using a stringbuilder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxWithStringBuilder_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            String text = uxDisplay.Text;

            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(singleChar(text[i]));
            }
            String encrypted = sb.ToString();
            uxDisplay.Text = encrypted;
        }




        /// <summary>
        /// Rotates the given character c n positions through the alphabet whose first
        /// letter is firstLetter and whose number of letters is alphabetLen. alphabetLen
        /// must be positive.
        /// </summary>
        /// <param name="c">The character to rotate.</param>
        /// <param name="n">The number of positions to rotate c.</param>
        /// <param name="firstLetter">The first letter of the alphabet.</param>
        /// <param name="alphabetLen">The number of letters in the alphabet.</param>
        /// <returns>The result of the rotation.</returns>
        private char Rotate(char c, int n, char firstLetter, int alphabetLen)
        {
            return (char)(firstLetter + (c - firstLetter + n) % alphabetLen);
        }
        /// <summary>
        /// Determines if the character is uppercase or lowercase or neither
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private char singleChar(char c)
        {
            char r;
            if (c >= 'a' && c <= 'z')
            {
                r = Rotate(c, 13, 'a', 26);
            }
            else if (c >= 'A' && c <= 'Z')
            {
                r = Rotate(c, 13, 'A', 26);
            }
            else
            {
                return c;
            }


            return r;
        }
    }
}
