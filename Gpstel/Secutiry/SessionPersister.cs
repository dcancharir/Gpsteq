using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gpstel.Security
{
    public static class SessionPersister
    {
        static string usernameSessionvar = "username";
        static string usertypeSessionvar = "employee";
        public static string Username {
            get {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }
        public static string Usertype {
            get {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usertypeSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set {
                HttpContext.Current.Session[usertypeSessionvar] = value;
            }
        }
    }
}