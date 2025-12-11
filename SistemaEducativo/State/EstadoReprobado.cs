using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaEducativo
{
    public class EstadoReprobado : IEstadoEstudiante
    {
        public void MostrarEstado()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Estado actual: REPROBADO");
            Console.ResetColor();
        }
    }
}
