using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Blogsayti.AppClasses
{
    public class Settings
    {
        public static Size Resmkicikboyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Smallwidth"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Smallheight"]);
                return sonuc;
            }
        }

        public static Size Resmortaboyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Mediumwidth"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Mediumheight"]);
                return sonuc;
            }
        }

        public static Size Resmboyukboyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Largewidth"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Largeheight"]);
                return sonuc;
            }
        }

        public static Size Yazarresimboyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Yazar"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Yazar"]);
                return sonuc;
            }
        }





    }
}