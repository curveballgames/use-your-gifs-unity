using Curveball;

namespace UseYourGifs
{
    public class RoomController : CBGGameObject
    {
        public static string RoomCode { get; private set; }

        private void Awake()
        {
            EventSystem.Subscribe<RoomCreatedEvent>(OnRoomCreated, this);
        }

        void OnRoomCreated(RoomCreatedEvent e)
        {
            RoomCode = e.RoomCode;
        }
    }
}