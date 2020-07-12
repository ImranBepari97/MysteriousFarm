using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Screen : MonoBehaviour
{
    public GameObject HelpMenu;
    public GameObject MainMenu;


    public void ShowMainMenu() {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }

    public void ShowHelpMenu() {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void StartGame() {
        SceneManager.LoadScene("AmritsScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
            ShowMainMenu();
        }
    }
}
