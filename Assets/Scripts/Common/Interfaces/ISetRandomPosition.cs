using UnityEngine;


namespace EventBus
{
    public interface ISetRandomPosition : IMessage
    {
        void RandomPosition(Vector3 position);
    }
}