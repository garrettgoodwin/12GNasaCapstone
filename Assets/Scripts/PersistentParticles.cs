using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    void Start()
    {
        // Get the Particle System component
        particles = GetComponent<ParticleSystem>();

        // Make this GameObject persist across scene loads
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Check if the particle system has stopped playing
        if (!particles.IsAlive())
        {
            // Destroy the GameObject if the particles have finished playing
            Destroy(gameObject);
        }
    }
}
