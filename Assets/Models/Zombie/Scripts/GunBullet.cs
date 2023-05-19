using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunBullet : MonoBehaviour
{
    public static int Count;
    public TextMeshProUGUI Text;
    
    // Start is called before the first frame update
    void Start()
    {
       // Count= 10;
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Gun" + Shoot.CountBullet;
    }
}
