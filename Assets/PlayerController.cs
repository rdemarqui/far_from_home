using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movement;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(300, 000, 000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")==true)
        {
            rb.AddForce(-movement, 0, 0);
        }
        else if (Input.GetKey("d") == true)
        {
            rb.AddForce(movement, 0, 0);
        }
        
    }
}
