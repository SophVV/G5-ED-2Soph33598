using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodoArbolBusqueda
{
    class Program
    {
        static void MENU()
        {
            try
            {
                NodoArbolBusqueda ABB = new NodoArbolBusqueda();

                byte Opcion = 0, Opcion1 = 0, Opcion2;
                
                do
                {

                    Console.Clear();
                    Console.WriteLine("\n.....MENU PRINCIPAL....");
                    Console.WriteLine("\n\n1.-  INSERTAR NODO EN EL ARBOL");
                    Console.WriteLine("\n2.-  BUSCAR NODO EN EL ARBOL");
                    Console.WriteLine("\n3.-  ELIMINAR NODO EN EL ARBOL");
                    Console.WriteLine("\n4.-  IMPRIMIR NODOS EN EL ARBOL");
                    Console.WriteLine("\n\n5.-  SALIR");

                    Console.WriteLine("\nSELECCIONE UNA OPCION: ");

                    Opcion = Convert.ToByte(Console.ReadLine());
                    

                    switch (Opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\nINSERTAR NODO EN EL ARBOL");
                            ABB.InsertarNodo(); //Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\nBUSCAR NODO.....:  ");
                            ABB.BusquedaDato(); //Console.ReadKey();
                            Console.ReadKey();
                            Console.Clear();
                 

                            break;

                        case 3:
                            try
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine(".....MENU PARA ELIMINAR LOS NODOS DEL ARBOL....");
                                    Console.WriteLine("\n\n1.-  ELIMINAR UN NODO DEL ARBOL DADO POR EL USUARIO");
                                    Console.WriteLine("\n2.-  ELIMINAR EL DATO MAYOR");
                                    Console.WriteLine("\n3.-  ELIMINAR EL DATO MENOR");
                                    Console.WriteLine("\n4.-  REGRESAR AL MENU PRINCIPAL");

                                    Console.WriteLine("SELECCIONE UNA OPCION: ");
                                    Opcion1 = Convert.ToByte(Console.ReadLine());
                                    

                                    switch (Opcion1)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("\nELIMINAR NODO EN EL ARBOL...");
                                            ABB.EliminarDato(); //Console.ReadKey();
                                            Console.Clear();
                                            Console.WriteLine("Borraste un nodo del arbol...");
                                            Console.ReadKey();
                                            break;

                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("\nELIMINAR NODO MAYOR EN EL ARBOL");
                                            ABB.BorrarMayor(); //Console.ReadKey();
                                            Console.Clear();
                                            Console.WriteLine("Borraste el nodo mayor del arbol...");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("\nELIMINAR NODO MENOR EN EL ARBOL");
                                            ABB.BorrarMenor(); //Console.ReadKey();
                                            Console.Clear();
                                            Console.WriteLine("Borraste el nodo menor del arbol...");
                                            Console.ReadKey();
                                            break;

                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine("\n\nREGRESARA' AL MENU PRINCIPAL =)   \n\n");
                                            break;

                                        default:
                                            Console.WriteLine("************************************************************");
                                            Console.WriteLine("******************* OPC INCORRECTA *************************");
                                            Console.WriteLine("************************************************************");
                                            Console.ReadKey();
                                            break;
                                    }
                                    //Console.ReadKey();

                                } while (Opcion1 != 4); Console.Clear();

                                
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("******************************");
                                Console.WriteLine("ERROR" + e.Message);
                                Console.WriteLine("******************************");
                            }
                            break;

                        case 4:
                            try
                            {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine(".....MENU PARA IMPRIMIR LOS NODOS DEL ARBOL....");
                                Console.WriteLine("\n\n1.-  IMPRIMIR PREORDEN ");
                                Console.WriteLine("\n2.-  IMPRIMIR INORDEN (ASCENDENTE)");//ASCENDENTE
                                Console.WriteLine("\n3.-  IMPRIMIR POSTORDEN");
                                Console.WriteLine("\n4.-  IMPRIMIR INVERSEORDEN (DESCENDIENTE)");//DESCENDIENTE
                                Console.WriteLine("\n5.-  MOSTRAR NODO RAIZ DEL ARBOL");
                                Console.WriteLine("\n6.-  MOSTRAR DESCENDIENTES (HIJOS) DE NODO X DADO POR EL USUARIO");
                                Console.WriteLine("\n7.-  MOSTRAR ANTECESOR DE UN NODO Y (PADRE)");
                                Console.WriteLine("\n8.-  MOSTRAR NODOS INTERIORES");
                                Console.WriteLine("\n9.-  MOSTRAR GRADO DE UN NODO X");
                                Console.WriteLine("\n10.-  MOSTRAR GRADO DEL ARBOL");
                                Console.WriteLine("\n11.-  MOSTRAR NIVEL DE UN NODO X");
                                Console.WriteLine("\n12.-  MOSTRAR LA ALTURA DEL ARBOL");
                                Console.WriteLine("\n13.-  MOSTRAR LONGITUD DE CAMINO INTERNO");
                                Console.WriteLine("\n14.-  MOSTRAR LONGITUD DE CAMINO EXTERNO");
                                Console.WriteLine("\n15.-  MOSTRAR LA MEDIA DE LONGITUD DE CAMINO INTERNO");
                                Console.WriteLine("\n16.-  MOSTRAR LA MEDIA DE LONGITUD DE CAMINO EXTERNO");
                                Console.WriteLine("\n17.-  MOSTRAR ABUELO");
                                Console.WriteLine("\n18.-  MOSTRAR TIOS(AS)");
                                Console.WriteLine("\n19.-  MOSTRAR SORINOS(AS)");
                                Console.WriteLine("\n20.-  MOSTRAR PRIMOS(AS)");
                                Console.WriteLine("\n\n21.-  REGRESAR AL MENU PRINCIPAL");

                                Console.WriteLine("\nSELECCIONE UNA OPCION: ");
                                Opcion2 = Convert.ToByte(Console.ReadLine());

                                switch (Opcion2)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("\n......IMPRIMIR PRE_ORDEN...... \n\n");
                                        ABB.ImprimirPreOrden(); //Console.ReadKey();
                                        Console.ReadKey();
                                        break;

                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("\n......IMPRIMIR IN_ORDEN...... \n\n");
                                        ABB.ImprimirInOrden(); //Console.ReadKey();
                                        Console.ReadKey();
                                        break;

                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("\n......IMPRIMIR POS_ORDEN...... \n\n");
                                        ABB.ImprimirPostOrden(); //Console.ReadKey();
                                        Console.ReadKey();
                                        break;

                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("\n......IMPRIMIR INVERSE_ORDEN...... \n\n");
                                        ABB.ImprimirInverseOrden(); //Console.ReadKey();
                                        Console.ReadKey();
                                        break;

                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("\n......IMPRIMIR RAIZ...... \n\n");
                                        ABB.EsRaiz();
                                        Console.ReadKey();
                                        break;

                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("\n......DESCENDIENTE DE UN NODO X....... \n\n");
                                        ABB.DescendientesDeX();
                                        Console.ReadKey();
                                        break;

                                    case 7:
                                        Console.Clear();
                                        Console.WriteLine("\n......ANTECESOR DE UN NODO Y....... \n\n");
                                        ABB.AntecesorDeY();
                                        Console.ReadKey();
                                        break;

                                    case 8:
                                         Console.Clear();
                                        Console.WriteLine("\n......NODOS INTERIORES....... \n\n");
                                        ABB.NodosInteriores();
                                        Console.ReadKey();
                                        break;

                                    case 9:
                                        Console.Clear();
                                        Console.WriteLine("\n......GRADO DE UN NODO....... \n\n");
                                        ABB.GradoDeUnNodo();
                                        Console.ReadKey();
                                        break;

                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("\n......GRADO DEL ARBOL....... \n\n");
                                        ABB.GradoDelArbol();
                                        Console.ReadKey();
                                        break;

                                    case 11:
                                        Console.Clear();
                                        Console.WriteLine("\n......NIVEL DE UN NODO....... \n\n");
                                        ABB.NivelDeUnNodo();
                                        Console.ReadKey();
                                        break;

                                    case 12:
                                        Console.Clear();
                                        Console.Write("\n........ALTURA DEL ARBOL...........  ");
                                        Console.WriteLine(ABB.AlturaDelArbol());
                                        Console.ReadKey();
                                        break;

                                    case 13:
                                        Console.Clear();
                                        Console.Write("......OPCION NO DISPONIBLE, CONTACTE A SU ADMINISTRADOR =D.......");
                                        Console.ReadKey();
                                        break;

                                    case 14:
                                        Console.Clear();
                                        Console.Write("......OPCION NO DISPONIBLE, CONTACTE A SU ADMINISTRADOR =D ......");
                                        Console.ReadKey();
                                        break;

                                    case 15:
                                        Console.Clear();
                                        Console.Write("........OPCION NO DISPONIBLE, CONTACTE A SU ADMINISTRADOR =D.........");
                                        Console.ReadKey();
                                        break;

                                    case 16:
                                        Console.Clear();
                                        Console.Write(".......OPCION NO DISPONIBLE, CONTACTE A SU ADMINISTRADOR =D ..........");
                                        Console.ReadKey();
                                        break;

                                    case 17:
                                        Console.Clear();
                                        Console.WriteLine("\n......ABUELO....... \n\n");
                                        ABB.Abuelo();
                                        Console.ReadKey();
                                        break;

                                    case 18:
                                        Console.Clear();
                                        Console.WriteLine("\n......TIO...... \n\n");
                                        
                                        ABB.Tio();
                                        Console.ReadKey();
                                        break;

                                    case 19:
                                        Console.Clear();
                                        Console.WriteLine("\n......SOBRINO...... \n\n");
                                        ABB.Sobrinos();
                                        Console.ReadKey();
                                        break;

                                    case 20:
                                        Console.Clear();
                                        Console.WriteLine("\n......PRIMO...... \n\n");
                                        ABB.Primos();
                                        Console.ReadKey();
                                        break;

                                    case 21:
                                        Console.WriteLine("\n\nREGRESARA' AL MENU PRINCIPAL =)");
                                        break;

                                    default:
                                        Console.Clear();
                                        Console.WriteLine("************************************************************");
                                        Console.WriteLine("******************* OPC INCORRECTA *************************");
                                        Console.WriteLine("************************************************************");
                                        Console.ReadKey();
                                        break;
                                }
                                //Console.ReadKey();

                            } while (Opcion2 != 21); Console.Clear();
                            
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("******************************");
                                Console.WriteLine("ERROR" + e.Message);
                                Console.WriteLine("******************************");
                            }
                            break;




                        case 5:
                            Console.Clear();
                            Console.WriteLine("************************************************************");
                            Console.WriteLine("****************** PROGRAMA TERMINADO **********************");
                            Console.WriteLine("************************************************************");
                            Console.ReadKey();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("************************************************************");
                            Console.WriteLine("******************* OPC INCORRECTA *************************");
                            Console.WriteLine("************************************************************");
                            Console.ReadKey();
                            break;
                    }
                    //Console.ReadKey();
                } while (Opcion != 5);
            }
            catch (FormatException e)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("ERROR" + e.Message);
                Console.WriteLine("******************************");
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            MENU();
            Console.ReadKey();
        }

        public static NodoArbol nodorecorrido { get; set; }
    }
}
