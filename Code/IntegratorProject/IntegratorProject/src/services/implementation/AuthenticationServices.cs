﻿using IntegratorProject.src.dtos;
using IntegratorProject.src.models;
using IntegratorProject.src.repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegratorProject.src.services
{
    public class AuthenticationServices : IAuthentication
    {

        #region Attributes
        private readonly IUser _repository;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public AuthenticationServices(IUser repository, IConfiguration configuration)
        {
            _repository = repository;
            Configuration = configuration;
        }
        #endregion

        #region Method
        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }
        public void CreateUserNotDuplicated(NewUserDTO dto)
        {
            var user = _repository.GetUserByEmail(dto.Email);
            if (user != null) throw new Exception("This email is already being used");
            dto.Password = EncodePassword(dto.Password);
            _repository.AddNewUser(dto);
        }
        public string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Type.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
        public AuthorizationDTO GetAuthorization(AuthenticateDTO authentication)
        {
            var user = _repository.GetUserByEmail(authentication.Email);
            if (user == null) throw new Exception("User not found");
            if (user.Password != EncodePassword(authentication.Password)) throw new Exception("Incorrect Password ");
            return new AuthorizationDTO(user.Id, user.Email, user.Type, GenerateToken(user));
        }
        #endregion method
    }
}
