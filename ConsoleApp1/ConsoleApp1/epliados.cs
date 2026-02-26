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