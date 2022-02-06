namespace BibleRecitation
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSTT = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.labVerseHead = new System.Windows.Forms.Label();
            this.txtVerse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labVerseCheck = new System.Windows.Forms.Label();
            this.labAllVerse = new System.Windows.Forms.Label();
            this.labCurrentVerse = new System.Windows.Forms.Label();
            this.labCorrectVerse = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbTest = new System.Windows.Forms.RadioButton();
            this.rbPratice = new System.Windows.Forms.RadioButton();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.numVerse = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.txtVerseBody = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVerse)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSTT
            // 
            this.btnSTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSTT.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSTT.Enabled = false;
            this.btnSTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSTT.Font = new System.Drawing.Font("배달의민족 주아", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSTT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSTT.Location = new System.Drawing.Point(905, 584);
            this.btnSTT.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSTT.Name = "btnSTT";
            this.btnSTT.Size = new System.Drawing.Size(180, 98);
            this.btnSTT.TabIndex = 4;
            this.btnSTT.TabStop = false;
            this.btnSTT.Text = "음성인식";
            this.btnSTT.UseVisualStyleBackColor = false;
            this.btnSTT.Click += new System.EventHandler(this.btnSTT_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("배달의민족 주아", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(12, 584);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 98);
            this.btnStart.TabIndex = 3;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labVerseHead
            // 
            this.labVerseHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labVerseHead.Font = new System.Drawing.Font("배달의민족 주아", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labVerseHead.Location = new System.Drawing.Point(12, 63);
            this.labVerseHead.Name = "labVerseHead";
            this.labVerseHead.Size = new System.Drawing.Size(1073, 89);
            this.labVerseHead.TabIndex = 5;
            this.labVerseHead.Text = "두란노 성구암송";
            this.labVerseHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVerse
            // 
            this.txtVerse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerse.BackColor = System.Drawing.Color.White;
            this.txtVerse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVerse.Enabled = false;
            this.txtVerse.Font = new System.Drawing.Font("배달의민족 주아", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVerse.Location = new System.Drawing.Point(12, 444);
            this.txtVerse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVerse.Multiline = true;
            this.txtVerse.Name = "txtVerse";
            this.txtVerse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVerse.Size = new System.Drawing.Size(1073, 130);
            this.txtVerse.TabIndex = 1;
            this.txtVerse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVerse_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "전체:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "현재:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "정답:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(589, 9);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar1.Maximum = 3000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(498, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.Location = new System.Drawing.Point(529, 7);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(61, 27);
            this.labTimer.TabIndex = 8;
            this.labTimer.Text = "00초";
            this.labTimer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labVerseCheck
            // 
            this.labVerseCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labVerseCheck.AutoSize = true;
            this.labVerseCheck.Font = new System.Drawing.Font("배달의민족 주아", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labVerseCheck.Location = new System.Drawing.Point(139, 85);
            this.labVerseCheck.Name = "labVerseCheck";
            this.labVerseCheck.Size = new System.Drawing.Size(0, 44);
            this.labVerseCheck.TabIndex = 9;
            // 
            // labAllVerse
            // 
            this.labAllVerse.AutoSize = true;
            this.labAllVerse.Location = new System.Drawing.Point(60, 9);
            this.labAllVerse.Name = "labAllVerse";
            this.labAllVerse.Size = new System.Drawing.Size(27, 27);
            this.labAllVerse.TabIndex = 10;
            this.labAllVerse.Text = "0";
            this.labAllVerse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCurrentVerse
            // 
            this.labCurrentVerse.AutoSize = true;
            this.labCurrentVerse.Location = new System.Drawing.Point(209, 9);
            this.labCurrentVerse.Name = "labCurrentVerse";
            this.labCurrentVerse.Size = new System.Drawing.Size(27, 27);
            this.labCurrentVerse.TabIndex = 11;
            this.labCurrentVerse.Text = "0";
            this.labCurrentVerse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCorrectVerse
            // 
            this.labCorrectVerse.AutoSize = true;
            this.labCorrectVerse.Location = new System.Drawing.Point(345, 9);
            this.labCorrectVerse.Name = "labCorrectVerse";
            this.labCorrectVerse.Size = new System.Drawing.Size(27, 27);
            this.labCorrectVerse.TabIndex = 12;
            this.labCorrectVerse.Text = "0";
            this.labCorrectVerse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(878, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 33);
            this.txtName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(822, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 33);
            this.label4.TabIndex = 14;
            this.label4.Text = "성명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbTest
            // 
            this.rbTest.AutoSize = true;
            this.rbTest.Checked = true;
            this.rbTest.Location = new System.Drawing.Point(26, 32);
            this.rbTest.Name = "rbTest";
            this.rbTest.Size = new System.Drawing.Size(109, 31);
            this.rbTest.TabIndex = 15;
            this.rbTest.TabStop = true;
            this.rbTest.Text = "시험모드";
            this.rbTest.UseVisualStyleBackColor = true;
            // 
            // rbPratice
            // 
            this.rbPratice.AutoSize = true;
            this.rbPratice.Location = new System.Drawing.Point(26, 61);
            this.rbPratice.Name = "rbPratice";
            this.rbPratice.Size = new System.Drawing.Size(110, 31);
            this.rbPratice.TabIndex = 16;
            this.rbPratice.Text = "연습모드";
            this.rbPratice.UseVisualStyleBackColor = true;
            // 
            // gbMode
            // 
            this.gbMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbMode.Controls.Add(this.rbPratice);
            this.gbMode.Controls.Add(this.rbTest);
            this.gbMode.Location = new System.Drawing.Point(397, 584);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(154, 98);
            this.gbMode.TabIndex = 17;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "모드";
            // 
            // numVerse
            // 
            this.numVerse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numVerse.Location = new System.Drawing.Point(571, 646);
            this.numVerse.Name = "numVerse";
            this.numVerse.Size = new System.Drawing.Size(86, 33);
            this.numVerse.TabIndex = 5;
            this.numVerse.TabStop = false;
            this.numVerse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVerse.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(566, 615);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 27);
            this.label5.TabIndex = 19;
            this.label5.Text = "암송개수";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNext.Location = new System.Drawing.Point(981, 85);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(106, 44);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "다음";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // chkShow
            // 
            this.chkShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShow.AutoSize = true;
            this.chkShow.Enabled = false;
            this.chkShow.Font = new System.Drawing.Font("배달의민족 주아", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkShow.Location = new System.Drawing.Point(762, 584);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(135, 37);
            this.chkShow.TabIndex = 20;
            this.chkShow.Text = "정답보기";
            this.chkShow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // txtVerseBody
            // 
            this.txtVerseBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerseBody.BackColor = System.Drawing.Color.Cornsilk;
            this.txtVerseBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVerseBody.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtVerseBody.Font = new System.Drawing.Font("배달의민족 주아", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVerseBody.Location = new System.Drawing.Point(12, 159);
            this.txtVerseBody.Name = "txtVerseBody";
            this.txtVerseBody.ReadOnly = true;
            this.txtVerseBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtVerseBody.Size = new System.Drawing.Size(1073, 278);
            this.txtVerseBody.TabIndex = 21;
            this.txtVerseBody.Text = "";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1099, 697);
            this.Controls.Add(this.txtVerseBody);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numVerse);
            this.Controls.Add(this.gbMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labCorrectVerse);
            this.Controls.Add(this.labCurrentVerse);
            this.Controls.Add(this.labAllVerse);
            this.Controls.Add(this.labVerseCheck);
            this.Controls.Add(this.labTimer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVerse);
            this.Controls.Add(this.labVerseHead);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSTT);
            this.Font = new System.Drawing.Font("배달의민족 주아", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(-10, -10);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "두란노 성구암송";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbMode.ResumeLayout(false);
            this.gbMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVerse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSTT;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labVerseHead;
        private System.Windows.Forms.TextBox txtVerse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labVerseCheck;
        private System.Windows.Forms.Label labAllVerse;
        private System.Windows.Forms.Label labCurrentVerse;
        private System.Windows.Forms.Label labCorrectVerse;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbTest;
        private System.Windows.Forms.RadioButton rbPratice;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.NumericUpDown numVerse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.RichTextBox txtVerseBody;
        private System.Windows.Forms.Timer timer2;
    }
}

