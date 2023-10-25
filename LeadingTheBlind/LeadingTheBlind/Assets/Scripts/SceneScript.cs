using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void gameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void winScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loseScene()
    {
        SceneManager.LoadScene(2);
    }

    public void mainScene()
    {
        //SceneManager.LoadScene();
    }

    public void controlScene()
    {
        //SceneManager.LoadScene();
    }

    public void quitGame()
    {
        Application.Quit();
        print("quit");
    }
}
