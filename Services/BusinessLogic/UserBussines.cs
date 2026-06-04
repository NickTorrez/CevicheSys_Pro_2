using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Repositories;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class UserBussines
    {
        private readonly UserRepository _userRepository;
        public UserBussines(UserRepository userRepository) => _userRepository = userRepository;

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("El usuario y contraseña no pueden estar vacíos.");

            // Intenta autenticar en Base de Datos; si falla o no está conectada, usa el Mock del Dominio
            User user = _userRepository.Authenticate(username, password);
            return user ?? User.MockAuthenticate(username, password);
        }
    }
}
