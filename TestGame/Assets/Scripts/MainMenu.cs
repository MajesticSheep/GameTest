using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject ContinueButton;
    [SerializeField] private TextMeshProUGUI nightDisplay;

    public void NewGame()
    {
        //I need to add a transition between scenes from the newspaper to Night 1
        //When making map, put lighting so the place isnt so dark when playing the game
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("NewspaperStart");
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentNight", "Night 1"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        if(PlayerPrefs.GetString("CurrentNight", "Night 1") == "Night 1")
        {
            ContinueButton.SetActive(false);
            
        }

        nightDisplay.text = PlayerPrefs.GetString("CurrentNight", "Night 1");
    }
}
