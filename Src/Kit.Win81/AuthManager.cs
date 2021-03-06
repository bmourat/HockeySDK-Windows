﻿using Microsoft.HockeyApp.Tools;
using Microsoft.HockeyApp.ViewModels;
using Microsoft.HockeyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;

namespace Microsoft.HockeyApp
{
    internal partial class AuthManager
    {

        Popup authPopup;

        protected void ShowLoginScreen(AuthenticationMode authMode, string appSecret, string email, AuthValidationMode authValidationMode)
        {
            var vm = new LoginVM();
            vm.AuthMode = authMode;
            vm.Email = email;
            vm.AppSecret = appSecret;

            var dialog = new LoginDialog();
            dialog.DataContext = vm;
            dialog.CloseRequested += Dialog_CloseRequested;
            authPopup = new Popup();
            authPopup.Child = dialog;
            authPopup.IsOpen = true;
            dialog.OnOpened(authMode, authValidationMode);
        }

        private void Dialog_CloseRequested(object sender, EventArgs e)
        {
            authPopup.IsOpen = false;
        }

    }
}
