using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int idNextLevel;
    [SerializeField] private int CoinsForNextLevel;
    [SerializeField] private int CrystalsForNextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            MavkaController Mavka = collision.GetComponent<MavkaController>();
            if (Mavka.coins >= CoinsForNextLevel) 
            if (Mavka.crystals >= CrystalsForNextLevel)
            {
                SceneManager.LoadScene(idNextLevel);
            }
        }
    }
}


