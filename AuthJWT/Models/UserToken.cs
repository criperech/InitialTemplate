using System;

namespace AuthJWT.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime ExpirationToken { get; set; }
    }
}
