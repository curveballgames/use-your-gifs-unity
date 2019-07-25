using Curveball;

namespace UseYourGifs
{
    public struct RoomCreatedEvent : IEvent
    {
        public string RoomCode;

        public RoomCreatedEvent(string roomCode)
        {
            RoomCode = roomCode;
        }
    }
}