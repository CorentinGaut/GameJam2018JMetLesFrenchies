using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    static protected int id=0;
    public int itemId;
    public int HP;
    public bool isRepared;
    public int maxHP;
    public float repareCooldown;
    public Collider repareCollider;
    public Collider endroitCollider; 
    public float baseHeight;
    public RepareParticleEmitter repareParticle;
    public DestroyParticleEmitter destroyParticle;
    public bool isWellPlaced;
    static public List<bool> itemsWellPlacedandRepared;
    static protected bool listCreated;

    private void Awake()
    {
        listCreated = false;
        if (!listCreated)
        {
            itemsWellPlacedandRepared = new List<bool>();
            listCreated = true;
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (HP < maxHP)
        {
            isRepared = false;
            itemsWellPlacedandRepared[itemId] = false;
        }
    }

    public virtual void Destroy()
    {
        HP = 0;
        isRepared = false;
        itemsWellPlacedandRepared[itemId] = false;
        destroyParticle.StartEmitDestroyParticle();
    }

    public virtual void Rotate(int angle)
    {
        gameObject.transform.Rotate(new Vector3(0, angle, 0));
    }

    public virtual void Repare()
    {
        if (repareCooldown <= 0 && !isRepared)
        {
            HP += 10;
            repareCooldown = 1;
            StartCoroutine("RepareTimer");
            if (HP == maxHP)
            {
                isRepared = true;
                if (isWellPlaced == true)
                {
                    itemsWellPlacedandRepared[itemId] = true;
                    CheckItemList();
                }
                repareParticle.StopEmitParticle();
                destroyParticle.StopEmitParticle();
            }              
        }
    }

    public virtual void CheckItemList()
    {
        for(int i=0;i<itemsWellPlacedandRepared.Count;i++)
        {
            //Debug.Log(i +" : "+ itemsWellPlacedandRepared[i].ToString() + " "+Time.time);
            if (itemsWellPlacedandRepared[i] == false)
            {
                Debug.Log(i);
                return;
            }        
        }
        Debug.Log("fdp");
    }

    IEnumerator RepareTimer()
    {
        repareParticle.StartEmitParticle();
        yield return new WaitForSeconds(repareCooldown);
        repareParticle.StopEmitParticle();
    }
}
