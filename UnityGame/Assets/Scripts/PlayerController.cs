using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Camera cam;
    Collider planecollider;
    RaycastHit hit;
    Ray ray;
    public Canvas CanvasLevelOver;
    public Transform pickups;
    public InputField InputFieldPickupAmount;
    public Text TextEndMessage;
    public InputField InputFieldTimeLeft;
    public int StartTime = 30;
    
    private int TimeLeft;
    private int pickupsAtStart;
    private int pickupsCollected;


    void Start()

    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planecollider = GameObject.Find("Plane").GetComponent<Collider>();

        pickupsAtStart = pickups.childCount;

        CanvasLevelOver.enabled = false;
        TimeLeft = StartTime; //reset the level time left
        InputFieldTimeLeft.text = TimeLeft.ToString();
        Time.timeScale = 1;//unfreeze time

        StartCoroutine("updateGameStatus");
    }

    IEnumerator updateGameStatus()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(1.0f);
            if (TimeLeft > 0)
                TimeLeft--;
            pickupsCollected = pickupsAtStart - pickups.childCount;
            InputFieldPickupAmount.text = pickupsCollected.ToString();
            
            InputFieldTimeLeft.text = TimeLeft.ToString();
            if (pickups.childCount == 0) // no pickups left? --> win level!
            {
                TextEndMessage.text = "Level completed!";
                //int ElapsedTime = StartTime - TimeLeft;
                CanvasLevelOver.enabled = true;  // level over menu visible
                Time.timeScale = 0; //freeze time
                break;

            }
   
            else if (TimeLeft <= 0)//lost level and game!
            {
            CanvasLevelOver.enabled = true;
            TextEndMessage.text = "Game over!";
            Time.timeScale = 0; //freeze time
            break;
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planecollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 4);
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
