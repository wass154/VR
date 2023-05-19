using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehabior : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float Range;
    [SerializeField] float Speed;
    [SerializeField] float CloseDistance;
    [SerializeField] Animator anim;
    private bool isFollow=false;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Walk",true);   
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, Player.position);
        RaycastHit hit;
        if (DistanceToPlayer <= CloseDistance || (Physics.Raycast(transform.position, Player.position - transform.position, out hit,Range)&& hit.collider.CompareTag("Player"))) { 
        isFollow= true;

            anim.SetBool("Walk", false);
            anim.SetBool("Attack",true);
            //MAKE IT FACE PLAYER
            transform.LookAt(Player.position);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        }
        else
        {
            isFollow=false;
            anim.SetBool("Walk",true) ;
            anim.SetBool("Attack", false);
         //   transform.Rotate(0, Random.Range(-180f, 180f), 0);
            transform.Translate(Vector3.forward*Speed* Time.deltaTime); 
        }
    }
}
