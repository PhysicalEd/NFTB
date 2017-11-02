using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NFTB.API.Security
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime WhenTokenExpires { get; set; }
    }
}