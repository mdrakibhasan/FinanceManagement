using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pos.Infrustructure;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;
        private readonly IConfiguration _configuration;
        List<Login> LoginInfo =new List<Login>();
       
        public ApplicationUserRepository(IMapper mapper, PosDbContext dbContext, IConfiguration configuration) 
        {
            _configuration = configuration;
             _dbContext = dbContext;
            _mapper = mapper;
            LoginInfo.Add(new Login { Password = "1234", Username = "admin" });
        }

        public async Task<LoginResponse> UserLogin(string username, string password)
        {
            var result = LoginInfo.Find(a=>a.Username==username && a.Password==password);

            if (result!=null)
            {
                string SecretKey = _configuration["AppSettings:Secret"];
                _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int AccessTokenValidityInMinutes);
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int RefreshTokenValidityInDays);
                //var userInformation = await _userManager.FindByNameAsync(username);
                //if (userInformation.IsOfficial != 1 && userInformation.EmailConfirmed == false)
                //{
                //    return null;

                //}
                //bool Delete = await DeleteRecentToken(userInformation.Id, ipAddress);
                string AccessToken = await GenerateAccessTokenAsync(username, AccessTokenValidityInMinutes, SecretKey, "");
                //string RefreshToken = GenerateRefreshToken();
                //UserRefreshToken RefreshTokenObject = await SaveTokenDetails(ipAddress, userInformation.Id.ToString(), AccessToken, RefreshToken, RefreshTokenValidityInDays);

                //var RefreshTokenList = _dbContext.UserRefreshToken.Where(p => p.UserRefreshTokenId == RefreshTokenObject.UserRefreshTokenId).FirstOrDefault();
                //RefreshTokenList.IsInvalidated = false;
                //_dbContext.Update(RefreshTokenList);
                //_dbContext.SaveChanges();

                return await CreateTokenRespose("Bearer", AccessToken, AccessTokenValidityInMinutes, AccessToken, RefreshTokenValidityInDays);
            }
            return null;
        }
        public async Task<LoginResponse> CreateTokenRespose(string TokenType, string AccessToken, int AccessTokenTime, string RefreshToken, int RefreshTokenTime)
        {

            var stream = AccessToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var AccessTokenCreateTime = tokenS.Claims.First(claim => claim.Type == "nbf").Value;
            var AccessTokenValidTill = tokenS.Claims.First(claim => claim.Type == "exp").Value;
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            //Creating Model
            LoginResponse _model = new LoginResponse();
            _model.Type = TokenType;
            _model.AccessToken = AccessToken;
            _model.AccessTokenCreateTime = dateTime.AddSeconds(Convert.ToDouble(AccessTokenCreateTime)).ToLocalTime().ToString();
            _model.AccessTokenValidity = AccessTokenTime.ToString() + " Minutes";
            _model.AccessTokenValidTill = dateTime.AddSeconds(Convert.ToDouble(AccessTokenValidTill)).ToLocalTime().ToString();
            _model.RefreshToken = RefreshToken;
            _model.RefreshTokenCreateTime = DateTime.Now.ToString();
            _model.RefreshTokenValidity = RefreshTokenTime.ToString() + " Days";
            _model.RefreshTokenValidTill = DateTime.Now.AddDays(1).ToString();
            return _model;
        }
        private async Task<string> GenerateAccessTokenAsync(UserInformation userInformation, int AccessTokenValidityInMinutes, string SecretKey, string ipAddress)
        {
            var keybytes = Encoding.ASCII.GetBytes(SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature);
            var nbf = DateTime.UtcNow.AddSeconds(-1);
            var exp = DateTime.UtcNow.AddMinutes(AccessTokenValidityInMinutes);
            var payload = new JwtPayload(null, "", new List<Claim>(), nbf, exp);
            //var AllRoles = await _userManager.GetRolesAsync(userInformation);
            //List<ClaimsModel> AllRoleClaims = new List<ClaimsModel>();
            var permissionList = new Dictionary<string, object>();
            int sl = 100;
            //if (AllRoles.Contains("SuperAdmin"))
            //{
            //    List<ControllerActions> data = _dbContext.AspNetControllerActions.ToList();
            //    List<string> Controllers = data.Select(p => p.Controller).Distinct().ToList();
            //    foreach (string controller in Controllers)
            //    {
            //        List<string> Actions = data.Where(p => p.Controller == controller).Select(p => p.Action).ToList();
            //        permissionList.Add(controller, Actions);
            //    }
            //    payload.Add("userRoleSl", 0);
            //}
            payload.Add("userRoleSl", 0);

            //payload.Add("userId", userInformation.Id);
            //payload.Add("name", userInformation.UserName);
            //payload.Add("role", AllRoles.ToList());
            //payload.Add("ipAddress", ipAddress);
            //payload.Add("userClaims", permissionList);
            //payload.Add("accsessLevel", userInformation.AccessLabel == null ? "" : userInformation.AccessLabel);
            //payload.Add("countryId", userInformation.CountryId);
            //payload.Add("stateId", userInformation.StateId);
            //payload.Add("regionId", userInformation.RegionId);
            //payload.Add("districtId", userInformation.DistrictId);
            //payload.Add("isOfficial", userInformation.IsOfficial);
            //payload.Add("personId", userInformation.PersonId);


            var jwtToken = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(jwtToken);
        }
        private async Task<string> GenerateAccessTokenAsync(string UserName, int AccessTokenValidityInMinutes, string SecretKey, string ipAddress)
        {
            var keybytes = Encoding.ASCII.GetBytes(SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature);
            var nbf = DateTime.UtcNow.AddSeconds(-1);
            var exp = DateTime.UtcNow.AddMinutes(AccessTokenValidityInMinutes);
            var payload = new JwtPayload(null, "", new List<Claim>(), nbf, exp);
            //var AllRoles = await _userManager.GetRolesAsync(userInformation);
            //List<ClaimsModel> AllRoleClaims = new List<ClaimsModel>();
            var permissionList = new Dictionary<string, object>();
            int sl = 100;
            //if (AllRoles.Contains("SuperAdmin"))
            //{
            //    List<ControllerActions> data = _dbContext.AspNetControllerActions.ToList();
            //    List<string> Controllers = data.Select(p => p.Controller).Distinct().ToList();
            //    foreach (string controller in Controllers)
            //    {
            //        List<string> Actions = data.Where(p => p.Controller == controller).Select(p => p.Action).ToList();
            //        permissionList.Add(controller, Actions);
            //    }
            //    payload.Add("userRoleSl", 0);
            //}
            payload.Add("userRoleSl", 0);

            payload.Add("userId", 1);
            payload.Add("name", UserName);
            payload.Add("role", "Admin");
            payload.Add("ipAddress", ipAddress);
            //payload.Add("userClaims", permissionList);
            //payload.Add("accsessLevel", userInformation.AccessLabel == null ? "" : userInformation.AccessLabel);
            //payload.Add("countryId", userInformation.CountryId);
            //payload.Add("stateId", userInformation.StateId);
            //payload.Add("regionId", userInformation.RegionId);
            //payload.Add("districtId", userInformation.DistrictId);
            //payload.Add("isOfficial", userInformation.IsOfficial);
            //payload.Add("personId", userInformation.PersonId);


            var jwtToken = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(jwtToken);
        }
    }

}
