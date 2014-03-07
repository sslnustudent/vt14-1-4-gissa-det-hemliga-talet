using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_4HemligaTalet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }

    public class SecretNumber
    {
        const int MaxNumberOfGuesses = 7;

        private int _number;

        private List<int> _previousGuesses;

        public bool CanMakeGuess
        {
            get
            {
                if (MaxNumberOfGuesses > Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int Count
        { get { return PreviousGuesses.Count; } }

        public int? Number
        {
            get 
            {
                if (CanMakeGuess == true)
                {
                    return _number;
                }
                else
                {
                    return null;
                }
            }
                
        }


        public Outcome Outcome
        { get; set; }

        public List<int> PreviousGuesses
        { get { return _previousGuesses; } }

        SecretNumber()
        {

        }

        public void Initialize()
        { }

        public Outcome MakeGuess(int guess)
        {
            return Outcome.Low;
        }
    }
}