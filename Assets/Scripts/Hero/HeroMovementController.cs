using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController heroInputController;
    [SerializeField] private float forwardMovementSpeed ;
    [SerializeField] private float horizontalMovementSpeed ;
    [SerializeField] private float horizontalLimitValue;

    private float newPositionX;

     void FixedUpdate()//carpýsma hareket falan kullanacagýmýz ýcýn fýxedupdate kullandýk
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }
    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);//fixed olmasý fixedupdate ýn ýcýnde kullanacagýmý ýcýn
    }
    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX,transform.position.y,transform.position.z);
    }
}
