using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Blackjack
{
    public partial class MainPage : ContentPage
    {
        public string[] Value = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public string[] Color = { "♠", "♥", "♣", "♦" };
        public int SumUser = 0;
        public int SumEnemy = 0;
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
                HorizontalTextAlignment = TextAlignment.End,
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

            switch (card.CardValue)
            {
                case "A":
                    SumUser += 1;
                    break;
                case "2":
                    SumUser += 2;
                    break;
                case "3":
                    SumUser += 3;
                    break;
                case "4":
                    SumUser += 4;
                    break;
                case "5":
                    SumUser += 5;
                    break;
                case "6":
                    SumUser += 6;
                    break;
                case "7":
                    SumUser += 7;
                    break;
                case "8":
                    SumUser += 8;
                    break;
                case "9":
                    SumUser += 9;
                    break;
                case "10":
                    SumUser += 10;
                    break;
                case "J":
                    SumUser += 11;
                    break;
                case "Q":
                    SumUser += 12;
                    break;
                case "K":
                    SumUser += 13;
                    break;
            }
            sumULbl.Text = SumUser.ToString();
            DrawCardEnemy();
            /*
            if (SumUser > 21)
            {
                DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            else if (SumUser == 21 && SumEnemy != 21)
            {
                DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }*/
            CheckScores();
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
                HorizontalTextAlignment = TextAlignment.End,
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

            switch (card.CardValue)
            {
                case "A":
                    SumEnemy += 1;
                    break;
                case "2":
                    SumEnemy += 2;
                    break;
                case "3":
                    SumEnemy += 3;
                    break;
                case "4":
                    SumEnemy += 4;
                    break;
                case "5":
                    SumEnemy += 5;
                    break;
                case "6":
                    SumEnemy += 6;
                    break;
                case "7":
                    SumEnemy += 7;
                    break;
                case "8":
                    SumEnemy += 8;
                    break;
                case "9":
                    SumEnemy += 9;
                    break;
                case "10":
                    SumEnemy += 10;
                    break;
                case "J":
                    SumEnemy += 11;
                    break;
                case "Q":
                    SumEnemy += 12;
                    break;
                case "K":
                    SumEnemy += 13;
                    break;
            }
            sumELbl.Text = SumEnemy.ToString();
            /*
            if (SumEnemy > 21)
            {
                DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumEnemy == 21 && SumUser != 21)
            {
                DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            */
            CheckScores();

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
        public void CheckScores()
        {

                if (SumEnemy > 21 && SumUser <= 21)
                {
                    DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                    Restart();
                }
                else
                { 
                    if (SumUser > 21)
                    {
                        DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                        Restart();
                    }
                    else
                    {
                        if (SumEnemy == 21 && SumUser != 21)
                        {
                            DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                            Restart();
                        }
                        else
                        {
                            if (SumUser == 21 && SumEnemy != 21)
                            {
                                DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                                Restart();
                            }
                        }
                    }
                }
            
        }
        private void Pass(object sender, EventArgs e)
        {
            if (SumEnemy < SumUser)
            {
                DrawCardEnemy();
            }
            PassCheckScores();
        }
        public void PassCheckScores()
        {
            if (SumUser > SumEnemy)
            {
                DisplayAlert("Wygrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
            if (SumEnemy > SumUser)
            {
                DisplayAlert("Przegrywasz", "Ty: " + SumUser + " Przeciwnik: " + SumEnemy, "OK");
                Restart();
            }
        }
    }
}
