using System.Collections.Generic;
using UnityEngine;
using Curveball;

using WebSocketSharp;

namespace UseYourGifs
{
    public class WebSocketConnector : CBGGameObject
    {
        private static WebSocket webSocket;

        void Start()
        {
            CreateSocketConnection();
            EventSystem.Subscribe<ConnectToNewRoomEvent>((ConnectToNewRoomEvent e) =>
            {
                webSocket.Close();
                CreateSocketConnection();
            }, this);
        }

        void CreateSocketConnection()
        {
            webSocket = new WebSocket("ws://127.0.0.1:57925/server");

            webSocket.OnMessage += OnMessage;
            webSocket.OnOpen += OnOpen;
            webSocket.OnError += OnError;

            webSocket.Connect();
        }

        private void OnOpen(object sender, System.EventArgs e)
        {

        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            Message message = new Message(e.Data);
            WebSocketEventHandler.QueueMessage(message);
        }

        private void OnError(object sender, ErrorEventArgs e)
        {
            Debug.LogError(e.Message);
        }

        private void OnApplicationQuit()
        {
            if (webSocket != null)
            {
                webSocket.Close();
            }
        }

        public static void SendEvent(WebSocketEvent e)
        {
            webSocket.Send(e.ToJSON());
        }
    }
}