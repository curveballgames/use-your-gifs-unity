using Curveball;

namespace UseYourGifs
{
    public struct RoundStartedEvent : IEvent
    {
        public string PlayerName;

        public RoundStartedEvent(string playerName)
        {
            PlayerName = playerName;
        }
    }
}