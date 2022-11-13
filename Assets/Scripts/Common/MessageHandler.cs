using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace EventBus
{
    public static class MessageHandler
    {
        private static readonly Dictionary<Type, List<IMessage>> MessageBus = new ();
        
        public static void Subscribe(IMessage receiver)
        {
            var receiverTypes = GetSubscribersTypes(receiver);

            foreach (var type in receiverTypes)
            {
                if (!MessageBus.ContainsKey(type))
                {
                    MessageBus[type] = new List<IMessage>();
                }
                MessageBus[type].Add(receiver);
                Debug.Log($"{type} {nameof(Subscribe)}");
            }
        }
        
        public static List<Type> GetSubscribersTypes(IMessage receiver)
        {
            var type = receiver.GetType();
            var subscriberTypes = type
                .GetInterfaces()
                .Where(it => typeof(IMessage).IsAssignableFrom(it) && it != typeof(IMessage))
                .ToList();

            return subscriberTypes;
        }
        
        public static void SendMessage<TReceiver>(Action<TReceiver> action) where TReceiver : class, IMessage
        {
            List<IMessage> receivers = MessageBus[typeof(TReceiver)];
            foreach (IMessage receiver in receivers)
            {
                action.Invoke(receiver as TReceiver);
            }
        }

        public static void UnSubscribe(IMessage receiver)
        {
            List<Type> subscriberTypes = GetSubscribersTypes(receiver);
            
            foreach (var type in subscriberTypes)
            {
                if (MessageBus.ContainsKey(type))
                {
                    MessageBus[type].Remove(receiver);
                    Debug.Log($"{type} {nameof(UnSubscribe)}");
                }
            }
        }
    }
}
