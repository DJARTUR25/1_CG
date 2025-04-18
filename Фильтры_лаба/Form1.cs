using System.ComponentModel;

namespace Фильтры_лаба
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Stack<Bitmap> history;
        public Form1()
        {
            InitializeComponent();
            history = new Stack<Bitmap>();
        }

        private void SaveHistory()
        {
            if (history != null)
            {
                Bitmap SavedImage = new Bitmap(image);
                history.Push(SavedImage);
            }
        }

        private void Undo()
        {
            if (history.Count > 0)
            {
                image = history.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }

                fs.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp; | All files (*.*) | (*.*)";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }

            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new Brightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new Embossing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void medianFilterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new MedianFilter(3);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void tranferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void turn2RadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHistory();
            Filters filter = new TurnFilter(Math.PI / 6, Color.Black);
            backgroundWorker1.RunWorkerAsync(filter);
        }

    }
}
