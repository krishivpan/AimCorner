using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CustomBullet : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask whatIsEnemies;

    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //Lifetime
    public int maxCollisions;
    public bool dieOnTouch;


    int collisions;
    PhysicsMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Die()
    {
        // Kill the bullet (delete) 
        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        if (collision.collider.CompareTag("Target"))
        {
            HUDScript hud = FindFirstObjectByType<HUDScript>();
            if (hud != null)
            {
                hud.AddScore();
            }
        }
        Debug.Log("Bullet hit: " + collision.gameObject.name + " with tag: " + collision.gameObject.tag);


        Die();

       
    }

    private void Setup()
    {
        // Create a new Physics material
        physics_mat = new PhysicsMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicsMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicsMaterialCombine.Maximum;

        // Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }
}
