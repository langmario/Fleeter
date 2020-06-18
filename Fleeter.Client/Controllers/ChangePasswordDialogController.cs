using Fleeter.Client.Framework;
using Fleeter.Client.Services;
using Fleeter.Client.UserServiceProxy;
using Fleeter.Client.ViewModels;
using Fleeter.Client.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Fleeter.Client.Controllers
{
    public class ChangePasswordDialogController
    {
        private ChangePasswordDialog _dialog;
        private ChangePasswordDialogViewModel _vm;
        private readonly IAuthenticationService _authService;

        public ChangePasswordDialogController(IAuthenticationService authService)
        {
            _authService = authService;
        }


        public void ShowPasswordChangeDialog()
        {
            _vm = new ChangePasswordDialogViewModel();
            _vm.Change = new RelayCommand(async o =>
            {
                if (!Validate(out var errors))
                {
                    MessageBox.Show(string.Join(Environment.NewLine, errors), "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        var result = await _authService.ChangePassword(_vm.OldPassword, _vm.NewPassword);
                        if (result.Status != Status.Updated)
                        {
                            MessageBox.Show(result.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            _dialog.Close();
                            _authService.Logout();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }, o => !(string.IsNullOrEmpty(_vm.OldPassword) || string.IsNullOrEmpty(_vm.NewPassword) || string.IsNullOrEmpty(_vm.NewPasswordRepeat)));
            _vm.Cancel = new RelayCommand(o => _dialog.Close());

            _dialog = new ChangePasswordDialog
            {
                DataContext = _vm
            };

            _dialog.ShowDialog();
        }

        private bool Validate(out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrEmpty(_vm.OldPassword))
                errors.Add("Aktuelles Passwort darf nicht leer sein");

            if (string.IsNullOrEmpty(_vm.NewPassword))
                errors.Add("Neues Passwort darf nicht leer sein");

            if (!NewPasswordsMatch())
                errors.Add("Passwörter stimmen nicht überein");

            return errors.Count == 0;
        }

        private bool NewPasswordsMatch()
        {
            return !string.IsNullOrEmpty(_vm.NewPassword) && _vm.NewPassword == _vm.NewPasswordRepeat;
        }
    }
}
