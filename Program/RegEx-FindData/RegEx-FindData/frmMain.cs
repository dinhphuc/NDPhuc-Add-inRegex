using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.IO;

namespace RegEx_FindData
{
    public partial class frmMain : Form
    {
        private DialogResult dialogMain;
        private bool textChanged = false; // parameter to definite text input?
        private string currentFileName = "";

        public frmMain()
        {
            InitializeComponent();
            richTextWord.Multiline = true;
            richTextWord.AcceptsTab = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //xóa richTextBox
            richTextWord.Clear();
            //đặt lại tên
            currentFileName = "";
            //cờ chưa nhập text
            textChanged = false;
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                dialogMain = MessageBox.Show("Do you want to save changes?", "Save changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogMain == DialogResult.Yes)
                {
                    saveMenuItem_Click(null, null);
                }
                else if (dialogMain == DialogResult.Cancel)
                {
                    richTextWord.Focus();
                }
                else
                {
                    currentFileName = "";
                    textChanged = false;
                    richTextWord.Clear();
                    richTextWord.Focus();
                }
            }
            else
            {
                currentFileName = "";
                textChanged = false;
                richTextWord.Clear();
                richTextWord.Focus();
            }
        }

        public void savefile()
        {
            dialogMain = MessageBox.Show("Do you want to save this file?", "Save file option", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogMain == DialogResult.Yes)
            {
                saveMenuItem_Click(null, null);
                textChanged = false;
            }
            else if (dialogMain == DialogResult.No)
            {
                return;
            }
        }

        public string openFile(string filter)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = filter;//"txt files (*.txt)|*.txt|All files (*.*)|*.*";
                op.FilterIndex = 0;
                op.ShowDialog();
                if (op.FileName != "")
                    this.Text = op.FileName.Split('\\')[op.FileName.Split('\\').Length - 1];
                return op.FileName;
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //mở file
            currentFileName = openFileDialog.FileName;
            richTextWord.LoadFile(currentFileName);
            richTextWord.Focus();
            textChanged = false;
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //tên file lưu
            currentFileName = saveFileDialog.FileName;
            //thực hiện lưu file
            richTextWord.SaveFile(currentFileName, RichTextBoxStreamType.UnicodePlainText);
            //đặt lại biến cờ chưa nhập text
            textChanged = false;
            richTextWord.Focus();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            // File name is not null
            if (currentFileName == "")
            {
                saveFileDialog.Filter = "All file|*.*";
                saveFileDialog.ShowDialog();
            }
            else
            {
                // Save for content to input
                richTextWord.SaveFile(currentFileName, RichTextBoxStreamType.UnicodePlainText);
                richTextWord.Focus();
                // Change parameter flat input content
                textChanged = false;
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            //lưu file với tên khác
            saveFileDialog.Filter = "All file|*.*";
            saveFileDialog.ShowDialog();
        }

        private void printMenuItem_Click(object sender, EventArgs e)
        {
            //hiển thị hộp thoại in
            dialogMain = printDialog.ShowDialog();
            //thông báo thành công nếu chọn OK/Print
            if (dialogMain == DialogResult.OK)
            {
                MessageBox.Show("Your file has been print successfully!", "Print info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //thông báo thất bại nếu chọn Cancel
            else
            {
                MessageBox.Show("Pringting file has been canceled!", "Print info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printPreviewMenuItem_Click(object sender, EventArgs e)
        {
            //tạo mới 1 document
            System.Drawing.Printing.PrintDocument document = new
                System.Drawing.Printing.PrintDocument();
            //tên của document được tạo là tên văn bản
            document.DocumentName = currentFileName;
            //thuộc tính document của printPreviewDialog
            printPreviewDialog.Document = document;
            //hiển thị hộp thoại
            printPreviewDialog.ShowDialog();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)//nếu đã nhập văn bản
            {
                //hiển thị hộp thoại có lưu hay không
                dialogMain = MessageBox.Show("Do you want to save changes?", "Confirm save file",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dialogMain == DialogResult.Yes)//nếu lưu
                {
                    //lưu và thoát
                    //saveToolStripMenuItem_Click(null, null);
                    saveFileDialog.Filter = "All file|*.*";
                    saveFileDialog.ShowDialog();

                    Close();
                }
                else if (dialogMain == DialogResult.Cancel)//nếu hủy
                {
                    //tiếp tục nhập văn bản
                    richTextWord.Focus();
                }
                else//dialogMain == DialogResult.NO
                {
                    Close();
                }
            }
            else//nếu chưa nhập văn bản
            {
                //hiện thị hộp thoại thoát chương trình
                dialogMain = MessageBox.Show("Are you sure you want to quit?", "Confirm exit",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (dialogMain == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void richTextWord_TextChanged(object sender, EventArgs e)
        {
            //thay đổi cờ nhập text textChanged
            textChanged = true;
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextWord.CanUndo)
            {
                richTextWord.Undo();
            }
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextWord.CanRedo)
            {
                richTextWord.Redo();
            }
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            richTextWord.Cut();
            pasteMenuItem.Enabled = true;
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            richTextWord.Copy();
            pasteMenuItem.Enabled = true;
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextWord.Paste();
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            richTextWord.SelectAll();
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            dialogMain = fontDialog.ShowDialog();//mở hộp thoại chọn font
            if (dialogMain == DialogResult.OK)
            {
                //thay đổi font cho đoạn văn bản được bôi đen
                if (richTextWord.SelectedText.Length > 0)
                {
                    richTextWord.SelectionFont = fontDialog.Font;
                }
                //nếu không chọn thì thay đổi font cho tất cả
                else
                {
                    richTextWord.SelectAll();
                    richTextWord.Font = fontDialog.Font;
                }
                richTextWord.Focus();
            }
        }

        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            //Color defaultColor = DefaultForeColor;
            dialogMain = colorDialog.ShowDialog();
            if (dialogMain == DialogResult.OK)
            {
                //thay đổi màu chữ cho đoạn văn bản được bôi đen
                if (richTextWord.SelectedText.Length > 0)
                {
                    richTextWord.SelectionColor = colorDialog.Color;
                    //richTextWord.ForeColor = defaultColor;
                }
                //thay đổi màu chữ cho toàn bộ văn bản
                else
                {
                    richTextWord.SelectAll();
                    richTextWord.ForeColor = colorDialog.Color;
                }
                richTextWord.Focus();
            }
        }

        /// <summary>
        /// Event information find menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a dialog box for find
                fShowFindForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information find error, please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event Keydown for main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Get event for Ctrl + F
                if (e.Control && e.KeyCode == Keys.F)
                {
                    try
                    {
                        // Open a dialog box for find
                        fShowFindForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Information find error, please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Process key down error, please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool fShowFindForm()
        {
            bool blnResult = false;

            try
            {
                frmFind objFind;

                objFind = new frmFind(richTextWord);

                objFind.Show(this);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return blnResult;
        }

        public void aboutMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChanged)
            {
                dialogMain = MessageBox.Show("Do you want to save changes?", "Save changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dialogMain == DialogResult.Yes)
                {
                    saveMenuItem_Click(null, null);
                }
                else if (dialogMain == DialogResult.Cancel)
                {
                    richTextWord.Focus();
                }
                else
                {
                    currentFileName = "";
                    textChanged = false;
                    richTextWord.Clear();
                    richTextWord.Focus();
                }
            }
            else
            {
                currentFileName = "";
                textChanged = false;
                richTextWord.Clear();
                richTextWord.Focus();
            }

            if (MessageBox.Show("Do you want to exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                savefile();
            }

            try
            {
                // Open a dialog box to selection the file
                OpenFileDialog objDialog;
                objDialog = new OpenFileDialog();
                objDialog.CheckFileExists = true;
                objDialog.CheckPathExists = true;
                objDialog.Filter = "RTF File|*.rtf";

                if (objDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Load content of file
                    richTextWord.Rtf = File.ReadAllText(objDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load file error, please try agian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                savefile();
            }

            try
            {
                // Open a dialog box to selection the file
                string path = openFile("pdf file|*.pdf");
                if (path != "")
                {
                    richTextWord.Text = helper.readPDF(path);
                    richTextWord.Font = new Font("Times New Roman", 14);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load file error, please try agian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                savefile();
            }
            try
            {
                // Open a dialog box to selection the file
                string path = openFile("text File (*.txt,*.cs,*json,*js,*html,*css,*htm)|*.cs;*.json;*.js;*.html;*.css;*.htm.;*.txt");
                if (path != "")
                {
                    richTextWord.Text = helper.readText(path);
                    richTextWord.Font = new Font("Times New Roman", 12);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load file error, please try agian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChanged)
            {
                savefile();
            }

            try
            {
                InputBoxResult Url = InputBox.Show("Input Url: " + "\n" + "Ex: https://seakbz.github.io/"
              , "Input Url", "https://seakbz.github.io/", 100, 25);
                if (Url.Text != "")
                {
                    this.Text = "Open URL: " + Url.Text;
                    richTextWord.Text = helper.GetHTML(Url.Text);
                    richTextWord.Font = new Font("Times New Roman", 12);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load file error, please try agian!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextWord_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Get event for Ctrl + F
                if (e.Control && e.KeyCode == Keys.F)
                {
                    try
                    {
                        // Open a dialog box for find
                        fShowFindForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Information find error, please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Process key down error, please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}