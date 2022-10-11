using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public AudioClip collectSound;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Destroy(gameObject); // Pickup will make suicide
        }
    }

}
