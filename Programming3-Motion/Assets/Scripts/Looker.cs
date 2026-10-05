
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    public List<Transform> Baits;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the scene starts, set the Looker's rotation to look at the first element in the list by setting eulerAngles.z.
        Vector3 directionToLook = Baits[0].position - transform.position;
        float angle = TestAngles.VectorToAngle(directionToLook);
      
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

    }
}
