using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDamage : MonoBehaviour
{
    public float Health;
    private Rigidbody2D rigidBody;
    public BallController ballController;

    private void Update()
    {

        if (Health <= 0)
        {
            Destroy(gameObject);
        }           


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health = Health - ballController.Damage;
    }
}
