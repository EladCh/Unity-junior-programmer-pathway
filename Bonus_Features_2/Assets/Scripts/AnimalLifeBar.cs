using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalLifeBar : MonoBehaviour
{
    public Slider lifeBarSlider;
    public int maxLife;
    private int currentLifeAmount;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        lifeBarSlider.maxValue = maxLife;
        currentLifeAmount = maxLife;
        lifeBarSlider.value = maxLife;
        lifeBarSlider.fillRect.gameObject.SetActive(true);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DecreaseLife(int amount) {
        currentLifeAmount -= amount;
        lifeBarSlider.fillRect.gameObject.SetActive(true);
        lifeBarSlider.value = currentLifeAmount;
        if (currentLifeAmount <= 0)
        {
            gameManager.AddScore(maxLife);
            Destroy(gameObject, 0.1f);
        }
     }

}
