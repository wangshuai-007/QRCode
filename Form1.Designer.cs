namespace QRCodeDemo
{
    partial class FormEnCodeQrCode
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
            this.picEncodedBarCode = new System.Windows.Forms.PictureBox();
            this.labEncoderContent = new System.Windows.Forms.Label();
            this.btnSelectBarcodeImageFileForDecoding = new System.Windows.Forms.Button();
            this.txtIconFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonIconSquare = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonIconRound = new System.Windows.Forms.RadioButton();
            this.colorDialogBack = new System.Windows.Forms.ColorDialog();
            this.btnBackGroundColor = new System.Windows.Forms.Button();
            this.btnQRCodeColor = new System.Windows.Forms.Button();
            this.labelBackColor = new System.Windows.Forms.Label();
            this.labelQrCodeColor = new System.Windows.Forms.Label();
            this.btnEncode = new System.Windows.Forms.Button();
            this.colorDialogQrCode = new System.Windows.Forms.ColorDialog();
            this.txtEncoderContent = new System.Windows.Forms.TextBox();
            this.btnSaveQrCode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkMergeBackImage = new System.Windows.Forms.CheckBox();
            this.txtBackImage = new System.Windows.Forms.TextBox();
            this.btnBackImage = new System.Windows.Forms.Button();
            this.labelBackImage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picEncodedBarCode
            // 
            this.picEncodedBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picEncodedBarCode.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.picEncodedBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEncodedBarCode.Location = new System.Drawing.Point(12, 12);
            this.picEncodedBarCode.Name = "picEncodedBarCode";
            this.picEncodedBarCode.Size = new System.Drawing.Size(399, 328);
            this.picEncodedBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEncodedBarCode.TabIndex = 10;
            this.picEncodedBarCode.TabStop = false;
            // 
            // labEncoderContent
            // 
            this.labEncoderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labEncoderContent.AutoSize = true;
            this.labEncoderContent.Location = new System.Drawing.Point(417, 167);
            this.labEncoderContent.Name = "labEncoderContent";
            this.labEncoderContent.Size = new System.Drawing.Size(29, 12);
            this.labEncoderContent.TabIndex = 13;
            this.labEncoderContent.Text = "内容";
            // 
            // btnSelectBarcodeImageFileForDecoding
            // 
            this.btnSelectBarcodeImageFileForDecoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectBarcodeImageFileForDecoding.Location = new System.Drawing.Point(307, 19);
            this.btnSelectBarcodeImageFileForDecoding.Name = "btnSelectBarcodeImageFileForDecoding";
            this.btnSelectBarcodeImageFileForDecoding.Size = new System.Drawing.Size(26, 23);
            this.btnSelectBarcodeImageFileForDecoding.TabIndex = 15;
            this.btnSelectBarcodeImageFileForDecoding.Text = "...";
            this.btnSelectBarcodeImageFileForDecoding.UseVisualStyleBackColor = true;
            this.btnSelectBarcodeImageFileForDecoding.Click += new System.EventHandler(this.btnSelectBarcodeImageFileForDecoding_Click);
            // 
            // txtIconFile
            // 
            this.txtIconFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIconFile.Location = new System.Drawing.Point(3, 21);
            this.txtIconFile.Name = "txtIconFile";
            this.txtIconFile.Size = new System.Drawing.Size(298, 21);
            this.txtIconFile.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Icon";
            // 
            // radioButtonIconSquare
            // 
            this.radioButtonIconSquare.AutoSize = true;
            this.radioButtonIconSquare.Checked = true;
            this.radioButtonIconSquare.Location = new System.Drawing.Point(3, 60);
            this.radioButtonIconSquare.Name = "radioButtonIconSquare";
            this.radioButtonIconSquare.Size = new System.Drawing.Size(47, 16);
            this.radioButtonIconSquare.TabIndex = 17;
            this.radioButtonIconSquare.TabStop = true;
            this.radioButtonIconSquare.Text = "方形";
            this.radioButtonIconSquare.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Icon形状";
            // 
            // radioButtonIconRound
            // 
            this.radioButtonIconRound.AutoSize = true;
            this.radioButtonIconRound.Location = new System.Drawing.Point(56, 60);
            this.radioButtonIconRound.Name = "radioButtonIconRound";
            this.radioButtonIconRound.Size = new System.Drawing.Size(47, 16);
            this.radioButtonIconRound.TabIndex = 19;
            this.radioButtonIconRound.Text = "圆形";
            this.radioButtonIconRound.UseVisualStyleBackColor = true;
            // 
            // colorDialogBack
            // 
            this.colorDialogBack.Color = System.Drawing.Color.White;
            // 
            // btnBackGroundColor
            // 
            this.btnBackGroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackGroundColor.BackColor = System.Drawing.Color.White;
            this.btnBackGroundColor.Location = new System.Drawing.Point(143, 60);
            this.btnBackGroundColor.Name = "btnBackGroundColor";
            this.btnBackGroundColor.Size = new System.Drawing.Size(61, 23);
            this.btnBackGroundColor.TabIndex = 20;
            this.btnBackGroundColor.Text = "背景颜色";
            this.btnBackGroundColor.UseVisualStyleBackColor = false;
            this.btnBackGroundColor.Click += new System.EventHandler(this.btnBackGroundColor_Click);
            // 
            // btnQRCodeColor
            // 
            this.btnQRCodeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQRCodeColor.BackColor = System.Drawing.Color.Black;
            this.btnQRCodeColor.Location = new System.Drawing.Point(210, 60);
            this.btnQRCodeColor.Name = "btnQRCodeColor";
            this.btnQRCodeColor.Size = new System.Drawing.Size(77, 23);
            this.btnQRCodeColor.TabIndex = 21;
            this.btnQRCodeColor.Text = "二维码颜色";
            this.btnQRCodeColor.UseVisualStyleBackColor = false;
            this.btnQRCodeColor.Click += new System.EventHandler(this.btnQRCodeColor_Click);
            // 
            // labelBackColor
            // 
            this.labelBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBackColor.AutoSize = true;
            this.labelBackColor.Location = new System.Drawing.Point(141, 45);
            this.labelBackColor.Name = "labelBackColor";
            this.labelBackColor.Size = new System.Drawing.Size(53, 12);
            this.labelBackColor.TabIndex = 22;
            this.labelBackColor.Text = "背景颜色";
            // 
            // labelQrCodeColor
            // 
            this.labelQrCodeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQrCodeColor.AutoSize = true;
            this.labelQrCodeColor.Location = new System.Drawing.Point(208, 45);
            this.labelQrCodeColor.Name = "labelQrCodeColor";
            this.labelQrCodeColor.Size = new System.Drawing.Size(65, 12);
            this.labelQrCodeColor.TabIndex = 23;
            this.labelQrCodeColor.Text = "二维码颜色";
            // 
            // btnEncode
            // 
            this.btnEncode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncode.Location = new System.Drawing.Point(422, 349);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(85, 23);
            this.btnEncode.TabIndex = 24;
            this.btnEncode.Text = "生成";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEncoderContent
            // 
            this.txtEncoderContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncoderContent.Location = new System.Drawing.Point(417, 182);
            this.txtEncoderContent.Multiline = true;
            this.txtEncoderContent.Name = "txtEncoderContent";
            this.txtEncoderContent.Size = new System.Drawing.Size(336, 158);
            this.txtEncoderContent.TabIndex = 25;
            // 
            // btnSaveQrCode
            // 
            this.btnSaveQrCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveQrCode.Location = new System.Drawing.Point(526, 349);
            this.btnSaveQrCode.Name = "btnSaveQrCode";
            this.btnSaveQrCode.Size = new System.Drawing.Size(85, 23);
            this.btnSaveQrCode.TabIndex = 26;
            this.btnSaveQrCode.Text = "保存";
            this.btnSaveQrCode.UseVisualStyleBackColor = true;
            this.btnSaveQrCode.Click += new System.EventHandler(this.btnSaveQrCode_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkMergeBackImage);
            this.panel1.Controls.Add(this.txtBackImage);
            this.panel1.Controls.Add(this.btnBackImage);
            this.panel1.Controls.Add(this.labelBackImage);
            this.panel1.Controls.Add(this.txtIconFile);
            this.panel1.Controls.Add(this.btnSelectBarcodeImageFileForDecoding);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButtonIconSquare);
            this.panel1.Controls.Add(this.labelQrCodeColor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelBackColor);
            this.panel1.Controls.Add(this.radioButtonIconRound);
            this.panel1.Controls.Add(this.btnQRCodeColor);
            this.panel1.Controls.Add(this.btnBackGroundColor);
            this.panel1.Location = new System.Drawing.Point(417, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 152);
            this.panel1.TabIndex = 27;
            // 
            // chkMergeBackImage
            // 
            this.chkMergeBackImage.AutoSize = true;
            this.chkMergeBackImage.Location = new System.Drawing.Point(3, 121);
            this.chkMergeBackImage.Name = "chkMergeBackImage";
            this.chkMergeBackImage.Size = new System.Drawing.Size(72, 16);
            this.chkMergeBackImage.TabIndex = 27;
            this.chkMergeBackImage.Text = "透明背景";
            this.chkMergeBackImage.UseVisualStyleBackColor = true;
            this.chkMergeBackImage.CheckedChanged += new System.EventHandler(this.chkMergeBackImage_CheckedChanged);
            // 
            // txtBackImage
            // 
            this.txtBackImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackImage.Location = new System.Drawing.Point(2, 94);
            this.txtBackImage.Name = "txtBackImage";
            this.txtBackImage.Size = new System.Drawing.Size(298, 21);
            this.txtBackImage.TabIndex = 24;
            // 
            // btnBackImage
            // 
            this.btnBackImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackImage.Location = new System.Drawing.Point(306, 92);
            this.btnBackImage.Name = "btnBackImage";
            this.btnBackImage.Size = new System.Drawing.Size(26, 23);
            this.btnBackImage.TabIndex = 25;
            this.btnBackImage.Text = "...";
            this.btnBackImage.UseVisualStyleBackColor = true;
            this.btnBackImage.Click += new System.EventHandler(this.btnBackImage_Click);
            // 
            // labelBackImage
            // 
            this.labelBackImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBackImage.AutoSize = true;
            this.labelBackImage.Location = new System.Drawing.Point(0, 79);
            this.labelBackImage.Name = "labelBackImage";
            this.labelBackImage.Size = new System.Drawing.Size(53, 12);
            this.labelBackImage.TabIndex = 26;
            this.labelBackImage.Text = "背景图片";
            // 
            // FormEnCodeQrCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 398);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveQrCode);
            this.Controls.Add(this.txtEncoderContent);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.labEncoderContent);
            this.Controls.Add(this.picEncodedBarCode);
            this.Name = "FormEnCodeQrCode";
            this.Text = "生成二维码";
            ((System.ComponentModel.ISupportInitialize)(this.picEncodedBarCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picEncodedBarCode;
        private System.Windows.Forms.Label labEncoderContent;
        private System.Windows.Forms.Button btnSelectBarcodeImageFileForDecoding;
        private System.Windows.Forms.TextBox txtIconFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonIconSquare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonIconRound;
        private System.Windows.Forms.ColorDialog colorDialogBack;
        private System.Windows.Forms.Button btnBackGroundColor;
        private System.Windows.Forms.Button btnQRCodeColor;
        private System.Windows.Forms.Label labelBackColor;
        private System.Windows.Forms.Label labelQrCodeColor;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.ColorDialog colorDialogQrCode;
        private System.Windows.Forms.TextBox txtEncoderContent;
        private System.Windows.Forms.Button btnSaveQrCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBackImage;
        private System.Windows.Forms.Button btnBackImage;
        private System.Windows.Forms.Label labelBackImage;
        private System.Windows.Forms.CheckBox chkMergeBackImage;
    }
}

