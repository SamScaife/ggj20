using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JoeyDinger.SamScaife
{
    public class CameraManager : MonoBehaviour
    {
        // Indicator of current camera
        public TMP_Text currentCamera;

        //Camera GameObjects
        [Header("Camera Objects")]
        [SerializeField]
        private Camera CameraOneActive = null;
        [SerializeField]
        private Camera CameraTwoActive = null;
        [SerializeField]
        private Camera CameraThreeActive = null;
        [SerializeField]
        private Camera CameraFourActive = null;
        [SerializeField]
        private Camera CameraFiveActive = null;

        //Camera Array
        private Camera[] CameraArray;

        // Map names to cameras
        private string[] cameraNameMap;

        //Camera Buttons
        [Header("Camera Button Objects")]
        [SerializeField]
        private Button CameraOneButton = null;
        [SerializeField]
        private Button CameraTwoButton = null;
        [SerializeField]
        private Button CameraThreeButton = null;
        [SerializeField]
        private Button CameraFourButton = null;
        [SerializeField]
        private Button CameraFiveButton = null;

        // Start is called before the first frame update
        void Start()
        {
            //Set up Camera Array
            CameraArray = new Camera[] {
                CameraOneActive,
                CameraTwoActive,
                CameraThreeActive,
                CameraFourActive,
                CameraFiveActive,
            };

            // Record camera names, with the same indexes as in the active cameras array above
            cameraNameMap = new string[] {
                "Camera One", "Camera Two", "Camera Three", "Camera Four", "Camera Five"
            };

            //Set up Camera Button events
            CameraOneButton.onClick.AddListener(delegate { HandleCameraButtonClicked(0); });
            CameraTwoButton.onClick.AddListener(delegate { HandleCameraButtonClicked(1); });
            CameraThreeButton.onClick.AddListener(delegate { HandleCameraButtonClicked(2); });
            CameraFourButton.onClick.AddListener(delegate { HandleCameraButtonClicked(3); });
            CameraFiveButton.onClick.AddListener(delegate { HandleCameraButtonClicked(4); });
        }

        public void HandleCameraButtonClicked(int cameraIndex) {
            //move all cameras to the back
            foreach (Camera camera in CameraArray) {
                camera.depth = 0;
            }
            //set the chosen camera to the front
            CameraArray[cameraIndex].depth = 1;
            UpdateCurrentCamera(cameraNameMap[cameraIndex]);
        }

        /**
        * Update the current camera display at the top of the screen
        **/
        private void UpdateCurrentCamera(string cameraName)
        {
            currentCamera.text = "Live Feed:" + cameraName;
        }
    }
}