using UnityEngine;
using Curveball;
using TMPro;

namespace UseYourGifs
{
    public class StartGameScreen : SimpleMenuScreen
    {
        private const float COUNTDOWN_TIME = 3f;

        public TextMeshProUGUI CountdownText;

        public override void Open(bool instant)
        {
            base.Open(instant);

            CountdownText.text = ((int)COUNTDOWN_TIME).ToString();
            Timer.CreateTimer(gameObject, COUNTDOWN_TIME, OnCountdownComplete, OnCountdownUpdated);
        }

        void OnCountdownComplete()
        {
            EventSystem.Publish(new NewGameCountdownCompleteEvent());
        }

        void OnCountdownUpdated(float t, float nt)
        {
            int secondsRemaining = Mathf.CeilToInt(COUNTDOWN_TIME - t);
            CountdownText.text = secondsRemaining.ToString();
        }
    }
}