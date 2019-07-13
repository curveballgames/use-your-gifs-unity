using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace VillageBuilder
{
    public class WebSocketEventHandler : CBGGameObject
    {
        private static Queue<Message> messagesToProcess = new Queue<Message>();

        public static void QueueMessage(Message message)
        {
            messagesToProcess.Enqueue(message);
        }

        private void LateUpdate()
        {
            while (messagesToProcess.Count > 0)
            {
                Message nextMessage = messagesToProcess.Dequeue();
                string type = nextMessage.EventType;

                switch (type)
                {
                    case "room_created":
                        HandleRoomCreated(nextMessage);
                        break;
                    case "player_joined":
                        HandlePlayerJoined(nextMessage);
                        break;
                    case "error":
                        HandleError(nextMessage);
                        break;
                }
            }
        }

        void HandleRoomCreated(Message message)
        {
            string roomCode = (string) message.GetField("room_code");
            EventSystem.Publish(new RoomCreatedEvent(roomCode));
        }

        void HandlePlayerJoined(Message message)
        {
            string playerName = (string)message.GetField("player_name");
            EventSystem.Publish(new CreatePlayerEvent(playerName));
        }

        void HandleError(Message message)
        {
            // TODO
        }
    }
}