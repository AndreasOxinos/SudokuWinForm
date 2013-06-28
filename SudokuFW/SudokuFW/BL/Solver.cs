using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuW
{
    class Solver
    {
        private int[, ,] _array = new int[9, 9, 10];
        private bool solutionfound;

        public bool _Solver(int[,] arraytobesolved)
        {
            //creating a 9*9*10 array with the intial values of the array to be solved, the rest with 1-9 numbers,
            //the first of the 10, holds the real value(0 mean not sure yet), the reset are the candidates
            int solutioncounter = 0; //counts how many real values are in the array

            int flag_arraytobesolved_isinvalid = 0;
            

            //checking if arraytobesolved is violating sudoku rules
            for (int i = 0 ; i < 9 ; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (flag_arraytobesolved_isinvalid == 1)
                        break;

                    int counterx = 0;
                    int countery = 0;
                    int counterbox = 0;
                    for (int k = 0; k < 9; k++)
                    {
                        if (arraytobesolved[i, j] == arraytobesolved[k, j] && arraytobesolved[i,j] != 0)
                            countery++ ;
                        if (arraytobesolved[i, j] == arraytobesolved[i, k] && arraytobesolved[i,j] != 0)
                            counterx++;
                    }

                    int ii = i;
                    int yy = j;
                    ii = ii - (ii % 3);
                    yy = yy - (yy % 3);


                    for (int p = ii; p < (ii + 3); p++)
                        for (int z = yy; z < (yy + 3); z++)
                            if (arraytobesolved[p, z] == arraytobesolved[i, j] && arraytobesolved[i, j] != 0)
                                counterbox++;

                    if ((counterbox == 2) || (counterx == 2) || (countery == 2))
                    {
                        flag_arraytobesolved_isinvalid = 1;
                        break;
                    }
                }


            //quit if arraytobesolved is violating the sudoku rules
            if (flag_arraytobesolved_isinvalid == 0)
            {



                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                        for (int p = 0; p < 10; p++)
                            _array[i, j, p] = p;


                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (arraytobesolved[i, j] != 0) //if there is a real value in the array, we remove it from each cell in column/row/box  cells candidates
                        {
                            _array[i, j, 0] = arraytobesolved[i, j];
                            solutioncounter++;

                            for (int k = 0; k < 9; k++)
                            {
                                _array[k, j, arraytobesolved[i, j]] = 0;
                                _array[i, k, arraytobesolved[i, j]] = 0;
                            }


                            int ii = i;
                            int yy = j;
                            ii = ii - (ii % 3);
                            yy = yy - (yy % 3);


                            for (int p = ii; p < (ii + 3); p++)
                                for (int z = yy; z < (yy + 3); z++)
                                    _array[p, z, arraytobesolved[i, j]] = 0;

                        }
                    }
                int nochanges = 1; //0 mean no changes
                while ((solutioncounter != 81) && (nochanges == 1))
                {
                    nochanges = 0;
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {

                            if (_array[i, j, 0] == 0)
                            {
                                int position = 0;
                                int candidatecounter = 0;
                                for (int z = 1; z < 10; z++)
                                    if (_array[i, j, z] != 0)
                                    {
                                        position = z;
                                        candidatecounter++;
                                    }
                                if (candidatecounter == 1)
                                {
                                    nochanges = 1;
                                    _array[i, j, 0] = _array[i, j, position];
                                    solutioncounter++;

                                    for (int k = 0; k < 9; k++)
                                    {
                                        _array[k, j, _array[i, j, 0]] = 0;
                                        _array[i, k, _array[i, j, 0]] = 0;
                                    }


                                    int ii = i;
                                    int yy = j;
                                    ii = ii - (ii % 3);
                                    yy = yy - (yy % 3);


                                    for (int p = ii; p < (ii + 3); p++)
                                        for (int z = yy; z < (yy + 3); z++)
                                            _array[p, z, _array[i, j, 0]] = 0;
                                }
                            }
                        }


                }

                // for the ablah cases
                if (nochanges == 0 && solutioncounter != 81)
                {

                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {

                            if (_array[i, j, 0] == 0)
                            {
                                int position = 0;
                                int candidatecounter = 0;
                                for (int z = 1; z < 10; z++)
                                    if (_array[i, j, z] != 0)
                                    {
                                        position = z;
                                        candidatecounter++;
                                    }
                                if (candidatecounter == 2) // if there is no change but we have 2 cells in same x/y/box then we have multible solutions
                                {
                                    int candidatecounterx = 0;
                                    int candidatecountery = 0;
                                    int candidatecounterbox = 0;
                                    for (int k = 0; k < 9; k++)
                                    {
                                        

                                        if (_array[k, j, 0] == 0)
                                        {

                                            for (int z = 1; z < 10; z++)
                                                if (_array[k, j, z] != 0 && k != i)
                                                {
                                                    candidatecounterx++;
                                                }
                                            if (candidatecounterx == 2) break;
                                            else candidatecounterx = 0;
                                        }
                                        if (_array[i, k, 0] == 0)
                                        {

                                            for (int z = 1; z < 10; z++)
                                                if (_array[i, k, z] != 0 && k != j)
                                                {
                                                    candidatecountery++;
                                                }
                                            if (candidatecountery == 2) break;
                                            else candidatecountery = 0;
                                        }


                                    }

                                        int ii = i;
                                        int yy = j;
                                        ii = ii - (ii % 3);
                                        yy = yy - (yy % 3);


                                        for (int p = ii; p < (ii + 3); p++)
                                        {
                                            for (int z = yy; z < (yy + 3); z++)
                                                if (_array[p, z, 0] == 0 && p != i && z != j)
                                                {
                                                    for (int d = 1; d < 10; d++)
                                                        if (_array[p, z, d] != 0)
                                                        {
                                                            candidatecounterbox++;
                                                        }
                                                    if (candidatecounterbox == 2) break;
                                                    else candidatecounterbox = 0;

                                                }
                                            if (candidatecounterbox == 2) break;
                                        }

                                        if (candidatecounterbox == 2 || candidatecounterx == 2 || candidatecountery == 2)
                                        {
                                            solutioncounter = 81;
                                            nochanges = 1;
                                        }
                                }
                            }
                        }

                }







                if (solutioncounter == 81 && nochanges == 1)
                    solutionfound = true;
                else solutionfound = false;

                


            }
            else solutionfound = false;

            //print(solutionfound);
            return solutionfound;
                }
        public void print(bool a)
        {
            Console.Write(a);
        }

        }
    }

