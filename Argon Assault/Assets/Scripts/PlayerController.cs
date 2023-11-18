using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 2f;
    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        float xOffset = (horizontalMovement * movementSpeed) * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos,-xRange, xRange);

        float yOffset = (verticalMovement * movementSpeed) * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos,-yRange, yRange);

        transform.localPosition = new Vector3(
        newXPos, 
        newYPos,
        transform.localPosition.z);
    }
}
