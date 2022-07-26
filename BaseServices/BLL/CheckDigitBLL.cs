using BaseServices.DAL.Factory;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;
using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    /// <summary>
    /// Gestiona los procesos de generacion de digito verificador.
    /// </summary>
    internal class CheckDigitBLL
    {
        readonly int USERS_ENTITY_ID = 100;

        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        Services.Logger _logger = ServiceContainer.Get<Services.Logger>();

        IUserRepository _userrepo = FactoryDAL.UserRepository;
        IGenericDVVRepository _dvvrepo = FactoryDAL.DVVRepository;

        private List<User> PersonasConFallos = new List<User>();

        #region Singleton
        private static CheckDigitBLL _instance = new CheckDigitBLL();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static CheckDigitBLL Current
        {
            get
            {
                if(_instance == null)
                    _instance = new CheckDigitBLL();

                return _instance;
            }
        }

        private CheckDigitBLL()
        {

        }
        #endregion

        /// <summary>
        /// Calcula el valor de digito verificador para la cadena especificada.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>Devuelve un objeto de tipo decimal.</returns>
        public decimal CalculateDVH(string cadena)
        {
            UnicodeEncoding u = new UnicodeEncoding();
               
            byte[] bytes = u.GetBytes(cadena);

            var hash = SHA512CryptoServiceProvider.Create();
            var valorhash = hash.ComputeHash(bytes);
            decimal valor = valorhash.Sum(o => o);

            return valor;
        }

        /// <summary>
        /// Calcula la integridad a nivel de entidad.
        /// </summary>
        /// <param name="numeros"></param>
        /// <returns>Retorna un objeto de tipo Decimal.</returns>
        public decimal CalculateDVV(List<decimal> numeros)
        {
            decimal DVV = new decimal();

            foreach(var item in numeros)
            {
                DVV += item;
            }

            return DVV;
        }

        /// <summary>
        /// Chequea la integridad de los datos de las cuentas almacenadas.
        /// </summary>
        /// <returns>Retorna un valor booleano. Si es True, pasó el chequeo de integridad. Si es False, hay registros modificados y deben revisarse.</returns>
        public bool CheckAccountsIntegrity(List<User> personas)
        {
            List<decimal> numeros = new List<decimal>();

            foreach (var c in personas)
            {
                numeros.Add(Convert.ToDecimal(c.DVH));
                if (Convert.ToInt32(c.DVH) != Convert.ToInt32(CalcularDVH(c)))
                {
                    PersonasConFallos.Add(c);
                }
            }

            if(PersonasConFallos.Count < 1)
            {
                return true;
            }

            else
            {
                foreach(User p in PersonasConFallos)
                {                                                      
                    _logger.Log("Error de chequeo de integridad en el usuario: " + p.Username, Log.Severity.Critical);
                }

                return false;
            }

        }

        /// <summary>
        /// Chequea la integridad de la entidad Persona.
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        private bool CheckUsersIntegrity(List<User> personas)
        {
            List<decimal> L = new List<decimal>();
            int DVV = _dvvrepo.SelectOne(USERS_ENTITY_ID);

            foreach (var persona in personas)
            {
                L.Add(persona.DVH);
            }
            
            if(DVV == CalculateDVV(L))
            {
                return true;
            }

            else
            {
                _logger.Log("Error de chequeo de integridad en la cuentas: Faltan datos.", Log.Severity.Fatal);
                return false;
            }

        }

        /// <summary>
        /// Chequea la integridad de los datos de inicio de sesion.
        /// </summary>
        /// <returns>Retorna un valor booleano.</returns>
        public bool CheckIntegrity()
        {
            var listapersonas = (_userrepo as IGenericRepository<User, Guid>).GetAll().ToList();

            if (CheckAccountsIntegrity(listapersonas) == true && CheckUsersIntegrity(listapersonas) == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Actualiza el DVV de una entidad. Debe usarse despues de ingresar cambios a una cuenta de usuario.
        /// </summary>
        /// <param name="id"></param>
        public void UpdateDVV(int id)
        {
            List<decimal> numeros = new List<decimal>();

            foreach (var c in (_userrepo as IGenericRepository<User, Guid>).GetAll().ToList())
            {
                numeros.Add(Convert.ToDecimal(c.DVH));
            }

            FactoryDAL.DVVRepository.Update(id, Convert.ToInt32(CalculateDVV(numeros)));
        }

        /// <summary>
        /// Actualiza el valor DVH utilizando el Guid de un usuario.
        /// </summary>
        /// <param name="c"></param>
        public void UpdateDVH(Guid Id)
        {
            var user = (_userrepo as IGenericRepository<User, Guid>).GetOne(Id);

            _userrepo.UpdateDVH(Id, Convert.ToInt32(CalcularDVH(user)));

            UpdateDVV(USERS_ENTITY_ID);
        }

        /// <summary>
        /// Calcula el digito verficador horizontal para el objecto especificado.
        /// </summary>
        /// <param name="obj"></param>
        public decimal CalcularDVH(object obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo prop in props)
            {
                if(prop.Name.ToLower() != "dvh" || prop.Name.ToLower().Contains("dvh"))
                    sb.Append($"{ prop.Name }:{ prop.GetValue(obj) }\n");
            }

            return CalculateDVH(sb.ToString());
        }
    }
}
