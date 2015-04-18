/*
* Copyleft 1979-2013 GTO Inc. All rights reversed.
*/

using System;
using System.IO;
using System.Printing;
using System.Threading;
using System.Windows.Xps.Packaging;

namespace XpsPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread printingThread = new Thread(XPSPrinter.PrintXPS);

            printingThread.SetApartmentState(ApartmentState.STA);

            printingThread.Start();
            printingThread.Join();
        }
    }

    public class XPSPrinter
    {
        public static void PrintXPS()
        {
            LocalPrintServer localPrintServer = new LocalPrintServer();
            PrintQueue psPrintQueue = localPrintServer.GetPrintQueue("HP CLJ 8550");

            string xpsFile = @"C:\twopages.xps";

            try
            {
                psPrintQueue.UserPrintTicket.CopyCount = 5;
                psPrintQueue.UserPrintTicket.Collation = Collation.Collated;

                PrintSystemJobInfo xpsPrintJob = psPrintQueue.AddJob(xpsFile, xpsFile, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
