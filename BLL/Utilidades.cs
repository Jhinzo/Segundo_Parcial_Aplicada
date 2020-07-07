using System;
using System.Collections.Generic;
using System.Text;

namespace Segundo_Parcial_Aplicada.BLL
{
 
    public class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno;
            int.TryParse(valor, out retorno);
            return retorno;
        }
        public static decimal ToDecimal(string valor)
        {
            decimal retorno;
            decimal.TryParse(valor, out retorno);
            return retorno;
        }
    }
}