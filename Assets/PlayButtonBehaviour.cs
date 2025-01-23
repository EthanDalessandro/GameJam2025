using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
