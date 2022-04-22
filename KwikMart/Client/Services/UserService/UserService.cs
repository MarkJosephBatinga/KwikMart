﻿using KwikMart.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KwikMart.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> LoginUser(LoginUser existingUser)
        {
            var result = await _httpClient.PostAsJsonAsync("api/user/login", existingUser);
            var status = await result.Content.ReadFromJsonAsync<User>();
            return status;
        }

        public async Task<List<User>> RegisterUser(User newUser)
        {
            var result = await _httpClient.PostAsJsonAsync("api/user/register", newUser);
            var status = await result.Content.ReadFromJsonAsync<List<User>>();
            return status;
        }
    }
}