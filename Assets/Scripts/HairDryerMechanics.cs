using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDryerMechanics : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    private Vector3 initialPos;
    private Quaternion rot;
    public GameObject [] hair;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.z = 0;

        rb.MovePosition(objPosition);

        Vector2 direction = (hair[0].transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        for(int i = 0; i<5; i++)
        {
            hair[i].transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void OnMouseUp()
    {
        transform.position = initialPos;
        transform.rotation = rot;
    }
}
