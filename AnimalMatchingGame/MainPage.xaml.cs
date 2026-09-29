using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e) //method to handle the Play Again button click event
        {
            AnimalButtons.IsVisible = true; // Show the animal buttons
            PlayAgainButton.IsVisible = false; // Hide the Play Again button

            var animalEmoji = new List<string>
            {
                "🐶","🐶", // Dog
                "🐱","🐱", // Cat
                "🐭","🐭", // Mouse
                "🐹","🐹", // Hamster
                "🐰","🐰", // Rabbit
                "🦊","🦊",  // Fox
                "🐙","🐙", // Octopus
                "🐦","🐦", // Bird
            };

            foreach (var button in AnimalButtons.Children.OfType<Button>())
            {
                int index = Random.Shared.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);

        }

        int tenthsOfSecondsElapsed = 0;

        private bool TimerTick()
        {
            // Note: If your MAUI Page doesn't have IsLoaded, remove that check.
            if (!this.IsLoaded) return false;

            tenthsOfSecondsElapsed++;

            TimeElapsed.Text = "Time elapsed: " +
                (tenthsOfSecondsElapsed / 10F).ToString("0.0s");

            if (PlayAgainButton.IsVisible)
            {
                tenthsOfSecondsElapsed = 0;
                return false;
            }

            return true;
        }

        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;
        List<string> pairsFound = new List<string>();

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is not Button buttonClicked)
                return;

            // ignore clicks on already-disabled (matched) tiles
            if (!buttonClicked.IsEnabled)
                return;

            if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && !findingMatch)
            {
                buttonClicked.BackgroundColor = Colors.Red;
                lastClicked = buttonClicked;
                findingMatch = true;
                return;
            }
            else
            {
                if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && !pairsFound.Contains(buttonClicked.Text))
                {
                    matchesFound++;
                    pairsFound.Add(lastClicked.Text);

                    // Prevent future clicks on matched tiles
                    lastClicked.IsEnabled = false;
                    buttonClicked.IsEnabled = false;

                    // Optional: visually mark matched tiles and clear text
                    lastClicked.BackgroundColor = Colors.LightGray;
                    buttonClicked.BackgroundColor = Colors.LightGray;
                    lastClicked.Text = string.Empty;
                    buttonClicked.Text = string.Empty;
                }

                lastClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
            }

            if (matchesFound == 8)
            {
                matchesFound = 0;
                AnimalButtons.IsVisible = false;
                PlayAgainButton.IsVisible = true;
            }
        }
    }
}