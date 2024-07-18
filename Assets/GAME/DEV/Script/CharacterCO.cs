using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCO : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] private float speed;
    [SerializeField] private float hSpeed;
    [SerializeField] private Joystick floatingJoystick;
    [SerializeField] float leftRightLimit;


    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = floatingJoystick.Horizontal;
        Vector3 horizontalMovement = Vector3.right * horizontalInput * hSpeed * Time.fixedDeltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        Vector3 newPosition = transform.position + horizontalMovement;
        newPosition.x = Mathf.Clamp(newPosition.x, -leftRightLimit, leftRightLimit);
        transform.position = newPosition;
    }

}
