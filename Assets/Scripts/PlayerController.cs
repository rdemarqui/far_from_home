using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int forcaEmX, forcaEmZ = 50;
    public Rigidbody rb;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forcaEmZ * Time.fixedDeltaTime);

        if (Input.GetKey("a")==true)
        {
            rb.AddForce(-forcaEmX * Time.fixedDeltaTime, 0, 0);
        }
        if (Input.GetKey("d") == true)
        {
            rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Colisão com " + collision.collider.name);
        if (collision.collider.CompareTag("Enemy") == true)
        {
            gameController.GameOver();
        }
    }
}
