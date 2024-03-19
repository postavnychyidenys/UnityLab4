using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWASDMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ����
    public float jumpForce = 10f; // ���� ������
    private Rigidbody2D rb; // ������ �� ��������� Rigidbody2D
    private bool isGrounded; // ����, �����������, ��������� �� ��� �� �����

    void Start()
    {
        // �������� ��������� Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������� ���� �� ����������
        float horizontalInput = Input.GetAxis("Horizontal");

        // ����������� ��� ����� � ������
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // �������, ���� ��� ��������� �� ����� � ������ ������� ������ (������)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ���� ��� �������� ������� � ����� "Ground", �� �� ��������� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ���������, ���� ��� ������ �� �������� ������� � ����� "Ground", �� �� �� ��������� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}