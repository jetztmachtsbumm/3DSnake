using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    private Vector3 currentMovementDirection;

    private void Awake()
    {
        currentMovementDirection = new Vector3(1, 0, 0);
    }

    private void Update()
    {
        currentMovementDirection = SnakeControlls.Instance.GetMovementDirection(currentMovementDirection);

        HandleMovement();
        HandleRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Apple"))
        {
            GameManager.Instance.IncreaseScore();
            Destroy(other.gameObject);
        }
    }

    private void HandleMovement()
    {
        float movementSpeed = 5f;
        transform.localPosition += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void HandleRotation()
    {
        float rotationSpeed = 10f;
        if (currentMovementDirection.x != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90 * currentMovementDirection.x, 0), rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, currentMovementDirection.z == 1 ? 0 : 180, 0), rotationSpeed * Time.deltaTime);
        }
    }

}
