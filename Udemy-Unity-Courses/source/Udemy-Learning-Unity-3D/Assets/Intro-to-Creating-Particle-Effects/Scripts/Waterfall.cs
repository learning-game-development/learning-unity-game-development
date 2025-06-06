using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour {

    private ParticleSystem particles;
    private ParticleSystem.MainModule particlesModule;
    
    [SerializeField]
    private bool shortenedWaterfall;

    // Start is called before the first frame update
    void Start() {
        particles = GetComponent<ParticleSystem>();
        particlesModule = particles.main;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            particlesModule.gravityModifierMultiplier *= -1;
        }

        if (Input.GetKeyDown("w")) {
            if (shortenedWaterfall) {
                particlesModule.startLifetimeMultiplier *= 0.5f;
                shortenedWaterfall = true;
            } else {
                particlesModule.startLifetimeMultiplier *= 2.0f;
                shortenedWaterfall = false;
            }
        }
    }
}
