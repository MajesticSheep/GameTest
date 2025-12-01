using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private DoorMechanics Door;
    [SerializeField] private PowerSystem Power;

    private void OnMouseDown()
    {
        Door.IsOpen = !Door.IsOpen;
        
        if (Power.Power > 0f)
        {
            Door.GetComponent<AudioSource>().Play();
        }
        else
        {
            Door.GetComponent<AudioSource>().Stop();
        }

        if (Door.IsOpen)
        {
            Power.SystemsOn -= 1;
        }
        else
        {
            Power.SystemsOn += 1;
        }

        
    }
}
