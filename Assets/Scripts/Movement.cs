using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    public float speed;
    [SerializeField]
    public float movementspeed;

    [SerializeField]
    float maxJumpHeight = 10f;
    [SerializeField]
    float jumpSpeed = 50f;
    [SerializeField]
    float jumpTime = 12.0f;

    [SerializeField]
    ParticleSystem WaterSplash;

    private bool isJumping;
    private bool JumpUp;
    private bool isJumpingDown;

    void Start()
    {
        isJumping = false;
        isJumpingDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0, 0, movementspeed * Time.deltaTime);
        //Movement
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -30)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 5)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
        }
        if (isJumping)
        {
            Jump();
        }
    }
    void Jump()
    {

        if (transform.position.y > maxJumpHeight)
        {
            isJumpingDown = true;
        }
        if (!isJumpingDown)
        {
            transform.position += new Vector3(0, jumpSpeed * Time.deltaTime, 0);
        }
        else
        {
            if (transform.position.y < 0)
            {
                isJumping = false;
                isJumpingDown = false;
                ParticleSystem ps= Instantiate(WaterSplash, transform.position, Quaternion.identity);
                ps.transform.position += new Vector3(7f, 0f, 0f);
            }
            transform.position -= new Vector3(0, jumpSpeed* 0.7f * Time.deltaTime, 0);
        }

        if (jumpTime >= 0)
        {

            jumpTime -= 0.01f;
        }
    }
}
