namespace AzureImageModelDeployExample
{
    partial class Form1
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
            this.gbImgUpload = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtPredictEndpoint = new System.Windows.Forms.TextBox();
            this.btnGetResults = new System.Windows.Forms.Button();
            this.btnSendPredict = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbImgUpload.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbImgUpload
            // 
            this.gbImgUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImgUpload.Controls.Add(this.textBox2);
            this.gbImgUpload.Controls.Add(this.txtPredictEndpoint);
            this.gbImgUpload.Controls.Add(this.btnGetResults);
            this.gbImgUpload.Controls.Add(this.btnSendPredict);
            this.gbImgUpload.Controls.Add(this.btnLoadImage);
            this.gbImgUpload.Controls.Add(this.label2);
            this.gbImgUpload.Controls.Add(this.label1);
            this.gbImgUpload.Location = new System.Drawing.Point(12, 12);
            this.gbImgUpload.Name = "gbImgUpload";
            this.gbImgUpload.Size = new System.Drawing.Size(1047, 135);
            this.gbImgUpload.TabIndex = 0;
            this.gbImgUpload.TabStop = false;
            this.gbImgUpload.Text = "Select image to upload";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(99, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(942, 20);
            this.textBox2.TabIndex = 2;
            // 
            // txtPredictEndpoint
            // 
            this.txtPredictEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPredictEndpoint.Location = new System.Drawing.Point(99, 73);
            this.txtPredictEndpoint.Name = "txtPredictEndpoint";
            this.txtPredictEndpoint.Size = new System.Drawing.Size(942, 20);
            this.txtPredictEndpoint.TabIndex = 2;
            this.txtPredictEndpoint.Text = "https://blobstorefuncteste.azurewebsites.net/api/predict_v0?code=XHeGapCuyxD7N3ft" +
    "oOOPUTCZY0XHMC0XtdfbzjG0/GcWLFoRCYlk9w==";
            // 
            // btnGetResults
            // 
            this.btnGetResults.Enabled = false;
            this.btnGetResults.Location = new System.Drawing.Point(273, 19);
            this.btnGetResults.Name = "btnGetResults";
            this.btnGetResults.Size = new System.Drawing.Size(126, 43);
            this.btnGetResults.TabIndex = 1;
            this.btnGetResults.Text = "Retrieve results";
            this.btnGetResults.UseVisualStyleBackColor = true;
            // 
            // btnSendPredict
            // 
            this.btnSendPredict.Enabled = false;
            this.btnSendPredict.Location = new System.Drawing.Point(141, 19);
            this.btnSendPredict.Name = "btnSendPredict";
            this.btnSendPredict.Size = new System.Drawing.Size(126, 43);
            this.btnSendPredict.TabIndex = 1;
            this.btnSendPredict.Text = "Send for prediction";
            this.btnSendPredict.UseVisualStyleBackColor = true;
            this.btnSendPredict.Click += new System.EventHandler(this.btnSendPredict_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(9, 19);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(126, 43);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load Image...";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Results endpoint:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Predict endpoint:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.picImg);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1047, 538);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // picImg
            // 
            this.picImg.Location = new System.Drawing.Point(9, 19);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(512, 512);
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(527, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 703);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbImgUpload);
            this.Name = "Form1";
            this.Text = "Azure Image Model Deploy Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbImgUpload.ResumeLayout(false);
            this.gbImgUpload.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImgUpload;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtPredictEndpoint;
        private System.Windows.Forms.Button btnGetResults;
        private System.Windows.Forms.Button btnSendPredict;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

