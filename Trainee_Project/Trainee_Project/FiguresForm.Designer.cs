namespace Trainee_Project
{
    partial class FiguresForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiguresForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Run = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.Triangle = new System.Windows.Forms.Button();
            this.formPictureBox = new System.Windows.Forms.PictureBox();
            this.formTreeView = new System.Windows.Forms.TreeView();
            this.formTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Run);
            this.panel1.Controls.Add(this.Rectangle);
            this.panel1.Controls.Add(this.Circle);
            this.panel1.Controls.Add(this.Triangle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // Run
            // 
            resources.ApplyResources(this.Run, "Run");
            this.Run.Name = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.btRun);
            // 
            // Rectangle
            // 
            resources.ApplyResources(this.Rectangle, "Rectangle");
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.RectClick);
            // 
            // Circle
            // 
            resources.ApplyResources(this.Circle, "Circle");
            this.Circle.Name = "Circle";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.CircleClick);
            // 
            // Triangle
            // 
            resources.ApplyResources(this.Triangle, "Triangle");
            this.Triangle.Name = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            this.Triangle.Click += new System.EventHandler(this.TriangleClick);
            // 
            // formPictureBox
            // 
            resources.ApplyResources(this.formPictureBox, "formPictureBox");
            this.formPictureBox.Name = "formPictureBox";
            this.formPictureBox.TabStop = false;
            this.formPictureBox.Click += new System.EventHandler(this.pbClick);
            this.formPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMainPaint);
            // 
            // formTreeView
            // 
            resources.ApplyResources(this.formTreeView, "formTreeView");
            this.formTreeView.Name = "formTreeView";
            this.formTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAfterSelect);
            this.formTreeView.DoubleClick += new System.EventHandler(this.tvDoubleClick);
            // 
            // FiguresForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formTreeView);
            this.Controls.Add(this.formPictureBox);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FiguresForm";
            this.Load += new System.EventHandler(this.fmLoad);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.PictureBox formPictureBox;
        private System.Windows.Forms.TreeView formTreeView;
        private System.Windows.Forms.Timer formTimer;
        
    }
}

