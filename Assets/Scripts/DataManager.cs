using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public int highScore = 0;
    public string playerName;
    public string highScorePlayerName = "noone";
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable] class SaveData
    {
        public int highScore1;
        public string highScorePlayerName1;
    }

    public void save()
    {
        SaveData save = new SaveData();
        save.highScore1 = highScore;
        save.highScorePlayerName1 = highScorePlayerName;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore1;
            highScorePlayerName = data.highScorePlayerName1;
        }
    }

    public void deleteSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}