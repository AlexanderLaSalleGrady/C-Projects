using System;
using System.Windows.Forms;

/*
 Programmer: Alexander Grady
 Date last modified: 12/9/2016 8:30PM
 Description: This project was inspired by my co-workers with the purpose of 
 double checking deposit paperwork at the end of a shift. This program is a simplified version 
 of what cashiers had to record at the end of a shift. Each textbox is used for user input.
 Every label is not accessable therefore prices and totals cannot be manually changed.    
*/

namespace Mattis_Auto_Wash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Price variables
        private const double RedPrice = 5.5;
        private const double WhitePrice = 1.5;
        private const double GoldPrice = 4.5;
        private const double BleachWhitePrice = 1;
        private const double MagicBondPrice = 1.5;
        private const double AirFreshenerPrice = 1;
        private const double MAWPrice = 5.5;
        private const double WAXPrice = 1.5;
        private const double RolloPrice = 1;
        private const double ValPakPrice = 1;
        private const double Disc1Price = 5.5;
        private const double Disc2Price = 7;
        private const double Disc3Price = 10;
        private const double FaultPrice = 5.5;
        private const double WedRedPrice = 4;
        private const double WedWhitePrice = 2;
        private const double WedGoldPrice = 5;
        private const double WedFaultPrice = 4;
        private const double WedMAWPrice = 4;
        private const double WedWAXPrice = 2;
        private const double WedDisc1Price = 4;
        private const double WedDisc2Price = 6;
        private const double WedDisc3Price = 9;

        //variables to store input values
        private double ZCars, ZWhite, ZGold, ZBleachWhite, ZMagicBond, Z2ndCar,
                XCars, XWhite, XGold, XBleachWhite, XMagicBond, X2ndCar,
                dblAirFresh, dblCharges, dblStore, dblFree, dblSupplies, dblDamage, dblRewash, dblEmployeeWash,
                dblCouponBooks, dblGiftCards, dblSubscriptions, dblMAW, dblWAX, dblRollo, dblValPak,
                dblDisc1, dblDisc2, dblDisc3, dblDeposit;

        //variable to help determine if wednesday calculations should apply
        private bool Wednesday;
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            /*Reset button to clear all text fields, reset some prices displayed,
              reset wednesday variable, and set focus*/

            //array of label objects used
            Label[]labels = { lblQuanCars, lblQuanWhite, lblQuanGold,
                lblQuanBleachWhite, lblQuanMaigcBond, lblTotalCoupQuantity,
                lblTotalCars, lblTotalWhite, lblTotalGold, lblTotalBleachWhite,
                lblTotalMagicbond, lblTotalAirFresh, lblTotalMAW, lblTotalWax,
                lblTotalRollo, lblTotalValPak, lblTotalRedDeisc, lblTotalWhiteDisc,
                lblTotalGoldDisc, lblTotalCouponSub, lblDeductionCoupons, lblDeductionTrip,
                lblTotalWash, lblTotalIncome, lblTotalDeductions, lblGrandTotal, lblOutcome,
                lblDeductionCharges, lblTotalChargeSlip };

            //array of textbox objects used
            TextBox[] txtboxes = { txtZCars, txtZWhite, txtZGold,
            txtZBleachWhite, txtZMagicBond, txtXCars, txtXWhite, txtXGold,
            txtXBleachWhite, txtXMagicBond, txtAirFreshener,
            txtDeductionStore, txtDeductionFree, txtDeductionSupplies, txtDeductionCWDamage,
            txtDeductionReWash, txtDeductionEmployeeWash, txtTotalCouponBooks,
            txtTotalGiftCards, txtTotalSubscriptions, txtQuantMAW, txtQuantWAX,
            txtQuantRollo, txtQuantValPak, txtQuantRedDisc, txtQuantWhiteDisc,
            txtQuantGoldDisc, txtDeposit, txtChargeSlip, txtZsecCar, txtXsecCar};

            //clear each selected label
            foreach (Label lbl in labels)
            {
                lbl.Text = "";
            }
            //clear each selected textbox
            foreach (TextBox txt in txtboxes)
            {
                txt.Text = "";
            }

            //set prices back to normal
            lblCarPrice.Text = "5.50";
            lblWhitePrice.Text = "1.50";
            lblGoldPrice.Text = "4.50";
            lblMAWPrice.Text = "5.50";
            lblWaxPrice.Text = "1.50";
            lblDiscPrice1.Text = "5.50";
            lblDiscPrice2.Text = "7.00";
            lblDiscPrice3.Text = "10.00";
            lblChargeSlip.Text = "5.50";
            //reset wednesday
            Wednesday = false;
            //set focus
            txtZCars.Focus();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            /*Calculate button*/

            //check for null values
            Zeros();

            //check for End Numbers          
            if (double.TryParse(txtZsecCar.Text, out Z2ndCar) == false || double.TryParse(txtXsecCar.Text, out X2ndCar) == false)
            {
                MessageBox.Show("Reading for '2nd Car' value must"
                    + "\nbe entered before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get user input
            GetValues();

            //X cannot be greater than Z             
            if (X2ndCar > Z2ndCar)
            {
                MessageBox.Show("X power cannot be greater than Z power", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //not wednesday
            Wednesday = false;

            //calculate totals
            SalesCalculation();
        }

        private void btnWednesday_Click(object sender, EventArgs e)
        {
            /*Wednesday calculate button*/

            //check for null values
            Zeros();

            //check for End Numbers          
            if (double.TryParse(txtZsecCar.Text, out Z2ndCar) == false || double.TryParse(txtXsecCar.Text, out X2ndCar) == false)
            {
                MessageBox.Show("Reading for '2nd Car' value must"
                    + "\nbe entered before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get user input
            GetValues();

            //X cannot be greater than Z             
            if (X2ndCar > Z2ndCar)
            {
                MessageBox.Show("X power cannot be greater than Z power", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //wednesday
            Wednesday = true;

            //wednesday calculations
            SalesCalculation();
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            /*Exit Button*/

            //close program
            this.Close();
        }

        private void Zeros()
        {
            /*If any textbox is left blank this method 
             will place a '0' inside the textbox*/

            double var;
            TextBox[] txtboxes = { txtZCars, txtZWhite, txtZGold,
            txtZBleachWhite, txtZMagicBond, txtXCars, txtXWhite, txtXGold,
            txtXBleachWhite, txtXMagicBond, txtAirFreshener,
            txtDeductionStore, txtDeductionFree, txtDeductionSupplies, txtDeductionCWDamage,
            txtDeductionReWash, txtDeductionEmployeeWash, txtTotalCouponBooks,
            txtTotalGiftCards, txtTotalSubscriptions, txtQuantMAW, txtQuantWAX,
            txtQuantRollo, txtQuantValPak, txtQuantRedDisc, txtQuantWhiteDisc,
            txtQuantGoldDisc, txtDeposit, txtChargeSlip};
            
            //loop through each textbox
            foreach (TextBox txt in txtboxes)
            {
                if (double.TryParse(txt.Text, out var) == false)
                {
                    txt.Text = "0";
                }
            } 
        }

        private void GetValues()
        {          
            /*Store user input with respective class variables*/

            string inValue;

            //ZCar
            inValue = txtZCars.Text;
            ZCars = double.Parse(inValue);

            //ZWhite
            inValue = txtZWhite.Text;
            ZWhite = double.Parse(inValue);

            //ZGold
            inValue = txtZGold.Text;
            ZGold = double.Parse(inValue);

            //ZBleachWhite
            inValue = txtZBleachWhite.Text;
            ZBleachWhite = double.Parse(inValue);

            //ZMagicBond
            inValue = txtZMagicBond.Text;
            ZMagicBond = double.Parse(inValue);

            //Z2ndCar
            inValue = txtZsecCar.Text;
            Z2ndCar = double.Parse(inValue);

            //XCar
            inValue = txtXCars.Text;
            XCars = double.Parse(inValue);

            //XWhite
            inValue = txtXWhite.Text;
            XWhite = double.Parse(inValue);

            //XGold
            inValue = txtXGold.Text;
            XGold = double.Parse(inValue);

            //XBleachWhite
            inValue = txtXBleachWhite.Text;
            XBleachWhite = double.Parse(inValue);

            //XMagicBond
            inValue = txtXMagicBond.Text;
            XMagicBond = double.Parse(inValue);

            //X2ndCar
            inValue = txtXsecCar.Text;
            X2ndCar = double.Parse(inValue);

            //AirFreshener
            inValue = txtAirFreshener.Text;
            dblAirFresh = double.Parse(inValue);

            //Charges
            inValue = txtChargeSlip.Text;
            dblCharges = double.Parse(inValue);

            //Store
            inValue = txtDeductionStore.Text;
            dblStore = double.Parse(inValue);

            //Free
            inValue = txtDeductionFree.Text;
            dblFree = double.Parse(inValue);

            //Supplies
            inValue = txtDeductionSupplies.Text;
            dblSupplies = double.Parse(inValue);

            //CW Damage
            inValue = txtDeductionCWDamage.Text;
            dblDamage = double.Parse(inValue);

            //Rewash
            inValue = txtDeductionReWash.Text;
            dblRewash = double.Parse(inValue);

            //Employee Wash
            inValue = txtDeductionEmployeeWash.Text;
            dblEmployeeWash = double.Parse(inValue);

            //Coupon Books
            inValue = txtTotalCouponBooks.Text;
            dblCouponBooks = double.Parse(inValue);

            //GiftCards
            inValue = txtTotalGiftCards.Text;
            dblGiftCards = double.Parse(inValue);

            //Subscriptions
            inValue = txtTotalSubscriptions.Text;
            dblSubscriptions = double.Parse(inValue);

            //MAW
            inValue = txtQuantMAW.Text;
            dblMAW = double.Parse(inValue);

            //WAX
            inValue = txtQuantWAX.Text;
            dblWAX = double.Parse(inValue);

            //Rollo
            inValue = txtQuantRollo.Text;
            dblRollo = double.Parse(inValue);

            //ValPak
            inValue = txtQuantValPak.Text;
            dblValPak = double.Parse(inValue);

            //Disc1
            inValue = txtQuantRedDisc.Text;
            dblDisc1 = double.Parse(inValue);

            //Disc2
            inValue = txtQuantWhiteDisc.Text;
            dblDisc2 = double.Parse(inValue);

            //Disc 3
            inValue = txtQuantGoldDisc.Text;
            dblDisc3 = double.Parse(inValue);

            //Deposit
            inValue = txtDeposit.Text;
            dblDeposit = double.Parse(inValue);
        }

        private void SalesCalculation()
        {
            /*Calculator method to calculate and display totals*/

            //variables to correspond with class variables
            double dblRed, dblWhite, dblGold, qBW, qMB, dblTotalCars, dblTotalWhite, dblTotalGold,
                dblTotalBleachWhite, dblTotalMB, dblTotal2ndCar, dblTotalAF,
                dblTotalWash, dblTotalMAW, dblTotalWAX, dblTotalRollo, dblTotalValPak,
                dblTotalDisc1, dblTotalDisc2, dblTotalDisc3, dblTotalCouponQuan,
                dblTotalCouponTotal, dblTotalTrip, dblTotalDeductions,
                dblTotalOverallTotal, dblTotalOutcome, dblTotalIncome, dblTotalFault, dblTotalCharges;

            //total cars
            if (ZCars == 0 || ZWhite == 0 || ZGold == 0)
            {
                dblRed = XCars;
                dblWhite = XWhite;
                dblGold = XGold;      
            }
            else
            {
                dblRed = ZCars - XCars;
                dblWhite = ZWhite - XWhite;
                dblGold = ZGold - XGold;               
            }

            //totalBleachWhite
            if (ZBleachWhite == 0)
            {
                qBW = XBleachWhite;
            }
            else
            {
                qBW = ZBleachWhite - XBleachWhite;
            }

            //totalMagicBond
            if (ZMagicBond == 0)
            {
                qMB = XMagicBond;
            }
            else
            {
                qMB = ZMagicBond - XMagicBond;
            }

            //Waxes cannot be greater than the total number of cars.
            if (dblRed < dblWhite || dblRed < dblGold || dblRed < (dblWhite + dblGold))
            {
                MessageBox.Show("Waxes cannot be greater than the total" 
                    + "\nnumber of cars. Check your numbers.", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //calculate trips
            dblTotal2ndCar = Z2ndCar - X2ndCar;
           
            if (dblTotal2ndCar < dblRed)
            {
                dblTotalFault = dblRed - dblTotal2ndCar;
                if (Wednesday == false)
                {
                    dblTotalTrip = dblTotalFault * FaultPrice;
                }
                else
                {
                    dblTotalTrip = dblTotalFault * WedFaultPrice;
                }
            }
            else
            {
                dblTotalTrip = 0;
            }

            //CALCULATE TOTALS//

            if (Wednesday == false)
            {
                //calculate normal day totals
                dblTotalCars = dblRed * RedPrice;
                dblTotalWhite = dblWhite * WhitePrice;
                dblTotalGold = dblGold * GoldPrice;
                //Disc1
                dblTotalDisc1 = dblDisc1 * Disc1Price;
                //Disc2
                dblTotalDisc2 = dblDisc2 * Disc2Price;
                //Disc3
                dblTotalDisc3 = dblDisc3 * Disc3Price;
                //MAW
                dblTotalMAW = dblMAW * MAWPrice;
                //WAX
                dblTotalWAX = dblWAX * WAXPrice;
                //Charges
                dblTotalCharges = dblCharges * RedPrice;
            }
            else
            {
                //calculate wednesday totals
                dblTotalCars = dblRed * WedRedPrice;
                dblTotalWhite = dblWhite * WedWhitePrice;
                dblTotalGold = dblGold * WedGoldPrice;
                //MAW
                dblTotalMAW = dblMAW * WedMAWPrice;
                //WAX
                dblTotalWAX = dblWAX * WedWAXPrice;
                //Disc1
                dblTotalDisc1 = dblDisc1 * WedDisc1Price;
                //Disc2
                dblTotalDisc2 = dblDisc2 * WedDisc2Price;
                //Disc3
                dblTotalDisc3 = dblDisc3 * WedDisc3Price;
                //Charges
                dblTotalCharges = dblCharges * WedRedPrice;
            }

            //Bleach White
            dblTotalBleachWhite = qBW * BleachWhitePrice;
            //Magic Bond
            dblTotalMB = qMB * MagicBondPrice;
            //Airfreshener
            dblTotalAF = dblAirFresh * AirFreshenerPrice;
            //Rollograph
            dblTotalRollo = dblRollo * RolloPrice;
            //ValPak
            dblTotalValPak = dblValPak * ValPakPrice;           
            //Coupon Quantity
            dblTotalCouponQuan = dblMAW + dblWAX + dblRollo + dblValPak + dblDisc1 + dblDisc2 + dblDisc3;
            //Coupon Total
            dblTotalCouponTotal = dblTotalMAW + dblTotalWAX + dblTotalRollo + dblTotalValPak + dblTotalDisc1 + dblTotalDisc2 + dblTotalDisc3;
            //Total Wash
            dblTotalWash = dblTotalCars + dblTotalWhite + dblTotalGold + dblTotalBleachWhite
            + dblTotalMB + dblTotalAF;
            //Total Income
            dblTotalIncome = dblTotalWash + dblCouponBooks + dblGiftCards + dblSubscriptions;
            //Total Deductions
            dblTotalDeductions = dblTotalCouponTotal + dblTotalCharges + dblStore
                + dblFree + dblSupplies + dblDamage + dblRewash + dblEmployeeWash + dblTotalTrip;
            //Overall Total
            dblTotalOverallTotal = dblTotalIncome - dblTotalDeductions;
            //Over|Short
            dblTotalOutcome = dblDeposit - dblTotalOverallTotal;

            //outcome color
            if (dblDeposit > dblTotalOverallTotal)
            {
                //if deposit is over the total needed
                lblOutcome.ForeColor = System.Drawing.Color.Blue;
            }
            else if (dblDeposit < dblTotalOverallTotal)
            {
                //if the deposit is short of the total needed
                lblOutcome.ForeColor = System.Drawing.Color.Red;
            }

            //DISPLAY TOTALS//

            //display price totals
            if (Wednesday == true)
            {
                //wednesday prices
                lblCarPrice.Text = "4.00";
                lblWhitePrice.Text = "2.00";
                lblGoldPrice.Text = "5.00";
                lblMAWPrice.Text = "4.00";
                lblWaxPrice.Text = "2.00";
                lblDiscPrice1.Text = "4.00";
                lblDiscPrice2.Text = "6.00";
                lblDiscPrice3.Text = "9.00";
                lblChargeSlip.Text = "4.00";
            }
            else
            {
                //normal prices
                lblCarPrice.Text = "5.50";
                lblWhitePrice.Text = "1.50";
                lblGoldPrice.Text = "4.50";
                lblMAWPrice.Text = "5.50";
                lblWaxPrice.Text = "1.50";
                lblDiscPrice1.Text = "5.50";
                lblDiscPrice2.Text = "7.00";
                lblDiscPrice3.Text = "10.00";
                lblChargeSlip.Text = "5.50";
            }

            //Display totals
            lblQuanCars.Text = dblRed.ToString("n0");
            lblQuanWhite.Text = dblWhite.ToString("n0");
            lblQuanGold.Text = dblGold.ToString("n0");
            lblQuanBleachWhite.Text = qBW.ToString("n0");
            lblQuanMaigcBond.Text = qMB.ToString("n0");
            lblTotalCoupQuantity.Text = dblTotalCouponQuan.ToString("n0");
            lblTotalCars.Text = dblTotalCars.ToString("c2");
            lblTotalWhite.Text = dblTotalWhite.ToString("c2");
            lblTotalGold.Text = dblTotalGold.ToString("c2");
            lblTotalBleachWhite.Text = dblTotalBleachWhite.ToString("c2");
            lblTotalMagicbond.Text = dblTotalMB.ToString("c2");
            lblTotalAirFresh.Text = dblTotalAF.ToString("c2");
            lblTotalMAW.Text = dblTotalMAW.ToString("c2");
            lblTotalWax.Text = dblTotalWAX.ToString("c2");
            lblTotalRollo.Text = dblTotalRollo.ToString("c2");
            lblTotalValPak.Text = dblTotalValPak.ToString("c2");
            lblTotalRedDeisc.Text = dblTotalDisc1.ToString("c2");
            lblTotalWhiteDisc.Text = dblTotalDisc2.ToString("c2");
            lblTotalGoldDisc.Text = dblTotalDisc3.ToString("c2");
            lblTotalCouponSub.Text = dblTotalCouponTotal.ToString("c2");
            lblDeductionCoupons.Text = dblTotalCouponTotal.ToString("c2");
            lblDeductionTrip.Text = dblTotalTrip.ToString("c2");
            lblTotalWash.Text = dblTotalWash.ToString("c2");
            lblTotalIncome.Text = dblTotalIncome.ToString("c2");
            lblTotalDeductions.Text = dblTotalDeductions.ToString("c2");
            lblGrandTotal.Text = dblTotalOverallTotal.ToString("c2"); 
            lblOutcome.Text = dblTotalOutcome.ToString("c2");
            lblTotalChargeSlip.Text = dblTotalCharges.ToString("c2");
            lblDeductionCharges.Text = dblTotalCharges.ToString("c2");
        }


        /*KEYPRESS TRAPS FOR TEXTBOXES
        WILL ONLY ALLOW DIGITS, BACKSPACE,
        AND ONE DECIMAL POINT*/

        private void txtXGold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXWhite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXCars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZsecCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZMagicBond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZBleachWhite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZGold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZWhite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtZCars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXBleachWhite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXMagicBond_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtXsecCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtAirFreshener_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantMAW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantWAX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantRollo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantValPak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantRedDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantWhiteDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantGoldDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionCharges_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionFree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionSupplies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionCWDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionReWash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeductionEmployeeWash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotalCouponBooks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotalGiftCards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotalSubscriptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;//Just Digits
            if (e.KeyChar == (char)8 || (e.KeyChar == '.')) e.Handled = false;//Allow Backspace                     
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
