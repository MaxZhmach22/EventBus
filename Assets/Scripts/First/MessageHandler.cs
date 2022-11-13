using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace EventBus
{
    public static class MessageHandler
    {
        public static Dictionary<Type, List<IMessage>> MessageBus = new ();


        public static void Subscribe(IMessage receiver)
        {
            
        }
    }
}
