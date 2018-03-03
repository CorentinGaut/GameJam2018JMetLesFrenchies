using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    Vector3 direction;
    List<GameObject> closeObjects;
    GameObject closestObject;
    Vector3 pos;
    float minDistObject;

    // Use this for initialization
    void Start()
    {
        closeObjects = new List<GameObject>();
        direction = new Vector3(0,0,0);
        minDistObject = 3000;
    }

    // Update is called once per frame
    void Update()
    {   
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");

        Camera.main.transform.position = gameObject.transform.position + new Vector3(0, 10, -10);

        if (Input.GetKeyDown(KeyCode.E))
        {
            closestObject.GetComponent<BaseObject>().Repare();
            Debug.Log("ENFONCE LA");
        }

        pos = gameObject.transform.position;
        if(closeObjects.Count>0)
        {
            foreach(GameObject go in closeObjects)
            {                    Debug.Log(go.gameObject.name);
                float dist = (go.transform.position-pos).sqrMagnitude;
                if(dist<minDistObject)
                {

                    minDistObject = dist;
                    closestObject = go;
                }
            }
            minDistObject = 3000;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        closeObjects.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        closeObjects.Remove(other.gameObject);
    }
}
