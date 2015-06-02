using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameCalculator
{
    public partial class _default : System.Web.UI.Page
    {
        // integer values to keep track of wins/losses
        int winCounter = 0;
        int lossCounter = 0;
        // double value that defines the total amount of games
        double maxGames = 4;
        // decimal values to keep track of the total points scored and allowed across all games
        decimal pointsScored = 0;
        decimal pointsAllowed = 0;
        decimal pointDifferential = 0;
        // decimal values to keep track of number of attendants across all games
        decimal totalAttendance = 0;
        decimal averageAttendance = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            //calculate the wins/losses
            calculateOutcome(rblGame1Outcome.SelectedItem.Text);
            calculateOutcome(rblGame2Outcome.SelectedItem.Text);
            calculateOutcome(rblGame3Outcome.SelectedItem.Text);
            calculateOutcome(rblGame4Outcome.SelectedItem.Text);

            //show the total calculated wins
            lblWins.Text = winCounter.ToString();

            //show the total calculated losses
            lblLosses.Text = lossCounter.ToString();

            //calculate and show the win percentage
            Double winPercentage = winCounter / maxGames;
            lblWinPercent.Text = winPercentage.ToString();

            //calculate and show total points scored
            pointsScored = Convert.ToDecimal(txtGame1Scored.Text) + Convert.ToDecimal(txtGame2Scored.Text) + Convert.ToDecimal(txtGame3Scored.Text) + Convert.ToDecimal(txtGame4Scored.Text);
            lblPointsScored.Text = pointsScored.ToString();

            //calculate and show total points allowed
            pointsAllowed = Convert.ToDecimal(txtGame1Allowed.Text) + Convert.ToDecimal(txtGame2Allowed.Text) + Convert.ToDecimal(txtGame3Allowed.Text) + Convert.ToDecimal(txtGame4Allowed.Text);
            lblPointsAllowed.Text = pointsAllowed.ToString();

            //calculate and show the point differential
            pointDifferential = pointsScored - pointsAllowed;
            lblPointDiff.Text = pointDifferential.ToString();

            //calculate and show the total attendance across all games
            totalAttendance = Convert.ToDecimal(txtGame1Spectators.Text) + Convert.ToDecimal(txtGame2Spectators.Text) + Convert.ToDecimal(txtGame3Spectators.Text) + Convert.ToDecimal(txtGame4Spectators.Text);
            lblTotalAttendance.Text = totalAttendance.ToString();

            //calculate and show the average attendance across all games
            averageAttendance = totalAttendance / Convert.ToDecimal(maxGames);
            lblAvgAttendance.Text = averageAttendance.ToString();

            //show the results panel
            pnlResults.Visible = true;
        }

        //this method accepts the user's win/loss choices and tallies the results
        private void calculateOutcome(string gameOutcome)
        {
            if (gameOutcome == "Win")
            {
                winCounter++;
            }
            else
            {
                lossCounter++;
            }
        }

    }
}