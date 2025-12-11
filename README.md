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

