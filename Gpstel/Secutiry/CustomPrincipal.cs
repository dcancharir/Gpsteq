using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Gpstel.Models;

namespace Gpstel.Security
{
    public class CustomPrincipal:IPrincipal
    {
        private Usuario Account;
        //private AccountModel am = new AccountModel();
        public CustomPrincipal(Usuario account) {
            this.Account = account;
            this.Identity = new GenericIdentity(account.nombre);
        }
        public IIdentity Identity { get; set; }
        public bool IsInRole(String role) {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.tipo.Contains(r));
        }
    }
}