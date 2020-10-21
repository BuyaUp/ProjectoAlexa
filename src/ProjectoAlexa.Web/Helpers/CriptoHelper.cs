using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.Helpers
{
    public static class CriptoHelper
    {
        //Criptografar/Codificar a senha
        public static string Encrypt(this string senha)
        {
            var salt = "|8E9895B4F52C45DABA449954EB993BDA6E15927D37F94699AF461858B0753EBE";

            var arrayBytes = Encoding.UTF8.GetBytes(senha + salt); //transformar a senha num vetor de Bytes unindo ao salto

            byte[] hashBytes; //outro vetor para crypt...

            //Criptografia final 
            using (var sha = SHA512.Create()) //formato da criptografia
            {
                hashBytes = sha.ComputeHash(arrayBytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}
