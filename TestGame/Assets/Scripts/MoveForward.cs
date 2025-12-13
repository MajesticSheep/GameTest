using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveForward : MonoBehaviour
{
    public void Forward()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentNight", "Night 1"));
    }
}
