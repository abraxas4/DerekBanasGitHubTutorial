using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//전제 : 
//      ASCII
//      소문자/대문자 구별
namespace DuplicatedChar
{
    class Program
    {
        //the number of all cases : ASCII
        const int NUM_MAX_CHAR_ASCII = 256;
        
        private static bool HasDuplicate(string strInput)
        {
            //1. # > the number of all the cases = duplicate already
            if (strInput.Length > NUM_MAX_CHAR_ASCII)
            {
                Console.WriteLine("length " + strInput.Length + " > " + NUM_MAX_CHAR_ASCII);
                return false;
            }
            //2. if any duplicates are found -> return false;
            bool[] arrIsValid = new bool[NUM_MAX_CHAR_ASCII];   //# = number of all the cases
            for (int i = 0; i < strInput.Length; i++)
            {
                //Console.WriteLine("i=%d, 
                //use the char value as the index
                int index = strInput.ElementAt(i);  //ASCII 256개. char 1 Byte = 2^8 = 256
                if (arrIsValid[index])  //already occupied
                {
                    Console.WriteLine("already occupied at " + index);
                    return false;
                }
                //setting true the slot
                arrIsValid[index] = true;
            }

            return true;
        }
        static void Main(string[] args)
        {
            //input (scanf?)
            char[] strInput = { 'a', 'b', 'c', 'c'};    //Capital and Non-Capital?
            string s = new string(strInput);

            if (!HasDuplicate(s))
            {
                Console.WriteLine("Duplicated\n");
            }
            else
            {
                Console.WriteLine("Not Duplicated\n");
            }
        }
        
    }
}
