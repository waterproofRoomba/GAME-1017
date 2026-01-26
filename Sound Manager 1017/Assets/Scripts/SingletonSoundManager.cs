using UnityEngine;

public class SingletonSoundManager : MonoBehaviour
{  
    
    
    
    [SerializeField] private AudioSource musicSource, sfxSource;



    private static SingletonSoundManager instance;
    public static SingletonSoundManager Instance

    {

       

        get
        {
            if (instance == null)
            {


                
                    // Check if an instance already exists in the scene
                    instance = FindFirstObjectByType<SingletonSoundManager>();


                    //Create a gamobject in the scene
                    if  (instance == null)
                    {
                    GameObject SingletonSoundManager = new GameObject(nameof(SingletonSoundManager));
                    SingletonSoundManager.AddComponent<SingletonSoundManager>();
                    
                    }
                    
                
                
            }
            return instance;
        }
    }


    private void Awake()
    {
        //If an instance already exists and it's not this, destroy this to enforce singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   
    public void ChangeMusicVolume(float newVolume) 
    {


        musicSource.volume = newVolume;
    }

    
    public void ChangeSFXVolume(float newVolume)
    {
        sfxSource.volume = newVolume;
    }

}

