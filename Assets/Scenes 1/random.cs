using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] Vector3 SpawnRange = new Vector3(2f, 0f, 2f);
    private Vector3 SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPosition=transform.position+new Vector3(Random.Range(-SpawnRange.x,SpawnRange.x),SpawnRange.y,Random.Range(-SpawnRange.z,SpawnRange.z));
        print(SpawnPosition);
        Instantiate(Prefab,SpawnPosition,Quaternion.identity);  
    }
}
