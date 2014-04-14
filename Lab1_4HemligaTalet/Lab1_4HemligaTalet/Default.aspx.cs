using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab1_4HemligaTalet.Model;

namespace Lab1_4HemligaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber _secretNumer;

        private SecretNumber SecretNumber
        {
            get 
            { 
                _secretNumer = Session["SecretNumber"] as SecretNumber;
                if (_secretNumer == null)
                {
                    _secretNumer = new SecretNumber();
                    Session["SecretNumber"] = _secretNumer;
                }
                return _secretNumer;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GuessTextBox.Focus();
        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Outcome outcome;
                int guess = int.Parse(GuessTextBox.Text);
                outcome = SecretNumber.MakeGuess(guess);

                if (outcome == Outcome.Correct)
                {
                    Label2.Text = "Rätt, det tog " + SecretNumber.Count + " försök";
                    OkButton.Enabled = false;
                    GuessTextBox.Enabled = false;
                    NewButton.Visible = true;
                }
                else if (outcome == Outcome.NoMoreGuesses)
                {
                    Label2.Text = "Slut på försök";
                    OkButton.Enabled = false;
                }
                else if (outcome == Outcome.Low)
                {
                    Label2.Text = "För lågt";
                }
                else if (outcome == Outcome.High)
                {
                    Label2.Text = "För högt";
                }

                for (int i = 0; i < SecretNumber.Count; i++)
                {
                    Label1.Text += SecretNumber.PreviousGuesses[i];
                    Label1.Text += " ";
                }

                if (!SecretNumber.CanMakeGuess && SecretNumber.Outcome != Outcome.Correct)
                {
                    Label2.Text += "Slut på försök, det hemliga talet var: " + SecretNumber.Number;
                    OkButton.Enabled = false;
                    GuessTextBox.Enabled = false;
                    NewButton.Visible = true;
                }
            }
        }

        protected void NewButton_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}