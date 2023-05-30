using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int forcaEmX, forcaEmZ = 50;
    public float targetAngle = 30;
    public float rotationSpeed = 3f;
    public Rigidbody rb;
    public GameController gameController;
    public float maxVelocityZ = 200;
    public GameObject fxExplosionPrefab;
    //public Vector3 finalPosition; //added
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.z < maxVelocityZ)
        {
            rb.AddForce(0, 0, forcaEmZ * Time.fixedDeltaTime);
        }
        

        if (Input.GetKey("a")==true)
        {
            rb.AddForce(-forcaEmX * Time.fixedDeltaTime, 0, 0);
            ShipRotation(1);
        }
        else if (Input.GetKey("d") == true)
        {
            rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);
            ShipRotation(-1);
        }
        else
        {
            ShipRotation(0);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Colisão com " + collision.collider.name);
        if (collision.collider.CompareTag("Enemy") == true)
        {
            GameObject.Instantiate(fxExplosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            gameController.GameOver();
        }
    }
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Planet") == true)
        {
            //finalPosition = rb.transform.position; //added
            gameController.WinGame();
            rb.AddForce(0, 0, 0);
        }
    }

    void ShipRotation(int multiplier)
    {
        Quaternion currentRotation = rb.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle * multiplier);
        Quaternion newRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
        rb.MoveRotation(newRotation);
    }
}
