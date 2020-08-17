using System;
using System.Text;
using CsQuery.StringScanner;
using NUnit.Framework;

namespace EmpleadoActividad
{
    class Empleado
    {
        //Declaramos las propiedades
        public int noTrabajador, horasExtra, hijos;
        public double sueldoBase, pagoExtra, tipoIRFP;
        public string nombreCompleto, cargoEmpresa;
        public char casado;

        //constructores
        public Empleado()
        {

        }

        public Empleado(int noTrabajador)
        {
            this.noTrabajador = noTrabajador;
        }

        //Métodos
        public int getHorasExtra()
        {
            return horasExtra;
        }

        public void setHorasExtra(int horasExtra)
        {
            this.horasExtra = horasExtra;
        }

        public int getHijos()
        {
            return hijos;
        }

        public void setHijos(int hijos)
        {
            this.hijos = hijos;
        }

        public double getSueldoBase()
        {
            return sueldoBase;
        }

        public void setSueldoBase(double sueldoBase)
        {
            this.sueldoBase = sueldoBase;
        }
        public double getPagoExtra()
        {
            return pagoExtra;
        }

        public void setPagoExtra(double pagoExtra)
        {
            this.pagoExtra = pagoExtra;
        }
        public double getTipoIRFP()
        {
            return tipoIRFP;
        }

        public void setTipoIRFP(double tipoIRFP)
        {
            this.tipoIRFP = tipoIRFP;
        }

        public String getNombre()
        {
            return nombreCompleto;
        }
        public void setNombre(String nombreCompleto)
        {
            this.nombreCompleto = nombreCompleto;
        }
        public String getCargoEmpresa()
        {
            return cargoEmpresa;
        }
        public void setCargoEmpresa(String cargoEmpresa)
        {
            this.cargoEmpresa = cargoEmpresa;
        }
        public char getCasado()
        {
            return casado;
        }
        public void setCasado(char casado)
        {
            this.casado = casado;
        }

        //Se calculan las horas extras
        public double calcularHorasExtra()
        {
            return sueldoBase ;
        }

        //Calculamos el sueldo
        public double calcularSueldo()
        {
            return sueldoBase;
        }

        //Calcular IRPF
        public double CalcularIRFP()
        {
            double tipo = tipoIRFP;
            if (sueldoBase <= 7500)
            {
                tipo = tipo * .08;
            }else if(sueldoBase > 7500 || sueldoBase <= 32000)
            {
                tipo = tipo * .13;
            }
            else
            {
                tipo = tipo * .2;
            }
            return calcularSueldo() * tipo / 100;
        }

        public double CalcularIRPFCasado()
        {
            double tipoC = tipoIRFP;
            if (casado == 's' || casado == 'S')
            {
                tipoC = tipoC - 2;
            }
            tipoC = tipoC - hijos;
            if(tipoC<0)
            {
                tipoC = 0;
            }
            return calcularSueldo() * tipoC / 100;
        }

        //Calculamos el sueldo
        public double calcularSueldoFin()
        {
            return calcularSueldo() - CalcularIRFP();
        }

        //Mostraremos los datos
        public String toString()
        {
            StringBuilder StringB = new StringBuilder();
            StringB.Append("Numero de trabajador: ");
            StringB.Append(noTrabajador);

            StringB.Append("Sueldo Base: ");
            StringB.Append(sueldoBase);

            StringB.Append("Horas Extra: ");
            StringB.Append(horasExtra);

            StringB.Append("IRFP : ");
            StringB.Append(tipoIRFP);

            StringB.Append("Casado : ");
            StringB.Append(casado);

            StringB.Append("Hijos cantidad : ");
            StringB.Append(hijos);

            return StringB.ToString();
        }

        public class EmpleadosImp
        {
                   
            //Metodo para guardar todos los empleados
        public static void Main(string[] args)
        {
                string nombre;
                int noEmpleado, horasExtra, sueldoBase, noHijos;
                double costoHora;
                char casado;

                Console.WriteLine("Ingrese nombre: ");
                nombre = Console.ReadLine();
                
                Console.WriteLine("Ingrese su número de empleado: ");
                noEmpleado = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Horas extra realizadas : ");
                horasExtra = int.Parse(Console.ReadLine());

                Console.WriteLine("Costo por hora extra : ");
                costoHora = double.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese sueldo base : ");
                sueldoBase = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Casado : S/N");
                casado = char.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese numero de hijos : ");
                noHijos = int.Parse(Console.ReadLine());

                Empleado objeto = new Empleado(noEmpleado);

                objeto.setNombre(nombre);
                objeto.setSueldoBase(sueldoBase);
                objeto.setHorasExtra(horasExtra);
                objeto.setCasado(Char.ToUpper(casado));
                objeto.setHijos(noHijos);

                Console.WriteLine("Nombre del empleado : " + nombre);
                Console.WriteLine("Horas extra realizadas : " + horasExtra);
                Console.WriteLine("Sueldo base : " + sueldoBase);
                Console.WriteLine("Casado : " + casado);
                Console.WriteLine("Hijos : " + noHijos);

                Console.WriteLine("IFRP : " + objeto.CalcularIRPFCasado()+objeto.CalcularIRFP());
                Console.WriteLine("Sueldo horas extra : " + (objeto.calcularHorasExtra()));
                Console.WriteLine("Sueldo Bruto : " + (objeto.calcularSueldoFin()*costoHora));

            }
        }
    }
}
