using BaseServices.DAL.Factory;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    internal class RoleBLL
    {
        ExceptionHandler _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
        Services.Logger _logger = ServiceContainer.Instance.GetService<Services.Logger>();
        SessionService _sessionService = ServiceContainer.Instance.GetService<SessionService>();

        private readonly IGenericRepository<Rol, int> _rolrepo = FactoryDAL.RolRepository;

        #region Singleton
        private readonly static RoleBLL _instance = new RoleBLL();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static RoleBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private RoleBLL()
        {

        }
        #endregion
        
        /// <summary>
        /// TODO: Implementar.
        /// </summary>
        /// <returns></returns>
        public List<Rol> ObtenerListaDeRoles()
        {
            return _rolrepo.GetAll().ToList();
        }

        /// <summary>
        /// Permite modificar el registro de un Rol.
        /// </summary>
        public void ModificarRol(Rol R)
        {
            _rolrepo.Update(R);
        }

        // select all, select one, insert, delete, update
        /// <summary>
        /// Obtiene la informacion de un rol a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        public Rol ObtenerRol(int id)
        {
            return _rolrepo.GetOne(id);
        }

        /// <summary>
        /// Permite crear un rol del sistema.
        /// </summary>
        /// <param name="R"></param>
        public void CrearRol(Rol R)
        {
            _rolrepo.Insert(R);
        }

        /// <summary>
        /// Permite eliminar un rol del sistema.
        /// </summary>
        /// <param name="id"></param>
        public void EliminarRol(int id)
        {
            _rolrepo.Delete(id);
        }
    }
}
