using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // List of cameras to cycle through.
    private Camera[] listOfCameras;
    
    // Index to for the current camera.
    private int currentCameraIndex;

    // Text on the ui to indicate current camera.
    private UnityEngine.UI.Text cameraIndicator;

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

        // Get the text ui object
        this.cameraIndicator = GameObject.Find("CameraIndicator").GetComponent<UnityEngine.UI.Text>();
        this.cameraIndicator.text = listOfCameras[currentCameraIndex].gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            // Disable current camera
            this.listOfCameras[this.currentCameraIndex].gameObject.SetActive(false);
            this.currentCameraIndex++;
            // Check if index is greater than length of camera list to prevent overflow
            if (!(this.currentCameraIndex < this.listOfCameras.Length))
            {
                this.currentCameraIndex = 0;
            }
            // Set next camera active
            this.listOfCameras[this.currentCameraIndex].gameObject.SetActive(true);
            // Update camera indicator
            this.cameraIndicator.text = listOfCameras[currentCameraIndex].gameObject.name;
        }
    }
}
