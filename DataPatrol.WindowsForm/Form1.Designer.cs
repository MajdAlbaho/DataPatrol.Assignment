namespace DataPatrol.WindowsForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.StartApiCallButton = new System.Windows.Forms.Button();
            this.ApiUrl = new System.Windows.Forms.TextBox();
            this.ApiLabel = new System.Windows.Forms.Label();
            this.ListenerDataGrid = new System.Windows.Forms.DataGridView();
            this.StopApiCallButton = new System.Windows.Forms.Button();
            this.RegisterListenerButton = new System.Windows.Forms.Button();
            this.UnregisterListenerButton = new System.Windows.Forms.Button();
            this.ApiRequestStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListenerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StartApiCallButton
            // 
            this.StartApiCallButton.Location = new System.Drawing.Point(112, 43);
            this.StartApiCallButton.Name = "StartApiCallButton";
            this.StartApiCallButton.Size = new System.Drawing.Size(92, 30);
            this.StartApiCallButton.TabIndex = 0;
            this.StartApiCallButton.Text = "Start";
            this.StartApiCallButton.UseVisualStyleBackColor = true;
            this.StartApiCallButton.Click += new System.EventHandler(this.OnStartApiCallButtonClicked);
            // 
            // ApiUrl
            // 
            this.ApiUrl.Location = new System.Drawing.Point(112, 15);
            this.ApiUrl.Name = "ApiUrl";
            this.ApiUrl.Size = new System.Drawing.Size(473, 22);
            this.ApiUrl.TabIndex = 1;
            // 
            // ApiLabel
            // 
            this.ApiLabel.AutoSize = true;
            this.ApiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApiLabel.Location = new System.Drawing.Point(40, 12);
            this.ApiLabel.Name = "ApiLabel";
            this.ApiLabel.Size = new System.Drawing.Size(66, 25);
            this.ApiLabel.TabIndex = 2;
            this.ApiLabel.Text = "API : ";
            // 
            // ListenerDataGrid
            // 
            this.ListenerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListenerDataGrid.Location = new System.Drawing.Point(112, 79);
            this.ListenerDataGrid.Name = "ListenerDataGrid";
            this.ListenerDataGrid.RowHeadersWidth = 51;
            this.ListenerDataGrid.RowTemplate.Height = 24;
            this.ListenerDataGrid.Size = new System.Drawing.Size(520, 400);
            this.ListenerDataGrid.TabIndex = 3;
            // 
            // StopApiCallButton
            // 
            this.StopApiCallButton.Location = new System.Drawing.Point(210, 43);
            this.StopApiCallButton.Name = "StopApiCallButton";
            this.StopApiCallButton.Size = new System.Drawing.Size(92, 30);
            this.StopApiCallButton.TabIndex = 0;
            this.StopApiCallButton.Text = "Stop";
            this.StopApiCallButton.UseVisualStyleBackColor = true;
            this.StopApiCallButton.Click += new System.EventHandler(this.OnStopApiButtonClicked);
            // 
            // RegisterListenerButton
            // 
            this.RegisterListenerButton.Location = new System.Drawing.Point(638, 79);
            this.RegisterListenerButton.Name = "RegisterListenerButton";
            this.RegisterListenerButton.Size = new System.Drawing.Size(92, 30);
            this.RegisterListenerButton.TabIndex = 0;
            this.RegisterListenerButton.Text = "Register";
            this.RegisterListenerButton.UseVisualStyleBackColor = true;
            this.RegisterListenerButton.Click += new System.EventHandler(this.OnRegisterListenerButtonClicked);
            // 
            // UnregisterListenerButton
            // 
            this.UnregisterListenerButton.Location = new System.Drawing.Point(638, 115);
            this.UnregisterListenerButton.Name = "UnregisterListenerButton";
            this.UnregisterListenerButton.Size = new System.Drawing.Size(92, 30);
            this.UnregisterListenerButton.TabIndex = 0;
            this.UnregisterListenerButton.Text = "Unregister";
            this.UnregisterListenerButton.UseVisualStyleBackColor = true;
            this.UnregisterListenerButton.Click += new System.EventHandler(this.OnUnRegisterListenerButtonClicked);
            // 
            // ApiRequestStatusLabel
            // 
            this.ApiRequestStatusLabel.AutoSize = true;
            this.ApiRequestStatusLabel.Location = new System.Drawing.Point(324, 50);
            this.ApiRequestStatusLabel.Name = "ApiRequestStatusLabel";
            this.ApiRequestStatusLabel.Size = new System.Drawing.Size(0, 16);
            this.ApiRequestStatusLabel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 491);
            this.Controls.Add(this.ApiRequestStatusLabel);
            this.Controls.Add(this.ListenerDataGrid);
            this.Controls.Add(this.ApiLabel);
            this.Controls.Add(this.ApiUrl);
            this.Controls.Add(this.StopApiCallButton);
            this.Controls.Add(this.UnregisterListenerButton);
            this.Controls.Add(this.RegisterListenerButton);
            this.Controls.Add(this.StartApiCallButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListenerDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartApiCallButton;
        private System.Windows.Forms.TextBox ApiUrl;
        private System.Windows.Forms.Label ApiLabel;
        private System.Windows.Forms.DataGridView ListenerDataGrid;
        private System.Windows.Forms.Button StopApiCallButton;
        private System.Windows.Forms.Button RegisterListenerButton;
        private System.Windows.Forms.Button UnregisterListenerButton;
        private System.Windows.Forms.Label ApiRequestStatusLabel;
    }
}

