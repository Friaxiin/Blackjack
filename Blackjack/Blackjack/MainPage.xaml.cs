using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Blackjack
{
    public partial class MainPage : ContentPage
    {
        public string[] Value = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public string[] Color = { "♠", "♥", "♣", "♦" };
        public int SumUser = 0;
        public int SumEnemy = 0;
        public Dictionary<string, int> CardDict = new Dictionary<string, int>()
        {
            {"A" , 1},
            {"2" , 2},
            {"3" , 3},
            {"4" , 4},
            {"5" , 5},
            {"6" , 6},
            {"7" , 7},
            {"8" , 8},
            {"9" , 9},
            {"10" , 10},
            {"J" , 11},
            {"Q" , 12},
            {"K" , 13},
        };

        public MainPage()
        {
            InitializeComponent();
            sumULbl.Text = SumUser.ToString();
            sumELbl.Text = SumEnemy.ToString();
        }

        private void DrawCardUser(object sender, EventArgs e)
        {
            //Rand
            Random random = new Random();
            int cardIndex = random.Next(0, 12);
            int cardColor = random.Next(0, 3);

            //Card
            Card card = new Card();
            card.CardValue = Value[cardIndex];
            card.CardColor = Color[cardColor];

            Label CardValue = new Label()
            {
                Text = card.CardValue.ToString(),
                FontSize = 36,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            Label CardColor = new Label()
            {   
                Text = card.CardColor.ToString(),
                FontSize = 12,
                HorizontalTextAlignment = TextAlignment.Start
            };

            //Card layout
            StackLayout CardLayoutUser = new StackLayout()
            {
                WidthRequest = 70,
                HeightRequest = 100,
                BackgroundColor = Xamarin.Forms.Color.White,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 0, 10, 0),
                HorizontalOptions = LayoutOptions.Start,
            };


            //Adding values to layout
            CardLayoutUser.Children.Add(CardColor);
            CardLayoutUser.Children.Add(CardValue);

            //Adding to deck
            cardDeckUser.Children.Add(CardLayoutUser);

            SumUser += CardDict[card.CardValue];

            sumULbl.Text = SumUser.ToString();

            CheckScore();

            if (SumUser < 21 && cardDeckUser.Children.Count != 0)
            {
                DrawCardEnemy();
            }
        }
        private void DrawCardEnemy()
        {
            //Rand
            Random random = new Random();
            int cardIndex = random.Next(0, 12);
            int cardColor = random.Next(0, 3);

            //Card
            Card card = new Card();
            card.CardValue = Value[cardIndex];
            card.CardColor = Color[cardColor];

            Label CardValue = new Label()
            {
                Text = card.CardValue.ToString(),
                FontSize = 36,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            Label CardColor = new Label()
            {
                Text = card.CardColor.ToString(),
                FontSize = 12,
                HorizontalTextAlignment = TextAlignment.Start
            };

            //Card layout
            StackLayout CardLayoutEnemy = new StackLayout()
            {
                WidthRequest = 70,
                HeightRequest = 100,
                BackgroundColor = Xamarin.Forms.Color.White,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 0, 10, 0),
                HorizontalOptions = LayoutOptions.Start,
            };

            //Adding values to layout
            CardLayoutEnemy.Children.Add(CardColor);
            CardLayoutEnemy.Children.Add(CardValue);

            //Adding to deck
            cardDeckEnemy.Children.Add(CardLayoutEnemy);

            SumEnemy += CardDict[card.CardValue];

            sumELbl.Text = SumEnemy.ToString();

            CheckScore();

        }
        public void Restart()
        {
            SumUser = 0;
            sumULbl.Text = SumUser.ToString();
            SumEnemy = 0;
            sumELbl.Text = SumEnemy.ToString();
            cardDeckUser.Children.Clear();
            cardDeckEnemy.Children.Clear();
        }
        public async void CheckScore()
        {
            if (SumEnemy == 21 && SumUser == 21)
            {
                await DisplayAlert("Remis", "Ty: " + SumUser + ", Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumEnemy > 21 && SumUser <= 21 || SumUser == 21 && SumEnemy != 21)
            {
                await DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumUser > 21 || SumEnemy == 21 && SumUser != 21)
            {
                await DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
        }

        private void Pass(object sender, EventArgs e)
        {
            if (SumEnemy <= SumUser)
            {
                DrawCardEnemy();
            }
            PassCheckScore();
        }
        public async void PassCheckScore()
        {
            if (SumEnemy == SumUser)
            {
                await DisplayAlert("Remis", "Ty: " + SumUser + ", Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumUser > SumEnemy)
            {
                await DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumEnemy > SumUser)
            {
                await DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
        }
    }
}
