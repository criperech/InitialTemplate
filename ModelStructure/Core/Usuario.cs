using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelStructure.Core
{
    public class Usuario
    {
        /// <summary>
        /// Id del usuario personalizado
        /// </summary>
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string BirthdayDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string AccessFailedCount { get; set; }
        public string TwoFactorEnabled { get; set; }
        public string LockoutEndDateUtc { get; set; }
        public string LockoutEnabled { get; set; }
        public string IdUserCreate { get; set; }
        public string CreationDate { get; set; }
        public string State { get; set; }
        public string Image { get; set; }
        public string PhoneHome { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string TokenRecovery { get; set; }

    }
}
