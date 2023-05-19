using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPos;
    [SerializeField] float Delay;
    [SerializeField] Vector3 direction;
    [Range(0, 2000)][SerializeField] float BulletSpeed;
    [Space, SerializeField] AudioSource aud;
    private float LastShot;
    public static float CountBullet;
    private bool Max=false;
    // Start is called before the first frame update
    void Start()
    {
        CountBullet = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (GunBullet.Count > 0)
        {
          //  ShootGun();
        
          
        }
        if(CountBullet<0)   
        {
            print("EMPTY STOCK OF BULLETS ");
            Max= true;
        }
        else
        {
            Max = false;
        }
        
    }
   public void ShootGun()
    {
        if(!Max) { 
        if(LastShot>Time.time)return;
             LastShot = Time.time+Delay;
             GunAudio();
             var bulletPrefab=Instantiate(Bullet,BulletPos.position,BulletPos.rotation);
             var bulletRigidbody=bulletPrefab.GetComponent<Rigidbody>();
             var Direction = bulletPrefab.transform.TransformDirection(direction.normalized);
             bulletRigidbody.AddForce(Direction * BulletSpeed);
             Destroy(bulletPrefab, 2f);
             CountBullet--;
        }
    }
    private void GunAudio()
    {
        var random=Random.Range(0.2f,1.8f);
        aud.pitch = random;
        aud.Play();
    }
}
