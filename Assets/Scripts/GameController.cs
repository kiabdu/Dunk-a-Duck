using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    private GameObject _rifle;
    private Transform _rifleTransform;
    private static Vector3 _duckPosition;
    private static bool _isShooting = false;
    public ParticleSystem particles;
    private static bool _duckKilled = false;
    private Animation _rifleAnimation;
    private AudioSource _audioSource;
    private int _score = 0;
    private Text _scoreText;
    
    public void Start()
    {
        _rifle = GameObject.Find("Rifle");
        _rifleTransform = _rifle.transform;
        _rifleAnimation = _rifle.GetComponent<Animation>();
        
        _audioSource = particles.GetComponent<AudioSource>();
        
        _scoreText = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
        _scoreText.transform.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.925f);
    }
    
    public void Update()
    {
        MoveRifle();
        Shoot();
        PlayParticlesAndAudio();

        _scoreText.text = "Score: " + _score;
    }

    private void MoveRifle()
    {
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //fuer Maus-Constraints gewaehlte Werte durch trial and error bestimmt
        
        //solange sich die Maus innerhalb des Spielfensters befindet
        if (currentMousePos.x >= 1.5f && currentMousePos.x <= 10f)
        {
            //Position des Gewaehrs = Mausposition
            _rifleTransform.position = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                _rifleTransform.position.y,
                _rifleTransform.position.z);
        }

        if (currentMousePos.y >= 0.25f && currentMousePos.y <= 2.5f)
        {
            _rifleTransform.position = new Vector3(
                _rifleTransform.position.x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                _rifleTransform.position.z);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isShooting = true;
            _rifleAnimation.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isShooting = false;
        }
    }

    public static bool IsShooting()
    {
        return _isShooting;
    }

    public static void SetDuckPosition(Vector3 position)
    {
        _duckPosition = position;
    }

    public static void DuckKilled(bool killed)
    {
        _duckKilled = killed;
    }

    private void PlayParticlesAndAudio()
    {
        if (_duckKilled)
        {
            particles.transform.position = _duckPosition;
            particles.Play();
            _audioSource.Play();
            _score++;
            _duckKilled = false;
        }
    }
}
