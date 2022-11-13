using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;


namespace EventBus.ECS
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsWorldInject _world = default;
        private readonly EcsPoolInject<UpDirectionRequest> _upPool = default;
        private readonly EcsPoolInject<DownDirectionRequest> _downPool = default;
        private readonly EcsPoolInject<LeftDirectionRequest> _leftPool = default;
        private readonly EcsPoolInject<RightDirectionRequest> _rightPool = default;
        private readonly EcsFilterInject<Inc<PlayerComponent>> _playerPool = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerPool.Value)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _upPool.Value.Add(entity);
                }
            
                if (Input.GetKey(KeyCode.S))
                {
                    _downPool.Value.Add(entity);
                }
            
                if (Input.GetKey(KeyCode.A))
                {
                    _leftPool.Value.Add(entity);
                }
            
                if (Input.GetKey(KeyCode.D))
                {
                    _rightPool.Value.Add(entity);
                }
            }
        }
    }
}