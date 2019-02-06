using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] guards;
    public GameObject[] lights;
    public GameObject guard;
    public GameObject Player;
    public Transform guardSpawn;
    public PlayerController playerController;
    public int guardCount;

    private bool gameOver;
    

    void Awake ()
    {
        playerController = Player.GetComponent<PlayerController>();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Debug.Log(playerController.hasItem);
    }

    
    
    void SpawnGuard ()
    {
        Debug.Log("Spawn Guards.");
        if (guardCount < 5)
        {
            Debug.Log("Doesn't Spawn Guards.");
            Instantiate(guard, guardSpawn);
            guardCount++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (playerController.hasItem == true)
        {
            Debug.Log("Spawn Them1.");
            InvokeRepeating("SpawnGuard", 1f, 3f);
            playerController.hasItem = false;
        }
    }

}
