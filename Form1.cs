using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//Kevin Lynch
//Lab project 1: Bingo!
//CIS 3309.001 Component-Based Software Design
//Instructor: Frank Friedman
namespace BingoLab
{
    //This class handles all the interaction with the forms.
    //This class is also the main driver program for the bingo game.
    //All the other classes have instances created and passed to each other here.
    public partial class frmBingo : Form
    {
        public frmBingo()
        {
            InitializeComponent();
            glowTimer.Tick += new EventHandler(GlowTimer_Tick);

        }

        // Named constants
        private const int BINGOCARDSIZE = 5;
        private const int NUMBERSPERCOLUMN = 15;
        private const int MAXBINGONUMBER = 75;

        //Button 2darray
        private Button[,] newButton = new Button[BINGOCARDSIZE, BINGOCARDSIZE];
        private LinkedList<Button> winningTiles = new LinkedList<Button>();

        //Selected Numbers List, passed to other classes from main form. 
        public static SelectedNumbersListType selectedNumbers = new SelectedNumbersListType();
        
        //Player data
        private Player player;
        int matches = 0;
        int turns = 0;
        
        //Board Data
        private InternalCardType2DimArray internalBoard =
             new InternalCardType2DimArray(BINGOCARDSIZE);
        private RNGType RNGObj = new RNGType(selectedNumbers);

        private string bingoLetters = "BINGO";
        // Total width and height of a card cell
        int cardCellWidth = 75;
        int cardCellHeight = 75;
        int barWidth = 6;  // Width or thickness of horizontal and vertical bars
        int xcardUpperLeft = 45;
        int ycardUpperLeft = 45;
        int padding = 20;




        //Start the game and validate name.
        private void btnLetsGo_Click(object sender, EventArgs e)
        {

            if ((!Regex.IsMatch(txtNameEntry.Text, @"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$"))) //Regex to check for valid names. Alphabetical, not only spaces, not only special characters.
            {                                                                                       //Spaces and special characters may go between Alphabetical characters
                MessageBox.Show("Please enter a valid name. Try again.", "Missing Name");
                txtNameEntry.Focus();
            }
            else //We have a valid name, create player object and get the board ready.
            {
                lblRules.Visible = true;
                txtNumberCalled.Visible = true;
                lblYourCard.Visible = true;
                btnDontHave.Visible = true;


                player = new Player(txtNameEntry.Text);
                createBingoCardOnForm();
                txtNameEntry.ReadOnly = true;
                btnLetsGo.Enabled = false;
           
            }  
        }
       
        //Create the visual board
        private void createBingoCardOnForm()
        {
            pnlCard.Visible = true;
            createCard();
        } 

        
        private void createCard()
        {
            // Dynamically Creates 25 buttons on a Bingo Board 
            // Written by Bill Hall with Joe Jupin and FLF
            // This should be enough help for all of you to adapt this to your own needs
            // Create and  Add the buttons to the form

            btnPlayAgain.Enabled = false;
            btnPlayAgain.Visible = false;

            Size size = new Size(75, 75);
            Point loc = new Point(0, 0);
            int topMargin = 60;

            int x;
            int y;

            // Draw Column indexes
            y = 0;
            DrawColumnLabels();

            x = xcardUpperLeft;
            y = ycardUpperLeft;

            // Draw top line for card
            drawHorizBar(x, y, BINGOCARDSIZE);
            y = y + barWidth;

            // The board is treated like a 5x5 array
            drawVertBar(x, y);
            for (int row = 0; row < BINGOCARDSIZE; row++)
            {
                loc.Y = topMargin + row * (size.Height + padding);
                int extraLeftPadding = 50;
                for (int col = 0; col < BINGOCARDSIZE; col++)
                {
                    newButton[row, col] = new Button();
                    newButton[row, col].Location = new Point(extraLeftPadding + col * (size.Width + padding) + barWidth, loc.Y);
                    newButton[row, col].Size = size;
                    newButton[row, col].Font = new Font("Arial", 24, FontStyle.Bold);
                    newButton[row, col].Enabled = true;

                    if (row == BINGOCARDSIZE / 2 && col == BINGOCARDSIZE / 2)
                    {
                        newButton[row, col].Font = new Font("Arial", 10, FontStyle.Bold);
                        newButton[row, col].Text = "Free \n Space";
                        newButton[row, col].BackColor = System.Drawing.Color.Orange;
                        newButton[row, col].Enabled = false;
                        internalBoard.SetTile(row, col, "0");
                    }
                    else
                    {
                        newButton[row, col].Font = new Font("Arial", 24, FontStyle.Bold);
                        string tileValue = RNGObj.GetRandomValue(bingoLetters[col]).ToString();
                        newButton[row, col].Text = tileValue;
                        internalBoard.SetTile(row, col, tileValue);
                    }  // end if    

                    newButton[row, col].Name = "btn" + row.ToString() + col.ToString();

                    // Associates the same event handler with each of the buttons generated
                    newButton[row, col].Click += new EventHandler(Button_Click);

                    // Add button to the form
                    pnlCard.Controls.Add(newButton[row, col]);

                    // Draw vertical delimiter                 
                    x += cardCellWidth + padding;
                    if (row == 0) drawVertBar(x - 5, y);
                } // end for col
                // One row now complete

                // Draw bottom square delimiter if square complete
                x = xcardUpperLeft - 20;
                y = y + cardCellHeight + padding;
                drawHorizBar(x + 25, y - 10, BINGOCARDSIZE - 10);
            } // end for row

            // Draw column indices at bottom of card
            y += barWidth - 1;
            DrawColumnLabels();
            selectedNumbers.Reset();    
            PlayTheGame();
        } 

        private void DrawColumnLabels()
        {
            Label lblColID = new Label();
            lblColID.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)24.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblColID.ForeColor = System.Drawing.Color.Orange;
            lblColID.Location = new System.Drawing.Point(cardCellWidth, 0);
            lblColID.Name = "lblColIDBINGO";
            lblColID.Size = new System.Drawing.Size(488, 32);
            lblColID.TabIndex = 0;
            lblColID.Text = "B       I        N       G       O";
            pnlCard.Controls.Add(lblColID);
            lblColID.Visible = true;
            lblColID.CreateControl();
            lblColID.Show();
        } 

        private void drawHorizBar(int x, int y, int cardSize)
        {
            int currentx;
            currentx = x;

            Label lblHorizBar = new Label();
            lblHorizBar.BackColor = System.Drawing.SystemColors.ControlText;
            lblHorizBar.Location = new System.Drawing.Point(currentx, y);
            lblHorizBar.Name = "lblHorizBar";
            lblHorizBar.Size = new System.Drawing.Size((cardCellWidth + padding - 1) * BINGOCARDSIZE, barWidth);
            lblHorizBar.TabIndex = 20;
            pnlCard.Controls.Add(lblHorizBar);
            lblHorizBar.Visible = true;
            lblHorizBar.CreateControl();
            lblHorizBar.Show();
            currentx = currentx + cardCellWidth;
        } 

        private void drawVertBar(int x, int y)
        {
            Label lblVertBar = new Label();
            lblVertBar.BackColor = System.Drawing.SystemColors.ControlText;
            lblVertBar.Location = new System.Drawing.Point(x, y);
            lblVertBar.Name = "lblVertBar" + x.ToString();
            lblVertBar.Size = new System.Drawing.Size(barWidth, (cardCellHeight + padding - 1) * BINGOCARDSIZE);
            lblVertBar.TabIndex = 19;
            pnlCard.Controls.Add(lblVertBar);
            lblVertBar.Visible = true;
            lblVertBar.CreateControl();
            lblVertBar.Show();
        } 

        //End board creation


        //Tile selection event handler. Color tile, check for match, disable tile, update internalBoard.
        //Whenever a tile is matched, and there are at least 4 matches we need to check if the player has won.
        //We do this by calling checkWinState on the internalBoard object
        //If we have a win, prepare the game to be reset, display a message, and put on a small display
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            string selectedNumber = txtNumberCalled.Text.Substring(1);

            int rowID = (int)Char.GetNumericValue(button.Name[3]);
            int colID = (int)Char.GetNumericValue(button.Name[4]);
            MessageBox.Show("Cell[" + rowID + "," + colID + "] has been selected!");
            int cellID = rowID * 3 + colID;

            if(internalBoard.ValueSelected(rowID, colID, selectedNumber))//If true we have a match, if false they selected an incorrect tile.
            { 
                button.Enabled = false;
                button.BackColor = System.Drawing.Color.Orange;
                btnDontHave.Focus();
                matches++;
                if (matches >= 4) //Don't need to check before at least 4 tiles have been matched. Probably super unnecessary
                {
                    if(internalBoard.CheckWinState())
                    {
                        //Victory achieved
                        foreach(Button btn in newButton)
                        {
                            btn.Enabled = false;
                        }
                        btnDontHave.Enabled = false;
                        TileGlow(internalBoard.GetWinningTiles());
                        player.wonGame();
                        player.updateTurns(turns);
                        MessageBox.Show("Congrats " + player.getName() + " you've won! Total wins: " + player.getWins() + " Average turns per game: " + player.getAvgTurns());
                        btnPlayAgain.Enabled = true;
                        btnPlayAgain.Visible = true;
                        btnPlayAgain.Focus();
                        
                    }
                }
                PlayTheGame();
            }
            else
            {
                MessageBox.Show("That tile doesn't match the called value, try again!");
                btnDontHave.Focus();
            }

        } // end button clickhandler 


        //Exit the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //Handle don't click button press event. Check the board for the number to confirm.
        //Proceed to next number or warn player.
        private void btnDontHave_Click(object sender, EventArgs e)
        {
            string value = txtNumberCalled.Text.Substring(1);
            if (internalBoard.DontHaveCheck(txtNumberCalled.Text[0], value)){ //Pass row/col index and LetterNumberNumber value
                PlayTheGame();
            }
            else {
                MessageBox.Show("Check your board for the value again!");
            }
        }

        //Main game loop, interacts with RNGClass to create and display the "next called" number 
        public void PlayTheGame()
        {
            string firstNum = "0";
            string secondNum = "0";
            string calledNumber = RNGObj.CallNumber();

            if (calledNumber.Length > 2) { 
               firstNum = calledNumber[1].ToString();
               secondNum = calledNumber[2].ToString();
            }
            else
            {
                secondNum = calledNumber[1].ToString();
            }
            string number = firstNum + secondNum;

            turns++;
            txtNumberCalled.Text = calledNumber;
            btnDontHave.Focus();
        }

        //Restart the game by recreating/initalizing the board
        private void BtnPlayAgain_Click(object sender, EventArgs e)
        {
            btnDontHave.Enabled = true;
            glowTimer.Enabled = false;
            glowTimer.Stop();
            matches = 0;
            turns = 0;
            newButton = new Button[BINGOCARDSIZE, BINGOCARDSIZE]; //Create new 2d button
            txtNumberCalled.Text = "";
            selectedNumbers.Reset();
            pnlCard.Controls.OfType<Button>().ToList().ForEach(btn => btn.Dispose()); //Get rid of all current buttons
            createBingoCardOnForm();

        }

        //Flash colors on winning row/column or both diagonals
        private void TileGlow(int[] array)
        {   

            if (array[0] == -1) //Diagonal win
            {
                int a = 4;
                int b = 0;
                int y = 0;
                int z = 0;
                for (int x = 0; x < 5; x++)
                {

                    winningTiles.AddLast(newButton[a,b]);
                    winningTiles.AddLast(newButton[y, z]);
                    a -= 1;
                    b += 1;
                    y += 1;
                    z += 1;

                }
            }
            else if (array.Length > 1) //Column win? 
            {

                int j = array[0];
                for(int x = 0; x < 5; x++)
                {
                    winningTiles.AddLast(newButton[x, j]);
                }
                
            }
            else //Row win
            {
                int i = array[0];
                for(int j = 0; j < 5; j++)
                {
                    winningTiles.AddLast(newButton[i, j]);
                }
                  
            }

            
            glowTimer.Enabled = true;
            glowTimer.Start();
            

        }

        //Get new color
        private void GlowTimer_Tick(object sender, System.EventArgs e)
        {
            foreach(Button btn in winningTiles){
                btn.BackColor = RNGObj.GetRandomColor();
            }
        }



    }//End Class
}//End Namespace

