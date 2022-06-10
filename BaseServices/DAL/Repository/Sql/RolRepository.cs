using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql.Adapter;
using BaseServices.DAL.Tools;
using BaseServices.Domain.Control_de_acceso;
using BaseServices.Domain.Exceptions;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql
{
    internal class RolRepository : IPermissionRepository<Rol>
    {


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Rol] (id_rol, permisos, nombre_rol) VALUES (@id_rol, @permisos, @nombre_rol)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Rol] SET permisos = @permisos, nombre_rol = @nombre_rol WHERE id_rol = @id_rol";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Rol] WHERE id_rol = @id_rol";
        }

        private string SelectOneStatement
        {
            get => "SELECT id_rol, permisos, nombre_rol FROM [dbo].[Rol] WHERE id_rol = @id_rol";
        }

        private string SelectAllStatement
        {
            get => "SELECT id_rol, nombre_rol, permisos FROM [dbo].[Rol]";
        }
        #endregion

        ExceptionHandlerService _exhandler = InstanceManager.Get<ExceptionHandlerService>();
        LogService _logger = InstanceManager.Get<LogService>();

        public void Insert(Rol c)
        {

            try
            {
                SqlHelper.SetSqlMode();
                SqlHelper.ExecuteNonQuery(InsertStatement, CommandType.Text, new SqlParameter[]
                {
                        new SqlParameter("@id_rol", c.IdRol),
                        new SqlParameter("@permisos", c.PermisosString),
                        new SqlParameter("@nombre_rol", c.NombreRol)
                });


            }
            catch (Exception ex)
            {
                _exhandler.Handle(ex);
            }
            
        }


        public IEnumerable<Rol> SelectAll()
        {
            SqlHelper.SetSqlMode();
            using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
            {
                Object[] values = new Object[dr.FieldCount];

                while (dr.Read())
                {
                    dr.GetValues(values);
                    yield return RolAdapter.Current.Adapt(values);
                }
            }

        }


        public Rol SelectOne(int id)
        {
            try
            {
                SqlHelper.SetSqlMode();
                using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                        new SqlParameter[] { new SqlParameter("@id_rol", id) }))
                {
                    Object[] values = new Object[dr.FieldCount];

                    Rol item = null;

                    while (dr.Read())
                    {
                        dr.GetValues(values);
                        item = RolAdapter.Current.Adapt(values);
                    }

                    return item;
                }

            }

            catch (Exception sqlError)
            {
                _exhandler.Handle(sqlError);
                return null;
            }
        }

       

        public void Update(Rol o)
        {
            try
            {
                SqlHelper.SetSqlMode();
                SqlHelper.ExecuteNonQuery(UpdateStatement, CommandType.Text, new SqlParameter[]
                {
                        new SqlParameter("@permisos", o.PermisosString ),
                        new SqlParameter("@nombre_rol", o.NombreRol ),
                        new SqlParameter("@id_rol", o.IdRol ),
                });

            }


            catch (Exception ex)
            {
                _exhandler.Handle(ex);
            }

        }

        public void Delete(int obj)
        {
            try
            {
                SqlHelper.SetSqlMode();
                SqlHelper.ExecuteNonQuery(DeleteStatement, CommandType.Text, new SqlParameter[]
                {   
                        new SqlParameter("@id_rol", obj),
                });
            }
            catch (Exception ex)
            {
                _exhandler.Handle(ex);
            }
        }















    }
}
