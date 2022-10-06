using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpForce;

    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            //The ball hits the safe plane
            // Debug.Log("The ball is safe");
            audioManager.Play("bounce");
        }
        else if (materialName == "Unsafe (Instance)")
        {
            //The ball htis the unsafe plane
            GameManager.gameOver = true;
            audioManager.Play("game over");

        } else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            //The hits the last ring
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
