using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelStructure.Core.Misc
{
    public class UserApp
    {

        public UserApp()
        {
            this.SitesWithRol = new List<UserRolResidentialSite>();
        }

        public bool Login { get; set; }
        /// <summary>
        /// Data del usuario
        /// </summary>
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
        public DateTime ExpireToken { get; set; }

        public List<UserRolResidentialSite>  SitesWithRol { get; set; }

    }
}
