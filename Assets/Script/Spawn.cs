using System;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public RectTransform PlayerImage; // Assuming this is the image of the player
    public Transform SpawnPoint;

    public float moveSpeed = 50f; // Adjust this to change movement speed

    public GameObject Crs;
    public GameObject show;
    public GameObject nxt;
    public GameObject ActEff;
    public GameObject deact;
    public GameObject deactPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a tag "Image"
        if (collision.gameObject.CompareTag("Col"))
        {
            // Disable the player object
            RelocateObject();
            Debug.Log("Collision with object tagged Col detected");
        }
        if (collision.gameObject.CompareTag("Fn1"))
        {
            ActEff.SetActive(true);
            Crs.SetActive(true);
            show.SetActive(true);
            nxt.SetActive(true);
            deact.SetActive(false);
            deactPlayer.SetActive(false);
        }
    }

    private void RelocateObject()
    {
        PlayerImage.position = SpawnPoint.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        PlayerImage.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
