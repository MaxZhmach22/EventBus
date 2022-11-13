using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using TMPro;

namespace EventBus.ECS
{
    public class TextUpdateSystem : IEcsRunSystem
    {
        private readonly TMP_Text _text;
        private readonly EcsWorldInject _world = default;
        private readonly EcsFilterInject<Inc<UpDirectionRequest>> _upFilter = default;
        private readonly EcsFilterInject<Inc<DownDirectionRequest>> _downFilter = default;
        private readonly EcsFilterInject<Inc<LeftDirectionRequest>> _leftFilter = default;
        private readonly EcsFilterInject<Inc<RightDirectionRequest>> _rightFilter = default;

        public TextUpdateSystem(TMP_Text text) =>
            _text = text;
         

        public void Run(IEcsSystems systems)
        {
            _text.text = "";
            
            foreach (var entity in _upFilter.Value)
            {
                _text.text += "Up ";
            }
            foreach (var entity in _downFilter.Value)
            {
                _text.text += "Down ";
            }
            foreach (var entity in _leftFilter.Value)
            {
                _text.text += "Left ";
                
            }
            foreach (var entity in _rightFilter.Value)
            {
                _text.text += "Right ";
            }
        }
    }
}