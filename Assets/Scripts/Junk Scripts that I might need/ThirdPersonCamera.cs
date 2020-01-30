using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] float minimum_Y = 0.0f;
    [SerializeField] float max_Y = 50f;
    [SerializeField] Transform player;
    [SerializeField] Transform cameraTransform;
    Camera cameraObject;       //have to configue camera according to open fields
    [SerializeField]float distance = 5f;
    [SerializeField]float currentX = 0.0f;
    [SerializeField]float currentY = 0.0f;
    [SerializeField]float sensitivityX = 4f;
    [SerializeField]float sensitivityY = 1f;

    private void Start()
    {
        cameraTransform = transform;
        cameraObject = Camera.main;  //initialization

    }
    private void LateUpdate()//calculation after frame 
    {
        Vector3 direction = new Vector3(0, 0, -distance);//new vector
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);//rotation
        cameraTransform.position = player.position + rotation * direction;//new transform
        cameraTransform.LookAt(player.position);//look at player
    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");// udpating according to axis change 
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, minimum_Y, max_Y);

    }
}
