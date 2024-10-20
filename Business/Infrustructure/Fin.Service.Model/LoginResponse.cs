using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class LoginResponse:IVm
    {
        public string Type { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenCreateTime { get; set; }
        public string AccessTokenValidity { get; set; }
        public string AccessTokenValidTill { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenCreateTime { get; set; }
        public string RefreshTokenValidity { get; set; }
        public string RefreshTokenValidTill { get; set; }
        public int Id { get; set; }
    }
}
