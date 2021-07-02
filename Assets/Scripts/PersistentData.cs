using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public string PlayerName;
    public string BestName;
    public int BestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string BestName;
        public int BestScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestName = BestName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }

}
