using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 150.0f;
    private AudioSource audioSource;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.PADDLE))
        {
            CameraShake.instance.Shake(0.08f, 0.05f);
            AudioManager.instance.Play(SoundName.HIT_PADDLE, true);        
        }
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
    }
    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.2f ) : Random.Range(0.2f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }
    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

   
}
