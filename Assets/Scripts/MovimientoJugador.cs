using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fuerzaGolpe;
    [SerializeField] GameObject testPanel;
    [SerializeField] GameObject testPanel1;
    [SerializeField] GameObject testPanel2;
    [SerializeField] GameObject testPanel3;
    [SerializeField] GameObject testPanel4;
    [SerializeField] GameObject testPanel5;
    [SerializeField] GameObject testPanel6;
    [SerializeField] GameObject testPanel7;

    bool puedeMoverse = true;

    Rigidbody2D rb;
    Animator animator;

    bool lookRight = true;

    bool isMoving = false;
    bool wasMoving = false;

    bool isFacingDownwards = false;
    bool wasFacingDownwards = false;

    bool isFacingUpwards = false;
    bool wasFacingUpwards = false;

    bool isWalkSide = false;
    bool wasWalkSide = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
    }


    void ProcesarMovimiento()
    {
        /*
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movement.y += 1;
        if (Input.GetKey(KeyCode.D))
            movement.x += 1;
        if (Input.GetKey(KeyCode.S))
            movement.y -= 1;
        if (Input.GetKey(KeyCode.A))
            movement.x -= 1;
        */

        if (puedeMoverse == false)
            return;


        //float inputMovementY = Input.GetAxis("Horizontal");
        //float inputMovementX = Input.GetAxis("Vertical");
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
            movement.x += 1;

        if (Input.GetKey(KeyCode.A))
            movement.x -= 1;

        if (movement.x != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
            animator.SetBool("isBackRunning", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= 1;
            animator.SetBool("isFrontRunning", true);
        }

        rb.velocity = new Vector3(movement.y * speed, rb.velocity.y);
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.x);

        if (Input.GetKey(KeyCode.F))
        {
            testPanel.SetActive(false);
            testPanel1.SetActive(false);
            testPanel2.SetActive(false);
            testPanel3.SetActive(false);
            testPanel4.SetActive(false);
            testPanel5.SetActive(false);
            testPanel6.SetActive(false);
            testPanel7.SetActive(false);
        }


        isMoving = movement != Vector2.zero;
        if (wasMoving && !isMoving)
        {
            animator.SetTrigger("StoppedMoving");
            print("now stopped");
        }
        wasMoving = isMoving;

        isFacingDownwards = movement.y < 0;
        if (!wasFacingDownwards && isFacingDownwards)
        {
            animator.SetTrigger("NowFacingDownwards");
            animator.SetBool("isBack", false);
            print("now moving downwards");
        }
        wasFacingDownwards = isFacingDownwards;

        isFacingUpwards = movement.y > 0;
        if (!wasFacingUpwards && isFacingUpwards)
        {
            animator.SetTrigger("NowFacingUpwards");
            animator.SetBool("isBack", true);
            print("now moving upwards");
        }
        wasFacingUpwards = isFacingUpwards;

        isWalkSide = movement.x < 0;
        if (!wasWalkSide && isWalkSide)
        {
            animator.SetTrigger("isRunningHorizontal");
        }

        if (lookRight == true && movement.x < 0 || lookRight == false && movement.x > 0)
        {
            lookRight = !lookRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    public void AplicarGolpeEnemigo()
    {
        puedeMoverse = false;

        //Vector2 direccionGolpe = transform.position - contactPoint;
        Vector2 direccionGolpe;

        if (rb.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-100, 0);
        }
        else if(rb.velocity.y > 0)
        {
            direccionGolpe = new Vector2(0, -100);
        }
        else if(rb.velocity.x < 0)
        {
            direccionGolpe = new Vector2(100, 0);
        }
        else if(rb.velocity.y < 0)
        {
            direccionGolpe = new Vector2(0, 100);
        }
        else
        {
            direccionGolpe = new Vector2(0, 0);
        }

        rb.AddForce(direccionGolpe * fuerzaGolpe);

        StartCoroutine(EsperarYActivarMovimiento());
    }


    IEnumerator EsperarYActivarMovimiento()
    {
        yield return new WaitForSeconds(0.3f);

        puedeMoverse = true;
    }

   

}
