using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Configuration;

namespace InnerMetrixWeb.Services
{
    public class DomainService
    {
        private PrincipalContext principalContext;
        private UserPrincipal userPrincipal;
        private GroupPrincipal groupPrincipal;
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set { _isAuthenticated = value; }
        }

        public DomainService()
        {

        }
        public DomainService(string userid, string password)
        {
            principalContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["Domain"]);
            userPrincipal = UserIsAuthenticated(userid, password) ? new UserPrincipal(principalContext, userid, password, true) : null;

            if (userPrincipal != null)
            {
                _isAuthenticated = true;
                //groupPrincipal.Members.Contains(userPrincipal);
                //GetGroup();
                //_isAuthenticated = groupPrincipal.Members.Contains(userPrincipal);
                //_isAuthenticated = userPrincipal.IsMemberOf(GetGroup()) ? true : false;
            }
            else
            {
                _isAuthenticated = false;
            }
        }
        public bool UserIsAuthenticated(string uid, string pwd)
        {
            return principalContext.ValidateCredentials(uid, pwd);
        }

        public bool CheckIfUserIsInGroup()
        {
            return false;
        }

        public GroupPrincipal GetGroup()
        {
            groupPrincipal = GroupPrincipal.FindByIdentity(principalContext, "ITALL");
            return groupPrincipal;
        }

    }
}