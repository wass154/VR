using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] Vector3 Destination;
   private Vector3 SpawnPos;
    [SerializeField] Vector3 CurrentPos;
    [SerializeField] float RangeX,RangeZ;
    [SerializeField] int ZombieCount;
    [SerializeField] int maxZombies = 2;
    [SerializeField] float Timer;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] GameObject bossPrefab;
    [SerializeField] float spawnInterval = 5f;
    private float timeSinceLastSpawn = 0f;
    private List<GameObject> zombies = new List<GameObject>();
    public bool isdead;


    // Start is called before the first frame update
    void Start()
    {
        isdead= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiePrefab == null && isdead)
        {
            //if zombie is dead then calul time and increase timer and if time passed respawn zombie again

      
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval && ZombieCount < maxZombies)
        {
            SpawnZombie();
           
        }
        }
     

    }
    void SpawnZombie()
    {
        SpawnPos = new Vector3(Random.Range(-RangeX, RangeX), -3.136f, Random.Range(-RangeZ, RangeZ));
        GameObject newZombie = Instantiate(zombiePrefab, SpawnPos, Quaternion.identity);
        zombies.Add(newZombie);
        ZombieCount++;
        timeSinceLastSpawn = 0f;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Bullet" )
        { // If the player hit the zombie
            CounterZombie.ZombieCount += 1;
            Destroy(zombiePrefab); // Destroy the zombie object
            SpawnZombie();
            isdead= true;
            GunBullet.Count --;
            // SpawnZombie(); // Respawn a new zombie
            print("trig");
        }
    }
}
