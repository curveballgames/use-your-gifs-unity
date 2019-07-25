namespace UseYourGifs
{
    public class StartRoundWebsocketEvent : WebSocketEvent
    {
        public string selected_player;

        public StartRoundWebsocketEvent(string type, string room_code, string player_name) : base(type, room_code)
        {
            this.selected_player = player_name;
        }
    }
}