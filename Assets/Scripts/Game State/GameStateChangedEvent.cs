using Curveball;

namespace UseYourGifs
{
    public struct GameStateChangedEvent : IEvent
    {
        public GameState NewState;

        public GameStateChangedEvent(GameState newState)
        {
            NewState = newState;
        }
    }
}