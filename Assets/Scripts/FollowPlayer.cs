using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerController playerController;
    public Vector3 playerDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null)
        {
            return;
        }
        this.transform.position = playerController.transform.position + playerDistance;
    }
}
