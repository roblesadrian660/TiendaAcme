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
    public class UserDomainService: IUserDomainService
    {
        public void ValidateUserCreation(UserEntity userEntity, IUnitOfWork unitOfWork)
        {
            if (string.IsNullOrWhiteSpace(userEntity.Email))
                throw new ArgumentException("El correo electrónico no puede ser nulo ni vacío.");

            if (string.IsNullOrWhiteSpace(userEntity.Password))
                throw new ArgumentException("La contraseña no puede ser nula ni vacía.");

            var users = unitOfWork.Users.GetAll();

            if (users.Any(o => o.UserId == userEntity.UserId))
                throw new InvalidOperationException($"El usuario con ID {userEntity.UserId} ya existe.");

            if (users.Any(o => o.Email == userEntity.Email))
                throw new InvalidOperationException($"El correo {userEntity.Email} ya está registrado.");
        }
    }
}
