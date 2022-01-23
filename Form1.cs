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
    public partial class PrayerNote : Form
    {
        public PrayerNote()
        {
            InitializeComponent();
        }

        // 로그 저장 함수
        public void Log_Save(string str)
        {
            string dirPath = Environment.CurrentDirectory + @"\Log";
            string filePath = dirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(dirPath);
            FileInfo fi = new FileInfo(filePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(dirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 날짜 콤보박스 초기화 함수
        private void Date_Init()
        {
            int thisYear = DateTime.Today.Year;
            int thisMonth = DateTime.Today.Month;
            int thisDay = DateTime.Today.Day;

            // 년 콤보박스 초기화
            for (int i = thisYear-30; i <= thisYear+30; i++)
            {
                cmbYear.Items.Add(i);
            }
            cmbYear.SelectedItem = thisYear;

            // 달 콤보박스 초기화
            for (int i = 1; i <= 12; i++)
            {
                cmbMonth.Items.Add(i);
            }
            cmbMonth.SelectedItem = thisMonth;

            // 일 콤보박스 초기화
            for (int i = 1; i <= 31; i++)
            {
                cmbDay.Items.Add(i);
            }
            cmbDay.SelectedItem = thisDay;
        }

        // 리스트 사이즈 초기화 함수
        private void List_Size_Init()
        {
            // int listCount = listPrayer.Columns.Count; 
            int listWidth = lstPrayer.Width;

            lstPrayer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lstPrayer.Columns[0].Width = Convert.ToInt32(listWidth * 0.095);
            lstPrayer.Columns[1].Width = Convert.ToInt32(listWidth * 0.7);
            lstPrayer.Columns[2].Width = Convert.ToInt32(listWidth * 0.2);

        }

        // 기도제목이 입력되어 있는지 확인
        bool IsNull_tb(TextBox tb)
        {
            if(tb.Text == string.Empty)
            {
                return true;
            }

            return false;
        }

        // 창 로드
        private void PrayerNote_Load(object sender, EventArgs e)
        {
            Date_Init();    // 날짜 콤보박스 초기화
            List_Size_Init();    // 기도제목 리스트뷰 크기 초기화
        }

        // 창 크기 조절시 사이즈 재조정
        private void PrayerNote_Resize(object sender, EventArgs e)
        {
            List_Size_Init();
        }


        // 기도제목 추가 함수(버튼클릭)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string log = "";
            string[] subItem = new string[lstPrayer.Columns.Count];

            if(IsNull_tb(txtPrayerInput))
            {
                log = "error: 추가할 기도제목이 없음.";
                Log_Save(log);

                MessageBox.Show("기도제목을 입력하세요.", "알림");

                return;
            }

            subItem[0] = (lstPrayer.Items.Count + 1).ToString();
            subItem[1] = (txtPrayerInput.Text).ToString();
            subItem[2] = (cmbYear.Text + "-" + cmbMonth.Text + "-" + cmbDay.Text).ToString();

            txtPrayerInput.Clear();

            lstPrayer.Items.Add(new ListViewItem(subItem));
            

            log = subItem[0] + ", " + subItem[1] + ", " + subItem[2] + " 추가";
            Log_Save(log);

            MessageBox.Show("기도제목이 추가 되었습니다.", "알림");
        }

        // 기도제목 삭제 함수(버튼클릭)
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int selectCount = lstPrayer.SelectedItems.Count;
            int itemCount = 0;
            string log = "";

            if (selectCount > 0)
            {
                for(int i = 0; i < selectCount; i++)
                {

                    log = lstPrayer.SelectedItems[0].SubItems[0].Text.ToString() + ", "
                           + lstPrayer.SelectedItems[0].SubItems[1].Text.ToString() + ", "
                           + lstPrayer.SelectedItems[0].SubItems[2].Text.ToString() + " 삭제";
                    Log_Save(log);

                    lstPrayer.Items.RemoveAt(lstPrayer.SelectedItems[0].Index);
                }

                itemCount = lstPrayer.Items.Count;

                for (int i = 0; i < itemCount; i++)
                {
                    lstPrayer.Items[i].SubItems[0].Text = (i+1).ToString();
                }

                log = "순번 재정렬";
                Log_Save(log);

                MessageBox.Show("기도제목이 삭제되었습니다.", "알림");

            }
            else
            {
                log = "error: 삭제할 기도제목이 선택되지 않음.";
                Log_Save(log);

                MessageBox.Show("기도제목을 선택해 주세요.", "알림");
            }
        }

        // 기도제목 저장 폼 불러오는 함수(버튼클릭)
        private void btnFileControl_Click(object sender, EventArgs e)
        {
            FormSave childForm = new FormSave(this, lstPrayer);
            childForm.ShowDialog();
        }

        // 엔터기로 기도제목 추가
        private void txtPrayerInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }
    }
}
