using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallDetect : MonoBehaviour
    {

    public Canvas CanvasLevelOver;
    public Text TextEndMessage;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= -10)
        {
            CanvasLevelOver.enabled = true;  // level over menu visible
            TextEndMessage.text = "Game over!";
            Time.timeScale = 0; //freeze time
            
        }
        
    }
}
