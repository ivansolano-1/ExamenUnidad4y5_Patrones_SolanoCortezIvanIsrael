using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaEducativo
{
    public class ValidacionDecorator : EstudianteDecorator
    {
        private readonly double calificacionBase;

        public ValidacionDecorator(IEstudiante estudiante, double calificacionBase)
            : base(estudiante)
        {
            this.calificacionBase = calificacionBase;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();

            double promedioExtra = 0.0;

            if (estudiante is EvaluacionExtraDecorator extra)
            {
                promedioExtra = extra.ObtenerPromedioExtra();
            }

            double promedioFinal = (promedioExtra > 0)
                ? (calificacionBase + promedioExtra) / 2.0
                : calificacionBase;

            Console.WriteLine($"Promedio final: {promedioFinal:F2}");

            //=== STATE PATTERN ===
            IEstadoEstudiante estado = DeterminarEstado(promedioFinal);

            estado.MostrarEstado();
        }

        private IEstadoEstudiante DeterminarEstado(double promedio)
        {
            if (promedio >= 75)
                return new EstadoAprobado();

            if (promedio >= 70)
                return new EstadoEnRiesgo();

            return new EstadoReprobado();
        }
    }
}
