using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_move : MonoBehaviour
{

    private float deltaX, deltaY;
    private Rigidbody2D rigidBdy;
    // Start is called before the first frame update
    void Start()
    {
        rigidBdy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    rigidBdy.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                   // rigidBdy.MovePosition(new Vector2(Screen.currentResolution.width, Screen.currentResolution.height));
                    break;

                case TouchPhase.Ended:
                    rigidBdy.velocity = Vector2.zero;
                    break;
            }
            Debug.Log(touchPos.x+"  " +touchPos.y);
        }
    }
}
