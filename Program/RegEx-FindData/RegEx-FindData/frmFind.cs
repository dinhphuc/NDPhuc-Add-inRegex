using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegEx_FindData
{
    public partial class frmFind : Form
    {
        private RichTextBox richTextBox;             // Text box for content
        private List<LineSelect> mlstLine = new List<LineSelect>();                 // List return result find
        private List<KetQua> lstKQ = new List<KetQua>();

        public frmFind(RichTextBox richTextBox)
        {
            InitializeComponent();
            this.richTextBox = richTextBox;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                           new ComboboxItem { Text = "Tất cả", Value = "ALL"},
                           new ComboboxItem { Text = "Gmail", Value = "Gmail"},
                           new ComboboxItem { Text = "Facebook", Value = "Facebook"},
                           new ComboboxItem { Text = "Yahoo", Value = "Yahoo"},
                           new ComboboxItem { Text = "Outlook", Value = "Outlook"},
                           new ComboboxItem { Text = "Loại Khác", Value = "Other"}
                      });
            cbLoc.SelectedIndex = 0;
        }

        public List<KetQua> Find(string input, string strRegex, bool blnIgnorCase = true)
        {
            List<KetQua> kq = new List<KetQua>();

            try
            {
                Regex objRegex;
                int i = 1;
                // Create object
                if (blnIgnorCase)
                {
                    objRegex = new Regex(strRegex, RegexOptions.IgnoreCase);
                }
                else
                {
                    objRegex = new Regex(strRegex);
                }
                // Find
                foreach (Match objMatch in objRegex.Matches(input))
                {
                    // If found then set back color is yellow green.
                    richTextBox.Select(objMatch.Index, objMatch.Length);
                    richTextBox.SelectionBackColor = System.Drawing.Color.YellowGreen;
                    mlstLine.Add(new LineSelect { STT = i, index = objMatch.Index, LengthSelect = objMatch.Length });
                    kq.Add(new KetQua { STT = i, KetQuaMatch = objMatch.ToString() });
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return kq;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete current data
                fClearSelection();
                dtgvKQ.Controls.Clear();
                mlstLine.Clear();
                // Option email selected
                if (rdEmail.Checked)
                {
                    string rex = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[AZ]{2,4}\b";
                    switch (cbLoc.SelectedIndex)
                    {
                        case 0:
                            rex = @"\b[A-Z0-9._+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b";
                            break;

                        case 1:
                            rex = @"\b[a-z0-9](\.?[a-z0-9]){5,}@g?(G)?mail\.com";
                            break;

                        case 2:
                            rex = @"\b[a-z0-9](\.?[a-z0-9]){5,}@f?(F)?acebook\.com";
                            break;

                        case 3:
                            rex = @"\b[a-z0-9](\.?[a-z0-9]){5,}@y?(Y)?ahoo\.com";
                            break;

                        case 4:
                            rex = @"\b[a-z0-9](\.?[a-z0-9]){5,}@o?(O)?utlook\.com";
                            break;

                        case 5:
                            string pattern = @"\w+";
                            RegexOptions options = RegexOptions.Multiline;
                            string newregx = @"";
                            foreach (Match m in Regex.Matches(inputLoc.Text, pattern, options))
                            {
                                newregx += "+.[" + m.ToString() + "]";
                            }
                            rex = @"\b[a-z0-9](\.?[a-z0-9]){5,}@" + newregx + "+";
                            break;
                    }
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
                // Option phone selected
                if (rdPhone.Checked)
                {
                    string rex = @"";
                    switch (cbLoc.SelectedIndex)
                    {
                        case 0:
                            rex = @"(\(\+84\)\s\d{9,10})|((09)[0-9]{8})|((0)[0-9]{1}[ .][0-9]{3}[ .][0-9]{3}[ .][0-9]{2})|((09)[0-9]{2}[ .][0-9]{3}[ .][0-9]{3})|((09)[0-9]{1}[ .][0-9]{3}[ .][0-9]{4})|((012)[0-9]{8})|((012)[0-9]{1}[ .][0-9]{3}[ .][0-9]{4})|((016)[2-9]{1}[0-9]{7})|((016)[2-9]{1}[ .][0-9]{3}[ .][0-9]{4})";
                            break;

                        case 1:
                            rex = @"(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}";
                            break;

                        case 2:
                            rex = @"((\(\+1\)\s\d{9,10}))";
                            break;

                        case 3:
                            rex = @"((\(\+61\)\s\d{9,10}))";
                            break;

                        case 4:
                            rex = @"((\(\+86\)\s\d{9,10}))";
                            break;

                        case 5:
                            rex = @"((\(\+91\)\s\d{9,10}))";
                            break;

                        case 6:
                            rex = @"((\(\+81\)\s\d{7,10}))";
                            break;

                        case 7:
                            rex = @"((\(\+33\)\s\d{9,10}))";
                            break;

                        case 8:
                            rex = string.Format(@"((\(\{0}\)\s\d{9,10}))", inputLoc.Text);
                            break;
                    }
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }

                // Option name selected
                if (rdName.Checked)
                {
                    string rex = (@"([A-ZÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ][qwertyuiopasdfghjklzxcvbnmàáâãèéêìíòóôõùúăđĩũơưăạảấầẩẫậắằẳẵặẹẻẽềềếểễệỉịọỏốồổỗộớờởỡợụủứừửữựỳỵỷỹ]+\s){3,5}");
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex, false);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }

                // Option URL selected
                if (rdURL.Checked)
                {
                    //string rex = @"(http|https|ftp|href=")\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]";
                    string rex = @"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?";
                    lstKQ = Find(richTextBox.Text, rex);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }

                // Option date selected
                if (rdDate.Checked)
                {
                    // (dd/mm/yyyy) | (mm/dd/yyyy) | (yyyy/mm/dd)
                    string rex = (@"((0[1-9]|[12][0-9]|3[01]|[1-9])[- /.]([1-9]|0[1-9]|1[012])[- /.]((19|20)\d\d))|(([1-9]|0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01]|[1-9])[- /.]((19|20)\d\d))|(((19|20)\d\d)[- /.]([1-9]|0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01]|[1-9]))");
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
                if (radIP.Checked)
                {
                    string rex = "";
                    switch (cbLoc.SelectedIndex)
                    {
                        case 0:   // 192.168.0.1
                            rex = (@"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])");
                            break;

                        case 1: //FE80:0000:0000:0000:0202:B3FF:FE1E:8329
                            rex = @"(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))";
                            break;
                    }

                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex, false);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
                if (radCard.Checked)
                {
                    string rex = @"(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})";
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex, false);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
                if (radTienTe.Checked)
                {
                    string rex = "";

                    switch (cbLoc.SelectedIndex)
                    {
                        case 0:
                            rex = @"(VND|Đồng)\s?(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2}))|(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?)\s?(VND|Đồng)";
                            break;

                        case 1:
                            rex = @"(USD|\$)\s?(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2}))|(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?)\s?(USD|\$)";
                            break;

                        case 2:
                            rex = @"(EUR|€)\s?(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2}))|(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?)\s?(EUR|€)";
                            break;

                        case 3:
                            string dau = string.Format("({0})", inputLoc.Text.Trim());
                            rex = dau + @"\s?(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2}))|(\d{1,3}(?:[.,]\d{3})*(?:[.,]\d{2})?)\s?" + dau;
                            break;
                    }
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex, false);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
                if (radFile.Checked)
                {
                    string rex = "";
                    switch (cbLoc.SelectedIndex)
                    {
                        case 0: //Văn bản
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.(docx|html|odt|xls|xlsx|pdf|pps|ppsx|ppt|pptx|rtf|txt|xps|epub|fb2|lit|lrf|mobi|pdb|rb|tcr|PRC|json|css)";
                            break;

                        case 1: //Video
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.(AVI|OGM|MPG|MP4|MPEG-4|3GP|MKV|MIDI|flv|avi|ogm|mp4|mpeg-4|3gp|mkv|wmv|flac|mov)";
                            break;

                        case 2: //Hình Ảnh
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.(JPEG|GIF|PNG|JPG|TIFF|BMP|jpeg|gif|png|jpg|tiff|bmp|jp2|ico|tga)";
                            break;

                        case 3: //Nén
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.(7z|ace|zip|rar|tar.gz|jar|tar|cab)";
                            break;

                        case 4: //âm thanh
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.(wav|flac|mp3|AAC|WMA|ogg|ac3|wav)";
                            break;

                        case 5: //Văn bản
                            rex = @"([a-zA-Z0-9-_ ]{1,})\.";
                            string temp = string.Format(@"({0})", inputLoc.Text.Trim());
                            rex = rex + temp;
                            break;
                    }
                    lstKQ.Clear();
                    lstKQ = Find(richTextBox.Text, rex);
                    helper.Hienthi(dtgvKQ, lstKQ);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool fClearSelection()
        {
            bool blnResult = false;

            try
            {
                //select start and end poit -> set back color is white
                richTextBox.SelectionStart = 0;
                richTextBox.SelectionLength = richTextBox.Text.Length;
                richTextBox.SelectionBackColor = Color.White;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return blnResult;
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoc.SelectedIndex == 5 && rdEmail.Checked)
            {
                inputLoc.Visible = true;
                inputLoc.Text = "mta.edu.vn";
            }
            if (rdPhone.Checked && cbLoc.SelectedIndex == 8)
            {
                inputLoc.Visible = true;
                inputLoc.Text = "(+84)";
            }
            if (radTienTe.Checked && cbLoc.SelectedIndex == 3)
            {
                inputLoc.Visible = true;
                inputLoc.Text = "Nhân dân tệ|RMB";
            }
            if (radFile.Checked && cbLoc.SelectedIndex == 5)
            {
                inputLoc.Visible = true;
                inputLoc.Text = "cs|js";
            }
        }

        //Dữ liệu lọc
        #region

        private void rdPhone_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Enabled = true;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                           new ComboboxItem { Text = "Việt Nam (+84)", Value = "VN"},
                           new ComboboxItem { Text = "Vương Quốc Anh (+44)", Value = "UK"},
                           new ComboboxItem { Text = "US (+1)", Value = "US"},
                           new ComboboxItem { Text = "Úc (+61)", Value = "AU"},
                           new ComboboxItem { Text = "Trung Quốc (+86)", Value = "CN"},
                           new ComboboxItem { Text = "Ấn Độ (+91)", Value = "India"},
                           new ComboboxItem { Text = "Nhật Bản (+81)", Value = "JP"},
                           new ComboboxItem { Text = "Pháp (+33)", Value = "Fr"},
                           new ComboboxItem { Text = "Nước khác", Value = "Other"}
                      });
            cbLoc.SelectedIndex = 0;
        }

        private void rdEmail_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Enabled = true;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                           new ComboboxItem { Text = "Tất cả", Value = "ALL"},
                           new ComboboxItem { Text = "Gmail", Value = "Gmail"},
                           new ComboboxItem { Text = "Facebook", Value = "Facebook"},
                           new ComboboxItem { Text = "Yahoo", Value = "Yahoo"},
                           new ComboboxItem { Text = "Outlook", Value = "Outlook"},
                           new ComboboxItem { Text = "Loại Khác", Value = "Other"}
                      });
            cbLoc.SelectedIndex = 0;
        }

        private void rdURL_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Items.Clear();
            cbLoc.Enabled = false;
        }

        private void radIP_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Enabled = true;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                           new ComboboxItem { Text = "IP V4", Value = "V4"},
                           new ComboboxItem { Text = "IP V6", Value = "V6"},
                      });
            cbLoc.SelectedIndex = 0;
        }

        private void radCard_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Items.Clear();
            cbLoc.Enabled = false;
        }

        private void radTienTe_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Enabled = true;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                        new ComboboxItem { Text = "Việt Nam", Value = "VN"},
                        new ComboboxItem { Text = "Mĩ", Value = "US"},
                        new ComboboxItem { Text = "Châu Âu", Value = "EU"},
                        new ComboboxItem { Text = "Nước khác", Value = "other"},
                      });
            cbLoc.SelectedIndex = 0;
        }

        private void radDiaChi_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radFile_CheckedChanged(object sender, EventArgs e)
        {
            inputLoc.Visible = false;
            cbLoc.Enabled = true;
            cbLoc.Items.Clear();
            cbLoc.Items.AddRange(
                        new ComboboxItem[] {
                           new ComboboxItem { Text = "Văn Bản", Value = "document"},
                           new ComboboxItem { Text = "Video", Value = "video"},
                           new ComboboxItem { Text = "Hình Ảnh", Value = "picture"},
                           new ComboboxItem { Text = "File Nén", Value = "archive"},
                           new ComboboxItem { Text = "Âm Thanh", Value = "sound"},
                           new ComboboxItem { Text = "Loại Khác", Value = "Other"}
                      });
            cbLoc.SelectedIndex = 0;
        }

        #endregion

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            helper.ExportToExcel(dtgvKQ);
        }

        private int CurR = 0;
        private int i;

        private void dtgvKQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurR = dtgvKQ.CurrentCell.RowIndex;
            i = CurR;
            richTextBox.Select(mlstLine.Find(x => x.STT == (i + 1)).index, mlstLine.Find(x => x.STT == (i + 1)).LengthSelect);

            richTextBox.ScrollToCaret();
            richTextBox.SelectionBackColor = System.Drawing.Color.Yellow;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<KetQua> temp = new List<KetQua>();
            foreach (KetQua kq in lstKQ)
            {
                if (kq.KetQuaMatch.Contains(txtLoc.Text))
                {
                    temp.Add(kq);
                }
            }
            helper.Hienthi(dtgvKQ, temp);
            temp.Clear();
        }

        private void rdName_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}