using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwordMan : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    BoxCollider2D col2D;

    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;
    public int moveSpeed;
    public float jumpPower = 40;
    bool inputJump = false;
    bool inputRight = false;
    bool inputLeft = false;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col2D = GetComponent<BoxCollider2D>();

        moveSpeed = 10;
        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2D.bounds.center, col2D.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            inputRight = true;
            animator.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            inputLeft = true;
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if (Input.GetKey(KeyCode.A) &&
            !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }

        if (raycastHit.collider != null)
            animator.SetBool("jumping", false);
        else animator.SetBool("jumping", true);

        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("jumping"))
        {
            inputJump = true;
        }
    }
    private void FixedUpdate()
    {
        if (inputRight)
        {
            inputRight = false;
            rigid2D.AddForce(Vector2.right * moveSpeed);
        }
        if (inputLeft)
        {
            inputLeft = false;
            rigid2D.AddForce(Vector2.left * moveSpeed);
        }
        if (inputJump)
        {
            inputJump = false;
            rigid2D.AddForce(Vector2.up * jumpPower);
        }
        if (rigid2D.velocity.x >= 2.5f) rigid2D.velocity = new Vector2(2.5f, rigid2D.velocity.y);
        else if (rigid2D.velocity.x <= -2.5f) rigid2D.velocity = new Vector2(-2.5f, rigid2D.velocity.y);
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;
    }
}
