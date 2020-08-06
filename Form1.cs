using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace QRCodeDemo
{
    public partial class FormEnCodeQrCode : Form
    {
        private IconShape _iconShape = IconShape.Square;
        private bool _isMergeBackImage;

        public FormEnCodeQrCode()
        {
            InitializeComponent();
            this.Load += FormEnCodeQrCode_Load;
        }

        private void FormEnCodeQrCode_Load(object sender, EventArgs e)
        {
            radioButtonIconRound.CheckedChanged += RadioButtonIconSquare_CheckedChanged;
            radioButtonIconSquare.CheckedChanged += RadioButtonIconSquare_CheckedChanged; ;
        }

        private void RadioButtonIconSquare_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIconRound.Checked)
                iconShape = IconShape.Round;
            else
                iconShape = IconShape.Square;
        }

        private void RadioButtonIconRound_CheckedChanged(object sender, EventArgs e)
        {
            if (picEncodedBarCode.Image != null)
            {
                btnEncode.PerformClick();
            }
        }

        private void btnSelectBarcodeImageFileForDecoding_Click(object sender, EventArgs e)
        {
            using (var openDlg = new OpenFileDialog())
            {
                openDlg.FileName = txtIconFile.Text;
                openDlg.Multiselect = false;
                openDlg.Filter = "PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif|JPG Files (*.jpg)|*.jpg|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtIconFile.Text = openDlg.FileName;
                }
            }
        }

        private void btnBackGroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialogBack.ShowDialog(this) == DialogResult.OK)
            {
                btnBackGroundColor.BackColor = colorDialogBack.Color;
                RadioButtonIconRound_CheckedChanged(null, null);
            }
        }

        private void btnQRCodeColor_Click(object sender, EventArgs e)
        {
            if (colorDialogQrCode.ShowDialog(this) == DialogResult.OK)
            {
                btnQRCodeColor.BackColor = colorDialogQrCode.Color;
                RadioButtonIconRound_CheckedChanged(null, null);
            }
        }

        private IconShape iconShape
        {
            get => _iconShape;
            set
            {
                if (value != _iconShape)
                {
                    _iconShape = value;
                    RadioButtonIconRound_CheckedChanged(null, null);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEncoderContent.Text))
            {
                MessageBox.Show("请输入内容！");
                return;
            }



            try
            {
                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions()
                    {
                        Height = picEncodedBarCode.Height,
                        Width = picEncodedBarCode.Width,CharacterSet = "utf-8"
                    },
                    
                    //Renderer = (IBarcodeRenderer<Bitmap>)Activator.CreateInstance(typeof(CustomBitmapRenderer))
                    Renderer = new CustomBitmapRenderer()
                    {
                        BackgroundGradientColor = btnBackGroundColor.BackColor,
                        ForegroundGradientColor = btnQRCodeColor.BackColor, IconShape = iconShape,
                        IconFullName = txtIconFile.Text,
                        BackImageFullName = txtBackImage.Text,
                    }
                };

                if (IsMergeBackImage)
                    writer.Renderer = new CustomBitmapRenderer()
                    {
                        BackImageFullName = txtBackImage.Text, IsMergeBackColor = IsMergeBackImage,
                        BackgroundGradientColor = Color.White, ForegroundGradientColor = Color.Black
                    };
                //writer.Options.
                picEncodedBarCode.Image = writer.Write(txtEncoderContent.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnSaveQrCode_Click(object sender, EventArgs e)
        {
            if (picEncodedBarCode.Image != null)
            {
                var fileName = String.Empty;
                using (var dlg = new SaveFileDialog())
                {
                    dlg.DefaultExt = "png";
                    dlg.Filter = "PNG Files (*.png)|*.png|SVG Files (*.svg)|*.svg|BMP Files (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif|JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                    if (dlg.ShowDialog(this) != DialogResult.OK)
                        return;
                    fileName = dlg.FileName;
                }
                var extension = Path.GetExtension(fileName).ToLower();
                var bmp = (Bitmap)picEncodedBarCode.Image;
                switch (extension)
                {
                    case ".bmp":
                        bmp.Save(fileName, ImageFormat.Bmp);
                        break;
                    case ".jpeg":
                    case ".jpg":
                        bmp.Save(fileName, ImageFormat.Jpeg);
                        break;
                    case ".tiff":
                    case ".tif":
                        bmp.Save(fileName, ImageFormat.Tiff);
                        break;
                    case ".svg":
                        {
                            var writer = new BarcodeWriterSvg
                            {
                                Format = BarcodeFormat.QR_CODE,
                                Options =  new EncodingOptions
                                {
                                    Height = picEncodedBarCode.Height,
                                    Width = picEncodedBarCode.Width
                                }
                            };
                            var svgImage = writer.Write(txtEncoderContent.Text);
                            File.WriteAllText(fileName, svgImage.Content, System.Text.Encoding.UTF8);
                        }
                        break;
                    default:
                        bmp.Save(fileName, ImageFormat.Png);
                        break;
                }
            }
        }

        private void btnBackImage_Click(object sender, EventArgs e)
        {
            using (var openDlg = new OpenFileDialog())
            {
                openDlg.FileName = txtBackImage.Text;
                openDlg.Multiselect = false;
                openDlg.Filter = "PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|TIFF Files (*.tif)|*.tif|JPG Files (*.jpg)|*.jpg|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                if (openDlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtBackImage.Text = openDlg.FileName;
                }
            }
        }

        public bool IsMergeBackImage
        {
            get => _isMergeBackImage;
            set
            {
                if (value != _isMergeBackImage)
                {
                    _isMergeBackImage = value;
                    SetControl(value);
                }
            }
        }

        private void chkMergeBackImage_CheckedChanged(object sender, EventArgs e)
        {
            IsMergeBackImage = chkMergeBackImage.Checked;
        }

        private void SetControl(bool state)
        {
            txtIconFile.Enabled = !state;
            radioButtonIconRound.Enabled = !state;
            radioButtonIconSquare.Enabled = !state;
            btnBackGroundColor.Enabled = !state;
            btnQRCodeColor.Enabled = !state;
        }
    }
}
