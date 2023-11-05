using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : SwatterScript
{
    public GameObject disappearEffectPrefabSpider;
    public Vector2 walkDirection = Vector2.left; 
    public float walkSpeed = 6.0f; 
    public float walkRange = 10.0f; 

    private Vector2 originalPosition; 
    private Rigidbody2D rb; 

    void Start()
    {
        base.Start();
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        Vector2 movement = walkDirection * walkSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        if (Vector2.Distance(originalPosition, rb.position) > walkRange)
        {
            walkDirection = -walkDirection;
            rb.position = originalPosition + walkDirection * walkRange;
        }
    }

    public void PlayDisappearEffectSpider(Vector3 position)
    {
        GameObject effect = Instantiate(disappearEffectPrefabSpider, position, Quaternion.identity);
        Destroy(effect, 1f); 
    }

    void OnDestroy()
    {
        PlayDisappearEffectSpider(transform.position);
    }
}
