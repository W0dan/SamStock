namespace SamStock.Stock.ComponentToevoegen
{
    partial class StockItemToevoegenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveAndCloseButton = new System.Windows.Forms.Button();
            this.componentToevoegenControl1 = new ComponentToevoegenControl();
            this.AddComponentbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(807, 414);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveAndCloseButton
            // 
            this.SaveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAndCloseButton.Location = new System.Drawing.Point(697, 414);
            this.SaveAndCloseButton.Name = "SaveAndCloseButton";
            this.SaveAndCloseButton.Size = new System.Drawing.Size(104, 23);
            this.SaveAndCloseButton.TabIndex = 2;
            this.SaveAndCloseButton.Text = "Save and close";
            this.SaveAndCloseButton.UseVisualStyleBackColor = true;
            // 
            // componentToevoegenControl1
            // 
            this.componentToevoegenControl1.Location = new System.Drawing.Point(13, 13);
            this.componentToevoegenControl1.Name = "componentToevoegenControl1";
            this.componentToevoegenControl1.Size = new System.Drawing.Size(670, 25);
            this.componentToevoegenControl1.TabIndex = 3;
            // 
            // AddComponentbutton
            // 
            this.AddComponentbutton.Location = new System.Drawing.Point(697, 13);
            this.AddComponentbutton.Name = "AddComponentbutton";
            this.AddComponentbutton.Size = new System.Drawing.Size(75, 23);
            this.AddComponentbutton.TabIndex = 4;
            this.AddComponentbutton.Text = "Add";
            this.AddComponentbutton.UseVisualStyleBackColor = true;
            this.AddComponentbutton.Click += new System.EventHandler(this.AddComponentbutton_Click);
            // 
            // StockItemToevoegenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 449);
            this.Controls.Add(this.AddComponentbutton);
            this.Controls.Add(this.componentToevoegenControl1);
            this.Controls.Add(this.SaveAndCloseButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "StockItemToevoegenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StockItemToevoegenForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveAndCloseButton;
        private Stock.ComponentToevoegen.ComponentToevoegenControl componentToevoegenControl1;
        private System.Windows.Forms.Button AddComponentbutton;
    }
}