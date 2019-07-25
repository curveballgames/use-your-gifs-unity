using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace UseYourGifs
{
    public class Message
    {
        private Dictionary<string, object> rawEvent;

        public Message(string eventData)
        {
            rawEvent = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType<Dictionary<string, object>>(eventData, rawEvent);
        }

        public object GetField(string fieldName)
        {
            return rawEvent[fieldName];
        }

        public string EventType
        {
            get
            {
                return (string)rawEvent["type"];
            }
        }
    }
}