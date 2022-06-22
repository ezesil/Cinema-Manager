using BaseServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL
{
    /// <summary>
    /// Clase gestora de servicios de Hashing.
    /// </summary>
    internal class HashingManager
    {
        ExceptionHandler _exhandler = ServiceContainer.Get<ExceptionHandler>();
        LogService _logger = ServiceContainer.Get<LogService>();

        private readonly static HashingManager _instance = new HashingManager();

        /// <summary>
        /// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
        /// </summary>
        public static HashingManager Current
        {
            get
            {
                return _instance;
            }
        }
        
        private HashingManager()
        {

        }
        /// <summary>
        /// Largo de bytes de la sal.
        /// </summary>
        private const int SaltByteLength = 24;

        /// <summary>
        /// Largo de la clave derivada.
        /// </summary>
        private const int DerivedKeyLength = 24;


        /// <summary>
        /// Calcula el valor hash a partir de una contraseña de tipo string.
        /// Este metodo utiliza PBKDF2 y SHA512 para las iteraciones.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Retorna el valor hash, sal e iteraciones de la contraseña en su forma codificada.</returns>
        public string CreatePasswordHash(string password)
        {
            var salt = GenerateRandomSalt();
            var iterationCount = GetIterationCount();
            var hashValue = GenerateHashValue(password, salt, iterationCount);
            var iterationCountBtyeArr = BitConverter.GetBytes(iterationCount);
            var valueToSave = new byte[SaltByteLength + DerivedKeyLength + iterationCountBtyeArr.Length];
            Buffer.BlockCopy(salt, 0, valueToSave, 0, SaltByteLength);
            Buffer.BlockCopy(hashValue, 0, valueToSave, SaltByteLength, DerivedKeyLength);
            Buffer.BlockCopy(iterationCountBtyeArr, 0, valueToSave, salt.Length + hashValue.Length, iterationCountBtyeArr.Length);
            return Convert.ToBase64String(valueToSave);
        }


        /// <summary>
        /// Verifica si la contraseña ingresada y la almacenada son la misma. 
        /// </summary>
        /// <param name="passwordGuess">Contraseña en texto plano.</param>
        /// <param name="actualSavedHashResults">Contraseña almacenada.</param>
        /// <returns>Devuelve un valor booleano. True en caso de login exitoso, False en caso de login fallido.</returns>
        public static bool VerifyPassword(string passwordGuess, string actualSavedHashResults)
        {
            //ingredient #1: password salt byte array
            var salt = new byte[SaltByteLength];

            //ingredient #2: byte array of password
            var actualPasswordByteArr = new byte[DerivedKeyLength];

            //convert actualSavedHashResults to byte array
            var actualSavedHashResultsBtyeArr = Convert.FromBase64String(actualSavedHashResults);

            //ingredient #3: iteration count
            var iterationCountLength = actualSavedHashResultsBtyeArr.Length - (salt.Length + actualPasswordByteArr.Length);
            var iterationCountByteArr = new byte[iterationCountLength];
            Buffer.BlockCopy(actualSavedHashResultsBtyeArr, 0, salt, 0, SaltByteLength);
            Buffer.BlockCopy(actualSavedHashResultsBtyeArr, SaltByteLength, actualPasswordByteArr, 0, actualPasswordByteArr.Length);
            Buffer.BlockCopy(actualSavedHashResultsBtyeArr, (salt.Length + actualPasswordByteArr.Length), iterationCountByteArr, 0, iterationCountLength);
            var passwordGuessByteArr = GenerateHashValue(passwordGuess, salt, BitConverter.ToInt32(iterationCountByteArr, 0));
            return ConstantTimeComparison(passwordGuessByteArr, actualPasswordByteArr);
        }


        /// <summary>
        /// Calcula la diferencia entre las contraseñas usando un algoritmo de tiempo constante.
        /// </summary>
        /// <param name="passwordGuess"></param>
        /// <param name="actualPassword"></param>
        /// <returns></returns>
        private static bool ConstantTimeComparison(byte[] passwordGuess, byte[] actualPassword)
        {
            uint difference = (uint)passwordGuess.Length ^ (uint)actualPassword.Length;
            for (var i = 0; i < passwordGuess.Length && i < actualPassword.Length; i++)
            {
                difference |= (uint)(passwordGuess[i] ^ actualPassword[i]);
            }

            return difference == 0;
        }

        /// <summary>
        /// Iteraciones para el hashing de contraseñas.
        /// </summary>
        /// <returns>Devuelve un entero.</returns>
        private int GetIterationCount()
        {
            return 30000;
        }

        /// <summary>
        /// Genera una cadena de sal al azar.
        /// </summary>
        /// <returns>Retorna una cadena de bytes.</returns>
        private static byte[] GenerateRandomSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltByteLength];
            csprng.GetBytes(salt);
            return salt;
        }


        /// <summary>
        /// Genera valor hash de la contraseña, sumado a la sal y la cantidad de iteraciones.
        /// Nota: El metodo de hashing es PBKDF2.
        /// </summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <param name="salt">Sal, cadena de bytes.</param>
        /// <param name="iterationCount">Cantidad de tieraciones.</param>
        /// <returns>Retorna el hash value de la contraseña.</returns>
        private static byte[] GenerateHashValue(string password, byte[] salt, int iterationCount)
        {
            

            byte[] hashValue;
            var valueToHash = string.IsNullOrEmpty(password) ? string.Empty : password;
            using (var pbkdf2 = new Rfc2898DeriveBytes(valueToHash, salt, iterationCount, HashAlgorithmName.SHA512))
            {
                
                hashValue = pbkdf2.GetBytes(DerivedKeyLength);
            }

            return hashValue;
        }
    }
}
