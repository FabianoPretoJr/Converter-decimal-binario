using System;

namespace binario
{
    class Program
    {
        static void Main(string[] args)
        {
            float a, b;
            float[,] arr = new float[8, 12];
            float[,] arr2 = new float[8, 12];
            double[] decAmenor = new double[8];
            double[] decAmaior = new double[8];
            double[] errAmenor = new double[8];
            double[] errAmaior = new double[8];
            int cont = 4;

            do
            {
                Console.Write("\n\n\tDigite um número decimal: ");
                a = float.Parse(Console.ReadLine());
            } while (a > 1 && a < 0);

            b = a;

            for (int i = 0; i <= 7; i++)
            {
                a = b;
                for (int i2 = 0; i2 <= cont; i2++)
                {
                    a = a * 2;

                    if (a > 1)
                    {
                        arr[i, i2] = 1;
                    }
                    else
                    {
                        arr[i, i2] = 0;
                    }
                    if (a > 1)
                    {
                        a = a - 1;
                    }
                }
                if (cont <= 11)
                {
                    cont++;
                }
            }

            //cont = 4;
            //int bits = 5;

            //for (int j = 0; j <= 7; j++)
            //{
            //    Console.Write("\n\n" + bits + " bits: ");

            //    for (int j2 = 0; j2 <= cont; j2++)
            //    {
            //        Console.Write(arr[j, j2]);
            //    }
            //    if (cont <= 11)
            //    {
            //        cont++;
            //    }
            //    bits++;
            //}

            //Console.Write("\n\n\n\n");

            int cont2 = 11;

            for (int k = 7; k >= 0; k--)
            {
                int sobe = 0, adc = 1;

                for (int k2 = cont2; k2 >= 0; k2--)
                {
                    if (arr[k, k2] == 1 && adc == 1 && sobe == 0)
                    {
                        arr2[k, k2] = 0;
                        adc = 0;
                        sobe = 1;
                    }
                    else if (arr[k, k2] == 0 && adc == 1 && sobe == 0)
                    {
                        arr2[k, k2] = 1;
                        adc = 0;
                        sobe = 0;
                    }
                    else if (arr[k, k2] == 1 && adc == 0 && sobe == 1)
                    {
                        arr2[k, k2] = 0;
                        sobe = 1;
                    }
                    else if (arr[k, k2] == 0 && adc == 0 && sobe == 1)
                    {
                        arr2[k, k2] = 1;
                        sobe = 0;
                    }
                    else if (arr[k, k2] == 1 && adc == 0 && sobe == 0)
                    {
                        arr2[k, k2] = 1;
                        sobe = 0;
                    }
                    else if (arr[k, k2] == 0 && adc == 0 && sobe == 0)
                    {
                        arr2[k, k2] = 0;
                        sobe = 0;
                    }
                }
                cont2--;
            }

            //cont = 4;
            //int aMaior = 5;

            //for (int j3 = 0; j3 <= 7; j3++)
            //{              
            //    Console.Write("\n\naMaior " + aMaior + " bits: ");

            //    for (int j4 = 0; j4 <= cont; j4++)
            //    {
            //        Console.Write(arr2[j3, j4]);
            //    }
            //    if (cont <= 11)
            //    {
            //        cont++;
            //    }
            //    aMaior++;
            //}

            cont = 4;
            double bin = -1, fdc = 2, acum = 0, acum2 = 0;

            for (int m = 0; m <= 7; m++)
            {
                for (int m2 = 0; m2 <= cont; m2++)
                {
                    if (arr[m, m2] == 1)
                    {
                        acum = acum + Math.Pow(fdc, bin);
                    }
                    if (arr2[m, m2] == 1)
                    {
                        acum2 = acum2 + Math.Pow(fdc, bin);
                    }
                    bin--;
                }
                decAmenor[m] = acum;
                decAmaior[m] = acum2;
                if (cont <= 11)
                {
                    cont++;
                }
            }

            //Console.Write("\n\n\n\n");

            //for(int n = 0; n <= 7; n++)
            //{
            //    Console.WriteLine("\n\naMenor decimal: " + decAmenor[n]);
            //    Console.WriteLine("aMaior decimal: " + decAmaior[n]);
            //}

            //Console.Write("\n\n\n\n");

            for (int p = 0; p <= 7; p++)
            {
                double x = ((b - decAmenor[p]) / b) * 100;
                if (x < 0)
                {
                    errAmenor[p] = x * -1;
                }
                else
                {
                    errAmenor[p] = x;
                }

                double y = ((b - decAmaior[p]) / b) * 100;
                if (y < 0)
                {
                    errAmaior[p] = y * -1;
                }
                else
                {
                    errAmaior[p] = y;
                }
                //Console.WriteLine("\n\nErr aMenor: " + errAmenor[p]);
                //Console.WriteLine("Err aMaior: " + errAmaior[p]);
            }

            cont = 4;
            int bits = 5;

            Console.WriteLine("\n\n\n\t<===R E S U L T A D O===>");

            for (int j = 0; j <= 7; j++)
            {
                Console.WriteLine("\n\n\n\tCom " + bits + " bits ");
                Console.Write("\n\tAproximação aMenor: ");
                for (int j2 = 0; j2 <= cont; j2++)
                {
                    Console.Write(arr[j, j2]);
                }
                Console.Write(" -> " + decAmenor[j] + " com erro = " + errAmenor[j]);

                Console.Write("\n\tAproximação aMaior: ");
                for (int j3 = 0; j3 <= cont; j3++)
                {
                    Console.Write(arr2[j, j3]);
                }
                Console.Write(" -> " + decAmaior[j] + " com erro = " + errAmaior[j]);

                if (cont <= 11)
                {
                    cont++;
                }
                bits++;
            }
            Console.ReadKey();
        }            
    }
}

