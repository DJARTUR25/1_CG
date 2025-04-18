namespace Фильтры_лаба
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            точечныеToolStripMenuItem = new ToolStripMenuItem();
            инверсияToolStripMenuItem = new ToolStripMenuItem();
            чернобелоеToolStripMenuItem = new ToolStripMenuItem();
            сепияToolStripMenuItem = new ToolStripMenuItem();
            яркостьToolStripMenuItem = new ToolStripMenuItem();
            tranferToolStripMenuItem = new ToolStripMenuItem();
            turn2RadToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            размытиеToolStripMenuItem = new ToolStripMenuItem();
            размытиеГауссаToolStripMenuItem = new ToolStripMenuItem();
            фильтрСобеляToolStripMenuItem = new ToolStripMenuItem();
            sharpnessToolStripMenuItem = new ToolStripMenuItem();
            embossingToolStripMenuItem = new ToolStripMenuItem();
            medianFilterToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1282, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem, saveImageToolStripMenuItem, undoToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1282, 24);
            menuStrip2.TabIndex = 1;
            menuStrip2.Text = "menuStrip2";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(37, 20);
            файлToolStripMenuItem.Text = "File";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(122, 22);
            открытьToolStripMenuItem.Text = "Open file";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem });
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(50, 20);
            фильтрыToolStripMenuItem.Text = "Filters";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, чернобелоеToolStripMenuItem, сепияToolStripMenuItem, яркостьToolStripMenuItem, tranferToolStripMenuItem, turn2RadToolStripMenuItem });
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(138, 22);
            точечныеToolStripMenuItem.Text = "Point-based";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(174, 22);
            инверсияToolStripMenuItem.Text = "Invertion";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // чернобелоеToolStripMenuItem
            // 
            чернобелоеToolStripMenuItem.Name = "чернобелоеToolStripMenuItem";
            чернобелоеToolStripMenuItem.Size = new Size(174, 22);
            чернобелоеToolStripMenuItem.Text = "Black and White";
            чернобелоеToolStripMenuItem.Click += чернобелоеToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(174, 22);
            сепияToolStripMenuItem.Text = "Sepia";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // яркостьToolStripMenuItem
            // 
            яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            яркостьToolStripMenuItem.Size = new Size(174, 22);
            яркостьToolStripMenuItem.Text = "+ brightness";
            яркостьToolStripMenuItem.Click += яркостьToolStripMenuItem_Click;
            // 
            // tranferToolStripMenuItem
            // 
            tranferToolStripMenuItem.Name = "tranferToolStripMenuItem";
            tranferToolStripMenuItem.Size = new Size(174, 22);
            tranferToolStripMenuItem.Text = "Tranfer";
            tranferToolStripMenuItem.Click += tranferToolStripMenuItem_Click;
            // 
            // turn2RadToolStripMenuItem
            // 
            turn2RadToolStripMenuItem.Name = "turn2RadToolStripMenuItem";
            turn2RadToolStripMenuItem.Size = new Size(174, 22);
            turn2RadToolStripMenuItem.Text = "Turn on 30 degrees";
            turn2RadToolStripMenuItem.Click += turn2RadToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, размытиеГауссаToolStripMenuItem, фильтрСобеляToolStripMenuItem, sharpnessToolStripMenuItem, embossingToolStripMenuItem, medianFilterToolStripMenuItem });
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(138, 22);
            матричныеToolStripMenuItem.Text = "Matrix";
            // 
            // размытиеToolStripMenuItem
            // 
            размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            размытиеToolStripMenuItem.Size = new Size(143, 22);
            размытиеToolStripMenuItem.Text = "Blur";
            размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
            // 
            // размытиеГауссаToolStripMenuItem
            // 
            размытиеГауссаToolStripMenuItem.Name = "размытиеГауссаToolStripMenuItem";
            размытиеГауссаToolStripMenuItem.Size = new Size(143, 22);
            размытиеГауссаToolStripMenuItem.Text = "Gauss Blur";
            размытиеГауссаToolStripMenuItem.Click += размытиеГауссаToolStripMenuItem_Click;
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            фильтрСобеляToolStripMenuItem.Size = new Size(143, 22);
            фильтрСобеляToolStripMenuItem.Text = "Sobel filter";
            фильтрСобеляToolStripMenuItem.Click += фильтрСобеляToolStripMenuItem_Click;
            // 
            // sharpnessToolStripMenuItem
            // 
            sharpnessToolStripMenuItem.Name = "sharpnessToolStripMenuItem";
            sharpnessToolStripMenuItem.Size = new Size(143, 22);
            sharpnessToolStripMenuItem.Text = "Sharpness";
            sharpnessToolStripMenuItem.Click += sharpnessToolStripMenuItem_Click;
            // 
            // embossingToolStripMenuItem
            // 
            embossingToolStripMenuItem.Name = "embossingToolStripMenuItem";
            embossingToolStripMenuItem.Size = new Size(143, 22);
            embossingToolStripMenuItem.Text = "Embossing";
            embossingToolStripMenuItem.Click += embossingToolStripMenuItem_Click;
            // 
            // medianFilterToolStripMenuItem
            // 
            medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            medianFilterToolStripMenuItem.Size = new Size(143, 22);
            medianFilterToolStripMenuItem.Text = "Median Filter";
            medianFilterToolStripMenuItem.Click += medianFilterToolStripMenuItem_Click_1;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(79, 20);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(74, 20);
            undoToolStripMenuItem.Text = "Undo <---";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(175, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(574, 475);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged_1;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(0, 561);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1287, 32);
            progressBar1.TabIndex = 3;
            progressBar1.Click += progressBar1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1166, 561);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 585);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private Button button1;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private ToolStripMenuItem размытиеГауссаToolStripMenuItem;
        private ToolStripMenuItem чернобелоеToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem яркостьToolStripMenuItem;
        private ToolStripMenuItem фильтрСобеляToolStripMenuItem;
        private ToolStripMenuItem sharpnessToolStripMenuItem;
        private ToolStripMenuItem embossingToolStripMenuItem;
        private ToolStripMenuItem medianFilterToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem tranferToolStripMenuItem;
        private ToolStripMenuItem turn2RadToolStripMenuItem;
    }
}
