using UnityEngine;


namespace EventBus.Common
{
    public interface ISetRandomPosition : IMessage
    {
        void RandomPosition(Vector3 position);
    }
}