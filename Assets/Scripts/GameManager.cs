using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int score;
    public TMP_Text scoreDisplay;
    public static bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
