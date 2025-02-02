using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{ 
    [SerializeField] private HeroStackController heroStackController;
    private Vector3 direction = Vector3.back; //TODO: Change this to Vector3.up
    private bool isStack = false;
    private RaycastHit hit;
    void Start()
    {
        heroStackController = GameObject.FindAnyObjectByType<HeroStackController>();
    }
     
    void FixedUpdate()
    {
        SetCubeRaycast();
    }
    private void SetCubeRaycast()
    {
        Vector3[] rayOrigins =
        {
        transform.position + Vector3.left * 1f,  
        transform.position,                         
        transform.position + Vector3.right * 1f 
    };

        foreach (var origin in rayOrigins)
        {
            Debug.DrawRay(origin, direction * 1f, Color.red, 0.1f); // Iþýnlarý görmek için
            if (Physics.Raycast(origin, direction, out hit, 1f))
            {
                if (!isStack)
                {
                    isStack = true;
                    heroStackController.AddBlock(gameObject);
                    SetDirection();
                    break; 
                }
                if (hit.transform.name == "ObstacleCube" || hit.transform.CompareTag("ObstacleCube"))
                {
                    heroStackController.RemoveBlock(gameObject);
                }
            }
        }
    }
    private void SetDirection() { 

        direction = Vector3.forward;
    }

    }
