using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterZombie : MonoBehaviour
{
    public static int ZombieCount;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        ZombieCount = 0;
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Zombies:" + ZombieCount;
    }
}
