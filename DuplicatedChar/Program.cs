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
#if false
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
#else
        //소문자a~z까지만. 1bit에 저장. 26/8 = 4 Byte
        private static bool HasDuplicate(string strInput)
        {
            //1. # > the number of all the cases = duplicate already
            UInt16 nAllCases = 26;
            if (strInput.Length > nAllCases)
            {
                Console.WriteLine("length " + strInput.Length + " > " + nAllCases);
                return false;
            }
            //2. if any duplicates are found -> return false;
            //UInt16 nArraySize = Math.Ceiling(double(nAllCases/8));
            //bool[] arrIsValid = new bool[nArraySize];   //# = number of all the cases
            UInt32 arrIsvalid = 0; //Initialized.
            for (int i = 0; i < strInput.Length; i++)
            {
                //Console.WriteLine("i=%d, 
                //use the char value as the index
                int index = strInput.ElementAt(i) - 'a';  //ASCII 256개. char 1 Byte = 2^8 = 256
                if ((arrIsvalid & (1 << index))!=0)  //already occupied
                {
                    Console.WriteLine("already occupied at " + index);
                    return false;
                }
                //setting true the slot
                arrIsvalid |= (UInt16)(1 << index);
            }
            return true;
        }
#endif
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
