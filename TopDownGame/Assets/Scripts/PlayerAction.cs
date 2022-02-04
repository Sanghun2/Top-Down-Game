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

    //터치패드 변수
    int upValue;
    int downValue;
    int leftValue;
    int rightValue;
    bool upDown;
    bool downDown;
    bool leftDown;
    bool rightDown;
    bool upUp;
    bool downUp;
    bool leftUp;
    bool rightUp;

    [Header("매니저")][Space(15f)]
    [SerializeField] GameManager gameManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //PC & mobile
        h = gameManager.IsAction() ? 0 : Input.GetAxisRaw("Horizontal") + rightValue + leftValue; ;
        v = gameManager.IsAction() ? 0 : Input.GetAxisRaw("Vertical") + upValue + downValue;

        //PC & mobile
        hDown = gameManager.IsAction() ? false : Input.GetButton("Horizontal") || rightDown || leftDown;
        vDown = gameManager.IsAction() ? false : Input.GetButton("Vertical") || upDown || downDown;
        hUp = gameManager.IsAction() ? false : Input.GetButtonUp("Horizontal") || rightUp || leftUp;
        vUp = gameManager.IsAction() ? false : Input.GetButtonUp("Vertical") || upUp || downUp;

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

        //scan object & action
        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            gameManager.Action(scanObject);
        }

        //mobile var init
        upDown = false;
        downDown = false;
        leftDown = false;
        rightDown = false;
        upUp = false;
        downUp = false;
        leftUp = false;
        rightUp = false;
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

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                upValue = 1;
                upDown = true;
                break;
            case "D":
                downValue = -1;
                downDown = true;
                break;
            case "L":
                leftValue = -1;
                leftDown = true;
                break;
            case "R":
                rightValue = 1;
                rightDown = true;
                break;
            case "A":
                if (scanObject != null)
                {
                    gameManager.Action(scanObject);
                }
                break;
            case "C":
                gameManager.SubMenuActive();
                break;
            default:
                break;
        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                upValue = 0;
                upDown = true;
                break;
            case "D":
                downValue = 0;
                downDown = true;
                break;
            case "L":
                leftValue = 0;
                leftDown = true;
                break;
            case "R":
                rightValue = 0;
                rightDown = true;
                break;
            default:
                break;
        }
    }
}
