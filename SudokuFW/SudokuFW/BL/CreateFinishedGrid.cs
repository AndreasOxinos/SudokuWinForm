using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuW
{
    class CreateFinishedGrid
    {
       /// <summary>
       /// creates and returns a finished grid
       /// </summary>
        private int[,] _array = new int[9, 9];

        public int [,] _CreateGrid()
        {
            int flagendx = 0;
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int flagend ;
                    
                    {

                        int[] array = new int[9];
                        for (int x = 0; x < 9; x++)
                        {
                            int flag;
                            do
                            {

                                flag = 1;

                                int temp = random.Next(1, 10);

                                array[x] = temp;
                                for (int k = 0; k < x; k++)
                                {

                                    if (temp == array[k])
                                    {
                                        flag = 0;
                                        break;
                                    }
                                }
                            } while (flag == 0);
                        }

                        int[] arrayx = new int[9]; arrayx = array;
                        int[] arrayy = new int[9]; arrayy = array;
                        int[] arrayz = new int[9]; arrayz = array;

                        //xtest

                        for (int k = 0; k < 9; k++)
                            for (int p = 0; p < y; p++)
                                if (arrayx[k] == _array[i, p])
                                    arrayx[k] = 0;

                        //ytest

                        for (int k = 0; k < 9; k++)
                            for (int p = 0; p < i; p++)
                                if (arrayy[k] == _array[p, y])
                                    arrayy[k] = 0;

                        //btest

                        {
                            int ii = i;
                            int yy = y;
                            ii = ii - (ii % 3);
                            yy = yy - (yy % 3);

                            for (int k = 0; k < 9; k++)
                                for (int p = ii; p < (ii + 3 ); p++)
                                {
                                    for (int z = yy; z < (yy + 3 ); z++)
                                    {
                                        if ((z >= y) && (p >= i)) break;

                                        if (arrayz[k] == _array[p, z])
                                            arrayz[k] = 0;

                                    }

                                }
                        }
                        flagend = 1;
                        for (int k = 0; k < 9; k++)
                        {
                            if ((arrayz[k] == arrayx[k]) && (arrayz[k] == arrayy[k]) && (arrayx[k] == arrayy[k]) && (arrayx[k] != 0))
                            {
                                _array[i, y] = arrayx[k];
                                flagend = 0;
                                break;
                            }
                        }
                        if (flagend == 1)
                        {
                            flagendx++;
                            y = -1;
                            for (int k = 0; k < 9; k++)
                                _array[i, k] = 0;

                             
                             if (flagendx == 30)
                             {
                                 i = 0;
                                 for (int k = 0; k < 9; k++)
                                     _array[i, k] = 0;
                                 flagendx = 0;
                             }
                             


                        }
                    }
                  
            }
            }
            
            return _array;
        }

        
        public void print(int[,] a)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Console.Write(" "); Console.Write(a[i,x].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
