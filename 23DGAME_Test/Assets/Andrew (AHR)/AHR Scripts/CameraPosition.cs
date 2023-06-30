using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject playerPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.transform.position;
    }
}
