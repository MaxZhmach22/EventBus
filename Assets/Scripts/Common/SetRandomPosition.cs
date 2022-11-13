using System;
using UnityEngine;

namespace EventBus
{
    public class SetRandomPosition : ISetRandomPosition, IDisposable
    {
        private readonly GameObject _sphere;
     

        public SetRandomPosition(GameObject sphere)
        {
            _sphere = sphere;
            
            MessageHandler.Subscribe(this);
        }

        public void RandomPosition(Vector3 position)
        {
            _sphere.transform.position = position;
            Debug.Log(_sphere.transform.position);
        }
        
        public void Dispose()
        {
            MessageHandler.UnSubscribe(this);
        }
    }
}