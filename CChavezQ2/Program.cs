using System;
using System.Collections.Generic;

//Program.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Process a series of tshirt orders. 
namespace CChavezQ2
{
    class Program
    {
        private const string COMPANYNAME = "Super Shirt Ordermatic 3000";
        private const string COMPANYSLOGAN = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            
            Header();
            char option;
            try
            {
                List<TShirtOrder> orders = new List<TShirtOrder>();
                do
                {
                        DisplayShirtOrders(orders);
                        option = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ").Trim().ToUpper()[0];
                        switch (option)
                        {

                            case 'A':
                                AddShirtOrder(orders);
                                break;
                            case 'R':
                                RemoveShirtOrder(orders);
                                break;
                            case 'T':
                                DisplayTotal(orders);
                                break;

                        }

                } while (option != 'E') ;
            }
            catch { }

            Console.WriteLine("Thank you for using " + COMPANYNAME);
        }
        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            double total = 0; // Debugging Edit: Swapped to Double for consistant varaibles
            foreach (TShirtOrder order in orders)
            {
                total += order.Price;
            }
            Console.WriteLine("Total price of order is: " + total);
        }

        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order"))
            {
                orders.Remove(orders[index-1]); //Debugging EDIT: Orders needed to be inserted here before index for the call to work right as it needs to know Where the index is that is being removed. THis is INdex-1 becasue the prebuild UI does not adjust for 0 standard indexing
            }
        }
        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            order.OrderDate = DateTime.Now;
            order.PrintAreaInSqIn = GetDoubleFromUser("Please enter are of your design in square inches: ");
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }
        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; ++i) // DEBUGGING EDIT: count was called lke a method. removed () from orders.Count
                {
                    Console.WriteLine((i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No shirts in order.");
            }
            Console.WriteLine();
        }
        private static void Header()
        {
            Console.WriteLine("Welcome to " + COMPANYNAME + "!");
            Console.WriteLine(COMPANYSLOGAN);
            Console.WriteLine();
        }
        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }
        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }
        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            return double.Parse(Console.ReadLine());// Debugging Edit a couble should return a double and not an Int
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

