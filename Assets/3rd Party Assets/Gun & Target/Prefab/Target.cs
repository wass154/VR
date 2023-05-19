using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    private MeshRenderer mesh;
    private BoxCollider Box;
    private AudioSource aud;
    private ParticleSystem part;
    private Vector3 randomRotation;
    private bool isDisabled;




    [SerializeField] GameObject Tar;
    [SerializeField] Vector3 maxSpawnRange = new Vector3(2f, 0f, 2f);
    [SerializeField] Vector3 minusSpawnRange = new Vector3(2f, 0f, 2f);
    private Vector3 SpawnPosition;
    // Start is called before the first frame update
    void Awake()
    {
        mesh=GetComponent<MeshRenderer>();
            Box=GetComponent<BoxCollider>();
            aud=GetComponent<AudioSource>();    
            part=GetComponent<ParticleSystem>();
        randomRotation = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    
    }
    void Rotate()
    {
        transform.Rotate(randomRotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isDisabled && collision.gameObject.CompareTag("Bullet")) { 
            Destroy(collision.gameObject);
            transform.position = new Vector3(Random.Range(minusSpawnRange.x, maxSpawnRange.x), Random.Range(minusSpawnRange.y, maxSpawnRange.y), Random.Range(minusSpawnRange.z, maxSpawnRange.z));

          
        }
    }
 
    /*void Spawn()
    {
    
        SpawnPosition = transform.position + new Vector3(Random.Range(-SpawnRange.x, SpawnRange.x), SpawnRange.y, Random.Range(-SpawnRange.z, SpawnRange.z));
   
    }*/
    void TargetDestroy()
    {
        var random = Random.Range(0.2f, 1.8f);
        aud.pitch= random;
        aud.Play();
        part.Play();
    }
}
