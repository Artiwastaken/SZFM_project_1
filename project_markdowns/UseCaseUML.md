

![alt text](/Images/usecase.png)
 
@startuml
top to bottom direction
actor Player as u

package Game {

package Gameplay {
usecase "Moving the character" as UC1
usecase "Avoid obstacles" as UC7
usecase "Scoring" as UC8
usecase "Set high score" as UC9
}

package UI {
usecase "Choosing biome" as UC2
usecase "Pausing the game" as UC4
usecase "Choosing the theme song" as UC5
usecase "Restart the game" as UC6
}



}
u --> UC1
u --> UC2
u --> UC4
u --> UC5
u --> UC6
u --> UC7
u --> UC8
u --> UC9

@enduml