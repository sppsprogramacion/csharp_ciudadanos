using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCache
{
    public class CurrentUser
    {
        private static CurrentUser _instance;

        // Propiedades del usuario
        public int id_usuario { get; private set; }
        public string apellido { get; private set; }
        public string nombre { get; private set; }
        public bool is_active { get; private set; }
        public string[] roles { get; private set; }
        //public DateTime? LastLogin { get; private set; }

        // Constructor privado para implementar el patrón Singleton
        private CurrentUser() { }

        // Método para obtener la instancia única
        public static CurrentUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CurrentUser();
                }
                return _instance;
            }
        }

        // Método para establecer los datos del usuario
        public void SetUser(int userId, string apellidox, string nombrex, bool isActivex, string[] rolesx)
        {
            id_usuario = userId;
            apellido = apellidox;
            nombre = nombrex;
            is_active = isActivex;
            roles = rolesx;
        }

        // Método para limpiar los datos del usuario (cerrar sesión)
        public void Clear()
        {
            id_usuario = 0;
            apellido = string.Empty; ;
            nombre = string.Empty; ;
            is_active = false;
            roles = null;
        }
    }
}
