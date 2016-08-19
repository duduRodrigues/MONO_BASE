using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
using Assets.Scripts.Auxiliar.MonoEnums;

public class Player : MonoBehaviour {

    private float walkingSpeed;
    private float runningSpeed;
    private float jumpForce;

    private DeathCounter _deathCounter;
    private CheckPoint _lastCheckPoint;
    private PlayerController _playerController;

    public bool IsWalking { get; set; }
    public bool IsRunning { get; set; }
    public bool IsJumping { get; set; }
    public bool IsGrounded { get; set; }

    // Use this for initialization
    void Start () {
        walkingSpeed = 3;
        runningSpeed = 5;
        jumpForce = 6;

        _deathCounter = DeathCounter.Instance;
        //_lastCheckPoint = new CheckPoint(this.transform.position, 0);
        _playerController = FindObjectOfType<PlayerController>();

        IsWalking = false;
        IsRunning = false;
        IsJumping = false;
        IsGrounded = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Jump()
    {
        if (!IsJumping)
        {
            Rigidbody2D rbPlayer = this.GetComponent<Rigidbody2D>();
            rbPlayer.velocity = new Vector2(0, jumpForce);

            IsJumping = true;
        }
    }

    public void Walk(float direction)
    {
        transform.Translate(new Vector3(direction * walkingSpeed * Time.deltaTime, 0, 0));
        IsWalking = (direction != 0);
    }

    public void Run(float direction)
    {
        transform.Translate(new Vector3(direction * runningSpeed * Time.deltaTime, 0, 0));
        IsRunning = (direction != 0);
    }

    public void SetCheckpoint(CheckPoint checkPoint)
    {
        if (_lastCheckPoint.index < checkPoint.index)
            _lastCheckPoint = checkPoint;
        
    }
    
    public void Die()
    {
        _playerController.enabled = false;
        _deathCounter.IncreaseDeath();
        new WaitForSeconds(0.5f);
        this.transform.position = _lastCheckPoint.Position;
        _playerController.enabled = true;
    }

    public void ResetDeaths()
    {
        _deathCounter.ResetDeaths();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ETagName.Ground.GetDescription())
        {
            IsJumping = false;
            IsGrounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == ETagName.Ground.GetDescription())
        {
            IsGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == ETagName.Ground.GetDescription())
        {
            IsGrounded = false;
        }
    }
}
