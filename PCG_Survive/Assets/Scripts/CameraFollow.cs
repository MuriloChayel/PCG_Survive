using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Camera.main.transform.position = target.position - new Vector3(0, 0, 10);   
    }
    private void LateUpdate()
    {
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target.position + new Vector3(0, 0, -10), Time.deltaTime * 8);
    }
}
