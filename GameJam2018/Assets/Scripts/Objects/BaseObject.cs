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


    private void Awake()
    {

    }

    // Use this for initialization
    protected virtual void Start ()
    {

        //itemsWellPlacedandRepared = new List<bool>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        if (HP < maxHP)
        {
            isRepared = false;
            
        }
    }

    public virtual void Destroy()
    {
        HP -=30;
        isRepared = false;
        CheckItemList();
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

                    CheckItemList();
                
                repareParticle.StopEmitParticle();
                destroyParticle.StopEmitParticle();
            }              
        }
    }

    public virtual void CheckItemList()
    {
        GameManager.repareScore = 0;
        GameManager.totalHp = 0;
        for(int i=0;i< GameManager.itemsWellPlacedandRepared.Count;i++)
        {
            GameManager.totalHp += GameManager.objects[i].maxHP;
            //Debug.Log(objects[i].maxHP);
            if (GameManager.itemsWellPlacedandRepared[i] == true)
            {
                //Debug.Log(i);
                GameManager.repareScore += GameManager.objects[i].HP;
            }        
        }

    }

    IEnumerator RepareTimer()
    {
        repareParticle.StartEmitParticle();
        yield return new WaitForSeconds(repareCooldown);
        repareParticle.StopEmitParticle();
    }

    public static int GetScore()
    {
        return GameManager.repareScore / GameManager.totalHp;
    }
}
