using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEducativo;


namespace SistemaEducativo
{
    public class EstudianteBase : IEstudiante
    {
        public string Nombre { get; }
        public double CalificacionBase { get; }

        public EstudianteBase(string nombre, double calificacion)
        {
            Nombre = nombre;
            CalificacionBase = calificacion;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Estudiante: {Nombre}");
            Console.WriteLine($"Calificación base: {CalificacionBase:F2}");
            Console.WriteLine($"Promedio final: {CalificacionBase:F2}");

            if (CalificacionBase >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("El estudiante aprueba.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El estudiante reprueba.");
            }
            Console.ResetColor();
        }
    }
}
