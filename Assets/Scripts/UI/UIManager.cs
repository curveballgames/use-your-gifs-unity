using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace UseYourGifs
{
    public class UIManager : CBGGameObject
    {
        public MenuScreen LobbyScreen;
        public MenuScreen GameStartScreen;
        public PromptEntryMenuScreen PromptEntryScreen;

        private void Awake()
        {
            MenuSystem.OpenMenu(LobbyScreen, true);

            EventSystem.Subscribe<StartGameEvent>(OnStartGame, this);
            EventSystem.Subscribe<RoundStartedEvent>(OnRoundStarted, this);
        }

        void OnStartGame(StartGameEvent e)
        {
            MenuSystem.OpenMenu(GameStartScreen, true);
        }

        void OnRoundStarted(RoundStartedEvent e)
        {
            MenuSystem.OpenMenu(PromptEntryScreen, true);
            PromptEntryScreen.SetPlayerName(e.PlayerName);
        }
    }
}