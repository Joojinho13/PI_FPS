using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera cam;
    public AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();    
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            audioData.Play(0);


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
