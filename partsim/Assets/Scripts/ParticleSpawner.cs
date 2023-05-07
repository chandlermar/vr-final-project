using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    public GameObject particlePrefab;
    public Transform spawnPoint;
    public int numParticles = 10;
    public float spawnRadius = 1f;
    public float scanRadius = 2f;
    public float cohesionWeight = 1f;
    public float separationWeight = 1f;
    public float alignmentWeight = 1f;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float maxForce = 1f;

    private GameObject[] particles;

    void Start()
    {
        SpawnParticles();
    }

    void SpawnParticles()
    {
        particles = new GameObject[numParticles];
        for (int i = 0; i < numParticles; i++)
        {
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            particles[i] = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        foreach (GameObject particle in particles)
        {
            Rigidbody rb = particle.GetComponent<Rigidbody>();
            Vector3 cohesion = Vector3.zero;
            Vector3 separation = Vector3.zero;
            Vector3 alignment = Vector3.zero;
            int count = 0;

            Collider[] colliders = Physics.OverlapSphere(particle.transform.position, scanRadius);
            foreach (Collider col in colliders)
            {
                if (col.gameObject != particle && col.gameObject.CompareTag("Particle"))
                {
                    count++;
                    cohesion += col.transform.position;
                    separation += (particle.transform.position - col.transform.position).normalized / (particle.transform.position - col.transform.position).magnitude;
                    alignment += col.GetComponent<Rigidbody>().velocity;
                }
            }

            if (count > 0)
            {
                cohesion /= count;
                separation /= count;
                alignment /= count;

                cohesion = (cohesion - particle.transform.position).normalized;
                separation = separation.normalized;
                alignment = alignment.normalized;

                Vector3 desiredVelocity = (cohesion * cohesionWeight + separation * separationWeight + alignment * alignmentWeight).normalized * speed;
                Vector3 steeringForce = Vector3.ClampMagnitude(desiredVelocity - rb.velocity, maxForce);
                rb.AddForce(steeringForce, ForceMode.VelocityChange);

                Quaternion targetRotation = Quaternion.LookRotation(rb.velocity);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
