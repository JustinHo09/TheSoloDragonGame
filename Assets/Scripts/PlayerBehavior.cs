using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public float hp;
    public float upAmount;
    public float maxWeight;

    public GameObject gameOver;
    public Slider weight;
    public TMP_Text score;
    public int points;

    public bool jumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weight.maxValue = maxWeight;
        weight.minValue = 1.0f;
        weight.value = GetComponent<Rigidbody2D>().mass;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + 1.0f);
        weight.transform.position = newPos;
        if (hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("dies");
            gameOver.SetActive(true);
            this.enabled = false;
        }
        
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (GetComponent<Rigidbody2D>().mass > 1.0f) {
                GetComponent<Rigidbody2D>().mass -= 1.0f;
            }else{
                GetComponent<Rigidbody2D>().mass = 1.0f;
            }
            weight.value = GetComponent<Rigidbody2D>().mass;
        }
        
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (GetComponent<Rigidbody2D>().mass < maxWeight)
            {
                GetComponent<Rigidbody2D>().mass += 1.0f;
            }else
            {
                GetComponent<Rigidbody2D>().mass = maxWeight;
            }
            weight.value = GetComponent<Rigidbody2D>().mass;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !jumping)
        {
            jumping = true;
            GetComponent<Animator>().SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForceY(upAmount, ForceMode2D.Impulse);
        }

        if (Keyboard.current.shiftKey.isPressed && jumping)
        {
            GetComponent<Rigidbody2D>().gravityScale += 1.0f;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("obstacle")) {
            GetComponent<Animator>().SetTrigger("hit");
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Border")
        {
            jumping = false;
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            GetComponent<Animator>().SetTrigger("landed");
        }
    }

    public void OnCollusionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Border")
        {
            jumping = true;
        }
    }

    public void updateScore(int newPoints)
    {
        points += newPoints;
        score.SetText("SCORE: " + points);
    }
}
