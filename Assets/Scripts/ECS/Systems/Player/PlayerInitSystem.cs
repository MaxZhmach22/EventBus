using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EventBus.ECS
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly Transform _player;
        private readonly EcsWorldInject _world = default;
        private readonly EcsPoolInject<PlayerComponent> _pool = default;

        public PlayerInitSystem(Transform player) =>
            _player = player;
        
        public void Init(IEcsSystems systems)
        {
            ref var playerComp = ref _pool.Value.Add(_world.Value.NewEntity());
            playerComp.Transform = _player;
        }
        
    }
}