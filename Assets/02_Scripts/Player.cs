using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    private void Dash()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            PlayerAim _playerAim = GetComponent<PlayerAim>();
            Vector3 dir = _playerAim.worldPos - transform.position;
            dir = dir.normalized;
            dir = dir * 100f;
            GetComponent<Rigidbody>().AddForce(dir, ForceMode.Impulse);
        }
    }
}