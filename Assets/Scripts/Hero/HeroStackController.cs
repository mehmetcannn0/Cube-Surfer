
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;
    private RaycastHit hit;
    void Start()
    {
        UpdateLastBlockObject();

    } 
    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    public void AddBlock(GameObject block)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        block.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f,lastBlockObject.transform.position.z);
        block.transform.SetParent(transform);
        blockList.Add(block);
        UpdateLastBlockObject();
    }
    public void RemoveBlock(GameObject block)
    {
        block.transform.SetParent(null);
        blockList.Remove(block); 
        UpdateLastBlockObject();
    }
    private void UpdateLastBlockObject()
    {
      
            lastBlockObject = blockList[blockList.Count - 1];
       

    }
    private void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position,Vector3.forward, out hit, 1f))
        {
          
            if (hit.transform.name == "ObstacleCube")
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }

        }
    }
}
