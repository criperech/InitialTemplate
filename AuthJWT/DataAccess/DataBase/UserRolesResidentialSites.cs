using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class UserRolesResidentialSites
    {
        public int UrrIdUserRolPk { get; set; }
        public int UrrIdRolFk { get; set; }
        public string UrrIdUserFk { get; set; }
        public string UrrIdResidentialSiteFk { get; set; }
        public DateTime UrrDateCreation { get; set; }

        public virtual DicResidentialSites UrrIdResidentialSiteFkNavigation { get; set; }
        public virtual Roles UrrIdRolFkNavigation { get; set; }
        public virtual Users UrrIdUserFkNavigation { get; set; }
    }
}
