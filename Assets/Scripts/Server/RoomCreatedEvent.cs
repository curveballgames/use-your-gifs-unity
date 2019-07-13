using Curveball;

namespace VillageBuilder
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