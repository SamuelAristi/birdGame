using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    private Boolean gameOverSoundPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && birdIsAlive )
        {
            myrigidbody.velocity = Vector2.up * flapStrength;
            soundController.Instance.startSound(jumpSound);
        }
        if(transform.position.y < -17 || transform.position.y > 15) {
            if (!gameOverSoundPlay)
            {
                logic.gameOver();
                birdIsAlive = false;
                soundController.Instance.startSound(gameOverSound);
                gameOverSoundPlay=true; 
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameOverSoundPlay)
        {
            logic.gameOver();
            birdIsAlive = false;
            soundController.Instance.startSound(gameOverSound);
            gameOverSoundPlay = true; 
        }
    }
}
