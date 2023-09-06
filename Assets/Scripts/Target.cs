using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{   
    public float ValorMin_X;
    public float ValorMax_X;

    public float ValorMin_Y;
    public float ValorMax_Y;

    public float ValorMin_Z;
    public float ValorMax_Z;

    public void hit()
    {
        transform.position = new Vector3(Random.Range(ValorMin_X, ValorMax_X), Random.Range(ValorMin_Y, ValorMax_Y), 16);
    }
}
