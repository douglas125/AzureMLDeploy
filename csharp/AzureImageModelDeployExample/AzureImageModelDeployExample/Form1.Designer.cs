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
            this.txtResultsendpoint = new System.Windows.Forms.TextBox();
            this.txtPredictEndpoint = new System.Windows.Forms.TextBox();
            this.btnGetResults = new System.Windows.Forms.Button();
            this.btnSendPredict = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbMask = new System.Windows.Forms.PictureBox();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_taskid = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOverlay = new System.Windows.Forms.CheckBox();
            this.chkLayers = new System.Windows.Forms.CheckedListBox();
            this.gbImgUpload.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImgUpload
            // 
            this.gbImgUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImgUpload.Controls.Add(this.lbl_taskid);
            this.gbImgUpload.Controls.Add(this.label3);
            this.gbImgUpload.Controls.Add(this.txtResultsendpoint);
            this.gbImgUpload.Controls.Add(this.txtPredictEndpoint);
            this.gbImgUpload.Controls.Add(this.btnGetResults);
            this.gbImgUpload.Controls.Add(this.btnSendPredict);
            this.gbImgUpload.Controls.Add(this.btnLoadImage);
            this.gbImgUpload.Controls.Add(this.label2);
            this.gbImgUpload.Controls.Add(this.label1);
            this.gbImgUpload.Location = new System.Drawing.Point(12, 12);
            this.gbImgUpload.Name = "gbImgUpload";
            this.gbImgUpload.Size = new System.Drawing.Size(1237, 135);
            this.gbImgUpload.TabIndex = 0;
            this.gbImgUpload.TabStop = false;
            this.gbImgUpload.Text = "Select image to upload";
            // 
            // txtResultsendpoint
            // 
            this.txtResultsendpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultsendpoint.Location = new System.Drawing.Point(99, 96);
            this.txtResultsendpoint.Name = "txtResultsendpoint";
            this.txtResultsendpoint.Size = new System.Drawing.Size(1132, 20);
            this.txtResultsendpoint.TabIndex = 2;
            this.txtResultsendpoint.Text = "https://blobstorefuncteste.azurewebsites.net/api/getresult_v0?code=i29ppJFs7cfv/p" +
    "QgfF4KD40YsWKbLYvgI9JnRwPqvhUG1mCUYixdwQ==";
            // 
            // txtPredictEndpoint
            // 
            this.txtPredictEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPredictEndpoint.Location = new System.Drawing.Point(99, 73);
            this.txtPredictEndpoint.Name = "txtPredictEndpoint";
            this.txtPredictEndpoint.Size = new System.Drawing.Size(1132, 20);
            this.txtPredictEndpoint.TabIndex = 2;
            this.txtPredictEndpoint.Text = "https://blobstorefuncteste.azurewebsites.net/api/predict_v0?code=XHeGapCuyxD7N3ft" +
    "oOOPUTCZY0XHMC0XtdfbzjG0/GcWLFoRCYlk9w==";
            // 
            // btnGetResults
            // 
            this.btnGetResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetResults.Location = new System.Drawing.Point(353, 19);
            this.btnGetResults.Name = "btnGetResults";
            this.btnGetResults.Size = new System.Drawing.Size(192, 43);
            this.btnGetResults.TabIndex = 1;
            this.btnGetResults.Text = "Retrieve results";
            this.btnGetResults.UseVisualStyleBackColor = true;
            this.btnGetResults.Click += new System.EventHandler(this.btnGetResults_Click);
            // 
            // btnSendPredict
            // 
            this.btnSendPredict.Enabled = false;
            this.btnSendPredict.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendPredict.Location = new System.Drawing.Point(163, 19);
            this.btnSendPredict.Name = "btnSendPredict";
            this.btnSendPredict.Size = new System.Drawing.Size(184, 43);
            this.btnSendPredict.TabIndex = 1;
            this.btnSendPredict.Text = "Send for prediction";
            this.btnSendPredict.UseVisualStyleBackColor = true;
            this.btnSendPredict.Click += new System.EventHandler(this.btnSendPredict_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.Location = new System.Drawing.Point(9, 19);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(148, 43);
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
            this.groupBox2.Controls.Add(this.pbMask);
            this.groupBox2.Controls.Add(this.picImg);
            this.groupBox2.Location = new System.Drawing.Point(200, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1049, 538);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // pbMask
            // 
            this.pbMask.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbMask.Location = new System.Drawing.Point(527, 19);
            this.pbMask.Name = "pbMask";
            this.pbMask.Size = new System.Drawing.Size(512, 512);
            this.pbMask.TabIndex = 0;
            this.pbMask.TabStop = false;
            // 
            // picImg
            // 
            this.picImg.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImg.Location = new System.Drawing.Point(9, 19);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(512, 512);
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Task id:";
            // 
            // lbl_taskid
            // 
            this.lbl_taskid.AutoSize = true;
            this.lbl_taskid.Location = new System.Drawing.Point(602, 35);
            this.lbl_taskid.Name = "lbl_taskid";
            this.lbl_taskid.Size = new System.Drawing.Size(242, 13);
            this.lbl_taskid.TabIndex = 3;
            this.lbl_taskid.Text = "59729da0-affb-45ec-b867-c9544f935946.payload";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLayers);
            this.groupBox1.Controls.Add(this.chkOverlay);
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 537);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categories";
            // 
            // chkOverlay
            // 
            this.chkOverlay.AutoSize = true;
            this.chkOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOverlay.Location = new System.Drawing.Point(6, 30);
            this.chkOverlay.Name = "chkOverlay";
            this.chkOverlay.Size = new System.Drawing.Size(130, 24);
            this.chkOverlay.TabIndex = 0;
            this.chkOverlay.Text = "Overlay masks";
            this.chkOverlay.UseVisualStyleBackColor = true;
            this.chkOverlay.CheckedChanged += new System.EventHandler(this.chkOverlay_CheckedChanged);
            // 
            // chkLayers
            // 
            this.chkLayers.CheckOnClick = true;
            this.chkLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLayers.FormattingEnabled = true;
            this.chkLayers.Location = new System.Drawing.Point(9, 71);
            this.chkLayers.Name = "chkLayers";
            this.chkLayers.Size = new System.Drawing.Size(167, 441);
            this.chkLayers.TabIndex = 1;
            this.chkLayers.SelectedIndexChanged += new System.EventHandler(this.chkLayers_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 703);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbImgUpload);
            this.Name = "Form1";
            this.Text = "Azure Image Model Deploy Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbImgUpload.ResumeLayout(false);
            this.gbImgUpload.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImgUpload;
        private System.Windows.Forms.TextBox txtResultsendpoint;
        private System.Windows.Forms.TextBox txtPredictEndpoint;
        private System.Windows.Forms.Button btnGetResults;
        private System.Windows.Forms.Button btnSendPredict;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.PictureBox pbMask;
        private System.Windows.Forms.Label lbl_taskid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOverlay;
        private System.Windows.Forms.CheckedListBox chkLayers;
    }
}

