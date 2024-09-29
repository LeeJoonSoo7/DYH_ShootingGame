using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject prefab_particle_boom; // ���� ��� �� ���� ��ƼŬ

    private void Start()
    {
        Invoke("KillMyself", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void KillMyself()

    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            // ���� 1�� Ȥ��!
            GameManager.Instance.AddScore();

            Instantiate(prefab_particle_boom, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
