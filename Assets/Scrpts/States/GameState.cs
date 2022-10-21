public class GameState : State
{
    public override void Handle(GameManager context)
    {
        context.StartScreen?.gameObject.SetActive(false);
        context.GameScreen?.gameObject.SetActive(true);
        context.PauseScreen?.gameObject.SetActive(false);
        context.GameOverScreen?.gameObject.SetActive(false);

        context.BirdMover.Start();
        context.InputHandler.gameObject.SetActive(true);
    }
}