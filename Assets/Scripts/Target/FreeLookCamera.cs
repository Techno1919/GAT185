using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    [Range(0, 2)] public float sensitiviy = 2;
    [Range(1, 5)] public float speed = 2;
    public GameObject hitMarker;
    public GameObject explosion;
    

    void Update()
    {
        // rotation
        if (Input.GetMouseButton(1))
        {
            Vector3 rotate = Vector3.zero;
            rotate.y = Input.GetAxis("Mouse X");
            rotate.x = Input.GetAxis("Mouse Y");

            transform.eulerAngles += rotate * sensitiviy;

            //Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        /*// quat
        Vector3 dir = transform.rotation * Vector3.right;
        Debug.DrawRay(transform.position, dir * 100, Color.red);*/

        //translate
        Vector3 translate = Vector3.zero;
        translate.x = Input.GetAxis("Horizontal");
        translate.z = Input.GetAxis("Vertical");

        transform.position += (transform.rotation * translate) * speed * Time.deltaTime;

        /*// raycast
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject gameObeject = Instantiate(explosion, hitInfo.point, Quaternion.identity);
                Destroy(gameObeject, 3);
                Destroy(hitInfo.collider.gameObject);
            }

            *//*hitMarker.transform.position = hitInfo.point;
            Debug.Log(hitInfo.collider.gameObject);*//*
        }*/

    } 
}