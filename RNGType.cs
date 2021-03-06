﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BingoLab
{
    //Handle creation of random numbers for gameplay/board creation
    //Generate random color values.
    public class RNGType
    {
        private Random RandomObj;      
        private SelectedNumbersListType numberList; //Store value inside the RNGobject to prevent having to pass between every class method. 

        public RNGType(SelectedNumbersListType numberList)
        {
            RandomObj = new Random();  // Creates and seeds (using current time) random object 
            this.numberList = numberList;
        } 

        // Get Random Value
        // Gets next random value and ensures it is in the correct range for the column involved
        // Returns a valid random number
        public int GetRandomValue(char columnHeader)
        {
            int r;   // Random number generated

            switch (columnHeader)
            {
                case 'B':
                    r = GetNextUniqueRandomValue(1, 15);
                    if (r < 1 || r > 15)
                    {
                        MessageBox.Show("Program Error! Selected random number out of range 1-15",
                             "Click to terminate program.", MessageBoxButtons.OK);
                        return -1;
                    }  // end if
                    break;
                case 'I':
                    r = GetNextUniqueRandomValue(16, 30);
                    if (r < 16 || r > 30)
                    {
                        MessageBox.Show("Program Error! Selected random number out of range 16-30",
                             "Click to terminate program.", MessageBoxButtons.OK);
                        return -1;
                    }  // end if
                    break;
                case 'N':
                    r = GetNextUniqueRandomValue(31, 45);
                    if (r < 31 || r > 45)
                    {
                        MessageBox.Show("Program Error! Selected random number out of range 31-45",
                             "Click to terminate program.", MessageBoxButtons.OK);
                        return -1;
                    } // end if
                    break;
                case 'G':
                    r = GetNextUniqueRandomValue(46, 60);
                    if (r < 46 || r > 60)
                    {
                        MessageBox.Show("Program Error! Selected random number out of range 46-60",
                             "Click to terminate program.", MessageBoxButtons.OK);
                        return -1;
                    } // end if
                    break;
                case 'O':
                    r = GetNextUniqueRandomValue(61, 75);
                    if (r < 61 || r > 75)
                    {
                        MessageBox.Show("Program Error! Selected random number out of range 61-75",
                             "Click to terminate program.", MessageBoxButtons.OK);
                        return -1;
                    } // end if
                    break;
                default:
                    MessageBox.Show("Program Error! Selected Letter no B I N G or O!",
                        "Click to terminate program.", MessageBoxButtons.OK);
                    return -1;
            } // end switch
            return r;
        } //  end getRandomValue


        // Verifies that the number generated by getRandomValue is 
        //Unique and hasn't already been used.
        //Does so by interacting with SelectedNumbersListType.
        //When it confirms a number is unique, it marks it as used in the list via
        //numberList.setIndexTrue(rn);
        public int GetNextUniqueRandomValue(int minVal, int maxVal)
        {
            Boolean isUnique;
            int rn = 0; 
            
            isUnique = false;

            while (isUnique == false)
            {
                rn = RandomObj.Next(minVal, maxVal);
                if (!numberList.IsNumberUsed(rn))
                {
                    isUnique = true;
                    numberList.SetIndexTrue(rn);
                }
            }
            
            return rn;
        } 

        //Select a random letter, get an appropriate number value, and return the result to the form class.
        public string CallNumber()
        {
            char[] letters = new char[] { 'B', 'I', 'N', 'G', 'O' };
            int index = RandomObj.Next(5);
            char choice = letters[index];
            int rndmNums = GetRandomValue(choice);
            return choice.ToString() + rndmNums.ToString();

        }

        //Generate random RGB values from 0 to 255
        public Color GetRandomColor()
        {
            return Color.FromArgb(RandomObj.Next(0, 255), RandomObj.Next(0, 255), RandomObj.Next(0, 255));
        }

    }
}