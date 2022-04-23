using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviouScript : MonoBehaviour
{
    public PlayerHUDScript playerHUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHUD.WinLevel();
        }
    }
}
