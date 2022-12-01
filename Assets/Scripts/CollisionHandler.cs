using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

  [SerializeField] float delay = 1f;
  [SerializeField] AudioClip crashEngine;
  [SerializeField] AudioClip successEngine;
  [SerializeField] ParticleSystem crashParticles;
  [SerializeField] ParticleSystem successParticles;

  AudioSource audioSource;
  

  bool isTrasiting = false;
  bool CollisionDisabled = false;

  void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }
  void Update() 
  {
    RespondToDebugKeys();
  }

  void RespondToDebugKeys()
  {
    if(Input.GetKeyDown(KeyCode.L))
    {
      LoadNextLevel();
    }
    if(Input.GetKeyDown(KeyCode.C))
    {
      CollisionDisabled = !CollisionDisabled; //toggle colision
    }


  }

  void OnCollisionEnter(Collision other) 
  {
    if(isTrasiting || CollisionDisabled){ return;}
    switch (other.gameObject.tag)
    {
        case "Friendly":
          Debug.Log("Friendly");
          break;
        case "Finish":
            StartSuccessSequence();
            break;
        
        default:
            StartCrashSequence();
            break;
    }
  }

  void StartCrashSequence()
  {
    isTrasiting = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crashEngine);
    crashParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", delay);
  }

   void StartSuccessSequence()
  {
    isTrasiting = true;
    audioSource.Stop();
    audioSource.PlayOneShot(successEngine);
    successParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", delay);
  }
  void LoadNextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex +1 ;
    if ( nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
        nextSceneIndex = 0;
    }
    
    SceneManager.LoadScene(nextSceneIndex);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
