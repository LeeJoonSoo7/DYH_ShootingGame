using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject prefab_particle_boom; // Àû±º »ç¸Á ½Ã Æø¹ß ÆÄÆ¼Å¬

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
            // Á¡¼ö 1Á¡ È¤µæ!
            GameManager.Instance.AddScore();

            Instantiate(prefab_particle_boom, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
