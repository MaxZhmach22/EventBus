using NaughtyAttributes;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace EventBus.UniRX
{
    public class UniRXStarter : MonoBehaviour
    {
        [field: BoxGroup("References")] [field: SerializeField] public Button SetDamage { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public Button SomeMessage { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public Button SetRandomPosition { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public TMP_Text DamageText { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public TMP_Text SomeText { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public GameObject Sphere { get; private set; }


        private void Start()
        {
            Bind();
            
            MessageBroker.Default.Receive<IDamage>()
                .Subscribe(_ => DamageText.text = "Hit")
                .AddTo(this);
            
            MessageBroker.Default.Receive<ISomeMessage>()
                .Subscribe(_=>
                {
                    SomeText.color = Color.red;
                    SomeText.text = "New Info";
                })
                .AddTo(this);
            
            MessageBroker.Default.Receive<ISetRandomPosition>()
                .Subscribe(_ => Sphere.transform.position = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f)))
                .AddTo(this);
        }

        private void Bind()
        {
            SetDamage.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish<IDamage>(new SomeDamage()))
                .AddTo(this);
            
            SomeMessage.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish<ISomeMessage>(new PrintRedMessage()))
                .AddTo(this);
            
            SetRandomPosition.OnClickAsObservable()
                .Subscribe(_ => MessageBroker.Default.Publish<ISetRandomPosition>(new SetRandomPosition()))
                .AddTo(this);
        }
    }
}
