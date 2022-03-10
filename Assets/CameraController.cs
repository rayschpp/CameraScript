using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera[] listOfCameras;
    private int currentCameraIndex;

    // Start is called before the first frame update
    async void Start()
    {
        this.currentCameraIndex = 0;

        // Get all cameras at the scene
        this.listOfCameras = Camera.allCameras;

        // Disable all except the first
        for(int i = 1; i < this.listOfCameras.Length; i++)
        {
            listOfCameras[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            this.listOfCameras[this.currentCameraIndex].gameObject.SetActive(false);
            this.currentCameraIndex++;
            if (!(this.currentCameraIndex < this.listOfCameras.Length))
            {
                this.currentCameraIndex = 0;
            }
            this.listOfCameras[this.currentCameraIndex].gameObject.SetActive(true);
            Debug.Log ("Camera with name: " + this.listOfCameras[this.currentCameraIndex].gameObject.name + ", is now enabled");
        }
    }
}
