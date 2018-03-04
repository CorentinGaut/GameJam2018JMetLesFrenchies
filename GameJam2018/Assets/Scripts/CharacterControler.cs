using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    Vector3 direction;
    public List<GameObject> closeObjects;
    public GameObject closestObject;
    Vector3 pos;
    float minDistObject;
    GameObject pickedUpObject;
    Vector3 pickedUpItemPos;
    Animator anim;
    [Header("Sort")]
    public float stunTime;
    private float tweakRalentissement;
    public float vitesseRalenti;
    public float dureeRalentissement;
    public bool isStuned;

    public AudioSource steps ,kick , pop ,lift ,modem;

    private TextScrollview contenu;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        closeObjects = new List<GameObject>();
        direction = new Vector3(0,0,0);
        minDistObject = 3000;
        isStuned=false;
        tweakRalentissement=1f;
        contenu=GameObject.Find("Content").GetComponent<TextScrollview>();
    }

    // Update is called once per frame
    void Update()
    {

        //sons

        //sons
        steps = GetComponents<AudioSource>()[0];
        kick = GetComponents<AudioSource>()[1];
        pop = GetComponents<AudioSource>()[2];
        lift = GetComponents<AudioSource>()[3];
        modem = GetComponents<AudioSource>()[4];

        if (!isStuned){
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
        }else{
            direction.x=0f;
            direction.y=0f;
        }

        if(Input.GetKeyDown(KeyCode.K)){
            //debug
            ralentir();
        }
        

        //a pour poser
        //x pour reparer
        //gachettes pour tourner un objet

        Camera.main.transform.position = gameObject.transform.position + new Vector3(0, 10, -10);

        if (Input.GetButtonDown("Repare"))
        {
            kick.Play();
            anim.SetBool("isReparing", true);
            StartCoroutine(WaitAnim());
            closestObject.GetComponent<BaseObject>().Repare();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("blub");
            closestObject.GetComponent<BaseObject>().Destroy();
        }

        if (Input.GetButtonDown("RotateD"))
        {
            pop.Play();
            if (pickedUpObject == null)
                closestObject.GetComponent<BaseObject>().Rotate(45);
            Debug.Log("droite");
        }

        if (Input.GetButtonDown("RotateG"))
        {
            pop.Play();
            if(pickedUpObject == null)
            closestObject.GetComponent<BaseObject>().Rotate(-45);
            Debug.Log("gauche");
        }


        if (Input.GetButtonDown("Poser"))
        {
            PickUp();
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

    IEnumerator WaitAnim()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("isReparing", false);
    }

    private void PickUp()
    {
        lift.Play();
        if(closestObject!=null&& pickedUpObject==null)
        {
            anim.SetBool("isWearing", true);
            pickedUpObject = closestObject;
            closestObject.transform.SetParent(gameObject.transform);
            closestObject.transform.localEulerAngles = Vector3.zero;
            closestObject.transform.localPosition = new Vector3(0, closestObject.transform.position.y, /*-((closestObject.transform.localScale.z/2f)+1)*/-((closestObject.GetComponent<BoxCollider>().size.z/2)+1) );
        }
        else if(pickedUpObject!=null)
        {
            anim.SetBool("isWearing", false);
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.transform.position = new Vector3(pickedUpObject.transform.position.x, closestObject.GetComponent<BaseObject>().baseHeight, pickedUpObject.transform.position.z);
            pickedUpObject = null;
        }
    }


    void FixedUpdate()
    {
        if (direction.magnitude > 0.1)
        {
            
            anim.SetBool("isMoving", true);
            //startsound
            steps.Play();

            if (direction.magnitude > 1)
                direction.Normalize();
            this.transform.position += direction/3* tweakRalentissement*0.5f;
            float sign = (direction.z > 0) ? 1.0f : -1.0f;
            transform.rotation = Quaternion.Euler(0,  90 - Vector3.Angle(Vector3.right, direction) * sign,0);
        }
        if (direction.magnitude == 0)
        {
            //stopsound
            steps.Stop();
            anim.SetBool("isMoving", false);
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

    IEnumerator FinStun(){
        yield return new WaitForSeconds(stunTime);
        isStuned=false;
        Debug.Log("finStun");
    }

    void Stun(){
        isStuned=true;
        direction.x=0;
        direction.y=0;
        StartCoroutine(FinStun());
    }

    public void ralentir(){
        //modemsound
        modem.Play();
        tweakRalentissement=vitesseRalenti;
        contenu.AddText("Ie utilise trop de processeur, ralentissement de l'ordinateur !");
        StartCoroutine(finRalentissement());    
    }

    IEnumerator finRalentissement(){
        yield return new WaitForSeconds(dureeRalentissement);
        tweakRalentissement=1f;
    }
}
