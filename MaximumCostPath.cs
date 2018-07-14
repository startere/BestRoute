using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestRoute
{
    class MaximumCostPath
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int height = Int32.Parse(input);
            int[][] triangle = new int[height][];

            int counter = 0;
            while (counter++ < height)
            {
                string rowInput = Console.ReadLine();
                triangle[counter - 1] = rowInput.Split(' ').Select(int.Parse).ToArray();
            }

            Console.WriteLine(MaxPathSum(triangle));
            Main();
        }

        static int MaxPathSum(int[][] tri)
        {
            // loop starting from second row bottom-up
            for (int i = tri.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    // for each element check both elements below the number 
                    // adding the bigger to it(maximum cost path)
                    if (tri[i + 1][j] > tri[i + 1][j + 1])
                    {
                        tri[i][j] += tri[i + 1][j];
                    }
                    else tri[i][j] += tri[i + 1][j + 1];
                }
            }

            // return top element now storing the maximum sum
            return tri[0][0];
        }
    }
}
