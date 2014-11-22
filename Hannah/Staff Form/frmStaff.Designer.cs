partial class frmStaff
{
    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstStaff = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLastName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewFirstName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1166, 71);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(284, 73);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(592, 36);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Phone:";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(592, 73);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 20);
            this.txtFax.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fax:";
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(811, 36);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(100, 20);
            this.txtOffice.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(767, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Office:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1166, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstStaff
            // 
            this.lstStaff.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStaff.FormattingEnabled = true;
            this.lstStaff.ItemHeight = 14;
            this.lstStaff.Location = new System.Drawing.Point(12, 133);
            this.lstStaff.Name = "lstStaff";
            this.lstStaff.Size = new System.Drawing.Size(1265, 284);
            this.lstStaff.TabIndex = 24;
            this.lstStaff.TabStop = false;
            this.lstStaff.SelectedIndexChanged += new System.EventHandler(this.lstStaff_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(284, 36);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(208, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Title:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(95, 73);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(92, 36);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "First name:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1067, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1067, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1326, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(103, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewLastName,
            this.mnuViewFirstName,
            this.mnuViewTitle,
            this.mnuViewEmail,
            this.mnuViewPhone});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // mnuViewLastName
            // 
            this.mnuViewLastName.Name = "mnuViewLastName";
            this.mnuViewLastName.Size = new System.Drawing.Size(152, 22);
            this.mnuViewLastName.Text = "&LastName";
            this.mnuViewLastName.Click += new System.EventHandler(this.mnuViewLastName_Click);
            // 
            // mnuViewFirstName
            // 
            this.mnuViewFirstName.Name = "mnuViewFirstName";
            this.mnuViewFirstName.Size = new System.Drawing.Size(152, 22);
            this.mnuViewFirstName.Text = "&FirstName";
            this.mnuViewFirstName.Click += new System.EventHandler(this.mnuViewFirstName_Click);
            // 
            // mnuViewTitle
            // 
            this.mnuViewTitle.Name = "mnuViewTitle";
            this.mnuViewTitle.Size = new System.Drawing.Size(152, 22);
            this.mnuViewTitle.Text = "Title";
            this.mnuViewTitle.Click += new System.EventHandler(this.mnuViewTitle_Click_1);
            // 
            // mnuViewEmail
            // 
            this.mnuViewEmail.Name = "mnuViewEmail";
            this.mnuViewEmail.Size = new System.Drawing.Size(152, 22);
            this.mnuViewEmail.Text = "Email";
            this.mnuViewEmail.Click += new System.EventHandler(this.mnuViewEmail_Click);
            // 
            // mnuViewPhone
            // 
            this.mnuViewPhone.Name = "mnuViewPhone";
            this.mnuViewPhone.Size = new System.Drawing.Size(152, 22);
            this.mnuViewPhone.Text = "Phone";
            this.mnuViewPhone.Click += new System.EventHandler(this.mnuViewPhone_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(972, 39);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(972, 70);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1326, 436);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstStaff);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtOffice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Office of Diversity Staff";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtFax;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtOffice;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.ListBox lstStaff;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.ToolStripMenuItem mnuView;
    private System.Windows.Forms.ToolStripMenuItem mnuViewLastName;
    private System.Windows.Forms.ToolStripMenuItem mnuViewFirstName;
    private System.Windows.Forms.ToolStripMenuItem mnuViewTitle;
    private System.Windows.Forms.ToolStripMenuItem mnuViewEmail;
    private System.Windows.Forms.ToolStripMenuItem mnuViewPhone;
    private System.Windows.Forms.Button btnUpdate;
}