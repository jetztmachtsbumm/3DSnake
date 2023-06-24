using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControlls : MonoBehaviour
{

    public static SnakeControlls Instance { get; private set; }

    private PlayerControlls controlls;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one SnakeControlls object active in the scene!");
            Destroy(gameObject);
        }
        Instance = this;

        controlls = new PlayerControlls();
        controlls.Player.Enable();
    }

    public Vector3 GetMovementDirection(Vector3 currentMovementDirection)
    {
        Vector2 inputVector = controlls.Player.Move.ReadValue<Vector2>();

        if(inputVector.x != 0 && inputVector.y != 0)
        {
            return currentMovementDirection;
        }

        if(inputVector.x == 0 && inputVector.y == 0)
        {
            return currentMovementDirection;
        }

        return new Vector3(inputVector.x, 0, inputVector.y);
    }

}
