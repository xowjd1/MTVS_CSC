using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate ()
    {
       // Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
