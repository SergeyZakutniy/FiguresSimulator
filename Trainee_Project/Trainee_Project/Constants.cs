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
    public class Constants
    {
        public const int widthFigure = 50;
        public const int heightFigure = 50;
        public const int pictureBoxMargin = 5;
        public const string rectangleNameRus = "Квадрат";
        public const string rectangleNameEn = "Square";
        public const string circleNameRus = "Круг";
        public const string circleNameEn = "Circle";
        public const string triangleNameRus = "Треугольник";
        public const string triangleNameEn = "Triangle";
        public const string localParamRus = "ru";
        public const string localParamEn = "en";
        public const string fileNameRus = "&Файл";
        public const string fileNameEn = "&File";
        public const string saveNameRus = "&Сохранить Файл";
        public const string saveNameEn = "&Save";
        public const string openNameRus = "&Открыть Файл";
        public const string openNameEn = "&Open";
        public const string languageRus = "&Язык";
        public const string languageEn = "&Language";
        public const string languageThemeRusR = "&Русский";
        public const string languageThemeRusE = "&Английский";
        public const string languageThemeEnR = "&Russian";
        public const string languageThemeEnE = "&English";
        public const string InitialDirectory = "C:\\Users\\1\\Desktop";
        public const string Filter = "(*.bin)|*.bin|(*.json*)|*.json|(*.xml)|*.xml";
        public const int TimerInterval = 50;
        public const int BinFilterIndex = 1;
        public const int JsonFilterIndex = 2;
        public const int XmlFilterIndex = 3;
        public const int ColorIndex = 255;
        public const string NameMember = "name";
        public const string HtmlColorMember = "htmlColor";
        public const string CoordXMember = "figureCoordX";
        public const string CoordYMember = "figureCoordY";
        public const string dXMember = "dX";
        public const string dYMember = "dY";
        public const string EnabledMember = "enabled";
        public const string AboutRus = "Справка";
        public const string AboutEn = "About";
    }
}
