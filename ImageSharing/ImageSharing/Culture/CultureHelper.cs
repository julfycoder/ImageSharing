using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.SessionState;
using System.Globalization;

namespace ImageSharing.Culture
{
    public class CultureHelper
    {
        protected HttpSessionState session;
        public CultureHelper(HttpSessionState session)
        {
            this.session = session;
        }
        public static int CurrentCulture
        {
            get
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "en-US") return 0;
                else if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU") return 1;
                return 0;
            }
            set
            {
                if (value == 0) Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                else if (value == 1) Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            }
        }
    }
}