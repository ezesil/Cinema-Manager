using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.DAL.Tools;
using BaseServices.Domain.Login;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    /// <summary>
    /// Repositorio de login para la clase Persona.
    /// </summary>
    internal class PersonaRepository : ILoginRepository<Persona>
    {


        #region statements

        private string SelectPassUsuario
        {
            get => "SELECT TOP (1) ([contraseña]) FROM [Persona] WHERE [usuario] = @Usuario";
        }


        private string SelectPassCorreo
        {
            get => "SELECT TOP (1) ([contraseña]) FROM [Persona] WHERE [emailprincipal] = @Correo";
        }

        private string SelectAllStatement 
        {
            //c.Guid.ToString() + c.Usuario + hashpass.ToString() + c.Correo + c.TipoUsuario.ToString()
            get => "SELECT guid_persona, usuario, contraseña, emailprincipal, TipoUsuario, DVH from [Persona]";              
        }

        private string SelectOneStatement
        {
            //c.Guid.ToString() + c.Usuario + hashpass.ToString() + c.Correo + c.TipoUsuario.ToString()
            get => "SELECT guid_persona, usuario, contraseña, emailprincipal, TipoUsuario from [Persona] where guid_persona = @Guid";
        }

        private string SelectUsuario
        {
            get => "SELECT TOP (1) ([guid_persona], [TipoUsuario]) FROM [Persona] WHERE [Usuario] = @Usuario AND [Contraseña] = @Contraseña";
        }

        private string SelectCorreo
        {
            get => "SELECT TOP (1) ([guid_persona], [TipoUsuario]) FROM [Persona] WHERE [emailprincipal] = @Correo AND [Contraseña] = @Contraseña";
        }

        private string UpdateDVHStatement
        {
            get => "UPDATE Persona SET DVH = @DVH WHERE guid_persona = @Guid";
        }

        private string SelectUserDataByUsernameStatement
        {
            get => "select guid_persona, usuario, emailprincipal, habilitado, TipoUsuario, Rol.nombre_rol, Rol.permisos from persona JOIN Rol on Rol.id_rol = persona.id_rol WHERE usuario = @user AND contraseña = @pass";
        }

        private string SelectUserDataByMailStatement
        {
            get => "select guid_persona, usuario, emailprincipal, habilitado, TipoUsuario, Rol.nombre_rol, Rol.permisos from persona JOIN Rol on Rol.id_rol = persona.id_rol WHERE emailprincipal = @correo AND contraseña = @pass";
        }

        #endregion



        /// <summary>
        /// Obtiene datos personales del usuario a partir de su nombre de usuario y contraseña.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public Persona SelectUserDataByUsername(Persona P)
        {
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectUserDataByUsernameStatement, System.Data.CommandType.Text,
                                     new SqlParameter[] {
                                         new SqlParameter("@user", P.Usuario),
                                         new SqlParameter("@pass", P.Contraseña),
                                                          }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = PersonaAdapter.Current.AdaptUserData(values);
                }
                return person;
            }
        }


        /// <summary>
        /// Obtiene los datos personales de un usuario a partir de su direccion de correo eletronico y contraseña.
        /// aseña.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public Persona SelectUserDataByEmailAddress(Persona P)
        {
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectUserDataByMailStatement, System.Data.CommandType.Text,
                                     new SqlParameter[] {
                                         new SqlParameter("@correo", P.Usuario),
                                         new SqlParameter("@pass", P.Contraseña),
                                                          }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = PersonaAdapter.Current.AdaptUserData(values);
                }
                return person;
            }
        }

        /// <summary>
        /// Obtiene la contraseña almacenada utilizando el correo del usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Retorna un objeto que contiene los datos.</returns>
        public Persona GetPassCorreo(Persona c)
        {
            //TODO: Limpiar
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectPassCorreo, System.Data.CommandType.Text,
                                     new SqlParameter[] { 
                                         new SqlParameter("@Correo", c.Correo),
                                                          }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = new Persona() { Contraseña = values[0].ToString() };
                }

                return person;
            }

        }

        /// <summary>
        /// Obtiene la contraseña almacenada utilizando el nombre de usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Retorna un objeto que contiene los datos.</returns>
        public Persona GetPassUsuario(Persona c)
        {
            //TODO: Limpiar
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectPassUsuario, System.Data.CommandType.Text,
                                     new SqlParameter[] {
                                         new SqlParameter("@Usuario", c.Usuario),
                                                          }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = new Persona() { Contraseña = values[0].ToString() };
                }

                return person;
            }

        }

        /// <summary>
        /// Obtiene los datos del usuario utillizando su nombre de usuario.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Devuelve un objeto de tipo Persona hidratado.</returns>
        public Persona GetUserDataUsuario(Persona c)
        {
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectUsuario, System.Data.CommandType.Text,
                                     new SqlParameter[] {
                                         new SqlParameter("@Usuario", c.Correo),
                                            new SqlParameter("@Contraseña", c.Contraseña),
                                     }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = new Persona()
                    {
                        Guid = Guid.Parse(values[0].ToString()),
                        TipoUsuario = (Persona.TipoPersona)values[1],
                    };
                }

                return person;
            }
        }

        /// <summary>
        /// Obtiene los datos del usuario utilizando su correo.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Devuelve un objeto de tipo Persona hidratado.</returns>
        public Persona GetUserDataCorreo(Persona c)
        {
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectCorreo, System.Data.CommandType.Text,
                                     new SqlParameter[] {
                                         new SqlParameter("@Correo", c.Correo),
                                            new SqlParameter("@Contraseña", c.Contraseña),
                                                          }))
            {
                Object[] values = new Object[dr.FieldCount];

                Persona person = default;

                while (dr.Read())
                {
                    dr.GetValues(values);
                    person = new Persona() 
                    { 
                        Guid = Guid.Parse(values[0].ToString()),
                        TipoUsuario = (Persona.TipoPersona)values[1],
                    };
                }

                return person;
            }
        }

        /// <summary>
        /// Devuelve un vector con todos los digitos verificadores.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Persona> SelectAllIntegrityData()
        {
            //c.Guid.ToString() + c.Usuario + hashpass.ToString() + c.Correo + c.TipoUsuario.ToString()
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return PersonaAdapter.Current.AdaptIntegrityData(values);
                }
            }
        }

        public Persona SelectIntegrityData(Guid g)
        {
            //c.Guid.ToString() + c.Usuario + hashpass.ToString() + c.Correo + c.TipoUsuario.ToString()
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, new SqlParameter[]{ new SqlParameter("@Guid", g) } ))
            {
                Object[] values = new Object[dr.FieldCount];

                var integdata = new Persona();
                while (dr.Read())
                {
                    dr.GetValues(values);
                    integdata = PersonaAdapter.Current.AdaptCorrectedIntegrityData(values);
                }

                return integdata;
            }
        }

        /// <summary>
        /// Actualiza el valor DVV de una Persona en la base de datos.
        /// </summary>
        public void UpdateDVH(Guid g, int dvh)
        {
            SqlHelper.ExecuteNonQuery(UpdateDVHStatement, System.Data.CommandType.Text, new SqlParameter[]
                {
                new SqlParameter("@Guid", g),
                new SqlParameter("@DVH", dvh)
                });
        }

    }
}
