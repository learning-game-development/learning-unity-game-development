using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
  private enum MoveOptions { UpDown, LeftRight }

  [SerializeField]
  private MoveOptions movementOptions;

  [SerializeField]
  private float movementSpeed = 125F;

  Rigidbody2D body2D;

  // Start is called before the first frame update
  void Start()
  {
    body2D = GetComponent<Rigidbody2D>();

    if (body2D == null)
    {
      Debug.LogError("Rigidbody2D required for MovableObject script");
    }

    if (movementOptions == MoveOptions.UpDown) {
      body2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    if (movementOptions == MoveOptions.LeftRight) {
      body2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
  }

  private void OnMouseDown()
  {
    body2D.isKinematic = false;
  }

  private void OnMouseUp()
  {
    body2D.isKinematic = true;
    body2D.velocity = new Vector2(0, 0);
  }

  private void OnMouseDrag()
  {
    // This turns our mouse point into usable 2D coordinates
    Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 shipPosition = transform.position;

    Vector2 directionToMove = new Vector2(0, 0);

    if (movementOptions == MoveOptions.UpDown)
    {
      if (shipPosition.y < touchPoint.y)
      {
        // Need to move up, set the direction to move to be
        // the distance between cursor and ship
        directionToMove.y += touchPoint.y - shipPosition.y;
      }
      else if (shipPosition.y > touchPoint.y)
      {
        directionToMove.y -= shipPosition.y - touchPoint.y;
      }
    }

    if (movementOptions == MoveOptions.LeftRight)
    {
      if (shipPosition.x < touchPoint.x)
      {
        directionToMove.x += touchPoint.x - shipPosition.x;
      }
      else if (shipPosition.x > touchPoint.x)
      {
        directionToMove.x -= shipPosition.x - touchPoint.x;
      }
    }

    body2D.velocity = new Vector2(0, 0);
    body2D.AddForce(directionToMove * movementSpeed, ForceMode2D.Force);
  }

}
