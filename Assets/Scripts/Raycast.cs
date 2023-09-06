using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                Target target = hit. transform. GetComponent<Target>();

                if (target != null)
                {
                    target.hit();
                }
            }
        }
    }
}
