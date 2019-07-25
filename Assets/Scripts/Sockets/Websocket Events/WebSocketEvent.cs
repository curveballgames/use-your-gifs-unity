using UnityEngine;

namespace UseYourGifs
{
    [System.Serializable]
    public class WebSocketEvent
    {
        public string type;
        public string room_code;

        public WebSocketEvent(string type, string room_code)
        {
            this.type = type;
            this.room_code = room_code;
        }

        public virtual string ToJSON()
        {
            return JsonUtility.ToJson(this, false);
        }
    }
}