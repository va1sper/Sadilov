namespace Sadilov
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbFromCurrency = new System.Windows.Forms.ComboBox();
            this.cmbToCurrency = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpHistoryDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.lblHistoryResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtAmount.Location = new System.Drawing.Point(48, 128);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 22);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "1";
            // 
            // cmbFromCurrency
            // 
            this.cmbFromCurrency.BackColor = System.Drawing.SystemColors.Highlight;
            this.cmbFromCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromCurrency.FormattingEnabled = true;
            this.cmbFromCurrency.Location = new System.Drawing.Point(279, 128);
            this.cmbFromCurrency.Name = "cmbFromCurrency";
            this.cmbFromCurrency.Size = new System.Drawing.Size(121, 24);
            this.cmbFromCurrency.TabIndex = 1;
            // 
            // cmbToCurrency
            // 
            this.cmbToCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToCurrency.FormattingEnabled = true;
            this.cmbToCurrency.Location = new System.Drawing.Point(279, 168);
            this.cmbToCurrency.Name = "cmbToCurrency";
            this.cmbToCurrency.Size = new System.Drawing.Size(121, 24);
            this.cmbToCurrency.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConvert.Location = new System.Drawing.Point(549, 109);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(148, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Конвертировать";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(546, 276);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(205, 16);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Результат отобразится здесь";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(546, 398);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 16);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Готов к работе";
            // 
            // dtpHistoryDate
            // 
            this.dtpHistoryDate.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.dtpHistoryDate.Location = new System.Drawing.Point(12, 220);
            this.dtpHistoryDate.Name = "dtpHistoryDate";
            this.dtpHistoryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpHistoryDate.TabIndex = 6;
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShowHistory.Location = new System.Drawing.Point(549, 158);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(148, 42);
            this.btnShowHistory.TabIndex = 7;
            this.btnShowHistory.Text = "Показать исторический курс";
            this.btnShowHistory.UseVisualStyleBackColor = false;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // lblHistoryResult
            // 
            this.lblHistoryResult.AllowDrop = true;
            this.lblHistoryResult.AutoSize = true;
            this.lblHistoryResult.Location = new System.Drawing.Point(546, 336);
            this.lblHistoryResult.Name = "lblHistoryResult";
            this.lblHistoryResult.Size = new System.Drawing.Size(205, 16);
            this.lblHistoryResult.TabIndex = 8;
            this.lblHistoryResult.Text = "Результат отобразится здесь";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(276, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "КОНВЕРТЕР ВАЛЮТ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHistoryResult);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.dtpHistoryDate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.cmbToCurrency);
            this.Controls.Add(this.cmbFromCurrency);
            this.Controls.Add(this.txtAmount);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbFromCurrency;
        private System.Windows.Forms.ComboBox cmbToCurrency;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpHistoryDate;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.Label lblHistoryResult;
        private System.Windows.Forms.Label label1;
    }
}

