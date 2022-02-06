using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BibleRecitation
{
    public partial class Form1 : Form
    {
        // 음성인식용
        readonly private static string wavDirPath = Environment.CurrentDirectory + @"\Wav";
        readonly private static string wavFileName = "record.wav";
        readonly private static string wavFilePath = wavDirPath + "\\" + wavFileName;
        readonly private Recorder recorder = new Recorder(0, wavDirPath, wavFileName);
        readonly private STT stt = new STT(wavFilePath);

        // 성구 리스트
        readonly private List<BibleVerse> listBV = new List<BibleVerse>();

        // 타이머용
        readonly private MyTimer myTimer = new MyTimer();

        // 개수 세기
        private int allVerseCount; // 성경구절의 총 개수
        private int currentVerseNum;   // 현재 성경구절 번째
        private int correctVerseCount;   // 맞은 성경구절 개수

        // 랜덤 성구 선정용
        private int[] randArray;
        private int index;

        public Form1()
        {
            InitializeComponent();

            progressBar1.Maximum = myTimer.GetMaxSec() * 100;
            timer1.Interval = 10;

        }

        // 로그 저장 함수
        public void LogSave(string str)
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

        private void ResultSave(int all, int correct)
        {
            string fileName = txtName.Text;

            string dirPath = Environment.CurrentDirectory + @"\Result";
            string filePath = dirPath + "\\" + fileName + ".txt";
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
                        temp = string.Format("[{0}] {1}개 중 {2}개 정답", DateTime.Now, all, correct);
                        sw.WriteLine(temp);
                        sw.Close();
                    }

                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        temp = string.Format("[{0}] {1}개 중 {2}정답", DateTime.Now, all, correct);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }

                temp = string.Format("{0} 결과 저장 완료", fileName);
                LogSave(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 성경구절 읽어서 리스트에 저장하는 함수
        private bool ReadVerse(List<BibleVerse> listBV)
        {
            string vsDirPath = Environment.CurrentDirectory + @"\Verse";
            string vsFileName = "verse.txt";
            string vsFilePath = vsDirPath + "\\" + vsFileName;

            DirectoryInfo di = new DirectoryInfo(vsFilePath);
            FileInfo fi = new FileInfo(vsFilePath);

            string[] lines;

            string temp;

            try
            {
                if (!di.Exists) Directory.CreateDirectory(vsDirPath);

                if (fi.Exists)
                {
                    lines = File.ReadAllLines(vsFilePath);

                    foreach (string str in lines)
                    {
                        string[] subStr = str.Split(')');

                        if (subStr.Length != 2)
                        {
                            temp = "파일이 올바르지 않습니다.";
                            LogSave("[error] " + temp);
                            MessageBox.Show(temp, "알림");
                            return false;
                        }

                        BibleVerse bv = new BibleVerse(subStr[0], subStr[1]);
                        listBV.Add(bv);
                    }

                    temp = string.Format("{0}개 성구 추가 완료", listBV.Count);
                    LogSave(temp);

                    return true;
                }
                else
                {
                    temp = "파일이 존재하지 않습니다.";
                    LogSave("[error] " + temp);
                    MessageBox.Show(temp, "알림");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // 암송 시작 함수
        private void RecitStart()
        {
            if (!ReadVerse(listBV)) return;

            randArray = GetRandomInt(listBV.Count);

            if (numVerse.Value < listBV.Count)
            {
                allVerseCount = Convert.ToInt16(numVerse.Value);
            }
            else
            {
                allVerseCount = listBV.Count;
            }

            currentVerseNum = 1;
            correctVerseCount = 0;
            index = randArray[currentVerseNum - 1];

            labAllVerse.Text = allVerseCount.ToString();
            labCurrentVerse.Text = currentVerseNum.ToString();
            labCorrectVerse.Text = correctVerseCount.ToString();

            labVerseHead.Text = listBV[index].Head;
            txtVerseBody.Text = listBV[index].Body;

            btnStart.Text = "종료";

            // 암송 시작 후 컨트롤속성 수정
            gbMode.Enabled = false;
            txtName.Enabled = false;
            btnSTT.Enabled = true;
            btnNext.Enabled = true;
            txtVerse.Enabled = true;
            numVerse.Enabled = false;
            chkShow.Enabled = true;
            txtVerseBody.Visible = false;

            if (txtName.Text == string.Empty)
            {
                txtName.Text = "익명";
            }

            if (rbTest.Checked)
            {
                chkShow.Enabled = false;
                timer1.Enabled = true;
                timer1.Tick += timer1_Tick;
            }
            else
            {
                chkShow.Checked = true;
                timer2.Enabled = true;
                timer2.Tick += timer2_Tick;
            }

            txtVerse.Focus();

            LogSave("성구암송 시작");

        }

        // 암송 종료 함수
        private void RecitEnd()
        {
            myTimer.Reset();

            if (rbTest.Checked && currentVerseNum != 0)
            {
                ResultSave(currentVerseNum, correctVerseCount);
            }

            //string temp = string.Format("{0}님은 {1}개 중 {2}개를 맞추셨습니다.", txtName.Text, currentVerseNum, correctVerseCount);
            //MessageBox.Show(temp, "성구암송 종료");


            // 암송 종료 후 컨트롤속성 수정
            timer1.Enabled = false;
            timer2.Enabled = false;
            btnSTT.Enabled = false;
            gbMode.Enabled = true;
            txtName.Enabled = true;
            btnNext.Enabled = false;
            txtVerseBody.Visible = true;
            txtVerse.Enabled = false;
            numVerse.Enabled = true;
            chkShow.Enabled = false;
            chkShow.Checked = false;

            // 암송 종료 후 텍스트 초기화
            btnStart.Text = "시작";
            labVerseHead.Text = "두란노 성구암송";
            txtVerseBody.Text = string.Empty;
            labVerseCheck.Text = string.Empty;
            txtVerse.Text = string.Empty;
            labTimer.Text = "00초";
            txtName.Text = string.Empty;

            progressBar1.Value = 0;

            allVerseCount = 0;
            currentVerseNum = 0;
            correctVerseCount = 0;

            labAllVerse.Text = allVerseCount.ToString();
            labCurrentVerse.Text = currentVerseNum.ToString();
            labCorrectVerse.Text = correctVerseCount.ToString();

            listBV.Clear();

            LogSave("성구암송 종료");
        }

        // 실시간으로 체크하여 글씨 변경
        private void RealTimeCheck()
        {
            int len = (txtVerseBody.Text.Length > txtVerse.Text.Length) ? txtVerse.Text.Length : txtVerseBody.Text.Length;

            txtVerseBody.SelectAll();
            txtVerseBody.SelectionColor = Color.Black;
            txtVerseBody.SelectionFont = new Font(txtVerseBody.Font.FontFamily,
                                                     txtVerseBody.Font.Size,
                                                     FontStyle.Regular);

            for (int i = 0; i < len; i++)
            {
                if (txtVerseBody.Text[i] == ' ' || txtVerseBody.Text[i] == txtVerse.Text[i])
                {
                    txtVerseBody.Select(i, 1);
                    txtVerseBody.SelectionColor = Color.Blue;

                }
                else
                {
                    txtVerseBody.Select(i, 1);
                    txtVerseBody.SelectionColor = Color.Red;
                    txtVerseBody.SelectionFont = new Font(txtVerseBody.Font.FontFamily,
                                                             txtVerseBody.Font.Size,
                                                             FontStyle.Underline);
                }


            }

        }

        // 성구 정답 확인 함수
        private void VerseCheck(string correct, string answer)
        {
            correct = RemoveGap(correct);
            answer = RemoveGap(answer);

            if (answer.Equals(correct))
            {
                labCorrectVerse.Text = (++correctVerseCount).ToString();

                labVerseCheck.Text = "정답 O";
                labVerseCheck.ForeColor = System.Drawing.Color.Blue;
                LogSave("성구확인: 정답");
            }
            else
            {
                labVerseCheck.Text = "오답 X";
                labVerseCheck.ForeColor = System.Drawing.Color.Red;
                LogSave("성구확인: 오답");
            }

        }

        private bool NextVerse()
        {
            VerseCheck(txtVerse.Text, listBV[index].Body);

            currentVerseNum++;

            if (currentVerseNum <= allVerseCount)
            {
                myTimer.Reset();

                labCurrentVerse.Text = currentVerseNum.ToString();

                index = randArray[currentVerseNum-1];
                labVerseHead.Text = listBV[index].Head;
                txtVerseBody.Text = listBV[index].Body;
                
                txtVerse.Text = string.Empty;

                LogSave("다음 성구");

                return true;
            }
            else
            {
                RecitEnd();
                return false;
            }
        }

        // 랜덤 생성 함수
        private int[] GetRandomInt(int max)
        {
            int[] randArray = new int[max];
            bool isSame;

            Random rand = new Random();

            for (int i = 0; i < max; i++)
            {
                while (true)
                {
                    randArray[i] = rand.Next(max);
                    isSame = false;

                    for (int j = 0; j < i; j++)
                    {
                        if (randArray[j] == randArray[i])
                        {
                            isSame = true;
                            break;
                        }
                    }
                    if (!isSame) break;

                }
            }

            return randArray;
}

        private string RemoveGap(string str)
        {
            string noGapStr = string.Empty;

            foreach (char c in str)
            {
                if (c != ' ')
                {
                    noGapStr += c;
                }
            }

            return noGapStr;
        }

        // 음성인식 시작 및 종료 버튼 함수
        private void btnSTT_Click(object sender, EventArgs e)
        {
            if (btnSTT.Text.Equals("음성인식"))
            {
                btnSTT.Text = "인식종료";
                recorder.StartRecording();  // 녹음시작
                LogSave("음성인식 시작");

            }
            else if( btnSTT.Text.Equals("인식종료"))
            {
                btnSTT.Text = "음성인식";
                recorder.RecordEnd();   // 녹음종료
                txtVerse.Text += stt.Run();    // 음성 텍스트 변환
                LogSave("음성인식 종료");

            }
            else btnSTT.Text = "음성인식";

        }

        // 성구암송 시작 및 종료 버튼 함수
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("시작"))
            {
                RecitStart();

            }
            else if(btnStart.Text.Equals("종료"))
            {
                RecitEnd();

            }
            else btnStart.Text = "시작";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTimer.Text = string.Format("{0:##}초", myTimer.Sec);
            progressBar1.Value = Convert.ToInt16(myTimer.Sec * 100 + myTimer.Ms);

            if (myTimer.TimeOver())
            {
                LogSave("시간종료");

                if (!NextVerse()) return;
            }

            myTimer.Decrease();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RealTimeCheck();
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked == true)
            {
                txtVerseBody.Visible = true;
            }
            else
            {
                txtVerseBody.Visible = false;
            }
        }

        private void txtVerse_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnNext_Click(sender, e);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextVerse();
        }

    }
}
