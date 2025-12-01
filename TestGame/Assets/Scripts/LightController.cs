using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private DoorMechanics Door;

    private void OnMouseDown()
    {
        Door.ChangeLights();
        
    }
}
