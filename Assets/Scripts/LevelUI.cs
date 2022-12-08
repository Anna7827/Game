using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public void Levels()
    {
        SceneManager.LoadScene(1);
    }
    public void Levels1()
    {
        SceneManager.LoadScene(0);
    }
    public void Levels2()
    {
        SceneManager.LoadScene(1);
    }
    public void Levels3()
    {
        SceneManager.LoadScene(2);
    }
    public void Levels4()
    {
        SceneManager.LoadScene(3);
    }
    public void Levels5()
    {
        SceneManager.LoadScene(0);
    }
}
