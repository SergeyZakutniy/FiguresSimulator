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
    [System.Xml.Serialization.XmlInclude(typeof(CircleFigure))]
    [System.Xml.Serialization.XmlInclude(typeof(TriangleFigure))]
    [System.Xml.Serialization.XmlInclude(typeof(RectangleFigure))]
    [XmlType]
    [DataContract]
    [KnownType(typeof(CircleFigure))]
    [KnownType(typeof(TriangleFigure))]
    [KnownType(typeof(RectangleFigure))]
    abstract public class Figure
    {
        public abstract void draw(Graphics pictureBoxGraphics);
        public abstract void move(Point pointMax);
        [DataMember(Name = Constants.NameMember)]
        public string name;
        public static Random random = new Random();
        [DataMember(Name = Constants.HtmlColorMember)]
        public string htmlColor = ColorTranslator.ToHtml(Color.FromArgb(random.Next(Constants.ColorIndex), random.Next(Constants.ColorIndex),
        random.Next(Constants.ColorIndex)));
        [XmlIgnore]
        public Color randomColor;
        [DataMember(Name = Constants.CoordXMember)]
        public int figureCoordX;
        [DataMember(Name = Constants.CoordYMember)]
        public int figureCoordY;
        [DataMember(Name = Constants.dXMember)]
        public int dX;
        [DataMember(Name = Constants.dYMember)]
        public int dY;
        [DataMember(Name = Constants.EnabledMember)]
        public bool enabled;

        public Figure() {}

    }
}
