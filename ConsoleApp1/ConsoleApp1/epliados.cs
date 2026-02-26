using System;

namespace SistemaEmpleados
{
    public abstract class Empleado
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }

        protected Empleado(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public abstract decimal CalcularSalario();

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
        }
    }
}


namespace SistemaEmpleados
{
    public class EmpleadoTiempoCompleto : Empleado
    {
        public decimal SalarioFijo { get; private set; }

        public EmpleadoTiempoCompleto(string id, string nombre, decimal salarioFijo)
            : base(id, nombre)
        {
            SalarioFijo = salarioFijo;
        }

        public override decimal CalcularSalario()
        {
            return SalarioFijo;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Tipo: Tiempo Completo");
            Console.WriteLine($"Salario: {CalcularSalario():C}");
        }
    }
}

namespace SistemaEmpleados
{
    public class EmpleadoPorHoras : Empleado
    {
        public int HorasTrabajadas { get; private set; }
        public decimal ValorPorHora { get; private set; }

        public EmpleadoPorHoras(string id, string nombre, int horasTrabajadas, decimal valorPorHora)
            : base(id, nombre)
        {
            HorasTrabajadas = horasTrabajadas;
            ValorPorHora = valorPorHora;
        }

        public override decimal CalcularSalario()
        {
            return HorasTrabajadas * ValorPorHora;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Tipo: Por Horas");
            Console.WriteLine($"Salario: {CalcularSalario():C}");
        }
    }
}


namespace SistemaEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>
            {
                new EmpleadoTiempoCompleto("1", "Ana", 3000000),
                new EmpleadoPorHoras("2", "Luis", 160, 20000),
                new EmpleadoTiempoCompleto("3", "Carlos", 3500000),
                new EmpleadoPorHoras("4", "Marta", 120, 18000)
            };

            Console.WriteLine("=== LISTA DE EMPLEADOS ===\n");

            foreach (Empleado emp in empleados)
            {
                emp.MostrarInformacion();
                Console.WriteLine("---------------------------");
            }

            Console.ReadKey();
        }
    }
}
