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
        public SecretNumber _secretNumer;

        public SecretNumber SecretNumer
        {
            get { return _secretNumer ?? (_secretNumer = new SecretNumber()); }
            set { _secretNumer = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GuessTextBox.Focus();
            if (Session["a"] != null)
            {
                Label1.Text = "";
                SecretNumer = (SecretNumber)Session["a"];
                Session.Remove("a");
            }
        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Outcome outcome;
                int guess = int.Parse(GuessTextBox.Text);
                outcome = SecretNumer.MakeGuess(guess);

                if (outcome == Outcome.Correct)
                {
                    Label2.Text = "Rätt, det tog " + SecretNumer.Count + " försök";
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

                for (int i = 0; i < SecretNumer.Count; i++)
                {
                    Label1.Text += SecretNumer.PreviousGuesses[i];
                    Label1.Text += " ";
                }
                if (SecretNumer.CanMakeGuess == false)
                {
                    Label2.Text = "Slut på försök, det hemliga talet var: " + SecretNumer.Number;
                    OkButton.Enabled = false;
                    GuessTextBox.Enabled = false;
                    NewButton.Visible = true;
                }
                Session["a"] = SecretNumer;
                GuessTextBox.Focus();
            }
        }

        protected void NewButton_Click(object sender, EventArgs e)
        {

        }
    }
}