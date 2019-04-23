using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl2 : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;        // A reference to the main camera in the scenes transform
        private Vector3 pastFoward;         // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.


        void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        void Update()
        {
            // calculate move direction to pass to character

            //if (m_Move != Vector3.zero)
            {
                //m_Move = vertical * pastFoward + horizontal * m_Cam.right;
                //m_Move += right * horizontal * speed * Time.deltaTime;
                //m_Move += forward * vertical * speed * Time.deltaTime;
            }
            //else if (m_Move == Vector3.zero)

            // calculate camera relative direction to move:
            //m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            //pastFoward = m_CamForward;
            //m_Move = vertical * m_CamForward + horizontal * m_Cam.right;

            Vector3 right = m_Cam.transform.right;
            Vector3 forward = Vector3.Cross(right, Vector3.up);

            m_Move = Vector3.zero;
            m_Move += right * Input.GetAxis("Horizontal") * (Time.deltaTime * 50);
            m_Move += forward * Input.GetAxis("Vertical") * (Time.deltaTime * 50);

            Debug.Log(m_Move + " | " + right + " | " + forward + " | " + Input.GetAxis("Horizontal") + " | " + Input.GetAxis("Vertical") + " | " + (Time.deltaTime * 100));

            // pass all parameters to the character control script

            m_Character.Move(m_Move, false, false);
        }
    }
}