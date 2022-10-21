public class GameOverState : State
{
    public override void Handle(GameManager context)
    {
        context.StartScreen?.gameObject.SetActive(false);
        context.GameScreen?.gameObject.SetActive(false);
        context.PauseScreen?.gameObject.SetActive(false);
        context.GameOverScreen?.gameObject.SetActive(true);

        context.BirdMover.Stop();
        context.InputHandler.gameObject.SetActive(false);
    }
}