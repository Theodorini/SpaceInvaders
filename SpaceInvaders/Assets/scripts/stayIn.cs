using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayIn : MonoBehaviour
{
    float horizontalMin, horizontalMax;
    float verticalMin, verticalMax;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
        verticalMin = -halfHeight;
        verticalMax = halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 2*horizontalMax),
     Mathf.Clamp(transform.position.y, 0, 2*verticalMax),
     transform.position.z);
    }
}