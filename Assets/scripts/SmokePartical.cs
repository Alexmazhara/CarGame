using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePartical : MonoBehaviour
{
    float particalEmissionRate = 0;

    car car;
    ParticleSystem particleSustemSmoke;
    ParticleSystem.EmissionModule particleSustemEmissionModule;

    void Awake()
    {
        car = GetComponentInParent<car>();
        particleSustemSmoke = GetComponent<ParticleSystem>();
        particleSustemEmissionModule = particleSustemSmoke.emission;
        particleSustemEmissionModule.rateOverTime = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        particalEmissionRate = Mathf.Lerp(particalEmissionRate, 0, Time.deltaTime * 5);
        particleSustemEmissionModule.rateOverTime = particalEmissionRate;

        if (car.IsTireScreeching(out float laterateralVelocity, out bool isBraking))
        {
            if (isBraking)
                particalEmissionRate = 30;
            else particalEmissionRate = Mathf.Abs(laterateralVelocity) * 2;
        }
    }
}
