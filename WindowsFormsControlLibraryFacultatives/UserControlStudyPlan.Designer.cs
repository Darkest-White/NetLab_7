namespace WindowsFormsControlLibraryFacultatives
{
    partial class UserControlStudyPlan
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelClient = new System.Windows.Forms.Label();
            this.textBoxStudent = new System.Windows.Forms.TextBox();
            this.labelRoom = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.labelStudyPlan = new System.Windows.Forms.Label();
            this.textBoxStudyPlan = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(3, 7);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(50, 13);
            this.labelClient.TabIndex = 0;
            this.labelClient.Text = "Студент:";
            // 
            // textBoxStudent
            // 
            this.textBoxStudent.Location = new System.Drawing.Point(55, 4);
            this.textBoxStudent.Name = "textBoxStudent";
            this.textBoxStudent.ReadOnly = true;
            this.textBoxStudent.Size = new System.Drawing.Size(263, 20);
            this.textBoxStudent.TabIndex = 1;
            // 
            // labelRoom
            // 
            this.labelRoom.AutoSize = true;
            this.labelRoom.Location = new System.Drawing.Point(324, 7);
            this.labelRoom.Name = "labelRoom";
            this.labelRoom.Size = new System.Drawing.Size(55, 13);
            this.labelRoom.TabIndex = 2;
            this.labelRoom.Text = "Предмет:";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(374, 4);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.ReadOnly = true;
            this.textBoxSubject.Size = new System.Drawing.Size(86, 20);
            this.textBoxSubject.TabIndex = 3;
            // 
            // labelStudyPlan
            // 
            this.labelStudyPlan.AutoSize = true;
            this.labelStudyPlan.Location = new System.Drawing.Point(3, 33);
            this.labelStudyPlan.Name = "labelStudyPlan";
            this.labelStudyPlan.Size = new System.Drawing.Size(82, 13);
            this.labelStudyPlan.TabIndex = 4;
            this.labelStudyPlan.Text = "Учебный план:";
            // 
            // textBoxStudyPlan
            // 
            this.textBoxStudyPlan.Location = new System.Drawing.Point(122, 30);
            this.textBoxStudyPlan.Name = "textBoxStudyPlan";
            this.textBoxStudyPlan.ReadOnly = true;
            this.textBoxStudyPlan.Size = new System.Drawing.Size(305, 20);
            this.textBoxStudyPlan.TabIndex = 5;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(433, 29);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(27, 21);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "x";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // UserControlStudyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxStudyPlan);
            this.Controls.Add(this.labelStudyPlan);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.labelRoom);
            this.Controls.Add(this.textBoxStudent);
            this.Controls.Add(this.labelClient);
            this.Name = "UserControlStudyPlan";
            this.Size = new System.Drawing.Size(474, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.TextBox textBoxStudent;
        private System.Windows.Forms.Label labelRoom;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label labelStudyPlan;
        private System.Windows.Forms.TextBox textBoxStudyPlan;
        private System.Windows.Forms.Button buttonDelete;
    }
}
