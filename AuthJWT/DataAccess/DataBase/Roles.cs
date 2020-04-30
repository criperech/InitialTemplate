using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class Roles
    {
        public Roles()
        {
            UserRolesResidentialSites = new HashSet<UserRolesResidentialSites>();
        }

        public int RolIdRolPk { get; set; }
        public string RolName { get; set; }
        public string RolDescription { get; set; }
        public DateTime RolDateCreation { get; set; }

        public virtual ICollection<UserRolesResidentialSites> UserRolesResidentialSites { get; set; }
    }
}
