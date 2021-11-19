using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //whose turn
        bool PlayerTurn = false;

        //Check if the game is running and what was clicked
        bool Winner = false;
        bool ButtonStart = false;

        //Check if there are names
        bool NamesIn = false;

        //Putting buttons into an array for easier access
        Button[] buttonarray = new Button[16];

        //rng
        Random rnd = new Random();

        //based off rng, who goes
        int iStartingTurn;

        //names
        string Player1Name;
        string Player2Name;

        public Form1()
        {
            //assigning values
            iStartingTurn = rnd.Next(1, 3);
            InitializeComponent();
        }
        public void EndGame()
        {
            if (Winner == true)
            {
                //Goes through every button to clear text and enable
                for (int i = 0; i < 16; i++)
                {
                    //Clears text and reenables all buttons
                    buttonarray[i].Text = "";
                    buttonarray[i].Enabled = false;
                }
                txtPlayer1Name.Enabled = true;
                txtPlayer2Name.Enabled = true;
                btnStart.Enabled = true;
                Winner = false;
                lblTurn.Text = "";
            }
        }

        //Settings buttons into array method
        public void SetButtonArray()
        {
            //Setting buttons into the array
            buttonarray[0] = button1;
            buttonarray[1] = button2;
            buttonarray[2] = button3;
            buttonarray[3] = button4;
            buttonarray[4] = button5;
            buttonarray[5] = button6;
            buttonarray[6] = button7;
            buttonarray[7] = button8;
            buttonarray[8] = button9;
            buttonarray[9] = button10;
            buttonarray[10] = button11;
            buttonarray[11] = button12;
            buttonarray[12] = button13;
            buttonarray[13] = button14;
            buttonarray[14] = button15;
            buttonarray[15] = button16;
            //If the start button is clicked, do this
            if (ButtonStart == true)
            {
                for (int i = 0; i < 16; i++)
                {
                    buttonarray[i].Enabled = true;
                }
                btnStart.Enabled = false;
            }
        }
        //Who goes first
        public void StartingPlayerTurn()
        {
            //assigning values
            Player1Name = (Convert.ToString(txtPlayer1Name.Text));
            Player2Name = (Convert.ToString(txtPlayer2Name.Text));
            if (txtPlayer1Name.Text.Equals("") || txtPlayer2Name.Text.Equals(""))
            {
                MessageBox.Show("Enter a name please");
                NamesIn = true;
            }
            else if(!txtPlayer1Name.Text.Equals("") && txtPlayer2Name.Text.Equals(""))
            {
                NamesIn = false;
                //if the rng is 1, player 1 goes first
                if (iStartingTurn == 1)
                {
                    PlayerTurn = true;
                    lblTurn.Text = "Turn of: " + Player1Name;
                }
                // if the rng is 2, player 2 goes
                else
                {
                    PlayerTurn = false;
                    lblTurn.Text = "Turn of: " + Player2Name;
                }
            }
            else
            {
                NamesIn = false;
            }
            //Displays who goes first
            if (PlayerTurn == true && NamesIn == false)
            {
                MessageBox.Show(Player1Name + " is starting!");
                lblTurn.Text = "Turn of: " + Player1Name;
            }
            else if (PlayerTurn == false && NamesIn == false)
            {
                MessageBox.Show(Player2Name + " is starting!");
                lblTurn.Text = "Turn of: " + Player2Name;
            }
            txtPlayer1Name.Text = "";
            txtPlayer2Name.Text = "";
            txtPlayer1Name.Enabled = false;
            txtPlayer2Name.Enabled = false;

        }

        public void ShowWinner()
        {
            //Displaying the winner
            if (PlayerTurn == false)
            {
                MessageBox.Show(Player1Name + " is the winner");
                Winner = true;
                //Resets game
                EndGame();

            }
            else if (PlayerTurn == true)
            {
                MessageBox.Show(Player2Name + " is the winner");
                Winner = true;
                EndGame();
            }
        }

        //Check win case horizontal
        public void Checkside()
        {
            //grabbing buttons from method
            SetButtonArray();
            //going through each row
            for (int k = 0; k <= 12; k = k + 4)
            {
                if ((buttonarray[k].Text.Equals(buttonarray[k + 1].Text)) &&
                    (buttonarray[k].Text.Equals(buttonarray[k + 2].Text)) &&
                    (buttonarray[k].Text.Equals(buttonarray[k + 3].Text)) &&
                    (!buttonarray[k].Text.Equals("")))
                {
                    ShowWinner();
                    break;
                }
            }
        }
        public void CheckVerti()
        {
            SetButtonArray();
            //checking every column
            for (int k = 0; k <= 3; k++)
            {
                if ((buttonarray[k].Text.Equals(buttonarray[k + 4].Text)) &&
                    (buttonarray[k].Text.Equals(buttonarray[k + 8].Text)) &&
                    (buttonarray[k].Text.Equals(buttonarray[k + 12].Text)) &&
                    (!buttonarray[k].Text.Equals("")))
                {
                    ShowWinner();
                    break;
                }
            }
        }
        public void CheckDiag()
        {
            SetButtonArray();

            int k = 0;

            if ((buttonarray[k].Text.Equals(buttonarray[k + 5].Text)) &&
                (buttonarray[k].Text.Equals(buttonarray[k + 10].Text)) &&
                (buttonarray[k].Text.Equals(buttonarray[k + 15].Text)) &&
                (!buttonarray[k].Text.Equals("")))
            {
                ShowWinner();
            }
            int g = 3;
            if ((buttonarray[g].Text.Equals(buttonarray[g + 3].Text)) &&
                (buttonarray[g].Text.Equals(buttonarray[g + 6].Text)) &&
                (buttonarray[g].Text.Equals(buttonarray[g + 9].Text)) &&
                (!buttonarray[g].Text.Equals("")))
            {
                ShowWinner();
            }
        }
        public void CheckTie()
        {
            int iCounter = 0;

            for (int i = 0; i < 16; i++)
            {

                if(buttonarray[i].Enabled == false)
                {
                    iCounter++;
                }

            }
            if (iCounter == 16)
            {
                MessageBox.Show("It's a tie!");
                Winner = true;
                btnStart.Enabled = true;
            }
        }
       

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //Calling startingplayerturn so we know who goes first
            StartingPlayerTurn();
            ButtonStart = true;
            if (NamesIn == false)
            {
                //Enabling grid
                SetButtonArray();
                ButtonStart = false;
            }
        }
        private void button_clicked(object sender, EventArgs e)
        {
            //Creating a button control that applies to all buttons 
            //because button_clicked is the button click event for every button on the grid
            Button btnXorO = (Button)sender;
            
            if(PlayerTurn == true)
            {
                lblTurn.Text = "Turn: " + Player1Name;
                btnXorO.Text = "X";
                PlayerTurn = false;
                
                lblTurn.Text = "Turn: " + Player2Name;
            }
            else if (PlayerTurn == false)
            {
                lblTurn.Text = "Turn: " + Player2Name;
                btnXorO.Text = "O";
                PlayerTurn = true;
                lblTurn.Text = "Turn: " + Player1Name;

            }
            //Disable the button so they cannot click it again
            btnXorO.Enabled = false;
            CheckTie();
            Checkside();
            CheckVerti();
            CheckDiag();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            //Restart game
            for (int i = 0; i < 16; i++)
            {
                //Clears text and reenables all buttons
                buttonarray[i].Text = "";
                buttonarray[i].Enabled = false;
            }
            txtPlayer1Name.Enabled = true;
            txtPlayer2Name.Enabled = true;
            lblTurn.Text = "";
            btnStart.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //getting rid of taborder stuff for grid buttons
            SetButtonArray();
            for (int i = 0; i < 16; i++)
            {
                buttonarray[i].TabStop = false;
            }
        }
    }
}
