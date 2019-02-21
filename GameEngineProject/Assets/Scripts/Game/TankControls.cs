using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    private float rotationX;

    [SerializeField] float sensitivityX = 15f;
    [SerializeField] private float walkingSpeed = 1f;

    [SerializeField] private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        }
        else if (Input.GetAxis("Mouse X") > 0.1 || Input.GetAxis("Mouse X") < -0.1)
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX , 0);

        transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetButtonDown("Vertical") && Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("Running",true);
        }
        else if (Input.GetButtonDown("Vertical"))
        {
            anim.SetBool("Running", false);
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



    }
}
