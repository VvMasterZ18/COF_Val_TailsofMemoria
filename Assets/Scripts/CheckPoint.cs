using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerRespawn playerRespawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRespawn = GameObject.Find("VvMaster").GetComponent<PlayerRespawn>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "VvMaster")
        {
            playerRespawn.respawnPoint = transform.position;
        }
    }
}
