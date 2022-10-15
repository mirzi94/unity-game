using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    public Color trailColor = new Color(1, 0, 0, 1);
    public float distanceFromCamera = 3;
    public float startWidth = 0.05f;
    public float endWidth = 0f;
    public float trailTime = 0.1f;
    public Canvas CanvasLevelOver;

    Transform trailTransform;
    Camera thisCamera;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();

        GameObject trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        TrailRenderer trail = trailObj.AddComponent<TrailRenderer>();
        trail.time = -1f;
        MoveTrailToCursor(Input.mousePosition);
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        trail.sharedMaterial.color = trailColor;
        CanvasLevelOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTrailToCursor(Input.mousePosition); 
        
        if(CanvasLevelOver.enabled == true)
        {
            trailTime = 0.0f;
            startWidth = 0.00f;
            distanceFromCamera = 0;
        }
    }

    void MoveTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = thisCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera));
    }

   

    }