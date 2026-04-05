using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float hp;

    public bool jumping;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.leftArrowKey.wasPressedThisFrame || Keyboard.aKey.wasPressedThisFrame)
        {
            GetComponent<RigidBody2d>().mass
        }
        
        if (Keyboard.rightArrowKey.wasPressedThisFrame || Keyboard.dKey.wasPressedThisFrame)
        {
            
        }

        if (Keyboard.spaceKey.wasPressedThisFrame && !jumping)
        {
            jumping == true;
        }
    }
    
    public void onCollis
}
