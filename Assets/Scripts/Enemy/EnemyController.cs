using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public PlayerHUDScript playerHUD;
    private GrapplingGunScript gun;
    private bool givenBonus = false;


    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<GrapplingGunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("isNearPlayer", true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && gun.isShooting)
        {
            animator.SetBool("isDead", true);
            GiveBonus();
        }
    }

    public void GiveBonus()
    {
        if (givenBonus) return;
        playerHUD.currentTime += 10;
        givenBonus = true;
    }
}
