using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;


namespace EventBus.Common
{
    public class PrintDamageMessageOnScreen : IDamage, IDisposable
    {
        private readonly TMP_Text _textField;
        private readonly CancellationToken _token;


        public PrintDamageMessageOnScreen(TMP_Text textField, CancellationToken token)
        {
            _textField = textField;
            _token = token;
            
            MessageHandler.Subscribe(this);
        }

        public async void Hit()
        {
            _textField.color = Color.red;
            _textField.text = "Hitted";

            await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: _token);
            
            _textField.text = "";
        }

        public void Dispose()
        {
            MessageHandler.UnSubscribe(this);
        }
    }
}