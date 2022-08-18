using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRunning : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;
    public float turnSpeed;
    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = Player.transform.position;

        Vector3 movementDirection = new Vector3(UiManager.instance.joystick.Horizontal, 0, UiManager.instance.joystick.Vertical);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }


        // if(UiManager.instance.joystick.Horizontal!=0|| UiManager.instance.joystick.Vertical != 0)
        //{
        //     transform.rotation = Quaternion.LookRotation()
        //}

       
    }
}
