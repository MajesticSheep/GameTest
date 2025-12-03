using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneGuySkip : MonoBehaviour
{
    public void SkipCall(GameObject skipButton)
    {
        Destroy(gameObject);
        Destroy(skipButton);
    }
}
