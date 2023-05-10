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

    public float brownianStrength = 0.1f;
    public float interactionDistance = 10f;



    public int redToRed = 0;
    public int redToGreen = 0;
    public int redToBlue = (int) UIMgr.inst.slider1.value;

    public int greenToRed = 0;
    public int greenToGreen = 0;
    public int greenToBlue = 0;

    public int blueToRed = 0;
    public int blueToGreen = 0;
    public int blueToBlue = 0;


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
        //Grab slider values on every update
        redToBlue = (int)UIMgr.inst.slider1.value;
        redToGreen = (int)UIMgr.inst.slider2.value;
        blueToGreen = (int)UIMgr.inst.slider3.value;
        blueToRed = (int)UIMgr.inst.slider4.value;
        greenToRed = (int)UIMgr.inst.slider5.value;
        greenToBlue = (int)UIMgr.inst.slider6.value;

        //If changed, run appropriate rule
        if (redToGreen != 0){
            Rule(particlesRed, particlesGreen, redToGreen);
        }
        if (redToRed != 0){
            Rule(particlesRed, particlesRed, redToRed);
        }
        if (redToBlue != 0){
            Rule(particlesRed, particlesBlue, redToBlue);
        }

        if (greenToRed != 0){
            Rule(particlesGreen, particlesRed, greenToRed);
        }
        if (greenToGreen != 0){
            Rule(particlesGreen, particlesGreen, greenToGreen);
        }
        if (greenToBlue != 0){
            Rule(particlesGreen, particlesBlue, greenToBlue);
        }

        if (blueToRed != 0){
            
            Rule(particlesBlue, particlesRed, blueToRed);
        }
        if (blueToGreen != 0){
            Rule(particlesBlue, particlesGreen, blueToGreen);
        }
        if (blueToBlue != 0){
            Rule(particlesBlue, particlesBlue, blueToBlue);
        }
        
        // Rule(particlesRed, particlesGreen, 4); //green attracts red
        // //Rule(particlesGreen, particlesBlue, -2); //blue repels green
        // Rule(particlesBlue, particlesRed, 1); //red attracts blue
        // //Rule(particlesBlue, particlesGreen, 2); //green attracts blue
        // Rule(particlesGreen, particlesBlue, -12); //blue repels green

        //AddBrownianMotion(particlesRed);
        //AddBrownianMotion(particlesGreen);
        //AddBrownianMotion(particlesBlue);

    }

    void Rule(GameObject[] particles1, GameObject[] particles2, float g)
    {
        float damping = 2f;
        

        foreach (GameObject particle1 in particles1)
        {
            Vector3 netForce = Vector3.zero;
            foreach (GameObject particle2 in particles2)
            {
                Vector3 a = particle1.transform.position;
                Vector3 b = particle2.transform.position;
                float d = Vector3.Distance(a, b);
                if (d > 0.5f && d < 5f)
                {
                    Vector3 forceDirection = (b - a).normalized;
                    float F = g / d;
                    netForce += F * forceDirection;
                }
            }
            Rigidbody rb = particle1.GetComponent<Rigidbody>();

            rb.velocity *= (1f - damping * Time.deltaTime);
            Vector3 angularVelocity = Vector3.Cross(rb.angularVelocity, Vector3.up);
        
            // Apply damping to angular velocity
            rb.angularVelocity *= (1f - damping * Time.deltaTime);

            rb.AddForce(netForce/2);
            rb.MovePosition(rb.position + rb.velocity * Time.deltaTime);
            
        }
    }

    
    void AddBrownianMotion(GameObject[] particles)
    {
        foreach (GameObject particle in particles)
        {
            Rigidbody rb = particle.GetComponent<Rigidbody>();
            Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.AddForce(randomForce * brownianStrength);
        }
    }
    

}
