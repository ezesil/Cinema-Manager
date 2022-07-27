using BaseServices.DAL.Factory;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class RolePermissionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Services.Logger _logger = ServiceContainer.Get<Services.Logger>();

        private readonly IRolPermisoRepository _repo = FactoryDAL.RolPermisoRepository;

        #region Singleton
        private readonly static RolePermissionBLL _instance = new RolePermissionBLL();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static RolePermissionBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private RolePermissionBLL()
        {

        }
        #endregion

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<RolPermisoRelation> ObtenerListaDeRelaciones()
        {
            return _repo.GetAll().ToList();
        }

        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarRolPermisoRelation(RolPermisoRelation R)
        {
            _repo.Update(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        public RolPermisoRelation ObtenerRolPermisoRelation(int id)
        {
            return _repo.GetOne(id);
        }

        /// <summary>
        /// Permite crear un rol del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearRolPermisoRelation(RolPermisoRelation R)
        {
            _repo.Insert(R);
        }

        /// <summary>
        /// Permite eliminar un rol del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarRolPermisoRelation(RolPermisoRelation R)
        {
            _repo.Delete(R);
        }
    }
}
