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
    [Serializable]
    [XmlType]
    [DataContract]

    public class RectangleFigure:Figure
    {
        Rectangle rectangle = new Rectangle();
        [NonSerialized()]
        SolidBrush solidBrushColor;
        [NonSerialized()]
        RandomClass randomClass = new RandomClass();
        public RectangleFigure() { }

        public RectangleFigure(Size pictureBoxSize)
        {
            figureCoordX = random.Next(pictureBoxSize.Width - Constants.widthFigure);
            figureCoordY = random.Next(pictureBoxSize.Height - Constants.heightFigure);
            randomColor = randomClass.getFigureColor();
            dX = randomClass.increaseX();
            dY = randomClass.increaseY();
            enabled = true;
        }

        public override void draw(Graphics pictureBoxGraphics)
        {
            solidBrushColor = new SolidBrush(randomColor);
            rectangle.X = figureCoordX;
            rectangle.Y = figureCoordY;
            rectangle.Width = Constants.widthFigure;
            rectangle.Height = Constants.heightFigure;
            pictureBoxGraphics.FillRectangle(solidBrushColor, rectangle);
        }

        public override void move(Point pointMax)
        {
            if ((figureCoordX <= Constants.pictureBoxMargin) || (figureCoordX >= pointMax.X - Constants.widthFigure)
               || (figureCoordY <= Constants.pictureBoxMargin) || (figureCoordY >= pointMax.Y - Constants.heightFigure))
            {
                dX = -dX;
                dY = -dY;  
            }
            figureCoordX += dX;
            figureCoordY += dY;
        }
    }
}
