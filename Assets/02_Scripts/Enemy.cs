using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //������ �÷��̾�� �����Ͽ��°�?
        if (collision.collider.CompareTag("Player"))
        {
            // �÷��̾��� ����� GameManager���� �˸�
            GameManager.Instance.OnPlayerDeath();

            // �÷��̾� ���ó�� (�ı�)
            Destroy(collision.gameObject);
        }
    }
}
