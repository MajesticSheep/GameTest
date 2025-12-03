using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftTimer : MonoBehaviour
{

    [SerializeField] private float Timer;

    //[SerializeField] private int ShiftEndTime = 6;
    [SerializeField] private string DigitalClock;
    [SerializeField] private float TimeMultiplier = 2f;

    [SerializeField] private TextMeshPro ClockText;

    [SerializeField] private GameObject WinScreen;

    [SerializeField] private bool Won;

    [SerializeField] private AnimatronicSystem[] Animatronics;

    [SerializeField] private string NextSceneToCall;
    // Start is called before the first frame update
    void Start()
    {
        DigitalClock = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!Won)
        {
            Timer += Time.deltaTime * TimeMultiplier;

            var hours = Mathf.FloorToInt(Timer / 60);
            var minutes = Mathf.FloorToInt(Timer - hours * 60);

            if(minutes == 0)
            {
                for (int i = 0; i < Animatronics.Length; i++)
                {
                    Animatronics[i].ChangeAggrssionByHour(hours);
                }
            }

            if (hours >= 6)
            {
                WinScreen.SetActive(true);
                Won = true;

                Invoke("NextScene", 1f);
            }

            if (hours == 0)
            {
                hours = 12;
            }

            DigitalClock = string.Format("{0:00}:{1:00}", hours, minutes);

            ClockText.text = DigitalClock;
        }


    }

    private void NextScene()
    {
        SceneManager.LoadScene(NextSceneToCall);
    }
}
