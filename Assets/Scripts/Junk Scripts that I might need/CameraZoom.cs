using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Transform cameraZoomPoint = null;
    [SerializeField] Transform initialCameraPoint = null;
    [SerializeField] float smooth = 5f;
    bool isZoomed = false;
    private void Update()
    {
        ZoomLog();
    }
    void ZoomLog()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {
            transform.LookAt(cameraZoomPoint);
            transform.Translate(Vector3.forward * smooth * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * smooth * Time.deltaTime);
        }
      
    }



    //[SerializeField] int zoom = 20;
    //[SerializeField] int normal = 40;
    //[SerializeField] float smooth = 5f;
    //bool isZoomed = false;

    //private void Update()
    //{
    //    ZoomLogic();
    //}

    //private void ZoomLogic()
    //{
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        isZoomed = !isZoomed;
    //    }
    //    if (isZoomed)
    //    {
    //        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
    //    }
    //    else
    //    {
    //        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
    //    }
    //}
}
