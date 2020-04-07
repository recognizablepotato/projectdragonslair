using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//This program invokes a inventory database, Inventory Items and Inventory Prices
//The output on the program is updated inventory, and Inventory discount prices as well as subtotal total and tax amount applied to total 
//the program consists of button eventhandlers which have set prices that they pass to methods
// the button eventhandlers also update inventory by specifying the amount of inventory to be taken out to a method
//the method for discount price gets the price from the eventhandler button and send back a discount price to be output
//the discount method also takes the price and retreives a updated total when ever passed through and tax as well as subtotal
//the method for inventory receives the amount of items to be taken from inventory via eventhandler buttons
//and subtracts them from total inventory displayed
//
//Brandi Lauria
//3/26/2017

namespace project3blauria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        //Field Variables for computation
        const double TAX_RATE = .05;
        private double dblTax, dblTotal;
        private double dblSubtotal;

        private void button1_Click(object sender, EventArgs e)
        {//begin event handler for oak wand  button
            //set Price of OakWand
            double dblPrice = 75.00;
            //set variable for discount price
            double dblDiscountPrice = 0.00;
            //Calls method for getting discount price send price to method
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //method for setting inventory takes one value out of oak wand inventory lbl
            getinventoryupdates(1, 0, 0, 0, 0, 0, 0, 0, 0);
            //Outputs to listbox inventory DiscountPrice
            lstInventoryOutput.Items.Add(string.Format("{0,1}{1,36}", "Oak Wand", dblDiscountPrice.ToString("C")));
            
        }//end event handler for oak wand button
        private void getdiscountprice(double dblPrice, ref double dblDiscountPrice)
        {//begins method for gettting discount price
            
            { 
                if (rdbFire.Checked == true)// if clicked Platinum or Fire discount retrieves this discount price computation
                {
                    double dblDiscount = .15;
                    dblDiscountPrice = dblPrice - (dblDiscount * dblPrice);
                }
                if (rdbEmber.Checked == true)// if clicked Gold or Ember discount retrieves this discount price computation
                {
                    double dblDiscount = .10;
                    dblDiscountPrice = dblPrice - (dblDiscount * dblPrice);
                }
                if (rdbSmoke.Checked == true)// if clicked Silver or Smoke discount retrieves this discount price computation
                {
                    double dblDiscount = .05;
                    dblDiscountPrice = dblPrice - (dblDiscount * dblPrice);
                }
                 if (rdbNone.Checked == true)// if clicked None discount retrieves this discount price computation
                {
                    double dblDiscount = 0;
                    dblDiscountPrice = dblPrice - (dblDiscount * dblPrice);
                }
                 else if (rdbNone.Checked == false && rdbEmber.Checked == false && rdbSmoke.Checked== false && rdbFire.Checked == false)
                {
                    double dblDiscount = 0;
                    dblDiscountPrice = dblPrice - (dblDiscount * dblPrice);
                }
                //computation for getting the total cost of items sold
                dblSubtotal = dblSubtotal + dblDiscountPrice;
                // gets the tax rate for cost of total items sold
                dblTax = TAX_RATE * dblSubtotal;
                //gets the Total of tax for cost of goods sold and cost of good sold total
                dblTotal = dblSubtotal + dblTax;
                //Displays Subtotal to textbox
                txtSubtotal.Text = dblSubtotal.ToString("C");
                //Displays Tax Total to textbox
                txtTaxes.Text = dblTax.ToString("C");
                //Displays Total to text box
                txtTotal.Text = dblTotal.ToString("C");
            }
    } //end of method
        private void getinventoryupdates(int intInventoryCountOak, int intInventoryCountSP, int intInventoryCountIP,
            int intInventoryCountR, int intInventoryCountSK, int intInventoryCountGW, int InventoryCountLL, int InventoryCountGC,
             int InventoryCountTT)
        {//inventory update to labels method begins
            {         //updates inventory amount of OakWand
                     int intInventory;
                     intInventory = int.Parse(txtInventoryCountOakWand.Text);
                     intInventory = intInventory - intInventoryCountOak;
                     txtInventoryCountOakWand.Text = intInventory.ToString();
                                  
                    //updates  inventory amount of Sleeping Potion
                     intInventory = int.Parse(txtInventoryCountSleepingPotion.Text);
                    intInventory = intInventory - intInventoryCountSP;
                    txtInventoryCountSleepingPotion.Text = intInventory.ToString(); 
                     
                   //updates inventory amount of Invisibility Potion
                        intInventory = int.Parse(txtInventoryCountInvisibilityPotion.Text);
                        intInventory = intInventory - intInventoryCountIP;
                        txtInventoryCountInvisibilityPotion.Text = intInventory.ToString();
                        

                    //updates inventory amount of Remembrall
                        intInventory = int.Parse(txtInventoryCountRemembrall.Text);
                        intInventory = intInventory - intInventoryCountR;
                        txtInventoryCountRemembrall.Text = intInventory.ToString();
                        
                  
                        //updates inventory amount of Survival Kit
                        intInventory = int.Parse(txtInventoryCountSurvivalKit.Text);
                        intInventory = intInventory - intInventoryCountSK;
                        txtInventoryCountSurvivalKit.Text = intInventory.ToString();
                       
                        
                    //updates inventory amount of GillyWeed
                        intInventory = int.Parse(txtInventoryCountGillyWeed.Text);
                        intInventory = intInventory - intInventoryCountGW;
                        txtInventoryCountGillyWeed.Text = intInventory.ToString();
                        
                   //updates inventory amount of Liquid Luck
                        intInventory = int.Parse(txtInventoryCountLiquidLuck.Text);
                        intInventory = intInventory - InventoryCountLL;
                        txtInventoryCountLiquidLuck.Text = intInventory.ToString();
                       
                   //updates inventory amount of Gold Chain
                        intInventory = int.Parse(txtInventoryCountGoldChain.Text);
                        intInventory = intInventory - InventoryCountGC;
                        txtInventoryCountGoldChain.Text = intInventory.ToString();
                        
                    //updates Inventory amount of Time Turner
                        intInventory = int.Parse(txtInventoryCountTimeTurner.Text);
                        intInventory = intInventory - InventoryCountTT;
                        txtInventoryCountTimeTurner.Text = intInventory.ToString();
                        
                
                
            }
        }//end of method
        private void button10_Click(object sender, EventArgs e)
        {//begin exit button event handler - allows you to exit program
            this.Close();
        }//end exit button event handler

        private void btnSleepingPotion_Click(object sender, EventArgs e)
        {//event handler for Sleeping Potion button begins
            //sets price of Sleeping Potion to pass to getdiscountprice method
            double dblPrice = 30.00;
            //sets discountPrice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking one Sleeping Potion out
            getinventoryupdates(0, 1, 0, 0, 0, 0, 0, 0, 0);
            //Print out the item and discount price of item
            lstInventoryOutput.Items.Add(string.Format("{0,12}{1,27}", "Sleeping Potion", dblDiscountPrice.ToString("C")));
            
        }//event handler ends for button Sleeping Potion

        private void btnInvisibilityPotion_Click(object sender, EventArgs e)
        {//event handler for Invisibility Potion button begins
            //sets price of Invisibility Potion to pass to get discount price method
            double dblPrice= 30.00;
            //sets discountPrice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking one Invisibility Potion out
            getinventoryupdates(0, 0, 1, 0, 0, 0, 0, 0, 0);
            //Prints out the item and discount price of item
            lstInventoryOutput.Items.Add(string.Format("{0,10}{1,22}", "Invisibility Potion", dblDiscountPrice.ToString("C")));
            
        }//event handler ends for button Sleeping Potion

        private void btnRemembrall_Click(object sender, EventArgs e)
        {//event handler for Remembrall button begins
            //sets price of Remembrall to pass to get discount price method
            double dblPrice = 100;
            //sets discountprice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking 1 Remembrall out of inventory
            getinventoryupdates(0, 0, 0, 1, 0, 0, 0, 0, 0);
            //prints out the item and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,10}{1,32}", "Remembrall", dblDiscountPrice.ToString("C")));
          
        }//event handler ends for button Remembrall

        private void btnSurvivalKit_Click(object sender, EventArgs e)
        {//event handler for Wizards Survival Kit button begins
            //sets price of Wizards Survival kit to pass to get discount price method
            double dblPrice= 200;
            //sets discountprice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking 1 wizards kit out of stock,gillyweed, oak wand, sleeping potion, and two liquid luck
            getinventoryupdates(1, 1, 0, 0, 1, 1, 2, 0, 0);
            //prints out the items and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,10}{1,11}", "A Wizards Survival Kit", dblDiscountPrice.ToString("C")));
            lstInventoryOutput.Items.Add(string.Format("{0,10}", "1 GillyWeed"));
            lstInventoryOutput.Items.Add(string.Format("{0,10}", "2 Liquid Luck"));
            lstInventoryOutput.Items.Add(string.Format("{0,10}", "1 Oak Wand"));
            lstInventoryOutput.Items.Add(string.Format("{0,10}", "1 Sleeping Potion"));
           
        }//event handler ends for button Wizards Survival Kit

        private void btnGillyWeed_Click(object sender, EventArgs e)
        {//event handler for GillyWeed button begins
            //sets price of gillyweed to pass to get discount price method
            double dblPrice = 30;
            //sets discountprice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //call method for inventory to update taking 1 gillyweed out of stock
            getinventoryupdates(0, 0, 0, 0, 0, 1, 0,0,0);
            //prints out the items and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,8}{1,35}", "GillyWeed", dblDiscountPrice.ToString("C")));
            
        }//event handler ends for button gillyweed 

        private void btnLiquidLuck_Click(object sender, EventArgs e)
        {//eventhandler for liquid luck button begins
            //sets price of liquid luck to pass to get discount price method
            double dblPrice = 30;
            //sets discountprice which will be retrieved for actual value by getdiscountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking 1 liquid luck out of stock
            getinventoryupdates(0, 0, 0, 0, 0, 0, 1, 0, 0);
            //prints out the items and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,11}{1,32}", "Liquid Luck", dblDiscountPrice.ToString("C")));
            
        }//event handler ends for button liquid luck

        private void btnGoldChain_Click(object sender, EventArgs e)
        {// eventhandler for goldchain button begins
            //sets price of gold chain to pass to get discount price method
            double dblPrice = 50;
            //sets discountprice which will be retrieved for actual value by get discountprice method
            double dblDiscountPrice = 0;
            //calls method get discountprice
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking 1 gold chain out of stock
            getinventoryupdates(0, 0, 0, 0, 0, 0, 0, 1, 0);
            //prints out the items and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,10}{1,34}", "Gold Chain", dblDiscountPrice.ToString("C")));
           
        }//event handler ends for button gold chain

        private void lstInventoryOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTimeTurner_Click(object sender, EventArgs e)
        {//eventhandler for time turner begins
            //sets price of time turner to pass to get discount price method
            double dblPrice = 150;
            //sets discountprice which will be retrieved for actual value by get discountprice method
            double dblDiscountPrice = 0;
            //calls method get discount price
            getdiscountprice(dblPrice, ref dblDiscountPrice);
            //calls method for inventory to update taking 1 gold chain and 1 time turner out of stock
            getinventoryupdates(0, 0, 0, 0, 0, 0, 0, 1, 1);
            //prints out the items and discount of item
            lstInventoryOutput.Items.Add(string.Format("{0,11}{1,31}", "Time Turner", dblDiscountPrice.ToString("C")));
            lstInventoryOutput.Items.Add(string.Format("{0,10}", "1 Gold Chain"));
            
        }//event handler ends for button time turner

      
    }//end class
}//end namespace
