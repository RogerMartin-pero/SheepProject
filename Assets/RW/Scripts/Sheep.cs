using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidBody;
    private SheepSpawner sheepSpawner;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.loop = false;
        myCollider = GetComponent<Collider>();
        myRigidBody = GetComponent<Rigidbody>();
    }
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidBody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        audio.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }else if (other.CompareTag("DropSheep"))
        {
            Drop();

        }
    }
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        audio.Play();
        
    }
    
}
