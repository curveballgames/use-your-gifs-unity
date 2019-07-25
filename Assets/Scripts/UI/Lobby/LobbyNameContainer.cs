using Curveball;
using TMPro;

namespace UseYourGifs
{
    public class LobbyNameContainer : CBGUIComponent
    {
        public TextMeshProUGUI NameText;

        public void SetName(string name)
        {
            NameText.text = name;
            SetActive(name != null);
        }
    }
}