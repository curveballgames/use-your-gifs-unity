using Curveball;

namespace VillageBuilder
{
    public struct CreatePlayerEvent : IEvent
    {
        public string PlayerName;

        public CreatePlayerEvent(string playerName)
        {
            PlayerName = playerName;
        }
    }
}