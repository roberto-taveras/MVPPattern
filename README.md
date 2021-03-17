# MVP Pattern
- Proyecto de ejemplo usando:
- Patrón de diseño MVP(Model-View-Presenter)
- Reflection
- Delegates
- Events 
- Repositorio Generico
- Inyección de dependencias
- Databindings en Windows Forms
- Traducciones
- Validaciones del modelo
- Fluent Validations
- Globalizacion (es-DO (Español),en-US (Ingles))

 El BusinessObjects tiene las siguientes partes:
 
Basicamente voy a dejar el link a github para que puedan desacargar el proyecto, que en escencia tiene un repositorio generico, con el cual se desarrollan los presenters, estos presenters validan las entidades con la informacion del modelo pero tambien se puede extender usando Fluent Validation si se requiere agregar Reglas, como es utilizado en el proyecto.

# Introduccion

El proyecto muestra cómo reducir código al crear aplicaciones de Windows Forms al usar repositorios genéricos, ayudantes usando el erroc del validador para no tener que aplicarlo manualmente en cada validación, si no para hacerlo automáticamente como funciona el CRUD en aplicaciones MVC.

# Partes del BusinessObjetcs & Dependencias
- proyecto tiene las siguientes dependencias:
- EntityFramework.6.4.4
- Fluent Validation 9.0.0.0: https://fluentvalidation.net/
- La librería BusinessObjects usa Standard Net (4.8)
- WinFormsAppBindings Tiene como dependencia .Net 5.0

# El BusinessObjects tiene las siguientes partes:

1 (Context): que se encarga de mapear algunos de los modelos que están vinculados a cada tabla.

2 (HelperAssignProperty): cuál es la función de getters y setters (entre la interfaz que se inyecta desde la vista y el modelo que se instancia en el presentador).

3 (HelperValidateEntity): El cual se encarga de las validaciones del modelo en base a las restricciones que se colocan en cada bit que representa cada tabla.

4 (Interfaces) : Contiene las interfaces relacionadas con algunos de los modelos de cada tabla y una interfaz especial llamada INofitify que se inyecta desde la vista al presentador para establecer todo el mecanismo de validación.

5 (Models): Contiene los pocos de cada clase, estos implementan interfaces que tienen que tener exactamente las mismas propiedades que los modelos para que los getters y setters se ejecuten correctamente en el helper (HelperAssignProperty).

6 (Repository): Contiene un repositorio genérico cuya función es reutilizar el código, y evitar tener que hacer lo mismo una y otra vez, se implementa en cada presentador y cuenta con métodos y eventos virtuales que se pueden utilizar para aumentar su flexibilidad:

7 (Presenters): que implementan RepositoryBase y que pueden sobrescribirse y extender sus validaciones con Fluent Validations.

8 (Resources): Contiene archivos de recursos y un Helper para la traducción al inglés y al español de la interfaz de usuario y el texto devuelto por las validaciones.
