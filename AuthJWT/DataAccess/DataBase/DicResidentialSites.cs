using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class DicResidentialSites
    {
        public DicResidentialSites()
        {
            UserRolesResidentialSites = new HashSet<UserRolesResidentialSites>();
        }

        public string RsiIdResidentialPk { get; set; }
        public string RsiName { get; set; }
        public string RsiDirection { get; set; }

        public virtual ICollection<UserRolesResidentialSites> UserRolesResidentialSites { get; set; }
    }
}
