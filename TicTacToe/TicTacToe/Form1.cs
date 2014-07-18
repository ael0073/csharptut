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
    public partial class TicTacToe : Form
    {
        bool turn = true; //true = X turn; false = Y turn
        int numOfTurns = 0; //if 9, game over & draw
        static string player1;
        static string player2;
        bool computer = false;

        public static void setPlayerNames(string name1, string name2)
        {
            player1 = name1;
            player2 = name2;
        }
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;*/
            setPlayerDefaultsToolStripMenuItem.PerformClick();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //when the user clicks the about button, a message window displays info about the game
            MessageBox.Show("By Katia", "About Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn; //after a player has made his move, it is the next player's turn to move
  
            //disable button so that no future moves can affect the value of the button once it has already been set
            b.Enabled = false;
            numOfTurns++;
            checkForWinner();

            if (!turn && computer) computer_make_move();
        }

        private void computer_make_move()
        {
            /* Computer moves:
             * Priority 1: Get Tic Tac Toe - if the Computer has a winning move, it must make that move
             * Priority 2: Block X Tic Tac Toe - if no win is possible, and X may make a move to win, the computer must block that move
             * Priority 3: If a corner space is available, go for that move
             * Priority 4: If none of the above are available, then just pick an open space
             */

            Button move = new Button();
            move = winOrBlock("O");
            if (move == null)
            {
                move = winOrBlock("X");
                if(move==null)
                {
                    move = findCorner();
                    if(move==null)
                    {
                        move = findSpace();
                    }
                }
            }
            if(move!=null)
            move.PerformClick();
        }

        private Button findCorner()
        {
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button findSpace()
        {
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }//end if
            }//end if

            return null;
        }
        private Button winOrBlock(string mark)
        { 
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
        }
        private void checkForWinner()
        {
            bool win = false;
            //check horizontals
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) win = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) win = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) win = true;

            //check vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) win = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) win = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) win = true;

            //check diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) win = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) win = true;

            
            if(win)
            {
                //disable all buttons since the game has already been won and no more moves can be made
                disableButtons();
                string winner = "";
                if(turn)
                {
                    winner = player2;
                    OWinCount.Text = (Int32.Parse(OWinCount.Text) + 1).ToString();
                  //  disableButtons();

                } else
                {
                    winner = player1;
                    XWinCount.Text = (Int32.Parse(XWinCount.Text) + 1).ToString();
                  //  disableButtons();
                }
                MessageBox.Show("Congratulations Player "+winner+". You have won the game!");
            }
            else
            {

                if (numOfTurns == 9)
                {
                    DrawCount.Text = (Int32.Parse(DrawCount.Text) + 1).ToString();
                    MessageBox.Show("Draw! No one has won the game.");
                 //   disableButtons();
                }
            }
        }

        private void disableButtons()
        {
            foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                }
           
        }

        //method will be used to show whose turn it is to play (X||O)
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled) b.Text=(turn)?"X":"O";
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled) b.Text = "";
        }

        private void newGame_Click(object sender, EventArgs e)
        {
       
            foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
              }
            
            numOfTurns = 0;
            turn = true;
        
        }

        private void resetScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OWinCount.Text = "0";
            XWinCount.Text = "0";
            DrawCount.Text = "0";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OWinCount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "Katia";
            p2.Text = "Computer";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Computer boolean " + computer);
            if (p2.Text.ToUpper() == "COMPUTER") computer = true;
            else computer = false;
        }

       
    }
}
