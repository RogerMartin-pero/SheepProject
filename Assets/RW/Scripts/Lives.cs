using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    public Text livetext;
    public int lives;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(lives > 0)
        {
            livetext.text = "Lives: " + lives;
        }
        else
        {
            livetext.text = "GAME OVER";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            if (lives > 0)
            {
                other.tag = "Untagged";
                lives--;
            }
        }
        
    }
}
