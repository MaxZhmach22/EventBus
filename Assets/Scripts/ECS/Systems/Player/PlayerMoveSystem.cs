using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;


namespace EventBus.ECS
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<PlayerComponent> _playerPool = default;
        private readonly EcsFilterInject<Inc<PlayerComponent, UpDirectionRequest>> _upFilter = default;
        private readonly EcsFilterInject<Inc<PlayerComponent, DownDirectionRequest>> _downFilter = default;
        private readonly EcsFilterInject<Inc<PlayerComponent, LeftDirectionRequest>> _leftFilter = default;
        private readonly EcsFilterInject<Inc<PlayerComponent, RightDirectionRequest>> _rightFilter = default;

       
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _upFilter.Value)
            {
                ref var player = ref _playerPool.Value.Get(entity);
                player.Transform.position += Vector3.up * Time.deltaTime;
            }
            
            foreach (var entity in _downFilter.Value)
            {
                ref var player = ref _playerPool.Value.Get(entity);
                player.Transform.position += Vector3.down * Time.deltaTime;
            }
            
            foreach (var entity in _leftFilter.Value)
            {
                ref var player = ref _playerPool.Value.Get(entity);
                player.Transform.position += Vector3.left * Time.deltaTime;
            }
            
            foreach (var entity in _rightFilter.Value)
            {
                ref var player = ref _playerPool.Value.Get(entity);
                player.Transform.position += Vector3.right * Time.deltaTime;
            }
        }
    }
}