using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayIn : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<RectTransform>().rect.width/2; //extents = size of width / 2
        objectHeight = transform.GetComponent<RectTransform>().rect.height/2; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, objectWidth +4, screenBounds.x -objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, objectHeight+2, screenBounds.y -objectHeight );
        transform.position = viewPos;
    }
}