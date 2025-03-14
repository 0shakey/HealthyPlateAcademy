using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPaddle : NetworkBehaviour
{
    public float verticalSpeed = 5f;
    //public float horizontalSpeed = 5f;

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();

        if (!Object.HasStateAuthority)
        {
            return;
        }

        //float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("UP");
            moveY = 0.1f * verticalSpeed * Runner.DeltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("DOWN");
            moveY = -0.1f * verticalSpeed * Runner.DeltaTime;
        }

        //if (Input.GetKey(KeyCode.OnObjectHeld))
        //{
        //    Debug.Log("LEFT");
        //    moveX = -0.1f * horizontalSpeed * Runner.DeltaTime;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log("RIGHT");
        //    moveX = 0.1f * horizontalSpeed * Runner.DeltaTime;
        //}

        transform.Translate(0, moveY, 0);
        //transform.Translate(moveX, 0, 0);
    }
}
