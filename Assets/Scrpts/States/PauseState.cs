public class PauseState:State
{
    public override void Handle(GameManager context)
    {
        context.StartScreen?.gameObject.SetActive(false);
        context.GameScreen?.gameObject.SetActive(false);
        context.PauseScreen?.gameObject.SetActive(true);
        context.GameOverScreen?.gameObject.SetActive(false);
        
        context.BirdMover.Stop();
        context.InputHandler.gameObject.SetActive(false);
    }
}