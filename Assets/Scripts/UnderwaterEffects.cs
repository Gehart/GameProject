using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffects : MonoBehaviour
{
    public GameObject player;
    public float waterLevel;
    private bool isUnderWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < waterLevel != isUnderWater)
        {
            isUnderWater = player.transform.position.y < waterLevel;
            if (isUnderWater)
            {
                RenderSettings.fogDensity = 0.2f;
                RenderSettings.fogColor = new Color(0.6f, 0.64f, 0.99f, 1f);
                RenderSettings.fog = true;
            }
            else
            {
                RenderSettings.fog = false;
            }
        }
    }
}
