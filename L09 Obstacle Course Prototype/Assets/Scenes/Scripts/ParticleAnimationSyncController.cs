using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public float emissionRate = 100.0f; // Default emission rate
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Apply the initial emission rate to all child particle systems
        ApplyEmissionRateToChildren(emissionRate);
    }

    private void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator not found.");
            return;
        }

        // Set the Animator parameter based on the emissionRate property
        animator.SetFloat("EmissionRate", emissionRate);
    }

    private void ApplyEmissionRateToChildren(float rate)
    {
        // Find all ParticleSystems in children and apply the emission rate
        ParticleSystem[] childParticleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in childParticleSystems)
        {
            var emission = ps.emission;
            emission.rateOverTime = rate;
        }
    }
}
