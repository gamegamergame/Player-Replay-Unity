using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevel;

public class InputController : MonoBehaviour
{
    [SerializeField]
    PlayerScript pScript;

    [SerializeField]
    ReplayScript replayScript;

    [SerializeField]
    GameManager manager;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!replayScript.isReplaying) 
        {
            pScript.SetMoveDirection(context.ReadValue<Vector2>());
        }
    }
    public void OnReplay(InputAction.CallbackContext context)
    {
        //if (!replayScript.isReplaying)
        //{
        //Debug.Log("test");

        replayScript.Replay();
        //}
    }
    /*public void OnShoot(InputAction.CallbackContext context)
    {
        //reminder to code switching number when you switch weapons
        //if (manager)
        //number represents what weapon you are holding and boolean tells method if the player is the one firing
        manager.SpawnBullet(true, 1);
    }
    public void OnDodge(InputAction.CallbackContext context)
    {
        pScript.Dodge();
    }
    public void OnReload(InputAction.CallbackContext context)
    {
        StartCoroutine(manager.Reload());
    }
    public void OnBT(InputAction.CallbackContext context)
    {
        manager.BulletTime();
    }*/
}
