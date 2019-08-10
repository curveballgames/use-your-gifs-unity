using Curveball;

namespace UseYourGifs
{
    public class GameStateManager : CBGGameObject
    {
        private static GameState currentState;

        public static GameState CurrentState {
            get => currentState;
            set {
                if (currentState == value)
                    return;

                currentState = value;
                EventSystem.Publish(new GameStateChangedEvent(currentState));
            }
        }

        private void Awake()
        {
            CurrentState = GameState.Lobby;

            EventSystem.Subscribe<StartGameEvent>(OnStartGame, this);
            EventSystem.Subscribe<NewGameCountdownCompleteEvent>(OnNewGameCountdownComplete, this);
            EventSystem.Subscribe<ConnectToNewRoomEvent>(OnConnectToNewRoom, this);
        }

        void OnStartGame(StartGameEvent e)
        {
            if (CurrentState == GameState.Lobby)
            {
                CurrentState = GameState.StartingGame;
            }
        }

        void OnNewGameCountdownComplete(NewGameCountdownCompleteEvent e)
        {
            CurrentState = GameState.NewRound;
        }

        void OnConnectToNewRoom(ConnectToNewRoomEvent e)
        {
            CurrentState = GameState.Lobby;
        }
    }
}