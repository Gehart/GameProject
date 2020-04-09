﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeadPlayer;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cactus")
        {
            Player.SetActive(false);
            DeadPlayer.SetActive(true);
            Instantiate(DeadPlayer, transform.position, transform.rotation);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
