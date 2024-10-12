using System;

namespace Array2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task1

            Random rnd = new Random();
            int[] arr1 = new int[10];

            for (int i = 0; i < arr1.Length; i++)
                arr1[i] = rnd.Next(0, 5);

            foreach (int i in arr1)
                Console.Write(i + " ");

            Console.WriteLine();

            Array.Sort(arr1, (a, b) =>
            {
                return b.CompareTo(a);
            });

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == 0)
                    arr1[i] = -1;
            }

            foreach (int i in arr1)
                Console.Write(i + " ");

            Console.WriteLine();


            #endregion

            #region task2

            int arrsize;

            while (true)
            {
                Console.WriteLine("введите размер двумерного массива n:");
                arrsize = int.Parse(Console.ReadLine());

                if (arrsize % 2 == 0)
                    Console.WriteLine("размер массива должен быть нечетным. попробуйте еще раз");
                else
                    break;
            }


            int[,] arr2 = new int[arrsize, arrsize];

            int center = arrsize / 2;
            arr2[center, center] = 1;

            bool isstarted = false;





            string nextDirection = "right";
            (int, int) curPos = (center, center);
            int counter = 1;

            while (true)
            {
                if (!isstarted)
                {
                    curPos.Item2++;
                    arr2[curPos.Item1, curPos.Item2] = ++counter;
                    isstarted = true;
                    nextDirection = "top";
                }
                else
                {
                    if (nextDirection == "top")
                    {
                        if (curPos.Item1 - 1 >= 0 && arr2[curPos.Item1 - 1, curPos.Item2] == 0)
                        {
                            curPos.Item1--;
                            arr2[curPos.Item1, curPos.Item2] = ++counter;
                            nextDirection = "left";
                        }
                        else
                        {
                            if (curPos.Item2 + 1 != arr2.GetLength(1))
                                nextDirection = "right";

                            else
                                break;
                        }
                    }

                    else if (nextDirection == "left")
                    {
                        if (curPos.Item2 - 1 >= 0 && (arr2[curPos.Item1, curPos.Item2 - 1] == 0))
                        {
                            curPos.Item2--;
                            arr2[curPos.Item1, curPos.Item2] = ++counter;
                            nextDirection = "bottom";
                        }
                        else
                        {
                            if (curPos.Item1 - 1 != arr2.GetLength(0))

                                nextDirection = "top";
                            else
                                break;
                        }
                    }

                    else if (nextDirection == "bottom")
                    {
                        if (curPos.Item1 + 1 <= arr2.GetLength(0) && (arr2[curPos.Item1 + 1, curPos.Item2] == 0))
                        {
                            curPos.Item1++;
                            arr2[curPos.Item1, curPos.Item2] = ++counter;
                            nextDirection = "right";
                        }
                        else
                        {
                            if (curPos.Item2 - 1 != arr2.GetLength(1))
                                nextDirection = "left";

                            else
                                break;
                        }
                    }

                    else if (nextDirection == "right")
                    {
                        if (curPos.Item2 + 1 <= arr2.GetLength(1) && (arr2[curPos.Item1, curPos.Item2 + 1] == 0))
                        {
                            curPos.Item2++;
                            arr2[curPos.Item1, curPos.Item2] = ++counter;
                            nextDirection = "top";
                        }
                        else
                        {
                            if (curPos.Item1 + 1 != arr2.GetLength(0))
                                nextDirection = "bottom";

                            else
                                break;
                        }
                    }
                }
            }

            for (int i = 0; i < arrsize; i++)
            {
                for (int j = 0; j < arrsize; j++)
                    Console.Write($"{arr2[i, j],5}");
                Console.WriteLine();
            }


            #endregion

            #region Task3


            Console.WriteLine("Rows:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Cols:");
            int cols = int.Parse(Console.ReadLine());


            int[,] arr3 = new int[rows, cols];
            int[,] arr4 = new int[rows, cols];
            
            Random random = new Random();

            Console.WriteLine("Choose your shift:");
            int shift = int.Parse(Console.ReadLine());

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j< cols; j++)
                {
                    arr3[i, j] = random.Next(0, 100);
                    arr4[i, j] = 0;
                }
            }


            for(int i = 0;i<rows; i++)
            {
                for(int j = 0; j < cols; j++)
                  Console.Write($"{arr3[i, j],5}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();



            for (int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (i + shift >= cols)
                        arr4[j, i+shift-cols] = arr3[j, i];

                    else
                        arr4[j, i+shift] = arr3[j, i];

                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{arr4[i, j],5}");
                Console.WriteLine();
            }

            #endregion


        }
    }
}
