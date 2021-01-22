using AutoMapper;
using CarPartShop.IRepositories;
using CarPartShop.Models;
using CarPartShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CarPartShop.DTO;

namespace CarPartShop.Services
{
    public class UserService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(long id)
        {
            return _userRepository.GetById(id);
        }

        public AuthenticationResponse Register(RegisterRequest request)
        {
            // If user with the same email exists, return null
            if (_userRepository.GetByEmail(request.Email) != null)
                return null;
            var user = _mapper.Map<RegisterRequest, User>(request);

            _userRepository.Create(user);
            // If we can't save the new user, return null
            if (!_userRepository.SaveChanges())
                return null;
            var authResponse = _mapper.Map<User, AuthenticationResponse>(user);
            authResponse.Token = GenerateJwtForUser(user);
            return authResponse;
        }

        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // find user
            var user = _userRepository.GetByEmailAndPassword(request.Email, request.Password);
            if (user == null) return null;

            // attach token to DTO
            var authenticationResponse = _mapper.Map<User, AuthenticationResponse>(user);
            authenticationResponse.Token = GenerateJwtForUser(user);

            return authenticationResponse;
        }

        private string GenerateJwtForUser(User user)
        {
            // generate token that is valid for 1 day
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
