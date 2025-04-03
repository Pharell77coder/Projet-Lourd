namespace Projet_Lourd
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnModify = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(153, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(720, 440);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(12, 12);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(135, 49);
            btnModify.TabIndex = 1;
            btnModify.Text = "Modifier";
            btnModify.Click += btnModify_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 177);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 49);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Supprimer";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 49);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Annuler";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 67);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 49);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Ajouter";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Form3
            // 
            ClientSize = new Size(900, 500);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnModify);
            Controls.Add(btnCancel);
            Name = "Form3";
            ResumeLayout(false);
        }
    }
}
