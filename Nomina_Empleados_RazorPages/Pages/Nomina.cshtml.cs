using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Nomina_Empleados_RazorPages.Pages
{
    public class NominaModel : PageModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public double SalarioBruto { get; set; }
        public double DescuentoAFP { get; set; }
        public double DescuentoARS { get; set; }
        public double DescuentoISR { get; set; }
        public double SalarioNeto { get; set; }

        

        public double AFP()
        {
            DescuentoAFP = SalarioBruto * 0.0287;

            if (DescuentoAFP <= 7738.67)
            {
                return DescuentoAFP;
            }

            else
            {
                DescuentoAFP = 7738.67;
            }

            return DescuentoAFP;
        }
        public double SFS()
        {
            DescuentoARS = SalarioBruto * 0.0304;
            if (DescuentoARS <= 4098.53)
            {
                DescuentoARS = SalarioBruto * 0.0304;
            }
            else
            {
                DescuentoARS = 4098.53;
            }

            return DescuentoARS;
        }
        
        public double ISR()
        {

            var Salario = SalarioBruto - (DescuentoARS + DescuentoAFP);
            if (Salario * 12 <= 416220.00)
            {
                DescuentoISR = 00.00;
                SalarioNeto = Salario - DescuentoISR;
                return DescuentoISR;
            }
            else if (Salario * 12 > 416220.01 && Salario * 12 < 624329.00)
            {
                DescuentoISR = (Salario * 12 * 0.015)/12;
                SalarioNeto = Salario - DescuentoISR;
                return DescuentoISR;
            }
            else if (Salario * 12 > 624329.01 && Salario * 12 < 867123.00)
            {
                DescuentoISR = (Salario * 12 * 0.020)/12;
                SalarioNeto = Salario - DescuentoISR;
                return DescuentoISR;
            }
            else if((Salario * 12) > 867123.01)
            {
                DescuentoISR = (Salario * 12 * 0.25)/12;
                SalarioNeto = Salario - DescuentoISR;
                return DescuentoISR;
            }


            return DescuentoISR;
            // DescuentoISR;
        }
        public void OnGet()
        {

        }
    }
}
