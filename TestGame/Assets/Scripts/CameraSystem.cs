using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    //Ask teacher how to fix cams!!!

    [SerializeField] private GameObject[] Cameras;

    [SerializeField] private int CurrentCam;

    [SerializeField] private KeyCode OpenCameras;

    [SerializeField] private bool CamerasOpen;
    [SerializeField] private GameObject MainCamera;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float CoolDownTime = 0.5f;

    [SerializeField] private GameObject CameraSystemUI;
    [SerializeField] private GameObject CameraMapUI;

    [SerializeField] private PowerSystem Power;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].SetActive(false);
        }

        CameraSystemUI.SetActive(false);
        MainCamera.SetActive(true);
        CameraMapUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Power.Power > 0f)
        {
            if (Input.GetKeyDown(OpenCameras))
            {
                CamerasOpen = !CamerasOpen;

                if (CamerasOpen)
                {
                    Power.SystemsOn += 1;
                }
                else
                {
                    Power.SystemsOn -= 1;
                }

                ShowCamera();
            }

            if (CoolDownTimer <= 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    Cameras[CurrentCam].SetActive(false);
                    CurrentCam = CurrentCam + 1;

                    if (CurrentCam >= Cameras.Length)
                    {
                        CurrentCam = 0;
                    }

                    GoToCamera(CurrentCam);
                    CoolDownTimer = CoolDownTime;
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    Cameras[CurrentCam].SetActive(false);
                    CurrentCam = CurrentCam - 1;

                    if (CurrentCam < 0)
                    {
                        CurrentCam = Cameras.Length - 1;
                    }

                    GoToCamera(CurrentCam);
                    CoolDownTimer = CoolDownTime;
                }
            }

            else
            {
                CoolDownTimer -= Time.deltaTime;
            }
        }
        else
        {
            CamerasOpen = false;
            ShowCamera();
        }
        
    }

    private void ShowCamera()
    {
        if(CamerasOpen)
        {
            MainCamera.SetActive(false);
            CameraMapUI.SetActive(true);
            CameraSystemUI.SetActive(true);
            Cameras[CurrentCam].SetActive(true);

        }
        else
        {
            MainCamera.SetActive(true);
            Cameras[CurrentCam].SetActive(false);
            CameraMapUI.SetActive(false);
            CameraSystemUI.SetActive(false);
        }
    }

    public void GoToCamera(int Progression)
    {
        MainCamera.SetActive(false);
        CurrentCam = Progression;
        ShowCamera();
    }
}
