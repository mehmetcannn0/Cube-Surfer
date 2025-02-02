using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    private float horizontalValue;
    public float HorizontalValue => horizontalValue;

    void Update()
    {
        HandleHeroHorizontalInput();
    }

    private void HandleHeroHorizontalInput()
    {
        if (Input.touchCount > 0)  
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)  
            {
                horizontalValue = touch.deltaPosition.x * 0.01f; 
            }
        }
        else
        {
            horizontalValue = 0;
        }
    }
}
