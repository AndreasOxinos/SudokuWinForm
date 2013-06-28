using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuW
{
    class dugteam
    {
        private int[,] canbedug = new int[9, 9]; //keeps track of which cells can be dug
        private int filledcells = 81;
        /// <summary>
        /// gets the finished grid and based on the difficulty returns the prid to be solved,
        /// needs check for when array[0, 0] == 1 and array[0, 1] == 1 start over
        /// </summary>
        /// <param name="_array">the finished grid</param>
        /// <param name="difficulty">3 = hard 2 = medium 1 = easy</param>
        /// <returns></returns>
        public int [,]  dugarray (int [,] _array, int difficulty)
        {
            Solver solver = new Solver () ;


            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    canbedug[i, j] = 1;

            int originalnum;
            int flag;
            int nochange = 0;


            if (difficulty == 3)//3 = hard 2 = medium 1 = easy
            {
                while (filledcells > 28  && nochange == 0)//////////////// need to add a return if filled cells > 31 to redo, and add propagating
                {
                    nochange = 1;
                    for (int i = 0; i < 9; i++)
                    {

                        //if (filledcells == 35) break;
                        for (int j = 0; j < 9; j++)
                        {
                            if (canbedug[i,j] == 1) 
                            {
                            int[,] temp = new int[9, 9];
                            flag = 0;
                            originalnum = _array[i, j];

                            for (int k = 1; k < 10; k++)
                                if (k != originalnum)
                                {
                                    for (int i1 = 0; i1 < 9; i1++)
                                        for (int j1 = 0; j1 < 9; j1++)
                                            if (i == i1 && j == j1)
                                                temp[i1, j1] = k;
                                            else
                                                temp[i1, j1] = _array[i1, j1];

                                    if (solver._Solver(temp))
                                    {
                                        flag = 1;
                                        break;
                                    }
                                }
                            if (flag == 0)
                            {
                                canbedug[i, j] = 0;
                                nochange = 0;
                                _array[i, j] = 0;
                                filledcells--;
                            }
                        }

                            

                        }

                    }
                    /*
                    if (nochange == 1)
                    {
                        for (int i = 0; i < 9; i++)
                            for (int j = 0; j < 9; j++)
                                if (canbedug[i, j] == 1)
                                    nochange = 0;
                    }
                     */
                }

                


            }
            else if (difficulty == 2)
            {
                int jump = 0 ;
                while (filledcells > 39 && nochange == 0)//////////////// need to add a return if filled cells > 31 to redo, and add propagating
                {
                    nochange = 1;
                    for (int i = 0; i < 9; i++)
                    {

                        if (filledcells == 34) break;
                        for (int j = (((i % 2) + jump) % 2) ; j < 9; j = j + 2) //so we jump 1 cell each time and at the next search from the start we start from the other one
                        {
                            if (canbedug[i, j] == 1)
                            {

                                int[,] temp = new int[9, 9];
                                flag = 0;
                                originalnum = _array[i, j];

                                for (int k = 1; k < 10; k++)
                                    if (k != originalnum)
                                    {
                                        for (int i1 = 0; i1 < 9; i1++)
                                            for (int j1 = 0; j1 < 9; j1++)
                                                if (i == i1 && j == j1)
                                                    temp[i1, j1] = k;
                                                else
                                                    temp[i1, j1] = _array[i1, j1];

                                        if (solver._Solver(temp))
                                        {
                                            flag = 1;
                                            break;
                                        }
                                    }
                                if (flag == 0)
                                {
                                    int rowcolumngivenbound = 0;
                                    int tempmin = 20;
                                    for (int i1 = 0; i1 < 9; i1++)
                                    {
                                        if ((i1 != i) && (_array[i1, j] != 0))
                                            rowcolumngivenbound++;
                                        int tempminbound = 0;
                                        for (int j1 = 0; j1 < 9; j1++)
                                            if ((j1 != j) && (_array[i, j1] != 0))
                                                tempminbound++;
                                        if (tempmin >= tempminbound)
                                            tempmin = tempminbound;
                                    }
                                    rowcolumngivenbound = rowcolumngivenbound + tempmin;
                                    if (rowcolumngivenbound >= 4)
                                    {
                                        canbedug[i, j] = 0;
                                        nochange = 0;
                                        _array[i, j] = 0;
                                        filledcells--;
                                    }
                                    else
                                    {
                                        canbedug[i, j] = 0;

                                    }

                                }
                                if (filledcells == 34) break;
                            }

                        }

                    }
                    jump = ((jump + 1) % 2);
                }



            }
            else if (difficulty == 1)
            {
                
                Random random = new Random();
                while (filledcells > 40)//////////////// need to add a return if filled cells > 31 to redo, and add propagating
                {
                  
                    
                    int i = random.Next(0, 9);
                    int j = random.Next(0, 9);

                            if (canbedug[i, j] == 1)
                            {
                                int[,] temp = new int[9, 9];
                                flag = 0;
                                originalnum = _array[i, j];

                                for (int k = 1; k < 10; k++)
                                    if (k != originalnum)
                                    {
                                        for (int i1 = 0; i1 < 9; i1++)
                                            for (int j1 = 0; j1 < 9; j1++)
                                                if (i == i1 && j == j1)
                                                    temp[i1, j1] = k;
                                                else
                                                    temp[i1, j1] = _array[i1, j1];

                                        if (solver._Solver(temp))
                                        {
                                            flag = 1;
                                            break;
                                        }
                                    }
                                if (flag == 0)
                                {
                                    int rowcolumngivenbound = 0;
                                    int tempmin = 20;
                                    for (int i1 = 0; i1 < 9; i1++)
                                    {
                                        if ((i1 != i) && (_array[i1, j] != 0))
                                            rowcolumngivenbound++;
                                        int tempminbound = 0;
                                        for (int j1 = 0; j1 < 9; j1++)
                                            if ((j1 != j) && (_array[i, j1] != 0))
                                                tempminbound++;
                                        if (tempmin >= tempminbound)
                                            tempmin = tempminbound;
                                    }
                                    rowcolumngivenbound = rowcolumngivenbound + tempmin;
                                    if (rowcolumngivenbound >= 5)
                                    {
                                        canbedug[i, j] = 0;

                                        _array[i, j] = 0;
                                        filledcells--;
                                    }
                                }
                            }

                            //if (filledcells == 35) break;

                        
                }




            }

            if (filledcells > 31 && difficulty == 3)
            {
                _array[0, 0] = 1;
                _array[0, 1] = 1;
                return _array;
            }
            else return _array;

            

        }
        public void print(int[,] a)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Console.Write(" "); Console.Write(a[i, x].ToString());
                }
                Console.WriteLine();
            }
        }

    }
}
