using System;
using System.Collections.Generic;

namespace WebApi.DataAccess.DataBase
{
    public partial class Users
    {
        public Users()
        {
            UserRolesResidentialSites = new HashSet<UserRolesResidentialSites>();
        }

        public string UseIdUsuarioPk { get; set; }
        public string UseUserName { get; set; }
        public string UseFirstName { get; set; }
        public string UseSecondName { get; set; }
        public string UseFirstLastName { get; set; }
        public string UseSecondLastName { get; set; }
        public DateTime? UseBirthdayDate { get; set; }
        public string UseEmail { get; set; }
        public string UsePhoneNumber { get; set; }
        public string UsePasswordHash { get; set; }
        public string UseSecurityStamp { get; set; }
        public int UseAccessFailedCount { get; set; }
        public bool UseTwoFactorEnabled { get; set; }
        public DateTime? UseLockoutEndDateUtc { get; set; }
        public bool UseLockoutEnabled { get; set; }
        public int? UseIdUserCreate { get; set; }
        public DateTime UseCreationDate { get; set; }
        public bool UseState { get; set; }
        public string UseImage { get; set; }
        public string UsePhoneHome { get; set; }
        public string UsePostalCode { get; set; }
        public string UseStreetAddress { get; set; }
        public string UseTokenRecovery { get; set; }

        public virtual ICollection<UserRolesResidentialSites> UserRolesResidentialSites { get; set; }
    }
}
