using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject plane;
    public GameObject goodBox;
    public List<GameObject> badBox;
    public Button restartButton;
    public int numOfSpheres = 31;
    private int planeCount = 0;
    private int goodBoxCount = 0;
    private int badBoxCount = 0;

    private void Update()
    {
        // get the counts of the good and plane objects
        planeCount = plane.GetComponent<Counter>().GetCount();
        goodBoxCount = plane.GetComponent<Counter>().GetCount();

        // get counters of all the bad boxes and update the text with the total amount
        foreach (GameObject box in badBox)
        {
            badBoxCount += box.GetComponent<Counter>().GetCount();
            badBox[0].GetComponent<Counter>().SetText(badBoxCount);
        }

        // check that all the speares had colided
        if (planeCount + goodBoxCount + badBoxCount >= numOfSpheres)
        {
            restartButton.gameObject.SetActive(true);
        }

        // rest counters so values will not be accumulated accross Update calls
        badBoxCount = goodBoxCount = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
