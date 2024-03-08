using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CChavezQ2
{
    using System;
    using System.Globalization;
    //TShirtOrder.cs
    //Programmer: Rob Garner (rgarner7@cnm.edu)
    //Date: 10 Mar 2020
    //Purpose: Model a TShirt order.
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {
        public TShirtOrder(double printAreaInSqIn = 1, int numColors = 1, int numShirts = 1, string firstName = "", string lastName = "", string address = "", DateTime? orderDate = null, bool isLocalPickup = true)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            OrderDate = orderDate;
            IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;
            this.numColors = numColors;
            this.numShirts = numShirts;
            Calc();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsLocalPickup { get; set; }
        private double printAreaInSqIn;
        public double PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }

        private int numColors;
        public int NumColors
        {
            get { return NumColors; }
            set { numColors = value; Calc(); } // DEBUGGING EDIT: This should not have been a capital NumColors causing a stac overflow
        }

        private int numShirts;
        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }
        public double Price { get; set; } // DEBUGGING EDIT: Channged to double and removed Private
        private void Calc()
        {

            Price = numShirts * (numColors * 2.25) + (printAreaInSqIn * .05); //    DEBUGGING EDIT: added Parenthis to split up the math properly with order of operations
        }
        public override string ToString()
        {
            return FirstName + " "
                + LastName + " "
                //  + OrderDate.ToString("MM/dd/yyyy HH:mm:ss") + " " // DEBUGGING EDIT: THis is the orginoal line of code I explored other solutions
                //  + OrderDate.ToString("MM dd yyyy HH mm ss") + " " //                But could not fiind one that comiles in the code. All solution I could get running on an external testbed would not work here.  
                //  + OrderDate.ToString("G", DateTimeFormatInfo.InvariantInfo) + " " I don't know how the Order Date ToString works. Expecting me to "just find it on the internet" doesn't help much when I am taking a class to learn these things from an expert. If I really wanted to learn how to use AI to learn how to code I woud not be taking a class from a human. But I guess i'm the dumb one...
                + " Price: " + Price.ToString("c");
        }
    }
}


