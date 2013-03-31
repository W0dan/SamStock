namespace SamStock
{
    partial class SamStockForm
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
            this.StockGroupBox = new System.Windows.Forms.GroupBox();
            this.StockVerhogenButton = new System.Windows.Forms.Button();
            this.StockItemToevoegenButton = new System.Windows.Forms.Button();
            this.StockOverviewListView = new System.Windows.Forms.ListView();
            this.StockButton = new System.Windows.Forms.Button();
            this.PedalenButton = new System.Windows.Forms.Button();
            this.UitgaandeBestellingenButton = new System.Windows.Forms.Button();
            this.KlantenBestellingenButton = new System.Windows.Forms.Button();
            this.OnkostenButton = new System.Windows.Forms.Button();
            this.LogboekButton = new System.Windows.Forms.Button();
            this.HerstellingenButton = new System.Windows.Forms.Button();
            this.PedalenGroupBox = new System.Windows.Forms.GroupBox();
            this.BestellingenGroupBox = new System.Windows.Forms.GroupBox();
            this.StockGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StockGroupBox
            // 
            this.StockGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockGroupBox.Controls.Add(this.StockVerhogenButton);
            this.StockGroupBox.Controls.Add(this.StockItemToevoegenButton);
            this.StockGroupBox.Controls.Add(this.StockOverviewListView);
            this.StockGroupBox.Location = new System.Drawing.Point(12, 41);
            this.StockGroupBox.Name = "StockGroupBox";
            this.StockGroupBox.Size = new System.Drawing.Size(1066, 465);
            this.StockGroupBox.TabIndex = 2;
            this.StockGroupBox.TabStop = false;
            this.StockGroupBox.Text = "Stock";
            // 
            // StockVerhogenButton
            // 
            this.StockVerhogenButton.Location = new System.Drawing.Point(89, 20);
            this.StockVerhogenButton.Name = "StockVerhogenButton";
            this.StockVerhogenButton.Size = new System.Drawing.Size(75, 23);
            this.StockVerhogenButton.TabIndex = 4;
            this.StockVerhogenButton.Text = "Add Stock";
            this.StockVerhogenButton.UseVisualStyleBackColor = true;
            // 
            // StockItemToevoegenButton
            // 
            this.StockItemToevoegenButton.Location = new System.Drawing.Point(7, 20);
            this.StockItemToevoegenButton.Name = "StockItemToevoegenButton";
            this.StockItemToevoegenButton.Size = new System.Drawing.Size(75, 23);
            this.StockItemToevoegenButton.TabIndex = 3;
            this.StockItemToevoegenButton.Text = "Add Item";
            this.StockItemToevoegenButton.UseVisualStyleBackColor = true;
            this.StockItemToevoegenButton.Click += new System.EventHandler(this.StockItemToevoegenButton_Click);
            // 
            // StockOverviewListView
            // 
            this.StockOverviewListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockOverviewListView.Location = new System.Drawing.Point(6, 63);
            this.StockOverviewListView.Name = "StockOverviewListView";
            this.StockOverviewListView.Size = new System.Drawing.Size(1054, 396);
            this.StockOverviewListView.TabIndex = 2;
            this.StockOverviewListView.UseCompatibleStateImageBehavior = false;
            this.StockOverviewListView.View = System.Windows.Forms.View.Details;
            // 
            // StockButton
            // 
            this.StockButton.Location = new System.Drawing.Point(18, 12);
            this.StockButton.Name = "StockButton";
            this.StockButton.Size = new System.Drawing.Size(75, 23);
            this.StockButton.TabIndex = 3;
            this.StockButton.Text = "Stock";
            this.StockButton.UseVisualStyleBackColor = true;
            this.StockButton.Click += new System.EventHandler(this.StockButton_Click);
            // 
            // PedalenButton
            // 
            this.PedalenButton.Location = new System.Drawing.Point(99, 12);
            this.PedalenButton.Name = "PedalenButton";
            this.PedalenButton.Size = new System.Drawing.Size(75, 23);
            this.PedalenButton.TabIndex = 4;
            this.PedalenButton.Text = "Pedalen";
            this.PedalenButton.UseVisualStyleBackColor = true;
            this.PedalenButton.Click += new System.EventHandler(this.PedalenButton_Click);
            // 
            // UitgaandeBestellingenButton
            // 
            this.UitgaandeBestellingenButton.Location = new System.Drawing.Point(181, 13);
            this.UitgaandeBestellingenButton.Name = "UitgaandeBestellingenButton";
            this.UitgaandeBestellingenButton.Size = new System.Drawing.Size(75, 23);
            this.UitgaandeBestellingenButton.TabIndex = 5;
            this.UitgaandeBestellingenButton.Text = "Bestellingen";
            this.UitgaandeBestellingenButton.UseVisualStyleBackColor = true;
            this.UitgaandeBestellingenButton.Click += new System.EventHandler(this.UitgaandeBestellingenButton_Click);
            // 
            // KlantenBestellingenButton
            // 
            this.KlantenBestellingenButton.Location = new System.Drawing.Point(262, 13);
            this.KlantenBestellingenButton.Name = "KlantenBestellingenButton";
            this.KlantenBestellingenButton.Size = new System.Drawing.Size(75, 23);
            this.KlantenBestellingenButton.TabIndex = 6;
            this.KlantenBestellingenButton.Text = "Klant";
            this.KlantenBestellingenButton.UseVisualStyleBackColor = true;
            // 
            // OnkostenButton
            // 
            this.OnkostenButton.Location = new System.Drawing.Point(344, 13);
            this.OnkostenButton.Name = "OnkostenButton";
            this.OnkostenButton.Size = new System.Drawing.Size(75, 23);
            this.OnkostenButton.TabIndex = 7;
            this.OnkostenButton.Text = "Onkosten";
            this.OnkostenButton.UseVisualStyleBackColor = true;
            // 
            // LogboekButton
            // 
            this.LogboekButton.Location = new System.Drawing.Point(426, 13);
            this.LogboekButton.Name = "LogboekButton";
            this.LogboekButton.Size = new System.Drawing.Size(75, 23);
            this.LogboekButton.TabIndex = 8;
            this.LogboekButton.Text = "Logboek";
            this.LogboekButton.UseVisualStyleBackColor = true;
            // 
            // HerstellingenButton
            // 
            this.HerstellingenButton.Location = new System.Drawing.Point(508, 13);
            this.HerstellingenButton.Name = "HerstellingenButton";
            this.HerstellingenButton.Size = new System.Drawing.Size(86, 23);
            this.HerstellingenButton.TabIndex = 9;
            this.HerstellingenButton.Text = "Herstellingen";
            this.HerstellingenButton.UseVisualStyleBackColor = true;
            // 
            // PedalenGroupBox
            // 
            this.PedalenGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PedalenGroupBox.Location = new System.Drawing.Point(12, 41);
            this.PedalenGroupBox.Name = "PedalenGroupBox";
            this.PedalenGroupBox.Size = new System.Drawing.Size(1066, 465);
            this.PedalenGroupBox.TabIndex = 10;
            this.PedalenGroupBox.TabStop = false;
            this.PedalenGroupBox.Text = "Pedalen";
            this.PedalenGroupBox.Visible = false;
            // 
            // BestellingenGroupBox
            // 
            this.BestellingenGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BestellingenGroupBox.Location = new System.Drawing.Point(12, 41);
            this.BestellingenGroupBox.Name = "BestellingenGroupBox";
            this.BestellingenGroupBox.Size = new System.Drawing.Size(1066, 465);
            this.BestellingenGroupBox.TabIndex = 11;
            this.BestellingenGroupBox.TabStop = false;
            this.BestellingenGroupBox.Text = "Bestellingen";
            this.BestellingenGroupBox.Visible = false;
            // 
            // SamStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 518);
            this.Controls.Add(this.HerstellingenButton);
            this.Controls.Add(this.LogboekButton);
            this.Controls.Add(this.OnkostenButton);
            this.Controls.Add(this.KlantenBestellingenButton);
            this.Controls.Add(this.UitgaandeBestellingenButton);
            this.Controls.Add(this.PedalenButton);
            this.Controls.Add(this.StockButton);
            this.Controls.Add(this.StockGroupBox);
            this.Controls.Add(this.PedalenGroupBox);
            this.Controls.Add(this.BestellingenGroupBox);
            this.Name = "SamStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SamStockForm";
            this.StockGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox StockGroupBox;
        private System.Windows.Forms.ListView StockOverviewListView;
        private System.Windows.Forms.Button StockButton;
        private System.Windows.Forms.Button PedalenButton;
        private System.Windows.Forms.Button UitgaandeBestellingenButton;
        private System.Windows.Forms.Button KlantenBestellingenButton;
        private System.Windows.Forms.Button OnkostenButton;
        private System.Windows.Forms.Button LogboekButton;
        private System.Windows.Forms.Button HerstellingenButton;
        private System.Windows.Forms.GroupBox PedalenGroupBox;
        private System.Windows.Forms.GroupBox BestellingenGroupBox;
        private System.Windows.Forms.Button StockItemToevoegenButton;
        private System.Windows.Forms.Button StockVerhogenButton;

    }
}

