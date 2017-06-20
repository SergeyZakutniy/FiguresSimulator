using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Trainee_Project
{
    public partial class FiguresForm : Form
    {
        List<Figure> figuresList = new List<Figure>();
        int countRectangles = 0;
        int countCircles = 0;
        int countTriangles = 0;
        string localization = Properties.Settings.Default.language;
        BinaryFormatter binSerializer = new BinaryFormatter();
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Figure>));
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Figure>));
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        Stream openStream = null;
        OpenFileDialog fileDialogOpen = new OpenFileDialog();

        public FiguresForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(localization);
            InitializeComponent();
        }

        public void pbClick(object sender, EventArgs e) {}

        private void btRun(object sender, EventArgs e)
        {
            if (formTimer.Enabled) {formTimer.Enabled = false;}
            else {formTimer.Enabled = true;}
        }

        private void RectClick(object sender, EventArgs e)
        {
            RectangleFigure rectangleFigure = new RectangleFigure(formPictureBox.Size);
            rectangleFigure.randomColor = ColorTranslator.FromHtml(rectangleFigure.htmlColor);
            if (Properties.Settings.Default.language.Equals(Constants.localParamRus))
            {rectangleFigure.name = Constants.rectangleNameRus;}
            else {rectangleFigure.name = Constants.rectangleNameEn;}
            figuresList.Add(rectangleFigure);
            formTreeView.Nodes.Add(new TreeNode(rectangleFigure.name + countRectangles));
            countRectangles++;
        }

        private void CircleClick(object sender, EventArgs e)
        {
            CircleFigure circleFigure = new CircleFigure(formPictureBox.Size);
            circleFigure.randomColor = ColorTranslator.FromHtml(circleFigure.htmlColor);
            if (Properties.Settings.Default.language.Equals(Constants.localParamRus))
            {circleFigure.name = Constants.circleNameRus;}
            else {circleFigure.name = Constants.circleNameEn;}
            figuresList.Add(circleFigure);
            formTreeView.Nodes.Add(new TreeNode(circleFigure.name + countCircles));       
            countCircles++;
        }

        private void TriangleClick(object sender, EventArgs e)
        {
            TriangleFigure triangleFigure = new TriangleFigure(formPictureBox.Size);
            triangleFigure.randomColor = ColorTranslator.FromHtml(triangleFigure.htmlColor);
            if (Properties.Settings.Default.language.Equals(Constants.localParamRus))
            {triangleFigure.name = Constants.triangleNameRus;}
            else {triangleFigure.name = Constants.triangleNameEn;}
            figuresList.Add(triangleFigure);
            formTreeView.Nodes.Add(new TreeNode(triangleFigure.name + countTriangles));
            countTriangles++;
        }

        private void tvAfterSelect(object sender, TreeViewEventArgs e)
        {
            int indexOfNode = formTreeView.SelectedNode.Index;
            Figure changeFigure = figuresList[indexOfNode];
            changeFigure.enabled = false;
            if (changeFigure.enabled == false)
            {changeFigure.randomColor = Color.Black;}
            figuresList[indexOfNode] = changeFigure;
        }

        private void collision(List<Figure> listFigures)
        {
            if (listFigures.Count > 1)
            {
                for (int firstIndex = 0; firstIndex < listFigures.Count; firstIndex++)
                {
                    for (int secondIndex = listFigures.Count - 1; secondIndex > firstIndex; secondIndex--)
                    {
                        if (
                            ((figuresList[firstIndex].figureCoordX + Constants.widthFigure) >= (figuresList[secondIndex].figureCoordX))
                            &&
                             ((figuresList[firstIndex].figureCoordX) <= (figuresList[secondIndex].figureCoordX + Constants.widthFigure))
                                &&
                            ((figuresList[firstIndex].figureCoordY + Constants.heightFigure) >= (figuresList[secondIndex].figureCoordY))
                            &&
                             ((figuresList[firstIndex].figureCoordY) <= (figuresList[secondIndex].figureCoordY + Constants.heightFigure))
                          )
                        {
                            figuresList[firstIndex].dX = -figuresList[firstIndex].dX;
                            figuresList[firstIndex].dY = -figuresList[firstIndex].dY;
                            figuresList[secondIndex].dX = -figuresList[secondIndex].dX;
                            figuresList[secondIndex].dY = -figuresList[secondIndex].dY;
                        }
                    }
                }
            }
        }

        private void fmLoad(object sender, EventArgs e)
        {
            formTimer.Enabled = true;
            formTimer.Tick += new EventHandler(timerDo);
            formTimer.Interval = Constants.TimerInterval;
            string file, save, open, lang, rus, en, about;
            if (Properties.Settings.Default.language.Equals(Constants.localParamRus))
            {
                file = Constants.fileNameRus; save = Constants.saveNameRus; open = Constants.openNameRus;
                lang = Constants.languageRus; rus = Constants.languageThemeRusR; en = Constants.languageThemeRusE;
                about = Constants.AboutRus;
            }
            else
            {
                file = Constants.fileNameEn; save = Constants.saveNameEn; open = Constants.openNameEn;
                lang = Constants.languageEn; rus = Constants.languageThemeEnR; en = Constants.languageThemeEnE;
                about = Constants.AboutEn;
            }

            MainMenu mnuFileMenu = new MainMenu();
            this.Menu = mnuFileMenu;
            MenuItem myMenuItemFile = new MenuItem(file);
            MenuItem myMenuItemSave = new MenuItem(save);
            MenuItem myMenuItemOpen = new MenuItem(open);
            MenuItem myMenuLanguage = new MenuItem(lang);
            MenuItem myMenuLangRussian = new MenuItem(rus);
            MenuItem myMenuLangEnglish = new MenuItem(en);
            MenuItem myMenuItemAbout = new MenuItem(about);
            mnuFileMenu.MenuItems.Add(myMenuItemFile);
            myMenuItemFile.MenuItems.Add(myMenuItemSave);
            myMenuItemFile.MenuItems.Add(myMenuItemOpen);
            mnuFileMenu.MenuItems.Add(myMenuLanguage);
            myMenuLanguage.MenuItems.Add(myMenuLangRussian);
            myMenuLanguage.MenuItems.Add(myMenuLangEnglish);
            mnuFileMenu.MenuItems.Add(myMenuItemAbout);
            myMenuItemOpen.Click += new EventHandler(this.openFile);
            myMenuItemSave.Click += new EventHandler(this.saveFile);
            myMenuLangRussian.Click += new EventHandler(this.setRUS);
            myMenuLangEnglish.Click += new EventHandler(this.setEN);
            myMenuItemAbout.Click += new EventHandler(this.aboutInfo);
        }

        void setRUS(object sender, EventArgs e)
        {
            saveFile(sender, e);
            Properties.Settings.Default.language = Constants.localParamRus;
            Properties.Settings.Default.Save();
            FiguresForm newForm = new FiguresForm();
            FiguresForm.ActiveForm.Hide();
            newForm.Show();
        }

        void setEN(object sender, EventArgs e)
        {
            saveFile(sender, e);
            Properties.Settings.Default.language = Constants.localParamEn;
            Properties.Settings.Default.Save();
            FiguresForm newForm = new FiguresForm();
            FiguresForm.ActiveForm.Hide();
            newForm.Show();
        }

        void aboutInfo(object sender, EventArgs e)
        {
            MessageBox.Show("Developers: Stolyarenko K.S. & Zakutniy S.V.");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        { Environment.Exit(0); }

        private void treeNodeAdd(List<Figure> figuresList)
        {
            foreach (var figure in figuresList)
            {
                if (figure.GetType() == typeof(CircleFigure))
                {
                    figure.randomColor = System.Drawing.ColorTranslator.FromHtml(figure.htmlColor);
                    formTreeView.Nodes.Add(new TreeNode(figure.name + countCircles));
                    countCircles++;
                }
                else if (figure.GetType() == typeof(RectangleFigure))
                {
                    figure.randomColor = System.Drawing.ColorTranslator.FromHtml(figure.htmlColor);
                    formTreeView.Nodes.Add(new TreeNode(figure.name + countRectangles));
                    countRectangles++;
                }
                else if (figure.GetType() == typeof(TriangleFigure))
                {
                    figure.randomColor = System.Drawing.ColorTranslator.FromHtml(figure.htmlColor);
                    formTreeView.Nodes.Add(new TreeNode(figure.name + countCircles));
                    countTriangles++;
                }
            }
        }

        private void openFile(object sender, EventArgs e)
        {
            fileDialogOpen.InitialDirectory = Constants.InitialDirectory;
            fileDialogOpen.Filter = Constants.Filter;
            fileDialogOpen.RestoreDirectory = true;

            if (fileDialogOpen.ShowDialog() == DialogResult.OK)
            {
                    if ((openStream = fileDialogOpen.OpenFile()) != null)
                    {
                        using (openStream)
                        {
                            if (fileDialogOpen.FilterIndex == Constants.BinFilterIndex)
                            {
                                using (Stream fStream = File.OpenRead(fileDialogOpen.FileName))
                                {
                                    figuresList = (List<Figure>)binSerializer.Deserialize(fStream);
                                    treeNodeAdd(figuresList);
                                }
                            }
                            else if (fileDialogOpen.FilterIndex == Constants.JsonFilterIndex)
                            {
                                using (StreamReader file = new StreamReader(fileDialogOpen.FileName))
                                {
                                    string json = file.ReadToEnd();
                                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                                    figuresList = (List<Figure>)jsonSerializer.ReadObject(stream);
                                    treeNodeAdd(figuresList);       
                                }
                            }
                            else if (fileDialogOpen.FilterIndex == Constants.XmlFilterIndex)
                            {
                                TextReader textReader = new StreamReader(fileDialogOpen.FileName);
                                figuresList = (List<Figure>)xmlSerializer.Deserialize(textReader);
                                treeNodeAdd(figuresList);
                                textReader.Close();
                            }
                         }
                     }
                openStream.Close();
             }  
        }

        private void saveFile(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Constants.InitialDirectory;
            saveFileDialog.Filter = Constants.Filter;
            saveFileDialog.RestoreDirectory = true;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == Constants.BinFilterIndex)
                    {
                        using (Stream fStreamBin = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                        {binSerializer.Serialize(fStreamBin, figuresList);}
                    }
                else if (saveFileDialog.FilterIndex == Constants.JsonFilterIndex)
                    {
                        FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        StreamWriter file = new StreamWriter(fileStream);
                        using (var stream = new MemoryStream())
                        {
                            jsonSerializer.WriteObject(stream, figuresList);
                            string json = Encoding.UTF8.GetString(stream.ToArray());
                            file.Write(json);
                            file.Close();
                        }
                    }
                else if (saveFileDialog.FilterIndex == Constants.XmlFilterIndex)
                    {
                        FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                        StreamWriter file = new StreamWriter(fileStream);
                        xmlSerializer.Serialize(file, figuresList);
                        file.Close();
                    }
                }
            }

        private void fmUnload(object sender, EventArgs e)
        {
            formTimer.Stop();
            formTimer.Dispose();
        }

        private void timerDo(object sender, EventArgs e)
        {
            formPictureBox.Refresh();
            collision(figuresList);
        }

        private void tvDoubleClick(object sender, EventArgs e)
        {
            Random randomVariable = new Random();
            Color randomColor = Color.FromArgb(randomVariable.Next(Constants.ColorIndex), randomVariable.Next(Constants.ColorIndex), 
            randomVariable.Next(Constants.ColorIndex));
            int indexOfNode = formTreeView.SelectedNode.Index;
            Figure changeFigure = figuresList[indexOfNode];
            changeFigure.enabled = true;
            if (changeFigure.enabled == true)
            {changeFigure.randomColor = randomColor;}
            figuresList[indexOfNode] = changeFigure;
        }

        private void pbMainPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            foreach (var figure in figuresList)
            {
                Point maxPointOfPictureBox = (Point)formPictureBox.Size;
                figure.draw(graphics);
                figure.move(maxPointOfPictureBox);
            }
        }
    }
}