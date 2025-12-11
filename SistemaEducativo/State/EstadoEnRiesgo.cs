using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class EstadoEnRiesgo : IEstadoEstudiante
    {
        public void MostrarEstado()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Estado actual: EN RIESGO");
            Console.ResetColor();
        }
    }
}
