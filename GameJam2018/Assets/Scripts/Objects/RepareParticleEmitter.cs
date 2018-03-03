using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepareParticleEmitter : MonoBehaviour {


    public ParticleSystem repareParticle;
    public BoxCollider box;
    // Use this for initialization
    void Start()
    {
        box = transform.parent.GetComponent<BoxCollider>();

        var rsh = repareParticle.shape;
        rsh.scale = box.size;
    }

    public void StartEmitParticle()
    {
                var rem = repareParticle.emission;
                rem.enabled = true; 
    }

    public void StopEmitParticle()
    {
                var rem = repareParticle.emission;
                rem.enabled = false; 
    }
}
