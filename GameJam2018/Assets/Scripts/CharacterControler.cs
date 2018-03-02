using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    Vector3 direction;
    // Use this for initialization
    void Start()
    {
        direction = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {   
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ENFONCE LA");
        }
    }

    void FixedUpdate()
    {
        if (direction.magnitude > 0.1)
        {
            if (direction.magnitude > 1)
                direction.Normalize();
            this.transform.position += direction;     
        }
    }
}
