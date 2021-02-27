using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(GroundChecker))]


public class Player : MonoBehaviour
{
    public float Health = 50;
    public float Fructs = 0;
    public float Speed;
    public float JumpForce;
    public List<TreasureData> Inventory = new List<TreasureData>();
    public TMP_Text HealthText;
    public TMP_Text FructsText;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CheckGround())
        {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        HealthText.text = Health.ToString();
    }

    public void TakeFructs(float amount)
    {
        Fructs += amount;
        FructsText.text = Fructs.ToString();
    }

    private void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction < 0)
        {
            _animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction > 0)
        {
            _animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _animator.SetBool("IsWalk", false);
        }

        _rigidbody.velocity = new Vector2(direction * Speed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CheckGround())
        {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Chest chest = collision.gameObject.GetComponent<Chest>();
                chest.Open();
            } 
        }

        else if (collision.gameObject.CompareTag("Fructs"))
        {
            Fructs fructs = collision.gameObject.GetComponent<Fructs>();
            fructs.Open();
           
        }

        else if (collision.gameObject.CompareTag("Treasure"))
        { 
                Treasure treasure = collision.gameObject.GetComponent<Treasure>();
                Inventory.Add(treasure.Take());
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Saw")
        {
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Fire")
        {
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Spikes")
        {
            SceneManager.LoadScene(1);
        }

    }

}


