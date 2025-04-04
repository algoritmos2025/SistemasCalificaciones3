int aprobados = 0;
int reprobados = 0;
string opcion;

do
{
    Console.WriteLine("--- Menú Principal ---");
    Console.WriteLine("1 - Ingreso fijo de notas");
    Console.WriteLine("2 - Ingreso indefinido de notas");
    Console.WriteLine("3 - Mostrar resumen");
    Console.WriteLine("4 - Salir");
    Console.WriteLine("Seleccione una opción:");
    opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            IngresoFijo();
            break;
        case "2":
            IngresoIndefinido();
            break;
        case "3":
            MostrarResumen();
            break;
        case "4":
            Console.WriteLine("Saliendo del sistema...");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }


} while (opcion!="4");





void IngresoFijo()
{
   
    

    int cantidad = ValidarCantidad();
    
    

    for (int i = 0; i < cantidad; i++)
    {
        float nota = ValidarNota(i);

        CalificarNota(nota);
        
    }
}

void IngresoIndefinido()
{
    float nota;
    string respuesta = "SI";

    while (respuesta == "SI")
    {
        bool notaValidada;
        do
        {
            Console.WriteLine("Ingrese la nota del estudiante:");
            notaValidada = float.TryParse(Console.ReadLine(), out nota) & nota>0 & nota<=10;

            if (!notaValidada)
            {
                Console.WriteLine("Ingrese una nota valida entre 1-10");

            }

        } while (!notaValidada);
        

        if (nota >= 7)
        {
            Console.WriteLine("Aprobado");
            aprobados++;
        }
        else
        {
            Console.WriteLine("Reprobado");
            reprobados++;
        }


        do
        {
            Console.WriteLine("¿Desea ingresar otra nota? (SI/NO):");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta != "SI" && respuesta != "NO")
            {
                Console.WriteLine("Por favor, ingrese (SI/NO)");
            }

        } while (respuesta != "SI" && respuesta != "NO");
        
    }
}

void MostrarResumen()
{
    if(aprobados==0 & reprobados == 0)
    {
        Console.WriteLine("No hay notas para mostrar");
    }
    else
    {
        Console.WriteLine("--- Resumen de notas ---");
        Console.WriteLine("Total de aprobados: " + aprobados);
        Console.WriteLine("Total de reprobados: " + reprobados);

    }
    
}

void CalificarNota(float nota)
{
    if (nota >= 7)
    {
        Console.WriteLine("Aprobado");
        aprobados++;
    }
    else
    {
        Console.WriteLine("Reprobado");
        reprobados++;
    }
}

int ValidarCantidad()
{
    bool cantidadValidada;
    int cantidad;
    do
    {

        Console.WriteLine("¿Cuántas notas desea ingresar?");
        cantidadValidada = int.TryParse(Console.ReadLine(), out cantidad) & cantidad > 0;

        if (!cantidadValidada)
        {
            Console.WriteLine("Ingresa una cantidad numerica mayor a cero");
        }

    } while (!cantidadValidada);

    return cantidad;
}


float ValidarNota(int i)
{
    float nota;
    bool notaValidada;
    do
    {
        Console.WriteLine($"Ingrese la nota del estudiante {i + 1}:");
        notaValidada = float.TryParse(Console.ReadLine(), out nota) & nota > 0 & nota <= 10;
        if (!notaValidada)
        {
            Console.WriteLine("Ingresa una nota numerica entre 1 y 10");
        }

    } while (!notaValidada);

    return nota;

}