using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Vector3 screenPos;
    public Vector3 worldPos;
    public LayerMask layersOnHit;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        LookAtMouse();

        if (Input.GetKeyDown(KeyCode.W)) { Anim_PlayRun(); }
        if (Input.GetKeyDown(KeyCode.A)) { Anim_PlayRun(); }
        if (Input.GetKeyDown(KeyCode.S)) { Anim_PlayRun(); }
        if (Input.GetKeyDown(KeyCode.D)) { Anim_PlayRun(); }

        if (Input.GetKeyUp(KeyCode.W)) { Anim_PlayIdle(); }
        if (Input.GetKeyUp(KeyCode.A)) { Anim_PlayIdle(); }
        if (Input.GetKeyUp(KeyCode.S)) { Anim_PlayIdle(); }
        if (Input.GetKeyUp(KeyCode.D)) { Anim_PlayIdle(); }
    }

    public void LookAtMouse()
    {
        screenPos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layersOnHit))
        {
            worldPos = hitInfo.point;
            worldPos.y = transform.position.y;
        }
        transform.LookAt(worldPos);
    }

    public void Anim_PlayRun()
    {
        animator.SetBool("isRun", true);
    }

    public void Anim_PlayIdle()
    {
        animator.SetBool("isRun", false);
    }
}
