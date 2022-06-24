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
    internal class CorrectedIntegrityDataAdapter : IGenericAdapter<Persona>
    {

        public Persona Adapt(object[] values)
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
