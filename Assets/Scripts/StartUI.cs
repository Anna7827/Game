using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
        UserDataController.Instance.ResetData();
    }

    public void Exit ()
    {
        Application.Quit();
    }


}
