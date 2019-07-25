using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;
using TMPro;

namespace UseYourGifs
{
    public class LobbyScreen : SimpleMenuScreen
    {
        public GameObject ConnectingParent;
        public GameObject LobbyParent;

        public TextMeshProUGUI RoomCode;
        public LobbyNameContainer[] NameContainers;

        private bool initialised = false;

        public override void Open(bool instant)
        {
            base.Open(instant);

            if (!initialised)
            {
                initialised = true;

                ConnectingParent.SetActive(true);
                LobbyParent.SetActive(false);
                UpdateLobbyNameContainerVisibility();

                EventSystem.Subscribe<RoomCreatedEvent>(OnRoomCreated, this);
                EventSystem.Subscribe<PlayersUpdatedEvent>(OnPlayersUpdated, this);
            }
        }

        void OnRoomCreated(RoomCreatedEvent e)
        {
            RoomCode.text = e.RoomCode;

            ConnectingParent.SetActive(false);
            LobbyParent.SetActive(true);
            UpdateLobbyNameContainerVisibility();
        }

        void OnPlayersUpdated(PlayersUpdatedEvent e)
        {
            UpdateLobbyNameContainerVisibility();
        }

        void UpdateLobbyNameContainerVisibility()
        {
            for (int i = 0; i < NameContainers.Length; i++)
            {
                Player p = PlayerManager.Players[i];

                NameContainers[i].SetActive(p != null);

                if (p != null)
                {
                    NameContainers[i].SetName(p.Name);
                }
            }
        }
    }
}