public class RestartState : State
{
    public override void Handle(GameManager context)
    {
        context.Player.Reset();
        context.BirdMover.Reset();
        context.LevelGenerator.Reset();
        context.ResetEnvironmentMovers();
        context.SetGameState();
    }
}