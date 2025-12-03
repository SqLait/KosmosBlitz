# **KosmosBlitz**

KosmosBlitz is a 2D endless shooter game developed using **MonoGame**.
The goal is simple: **destroy 40 ships to progress to the next, more difficult stage**.
The game continues indefinitely until the player is hit by an enemy.

Anyone can play the game—there is no targeted audience.

---

## **Building & Running the Project**

### **Requirements**

To build the project from source you need:

* **.NET SDK** (dotnet CLI)
* **git**

Use your OS package manager to install them easily.

On **Windows**, using the *Scoop* package manager is recommended:

```sh
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
Invoke-RestMethod -Uri https://get.scoop.sh | Invoke-Expression

scoop install dotnet-sdk git
```

### **Clone the Repository**

```sh
git clone https://github.com/SqLait/KosmosBlitz.git
cd KosmosBlitz
```

### **Build & Run**

```sh
dotnet build
dotnet run
```

All assets and data required to run the game are included in the repository.
No additional setup is needed.

---

## **Project Structure**

### **Source Code Layout**

Please follow the existing structure when contributing or adding new code:

```
SpaceShooter/      -- root of the project
|-- BaseClasses/   -- base classes and data structures
|-- Debug/         -- debugging utilities
|-- GameManager/   -- scripts that manage game state and logic
|-- GameObjects/   -- gameplay objects (player, enemies, bullets, etc.)
|-- Interfaces/    -- shared interfaces
|-- Misc/          -- scripts not fitting other categories
|-- Game1.cs       -- main game loop logic
|-- Program.cs     -- C# entry point (DO NOT EDIT)
```

### **Content & Assets**

All visual and audio content is located in the `Content/` directory.
These assets are required for the game to run correctly—please avoid altering or removing them as it may break the build or gameplay.

---

## **Design & Architectural Choices**

* The game is written in C# using the **MonoGame** framework.
* The project is structured in a modular way, separating concerns:

  * **GameObjects** contains all in-game entities.
  * **GameManager** handles core game state and progression.
  * **BaseClasses** helps maintain consistent behaviors.
* The `Game1.cs` class acts as the main MonoGame loop, managing update and draw logic.
* This structure is chosen for maintainability, clarity, and easier extension of gameplay features.

---

## **Security Considerations**

Although this is a local, offline game project, basic security practices are followed:

* No secrets, tokens, or private keys are stored in the repository.
* The game does not collect or transmit user data.
* External dependencies are limited to trusted sources (.NET SDK & MonoGame).
* The repository avoids execution of unsafe external scripts beyond normal build tools.

---

## **Repository & Version Control**

### **Branching Strategy**

* **main**: stable branch for releases
* Feature branches should be created for new additions or changes:

  * Example: `feature/new-enemy-ai`

### **Commit Guidelines**

Use clear, descriptive commit messages.
Optionally, conventional commit style can be used:

* `feat:` new feature
* `fix:` bug fix
* `refactor:` code improvements
* `docs:` documentation changes

### **Releases & Tags**

Releases will be tagged using semantic versioning, e.g.:

```
v1.0.0
v1.1.0
```

A changelog can be maintained in the future if the project expands.

---

## **Playing the Game**

Once launched, control your ship to avoid enemies and destroy them.
Every **40 ships** destroyed increases the difficulty.

The game ends when your ship is hit.
