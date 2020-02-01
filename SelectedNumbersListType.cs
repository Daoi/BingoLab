using System.Linq;

namespace BingoLab
{
    //Keep track of which numbers have been called/used on the board(During creation).
    public class SelectedNumbersListType
    {
        private bool[] selectedNumbersList;

        //Create an iterable object with 75 false values and convert to an array.(Saves for loop)
        //The game has a number range of 1-75. So we can use the index values of the array to represent the numbers,
        //and the true/false value inside to represent whether it's been selected/not selected already. 
        public SelectedNumbersListType()
        {
            selectedNumbersList = Enumerable.Repeat(false, 75).ToArray();
        }
        
        //Create a new array and point the reference to it. 
        public void Reset()
        {
            selectedNumbersList = Enumerable.Repeat(false, 75).ToArray();
        }

        //Index - 1 represents number called, change it to true(called)
        public void SetIndexTrue(int index)
        {
            selectedNumbersList[index-1] = true;
        }

        //Return the true or false value for the index
        public bool IsNumberUsed(int index)
        {
            return selectedNumbersList[index-1];
        }


    }
}