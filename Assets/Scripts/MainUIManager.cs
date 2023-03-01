using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{

    public int bestScore;
    public string BestUsername;
    public string Username;

    public static MainUIManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestScore = bestScore;
        data.BestUserName = BestUsername;
        data.UserName = Username;

        string json = JsonUtility.ToJson(data);

        Debug.Log(Application.persistentDataPath);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.BestScore;
            BestUsername = data.BestUserName;
            Username = data.UserName;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string UserName;
        public string BestUserName;
    }


}
