using UnityEngine;

public class ScissorsMechanics : MonoBehaviour
{
    private Animator animator;
    private Vector3 mousePos;
    private Vector3 objectPos;
    private float deltaX;
    private Vector3 initialPos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        initialPos = transform.position;
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        deltaX = mousePos.x - objectPos.x;
        animator.SetBool("dragging", true);
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        animator.SetBool("dragging", false);
        transform.position = initialPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
