using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrayerNote
{
    public partial class FormSave : Form
    {
        private PrayerNote parent;
        private ListView lstPrayer;

        public FormSave(PrayerNote parent, ListView list)
        {
            InitializeComponent();
            this.parent = parent;
            this.lstPrayer = list;
        }

        // 파일 리스트를 불러오는 함수
        private void File_List_Get()
        {
            string dirPath = Environment.CurrentDirectory + @"\Save";

            DirectoryInfo di = new DirectoryInfo(dirPath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(dirPath);

                FileInfo[] files = di.GetFiles();
                
                if (di.GetFiles().Length > 0)
                {
                    lstFile.Items.Clear();
                
                    for(int i = 0; i < files.Length; i++)
                    {
                        lstFile.Items.Add(files[i].Name);
                    }

                    lstFile.SetSelected(0, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 리스트뷰 항목을 저장하기 쉽게 문자열로 만들어 주는 함수
        private string List_To_String()
        {
            int itemCount = lstPrayer.Items.Count;
            int subItemCount = lstPrayer.Items[0].SubItems.Count;
            string str = "";
            
            for (int i = 0; i < itemCount; i++)
            {
                for (int j = 0; j < subItemCount; j++)
                {
                    str += lstPrayer.Items[i].SubItems[j].Text.ToString();

                    if (j < subItemCount - 1)
                    {
                        str += " ";
                    }
                }

                if (i < itemCount - 1)
                {
                    str += "\r\n";
                }

            }

            return str;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            File_List_Get();
        }

        private void lstFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFile.Text = lstFile.SelectedItem.ToString();
        }

        // 파일 저장 함수(버튼클릭)
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dirPath = Environment.CurrentDirectory + @"\Save";
            string filePath = dirPath + "\\" + txtFile.Text;
            string temp = "";

            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo fi = new FileInfo(filePath);

            DialogResult overWrite = DialogResult.No;

            try
            {
                if (!di.Exists) Directory.CreateDirectory(dirPath);
                if (!fi.Exists)
                {

                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        temp = List_To_String();
                        sw.WriteLine(temp);
                        sw.Close();
                    }

                    temp = "\r\n" + temp + " 저장";
                    parent.Log_Save(temp);

                    MessageBox.Show("파일이 저장되었습니다.", "알림");

                    this.Close();
                }
                else
                {
                    overWrite = MessageBox.Show("파일명이 중복됩니다. 덮어쓰시겠습니까?", "알림", MessageBoxButtons.YesNo);
                    if (overWrite == DialogResult.Yes)
                    {
                        using (StreamWriter sw = new StreamWriter(filePath))
                        {
                            temp = List_To_String();
                            sw.WriteLine(temp);
                            sw.Close();
                        }

                        temp = "\r\n" + temp + " 저장";
                        parent.Log_Save(temp);

                        MessageBox.Show("파일이 저장되었습니다.", "알림");

                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 파일 불러오기 함수(버튼클릭)
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string dirPath = Environment.CurrentDirectory + @"\Save";
            string filePath = dirPath + "\\" + txtFile.Text;
            string[] subItem = new string[lstPrayer.Columns.Count];
            string[] lines;
            string temp = "";

            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo fi = new FileInfo(filePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(dirPath);
                if (fi.Exists)
                {
                    lstPrayer.Items.Clear();

                    lines = File.ReadAllLines(filePath);
                    
                    foreach (string str in lines)
                    {
                        subItem = str.Split(' ');
                        lstPrayer.Items.Add(new ListViewItem(subItem));
                        temp += "\r\n" + str;
                    }

                    temp += " 불러오기";
                    parent.Log_Save(temp);

                    MessageBox.Show("파일을 불러왔습니다.", "알림");

                    this.Close();
                }
                else
                {
                    temp = "error: 존재하지 않는 파일";
                    parent.Log_Save(temp);

                    MessageBox.Show("파일이 존재하지 않습니다.", "알림");                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // 파일 삭제 함수 버튼 클릭
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string dirPath = Environment.CurrentDirectory + @"\Save";
            string filePath = dirPath + "\\" + txtFile.Text;
            string temp = "";

            FileInfo fi = new FileInfo(filePath);

            DialogResult deleteFile = DialogResult.No;

            try
            {
                if (fi.Exists)
                {
                    deleteFile = MessageBox.Show("정말로 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo);
                    if (deleteFile == DialogResult.Yes)
                    {
                        fi.Delete();
                        File_List_Get();

                        temp = fi.FullName + " 삭제";
                        parent.Log_Save(temp);

                        MessageBox.Show("파일이 삭제되었습니다.", "알림");
                    }


                }
                else
                {
                    temp = "error: 존재하지 않는 파일";
                    parent.Log_Save(temp);

                    MessageBox.Show("파일이 존재하지 않습니다.", "알림");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
