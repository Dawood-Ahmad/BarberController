using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMove : MonoBehaviour
{
    [SerializeField] float rotSpeedx;
    [SerializeField] float rotSpeedy;
    [SerializeField] float min = -85;
    [SerializeField] float max = 85;
    float xRot;
    [SerializeField] bool inverted = true;

    private void LateUpdate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y += 1;
            rotation.y = Mathf.Clamp(rotation.y, min, max);
            transform.rotation = Quaternion.Euler(rotation);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y -= 1;
            rotation.y = Mathf.Clamp(rotation.y, min, max);
            transform.rotation = Quaternion.Euler(rotation);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x += 1;
            transform.rotation = Quaternion.Euler(rotation);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x -= 1;
            transform.rotation = Quaternion.Euler(rotation);
        }

        
        if (AxisSaver.xMove)
        {
            if (AxisSaver.xPositive)
            {
                Vector3 rotation = transform.rotation.eulerAngles;
                rotation.y += rotSpeedy;
                transform.rotation = Quaternion.Euler(rotation);
            }
            else
            {
                Vector3 rotation = transform.rotation.eulerAngles;
                rotation.y -= rotSpeedy;
                transform.rotation = Quaternion.Euler(rotation);
            }
        }

        if (AxisSaver.yMove)
        {
            if (inverted)
            {
                if (AxisSaver.yPositive)
                {
                    Vector3 rotation = transform.rotation.eulerAngles;
                    xRot -= rotSpeedx;
                    xRot = Mathf.Clamp(xRot, min, max);
                    rotation.x = xRot;
                    transform.rotation = Quaternion.Euler(rotation);
                }
                else
                {
                    Vector3 rotation = transform.rotation.eulerAngles;
                    xRot += rotSpeedx;
                    xRot = Mathf.Clamp(xRot, min, max);
                    rotation.x = xRot;
                    transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                if (AxisSaver.yPositive)
                {
                    Vector3 rotation = transform.rotation.eulerAngles;
                    xRot += rotSpeedx;
                    xRot = Mathf.Clamp(xRot, min, max);
                    rotation.x = xRot;
                    transform.rotation = Quaternion.Euler(rotation);
                }
                else
                {
                    Vector3 rotation = transform.rotation.eulerAngles;
                    xRot -= rotSpeedx;
                    xRot = Mathf.Clamp(xRot, min, max);
                    rotation.x = xRot;
                    transform.rotation = Quaternion.Euler(rotation);
                }
            }
            
        }

        MakeAllAxisFalse();


    }
    void MakeAllAxisFalse()
    {
        AxisSaver.yMove = false;
        AxisSaver.xMove = false;
        AxisSaver.yPositive = false;
        AxisSaver.xPositive = false;
    }

}
