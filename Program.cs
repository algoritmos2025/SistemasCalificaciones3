﻿
int aprobados = 0;
int reprobados = 0;

Console.WriteLine("--- Menú Principal ---");
Console.WriteLine("1 - Ingreso fijo de notas");
Console.WriteLine("2 - Ingreso indefinido de notas");
Console.WriteLine("3 - Mostrar resumen");
Console.WriteLine("4 - Salir");
Console.WriteLine("Seleccione una opción:");

string opcion = Console.ReadLine();

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

void IngresoFijo()
{
    int cantidad;
    float nota;

    bool cantidadValidada;

    do
    {
        
        Console.WriteLine("¿Cuántas notas desea ingresar?");
        cantidadValidada=int.TryParse(Console.ReadLine(), out cantidad) & cantidad>0;

        if (!cantidadValidada)
        {
            Console.WriteLine("Ingresa una cantidad numerica mayor a cero");
        }

    } while (!cantidadValidada);
    

    for (int i = 0; i < cantidad; i++)
    {
        bool notaValidada;
        do
        {
            Console.WriteLine($"Ingrese la nota del estudiante {i + 1}:");
            notaValidada = float.TryParse(Console.ReadLine(),out nota) & nota>0 & nota<=10;
            if (!notaValidada)
            {
                Console.WriteLine("Ingresa una nota numerica entre 1 y 10");
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
    }
}

void IngresoIndefinido()
{
    float nota;
    string respuesta = "SI";

    while (respuesta == "SI")
    {
        Console.WriteLine("Ingrese la nota del estudiante:");
        nota = float.Parse(Console.ReadLine());

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

        Console.WriteLine("¿Desea ingresar otra nota? (SI/NO):");
        respuesta = Console.ReadLine().ToUpper();
    }
}

void MostrarResumen()
{
    Console.WriteLine("--- Resumen de notas ---");
    Console.WriteLine("Total de aprobados: " + aprobados);
    Console.WriteLine("Total de reprobados: " + reprobados);
}