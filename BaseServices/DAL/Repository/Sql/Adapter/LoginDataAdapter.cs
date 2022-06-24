using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Login;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Clase de tipo Adaptador.
    /// </summary>
    internal class LoginDataAdapter : IGenericAdapter<Persona>
    {
        /// <summary>
        /// Metodo utilizado para adaptar un vector de objetos a un objeto Persona.
        /// Nota: Solo adapta los valores de usuario, correo y su estado de habilitacion.
        /// </summary>
        /// <param name="values">Vector de objetos que corresponden a la clase Persona.</param>
        /// <returns>Retorna un objeto de tipo Persona.</returns>
        public Persona Adapt(object[] values)
        {
            return new Persona
            {//guid_persona, usuario, contraseña, emailprincipal, TipoUsuario, DVH
                Usuario = values[1].ToString(),
                Correo = values[3].ToString(),
                Habilitado = values[4].ToString()              
            };
        }
    }
}
