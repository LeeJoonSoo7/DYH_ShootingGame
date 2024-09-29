using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Vector3 screenPos;
    public Vector3 worldPos;
    public LayerMask layersOnHit;
    public Transform aimPoint;
    public GameObject prefab_bullet;
    public GameObject particle_muzzleFlashe;    // 총구 화염 파티클 오브젝트 참조용 변수

    private void Update()
    {
        Aim();
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            particle_muzzleFlashe.SetActive(true);
        }
        else
        {
            particle_muzzleFlashe.SetActive(false);
        }
    }

    public void Aim()
    {
        screenPos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 100, layersOnHit))
        {
            worldPos = hitInfo.point;
            worldPos.y = transform.position.y;
        }
        aimPoint.transform.position = worldPos;
    }

    private void Shoot()
    {
        screenPos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layersOnHit))
        {
            worldPos = hitInfo.point;
            worldPos.y = transform.position.y;
        }

        GameObject _obj = Instantiate(prefab_bullet, transform.position, Quaternion.identity);
        _obj.transform.LookAt(worldPos);
    }
}
