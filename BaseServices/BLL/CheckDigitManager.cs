using BaseServices.DAL.Factory;
using BaseServices.Domain.Login;
using BaseServices.Domain.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    /// <summary>
    /// Gestiona los procesos de generacion de digito verificador.
    /// </summary>
    internal class CheckDigitManager
    {
        private static List<Persona> PersonasConFallos = new List<Persona>();

        #region Singleton
        private readonly static CheckDigitManager _instance = new CheckDigitManager();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static CheckDigitManager Current
        {
            get
            {
                return _instance;
            }
        }

        private CheckDigitManager()
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
        public bool CheckAccountsIntegrity(List<Persona> personas)
        {
            List<decimal> numeros = new List<decimal>();

            foreach (var c in personas)
            {
                numeros.Add(Convert.ToDecimal(c.DVH));
                if (Convert.ToInt32(c.DVH) != Convert.ToInt32(CalculateDVH(c.Guid.ToString() + c.Usuario + c.Contraseña + c.Correo + c.TipoUsuario.ToString())))
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
                foreach(Persona p in PersonasConFallos)
                {                                                      
                    Services.Security.LogServices.LogService.LogEvent(new Domain.Log("Error de chequeo de integridad en el usuario: " + p.Usuario, Log.Severity.Critical));
                }

                return false;
            }

        }

        /// <summary>
        /// Chequea la integridad de la entidad Persona.
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        private bool CheckPersonaIntegrity(List<Persona> personas)
        {
            List<decimal> L = new List<decimal>();
            int DVV = FactoryDAL.DVVRepository.SelectOne(100);

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
                Services.Security.LogServices.LogService.LogEvent(new Domain.Log("Error de chequeo de integridad en la cuentas: Faltan datos.", Log.Severity.Critical));
                return false;
            }

        }

        /// <summary>
        /// Chequea la integridad de los datos de inicio de sesion.
        /// </summary>
        /// <returns>Retorna un valor booleano.</returns>
        public bool CheckIntegrity()
        {
            var listapersonas = FactoryDAL.PersonaRepository.SelectAllIntegrityData().ToList();

            if (CheckAccountsIntegrity(listapersonas) == true && CheckPersonaIntegrity(listapersonas) == true)
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

            foreach (var c in FactoryDAL.PersonaRepository.SelectAllIntegrityData().ToList())
            {
                numeros.Add(Convert.ToDecimal(c.DVH));
            }
              
            FactoryDAL.DVVRepository.Update(id, Convert.ToInt32(CalculateDVV(numeros)));
        }

        /// <summary>
        /// Actualiza el valor DVH utilizando el Guid de un usuario.
        /// </summary>
        /// <param name="c"></param>
        public void UpdateDVH(Persona c)
        {
            c = FactoryDAL.PersonaRepository.SelectIntegrityData(c.Guid);
            FactoryDAL.PersonaRepository.UpdateDVH(c.Guid, Convert.ToInt32(CalculateDVH(c.Guid.ToString() + c.Usuario + c.Contraseña + c.Correo + c.TipoUsuario.ToString())));

            UpdateDVV(100);
        }

    }
}
