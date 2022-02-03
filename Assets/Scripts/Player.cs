using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public Rigidbody2D Rig;
    public SpriteRenderer SpriteRenderer;
    public int Score;
    public UI Ui;


    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        Rig.velocity = new Vector2(xInput * MoveSpeed, Rig.velocity.y);

        if (Rig.velocity.x > 0)
        {
            SpriteRenderer.flipX = false;
        }else if(Rig.velocity.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
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

    public void AddScore(int amount)
    {
        Score += amount;
        Ui.SetScoreText(Score);
    }
}
