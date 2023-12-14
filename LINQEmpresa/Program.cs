using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQEmpresa
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Empresa> empresas = new List<Empresa>
        {
            new Empresa { Id = 1, Nombre = "InnovateTech Solutions" },
            new Empresa { Id = 2, Nombre = "Digital Innovations Ltd." }
        };

            List<Empleado> empleados = new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan Pérez", Cargo = "CEO", Salario = 55000, EmpresaId = 1 },
            new Empleado { Id = 2, Nombre = "María Rodríguez", Cargo = "Analista", Salario = 60000, EmpresaId = 1 },
            new Empleado { Id = 3, Nombre = "Carlos Ramírez", Cargo = "Ingeniero", Salario = 70000, EmpresaId = 1 },
            new Empleado { Id = 4, Nombre = "Laura Gómez", Cargo = "Gerente", Salario = 80000, EmpresaId = 1 },
            new Empleado { Id = 5, Nombre = "Alejandro Castro", Cargo = "CEO", Salario = 60000, EmpresaId = 2 },
            new Empleado { Id = 6, Nombre = "Gabriela Navarro", Cargo = "Analista", Salario = 65000, EmpresaId = 2 },
            new Empleado { Id = 7, Nombre = "José Mendoza", Cargo = "Ingeniero", Salario = 72000, EmpresaId = 2 },
            new Empleado { Id = 8, Nombre = "Sofía Vargas", Cargo = "Gerente", Salario = 85000, EmpresaId = 2 },
            new Empleado { Id = 9, Nombre = "Daniel Herrera", Cargo = "Desarrollador", Salario = 62000, EmpresaId = 1 },
            new Empleado { Id = 10, Nombre = "Paola Méndez", Cargo = "Analista", Salario = 67000, EmpresaId = 1 },
            new Empleado { Id = 11, Nombre = "Javier Delgado", Cargo = "Ingeniero", Salario = 73000, EmpresaId = 1 },
            new Empleado { Id = 12, Nombre = "Isabel Torres", Cargo = "Gerente", Salario = 88000, EmpresaId = 1 },
            new Empleado { Id = 13, Nombre = "Martín Sánchez", Cargo = "Desarrollador", Salario = 61000, EmpresaId = 2 },
            new Empleado { Id = 14, Nombre = "Fernanda Rojas", Cargo = "Analista", Salario = 68000, EmpresaId = 2 },
            new Empleado { Id = 15, Nombre = "Roberto Varela", Cargo = "Ingeniero", Salario = 74000, EmpresaId = 2 },
            new Empleado { Id = 16, Nombre = "Carmen López", Cargo = "Gerente", Salario = 90000, EmpresaId = 2 },
            new Empleado { Id = 17, Nombre = "Hugo Medina", Cargo = "Desarrollador", Salario = 63000, EmpresaId = 1 },
            new Empleado { Id = 18, Nombre = "Luisa Soto", Cargo = "Analista", Salario = 69000, EmpresaId = 1 },
            new Empleado { Id = 19, Nombre = "Miguel González", Cargo = "Ingeniero", Salario = 76000, EmpresaId = 1 },
            new Empleado { Id = 20, Nombre = "Ana Beltrán", Cargo = "Gerente", Salario = 92000, EmpresaId = 1 }
        };

            //empleados cullo cargo sea CEO

            var res = from empleado in empleados
                      where empleado.Cargo == "CEO"
                      select empleado;

            foreach (var empleado in res)
            {
                Console.WriteLine(empleado.Nombre);
            }


            //salarios de mas de 20.000

            var salariosMasDeVeintemil = from empleado in empleados
                      where empleado.Salario >= 75000
                      select empleado;

            foreach (var empleado in salariosMasDeVeintemil)
            {
                Console.WriteLine(empleado.Nombre + " Salario: " + empleado.Salario );
            }



            // empleados ordenados alfabeticamente a la inversa
            var empleadosPorOrdenAlfabetico = from empleado in empleados
                                              orderby empleado.Nombre descending
                                              select empleado;


            foreach (var empleado in empleadosPorOrdenAlfabetico)
            {
                Console.WriteLine(empleado.Nombre);
            }



            //empleados que pertenezcan a InnovateTech Solutions


            var empleadosInnovateTech = from empleado in empleados
                                        join empresa in empresas on empleado.EmpresaId equals empresa.Id
                                        where empresa.Nombre == "InnovateTech Solutions"
                                        select empleado;


            foreach (var empleado in empleadosInnovateTech)
            {
                empleado.printDatosEmpleado();
            }


            //media de los salarios de todos los empleados en cada empresa, el salario maximo y el salario minimo

            var mediaSalarios = from empleado in empleados
                                join empresa in empresas on empleado.EmpresaId equals empresa.Id
                                group empleado by new { empleado.EmpresaId, empresa.Nombre } into grupo
                                select new
                                {
                                    EmpresaId = grupo.Key.EmpresaId,
                                    NombreEmpresa = grupo.Key.Nombre,
                                    SalarioMedio = grupo.Average(e => e.Salario),
                                    SalarioMaximo = grupo.Max(e => e.Salario),
                                    SalarioMinimo = grupo.Min(e => e.Salario),
                                };

            foreach (var empleado in mediaSalarios)
            {
                Console.WriteLine("{0},{1},"+empleado.EmpresaId);
            }


        }
    }





    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void printDatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con Id {1}", Nombre, Id);
        }

    }


    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }

        public double Salario { get; set; }

        public int EmpresaId { get; set; }


        public void printDatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con Id {1}, cargo {2}, con salario {3} y perteneciente a la empresa {4}", Nombre, Id, Cargo, Salario, EmpresaId);
        }

    }
}
