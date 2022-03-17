using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 10.0f;
    private bool isOnGround;
    private float zBound = 9.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        JumpPlayer();

        LimiteWalkPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Colidiu");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collider with enemy");
        }
    }

    //Código que move o jogador

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * speed * inputHorizontal);
        playerRb.AddForce(Vector3.forward * speed * inputVertical);
    }

    //Código que faz o jogador pular
    private void JumpPlayer()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    //Código que dá limite superior e inferior para onde o jogador pode andar
    private void LimiteWalkPlayer()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }


}
