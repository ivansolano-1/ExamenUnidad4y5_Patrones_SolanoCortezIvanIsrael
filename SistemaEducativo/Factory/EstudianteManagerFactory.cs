using System;
using System.Collections.Generic;

namespace SistemaEducativo
{
    public static class EstudianteManagerFactory
    {
        public static IEstudiante CrearEstudianteBase(string nombre, double calificacion)
        {
            return new EstudianteBase(nombre, calificacion);
        }

        public static IEstudiante CrearEstudianteConExtras(string nombre, double calificacion)
        {
            var baseStudent = new EstudianteBase(nombre, calificacion);
            return new EvaluacionExtraDecorator(baseStudent);
        }

        public static IEstudiante CrearEstudianteConValidacion(string nombre, double calificacion)
        {
            var baseStudent = new EstudianteBase(nombre, calificacion);
            return new ValidacionDecorator(baseStudent, calificacion);
        }

        public static IEstudiante CrearEstudianteAntiguo(string nombre, double calificacion, ISistemaAntiguo sistemaAntiguo)
        {
            return new SistemaAdapter(sistemaAntiguo, nombre, calificacion);
        }
    }
}
