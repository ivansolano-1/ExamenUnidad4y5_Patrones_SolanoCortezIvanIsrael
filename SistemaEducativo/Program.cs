using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaEducativo;

class Program
{
    static void Main()
    {
        List<IEstudiante> estudiantes = new List<IEstudiante>();
        ISistemaAntiguo sistemaAntiguo = new SistemaAntiguo();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema Educativo TecNM ===");
            Console.WriteLine("1. Registrar estudiante nuevo");
            Console.WriteLine("2. Registrar estudiante del sistema antiguo");
            Console.WriteLine("3. Mostrar lista de estudiantes");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción (1-4): ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarEstudianteNuevo(estudiantes);
                    break;

                case "2":
                    RegistrarEstudianteAntiguo(estudiantes, sistemaAntiguo);
                    break;

                case "3":
                    MostrarEstudiantes(estudiantes);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Opción inválida...");
                    break;
            }
        }
    }

    static void RegistrarEstudianteNuevo(List<IEstudiante> lista)
    {
        Console.Clear();
        Console.WriteLine("=== Registrar Estudiante Nuevo ===");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Calificación base: ");
        double cal = double.Parse(Console.ReadLine());

        // Crear estudiante base + extras + validación
        var estudiante = EstudianteManagerFactory.CrearEstudianteConExtras(nombre, cal);

        if (estudiante is EvaluacionExtraDecorator extra)
        {
            Console.WriteLine("\nAgregar módulos extra (deje vacío para terminar):");

            while (true)
            {
                Console.Write("Nombre del módulo: ");
                string modulo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(modulo))
                    break;

                Console.Write("Calificación: ");
                double calMod = double.Parse(Console.ReadLine());

                extra.AgregarModulo(modulo, calMod);
            }

            estudiante = new ValidacionDecorator(extra, cal);
        }

        lista.Add(estudiante);

        Console.WriteLine("\nEstudiante registrado!");
        Console.ReadKey();
    }

    static void RegistrarEstudianteAntiguo(List<IEstudiante> lista, ISistemaAntiguo sistemaAntiguo)
    {
        Console.Clear();
        Console.WriteLine("=== Registrar Estudiante del Sistema Antiguo ===");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Calificación base: ");
        double cal = double.Parse(Console.ReadLine());

        var estudiante = EstudianteManagerFactory.CrearEstudianteAntiguo(nombre, cal, sistemaAntiguo);

        lista.Add(estudiante);

        Console.WriteLine("\nEstudiante registrado!");
        Console.ReadKey();
    }

    static void MostrarEstudiantes(List<IEstudiante> lista)
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE ESTUDIANTES REGISTRADOS ===\n");

        int contador = 1;

        foreach (var est in lista)
        {
            Console.WriteLine($"-- Estudiante #{contador} --");
            est.MostrarInformacion();
            Console.WriteLine();
            contador++;
        }

        Console.WriteLine($"Total de estudiantes: {lista.Count}\n");
        Console.WriteLine("Presiona ENTER para volver al menú...");
        Console.ReadLine();
    }
}
