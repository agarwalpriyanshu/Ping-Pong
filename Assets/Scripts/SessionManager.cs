using System.Drawing;
using System.IO;
using UnityEngine;

public class SessionManager : MonoBehaviour
{

    public static SessionManager Instance;

    public string playerName;
    public int highScore;

    private void Awake()
    {
        //Debug.Log("its awake");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();

    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;

    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName; 
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

   
}
