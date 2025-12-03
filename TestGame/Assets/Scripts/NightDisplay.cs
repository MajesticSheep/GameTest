using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightDisplay : MonoBehaviour
{
    [SerializeField] private string NightName;
    [SerializeField] private TextMeshProUGUI NightText;

    [SerializeField] private float TimeToDestroy;

    [SerializeField] private GameObject[] ItemsInScene;

    [SerializeField] private float CoolDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("CurrentNight", SceneManager.GetActiveScene().name);

        for (int i = 0; i < ItemsInScene.Length; i++)
        {
            ItemsInScene[i].SetActive(false);
        }

        NightText.text = NightName;
        Destroy(gameObject, TimeToDestroy);
        CoolDownTimer = TimeToDestroy;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < ItemsInScene.Length; i++)
        {
            ItemsInScene[i].SetActive(true);
        }
    }
}
