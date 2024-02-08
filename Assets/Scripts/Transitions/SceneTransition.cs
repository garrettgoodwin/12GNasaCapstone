using UnityEngine;

public abstract class SceneTransition : MonoBehaviour
{
    public abstract void InitializeTransition();
    public abstract void PerformTransition();
    public abstract void EndTransition();
}
