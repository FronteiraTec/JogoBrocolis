using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }
}