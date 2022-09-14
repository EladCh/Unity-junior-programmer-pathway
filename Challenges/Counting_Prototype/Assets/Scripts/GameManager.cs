using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject plane;
    public GameObject box;
    public Button restartButton;
    public int numOfSpheres = 31;
    private int planeCount = 0;
    private int boxCount = 0;

    private void Update()
    {
        planeCount = plane.GetComponent<Counter>().GetCount();
        boxCount = plane.GetComponent<Counter>().GetCount();
        if (planeCount + boxCount >= numOfSpheres)
        {
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
