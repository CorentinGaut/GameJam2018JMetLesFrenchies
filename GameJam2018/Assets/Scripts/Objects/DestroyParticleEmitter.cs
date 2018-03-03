using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEmitter : MonoBehaviour {


    public ParticleSystem destroyedParticle;
    public BoxCollider box;
    // Use this for initialization
    void Start()
    {
        var dsh = destroyedParticle.shape;
        dsh.scale = box.size;
        if (!GetComponentInParent<BaseObject>().isRepared)
        {
            var dem = destroyedParticle.emission;
            dem.enabled = true;
        }
    }

    public void StartEmitDestroyParticle()
    {

                var dem = destroyedParticle.emission;
                dem.enabled = true; 
        
    }

    public void StopEmitParticle()
    {

                var dem = destroyedParticle.emission;

    }
}
