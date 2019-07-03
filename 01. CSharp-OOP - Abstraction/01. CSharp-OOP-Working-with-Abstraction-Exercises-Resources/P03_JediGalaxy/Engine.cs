namespace P03_JediGalaxy
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
   public class Engine
    {
        private int[,] matrix;
        private long sum;
        public void Run()
        {
            this.CreatePlayground();
           
            string command = Console.ReadLine();
            sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] playerCoordinate = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinate = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int rowEvil = evilCoordinate[0];
                int colEvil = evilCoordinate[1];

                MoveEvilToTopLeftCorner(rowEvil,colEvil);

                int rowPlayer = playerCoordinate[0];
                int colPlayer = playerCoordinate[1];

                MovePlayerToTopRightCorner(  rowPlayer,  colPlayer);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private void MovePlayerToTopRightCorner(int rowPlayer,int colPlayer)
        {
            while (rowPlayer >= 0 && colPlayer < matrix.GetLength(1))
            {
                if (IsInside(rowPlayer, colPlayer))
                {
                    sum += matrix[rowPlayer, colPlayer];
                }

                colPlayer++;
                rowPlayer--;
            }
        }

        private void MoveEvilToTopLeftCorner( int rowEvil, int colEvil)
        {
            while (rowEvil >= 0 && colEvil >= 0)
            {
                if (IsInside(rowEvil, colEvil))
                {
                    matrix[rowEvil, colEvil] = 0;
                }
                rowEvil--;
                colEvil--;
            }
        }

        private bool IsInside( int rowCurrent, int colCurrent)
        {
            return rowCurrent >= 0 && rowCurrent < matrix.GetLength(0) && colCurrent >= 0 && colCurrent < matrix.GetLength(1);
        }

        private void CreatePlayground()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1]; 

            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
