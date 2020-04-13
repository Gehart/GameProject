using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject DeadPlayer;
   

    private void OnTriggerEnter(Collider other)
    {
        // при столкновении с кактусом, игрок умирает.
        if (other.tag == "Cactus")
        {
            Player.SetActive(false);
            DeadPlayer.SetActive(true);
            Instantiate(DeadPlayer, transform.position, transform.rotation);
        }
        if (other.tag == "DeadObject")
        {
            Debug.Log("dead!");
            Player.GetComponent<Animator>().SetTrigger("Dead");
        }
        if (other.tag == "Water")
        {
            // ApplyDamage(10);
            Debug.Log("water!");
            RenderSettings.fogDensity = 0.2f;
            RenderSettings.fogColor = new Color(0.6f, 0.64f, 0.99f, 1f);
            RenderSettings.fog = true;
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
