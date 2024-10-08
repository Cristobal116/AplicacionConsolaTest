// See https://aka.ms/new-console-template for more information
using testingCode;

//EjemploOneSelectMany();
//EjemploTwoSelectMany();
EjemploSort();

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

void EjemploTwoSelectMany()
{
    PetOwner[] petOwners =
        { new PetOwner { Name="Higa",
              Pets = new List<string>{ "Scruffy", "Sam" } },
          new PetOwner { Name="Ashkenazi",
              Pets = new List<string>{ "Walker", "Sugar" } },
          new PetOwner { Name="Price",
              Pets = new List<string>{ "Scratches", "Diesel" } },
          new PetOwner { Name="Hines",
              Pets = new List<string>{ "Dusty" } } };

    // Project the pet owner's name and the pet's name.
    var query =
        petOwners
        .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
        .Where(ownerAndPet => ownerAndPet.petName.StartsWith('S'))
        .Select(ownerAndPet =>
                new
                {
                    Owner = ownerAndPet.petOwner.Name,
                    Pet = ownerAndPet.petName
                }
        );

    // Print the results.
    foreach (var obj in query)
    {
        Console.WriteLine(obj);
    }

    // This code produces the following output:
    //
    // {Owner=Higa, Pet=Scruffy}
    // {Owner=Higa, Pet=Sam}
    // {Owner=Ashkenazi, Pet=Sugar}
    // {Owner=Price, Pet=Scratches}
}


void EjemploSort()
{
    List<Persona> personas = new List<Persona>
    {
        new Persona { Nombre = "Ana", Edad = 25 },
        new Persona { Nombre = "Carlos", Edad = 30 },
        new Persona { Nombre = "Beatriz", Edad = 22 },
        new Persona { Nombre = "David", Edad = 35 },
        new Persona { Nombre = "Elena", Edad = 28 }
    };

    // Usando OrderBy
    var ordenadoPorNombre = personas.OrderBy(p => p.Edad).ToList();
    Console.WriteLine("\nOrdenado por nombre (OrderBy):");
    ImprimirLista(ordenadoPorNombre);

    // Usando OrderByDescending
    var ordenadoPorEdadDesc = personas.OrderByDescending(p => p.Edad).ToList();
    Console.WriteLine("\nOrdenado por edad descendente (OrderByDescending):");
    ImprimirLista(ordenadoPorEdadDesc);

    // Usando Sort ascendente
    personas.Sort((p1, p2) => p1.Edad.CompareTo(p2.Edad));
    Console.WriteLine("\nOrdenado por edad ascendente (Sort):");
    ImprimirLista(personas);

    // Usando Sort descendente
    personas.Sort((p1, p2) => p2.Edad.CompareTo(p1.Edad));
    Console.WriteLine("\nOrdenado por edad ascendente (Sort):");
    ImprimirLista(personas);
}

static void ImprimirLista(List<Persona> lista)
{
    foreach (var persona in lista)
    {
        Console.WriteLine($"{persona.Nombre} - {persona.Edad}");
    }
}

