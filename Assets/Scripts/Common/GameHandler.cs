using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace EventBus
{
    public class GameHandler : MonoBehaviour
    {
        [field: BoxGroup("References")] [field: SerializeField] public Button SetDamage { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public Button SomeMessage { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public Button SetRandomPosition { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public TMP_Text DamageText { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public TMP_Text SomeText { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public GameObject Sphere { get; private set; }

        private PrintDamageMessageOnScreen _printDamageMessageOnScreen;
        private PrintSomeMessageOnScreen _printSomeMessageOnScreen;
        private SetRandomPosition _setRandomPosition;

        private void Start()
        {
            BindButtons();
            
            _printDamageMessageOnScreen = new PrintDamageMessageOnScreen(DamageText, this.GetCancellationTokenOnDestroy());
            _printSomeMessageOnScreen = new PrintSomeMessageOnScreen(SomeText, this.GetCancellationTokenOnDestroy());
            _setRandomPosition = new SetRandomPosition(Sphere);
        }

        private void BindButtons()
        {
            SetDamage.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    MessageHandler.SendMessage<IDamage>(damage => damage.Hit());
                })
                .AddTo(this);
            
            SomeMessage.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    MessageHandler.SendMessage<ISomeMessage>(message => message.Print("Something on Screen"));
                })
                .AddTo(this);
            
            SetRandomPosition.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    MessageHandler.SendMessage<ISetRandomPosition>(setPos => 
                        setPos.RandomPosition(new Vector3(Random.Range(0f,1f), Random.Range(0f,1f), 0)));
                })
                .AddTo(this);
        }

        private void OnDestroy()
        {
            _setRandomPosition.Dispose();
            _printDamageMessageOnScreen.Dispose();
            _printSomeMessageOnScreen.Dispose();
        }
    }
}

