using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMove : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalepPrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;
    public AudioSource shootin;
    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }
    private void ShootHay()
    {
        shootin.Play();
        Instantiate(hayBalepPrefab, haySpawnpoint.position, Quaternion.identity);
    }

   
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 2
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 3
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }
    private void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
