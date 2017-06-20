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
    public class TriangleFigure:Figure
    {
        [NonSerialized()]
        SolidBrush solidBrushColor;
        [NonSerialized()]
        RandomClass randomClass = new RandomClass();
        public Point trianglePointTop, trianglePointLeft, trianglePointRight;
        public TriangleFigure() {}

        public TriangleFigure(Size pictureBoxSize)
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
            trianglePointLeft.X = figureCoordX;
            trianglePointLeft.Y = figureCoordY + Constants.heightFigure;
            trianglePointTop.X = figureCoordX + Constants.widthFigure;
            trianglePointTop.Y = figureCoordY + Constants.heightFigure;
            trianglePointRight.X = figureCoordX + (Constants.widthFigure / 2);
            trianglePointRight.Y = figureCoordY;
            Point [] points = {trianglePointLeft,trianglePointTop,trianglePointRight};
            solidBrushColor = new SolidBrush(randomColor);
            pictureBoxGraphics.FillPolygon(solidBrushColor, points);
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
