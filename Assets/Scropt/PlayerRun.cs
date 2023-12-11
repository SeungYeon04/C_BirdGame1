using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerRun : MonoBehaviour
{

    [SerializeField] private SpriteRenderer PlayerSprite;
    private float movement;

    Vector3 playerPosition;


    public float moveSpeed { get; private set; }

    void Update()
    {
        Movement();
        //매 프레임 호출되는 Update()문에서 동시에
        //Movement()메소드가 호출됨.

    }

    void Movement()
    {
        if(Application.platform == RuntimePlatform.Android) //안드로이드일 경우 
        {
            if((Input.GetTouch(0).phase == TouchPhase.Stationary)
                || (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                UnityEngine.Touch touch = Input.GetTouch(0);

                if(touch.position.x <= 90f)
                {
                    movement = -1;
                    PlayerSprite.flipX = false;
                }
                else if(touch.position.x > 90f)
                {
                    movement = 1;
                    PlayerSprite.flipX = true;
                }
            }
            //Sprite.FlipX = (movement == -1);

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                movement = 0;
            }

            transform.RotateAround(Vector3.zero, Vector3.back,
                movement * Time.fixedDeltaTime * moveSpeed);
        }
        else //if(Application.platform == RuntimePlatform.WindowsPlayer) //윈도우플레이어일 경우 
        {
            playerPosition = this.transform.position;

            // w ->앞
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0.0f, 0.011f, 0.0f);
            }
            // s->뒤
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0.0f, 0.011f, 0.0f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(0.011f, 0.0f, 0.0f);
                PlayerSprite.flipX = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(0.011f, 0.0f, 0.0f);
                PlayerSprite.flipX = true;
            }


            
        }

    }  
}
