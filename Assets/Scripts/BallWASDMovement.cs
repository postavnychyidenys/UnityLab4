using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWASDMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения мяча
    public float jumpForce = 10f; // Сила прыжка
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private bool isGrounded; // Флаг, указывающий, находится ли мяч на земле

    void Start()
    {
        // Получаем компонент Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Получаем ввод от клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");

        // Передвигаем мяч влево и вправо
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Прыгаем, если мяч находится на земле и нажата клавиша прыжка (пробел)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, если мяч касается объекта с тегом "Ground", то он находится на земле
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Проверяем, если мяч больше не касается объекта с тегом "Ground", то он не находится на земле
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}