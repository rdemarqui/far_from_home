using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArrival : MonoBehaviour
{
    public PlayerController player;
    public GameObject planet;
    public FollowPlayer followPlayer;
    public float planetForce = 3000;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        Vector3 planetDirection = planet.transform.position - player.transform.position;
        if (planetDirection.magnitude < 250.0f)
        {
            this.enabled = false;
            player.rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        planetDirection.Normalize();
        player.rb.AddForce(planetDirection * Time.fixedDeltaTime * planetForce);
    }
    public void TakeShipToPlanet()
    {
        this.enabled = true;
        followPlayer.enabled = false;
        player.enabled = false;        
    }
}
