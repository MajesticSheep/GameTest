using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneGuySkipCallButton : MonoBehaviour
{
    [SerializeField] private GameObject SkipCallButton;

    [SerializeField] private float delayTime = 6f;

    // Used if the player doesn't want to press the skip call button
    void Start()
    {
        if(SkipCallButton != null)
        {
            SkipCallButton.SetActive(false);
        }

        Invoke("ActivateObject", delayTime);

        Destroy(gameObject, 10f);
    }
    
    void ActivateObject()
    {
        if (SkipCallButton != null)
        {
            SkipCallButton.SetActive(true);
        }
    }
}
