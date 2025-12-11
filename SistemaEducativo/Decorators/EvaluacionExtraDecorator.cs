using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class EvaluacionExtraDecorator : EstudianteDecorator
    {
        private readonly List<(string nombreModulo, double calificacion)> modulosExtras;

        public EvaluacionExtraDecorator(IEstudiante estudiante)
            : base(estudiante)
        {
            modulosExtras = new List<(string, double)>();
        }

        public void AgregarModulo(string nombre, double calificacion)
        {
            modulosExtras.Add((nombre, calificacion));
        }

        public double ObtenerPromedioExtra()
        {
            if (modulosExtras.Count == 0) return 0.0;

            double suma = 0;
            foreach (var m in modulosExtras)
                suma += m.calificacion;

            return suma / modulosExtras.Count;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            if (modulosExtras.Count > 0)
            {
                Console.WriteLine("Módulos adicionales:");
                foreach (var (nombreModulo, calificacion) in modulosExtras)
                {
                    Console.WriteLine($"   - {nombreModulo}: {calificacion}");
                }

                Console.WriteLine($"Promedio módulos extra: {ObtenerPromedioExtra():F2}");
            }
            else
            {
                Console.WriteLine("No tiene módulos adicionales.");
            }
        }
    }
}
