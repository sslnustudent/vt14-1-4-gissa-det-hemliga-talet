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
        public SecretNumber secretNumer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["a"] != null)
            {
                secretNumer = (SecretNumber)Session["a"];
                Session.Remove("a");
                //Label1.Text = secretNumer.PreviousGuesses;
                for (int i = 0; i < secretNumer.Count; i++ )
                {
                    Label1.Text += secretNumer.PreviousGuesses[i];
                }
            }
        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            Outcome outcome;
            int guess = int.Parse(GuessTextBox.Text);
            outcome = secretNumer.MakeGuess(guess);

            if (outcome == Outcome.Correct)
            {
                Label1.Text = "Rätt";
            }
            else if (outcome == Outcome.Low)
            {
                Label1.Text = "För lågt";
            }
            else if (outcome == Outcome.High)
            {
                Label1.Text = "För högt";
            }


            Session["a"] = secretNumer;
        }
    }
}