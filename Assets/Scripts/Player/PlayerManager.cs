using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace UseYourGifs
{
    public class PlayerManager : CBGGameObject
    {
        public const int MAX_PLAYERS = 6;

        public static Player[] Players = new Player[MAX_PLAYERS];
        private static int nextPlayerIndex = 0;

        public static Player GetNextController()
        {
            int startIndex = nextPlayerIndex;

            do
            {
                nextPlayerIndex++;

                if (nextPlayerIndex >= Players.Length)
                {
                    nextPlayerIndex = 0;
                }
            }
            while (Players[nextPlayerIndex] == null && nextPlayerIndex != startIndex);

            if (Players[nextPlayerIndex] == null)
            {
                Debug.LogError("Oh no! No players found to become the controller.");
                return null;
            }

            return Players[nextPlayerIndex];
        }

        private void Awake()
        {
            EventSystem.Subscribe<CreatePlayerEvent>(OnCreatePlayer, this);
            EventSystem.Subscribe<StartGameEvent>(OnStartGame, this);
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

        void OnStartGame(StartGameEvent e)
        {
            ShufflePlayers();
            nextPlayerIndex = 0;
        }

        void ShufflePlayers()
        {
            for (int i = 0; i < 10; i++)
            {
                int index1 = Random.Range(0, Players.Length);
                int index2 = Random.Range(0, Players.Length);

                Player p1 = Players[index1];
                Players[index1] = Players[index2];
                Players[index2] = p1;
            }
        }
    }
}