using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GurdParticle : MonoBehaviour
{
    private ParticleSystem _ps;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _ps = this.GetComponent<ParticleSystem>();
            _ps.Play();
        }
    }
}
