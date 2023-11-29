using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        print("quit");
    }
}
