using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticleEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleEffect;
    [SerializeField]
    private MeshRenderer mr;


    public void PlayEffect()
    {

        var em = particleEffect.emission;
        var duration = particleEffect.duration;

        em.enabled = true;
        particleEffect.Play();
        mr.enabled = false;
        Invoke(nameof(DestroyObject), duration);
    }


    void DestroyObject()
    {
        Destroy(gameObject);

    }
}

