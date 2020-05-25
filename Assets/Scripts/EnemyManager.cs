using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(enemy, new Vector3(24.64f + i * 2f, 107.9567f, 45.58f), Quaternion.identity);

        }
    }


    void Update()
    {
        
    }
}
