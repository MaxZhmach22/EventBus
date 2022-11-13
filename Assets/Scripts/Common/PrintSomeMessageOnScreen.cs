using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;


namespace EventBus.Common
{
    public class PrintSomeMessageOnScreen : ISomeMessage, IDisposable
    {
        private readonly TMP_Text _textField;
        private readonly CancellationToken _getCancellationTokenOnDestroy;

        public PrintSomeMessageOnScreen(TMP_Text textField, CancellationToken getCancellationTokenOnDestroy)
        {
            _textField = textField;
            _getCancellationTokenOnDestroy = getCancellationTokenOnDestroy;
            
            MessageHandler.Subscribe(this);
        }

        public async void Print(string message)
        {
            _textField.color = Color.cyan;
            _textField.text = message;

            await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: _getCancellationTokenOnDestroy);
            
            _textField.text = "";
        }

        public void Dispose()
        {
            MessageHandler.UnSubscribe(this);
        }
    }
}