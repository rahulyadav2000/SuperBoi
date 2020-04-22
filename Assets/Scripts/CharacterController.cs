using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterController : MonoBehaviour 
{
    
    Rigidbody2D rigidbody;
    Animator Animator;
    Transform tran;
    public  bool isAttack;

    private float h = 0;
    private float v = 0;

    public float MoveSpeed = 30.7f;

    public SpriteRenderer[] SpriteGroup;

    public bool OnceAttack = false;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        rigidbody = this.GetComponent<Rigidbody2D>();
        Animator = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponent<Animator>();
        tran = this.transform;
        SpriteGroup = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponentsInChildren<SpriteRenderer>(true);

       // Invoke("Attackreset", 0.36f);
    }
	
	// Update is called once per frame
	void Update () {

        

        spriteOrder_Controller();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnceAttack = false;
            //Debug.Log("Lclick");
            Animator.SetBool("Attack",true);

            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            Animator.SetBool("Attack", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnceAttack = false;
           // Debug.Log("Rclick");
            Animator.SetBool("Attack2",true);

            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            Animator.SetBool("Attack2", false);
        }

        Move_Fuc();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Animator.SetFloat("MoveSpeed", Mathf.Abs(h )+Mathf.Abs (v));

    }

    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            
            for (int i = 0; i < SpriteGroup.Length; i++)
            {
                SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;
            }

            Update_Tic = 0;
        }
    }

    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //  Debug.Log("Left");
            rigidbody.AddForce(Vector2.left * MoveSpeed );
            if (FacingRight)
                Filp();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //  Debug.Log("Right");
            rigidbody.AddForce(Vector2.right * MoveSpeed);
            if (!FacingRight)
                Filp();
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Debug.Log("up");
            rigidbody.AddForce(Vector2.up * MoveSpeed * 2);
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log("Down");
            rigidbody.AddForce(Vector2.down * MoveSpeed * 2);   
        }
    }
 
    bool Attack = false;
    bool FacingRight = true;

    void Filp()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        tran.localScale = theScale;
    }

     void attackReset()
     {
        Animator.SetBool("Attack", false);
        isAttack = false;
        Debug.Log("Attack");
     }
}
