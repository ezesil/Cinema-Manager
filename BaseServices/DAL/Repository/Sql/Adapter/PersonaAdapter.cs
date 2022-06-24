﻿using System;
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
    internal class PersonaAdapter : IGenericAdapter<Persona>
    {
        /// <summary>
        /// Adapta los datos del usuario.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Persona Adapt(object[] values)
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
    }
}
