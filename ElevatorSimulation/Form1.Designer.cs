namespace ElevatorSimulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            grpLiftA = new GroupBox();
            lblDoorA = new Label();
            btnA1 = new Button();
            btnA0 = new Button();
            pnlLiftA = new Panel();
            pnlDoorRightA = new Panel();
            pnlDoorLeftA = new Panel();
            lblFloorA = new Label();
            grpLiftB = new GroupBox();
            lblDoorB = new Label();
            btnB0 = new Button();
            btnB1 = new Button();
            pnlLiftB = new Panel();
            pnlDoorLeftB = new Panel();
            pnlDoorRightB = new Panel();
            lblFloorB = new Label();
            grpRequests = new GroupBox();
            btnRequests1 = new Button();
            btnRequest0 = new Button();
            grpFloorStatus = new GroupBox();
            lblStatus1 = new Label();
            lblStatus0 = new Label();
            btnViewLogs = new Button();
            grpSystemControl = new GroupBox();
            btnHelp = new Button();
            btnEmergency = new Button();
            btnReset = new Button();
            btnStop = new Button();
            btnStart = new Button();
            grpLog = new GroupBox();
            dgvLogs = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grpLiftA.SuspendLayout();
            pnlLiftA.SuspendLayout();
            grpLiftB.SuspendLayout();
            pnlLiftB.SuspendLayout();
            grpRequests.SuspendLayout();
            grpFloorStatus.SuspendLayout();
            grpSystemControl.SuspendLayout();
            grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.LightSteelBlue;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(105, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(900, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ELEVATOR SIMULATION SYSTEM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpLiftA
            // 
            grpLiftA.BackColor = Color.Honeydew;
            grpLiftA.Controls.Add(lblDoorA);
            grpLiftA.Controls.Add(btnA1);
            grpLiftA.Controls.Add(btnA0);
            grpLiftA.Controls.Add(pnlLiftA);
            grpLiftA.Controls.Add(lblFloorA);
            grpLiftA.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpLiftA.ForeColor = Color.DarkGreen;
            grpLiftA.Location = new Point(42, 102);
            grpLiftA.Name = "grpLiftA";
            grpLiftA.Size = new Size(537, 496);
            grpLiftA.TabIndex = 1;
            grpLiftA.TabStop = false;
            grpLiftA.Text = "ELEVATOR A";
            // 
            // lblDoorA
            // 
            lblDoorA.AutoSize = true;
            lblDoorA.Location = new Point(118, 438);
            lblDoorA.Name = "lblDoorA";
            lblDoorA.Size = new Size(133, 28);
            lblDoorA.TabIndex = 4;
            lblDoorA.Text = "Door: Closed";
            // 
            // btnA1
            // 
            btnA1.Location = new Point(239, 122);
            btnA1.Name = "btnA1";
            btnA1.Size = new Size(40, 35);
            btnA1.TabIndex = 2;
            btnA1.Text = "1";
            btnA1.UseVisualStyleBackColor = true;
            btnA1.Click += btnA1_Click;
            // 
            // btnA0
            // 
            btnA0.Location = new Point(239, 163);
            btnA0.Name = "btnA0";
            btnA0.Size = new Size(40, 35);
            btnA0.TabIndex = 0;
            btnA0.Text = "0";
            btnA0.UseVisualStyleBackColor = true;
            btnA0.Click += btnA0_Click;
            // 
            // pnlLiftA
            // 
            pnlLiftA.BackColor = Color.Gray;
            pnlLiftA.BorderStyle = BorderStyle.FixedSingle;
            pnlLiftA.Controls.Add(pnlDoorRightA);
            pnlLiftA.Controls.Add(pnlDoorLeftA);
            pnlLiftA.Location = new Point(143, 79);
            pnlLiftA.Name = "pnlLiftA";
            pnlLiftA.Size = new Size(90, 345);
            pnlLiftA.TabIndex = 0;
            // 
            // pnlDoorRightA
            // 
            pnlDoorRightA.BackColor = Color.LightSkyBlue;
            pnlDoorRightA.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorRightA.Location = new Point(44, 226);
            pnlDoorRightA.Name = "pnlDoorRightA";
            pnlDoorRightA.Size = new Size(41, 114);
            pnlDoorRightA.TabIndex = 0;
            // 
            // pnlDoorLeftA
            // 
            pnlDoorLeftA.BackColor = Color.LightSkyBlue;
            pnlDoorLeftA.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorLeftA.Location = new Point(4, 226);
            pnlDoorLeftA.Name = "pnlDoorLeftA";
            pnlDoorLeftA.Size = new Size(45, 114);
            pnlDoorLeftA.TabIndex = 8;
            // 
            // lblFloorA
            // 
            lblFloorA.BackColor = Color.DarkSeaGreen;
            lblFloorA.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloorA.Location = new Point(118, 41);
            lblFloorA.Name = "lblFloorA";
            lblFloorA.Size = new Size(160, 35);
            lblFloorA.TabIndex = 2;
            lblFloorA.Text = "Floor: 0";
            lblFloorA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpLiftB
            // 
            grpLiftB.BackColor = Color.Honeydew;
            grpLiftB.Controls.Add(lblDoorB);
            grpLiftB.Controls.Add(btnB0);
            grpLiftB.Controls.Add(btnB1);
            grpLiftB.Controls.Add(pnlLiftB);
            grpLiftB.Controls.Add(lblFloorB);
            grpLiftB.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpLiftB.ForeColor = Color.DarkGreen;
            grpLiftB.Location = new Point(696, 102);
            grpLiftB.Name = "grpLiftB";
            grpLiftB.Size = new Size(509, 496);
            grpLiftB.TabIndex = 0;
            grpLiftB.TabStop = false;
            grpLiftB.Text = "ELEVATOR B";
            // 
            // lblDoorB
            // 
            lblDoorB.AutoSize = true;
            lblDoorB.Location = new Point(160, 438);
            lblDoorB.Name = "lblDoorB";
            lblDoorB.Size = new Size(133, 28);
            lblDoorB.TabIndex = 5;
            lblDoorB.Text = "Door: Closed";
            // 
            // btnB0
            // 
            btnB0.Location = new Point(292, 163);
            btnB0.Name = "btnB0";
            btnB0.Size = new Size(40, 35);
            btnB0.TabIndex = 2;
            btnB0.Text = "0";
            btnB0.UseVisualStyleBackColor = true;
            btnB0.Click += btnB0_Click;
            // 
            // btnB1
            // 
            btnB1.Location = new Point(292, 122);
            btnB1.Name = "btnB1";
            btnB1.Size = new Size(40, 35);
            btnB1.TabIndex = 3;
            btnB1.Text = "1";
            btnB1.UseVisualStyleBackColor = true;
            btnB1.Click += btnB1_Click;
            // 
            // pnlLiftB
            // 
            pnlLiftB.BackColor = Color.Gray;
            pnlLiftB.BorderStyle = BorderStyle.FixedSingle;
            pnlLiftB.Controls.Add(pnlDoorLeftB);
            pnlLiftB.Controls.Add(pnlDoorRightB);
            pnlLiftB.Location = new Point(196, 79);
            pnlLiftB.Name = "pnlLiftB";
            pnlLiftB.Size = new Size(90, 345);
            pnlLiftB.TabIndex = 4;
            // 
            // pnlDoorLeftB
            // 
            pnlDoorLeftB.BackColor = Color.LightSkyBlue;
            pnlDoorLeftB.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorLeftB.Location = new Point(3, 4);
            pnlDoorLeftB.Name = "pnlDoorLeftB";
            pnlDoorLeftB.Size = new Size(45, 114);
            pnlDoorLeftB.TabIndex = 8;
            // 
            // pnlDoorRightB
            // 
            pnlDoorRightB.BackColor = Color.LightSkyBlue;
            pnlDoorRightB.BorderStyle = BorderStyle.FixedSingle;
            pnlDoorRightB.Location = new Point(44, 4);
            pnlDoorRightB.Name = "pnlDoorRightB";
            pnlDoorRightB.Size = new Size(41, 114);
            pnlDoorRightB.TabIndex = 0;
            // 
            // lblFloorB
            // 
            lblFloorB.BackColor = Color.DarkSeaGreen;
            lblFloorB.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFloorB.Location = new Point(160, 41);
            lblFloorB.Name = "lblFloorB";
            lblFloorB.Size = new Size(160, 35);
            lblFloorB.TabIndex = 3;
            lblFloorB.Text = "Floor: 1";
            lblFloorB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpRequests
            // 
            grpRequests.Controls.Add(btnRequests1);
            grpRequests.Controls.Add(btnRequest0);
            grpRequests.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRequests.Location = new Point(42, 656);
            grpRequests.Name = "grpRequests";
            grpRequests.Size = new Size(278, 130);
            grpRequests.TabIndex = 2;
            grpRequests.TabStop = false;
            grpRequests.Text = "FLOOR REQUESTS";
            // 
            // btnRequests1
            // 
            btnRequests1.BackColor = Color.LightSteelBlue;
            btnRequests1.ForeColor = Color.MidnightBlue;
            btnRequests1.Location = new Point(3, 71);
            btnRequests1.Name = "btnRequests1";
            btnRequests1.Size = new Size(120, 40);
            btnRequests1.TabIndex = 1;
            btnRequests1.Text = "Floor 1";
            btnRequests1.UseVisualStyleBackColor = false;
            btnRequests1.Click += btnRequests1_Click;
            // 
            // btnRequest0
            // 
            btnRequest0.BackColor = Color.LightSteelBlue;
            btnRequest0.ForeColor = Color.MidnightBlue;
            btnRequest0.Location = new Point(3, 27);
            btnRequest0.Name = "btnRequest0";
            btnRequest0.Size = new Size(120, 40);
            btnRequest0.TabIndex = 0;
            btnRequest0.Text = "Floor 0";
            btnRequest0.UseVisualStyleBackColor = false;
            btnRequest0.Click += btnRequest0_Click;
            // 
            // grpFloorStatus
            // 
            grpFloorStatus.Controls.Add(lblStatus1);
            grpFloorStatus.Controls.Add(lblStatus0);
            grpFloorStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFloorStatus.Location = new Point(892, 665);
            grpFloorStatus.Name = "grpFloorStatus";
            grpFloorStatus.Size = new Size(300, 121);
            grpFloorStatus.TabIndex = 3;
            grpFloorStatus.TabStop = false;
            grpFloorStatus.Text = "FLOOR STATUS";
            // 
            // lblStatus1
            // 
            lblStatus1.Location = new Point(57, 62);
            lblStatus1.Name = "lblStatus1";
            lblStatus1.Size = new Size(187, 35);
            lblStatus1.TabIndex = 1;
            lblStatus1.Text = "Floor 1: Lift B";
            lblStatus1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStatus0
            // 
            lblStatus0.Location = new Point(29, 27);
            lblStatus0.Name = "lblStatus0";
            lblStatus0.Size = new Size(239, 35);
            lblStatus0.TabIndex = 0;
            lblStatus0.Text = "Floor 0: Lift A";
            lblStatus0.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnViewLogs
            // 
            btnViewLogs.Location = new Point(816, 921);
            btnViewLogs.Name = "btnViewLogs";
            btnViewLogs.Size = new Size(200, 40);
            btnViewLogs.TabIndex = 2;
            btnViewLogs.Text = "VIEW ELEVATOR LOGS";
            btnViewLogs.UseVisualStyleBackColor = true;
            btnViewLogs.Click += btnViewLogs_Click;
            // 
            // grpSystemControl
            // 
            grpSystemControl.Controls.Add(btnHelp);
            grpSystemControl.Controls.Add(btnEmergency);
            grpSystemControl.Controls.Add(btnReset);
            grpSystemControl.Controls.Add(btnStop);
            grpSystemControl.Controls.Add(btnStart);
            grpSystemControl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSystemControl.Location = new Point(458, 665);
            grpSystemControl.Name = "grpSystemControl";
            grpSystemControl.Size = new Size(275, 121);
            grpSystemControl.TabIndex = 6;
            grpSystemControl.TabStop = false;
            grpSystemControl.Text = "SYSTEM CONTROL";
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.LightYellow;
            btnHelp.ForeColor = Color.DarkRed;
            btnHelp.Location = new Point(5, 24);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(112, 34);
            btnHelp.TabIndex = 8;
            btnHelp.Text = "HELP";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnEmergency
            // 
            btnEmergency.ForeColor = Color.Red;
            btnEmergency.Location = new Point(129, 25);
            btnEmergency.Name = "btnEmergency";
            btnEmergency.Size = new Size(140, 35);
            btnEmergency.TabIndex = 8;
            btnEmergency.Text = "EMERGENCY";
            btnEmergency.UseVisualStyleBackColor = true;
            btnEmergency.Click += btnEmergency_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.LightGray;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(199, 66);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(70, 35);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Red;
            btnStop.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStop.ForeColor = Color.WhiteSmoke;
            btnStop.Location = new Point(103, 66);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(70, 35);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Green;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.WhiteSmoke;
            btnStart.Location = new Point(6, 66);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(70, 35);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // grpLog
            // 
            grpLog.BackColor = Color.White;
            grpLog.Controls.Add(dgvLogs);
            grpLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpLog.ForeColor = Color.DarkGreen;
            grpLog.Location = new Point(45, 820);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(718, 261);
            grpLog.TabIndex = 7;
            grpLog.TabStop = false;
            grpLog.Text = "ELEVATOR OPERATION LOGS";
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.BackgroundColor = Color.White;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Location = new Point(27, 50);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.RowHeadersWidth = 62;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(650, 150);
            dgvLogs.TabIndex = 8;
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Interval = 50;
            timer2.Tick += timer2_Tick;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1318, 1170);
            Controls.Add(grpLiftA);
            Controls.Add(grpLog);
            Controls.Add(grpSystemControl);
            Controls.Add(btnViewLogs);
            Controls.Add(grpFloorStatus);
            Controls.Add(grpRequests);
            Controls.Add(grpLiftB);
            Controls.Add(lblTitle);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ELEVATOR SIMULATION SYSTEM";
            grpLiftA.ResumeLayout(false);
            grpLiftA.PerformLayout();
            pnlLiftA.ResumeLayout(false);
            grpLiftB.ResumeLayout(false);
            grpLiftB.PerformLayout();
            pnlLiftB.ResumeLayout(false);
            grpRequests.ResumeLayout(false);
            grpFloorStatus.ResumeLayout(false);
            grpSystemControl.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpLiftA;
        private GroupBox grpLiftB;
        private Label lblFloorB;
        private Label lblFloorA;
        private Panel pnlLiftA;
        private Panel pnlLiftB;
        private Button btnA0;
        
        private Button btnB0;
        private Button btnB1;
        private Button btnA1;
        private GroupBox grpRequests;
        //private Button button2;
        private Button btnRequest0;
        private Button btnRequests1;
        private GroupBox grpFloorStatus;
        private Label lblStatus0;
        private Label lblStatus1;
        private Button btnViewLogs;
        private Label lblDoorA;
        private Label lblDoorB;
        private GroupBox grpSystemControl;
        private Button btnReset;
        private Button btnStop;
        private Button btnStart;
        private GroupBox grpLog;
        private DataGridView dgvLogs;
        private Panel pnlDoorRightA;
        private Panel pnlDoorLeftA;
        private Panel pnlDoorRightB;
        private Panel pnlDoorLeftB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Button btnEmergency;
        private Button btnHelp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
