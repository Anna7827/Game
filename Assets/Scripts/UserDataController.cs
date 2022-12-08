using System;
using UnityEngine;


[Serializable]
public class UserData
{
    public int Coins;
    public int Crystals;
    public int Hearts;
    public int Lilys;
}

public class UserDataController : MonoBehaviour
{
    public static UserDataController Instance { get; private set; }

    public UserData userData;

    private string PATH => Application.persistentDataPath + "/UserData.txt";

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            print("Create instance");

            LoadData();
        }
        else
        {
            print("Instance was created, delete current");
            Destroy(gameObject);
        }
    }

    private void LoadData()
    {
        if (System.IO.File.Exists(PATH))
        {
            print("load exists user data");
            string json = System.IO.File.ReadAllText(PATH);
            userData = JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            print("create new user data");
            userData = new UserData();
            userData.Coins = 0;
            userData.Crystals = 0;
            userData.Lilys = 0;
            userData.Hearts = 3;
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(userData);
        System.IO.File.WriteAllText(PATH, json);
        print(json);
    }

    public void AddHealth(int hp)
    {
        userData.Hearts += hp;
        SaveData();
    }

    public void RemoveHealth(int hp)
    {
        userData.Hearts -= hp;
        SaveData();
    }

    public void RemoveLilys(int removeLilys)
    {
        userData.Lilys -= removeLilys;
        SaveData();
    }

    public void AddCoins(int coins)
    {
        userData.Coins += coins;
        SaveData();
    }

    public void AddCrystals(int amount)
    {
        userData.Crystals += amount;
        SaveData();
    }

    public void AddLilys(int amount)
    {
        userData.Lilys += amount;
        SaveData();
    }

    public void ResetData()
    {
        userData.Coins = 0;
        userData.Crystals = 0;
        userData.Lilys = 0;
        userData.Hearts = 3;
    }

    public void ResetCoins()
    {
        userData.Coins = 0;
    }

    public void ResetCrystals()
    {
        userData.Crystals = 0;
    }

    public void ResetLilys()
    {
        userData.Lilys = 0;
    }

    public void ResetLives()
    {
        userData.Hearts = 3;
    }

}
