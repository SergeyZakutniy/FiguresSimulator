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
    public class RandomClass
    {
        Random random = new Random();
        Color randomColor = new Color();
        int[] moveCoefficients = { -4, -3, -2, -1, 1, 2, 3, 4 };

        public Color getFigureColor()
        {
            randomColor = Color.FromArgb(random.Next(0,255), random.Next(0,255), random.Next(0,255));
            return randomColor;
        }

        public int increaseX()
        {
            int dX = random.Next(moveCoefficients[0], moveCoefficients[moveCoefficients.Length - 1]);
            return dX;
        }

        public int increaseY()
        {
            int dY = random.Next(moveCoefficients[0], moveCoefficients[moveCoefficients.Length - 1]);
            return dY;
        }
    }
}
