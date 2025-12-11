# ExamenUnidad4y5_Patrones_SolanoCortezIvanIsrael
Examen de la unidad 4 y 5 de Patrones de diseño (Sistema educativo con módulos extra de evaluación)

### Patrones implementados

| **Patrón** | **Tipo de Patrón**                | **Clases Clave Involucradas**                                                                                                                            |
| ------------------ | ------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Factory Method**     | **Creacional**        | `EstudianteManagerFactory`, `EstudianteBase`, `EvaluacionExtraDecorator`, `ValidacionDecorator`, `SistemaAdapter`                                        |
| **Decorator**    | **Estructural**             | `EstudianteDecorator`, `EvaluacionExtraDecorator`, `ValidacionDecorator`, `IEstudiante`                                                                  |
| **Adapter**    | **Estructural**               | `SistemaAdapter`, `ISistemaAntiguo`, `SistemaAntiguo`, `IEstudiante`                                                                                     |
| **State** | **Comportamiento**                 | `IEstadoEstudiante`, `EstadoAprobado`, `EstadoEnRiesgo`, `EstadoReprobado`, `ValidacionDecorator`                                                        |
| **Arquitectura en Capas**   | **Arquitectura en Capas** | `Program.cs` (Capa de Presentación), clases del dominio en `SistemaEducativo` (Negocio), `List<IEstudiante>` (Datos), `SistemaAntiguo` (Legacy/Externos) |

### Doagrama UML

```mermaid
classDiagram
    %% Interfaces
    IEstudiante <|.. EstudianteBase
    IEstudiante <|.. EstudianteDecorator
    ISistemaAntiguo <|.. SistemaAntiguo

    %% Clases base
    EstudianteBase : -string nombre
    EstudianteBase : -double calificacion
    EstudianteBase : +ObtenerCalificacionBase()
    EstudianteBase : +MostrarInformacion()

    %% Decorator
    EstudianteDecorator <|-- EvaluacionExtraDecorator
    EstudianteDecorator <|-- ValidacionDecorator
    EstudianteDecorator : -IEstudiante estudiante
    EstudianteDecorator : +MostrarInformacion()

    EvaluacionExtraDecorator : -List~(string, double)~ modulosExtras
    EvaluacionExtraDecorator : +AgregarModulo(nombre, calificacion)
    EvaluacionExtraDecorator : +ObtenerPromedioExtra()
    EvaluacionExtraDecorator : +MostrarInformacion()

    ValidacionDecorator : -double calificacionBase
    ValidacionDecorator : +MostrarInformacion()

    %% Adapter
    SistemaAdapter : -ISistemaAntiguo _sistemaAntiguo
    SistemaAdapter : -string _nombre
    SistemaAdapter : -double _calificacion
    SistemaAdapter : +MostrarInformacion()

    %% State
    IEstadoEstudiante <|.. EstadoAprobado
    IEstadoEstudiante <|.. EstadoEnRiesgo
    IEstadoEstudiante <|.. EstadoReprobado
    IEstadoEstudiante : +MostrarEstado()

    EstadoAprobado : +MostrarEstado()
    EstadoEnRiesgo : +MostrarEstado()
    EstadoReprobado : +MostrarEstado()

    %% Factory Method
    EstudianteManagerFactory : +CrearEstudianteBase(nombre, calificacion)
    EstudianteManagerFactory : +CrearEstudianteConExtras(nombre, calificacion)
    EstudianteManagerFactory : +CrearEstudianteAntiguo(nombre, calificacion, sistemaAntiguo)
    
    %% Relaciones
    EvaluacionExtraDecorator --> EstudianteDecorator
    ValidacionDecorator --> EstudianteDecorator
    SistemaAdapter --> ISistemaAntiguo
    ValidacionDecorator --> IEstadoEstudiante
