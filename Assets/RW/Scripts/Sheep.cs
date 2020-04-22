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

    public float heartOffset;
    public GameObject heartPrefab;

    


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
        this.tag = "Untagged";
        Destroy(gameObject, dropDestroyDelay);
        audio.Play();
        GameStateManager.Instance.DroppedSheep();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }else if (other.CompareTag("DropSheep"))
        {
            if (this.CompareTag("Sheep"))
            {
                Drop();
            }
            

        }
    }
    private void HitByHay()
    {        
        GameStateManager.Instance.SavedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        audio.Play();
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>(); ; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay; // 3

    }
    
}
