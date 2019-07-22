using RhumbixAPIConnector.Models;
using RhumbixAPIConnector.ViewModels.Commands;
using System;
using System.Windows;

namespace RhumbixAPIConnector.ViewModels
{
    public class ApiKeysVm
    {
        public Tokens Tokens { get; set; }
        public SaveTokenCommand SaveTokenCommand { get; set; }
        public ApiKeysVm()
        {
            Tokens = new Tokens();
            SaveTokenCommand = new SaveTokenCommand(this);
        }

        public async void EncryptAndSaveTokenAsync(Tokens savedTokens)
        {
            var hashedToken = Crypto.EncryptStringAES(savedTokens.ApiToken, savedTokens.SecretPin);
            var hashedSecret = Crypto.EncryptStringAES(savedTokens.SecretPin, savedTokens.SecretPin);

            var hashedKeys = new Tokens() { ApiToken = hashedToken, SecretPin = hashedSecret };

            var numOfRows = await DatabaseHelper.Insert<Tokens>(hashedKeys, true);
            FileSystemsHelpers.WriteToFile($"Api Key have been saved! {DateTime.Now}");

            MessageBox.Show("Api token has been saved!", "Rhumbix Encrypt", MessageBoxButton.OK,
                MessageBoxImage.Information);

        }
    }
}
