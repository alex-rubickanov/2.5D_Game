using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCameraMove : MonoBehaviour
{
    public Transform camPos;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camPos.position;
    }
}
