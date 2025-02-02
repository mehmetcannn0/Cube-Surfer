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

     void FixedUpdate()//carp�sma hareket falan kullanacag�m�z �c�n f�xedupdate kulland�k
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }
    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);//fixed olmas� fixedupdate �n �c�nde kullanacag�m� �c�n
    }
    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX,transform.position.y,transform.position.z);
    }
}
