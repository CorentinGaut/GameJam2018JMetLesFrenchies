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
    GameObject pickedUpObject;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            closestObject.GetComponent<BaseObject>().Repare();
            Debug.Log("ENFONCE LA");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            closestObject.GetComponent<BaseObject>().Rotate(-45);
            Debug.Log("droite");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            closestObject.GetComponent<BaseObject>().Rotate(45);
            Debug.Log("gauche");
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
            Debug.Log("gauche");
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

    private void PickUp()
    {
        if(closestObject!=null&& pickedUpObject==null)
        {
            pickedUpObject = closestObject;
            closestObject.transform.position += Vector3.up;
            closestObject.transform.SetParent(gameObject.transform);
            closestObject.transform.localPosition = new Vector3(0, closestObject.GetComponent<BoxCollider>().size.y, closestObject.GetComponent<BoxCollider>().size.magnitude+1);
        }
        else if(pickedUpObject!=null)
        {
            pickedUpObject.transform.position -= Vector3.up;
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.transform.position = new Vector3(pickedUpObject.transform.position.x, closestObject.GetComponent<BoxCollider>().size.y/2, pickedUpObject.transform.position.z);
            pickedUpObject = null;
        }
    }

    void FixedUpdate()
    {
        if (direction.magnitude > 0.1)
        {
            if (direction.magnitude > 1)
                direction.Normalize();
            this.transform.position += direction/3;     
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
        if(closeObjects.Count==0)
        {
            closestObject = null;
        }
    }
}
