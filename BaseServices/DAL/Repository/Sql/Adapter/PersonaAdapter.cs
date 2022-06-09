using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Login;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Clase de tipo Adaptador.
    /// </summary>
    internal class PersonaAdapter
    {

        private readonly static PersonaAdapter Instance = new PersonaAdapter();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static PersonaAdapter Current
        {
            get
            {
                return Instance;
            }
        }

        private PersonaAdapter()
        {

        }

        /// <summary>
        /// Metodo utilizado para adaptar un vector de objetos a un objeto Persona.
        /// Nota: Solo adapta los valores de usuario, correo y su estado de habilitacion.
        /// </summary>
        /// <param name="values">Vector de objetos que corresponden a la clase Persona.</param>
        /// <returns>Retorna un objeto de tipo Persona.</returns>
        public Persona AdaptLoginData(object[] values)
        {
            return new Persona
            {//guid_persona, usuario, contraseña, emailprincipal, TipoUsuario, DVH
                Usuario = values[1].ToString(),
                Correo = values[3].ToString(),
                Habilitado = values[4].ToString()
                
            };
        }

        /// <summary>
        /// Adapta los datos necesarios para verificar su integridad.
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Retorna un objeto Persona hidratado con datos necesarios para chequeo de integridad.</returns>
        public Persona AdaptIntegrityData(object[] values)
        {
            return new Persona
            {
                Guid = Guid.Parse(values[0].ToString()),
                Usuario = values[1].ToString(),
                Contraseña = values[2].ToString(),
                Correo = values[3].ToString(),
                TipoUsuario = (Persona.TipoPersona)values[4],
                DVH = (int)values[5]
            };
        }

        /// <summary>
        /// Adapta los datos del usuario.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Persona AdaptUserData(object[] values)
        {
            var p = new Persona
            {
                Guid = Guid.Parse(values[0].ToString()),
                Usuario = values[1].ToString(),
                Correo = values[2].ToString(),
                Habilitado = values[3].ToString(),
                TipoUsuario = (Persona.TipoPersona)values[4],
                Rol = values[5].ToString(),                          
            };

            foreach(var item in values[6].ToString().Split(';'))
            {
                p.Permisos.Add(new Permiso(item));
            }

            return p;
        }


        public Persona AdaptCorrectedIntegrityData(object[] values)
        {
            return new Persona
            {
                Guid = Guid.Parse(values[0].ToString()),
                Usuario = values[1].ToString(),
                Contraseña = values[2].ToString(),
                Correo = values[3].ToString(),
                TipoUsuario = (Persona.TipoPersona)values[4],
            };
        }












    }
}
