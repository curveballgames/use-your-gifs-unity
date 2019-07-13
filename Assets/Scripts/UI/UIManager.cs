using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Curveball;

namespace VillageBuilder
{
    public class UIManager : CBGGameObject
    {
        public MenuScreen LobbyScreen;

        private void Awake()
        {
            MenuSystem.OpenMenu(LobbyScreen, true);
        }
    }
}