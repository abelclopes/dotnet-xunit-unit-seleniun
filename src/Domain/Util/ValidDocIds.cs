using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Util
{
    public static class ValidDocIds
    {


        public static bool ValidCpf(string vrCPF)
        {
            var valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");
            if (valor.Length != 11) return false;

            bool isEqual = true;
            for (int i = 1; i < 11 && isEqual; i++)
                if (valor[i] != valor[0])
                    isEqual = false;
            if (isEqual || valor == "12345678909")
                return false;
            var numbers = new int[11];
            for (int i = 0; i < 11; i++)
                numbers[i] = int.Parse(valor[i].ToString());
            var soma = 0;                                   
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numbers[i];
            var result = soma % 11;
            if (result == 1 || result == 0)
            {
                if (numbers[9] != 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numbers[i];
            result = soma % 11;
            if (result == 1 || result == 0)
            {                                    
                if (numbers[10] != 0)
                    return false;
            }
            else if (numbers[10] != 11 - result)
                return false;
            return true;
        }
    }
}
