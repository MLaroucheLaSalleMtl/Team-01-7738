using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter thirdPersonCharacter; // A reference to the ThirdPersonCharacter on the object

        public float speed = 0.5f;

        private Transform camera;
        private Vector3 cameraForward;
        private Vector3 cameraRight;
        private Vector3 pastCameraForward;
        private Vector3 pastCameraRight;
        private Vector3 movement;

        void Awake()
        {
            camera = Camera.main.transform;
            thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        }

        void Update()
        {
            Vector3 movementAxis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            Vector3.ClampMagnitude(movementAxis, 1);

            if (movementAxis.x < 0.8f && movementAxis.x > -0.8f && movementAxis.z < 0.8f && movementAxis.z > -0.8f)
            {
                cameraForward = Vector3.Scale(camera.forward, new Vector3(1, 0, 1)).normalized;
                cameraRight = camera.right;
                cameraRight = cameraRight.normalized;

                movement = (cameraForward * movementAxis.z + cameraRight * movementAxis.x) * Time.deltaTime * speed;
            }
            else if (movement != Vector3.zero)
            {

                pastCameraForward = cameraForward;
                pastCameraRight = cameraRight;

                pastCameraForward = cameraForward;
                pastCameraRight = cameraRight;

                if (movementAxis.x == 0 && movementAxis.z > -0.1f || movementAxis.z < 0.1f)
                {
                    movement = (pastCameraForward * movementAxis.z + cameraRight * movementAxis.x) * (Time.deltaTime * 100) * speed;
                }
                else if (movementAxis.z == 0 && movementAxis.x > -0.1f || movementAxis.x < 0.1f)
                {
                    movement = (cameraForward * movementAxis.z + pastCameraRight * movementAxis.x) * (Time.deltaTime * 100) * speed;
                }
                else if (movementAxis.x != 0 && movementAxis.z != 0)
                {
                    movement = (pastCameraForward * movementAxis.z + pastCameraRight * movementAxis.x) * (Time.deltaTime * 100) * speed;
                }
            }
            thirdPersonCharacter.Move(movement, false, false);
        }

    }
}