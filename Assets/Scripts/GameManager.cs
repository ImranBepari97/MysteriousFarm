using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PlantSpawn[] spawners;

    public static int score;
    public TMP_Text scoreDisplay;
    public static bool isGameOver = false;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        spawners = Object.FindObjectsOfType<PlantSpawn>();
        score = 0;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Restart")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        int numRotten = 0;
        foreach (PlantSpawn s in spawners) {
            if( s.currentVegetable != null && s.currentVegetable.Stage == Plant.Growth_Stage.ROTTEN) {
                numRotten += 1;
            }
        }
        
        if((float) (numRotten / spawners.Length) > 0.75f) {
            isGameOver = true;
            PopUpGameOver();
        }

        scoreDisplay.text = "Score: " + score;
    }


    void PopUpGameOver() {
        gameOverScreen.SetActive(true);
    }
}
