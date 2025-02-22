using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service.DomainService.Interface;
using Infrastructure.Core.Entities;
using Infrastructure.Core.UnitOfWork.Interface;

namespace Domain.Service.DomainService
{
    public class AuthDomainService : IAuthDomainService
    {
        public async Task<UserEntity> ValidateUserAsync(string email, string password, IUnitOfWork _unitOfWork)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("El email y la contraseña son requeridos.");

            var users = await _unitOfWork.Users.GetAllAsync();
            var foundUser = users.Find(u => u.Email == email && u.Password == password);

            if (foundUser == null)
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");

            return foundUser;
        }
    }
}
