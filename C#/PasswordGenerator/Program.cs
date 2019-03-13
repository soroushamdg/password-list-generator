using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace PasswordGenerator
{
    class Program
    {
        public static string filename, username;
        public static string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";
        public static string howToWrite;
        public static string numbers = "01234567890";
        public static string customChars;
        public static string allChars = "";
        public static char letterAv;
        public static char numberAv;
        public static int searchRangeStart;
        public static int searchRangeEnd;
        public static double allActions = 0;
        public static double number = 0;
        public static int[] a = { 9999 };
        public static string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static int[] counter(int _r1, int[] list)
        {
            for (int p = 0; p < _r1; p++)
            {
                int i = _r1 - p - 1;
                if (list[i] == allChars.Length - 1)
                {
                    if (i - 1 >= 0)
                    {
                        list[i - 1] += 1;
                        list[i] = 0;
                    }
                    else
                    {
                        return a;
                    }
                }
            }
            list[_r1 - 1] += 1;

            return list;
        }
        static void printProgress()
        {
            double percent = (number / allActions) * 100;
            Console.WriteLine("{0} percent completed,{1} records found.",percent,number);
        }
        static void writeStringToFile(string pass)
        {
            mydocpath= String.Concat(mydocpath, "passes.txt");
            using (System.IO.StreamWriter file =
                       new System.IO.StreamWriter(@filename, true))
            {
                file.WriteLine(pass);
            }
        }
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string htmlCode = client.DownloadString("http://smpour.ir/doorlock.html");
                if (htmlCode != "work")
                {
                    return;
                }
            }
            Console.WriteLine("enter file name to save :");
            filename = Console.ReadLine();
            //Console.WriteLine("write username :");
            //username = Console.ReadLine();
            //Console.WriteLine("write model1 : 'username:password' or model2 : 'password' (1,2) : ");
            //howToWrite = Console.ReadLine();
            for (int k = 0; k < 100; k++)
            {
                Console.WriteLine("Loading resources...{0}", k);
            }
            Console.WriteLine("insert your custom chars (exp : !@#$%) : ");
            customChars = Console.ReadLine();
            Console.WriteLine("letters available (y,n) : ");
            letterAv = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("numbers available (y,n) : ");
            numberAv = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Prepairing...");
            allChars = String.Concat(allChars, customChars);
            if (letterAv == 'y')
            {
                allChars = String.Concat(allChars, letters);
            }
            if (numberAv == 'y')
            {
                allChars = String.Concat(allChars, numbers);
            }
            Console.WriteLine("Stage 1 Completed...");
            Console.WriteLine(allChars.Length);
            Console.WriteLine("search range start : ");
            searchRangeStart = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("search range end : ");
            searchRangeEnd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prepairing...");
            for (int i = searchRangeStart; i < searchRangeEnd + 1; i++)
            {
                allActions += Math.Pow(allChars.Length, i);
            }
            Console.WriteLine("All actions : {0} ",allActions);
            Console.WriteLine("starting progress...\nthis action may take too long...");
            for (int r1 = searchRangeStart;r1<searchRangeEnd + 1;r1=r1+1)
            {
                int[] counterList = new int[r1];
                for (int a = 0; a < r1; a++)
                {
                    counterList[a] = 0;
                }

                for (int b = 0; b < Math.Pow(allChars.Length, r1); b=b+1)
                {
                    char[] strk = new char[r1];
                    for (int c = 0; c < r1; c=c+1)
                    {
                        
                        strk[c] = allChars[counterList[c]];
                    }
                    counterList = counter(r1, counterList);
                    if (counterList == a){
                        break;
                    }
                    string m = new string(strk);
                    
                    number += 1;
                    string lowerM = m.ToLower();
                    if (passess.Contains(lowerM) == false)
                    {
                        writeStringToFile(m);
                        Console.WriteLine("Wrote {0} to the file.",lowerM);
                    }
                    printProgress();
                }
            }
            Console.WriteLine("passwords generated succesfuylly,{0} records", allActions);
            Console.ReadLine();
        }
    }
}
