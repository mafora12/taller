using System;
using System.Collections.Generic; 

namespace SistemaEmpleados
{
    public interface IBonificable
    {
        void AplicarBonificacion(decimal monto);
    }

    public abstract class Empleado
    {
        public string Id { get; protected set; }
        public string Nombre { get; protected set; }
        public decimal SalarioBase { get; protected set; }

        protected Empleado(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public abstract decimal CalcularSalario();

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id} | Nombre: {Nombre}");
        }
    }

    public class EmpleadoTiempoCompleto : Empleado, IBonificable
    {
        private decimal bonificacionAdicional = 0;

        public EmpleadoTiempoCompleto(string id, string nombre, decimal salarioFijo)
            : base(id, nombre)
        {
            SalarioBase = salarioFijo;
        }

        public void ActualizarSalario(decimal nuevoSalario)
        {
            SalarioBase = nuevoSalario;
        }

        public void ActualizarSalario(decimal nuevoSalario, decimal bonificacion)
        {
            SalarioBase = nuevoSalario;
            bonificacionAdicional = bonificacion;
        }

        public void AplicarBonificacion(decimal monto) => bonificacionAdicional = monto;

        public override decimal CalcularSalario() => SalarioBase + bonificacionAdicional;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Tiempo Completo | Total: {CalcularSalario():C}");
        }
    }

    public class EmpleadoPorHoras : Empleado
    {
        public int HorasTrabajadas { get; private set; }
        public decimal ValorHora { get; private set; }

        public EmpleadoPorHoras(string id, string nombre, int horas, decimal valor)
            : base(id, nombre)
        {
            HorasTrabajadas = horas;
            ValorHora = valor;
        }

        public override decimal CalcularSalario() => HorasTrabajadas * ValorHora;

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Por Horas | Total: {CalcularSalario():C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> nomina = new List<Empleado>();

            // Creación de objetos
            EmpleadoTiempoCompleto emp1 = new EmpleadoTiempoCompleto("101", "Ana Maria", 3500000);
            emp1.AplicarBonificacion(200000);

            EmpleadoPorHoras emp2 = new EmpleadoPorHoras("102", "Juan Jose", 40, 50000);

            EmpleadoTiempoCompleto emp3 = new EmpleadoTiempoCompleto("103", "Carlos Perez", 3000000);
            emp3.ActualizarSalario(3200000, 150000);

            nomina.Add(emp1);
            nomina.Add(emp2);
            nomina.Add(emp3);

            Console.WriteLine("=== REPORTE DE NÓMINA POLIMÓRFICO ===\n");

            foreach (var emp in nomina)
            {
                emp.MostrarInformacion();
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
