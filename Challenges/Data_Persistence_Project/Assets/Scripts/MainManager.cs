using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private string currentPlayer;
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
    }

    public void SetCurrentPlayerName( string name)
    {
        currentPlayer = name;
    }

    public string GetCurrentPlayerName()
    {
        return currentPlayer;
    }

    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }
}
