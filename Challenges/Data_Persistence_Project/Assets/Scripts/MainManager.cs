using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private string currentPlayer;
    private string bestScorePlayer;
    private int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayer = name;
    }

    public string GetCurrentPlayerName()
    {
        return currentPlayer;
    }

    public string GetBestScorePlayerName()
    {
        return bestScorePlayer;
    }
    
    public int GetBestScore()
    {
        return bestScore;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SetBestScore(int score)
    {
        bestScorePlayer = currentPlayer;
        bestScore = score;

        SaveData data = new SaveData();
        data.playerName = currentPlayer;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highScore.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/highScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.score;
            bestScorePlayer = data.playerName;
        }
    }
}
