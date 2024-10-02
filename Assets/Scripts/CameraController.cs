using UnityEngine;

public class CameraController : MonoBehaviour
{

private bool canMove = true;

public float panSpeed = 30f;
public float panBorder = 10f;
public float scrollSpeed = 5f;

public float minY = 15f;
public float maxY = 60f;

void Update () {

    if (Input.GetKeyDown(KeyCode.P))
    {
        canMove = !canMove;
    }

    if(!canMove)
    {
        return;
    }

    if(Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
    {
        transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
    {
        transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
    }
        if(Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)
    {
        transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
    }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
    {
        transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
    }

    float scroll = Input.GetAxis("Mouse ScrollWheel");

    Vector3 pos = transform.position;

    pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
    pos.y = Mathf.Clamp(pos.y, minY, maxY);

    transform.position = pos;
}
}
