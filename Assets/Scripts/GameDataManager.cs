using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.UI;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public string PlayerName;
    public string HighScoreName;
    public int HighScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        public string highScoreName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = PlayerName;
        data.highScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.highScoreName;
            HighScore = data.highScore;
        }
    }
}
