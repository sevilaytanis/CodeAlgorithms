using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public static class NumIslands
    {
        public static void bfs(char[,] grid, int r, int c)
        {
            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r,c] == '0')
            {
                return;
            }

            grid[r,c] = '0';
            bfs(grid, r - 1, c); //down
            bfs(grid, r + 1, c); //up
            bfs(grid, r, c - 1); //left
            bfs(grid, r, c + 1); //right
        }

        public static int numIslands(char[,] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.GetLength(0);
            int nc = grid.GetLength(1);
            int num_islands = 0;
            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r,c] == '1')
                    {
                        ++num_islands;
                        bfs(grid, r, c);
                    }
                }
            }

            return num_islands;
        }

        public static void Test()
        {

            var testData = new char[,] { { '1', '1', '1', '1', '0' }, { '1', '1', '0', '1', '0' }, { '1', '1', '0', '0', '0' }, { '0', '0', '0', '1', '1' } };

            var result= numIslands(testData);

            Console.WriteLine(result);
        }
    }
}