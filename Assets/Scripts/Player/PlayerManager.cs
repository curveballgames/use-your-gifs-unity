using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace VillageBuilder
{
    public class PlayerManager : CBGGameObject
    {
        public const int MAX_PLAYERS = 6;

        public static Player[] Players = new Player[MAX_PLAYERS];

        private void Awake()
        {
            EventSystem.Subscribe<CreatePlayerEvent>(OnCreatePlayer, this);
        }

        void OnCreatePlayer(CreatePlayerEvent e)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i] == null)
                {
                    Players[i] = new Player(e.PlayerName);
                    EventSystem.Publish(new PlayersUpdatedEvent());
                    return;
                }
            }
        }
    }
}