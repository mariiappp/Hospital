namespace Hospital.WinForms
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
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.textBoxOffice = new System.Windows.Forms.TextBox();
            this.labelOffice = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxExperience = new System.Windows.Forms.TextBox();
            this.labelExperience = new System.Windows.Forms.Label();
            this.comboBoxSpecialization = new System.Windows.Forms.ComboBox();
            this.labelSpecialization = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelFullName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewDoctors = new System.Windows.Forms.DataGridView();
            this.groupBoxBusiness = new System.Windows.Forms.GroupBox();
            this.btnFindExperienced = new System.Windows.Forms.Button();
            this.textBoxMinExperience = new System.Windows.Forms.TextBox();
            this.labelMinExperience = new System.Windows.Forms.Label();
            this.btnGroupBySpecialization = new System.Windows.Forms.Button();
            this.btnToggleTable = new System.Windows.Forms.Button();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpecialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExperience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOffice = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.groupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).BeginInit();
            this.groupBoxBusiness.SuspendLayout();
            this.SuspendLayout();

            this.groupBoxInput.Controls.Add(this.textBoxOffice);
            this.groupBoxInput.Controls.Add(this.labelOffice);
            this.groupBoxInput.Controls.Add(this.textBoxPhone);
            this.groupBoxInput.Controls.Add(this.labelPhone);
            this.groupBoxInput.Controls.Add(this.textBoxExperience);
            this.groupBoxInput.Controls.Add(this.labelExperience);
            this.groupBoxInput.Controls.Add(this.comboBoxSpecialization);
            this.groupBoxInput.Controls.Add(this.labelSpecialization);
            this.groupBoxInput.Controls.Add(this.textBoxFullName);
            this.groupBoxInput.Controls.Add(this.labelFullName);
            this.groupBoxInput.Controls.Add(this.btnDelete);
            this.groupBoxInput.Controls.Add(this.btnUpdate);
            this.groupBoxInput.Controls.Add(this.btnAdd);
            this.groupBoxInput.Controls.Add(this.btnToggleTable);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(760, 120);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "УЧЁТ ВРАЧЕЙ";

            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(10, 25);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(37, 15);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.Text = "ФИО:";

            this.textBoxFullName.Location = new System.Drawing.Point(120, 22);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(200, 23);
            this.textBoxFullName.TabIndex = 1;

            this.labelSpecialization.AutoSize = true;
            this.labelSpecialization.Location = new System.Drawing.Point(10, 54);
            this.labelSpecialization.Name = "labelSpecialization";
            this.labelSpecialization.Size = new System.Drawing.Size(95, 15);
            this.labelSpecialization.TabIndex = 2;
            this.labelSpecialization.Text = "Специализация:";

            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(120, 51);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            this.comboBoxSpecialization.Size = new System.Drawing.Size(150, 23);
            this.comboBoxSpecialization.TabIndex = 3;

            this.labelExperience.AutoSize = true;
            this.labelExperience.Location = new System.Drawing.Point(340, 25);
            this.labelExperience.Name = "labelExperience";
            this.labelExperience.Size = new System.Drawing.Size(38, 15);
            this.labelExperience.TabIndex = 4;
            this.labelExperience.Text = "Стаж:";

            this.textBoxExperience.Location = new System.Drawing.Point(400, 22);
            this.textBoxExperience.Name = "textBoxExperience";
            this.textBoxExperience.Size = new System.Drawing.Size(60, 23);
            this.textBoxExperience.TabIndex = 5;

            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(340, 54);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(55, 15);
            this.labelPhone.TabIndex = 6;
            this.labelPhone.Text = "Телефон:";

            this.textBoxPhone.Location = new System.Drawing.Point(400, 51);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(150, 23);
            this.textBoxPhone.TabIndex = 7;

            this.labelOffice.AutoSize = true;
            this.labelOffice.Location = new System.Drawing.Point(570, 25);
            this.labelOffice.Name = "labelOffice";
            this.labelOffice.Size = new System.Drawing.Size(62, 15);
            this.labelOffice.TabIndex = 8;
            this.labelOffice.Text = "Кабинет:";

            this.textBoxOffice.Location = new System.Drawing.Point(640, 22);
            this.textBoxOffice.Name = "textBoxOffice";
            this.textBoxOffice.Size = new System.Drawing.Size(60, 23);
            this.textBoxOffice.TabIndex = 9;

            this.btnAdd.Location = new System.Drawing.Point(10, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 25);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(110, 85);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 25);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(210, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 25);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnToggleTable.Location = new System.Drawing.Point(310, 85);
            this.btnToggleTable.Name = "btnToggleTable";
            this.btnToggleTable.Size = new System.Drawing.Size(150, 25);
            this.btnToggleTable.TabIndex = 13;
            this.btnToggleTable.Text = "Показать таблицу";
            this.btnToggleTable.UseVisualStyleBackColor = true;
            this.btnToggleTable.Click += new System.EventHandler(this.btnToggleTable_Click);

            this.dataGridViewDoctors.AllowUserToAddRows = false;
            this.dataGridViewDoctors.AllowUserToDeleteRows = false;
            this.dataGridViewDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDoctors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnFullName,
            this.ColumnSpecialization,
            this.ColumnExperience,
            this.ColumnPhone,
            this.ColumnOffice});
            this.dataGridViewDoctors.Location = new System.Drawing.Point(12, 138);
            this.dataGridViewDoctors.Name = "dataGridViewDoctors";
            this.dataGridViewDoctors.ReadOnly = true;
            this.dataGridViewDoctors.Size = new System.Drawing.Size(760, 200);
            this.dataGridViewDoctors.TabIndex = 1;
            this.dataGridViewDoctors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDoctors_CellClick);

            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 50;

            this.ColumnFullName.HeaderText = "ФИО";
            this.ColumnFullName.Name = "ColumnFullName";
            this.ColumnFullName.ReadOnly = true;
            this.ColumnFullName.Width = 150;

            this.ColumnSpecialization.HeaderText = "Специализация";
            this.ColumnSpecialization.Name = "ColumnSpecialization";
            this.ColumnSpecialization.ReadOnly = true;
            this.ColumnSpecialization.Width = 120;

            this.ColumnExperience.HeaderText = "Стаж";
            this.ColumnExperience.Name = "ColumnExperience";
            this.ColumnExperience.ReadOnly = true;
            this.ColumnExperience.Width = 60;

            this.ColumnPhone.HeaderText = "Телефон";
            this.ColumnPhone.Name = "ColumnPhone";
            this.ColumnPhone.ReadOnly = true;
            this.ColumnPhone.Width = 120;

            this.ColumnOffice.HeaderText = "Кабинет";
            this.ColumnOffice.Name = "ColumnOffice";
            this.ColumnOffice.ReadOnly = true;
            this.ColumnOffice.Width = 80;

            this.groupBoxBusiness.Controls.Add(this.btnFindExperienced);
            this.groupBoxBusiness.Controls.Add(this.textBoxMinExperience);
            this.groupBoxBusiness.Controls.Add(this.labelMinExperience);
            this.groupBoxBusiness.Controls.Add(this.btnGroupBySpecialization);
            this.groupBoxBusiness.Location = new System.Drawing.Point(12, 344);
            this.groupBoxBusiness.Name = "groupBoxBusiness";
            this.groupBoxBusiness.Size = new System.Drawing.Size(760, 100);
            this.groupBoxBusiness.TabIndex = 2;
            this.groupBoxBusiness.TabStop = false;
            this.groupBoxBusiness.Text = "";

            this.btnGroupBySpecialization.Location = new System.Drawing.Point(10, 30);
            this.btnGroupBySpecialization.Name = "btnGroupBySpecialization";
            this.btnGroupBySpecialization.Size = new System.Drawing.Size(200, 30);
            this.btnGroupBySpecialization.TabIndex = 0;
            this.btnGroupBySpecialization.Text = "Группировать по специализации";
            this.btnGroupBySpecialization.UseVisualStyleBackColor = true;
            this.btnGroupBySpecialization.Click += new System.EventHandler(this.btnGroupBySpecialization_Click);

            this.labelMinExperience.AutoSize = true;
            this.labelMinExperience.Location = new System.Drawing.Point(10, 70);
            this.labelMinExperience.Name = "labelMinExperience";
            this.labelMinExperience.Size = new System.Drawing.Size(120, 15);
            this.labelMinExperience.TabIndex = 1;
            this.labelMinExperience.Text = "Минимальный стаж:";

            this.textBoxMinExperience.Location = new System.Drawing.Point(140, 67);
            this.textBoxMinExperience.Name = "textBoxMinExperience";
            this.textBoxMinExperience.Size = new System.Drawing.Size(60, 23);
            this.textBoxMinExperience.TabIndex = 2;
            this.textBoxMinExperience.Text = "10";

            this.btnFindExperienced.Location = new System.Drawing.Point(210, 65);
            this.btnFindExperienced.Name = "btnFindExperienced";
            this.btnFindExperienced.Size = new System.Drawing.Size(150, 25);
            this.btnFindExperienced.TabIndex = 3;
            this.btnFindExperienced.Text = "Найти опытных";
            this.btnFindExperienced.UseVisualStyleBackColor = true;
            this.btnFindExperienced.Click += new System.EventHandler(this.btnFindExperienced_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 456);
            this.Controls.Add(this.groupBoxBusiness);
            this.Controls.Add(this.dataGridViewDoctors);
            this.Controls.Add(this.groupBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт врачей";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDoctors)).EndInit();
            this.groupBoxBusiness.ResumeLayout(false);
            this.groupBoxBusiness.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.TextBox textBoxOffice;
        private System.Windows.Forms.Label labelOffice;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxExperience;
        private System.Windows.Forms.Label labelExperience;
        private System.Windows.Forms.ComboBox comboBoxSpecialization;
        private System.Windows.Forms.Label labelSpecialization;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnToggleTable;
        private System.Windows.Forms.DataGridView dataGridViewDoctors;
        private System.Windows.Forms.GroupBox groupBoxBusiness;
        private System.Windows.Forms.Button btnFindExperienced;
        private System.Windows.Forms.TextBox textBoxMinExperience;
        private System.Windows.Forms.Label labelMinExperience;
        private System.Windows.Forms.Button btnGroupBySpecialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpecialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExperience;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOffice;
    }

    #endregion
}

