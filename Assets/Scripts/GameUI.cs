using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TextMeshProUGUI textCoins, textCrystals, textLilys;

    //private int hearts = 3;

    //public void AddHeart()
    //{
    //    //hearts++;
    //    UpdateHeart();
    //}
    //public void RemoveHeart()
    //{
    //    //hearts--;
    //    UpdateHeart();
    //}

    private void Start()
    {
        UserData data = UserDataController.Instance.userData;
        UpdateHeart(data.Hearts);
        textCoins.text = data.Coins.ToString();
        textCrystals.text = data.Crystals.ToString();
        textLilys.text = data.Lilys.ToString();
    }

    public void GameOver ()
    {
        panelGameOver.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void NewGame ()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        UserDataController.Instance.ResetData();
    }

    public void SetCountCoinsUI(int countCoins) 
    {
        textCoins.text = countCoins.ToString();
    }

    public void SetCountCrystalsUI(int countCrystals)
    {
        textCrystals.text = countCrystals.ToString();
    }

    public void SetCountLilysUI(int countLilys)
    {
        textLilys.text = countLilys.ToString();
    }

    public void UpdateHeart(int hearts)
    {
        for (int i=0; i<3; i++)
        {
            if (hearts > i)
            {
                objHearts[i].SetActive(true);
            }
            
            else
            {
                objHearts[i].SetActive(false);
            }

        }

    }
}