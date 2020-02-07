using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidGrav;
    bool isPlayer = true;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpheight = 4f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//getting component
        rigidGrav = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Jump();
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {//space for jumping
            rigidGrav.AddForce(new Vector3(0, jumpheight, 0), ForceMode.Impulse);
            //giving accelarition in height
            animator.SetTrigger("Jump");//changing animator state
        }
    }
    //IDK how to move it according to camera. 
    private void Movement()
    {
        Camera kamera = Camera.main;
        float verticalAxis = Input.GetAxis("Vertical");//varies between 1 and -1
        float horizontalAxis = Input.GetAxis("Horizontal");
        //create a new vector
        Vector3 cameraForward = Vector3.Scale(kamera.transform.forward, new Vector3(1, 0, 1)).normalized; // forward direction in 2d
        //Vector3 updatedVector = new Vector3(horizontalAxis, 0.0f, verticalAxis);//new position that has been changed through axis
        Vector3 updatedVector = verticalAxis * cameraForward + horizontalAxis * kamera.transform.right;
        transform.LookAt(updatedVector + transform.position);//facing towards vector
        animator.SetBool("Is_Running", true);//setting animator boolean
        transform.Translate(updatedVector * speed * Time.deltaTime, Space.World);//actual movement
        if(verticalAxis == 0 && horizontalAxis == 0)//if player doesn't move
        {
            animator.SetBool("Is_Running", false);
        }
        
    }
    public bool ISplayer()
    {
        return isPlayer;
    }
}
