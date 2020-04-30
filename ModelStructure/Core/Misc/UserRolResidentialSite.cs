using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelStructure.Core.Misc
{
    /// <summary>
    /// clase para la relación de cada usuario con su site y rol
    /// </summary>
    public class UserRolResidentialSite
    {
        public ResidentialSite Site { get; set; }

        /// <summary>
        /// Rol del usuario en el Site
        /// </summary>
        public int IdRol { get; set; }

        public string RolName { get; set; }
    }
}
