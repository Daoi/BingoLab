using System.Collections.Generic;
using System.Windows.Forms;

namespace BingoLab
{
    //This class handles the internal board. Checks for win condition, keeps track of matched tile locations. Check if the value exists on the board.
    public class InternalCardType2DimArray
    {
        private const int BINGOCARDSIZE = 5;//XbyX       
        private string[][] board = new string[BINGOCARDSIZE][]; //Uniform jagged array
        private int[] winningTiles;

        

        //Constructor to initalize the board array
        public InternalCardType2DimArray(int boardSize)
        {
            for (int i = 0; i < boardSize; i++)
            {
                this.board[i] = new string[boardSize];
            }
        }

        //Fill in value for board, used to copy values during board creation. 
        public void SetTile(int row, int col, string value)
        {
            this.board[row][col] = value;
        }

        //Checks to make sure the value called and value selected by player match
        public bool ValueSelected(int row, int col, string value)
        {
            if(value == board[row][col])
            {
                this.board[row][col] = "0";
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checks to make sure the value called actually doesn't exist on the board.
        //If we know the value of the column, we only have to check each row, 
        //instead of checking each tile. Probably better ways to do this since
        //switches suck, but it's also really easy/clear. 
        public bool DontHaveCheck(char col, string value) //If we don't have the value, return true(Good). If we do have the value, return false(bad).
        {
            int colIndex;
            
            switch (col)
            {
                case 'B':
                    colIndex = 0;
                    break;
                case 'I':
                    colIndex = 1;
                    break;
                case 'N':
                    colIndex = 2;
                    break;
                case 'G':
                    colIndex = 3;
                    break;
                case 'O':
                    colIndex = 4;
                    break;
                default:
                    MessageBox.Show("Program Error! Selected Letter not B I N G or O!",
                        "Click to terminate program.", MessageBoxButtons.OK);
                    colIndex = -1;
                    return true;
            } // end switch

            for(int i = 0; i < 5; i++)
            {
                if (board[i][colIndex] == value) {
                    return false;
                }
            }


            return true;
        }


        //Checks for a bingo, keep track of winning tiles
        //Sets are unique, order doesn't matter.
        //If we have a win, there will be only "0"s in the winning sequence.
        //i.e. set.Count == 1
        //Similarly, we keep track of the winning tiles for a row/column because
        //We will only ever need one value, and the rest is just a sequence of y-values/x-values(Cordinate plane)
        //Diagonals indicies are always static. 
        public bool CheckWinState()
        { 
        

            //Check rows
            for (int i = 0; i < 5; i++)
            {
                winningTiles = new int[BINGOCARDSIZE];
                var set = new HashSet<string>(board[i]);    //Grab first row
                if (set.Count == 1)                         //If the set's size is 1, all entries are "0" and thus the win state is achieved. 

                {
                    winningTiles = new int[1];
                    winningTiles[0] = i;
                    return true;
                }
            }
            //Check columns
            for (int i = 0; i < 5; i++) {
                var set = new HashSet<string>();
                winningTiles = new int[BINGOCARDSIZE];
                for (int j = 0; j < 5; j++) {
                    set.Add(this.board[j][i]);

                    winningTiles[j] = i;
                }
                if (set.Count == 1)
                {
                    return true;
                }
            }
            //Check Diagonals
            var topLeftBtmRight = new HashSet<string>(); // "\" diagonal
            var topRightBtmLeft = new HashSet<string>(); // "/" diagonal
            int a = 4;
            int b = 0;
            int y = 0;
            int z = 0;
            for (int x = 0; x < 5; x++) {

                topRightBtmLeft.Add(this.board[a][b]);
                topLeftBtmRight.Add(this.board[y][z]);
                a -= 1;
                b += 1;
                y += 1;
                z += 1;
               
            }

            if (topLeftBtmRight.Count == 1 || topRightBtmLeft.Count == 1) {

                winningTiles[0] = -1;
                return true;
            }

            return false; //No win states found
        }

        //Fetch the winning tiles
        public int[] GetWinningTiles()
        {
            return winningTiles;
        }

    }
}

            