using Curveball;

namespace UseYourGifs
{
    public class RoundController : CBGGameObject
    {
        private void Awake()
        {
            EventSystem.Subscribe<GameStateChangedEvent>(OnGameStateChanged, this);
        }

        void OnGameStateChanged(GameStateChangedEvent e)
        {
            if (e.NewState == GameState.NewRound)
            {
                StartNewRound();
                return;
            }
        }

        void StartNewRound()
        {
            Player controller = PlayerManager.GetNextController();
            StartRoundWebsocketEvent ev = new StartRoundWebsocketEvent("start_round", RoomController.RoomCode, controller.Name);
            WebSocketConnector.SendEvent(ev);

            EventSystem.Publish(new RoundStartedEvent(controller.Name));
        }
    }
}