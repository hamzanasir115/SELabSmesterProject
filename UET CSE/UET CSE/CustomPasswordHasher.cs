using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UET_CSE
{
    public class CustomPasswordHasher: IPasswordHasher
    {
        public string HashPassword(string Password)
        {
            return Encrypt.GetHash(Password);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if(hashedPassword == HashPassword(providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}