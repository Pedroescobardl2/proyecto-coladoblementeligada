using System;

public class Nodo
{
    public int dato;
    public Nodo siguiente;
    public Nodo anterior;

    public Nodo(int d)
    {
        dato = d;
        siguiente = null;
        anterior = null;
    }
}

public class ListaDoble
{
    private Nodo cabeza;

    public ListaDoble()
    {
        cabeza = null;
    }

    public void Insertar(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            nuevo.siguiente = cabeza;
            cabeza.anterior = nuevo;
            cabeza = nuevo;
        }
    }

    public void Eliminar(int dato)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.dato == dato)
            {
                if (actual.anterior != null)
                {
                    actual.anterior.siguiente = actual.siguiente;
                }
                if (actual.siguiente != null)
                {
                    actual.siguiente.anterior = actual.anterior;
                }
                if (actual == cabeza)
                {
                    cabeza = actual.siguiente;
                }
                return;
            }
            actual = actual.siguiente;
        }
    }

    public bool Buscar(int dato)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.dato == dato)
            {
                return true;
            }
            actual = actual.siguiente;
        }
        return false;
    }

    public void Recorrer()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;
        }
        Console.WriteLine();
    }

    public void Ordenar()
    {
        
        Nodo actual, siguiente;
        int temp;
        actual = cabeza;
        while (actual != null)
        {
            siguiente = actual.siguiente;
            while (siguiente != null)
            {
                if (actual.dato > siguiente.dato)
                {
                    temp = actual.dato;
                    actual.dato = siguiente.dato;
                    siguiente.dato = temp;
                }
                siguiente = siguiente.siguiente;
            }
            actual = actual.siguiente;
        }
    }

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("");
            Console.WriteLine("\t=== Menú de Operaciones ===");
            Console.WriteLine("");
            Console.WriteLine("\t1. Insertar elemento");
            Console.WriteLine("\t2. Eliminar elemento");
            Console.WriteLine("\t3. Buscar elemento");
            Console.WriteLine("\t4. Recorrer lista");
            Console.WriteLine("\t5. Ordenar lista");
            Console.WriteLine("\t6. Salir");
            Console.WriteLine("");
            Console.Write("\tSelecciona una opción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.Write("\tIngrese el elemento a insertar: ");
                    int elementoInsertar = int.Parse(Console.ReadLine());
                    Insertar(elementoInsertar);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.Write("\tIngrese el elemento a eliminar: ");
                    int elementoEliminar = int.Parse(Console.ReadLine());
                    Eliminar(elementoEliminar);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.Write("\tIngrese el elemento a buscar: ");
                    int elementoBuscar = int.Parse(Console.ReadLine());
                    if (Buscar(elementoBuscar))
                        Console.WriteLine("\tEl elemento está presente en la lista.");
                    else
                        Console.WriteLine("\tEl elemento no está presente en la lista.");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("\tElementos de la lista:");
                    Recorrer();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("");
                    Ordenar();
                    Console.WriteLine("Lista ordenada.");
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("\tSaliendo del programa.");
                    break;
                default:
                    Console.WriteLine("\tOpción no válida. Por favor, seleccione nuevamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcion != 6);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaDoble lista = new ListaDoble();
        lista.MostrarMenu();
    }
}
