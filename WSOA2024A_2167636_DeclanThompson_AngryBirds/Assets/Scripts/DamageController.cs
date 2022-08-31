using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public GameManager gameManager;
    public float Health = 10f;
    public Rigidbody2D rigidBody;
    public BallController ballController;
    public float FallDamage;
    private float enemiesLeft = 3f;

    private void Update()
    {
        if (rigidBody.position.x >= 9.54)
        {
            Health = 0;
        }


        if (Health <= 0)
        {
            Destroy(gameObject);
            enemiesLeft--;
            gameManager.PlayerScored(1);
        }
        
                
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health = Health - ballController.Damage;        
    }
    

    
}
