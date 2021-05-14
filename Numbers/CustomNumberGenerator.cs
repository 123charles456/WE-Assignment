using System;
using System.Collections.ObjectModel;

namespace Numbers
{
    public class CustomNumberGenerator 
    {
        private int _limit;
        int[] dividers = { 3, 5 };
        string allDividerMessage = "Bingo!";
        public void GenerateCustomList(int limit, ObservableCollection<string> CustNumberColl)
        {
            _limit = limit;      

            String _currentNumber = "";
            for (int i = 1; i <= _limit; i++)
            {
                if (CheckDivisbleByAllDividers(i))
                {
                    _currentNumber = allDividerMessage;
                }
                else if (i % dividers[0] == 0)
                {
                    int multiplier = i / dividers[0];
                    _currentNumber = (multiplier.ToString() + " times " + NumberToWordConvertor(dividers[0]));
                }
                else if (i % dividers[1] == 0)
                {
                    int multiplier = i / dividers[1];
                    _currentNumber = (multiplier.ToString() + " times " + NumberToWordConvertor(dividers[1]));
                }
                else
                {
                    _currentNumber = i.ToString();
                }

                //Sleep is given to show it is working Async
                System.Threading.Thread.Sleep(60);
                CustNumberColl.Add(_currentNumber);             

            }

        }

        private bool CheckDivisbleByAllDividers(int num)
        {
            bool flag = true;
            foreach (int divider in dividers)
            {
                if (num % divider != 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        
        private string NumberToWordConvertor(int _num)
        {
            String name = "";
            switch (_num)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
    }
}
