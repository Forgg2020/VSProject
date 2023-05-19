using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old_PlayerMovement : PlayerData
{
    private float horizontal;
    private float vertical;
    public float speed = 24f;
    public bool isFacingRight = true;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        var mousePos = Input.mousePosition;
        //print(transform.position);
        if (mousePos.x < 500 && isFacingRight)
        {
            Flip();
        }
        else if (mousePos.x > 500 && !isFacingRight)
        {
            Flip();
        }
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * player_Speed, horizontal * player_Speed);
        rb.velocity = new Vector2(horizontal * player_Speed, vertical * player_Speed);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
