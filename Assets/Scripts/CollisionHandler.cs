using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

[SerializeField] float delay = 1f;

  void OnCollisionEnter(Collision other) 
  {
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
    //todo sound effect upon crash
    // to do particle effect uppon crash
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", delay);
  }

   void StartSuccessSequence()
  {
    //todo sound effect upon success
    // to do particle effect uppon success
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
