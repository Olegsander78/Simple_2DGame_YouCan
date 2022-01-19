using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public Rigidbody2D Rig;

    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        Rig.velocity = new Vector2(xInput * MoveSpeed, Rig.velocity.y);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -0.03f, 0f), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
