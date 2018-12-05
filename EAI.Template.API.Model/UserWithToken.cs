using System;
using System.Collections.Generic;
using System.Text;

namespace EAI.Template.API.Model
{
    public class UserWithToken
    {
        public DateTime ExpiresAt { get; set; }
        public string Token { get; set; }
    }
}
