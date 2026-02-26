#### Integrantes

Juan José Hernández Tobón

Miguel Santana Saldarriaga

Mariana Flórez Ramírez

#### Descripción

Este proyecto es una aplicación de consola que hicimos en C# ya que es el lenguaje con el que estamos mas familiarizados, para gestionar empleos y calcular salarios utilizando programación orientada a objetos

Lo que el sistema permite hacer es manejar distintos tipos de empleados donde cada uno tiene su propia forma de calcular el salario pero todos comparten una estructura en común

#### Lo que aplicamos

- Abstracción

  Creamos una clase abstracta llamada empleado, la clase contiene atributos comunes (ID y nombre), El metodo abtracto (calcularsalario()) y un metodo virtual (Mostrarinformación())

  Con esto definimos una estructua general para todos los empleados sin implementar directamente el calculo del salario.

 - Herencia
 
  Los conceptos EmpleadoTiempoCompleto y EmpleadoPorHoras heredan de la clase Empleado, esto nos permitió reutilizar codigo y mantener una organización clara

 -Polimorfismo

  Fue una lista de este tipo

  List<Empleado>

  En esta colección guardamos empleados de distintos tipos y luego al recorrerla hicimos

  Foreach(Empleado emp in empleados)
  {
    emp.MostrarInformacion();
  }

  Cada objeto ejecuta su propio comportamiento dependiendo de su tipo

 -Encapsulamiento

  Estas propiedades tiene

  private set; que se usó para evitar que los datos se modifiquen desde fuera de la clase y asi mantener el control de la información

 #### Por que decidimos implementar esto?

Quisimos usar una clase abstracta en vez de una interfaz por que tidis kis empleados tienen atributos en común, se puede reutilizar el metodo MostrarInformacion() y se evita que repitamos el codigo en las clases hijas

Utilizamos el metodo vitrual MostrarInformacioni() para que las clases hijas puedaan usar como información base y agregar su propia información utilizando base.MostrarInformación()

y utilizamos el calculo del salario por que cada tipo de empleado tiene su propia logica, por ejemplo: un empleado de tiempo completo tiene salario fijo, mientras que el que es empleado por horas son horas trabajadas x el valor x hora, que se implementó sobrescribiendo el metodo CalcularSalario()

#### Funcionamiento del programa

El programa principal crea varios empleados de distintosd tipos, los almacena en una sola colección, recorre la lista, muestra la info de cada empleado y calcula el salario de forma polimorfica. 
Para este prototipo no implementamos persistencia de datos
