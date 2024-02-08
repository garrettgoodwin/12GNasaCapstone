using UnityEngine;

public class BWTransition : SceneTransition
{
    public override void InitializeTransition()
    {
        // Initialize black and white effect
        SetScreenBlackAndWhite(true);
    }

    public override void PerformTransition()
    {
        // Wait for a few seconds (handled by the TransitionManager)
    }

    public override void EndTransition()
    {
        // Reset the screen color effect
        SetScreenBlackAndWhite(false);
    }

    private void SetScreenBlackAndWhite(bool enabled)
    {
        // Implement the logic to set the screen to black and white
    }
}
 