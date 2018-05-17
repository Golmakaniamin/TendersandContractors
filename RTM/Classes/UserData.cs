
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM
{
    public static class UserData
    {
        public static RTM.User CurrentUser = new RTM.User() ;
        public static RTM.Position CurrentPoistion = new RTM.Position();
        public static RTM.AccessRight CurrentAccessRight = new RTM.AccessRight();
        public static RTM.OrganizationalChart OrganizationalPosition = new RTM.OrganizationalChart();
    }
    
}
