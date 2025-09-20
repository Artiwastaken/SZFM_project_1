
![alt](/Images/UMLClassDiagram2.png)

#### PlantUML Script:
```
@startuml


class MonoBehaviour{
    + void Start()
    + void Update()
}
class GameManager{
    + BiomeManager bm
    + int platformSpeed
    + PlayerController playerC
    + RadioController radioC
    + UIManager uim
    + GameObject[] platformElements
    + bool isGameActive
    + int score
    + int timer
    
    + IEnumerator Timer()
    + IEnumerator ScoreUpdater()
    + void SaveHighScore()
    + void LoadHighScore()
    + void StartGame()
    + void GameOver()
    + void RestartGame()
    + void ResumeGame()
}
class BiomeManager{
    + void PickBiome()
}
class PlayerController{
    + bool onGround
    + RigidBody rb
    + BoxCollider bc
    + GameManager gm
    + Animator animator
    
    + void OnCollisionEnter(Collision collision)
    + void PlayerMovement()
    
}
class SoundEffectController{
    + GameManager gm
    + AudioSource audioSource
    + AudioClip[] clips
    + PlayerController playerC
    + void PlayDeathSound()
    + void PlaySoundEffect()
}
class RadioController{
    + AudioSource audioSource
    + AudioClip[] clips
    + int currentClip
    + UIManager um
    
    + void AdjustVolume()
    + void ChangeClipUp()
    + void ChangeClipDown()
}
class CollisionController{
    + GameManager gm
    + SoundEffectController sc
    + BackGroundManager bm
    + ObstacleGenerator og
    
    + void OnTriggerEnter(Collider other)
}
class BackGroundManager{
    + void SpawnBackGround()
}
class ObstacleGenerator{
    + void SpawnObstacle()
}
class UIManager{
    + TextMeshProUGUI[] uiElementsList
}



GameManager --> BiomeManager
GameManager --> PlayerController
GameManager --> RadioController
SoundEffectController --> GameManager
SoundEffectController --> PlayerController
RadioController --> UIManager
CollisionController --> GameManager
CollisionController --> SoundEffectController
CollisionController --> BackGroundManager
CollisionController --> ObstacleGenerator
MonoBehaviour <|-- GameManager
MonoBehaviour <|-- BiomeManager
MonoBehaviour <|-- PlayerController
MonoBehaviour <|-- SoundEffectController
MonoBehaviour <|-- RadioController
MonoBehaviour <|-- CollisionController
MonoBehaviour <|-- BackGroundManager
MonoBehaviour <|-- ObstacleGenerator
MonoBehaviour <|-- UIManager
@enduml

```

