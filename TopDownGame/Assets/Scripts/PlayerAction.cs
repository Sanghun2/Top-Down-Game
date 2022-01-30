using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    float h;
    float v;
    bool isHorizonMove;
    bool hDown;
    bool vDown;
    bool hUp;
    bool vUp;
    Vector3 dirVec;
    GameObject scanObject;

    Rigidbody2D rigid;
    Animator anim;

    [SerializeField] GameManager gameManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        h = gameManager.IsAction() ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.IsAction() ? 0 : Input.GetAxisRaw("Vertical");

        hDown = gameManager.IsAction() ? false : Input.GetButton("Horizontal");
        vDown = gameManager.IsAction() ? false : Input.GetButton("Vertical");
        hUp = gameManager.IsAction() ? false : Input.GetButtonUp("Horizontal");
        vUp = gameManager.IsAction() ? false : Input.GetButtonUp("Vertical");

        //check horizontal move
        if (hDown)
        {
            isHorizonMove = true;
        }
        else if (vDown)
        {
            isHorizonMove = false;
        }
        else if (vUp || hUp)
        {
            isHorizonMove = h != 0;
        }

        //animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //see direction
        if (vDown && v == 1)
        {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            gameManager.Action(scanObject);
        }
    }

    void FixedUpdate()
    {
        //move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //ray
        Debug.DrawRay(rigid.position, dirVec*0.7f, Color.green);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }
}