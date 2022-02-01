using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Vector3 startPos, finalPos, movementDirection;

    public Vector3 MovementDirection { get { return movementDirection; } }

    void Update()
    {
        GetInputFromUser();
    }

    private void GetInputFromUser()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            finalPos = Input.mousePosition;
            movementDirection = new Vector3(finalPos.x - startPos.x, 0f, 0f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            movementDirection = Vector3.zero;
        }
    }
}
