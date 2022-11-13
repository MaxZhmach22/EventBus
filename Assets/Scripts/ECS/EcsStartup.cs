using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using NaughtyAttributes;
using TMPro;
using UnityEngine;


namespace EventBus.ECS 
{
    sealed class EcsStartup : MonoBehaviour 
    {
        [field: BoxGroup("References")] [field: SerializeField] public GameObject Player { get; private set; }
        [field: BoxGroup("References")] [field: SerializeField] public TMP_Text Text { get; private set; }
        EcsWorld _world;        
        IEcsSystems _systems;

        void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
               
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Add(new PlayerInitSystem(Player.transform))
                .ClearInput()
                .Add(new InputSystem())
                .Add(new PlayerMoveSystem())
                .Add(new TextUpdateSystem(Text))
                .Inject()
                .Inject(Player)
                .Init();
        }

        void Update () 
        {
            _systems?.Run ();
        }
        
        void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) 
            {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}