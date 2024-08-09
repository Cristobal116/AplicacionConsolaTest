// See https://aka.ms/new-console-template for more information
using testingCode;

EjemploOneSelectMany();

void EjemploOneSelectMany()
{
    var personas = new List<Persona>() {
    new Persona { Nombre = "Eduardo", Telefonos = { "123-456", "789-852" } },
    new Persona { Nombre = "Nidia", Telefonos = { "998-478", "568-222" } },
    new Persona { Nombre = "Alejandro", Telefonos = { "712-132" } },
    new Persona { Nombre = "Valentina" }
    };

    // El primer argumento es un Func, indicando el elemento que deseamos aplanar, es decir, los telefonos.
    // El segundo argumento es la forma como deseamos estructurar el IEnumerable con el Func anterior aplanado.
    var personasYTelefonos = personas.SelectMany(p => p.Telefonos, (persona, telefono) => new
    {
        Persona = persona,
        Telefono = telefono
    });

    foreach (var item in personasYTelefonos)
    {
        Console.WriteLine($"{item.Persona.Nombre} - {item.Telefono}");
    }

    // Se imprime lo siguiente:
    // Eduardo - 123-456
    // Eduardo - 789-852
    // Nidia - 998-478
    // Nidia - 568-222
    // Alejandro - 712-132
}


