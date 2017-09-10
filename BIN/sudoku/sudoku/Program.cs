using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public int Judge(int[,] x, int i, int j)
        {
            int sum = 0;
            int p = 0, q = 0, flag;
            int[] hashrow = new int[10];
            int[] hashcolumn = new int[10];
            int[] hashnine = new int[10];
            Random ra1 = new Random();
            for (; p < j; p++)
            {
                if (x[i, p] != 0)
                {
                    hashrow[x[i, p]] = 1;
                }
            }
            for (; q < i; q++)
            {
                if (x[q, j] != 0)
                {
                    hashcolumn[x[q, j]] = 1;
                }
            }
            if (i % 3 == 1)
            {
                if (j % 3 == 0)
                {
                    hashnine[x[i - 1, j + 1]] = 1;
                    hashnine[x[i - 1, j + 2]] = 1;
                }
                if (j % 3 == 1)
                {
                    hashnine[x[i - 1, j - 1]] = 1;
                    hashnine[x[i - 1, j + 1]] = 1;
                }
                if (j % 3 == 2)
                {
                    hashnine[x[i - 1, j - 1]] = 1;
                    hashnine[x[i - 1, j - 2]] = 1;
                }
            }
            if (i % 3 == 2)
            {
                if (j % 3 == 0)
                {
                    hashnine[x[i - 2, j + 1]] = 1;
                    hashnine[x[i - 2, j + 2]] = 1;
                    hashnine[x[i - 1, j + 1]] = 1;
                    hashnine[x[i - 1, j + 2]] = 1;
                }
                if (j % 3 == 1)
                {
                    hashnine[x[i - 2, j - 1]] = 1;
                    hashnine[x[i - 2, j + 1]] = 1;
                    hashnine[x[i - 1, j - 1]] = 1;
                    hashnine[x[i - 1, j + 1]] = 1;
                }
                if (j % 3 == 2)
                {
                    hashnine[x[i - 2, j - 2]] = 1;
                    hashnine[x[i - 2, j - 1]] = 1;
                    hashnine[x[i - 1, j - 2]] = 1;
                    hashnine[x[i - 1, j - 1]] = 1;
                }
            }
            for (int ff = 1; ff < 10; ff++)
            {
                if (hashcolumn[ff] + hashnine[ff] + hashrow[ff] > 0) sum++;
            }
            if (sum == 9)
            {

                return 0;
            }
            else
            {
                while (true)
                {
                    flag = ra1.Next(1, 10);
                    if (hashrow[flag] == 0 && hashcolumn[flag] == 0 && hashnine[flag] == 0)
                    {
                        x[i, j] = flag;
                        hashrow[flag] = 1;
                        hashcolumn[flag] = 1;
                        break;
                    }
                }
                return 1;
            }
        }

        public void test(int[,] x)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (i + j > 0)
                    {
                        int k = Judge(x, i, j);
                        if (k == 0)
                        {
                            i = i - 1;
                            //j = 0;                       
                            Judge(x, i, j);
                        }
                    }
                }
            }
        }

        static void Main(int arg = 3, String[] args)
        {
            int sum = 0;
            for (int n = 0; n < args[2].Length; n++, sum++)
            {
                if (args[2][n] < 48 || args[2][n] > 57) break;
            }
            if (sum == args[2].Length)
            {
                FileStream fs = new FileStream("..\\sudoku.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                int t = Convert.ToInt32(args[2]);
                for (; t > 0; t--)
                {
                    int i = 0; int j = 0;
                    int[,] sudoku = new int[9, 9];
                    sudoku[0, 0] = 4;
                    Program pro = new Program();
                    pro.test(sudoku);
                    for (i = 0; i < 9; i++)
                    {
                        for (j = 0; j < 9; j++)
                        {
                            sw.Write(sudoku[i, j].ToString() + " ");
                            if (j % 9 == 8) sw.WriteLine();
                        }
                    }
                    sw.WriteLine();
                }
                sw.Close();
                fs.Close();
                Console.ReadLine();
            }
            else Console.Write("erro!");
        }
    }
}
