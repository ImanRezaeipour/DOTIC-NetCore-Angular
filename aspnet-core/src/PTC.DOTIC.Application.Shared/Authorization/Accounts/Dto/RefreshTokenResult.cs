﻿namespace PTC.DOTIC.Authorization.Accounts.Dto
{
    public class RefreshTokenResult
    {
        public string AccessToken { get; set; }

        public RefreshTokenResult(string accessToken)
        {
            AccessToken = accessToken;
        }

        public RefreshTokenResult()
        {
            
        }
    }
}