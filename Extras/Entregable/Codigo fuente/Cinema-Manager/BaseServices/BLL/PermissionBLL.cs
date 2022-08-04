using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Factory;
using BaseServices.Services;
using BaseServices.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace BaseServices.BLL
{
    /// <summary>
    /// Provee herramientas para la gestion de permisos de formulario.
    /// </summary>
    internal class PermissionBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
        Services.Logger _logger = ServiceContainer.Instance.GetService<Services.Logger>();
        SessionService _sessionService = ServiceContainer.Instance.GetService<SessionService>();

        private readonly IGenericRepository<Permiso, int> _permrepo = FactoryDAL.PermisoRepository;

        #region Singleton
        private readonly static PermissionBLL _instance = new PermissionBLL();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static PermissionBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private PermissionBLL()
        {
            
        }
        #endregion

        /// <summary>
        /// Verificar si el usuario actual tiene el permiso especificado.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool HasRight(Permission P)
        {
            if (_sessionService.CurrentUser == "admin")
                return true;

            if (SessionBLL.Current.UserIsNull)
            {
                return false;
            }

            foreach (Permiso permiso in SessionBLL.Current.CurrentUserPermissions)
            {
                if (P == permiso.PermissionType)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si el usuario actual contiene el listado de permisos especificado.
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool HasRights(List<Permiso> P)
        {
            if (SessionBLL.Current.CurrentUserPermissions == null)
            {
                return false;
            }

            int counter = 0;

            foreach (Permiso permiso in SessionBLL.Current.CurrentUserPermissions)
            {
                foreach (Permiso permiso2 in P)
                    if (permiso.Codigo == permiso2.Codigo)
                    {
                        counter++;
                    }
            }

            if (counter == P.Count)
                return true;


            else
                return false;
        }


        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerListaDePermisos()
        {
            return _permrepo.GetAll().ToList();
        }

        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Permiso> ObtenerListaDePermisos(Rol r)
        {
            return _permrepo.GetAll(new { IdRol = r.Id }).ToList();
        }


        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarPermiso(Permiso R)
        {
            _permrepo.Update(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        public Permiso ObtenerPermiso(int id)
        {
            return _permrepo.GetOne(id);
        }

        /// <summary>
        /// Permite crear un rol del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearPermiso(Permiso R)
        {
            _permrepo.Insert(R);
        }

        /// <summary>
        /// Permite eliminar un rol del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarPermiso(int id)
        {
            _permrepo.Delete(id);
        }
    }    
}
