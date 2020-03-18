using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayIn : MonoBehaviour
{
    public Camera MainCamera;
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        //screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<RectTransform>().rect.width/2; //extents = size of width / 2
        objectHeight = transform.GetComponent<RectTransform>().rect.height/2; //extents = size of height / 2
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        //Debug.Log(viewPos);
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x +objectWidth, screenBounds.x-objectWidth );
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y +objectHeight, screenBounds.y-objectHeight );
        transform.position = viewPos;
    }
}
///&& touchPosition.y >-(BottomBorder.y - BottomBorder.y *0.4f)