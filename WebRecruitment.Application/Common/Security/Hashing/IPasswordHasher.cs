using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRecruitment.Application.Common.Security.Hashing
{
    public interface IPasswordHasher
    {
        string HashPasword(string password, out byte[] salt);
        bool VerifyPassword(string password, string storedHash);

        string HashPassword(string password);
        bool VerifyPasswordB(string password, string hashedPassword);
    }
}
