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
                return MaxNumberOfGuesses > Count && !_previousGuesses.Contains(_number);
            }
        }

        public int Count
        { get { if (PreviousGuesses == null) { return 0; } else { return PreviousGuesses.Count; } } }

        public int? Number
        {
            get 
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
                
        }

        public Outcome Outcome
        { get; set; }

        public List<int> PreviousGuesses
        { get { return _previousGuesses; } }

        public SecretNumber()
        {
            _previousGuesses = new List<int>();
            Initialize();
        }

        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (CanMakeGuess == false)
            {
                return Outcome.NoMoreGuesses;
            }
            else if (guess == _number)
            {
                PreviousGuesses.Add(guess);
                return Outcome.Correct;
            }
            else if (guess < _number)
            {
                PreviousGuesses.Add(guess);
                return Outcome.Low;
            }
            else
            {
                PreviousGuesses.Add(guess);
                return Outcome.High;
            }
        }
    }
}