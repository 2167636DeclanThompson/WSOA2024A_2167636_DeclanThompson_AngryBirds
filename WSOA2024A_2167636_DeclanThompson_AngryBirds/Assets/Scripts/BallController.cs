using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // FreakyFeet. Make an Angry birds-like sling mechanic in Unity. (June 7, 2018) Accessed: June 6, 2020. [Online Video] Available: https://www.youtube.com/watch?v=VOEtOGmHoeE

    private bool isClicked;
    private Rigidbody2D rigidBody;
    private SpringJoint2D springJoint;
    private SpriteRenderer spriteRenderer;
    public float maxShots;
    private float releaseBall;
    public float respawnBall = 1f;
    private float maxDistance = 1.5f;
    private Rigidbody2D rigidBodySling;
    private LineRenderer line;
    private TrailRenderer trail;
    public float Damage;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBodySling = springJoint.connectedBody;
        line = GetComponent<LineRenderer>();
        trail = GetComponent<TrailRenderer>();
        releaseBall = 1 / (springJoint.frequency * 4);
        trail.enabled = false;
        line.enabled = false;
        maxShots = 5;
    }

    private void Update()
    {
        if(isClicked )
        {
            DragBall();
        }

        Damage = (rigidBody.velocity.x + rigidBody.velocity.y)/2;
    }

    private void DragBall()
    {
        LineRendererPosition();
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, rigidBodySling.position);
        if (distance > maxDistance)
        {
            Vector2 direction = (mousePosition - rigidBodySling.position).normalized;
            rigidBody.position = rigidBodySling.position + direction * maxDistance;
        }
        else
        {
            rigidBody.position = mousePosition;
        }
        
    }
    private void LineRendererPosition()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = rigidBody.position;
        positions[1] = rigidBodySling.position;
        line.SetPositions(positions);
    }
    private void OnMouseDown()
    {
        isClicked = true;
        rigidBody.isKinematic = true;
        line.enabled = true;
        trail.enabled = false;
        
    }

    private void OnMouseUp()
    {
        isClicked = false;
        rigidBody.isKinematic = false;
        StartCoroutine(Release());
        StartCoroutine(Respawn());
        line.enabled = false;
        
        

    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseBall);
        springJoint.enabled = false;
        trail.enabled = true;

    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnBall);
        spriteRenderer.enabled = false;
        rigidBody.position = new Vector3(-6.45f, -2.71f, -1.875f);
        springJoint.enabled = true;
        spriteRenderer.enabled = true;
        maxShots--;
   }
}
