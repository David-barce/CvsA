using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Mago;

    void Update()
    {
        if (Mago != null)
        {
            Vector3 position = transform.position;
            position.x = Mago.transform.position.x;
            position.y = Mago.transform.position.y;
            transform.position = position;
        }
    }
}
