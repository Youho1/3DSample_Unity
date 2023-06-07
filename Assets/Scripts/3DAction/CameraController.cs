using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    float vectorY;
    private void FixedUpdate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //y : xaxis
        vectorY -= mouseY * 0.3f;
        vectorY = Mathf.Clamp(vectorY, -20.0f, 90.0f);
        this.transform.rotation = Quaternion.Euler(vectorY, 0.0f, 0.0f);
        transform.LookAt(target, Vector3.up);
    }
}
