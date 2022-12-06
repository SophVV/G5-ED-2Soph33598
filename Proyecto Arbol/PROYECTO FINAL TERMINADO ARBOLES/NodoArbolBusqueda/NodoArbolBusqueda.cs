using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodoArbolBusqueda
{
    public class NodoArbolBusqueda
    {
        

        public NodoArbol nodoRaiz;
        public NodoArbol NodoAnterior, NodoSiguiente, NodoRecorrido, NodoAuxiliar, NodoAbuelo, NodoHermano, NodoTio;
        int dato; string nombre;//ATRIBUTOS DE CADA NODO
        bool Encontrado = false;
        private int Cantidad, Altura;
        public bool Grado1 = false, Grado2 = false;
        
        public NodoArbolBusqueda()
        {
            nodoRaiz = null;
        }

        public void InsertarNodo()
        {
            NodoArbol NuevoNodo = new NodoArbol(dato, nombre);

            Console.WriteLine("INGRESE EL DATO PARA EL ARBOL BINARIO DE BUSQUEDA:    ");
            dato = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("INGRESE EL NOMBRE PARA EL DATO DEL ARBOL BINARIO DE BUSQUEDA:   ");
            nombre = Console.ReadLine().ToUpper();

            NuevoNodo.Dato = dato; NuevoNodo.Nombre = nombre;

            if(nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                nodoRaiz = NuevoNodo;
            }

            else if( BuscarDato(dato) != null)
            {
                Console.WriteLine("EL VALOR INGRESADO ES:  " + dato + "\nYA SE ENCUENTRA EN EL ARBOL:   ");
            }

            else
            {
                NodoArbol NodoAnterior = null; // NODO PADRE
                NodoArbol NodoRecorrido = nodoRaiz; //NODO AUXILIAR

                while(NodoRecorrido != null)
                {
                    NodoAnterior = NodoRecorrido;
                    
                    if(dato < NodoRecorrido.Dato)//SI EL DATO ES MENOR SE VA POR LA RAMA IZQUIERDA DEL ARBOL
                    {
                        NodoRecorrido = NodoRecorrido.RamaIzquierda;
                    }
                    else //SI EL DATO ES MAYOR SE VA POR LA RAMA DERECHA DEL ARBOL
                    {
                        NodoRecorrido = NodoRecorrido.RamaDerecha;
                    }
                }//FIN WHILE

                //CUANDO ENCUENTRA EL DATO SE INSERTA POR LA RAMA IZQUIERDA SI ES MENOR O POR LA DERECHA SI ES MAYOR
                if(dato < NodoAnterior.Dato)
                {
                    NodoAnterior.RamaIzquierda = NuevoNodo;
                    Grado1 = true;
                }
                else
                {
                    NodoAnterior.RamaDerecha = NuevoNodo;
                    Grado2 = true;
                }
            }
        }


        private void ImprimirPreOrden(NodoArbol NodoRecorrido)
        {
            if(NodoRecorrido != null)
            {
                Console.Write("\nNodo:  ->  " + NodoRecorrido.Dato + " " +  "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre + "\n\n");

                ImprimirPreOrden(NodoRecorrido.RamaIzquierda);

                ImprimirPreOrden(NodoRecorrido.RamaDerecha);
            }
        }

        public void ImprimirPreOrden()
        {
            ImprimirPreOrden(nodoRaiz);
            Console.WriteLine();
        }


        private void ImprimirInOrden(NodoArbol NodoRecorrido)
        {
            if (NodoRecorrido != null)
            {
                ImprimirInOrden(NodoRecorrido.RamaIzquierda);

                Console.Write("\nNodo:  ->  " + NodoRecorrido.Dato + "  " + "\nSU NOMBRE ES  " + NodoRecorrido.Nombre + "\n\n");

                ImprimirInOrden(NodoRecorrido.RamaDerecha);
            }
        }

        public void ImprimirInOrden()
        {
            ImprimirInOrden(nodoRaiz);
            Console.WriteLine();
        }

        private void ImprimirPostOrden(NodoArbol NodoRecorrido)
        {
            if (NodoRecorrido != null)
            {
                ImprimirPostOrden(NodoRecorrido.RamaIzquierda);

                ImprimirPostOrden(NodoRecorrido.RamaDerecha);

                Console.Write("\nNodo:  ->  " + NodoRecorrido.Dato + "  " + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre + "\n\n");
            }
        }

        public void ImprimirPostOrden()
        {
            ImprimirPostOrden(nodoRaiz);
            Console.WriteLine();
        }


        private void ImprimirInverseOrden(NodoArbol NodoRecorrido)
        {
            if (NodoRecorrido != null)
            {
                ImprimirInverseOrden(NodoRecorrido.RamaDerecha);

                Console.Write("\nNodo:  ->  " + NodoRecorrido.Dato + "  " + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre + "\n\n");

                ImprimirInverseOrden(NodoRecorrido.RamaIzquierda);

            }
        }

        public void ImprimirInverseOrden()
        {
            ImprimirInverseOrden(nodoRaiz);
            Console.WriteLine();
        }

       

        public void BusquedaDato()
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("\n.....ARBOL ACTUALMENTE VACIO.....");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR:    ");
                dato = Convert.ToInt32(Console.ReadLine());
                

                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    Console.WriteLine("\t\t¡VALOR ENCONTRADO!\n\n");
                    Console.WriteLine("EL VALOR BUSCADO ES:   " + dato + "  \nES LA RAIZ DEL ARBOL:   " + nodoRaiz.Dato + "  " + "\nSU NOMBRE ES:  " + nodoRaiz.Nombre);
                    
                }

                else//SI EL DATO NO ES LA RAIZ
                {
                    if(BuscarDato(dato) == null)
                    {
                        Console.WriteLine("EL VALOR BUSCADO ES:  " + dato + "\nNO SE ENCUENTRA EN EL NODO");
                    }

                    else
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO ES:    " + dato + "\nSE ENCUENTRA EN EL ARBOL:     "  +  dato + "  " + "\nSU NOMBRE ES:  " + nombre);
                    }
                }
               
            }
        }


        public NodoArbol BuscarDato(int dato)
        {
            NodoArbol NodoRecorrido = nodoRaiz;

            while(NodoRecorrido.Dato != dato)
            {
                if(dato < NodoRecorrido.Dato)
                {
                    NodoRecorrido = NodoRecorrido.RamaIzquierda;
                }
                else
                {
                    NodoRecorrido = NodoRecorrido.RamaDerecha;
                }
                if(NodoRecorrido == null)//SI NO ENCUENTRA NADA
                {
                    return null;
                }
            }

            return NodoRecorrido;

        }



        public void BorrarMenor()
        {
            if (nodoRaiz == null) // SI EL ARBOL ESTA VACIO
            {
                Console.Write("......ARBOL ACTUALMENTE VACIO........");
            }
            else// SI EXISTEN DATOS EN EL ARBOL
            {
                if(nodoRaiz != null)// SE HACE EL RECORRIDO EN EL ARBOL
                {

                    if (nodoRaiz.RamaIzquierda == null)//SI EL DATO MENOR ES LA RAIZ SE ELIMINA REDIRECCIONANDO LAS RAMAS
                    {
                        nodoRaiz = nodoRaiz.RamaDerecha;
                    }
                    else//SI EL DATO MENOR NO ES LA RAIZ SE HACE EL RECORRIDO HASTA ENCONTRAR EL MENOR Y ELIMINARLO
                    {
                        NodoArbol NodoAtras = nodoRaiz;
                        NodoArbol NodoRecorrido = nodoRaiz.RamaIzquierda;

                        while(NodoRecorrido.RamaIzquierda != null)
                        {
                            NodoAtras = NodoRecorrido;
                            NodoRecorrido = NodoRecorrido.RamaIzquierda;
                        }
                        NodoAtras.RamaIzquierda = NodoRecorrido.RamaDerecha;
                    }
                    Console.WriteLine("\nSE ELIMINO' EL DATO MENOR DEL ARBOL");
                }


            }
        }//FIN DEL METODO

        public void BorrarMayor()
        {
            if (nodoRaiz == null) // SI EL ARBOL ESTA VACIO
            {
                Console.Write("........ARBOL ACTUALMENTE VACIO.........");
            }
            else// SI EXISTEN DATOS EN EL ARBOL
            {
                if (nodoRaiz != null)// SE HACE EL RECORRIDO EN EL ARBOL
                {

                    if (nodoRaiz.RamaDerecha == null)//SI EL DATO MAYOR ES LA RAIZ SE ELIMINA REDIRECCIONANDO LAS RAMAS
                    {
                        nodoRaiz = nodoRaiz.RamaIzquierda;
                    }
                    else //SI EL DATO MENOR NO ES LA RAIZ SE HACE EL RECORRIDO HASTA ENCONTRAR EL MENOR Y ELIMINARLO
                    {
                        NodoArbol NodoAtras = nodoRaiz;
                        NodoArbol NodoRecorrido = nodoRaiz.RamaDerecha;

                        while (NodoRecorrido.RamaDerecha != null)
                        {
                            NodoAtras = NodoRecorrido;
                            NodoRecorrido = NodoRecorrido.RamaDerecha;
                        }
                        NodoAtras.RamaDerecha = NodoRecorrido.RamaIzquierda;
                    }
                    Console.WriteLine("SE ELIMINO' EL DATO MAYOR DEL ARBOL");
                }


            }
        }//FIN DEL METODO

        public Boolean EliminarDato()
        {
            if (nodoRaiz == null) // SI EL ARBOL ESTA VACIO
            {
                Console.Write(".........ARBOL ACTUALMENTE VACIO.........");
            }
            else if (BuscarDato(dato) == null)
            {
                Console.WriteLine("EL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A ELIMINAR:   ");
                dato = Convert.ToInt32(Console.ReadLine());

                NodoArbol NodoRecorrido = nodoRaiz;
                NodoArbol NodoPadre = nodoRaiz;
                Boolean HijoIzquierdo = true;
                
                while(NodoRecorrido.Dato != dato)//SE HACE LA BUSQUEDA EN EL ARBOL
                {
                    NodoPadre = NodoRecorrido;

                    if(dato < NodoRecorrido.Dato)//SI EL DATO ES MENOR QUE LA RAIZ SE HACE EL RECORRIDO POR LA IZQUIERDA
                    {
                        HijoIzquierdo = true;
                        NodoRecorrido = NodoRecorrido.RamaIzquierda;
                    }
                    else //SI EL DATO ES MAYOR QUE LA RAIZ SE HACE EL RECORRIDO POR LA DERECHA
                    {
                        HijoIzquierdo = false;
                        NodoRecorrido = NodoRecorrido.RamaDerecha;
                    }

                }

                if(NodoRecorrido.RamaIzquierda == null && NodoRecorrido.RamaDerecha == null)//SI EL NODO ES HOJA O UNICO NODO
                {
                    if(NodoRecorrido == nodoRaiz) //SI EL NODO A ELIMINAR ES LA RAIZ
                    {
                        nodoRaiz = null;
                    }
                    else if(HijoIzquierdo)// SI ES NODO HOJA Y ES MENOR A LA RAIZ
                    {
                        NodoPadre.RamaIzquierda = null;
                    }
                    else // SI ES NODO HOJA Y ES MAYOR A LA RAIZ
                    {
                        NodoPadre.RamaDerecha = null;
                    }
                }

                else if(NodoRecorrido.RamaDerecha == null) // SI EL DATO A ELIMINAR NO ES HOJA Y TIENE RAMA IZQUIERDA
                {
                    if (NodoRecorrido == nodoRaiz) //SI EL NODO A ELIMINAR ES LA RAIZ
                    {
                        nodoRaiz = NodoRecorrido.RamaIzquierda;
                    }
                    else if (HijoIzquierdo)
                    {
                        NodoPadre.RamaIzquierda = NodoRecorrido.RamaIzquierda;
                    }
                    else 
                    {
                        NodoPadre.RamaDerecha = NodoRecorrido.RamaIzquierda;
                    }
                }

                else if (NodoRecorrido.RamaIzquierda == null) // SI EL DATO A ELIMINAR NO ES HOJA Y TIENE RAMA DERECHA
                {
                    if (NodoRecorrido == nodoRaiz) //SI EL NODO A ELIMINAR ES LA RAIZ
                    {
                        nodoRaiz = NodoRecorrido.RamaDerecha;
                    }
                    else if (HijoIzquierdo)
                    {
                        NodoPadre.RamaIzquierda = NodoRecorrido.RamaDerecha;
                    }
                    else
                    {
                        NodoPadre.RamaDerecha = NodoRecorrido.RamaIzquierda;
                    }
                }

                else //SI EL DATO A ELIMINAR NO ES HOJA, TAMPOCO TIENE UNA UNICA RAMA
                {
                    NodoArbol NodoReemplazo = ObtenerNodoReemplazo(NodoRecorrido);

                    if(NodoRecorrido == nodoRaiz)
                    {
                        nodoRaiz = NodoReemplazo;
                    }
                    else if(HijoIzquierdo)
                    {
                        NodoPadre.RamaIzquierda = NodoReemplazo;
                    }
                    else
                    {
                        NodoPadre.RamaDerecha = NodoReemplazo;
                    }

                    NodoReemplazo.RamaIzquierda = NodoRecorrido.RamaIzquierda;

                }
            }

            return true;

        }//FIN METODO ELIMINAR

        public NodoArbol ObtenerNodoReemplazo(NodoArbol NodoReemp)//METODO PARA REEMPLAZAR DATO A ELIMINAR
        {
            NodoArbol NodoReemplazoPadre = NodoReemp;
            NodoArbol NodoReemplazo = NodoReemp;
            NodoArbol NodoRecorrido = NodoReemp.RamaDerecha;

            while(NodoRecorrido != null)
            {
                NodoReemplazoPadre = NodoReemplazo;
                NodoReemplazo = NodoRecorrido;
                NodoRecorrido = NodoRecorrido.RamaIzquierda;
            }

            if(NodoReemplazo != NodoReemp.RamaDerecha)//PARA REACOMODAR LOS NODOS DEL ARBOL
            {
                NodoReemplazoPadre.RamaIzquierda = NodoReemplazo.RamaDerecha;
                NodoReemplazo.RamaDerecha = NodoReemp.RamaDerecha;
            }

            Console.WriteLine("\nEL NODO REEMPLAZO DEL NODO ELIMINADO ES:  " + NodoReemplazo.Dato + "\nSU NOMBRE ES:  " + NodoReemplazo.Nombre);

            return NodoReemplazo;

        }


        public void EsRaiz()//METODO PARA MOSTRAR LA RAIZ DEL ARBOL
        {
            if (nodoRaiz == null) // SI EL ARBOL ESTA VACIO
            {
                Console.Write(".......ARBOL ACTUALMENTE VACIO..........");
            }
            
            else //SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
            {
                Console.WriteLine("LA RAIZ DEL ARBOL ES:  ->  " + nodoRaiz.Dato + "  " + "\nSU NOMBRE ES:  " + nodoRaiz.Nombre);
            }
        }





        public void DescendientesDeX()//METODO PARA MOSTRAR LOS DESCENDIENTES DE X DATO (HIJOS)
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write(".........ARBOL ACTUALMENTE VACIO...........");
            }
            else
            {

                Console.WriteLine("\n\nINGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SUS DESCENDIENTES (HIJOS):   ");
                dato = Convert.ToInt32(Console.ReadLine());

                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    if(nodoRaiz.RamaIzquierda == null && nodoRaiz.RamaDerecha == null)
                    {
                        Console.WriteLine("\nEL ARBOL TIENE UN UNICO DATO, NO HAY DESCENDIENTES");
                    }
                    else if (nodoRaiz.RamaDerecha == null)
                    {
                        Console.WriteLine("EL DATO SELECCIONADO ES LA RAIZ, TIENE UN SOLO DESCENDIENTE Y ES MENOR QUE LA RAIZ\n");
                        Console.WriteLine("\nEL DESCENDIENTE DE:  " + nodoRaiz.Dato + "  " + nodoRaiz.Nombre + "  ES:  " + nodoRaiz.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + nodoRaiz.RamaIzquierda.Nombre);
                    }
                    else if (nodoRaiz.RamaIzquierda == null)
                    {
                        Console.WriteLine("EL DATO SELECCIONADO ES LA RAIZ, TIENE UN SOLO DESCENDIENTE Y ES MAYOR QUE LA RAIZ\n");
                        Console.WriteLine("EL DESCENDIENTE DE:  " + nodoRaiz.Dato + "  " + nodoRaiz.Nombre + "  ES:  " + nodoRaiz.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + nodoRaiz.RamaDerecha.Nombre);
                    }
                    else
                    {
                        Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nES LA RAIZ DEL ARBOL:  ->  " + nodoRaiz.Dato + "  " + "\nSU NOMBRE ES:  " + nodoRaiz.Nombre);
                        Console.WriteLine("EL PRIMER DESCENDIENTE ES:  " + nodoRaiz.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + nodoRaiz.RamaIzquierda.Nombre);
                        Console.WriteLine("EL SEGUNDO DESCENDIENTE ES:  " + nodoRaiz.RamaDerecha.Dato + "\nSU NOMBRE ES  " + nodoRaiz.RamaDerecha.Nombre);
                        
                    }
                }

                else//SI EL DATO NO ES LA RAIZ
                {
                    if( BuscarDato(dato) == null)
                    {
                        Console.WriteLine("EL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                        
                    else
                    {
                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {
                            if (dato < NodoRecorrido.Dato)
                            {
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if(NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if (NodoRecorrido.RamaIzquierda == null && NodoRecorrido.RamaDerecha == null)
                        {
                            Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  -> " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO EL DATO NO TIENE DESCENDIENTES");
                        }
                        else if (NodoRecorrido.RamaDerecha == null)
                        {
                            Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO SELECCIONADO, TIENE UN SOLO DESCENDIENTE");
                            Console.WriteLine("\nTIENE UN SOLO DESCENDIENTE Y ES:  " + NodoRecorrido.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.RamaIzquierda.Nombre);
                        }
                        else if (NodoRecorrido.RamaIzquierda == null)
                        {
                            Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO SELECCIONADO, TIENE UN SOLO DESCENDIENTE");
                            Console.WriteLine("\nTIENE UN SOLO DESCENDIENTE Y ES:  " + NodoRecorrido.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.RamaDerecha.Nombre);
                        }
                        else
                        {
                            Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL PRIMER DESCENDIENTE ES:  " + NodoRecorrido.RamaIzquierda.Dato + "  SU NOMBRE ES  " + NodoRecorrido.RamaIzquierda.Nombre);
                            Console.WriteLine("\nEL SEGUNDO DESCENDIENTE ES:  " + NodoRecorrido.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.RamaDerecha.Nombre);
                        }
                    }
                }

            }

        }


        public void AntecesorDeY()//METODO PARA MOSTRAR EL ANTECESOR DE Y DATO (PADRE)
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("ARBOL ACTUALMENTE VACIO");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU ANTECESOR (PADRE):  ");
                dato = Convert.ToInt32(Console.ReadLine());

                

                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                        Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, NO HAY ANTECESOR");                   
                }

                else
                {
                    if( BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                    else
                    {
                    NodoRecorrido = nodoRaiz;
                    
                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {
                            if (dato < NodoRecorrido.Dato)
                            {
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if(NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        Console.WriteLine("EL VALOR BUSCADO: " + dato + "\nSE ENCUENTRA EN EL NODO  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                        Console.WriteLine("\nEL ANTECESOR (PADRE) DEL DATO ES:  " + NodoAnterior.Dato + "\nSU NOMBRE ES:  " + NodoAnterior.Nombre);

                    }

                }
            }
        }//FIN DEL METODO

        public void NodosInteriores(NodoArbol NodoRecorrido)//NODOS QUE NO SON LA RAIZ Y TAMPOCO HOJA
        {

            if(NodoRecorrido != null)
            {
                NodosInteriores(NodoRecorrido.RamaIzquierda);
                NodosInteriores(NodoRecorrido.RamaDerecha);

                if(NodoRecorrido != nodoRaiz && NodoRecorrido.RamaIzquierda != null)
                {
                    Cantidad++;
                    Console.WriteLine("\nEL VALOR QUE SE ENCUENTRA EN EL ARBOL: ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre + "\nES NODO INTERIOR:  ");
                    //Console.WriteLine("CANTIDAD DE NODOS INTERIORES\t" + Cantidad);
                }
                else if (NodoRecorrido != nodoRaiz && NodoRecorrido.RamaDerecha != null)
                {
                    Cantidad++;
                    Console.WriteLine("\nEL VALOR QUE SE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre + "\nES NODO INTERIOR");
                }

            }
        }

        public int NodosInteriores()
        {
            Cantidad = 0;
            NodosInteriores(nodoRaiz);
            return Cantidad;
        }




        public void GradoDeUnNodo()
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("ARBOL ACTUALMENTE VACIO");
            }
            else
            {

                Console.WriteLine("\nINGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU GRADO:");
                dato = Convert.ToInt32(Console.ReadLine());

                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    if (nodoRaiz.RamaIzquierda == null && nodoRaiz.RamaDerecha == null)
                    {
                        Cantidad = 0;
                        Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ DEL ARBOL \nEL ARBOL TIENE UN UNICO DATO, EL GRADO DEL NODO:  " + nodoRaiz.Dato + "\nCON NOMBRE:  " + nodoRaiz.Nombre + "\nES...  " + Cantidad);
                    }
                    else if (nodoRaiz.RamaDerecha == null)
                    {
                        Cantidad = 1;
                        Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, LA RAIZ TIENE UN SOLO DESCENDIENTE DIRECTO Y ES MENOR QUE LA RAIZ  ");
                        Console.WriteLine("\nEL GRADO DEL NODO:  " + nodoRaiz.Dato + "\nCON NOMBRE:  " + nodoRaiz.Nombre + "\nES...  " + Cantidad);
                    }
                    else if (nodoRaiz.RamaIzquierda == null)
                    {
                        Cantidad = 1;
                        Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, LA RAIZ TIENE UN SOLO DESCENDIENTE DIRECTO Y ES MAYOR QUE LA RAIZ");
                        Console.WriteLine("\nEL GRADO DEL NODO:  " + nodoRaiz.Dato + "\nCON NOMBRE:  " + nodoRaiz.Nombre + "\nES...  " + Cantidad);
                    }
                    else
                    {
                        Cantidad = 2;
                        Console.WriteLine("\nEL DATO SELECCIONADO:  " + dato + "\nES LA RAIZ DEL ARBOL:   ->  " + nodoRaiz.Dato + "  " + "\nSU NOMBRE ES:  " + nodoRaiz.Nombre);
                        Console.WriteLine("\nEL GRADO DEL NODO:  " + nodoRaiz.Dato + "\nCON NOMBRE:  " + nodoRaiz.Nombre + "\nES...  " + Cantidad);
                    }
                }

                else//SI EL DATO NO ES LA RAIZ
                {
                    if (BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO.  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }

                    else
                    {
                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {
                            if (dato < NodoRecorrido.Dato)
                            {
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if (NodoRecorrido.RamaIzquierda == null && NodoRecorrido.RamaDerecha == null)
                        {
                            Cantidad = 0;
                            Console.WriteLine("\nEL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO EL DATO NO TIENE DESCENDIENTES DIRECTOS. EL GRADO DEL NODO ES:  " + Cantidad);
                        }
                        else if (NodoRecorrido.RamaDerecha == null)
                        {
                            Cantidad = 1;
                            Console.WriteLine("\nEL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO SELECCIONADO, TIENE UN SOLO DESCENDIENTE DIRECTO");
                            Console.WriteLine("\nEL GRADO DEL NODO ES:  " + Cantidad);
                        }
                        else if (NodoRecorrido.RamaIzquierda == null)
                        {
                            Cantidad = 1;
                            Console.WriteLine("\nEL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO SELECCIONADO, TIENE UN SOLO DESCENDIENTE DIRECTO");
                            Console.WriteLine("\nEL GRADO DEL NODO ES:  " + Cantidad);
                        }
                        else
                        {
                            Cantidad = 2;
                            Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO SELECCIONADO, TIENE DOS DESCENDIENTES DIRECTOS");
                            Console.WriteLine("\nEL GRADO DEL NODO ES:  " + Cantidad);
                        }
                    }
                }

            }
        }//FIN DEL METODO GRADO DE UN NODO




        public void GradoDelArbol()
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("........ARBOL ACTUALMENTE VACIO........");
            }
            else
            {
                if(Grado1 == true && Grado2 == true)
                {
                    Cantidad = 2;
                    Console.WriteLine("\nEL GRADO DEL ARBOL ES:  " + Cantidad );
                }
                else if (Grado1 == true && Grado2 == false)
                {
                    Cantidad = 1;
                    Console.WriteLine("\nEL GRADO DEL ARBOL ES:  " + Cantidad);
                }
                else if (Grado1 == false && Grado2 == true)
                {
                    Cantidad = 1;
                    Console.WriteLine("\nEL GRADO DEL ARBOL ES:  " + Cantidad);
                }
                else
                {
                    Cantidad = 0;
                    Console.WriteLine("\nEL GRADO DEL ARBOL ES:  " + Cantidad);
                }
            }
        }
        

        public void NivelDeUnNodo()
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write(".....ARBOL ACTUALMENTE VACIO........");
            }

            else
            {
                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU NIVEL:   ");
                dato = Convert.ToInt32(Console.ReadLine());

                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                        Cantidad = 1;
                        Console.WriteLine("EL DATO SELECCIONADO ES LA RAIZ DEL ARBOL:  " + nodoRaiz.Dato + "\nCON NOMBRE:  " + nodoRaiz.Nombre + "\nEL ARBOL POR DEFINICION TIENE NIVEL: " + Cantidad);
                }

                else
                {

                    if (BuscarDato(dato) == null)
                    {
                    Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL:");
                    }

                    else
                    {
                        
                        NodoRecorrido = nodoRaiz;
                        Cantidad = 1;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {
                            if (dato < NodoRecorrido.Dato)
                            {
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                                Cantidad++;
                            }
                            else
                            {
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                                Cantidad++;
                            }
                        }
                        Encontrado = false;
                  
                        Console.WriteLine("EL DATO SELECCIONADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                        Console.WriteLine("\nEL NIVEL DEL DATO ES:  " + Cantidad );
                    }

                }
            }
        }//TERMINA EL METODO


        private void AlturaDelArbol(NodoArbol NodoRecorrido, int Nivel)
        {
            if (NodoRecorrido != null)
            {
                AlturaDelArbol(NodoRecorrido.RamaIzquierda, Nivel + 1);
                if (Nivel > Altura)
                {
                    Altura = Nivel;
                }
                AlturaDelArbol(NodoRecorrido.RamaDerecha, Nivel + 1);
            }

        }

        public int AlturaDelArbol()
        {
            Altura = 0;
            AlturaDelArbol(nodoRaiz, 1);
            return Altura;
        }



        public void Abuelo()//METODO PARA MOSTRAR EL ABUELO DEL DATO
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("........ARBOL ACTUALMENTE VACIO..........");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU ABUELO:  ");
                dato = Convert.ToInt32(Console.ReadLine());



                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, NO TIENE ANTECESOR EN EL ARBOL. POR LO TANTO NO TIENE ABUELO");
                }

                else
                {
                    if (BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                    else
                    {
                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {

                            Cantidad++;

                            if (dato < NodoRecorrido.Dato)
                            {
                                if(Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                if (Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if (NodoAbuelo == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE ABUELO (A) ");
                        }
                        else if (NodoRecorrido == nodoRaiz)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE ABUELO (A) ");
                        }
                        else
                        { 
                        Console.WriteLine("EL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                        Console.WriteLine("\nEL ABUELO DEL DATO ES:  " + NodoAbuelo.Dato + "\nSU NOMBRE ES:  " + NodoAbuelo.Nombre);
                        }
                    }

                }
            }
        }//FIN DEL METODO



        public void Tio()//METODO PARA MOSTRAR EL TIO DEL DATO
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("....ARBOL ACTUALMENTE VACIO...........");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU TIO:");
                dato = Convert.ToInt32(Console.ReadLine());



                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, NO TIENE ANTECESOR EN EL ARBOL. POR LO TANTO NO TIENE TIO(S)");
                }

                else
                {
                    if (BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                    else
                    {
                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {

                            Cantidad++;

                            if (dato < NodoRecorrido.Dato)
                            {
                                if (Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                if (Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if (NodoAbuelo == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE TIO (AS) PORQUE NO TIENE UN ABUELO EN EL ARBOL");
                        }
                        else if (NodoAbuelo.RamaIzquierda == NodoAnterior && NodoAbuelo.RamaDerecha != null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL TIO DEL DATO ES:  " + NodoAbuelo.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + NodoAbuelo.RamaDerecha.Nombre);
                        }
                        else if (NodoAbuelo.RamaDerecha == NodoAnterior && NodoAbuelo.RamaIzquierda != null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                           Console.WriteLine("\nEL TIO DEL DATO ES:  " + NodoAbuelo.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + NodoAbuelo.RamaIzquierda.Nombre);
                        }
                        else if (NodoAbuelo.RamaDerecha == NodoAnterior && NodoAbuelo.RamaIzquierda == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE TIO (AS) PORQUE EL PAPA NO TIENE HERMANOS");
                        }
                        else if (NodoAbuelo.RamaIzquierda == NodoAnterior && NodoAbuelo.RamaDerecha == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE TIO (AS) PORQUE EL PAPA NO TIENE HERMANOS");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("EL VALOR BUSCADO  " + dato + "  SE ENCUENTRA EN EL ARBOL ===>  " + NodoRecorrido.Dato + "  SU NOMBRE ES  " + NodoRecorrido.Nombre);
                            //    Console.WriteLine("PERO NO TIENE TIO (AS) PORQUE EL PAPA NO TIENE HERMANOS");
                            //}
                        }

                    }
                }
            }
        }//FIN DEL METODO


        public void Sobrinos()//METODO PARA MOSTRAR EL ANTECESOR DE Y DATO (PADRE)
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write("ARBOL ACTUALMENTE VACIO");
            }
            else
            {

                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU(S) SOBRINO(S):");
                dato = Convert.ToInt32(Console.ReadLine());



                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    Console.WriteLine("\nEL DATO SELECCIONADO ES LA RAIZ, NO TIENE ANTECESOR EN EL ARBOL." + "\nPOR LO TANTO NO TIENE UN HERMANO Y TAMPOCO SOBRINO(S)");
                }

                else
                {
                    if (BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                    else
                    {
                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {
                            if (dato < NodoRecorrido.Dato)
                            {
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                NodoHermano = NodoAnterior.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                NodoHermano = NodoAnterior.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if(NodoHermano == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO NO TIENE SOBRINOS PORQUE NO TIENE HERMANOS");
                        }
                        else if (NodoHermano.RamaIzquierda == null && NodoHermano.RamaDerecha == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL DATO NO TIENE SOBRINOS PORQUE TIENE HERMANO, PERO EL HERMANO NO TIENE HIJOS");
                        }
                        else if (NodoHermano.RamaIzquierda == null && NodoHermano.RamaDerecha != null)
                        { 
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                        Console.WriteLine("\nEL SOBRINO DEL DATO ES:  " + NodoHermano.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + NodoHermano.RamaDerecha.Dato);
                        }
                        else if (NodoHermano.RamaIzquierda != null && NodoHermano.RamaDerecha == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL SOBRINO DEL DATO ES:  " + NodoHermano.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + NodoHermano.RamaIzquierda.Dato);
                        }
                        else
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:    ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL PRIMER SOBRINO DEL DATO ES:  " + NodoHermano.RamaIzquierda.Dato + "\nSU NOMBRE ES:  " + NodoHermano.RamaIzquierda.Dato);
                            Console.WriteLine("\nEL SEGUNDO SOBRINO DEL DATO ES:  " + NodoHermano.RamaDerecha.Dato + "\nSU NOMBRE ES:  " + NodoHermano.RamaDerecha.Dato);
                        }
                    }

                }
            }
        }//FIN DEL METODO


        public void Primos()
        {
            if (nodoRaiz == null)//SI EL ARBOL ESTA VACIO
            {
                Console.Write(".....ARBOL ACTUALMENTE VACIO........");
            }
            else
            {
                Console.WriteLine("INGRESE EL VALOR DEL DATO A BUSCAR PARA MOSTRAR SU(S) SOBRINO(S):   ");
                dato = Convert.ToInt32(Console.ReadLine());



                if (dato == nodoRaiz.Dato)//SI EL DATO BUSCADO ES LA RAIZ DEL ARBOL
                {
                    Console.WriteLine("EL DATO SELECCIONADO ES LA RAIZ, NO TIENE ANTECESOR EN EL ARBOL." + "\nPOR LO TANTO NO TIENE UN HERMANO Y TAMPOCO SOBRINO(S)");
                }
                else
                {
                    if (BuscarDato(dato) == null)
                    {
                        Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nNO SE ENCUENTRA EN EL ARBOL");
                    }
                    else
                    {

                        NodoRecorrido = nodoRaiz;

                        while (NodoRecorrido.Dato != dato && Encontrado == false)
                        {

                            Cantidad++;

                            if (dato < NodoRecorrido.Dato)
                            {
                                if (Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                    NodoTio = NodoAbuelo.RamaDerecha;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaIzquierda;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                            else
                            {
                                if (Cantidad > 1)
                                {
                                    NodoAbuelo = NodoAnterior;
                                    NodoTio = NodoAbuelo.RamaDerecha;
                                }
                                NodoAnterior = NodoRecorrido;
                                NodoRecorrido = NodoRecorrido.RamaDerecha;
                                if (NodoRecorrido.Dato == dato)
                                {
                                    Encontrado = true;
                                }
                            }
                        }
                        Encontrado = false;

                        if (NodoAbuelo == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE ABUELO (A) EN EL ARBOL, POR LO TANTO NO TIENE TIO NI SOBRINOS");
                        }
                        else if (NodoTio == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nPERO NO TIENE ABUELO (A) EN EL ARBOL, POR LO TANTO NO TIENE TIO NI SOBRINOS");
                        }
                        else if(NodoTio.RamaIzquierda == null && NodoTio.RamaDerecha == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL NODO TIENE ABUELO Y TIO, PERO EL TIO NO TIENE HIJO. POR LO TANTO NO TIENE PRIMOS");
                        }
                        else if(NodoTio.RamaIzquierda != null && NodoTio.RamaDerecha == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:  ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL NODO TIENE ABUELO Y TIO, PERO EL TIO TIENE UN SOLO HIJO. EL PRIMO DEL NODO ES...  " + NodoTio.RamaIzquierda.Dato + "\nCON NOMBRE  " + NodoTio.RamaIzquierda.Nombre);
                        }
                        else if (NodoTio.RamaDerecha != null && NodoTio.RamaIzquierda == null)
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL NODO TIENE ABUELO Y TIO, PERO EL TIO TIENE UN SOLO HIJO. EL PRIMO DEL NODO ES...  " + NodoTio.RamaDerecha.Dato + "\nCON NOMBRE:  " + NodoTio.RamaDerecha.Nombre);
                        }
                        else
                        {
                            Console.WriteLine("\nEL VALOR BUSCADO:  " + dato + "\nSE ENCUENTRA EN EL NODO:   ->  " + NodoRecorrido.Dato + "\nSU NOMBRE ES:  " + NodoRecorrido.Nombre);
                            Console.WriteLine("\nEL NODO TIENE ABUELO Y TIO, EL TIO DOS HIJOS. EL PRIMER PRIMO DEL NODO ES...  " + NodoTio.RamaIzquierda.Dato + "\nCON NOMBRE:  " + NodoTio.RamaIzquierda.Nombre);
                            Console.WriteLine("\nEL NODO TIENE ABUELO Y TIO, EL TIO DOS HIJOS. EL SEGUNDO PRIMO DEL NODO ES...  " + NodoTio.RamaDerecha.Dato + "\nCON NOMBRE:  " + NodoTio.RamaDerecha.Nombre);
                        }

                    }

                }

            }
        }//TERMINA EL METODO

    }
        

    }
