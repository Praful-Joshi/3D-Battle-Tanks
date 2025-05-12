# 3D Battle Tanks
<p align="center">
  <img src="preview.gif" alt="Gameplay Preview" />
</p>
A 3D tank combat game built with Unity, featuring player-controlled tanks, enemy AI, and object-oriented architecture.

## ✨ Project Overview

3D Battle Tanks is a tank combat simulation where players control a tank in a 3D environment, battling against AI-controlled enemy tanks. The game employs a Model-View-Controller (MVC) pattern along with service layers to create a modular, maintainable codebase.

## 🧱 Setup and Configuration

### Requirements
- Unity 2019.4 or higher
- Basic understanding of Unity's component system

### Getting Started
1. Clone the repository
2. Open the project in Unity
3. Open the game scene
5. Press Play to test the game

## 🎨 Architecture & Design Patterns

### MVC Pattern Implementation
The game implements the Model-View-Controller (MVC) architectural pattern:
- **Model**: Data classes (TankModel, EnemyModel) that store game object properties
- **View**: Visual representation classes (TankView) that handle rendering
- **Controller**: Logic classes (TankController, EnemyController) that process input and update models

### Service Layer Pattern
Service classes (TankService, EnemyService) manage the creation and coordination of models and controllers:
- Instantiate tank models and link them to controllers
- Manage game state and provide access to shared resources
- Handle lifecycle management of game entities

### Singleton Pattern
The `GenericSingleton<T>` implementation ensures only one instance of critical manager classes exists:
- Prevents duplicate instances of services
- Provides global access to managers
- Handles automatic DontDestroyOnLoad for persistent objects

### Object Pooling
An object pool implementation for bullets to optimize performance:
- Reuses bullet objects instead of instantiating/destroying them
- Reduces garbage collection overhead
- Improves performance during frequent shooting events

## ⚒️ Core Systems

### Tank Movement System
- Physics-based movement using Rigidbody
- Separated input handling from movement logic
- Configurable movement and turning speeds via ScriptableObjects

### Tank Combat System
- Charging-based shooting mechanic with variable force
- Bullet physics with explosion radius damage
- Health and damage system with visual feedback

### Enemy AI System
- State-based AI with patrolling, chasing, and attacking behaviors
- NavMesh-based pathfinding for intelligent enemy movement
- Waypoint system for patrol routes

### Camera Control System
- Dynamic camera that follows targets
- Automatic zooming based on target positions
- Smooth damping for camera movements

## 📒 Data Management

### ScriptableObjects
Game entities are configured through ScriptableObjects:
- TankScriptableObject: Defines player tank properties
- EnemySO: Defines enemy tank properties
- Properties include health, damage, speed, audio clips, etc.

### Event System
The game uses a simple event system for communication between components:
- Example: `Bullet.attackedEnemy` event for notifying when an enemy is hit

## 🎮 Gameplay Elements

### Player Controls
- WASD/Arrow keys for tank movement
- Mouse for aiming and shooting
- Charging mechanic for variable shot power

### Health System
- Visual health sliders with color gradient
- Damage calculation based on distance from explosion
- Death effects with particles and audio

### Audio System
- Event-based audio triggers
- Different sound effects for movement, shooting, and explosions
- Audio pitch variations for more natural sound

## ⚛️ Technical Implementation Details

### Physics Implementation
- Rigidbody-based movement for realistic physics
- Collision detection for bullet impacts
- Explosion force applied to affected objects

### Optimization Techniques
- Object pooling for frequently created/destroyed objects
- Efficient state management for AI
- Culling of inactive game objects

### Code Structure
The codebase is organized into logical folders:
- **Player Tank**: Player-related scripts
- **Enemy Tank**: Enemy AI and controller scripts
- **Bullet**: Projectile behavior and damage
- **Camera**: Camera control and following logic
- **Object Pool**: Resource management
- **Manager**: Game state coordination
- **Singleton**: Pattern implementation
- **UI**: User interface elements

## 🗓️ Future Development

Potential areas for expansion and improvement:
- Multiplayer support
- More enemy types with unique behaviors
- Terrain destruction system
- Power-up system
- Level progression

## Development Notes

### Code Conventions
- PascalCase for class names and public methods
- camelCase for variables and private methods
- Namespace organization for larger modules
- MonoBehaviour for Unity-specific behavior
- Plain C# classes for data and service layers

### Design Considerations
- Separation of concerns between models, views, and controllers
- Minimal dependencies between components
- ScriptableObjects for configuration without code changes
- Event-based communication to reduce tight coupling

---

## Contributors
- Praful Joshi

## License
This project is licensed under the MIT License – feel free to modify and build upon it after making a fork.
