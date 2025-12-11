using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEducativo
{
    public class EstadoAprobado : IEstadoEstudiante
    {
        public void MostrarEstado()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estado actual: APROBADO");
            Console.ResetColor();
        }
    }
}
