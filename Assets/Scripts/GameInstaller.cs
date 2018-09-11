using UnityEngine;

using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller> {
    public GameController gameController;
    public InputHandler inputHandler;
    public PanelManager panelManager;
    public FSM fsm;
    public CameraHandler cameraHandler;
    public PlanetGenerator planetGenerator;
    public Player player;
    public Rocket rocket;
    public TitleState titleState;
    public NewGameState newGameState;
    public EndGameState endGameState;
    public PlanetState planetState;
    public RocketState rocketState;

    public override void InstallBindings () {
        Container.BindInstance(gameController);
        Container.BindInstance(inputHandler);
        Container.BindInstance(panelManager);
        Container.BindInstance(fsm);
        Container.BindInstance(cameraHandler);
        Container.BindInstance(planetGenerator);
        Container.BindInstance(player);
        Container.BindInstance(rocket);
        Container.BindInstance(titleState);
        Container.BindInstance(newGameState);
        Container.BindInstance(endGameState);
        Container.BindInstance(planetState);
        Container.BindInstance(rocketState);

        Container.Bind<TimeController>().AsSingle();
    }
}