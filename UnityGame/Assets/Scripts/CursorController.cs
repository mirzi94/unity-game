using UnityEngine;

public class CursorController : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

}