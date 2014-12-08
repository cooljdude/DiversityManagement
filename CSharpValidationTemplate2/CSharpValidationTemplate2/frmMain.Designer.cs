partial class frmMain
{
    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.btnSchool = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(163, 216);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(263, 216);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "E&XIT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(41, 83);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(75, 23);
            this.btnStudent.TabIndex = 2;
            this.btnStudent.Text = "button1";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.Location = new System.Drawing.Point(142, 83);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(75, 23);
            this.btnProgram.TabIndex = 3;
            this.btnProgram.Text = "button2";
            this.btnProgram.UseVisualStyleBackColor = true;
            // 
            // btnSchool
            // 
            this.btnSchool.Location = new System.Drawing.Point(248, 83);
            this.btnSchool.Name = "btnSchool";
            this.btnSchool.Size = new System.Drawing.Size(75, 23);
            this.btnSchool.TabIndex = 4;
            this.btnSchool.Text = "button3";
            this.btnSchool.UseVisualStyleBackColor = true;
            this.btnSchool.Click += new System.EventHandler(this.btnSchool_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(356, 83);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(75, 23);
            this.btnStaff.TabIndex = 5;
            this.btnStaff.Text = "button4";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(456, 262);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnSchool);
            this.Controls.Add(this.btnProgram);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Name = "frmMain";
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnStudent;
    private System.Windows.Forms.Button btnProgram;
    private System.Windows.Forms.Button btnSchool;
    private System.Windows.Forms.Button btnStaff;
}