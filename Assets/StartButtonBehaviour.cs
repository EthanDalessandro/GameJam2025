using UnityEngine;

public class StartButtonBehaviour : MonoBehaviour
{
    [SerializeField] AnimationClip clip;
    [SerializeField] Animator screen;
    public void OnClick()
    {
        screen.Play(clip.name);
    }
}
