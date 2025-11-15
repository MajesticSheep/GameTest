using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float CameraSensitivity = 10f;

    [SerializeField] private float MinLookDist;
    [SerializeField] private float MaxLookDist;

    float camlookDistance;

    // Start is called before the first frame update
    void Start()
    {
        camlookDistance = transform.localRotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        camlookDistance = Mathf.Clamp(camlookDistance + Input.GetAxis("Mouse X") * CameraSensitivity, MinLookDist, MaxLookDist);

        transform.localRotation = Quaternion.Euler(0f, camlookDistance, 0f);
    }
}
