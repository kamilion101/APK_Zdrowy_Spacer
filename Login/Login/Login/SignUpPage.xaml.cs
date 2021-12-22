﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        IAuth auth;
        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void SignUpClicked(object sender, EventArgs e)
        {
            var user = auth.SignUpWithEmailAndPassword(EmailInput.Text, PasswordInput.Text);

            if (user != null)
            {
                await DisplayAlert("Success", "New User Created", "Ok");

                var signOut = auth.SignOut();

                if (signOut)
                {
                    Application.Current.MainPage = new MainPage();
                }
            }else
            {
                await DisplayAlert("ERROR", "Something went wrong, please try again", "Ok");
            }

        }

    }
}