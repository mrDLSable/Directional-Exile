﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    /// <summary>
    /// Manages the Movement of the camera
    /// </summary>
    public class CameraMovement : MonoBehaviour
    {


        /// <summary>
        /// Instantiates the CameraMovement script object
        /// </summary>
        void Start()
        {
            oldPosition = this.transform.position;
        }

        public Vector3 oldPosition;

        public float CameraSpeed = 0.1f;
        public float ScrollSpeed = 1f;
        public float ScrollCeil = 20f;
        public float ScrollFloor = 1f;

        /// <summary>
        /// Is called once per frame to update the Camera
        /// </summary>
        void Update()
        {
            float scrollAmount = 0;

            if (Input.GetAxis("Mouse ScrollWheel") != 0f && !WindowManager.MouseOverUI)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    scrollAmount = 1;
                }
                else
                {
                    scrollAmount = -1;
                }
            }

            Vector3 cameraMovement = new Vector3(
                Input.GetAxis("Horizontal") * CameraSpeed,
                Input.GetAxis("Vertical") * CameraSpeed,
                scrollAmount * ScrollSpeed);

            transform.Translate(cameraMovement);

            if (transform.position.y < ScrollFloor)
                transform.position = new Vector3(transform.position.x, ScrollFloor, transform.position.z);

            if (transform.position.y > ScrollCeil)
                transform.position = new Vector3(transform.position.x, ScrollCeil, transform.position.z);

            if (this.transform.position != oldPosition)
            {
                oldPosition = this.transform.position;

                UI.World.HexComponent[] hexes = GameObject.FindObjectsOfType<UI.World.HexComponent>();
                foreach (UI.World.HexComponent hex in hexes)
                {
                    hex.UpdatePosition();
                }
            }
        }
    }
}