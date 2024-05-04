using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float movespeed = 5f;
    public float Jump_power = 10f;
    
    public float Inputx;//儲存移動數值
    public float Inputy;
    private bool isGrounds;//判斷是否在地板上

    public LayerMask LayerMask;//要判段的layer


    public Transform GroundCheck;//判斷位置
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
     }

    // Update is called once per frame
    void Update()
    {
        //rig.velocity = new Vector2(movespeed * Inputx, rig.velocity.y);//速度*輸入值
        transform.Translate(new Vector2(Inputx*Time.deltaTime*movespeed,Inputy*Time.deltaTime*movespeed));
       
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        
        Inputx = ctx.ReadValue<Vector2>().x;
        Inputy = ctx.ReadValue<Vector2>().y;
        
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        Collider2D isGround = Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(0.9f, 0.5f), CapsuleDirection2D.Horizontal, 0, LayerMask);//判斷的位置                長寬                           方向                                      判斷layer
         

     if (ctx.performed&& isGround )
        {
            if (isGround.gameObject.name == "Square")
            {
                Jump_power = 8f;
            }
            rig.velocity = Vector2.up * Jump_power;
            Jump_power = 5f;
        }

        
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("press shoot button");
        }
    }
   
}
