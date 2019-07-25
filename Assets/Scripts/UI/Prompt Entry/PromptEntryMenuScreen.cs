using Curveball;
using TMPro;

namespace UseYourGifs
{
    public class PromptEntryMenuScreen : SimpleMenuScreen
    {
        private static string[] promptTemplates =
        {
            "{0} is coming up with something filthy!",
            "Hold tight, {0} is utilising all 3 of their brain cells coming up with a prompt...",
            "{0} is coming up with a prompt!",
            "Let's hope {0} has an original prompt for you to answer...",
            "Quick then {0}, come up with a cracker!",
            "I'm not sure who invited {0}, but they're responsible for this next prompt...",
            "Put the kettle on, {0} is coming up with a zinger!",
            "We might regret this, but we put {0} in charge of the next prompt..."
        };

        public TextMeshProUGUI PromptText;

        public void SetPlayerName(string name)
        {
            PromptText.text = string.Format(Utilities.SelectRandomlyFromArray(promptTemplates), name);
        }
    }
}