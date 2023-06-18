using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data;

namespace Presentacion.CLS
{
    public class Validaciones
    {        
        /// <summary>
        /// Garantizar que en un objeto (TextBox, etc.) capture solo datos numericos enteros
        /// </summary>
        /// <param name="sender">Objeto que llama al metodo</param>
        /// <param name="e">Evento que desencadena el metodo</param>
        /// <returns></returns>
        public static bool soloDigitos(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

            return e.Handled;
        }
        public static bool soloDecimal(object sender, KeyPressEventArgs e, String Texto)
        {
            string SeparadorDecimal = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(SeparadorDecimal) && Texto.IndexOf(Convert.ToChar(SeparadorDecimal)) != -1)
                e.Handled = true;
            else if (e.KeyChar == Convert.ToChar(SeparadorDecimal))
                e.Handled = false;
            else
                e.Handled = true;

            return e.Handled;
        }
        
        public static bool validaConsecutivos(TextBox cajadeTexto)
        {
            Boolean resultado = false;
            try
            {
                int num, numSiguiente, contador = 1;
                for (int i = 0; i < cajadeTexto.TextLength; i++)
                {
                    num = int.Parse(cajadeTexto.Text.Substring( i, 1));
                    if (i + 1 < cajadeTexto.TextLength)
                    {

                        numSiguiente = int.Parse(cajadeTexto.Text.Substring(i + 1, 1));
                        if (numSiguiente == num + 1)
                        {
                            contador++;
                        }
                    }
                }
                if (contador == (cajadeTexto.TextLength))
                    resultado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }

        public static bool validaInversos(TextBox cajadeTexto)
        {
            Boolean resultado = false;
            int num, numSiguiente, contador = 1;
            try
            {
                for (int i = 0; i < cajadeTexto.TextLength; i++)
                {                   
                    num = int.Parse(cajadeTexto.Text.Substring( i, 1));
                    if (i + 1 < cajadeTexto.TextLength)
                    {

                        numSiguiente = int.Parse(cajadeTexto.Text.Substring( i + 1, 1));
                        if (num == numSiguiente + 1)
                        {
                            contador++;
                        }
                    }
                }
                if (contador == (cajadeTexto.TextLength))
                    resultado = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultado;
        }
        
        public static bool CheckIgualValues(string value1, string value2)
        {
            if (value1.Trim() == value2.Trim())
                return true;
            else
                return false;
        }
        public static bool CheckIgualValues(int value1, int value2)
        {
            if (value1 == value2)
                return true;
            else
                return false;
        }
        
    }
}
