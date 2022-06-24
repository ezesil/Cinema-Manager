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
    internal class IntegrityDataAdapter : IGenericAdapter<Persona>
    {
        /// <summary>
        /// Adapta los datos necesarios para verificar su integridad.
        /// </summary>
        /// <param name="values"></param>
        /// <returns>Retorna un objeto Persona hidratado con datos necesarios para chequeo de integridad.</returns>
        public Persona Adapt(object[] values)
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
    }
}
