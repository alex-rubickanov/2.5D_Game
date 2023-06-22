using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    [SerializeField] private GameObject camTwoD;
    [SerializeField] private GameObject camThreeD;
    [SerializeField] private Camera mainCam;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SwapCamera());
        }
    }
    

    private IEnumerator SwapCamera()
    {
        if(camTwoD.activeSelf == true)
        {
            // Make 3D
            camThreeD.SetActive(true);
            camTwoD.SetActive(false);
            //mainCam.orthographic = false;
        }
        else
        {
            // Make 2D
            camThreeD.SetActive(false);
            camTwoD.SetActive(true);
            yield return new WaitForSeconds(2f);
           // mainCam.orthographic = true;
        }
    }
}
