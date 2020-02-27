using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAndDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
             
            string mode = Initialization();
            while (string.Equals(mode, "0") || string.Equals(mode, "1"))
            {
                if(string.Equals(mode, "1")) ConvertBinaryToDecimal();
                else ConvertDecimalToBinary();

                mode = Initialization();
            }
        }

        static void ConvertBinaryToDecimal()
        {
            string eleccion = "1";
            while (string.Equals(eleccion, "1"))
            {

                Console.WriteLine("Introduzca un numero binario.");

                string input = Console.ReadLine();
                int inputLength = input.Length;
                int result = 0;
                int number;
                bool mostrarResultado = true;

                //Console.WriteLine("El tamano de el numero es: " + inputLength);

                int index = 0;
                for (int i = inputLength; i > 0; i--)
                {
                    //Console.WriteLine(input[i - 1]);
                    //bool isThereOne = string.Equals(input[i-1], '1');
                    //Console.WriteLine(" is a one?: " + isThereOne);
                    number = Convert.ToInt32(input[i - 1]);
                    if (string.Equals(input[i - 1], '1') || string.Equals(input[i - 1], '0'))
                    {

                        if (string.Equals(input[i - 1], '1'))
                        {
                            result += Convert.ToInt32(Math.Pow(2, Convert.ToDouble(index)));
                        }
                        index++;
                    }
                    else
                    {
                        Console.WriteLine("El numero especificado no es binario.");
                        mostrarResultado = false;
                        break;
                    }


                }

                if (mostrarResultado) Console.WriteLine("El resultado es: " + result);

                Console.WriteLine();
                Console.WriteLine("Quiere continuar calculando?");
                eleccion = Console.ReadLine();
            }
        }

        static void ConvertDecimalToBinary()
        {
            string eleccion = "1";

            while (string.Equals(eleccion, "1"))
            {
                Console.WriteLine("Porfavor introduzca un numero entero a convertir.");
                string numeroBinario = string.Empty;
                float numerodecimal = float.Parse( Console.ReadLine() );

                int quotient = 8;
                float resultado;
                while (quotient != 0)
                {
                    resultado = numerodecimal / 2;
                    quotient = Convert.ToInt32( Math.Truncate(resultado) ); //Dividr entre 2 despues
                    bool hayResiduo = ChecarSiHayResiduo(numerodecimal);

                    //Console.WriteLine("Hay residuo?" + hayResiduo);
                    //Console.WriteLine("La parte entera es: " + quotient);
                    //Console.WriteLine();

                    numerodecimal = quotient;
                    if (hayResiduo)
                    {
                        numeroBinario += "1";
                    }
                    else
                    {
                        numeroBinario += "0";
                    }


                }
                numeroBinario = ReverseString(numeroBinario);

                Console.WriteLine("Numero binario: " + numeroBinario);

                Console.WriteLine("Quiere seguir calculando?");
                eleccion = Console.ReadLine();
            }
        }

        static bool ChecarSiHayResiduo(float numerodecimal)
        {
            bool hayResiduo = false;
            float residuo = numerodecimal % 2;
            if (residuo != 0.0)
            {
                hayResiduo = true;
            }

            return hayResiduo;
        }

        static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }

        static string Initialization()
        {
            Console.WriteLine("Convertidor de decimal a Binario estas son las opciones: ");
            Console.WriteLine("[0] Convertor Decimal a Binario");
            Console.WriteLine("[1] Convertir Binario a Decimal");
            Console.WriteLine("Presione Cualquier otra tecla para salir del programa.");

            string mode = Console.ReadLine();

            return mode;
        }
    }
}
