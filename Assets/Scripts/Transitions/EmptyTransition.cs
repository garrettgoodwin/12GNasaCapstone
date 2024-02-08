using UnityEngine;

public class EmptyTransition : SceneTransition
{
    public override void InitializeTransition()
    {
        // No initialization needed
    }

    public override void PerformTransition()
    {
        // No transition effect
    }

    public override void EndTransition()
    {
        // No cleanup needed
    }
}
