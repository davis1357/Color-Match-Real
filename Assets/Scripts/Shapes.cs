using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    private Color thisColor;
    private Color[] colors = { Color.red, Color.green, Color.yellow, Color.blue };
    private AudioSource audioSource;

    [SerializeField] AudioClip pickUp;
    [SerializeField] AudioClip drop;
    [SerializeField] AudioClip wrongColor;
    [SerializeField] AudioClip destroyed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int num = Random.Range(0, 4);
        thisColor = colors[num];
        GetComponent<SpriteRenderer>().color = thisColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Grab();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Drop();
        }
    }

    private void Drop()
    {
        audioSource.PlayOneShot(drop);
    }

    private void Grab()
    {
        if(Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(pickUp);
        Vector2 screenNewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = screenNewPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Circle")
        {
            Color otherColor = collision.GetComponent<SpriteRenderer>().color;
            if (otherColor == thisColor)
            {
                FindObjectOfType<Overlay>().RaiseScore();
                AudioSource.PlayClipAtPoint(destroyed, Camera.main.transform.position);
                Destroy(this.gameObject);
            }
            else
            {
                FindObjectOfType<Overlay>().LoseLife();
                AudioSource.PlayClipAtPoint(wrongColor, Camera.main.transform.position);
                Destroy(this.gameObject);
                //TODO: health reduction
            }
        }
    }
}
