using UnityEngine;
using System.Collections.Generic;

public class ParticleInteraction : MonoBehaviour
{
    //public float g;
    private GameObject[] particlesRed;
    private GameObject[] particlesGreen;
    private GameObject[] particlesBlue;

    public GameObject redParticlePrefab;
    public GameObject greenParticlePrefab;
    public GameObject blueParticlePrefab;
    public Transform spawnPoint;
    public int numParticles = 10;
    public float spawnRadius = 1f;
    public float scanRadius = 2f;
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float maxForce = 1f;


    private void Start()
    {
        SpawnParticles();
    }

    void SpawnParticles()
    {
        particlesRed = new GameObject[numParticles/3];
        particlesGreen = new GameObject[numParticles/3];
        particlesBlue = new GameObject[numParticles / 3];
        GameObject particlePrefab;

        for (int i = 0; i < numParticles / 3; i++)
        {
            particlePrefab = redParticlePrefab;
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            particlesRed[i] = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numParticles / 3; i++)
        {
            particlePrefab = greenParticlePrefab;
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            particlesGreen[i] = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < numParticles / 3; i++)
        {
            particlePrefab = blueParticlePrefab;
            Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            particlesBlue[i] = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
        }
    }
    void Update()
    {
        Rule(particlesRed, particlesGreen, 4); //green attracts red
        //Rule(particlesGreen, particlesBlue, -2); //blue repels green
        Rule(particlesBlue, particlesRed, 1); //red attracts blue
        //Rule(particlesBlue, particlesGreen, 2); //green attracts blue
        Rule(particlesGreen, particlesBlue, -12); //blue repels green

    }

    void Rule(GameObject[] particles1, GameObject[] particles2, float g)
    {
        foreach (GameObject particle1 in particles1)
        {
            Vector3 netForce = Vector3.zero;
            foreach (GameObject particle2 in particles2)
            {
                Vector3 a = particle1.transform.position;
                Vector3 b = particle2.transform.position;
                float d = Vector3.Distance(a, b);
                if (d > 0.4f && d < 4f)
                {
                    Vector3 forceDirection = (b - a).normalized;
                    float F = g / d;
                    netForce += F * forceDirection;
                }
            }
            Rigidbody rb = particle1.GetComponent<Rigidbody>();
            rb.AddForce(netForce);
            rb.MovePosition(rb.position + rb.velocity * Time.deltaTime);
            
        }
    }
}
