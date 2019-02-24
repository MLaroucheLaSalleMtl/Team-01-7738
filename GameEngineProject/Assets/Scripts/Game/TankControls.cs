using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    private float rotationX;

    [SerializeField] float sensitivityX = 15f;
    [SerializeField] private float walkingSpeed = 1f;

    private Animator anim;
    private Vector3 direction = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        anim.SetFloat("h", Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Horizontal"))
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                //anim.SetTrigger("Turn");
                anim.SetBool("Turn", true);
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                //anim.SetTrigger("Turn");
                anim.SetBool("Turn", true);

            }
            else
            {
                anim.SetBool("Turn", false);
                anim.SetFloat("h", 0);
            }
            //else
            //{
            //    anim.SetBool("Turn", false);

            //}
        }
        //if (Input.GetButton("Horizontal") && Input.GetAxis("Vertical") > 0)
        //{
        //    rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
        //    transform.localEulerAngles = new Vector3(0, rotationX, 0);
        //    transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        //}
        //else if (Input.GetAxis("Mouse X") > 0.1 || Input.GetAxis("Mouse X") < -0.1)
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

        //transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        anim.SetFloat("v", Input.GetAxis("Vertical"));
        if (Input.GetButton("Fire3") && Input.GetButton("Vertical"))
        {
            anim.SetBool("Running", true);
        }
        else
            anim.SetBool("Running", false);
<<<<<<< Updated upstream
            anim.SetFloat("CasualWalk", Input.GetAxis("Vertical"));
        }



       



    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        // Add what you want to Save here 

        // Example: health = data.health

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;



=======
        direction = Vector3.zero;
>>>>>>> Stashed changes
    }
}
