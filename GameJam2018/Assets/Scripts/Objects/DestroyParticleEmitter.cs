using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEmitter : MonoBehaviour {


    public ParticleSystem destroyedParticle;
    public BoxCollider box;
    // Use this for initialization
    void Start()
    {
        box = transform.parent.GetComponent<BoxCollider>();
        var dsh = destroyedParticle.shape;
        dsh.scale = new Vector3(box.size.x,box.size.z,box.size.y);
        if (!GetComponentInParent<BaseObject>().isRepared)
        {
            destroyedParticle.Play();
        }
    }

    public void StartEmitDestroyParticle()
    {
        destroyedParticle.Play();
    }

    public void StopEmitParticle()
    {
        destroyedParticle.Stop();
    }
}
