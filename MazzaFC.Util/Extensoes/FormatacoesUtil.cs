using System;
using System.Collections.Generic;
using System.Text;


public static class FormatacoesUtil
{
    /// <summary>
    /// Formata o CPF no formato 000.000.000-00
    /// </summary>
    /// <param name="value">String que deve ser formatada</param>
    /// <returns>CPF formatado</returns>
    public static string FormatarCPF(this string value)
    {
        value = string.Format("{0}", value);
        if (String.IsNullOrEmpty(value))
        {
            value = "0";
        }
        value = value.Trim();
        value = value.Replace(".", "").Replace("-", "").Replace("/", "");

        return Convert.ToUInt64(value).ToString(@"000\.000\.000\-00");
    }
}

