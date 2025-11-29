using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private DoorMechanics Door;
    private void OnMouseDown()
    {
        Door.IsOpen = !Door.IsOpen;
        Door.GetComponent<AudioSource>().Play();
    }
}
