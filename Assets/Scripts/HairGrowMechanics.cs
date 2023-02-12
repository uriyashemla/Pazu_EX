using UnityEngine;

public class HairGrowMechanics : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 objectPos;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        transform.position = initialPos;
    }
}
