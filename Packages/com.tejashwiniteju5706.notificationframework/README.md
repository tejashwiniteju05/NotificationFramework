# Notification Framework

A reusable and customizable notification framework developed in Unity.

This framework allows developers to display beautiful runtime notifications with different notification types, animations, queue management modes, notification history, and progress notifications. The framework is designed to be reusable by importing it into any Unity project.

# Features

## Notification Types

- Success
- Error
- Warning
- Information
- Loading
- Progress

## Queue Modes

The framework supports two queue modes.

### FIFO (First In First Out)

Notifications are displayed in the order they are received.

### Priority Queue

Notifications are sorted according to their priority before displaying.

Priority Levels:

- Critical
- High
- Medium
- Low

The queue mode can be selected from the Notification Settings ScriptableObject.

## Supported Positions

Notifications can appear at:

- Top Left
- Top Center
- Top Right
- Bottom Left
- Bottom Center
- Bottom Right

## Animation Styles

The framework provides three animation styles.

- Fade
- Slide
- Scale

Animation style can be changed from Notification Settings.

## Notification History

The framework maintains a notification history panel.

Features:

- Open History
- Close History
- Clear History

Loading and Progress notifications are excluded from the history panel.

## Progress Notification

The framework supports progress notifications.

Features:

- Progress Slider
- Runtime Progress Update
- Manual Close after Completion

## ScriptableObject Settings

The framework uses a ScriptableObject for customization.

Developers can change:

- Success Color
- Error Color
- Warning Color
- Information Color
- Loading Color
- Progress Color

Icons

- Success Icon
- Error Icon
- Warning Icon
- Information Icon
- Progress Icon

Fonts

- Title Font
- Message Font

Animation

- Fade
- Slide
- Scale

Queue Mode

- FIFO
- Priority

Default Notification Duration

# Folder Structure

```
Notification Framework
|
|- Editor
|
|- Runtime
|   |- Assets
|   |   |- Animators
|   |   |- Fonts
|   |   |- Prefab
|   |   |- ScriptableObject
|   |   L Sprites
|   |
|   |-Documentation
|   |- Data
|   |- Manager
|   |- Settings
|   L UI
|
|- Samples
|
|- package.json
|
L README.md
```

# Main Classes

### Notification

Public API used by developers.

Methods:

```csharp
Notification.ShowSuccess("Profile Saved");

Notification.ShowError("Network Error");

Notification.ShowWarning("Low Battery");

Notification.ShowInformation("New Update");

Notification.ShowLoading("Downloading...");

Notification.ShowProgress();

Notification.HideCurrent();

Notification.ClearAll();
```

### NotificationManager

Responsible for:

- Managing Queue
- Showing Notifications
- Queue Mode (FIFO/Priority)
- Notification Position
- Progress Updates
- Notification History

### NotificationSettings

Stores framework settings using ScriptableObject.

Includes:

- Colors
- Icons
- Fonts
- Queue Mode
- Animation Style
- Default Duration

### NotificationData

Stores notification information.

Contains:

- Title
- Message
- Type
- Duration
- Sticky
- Priority
- Position
- Time

# Prefabs

The framework includes the following prefabs.

- NotificationPanel
- NotificationManager
- HistoryPanel
- HistoryItem

# Demo Scene

Demo Scene Name: Notification

The demo scene demonstrates:

- Success Notification
- Error Notification
- Warning Notification
- Information Notification
- Loading Notification
- Progress Notification
- FIFO Queue
- Priority Queue
- Notification History
- Clear Queue

# Installation

1. Import the Notification Framework package into your Unity project.

2. Add the NotificationManager prefab to the scene.

3. Assign the required references:

- Notification Panel
- Notification Settings
- Position Transforms
- History Panel
- History Item Prefab

4. Press Play.

The framework is ready to use.

# Requirements

Unity Version
Unity 6
TextMeshPro Package
UGUI Package

# Bonus Features Implemented

✔ Progress Bar

✔ Notification History

✔ Priority Queue

# Future Improvements

Possible future enhancements include:

- Custom Notification Templates
- Sound Effects
- Notification Stacking
- Theme Support
- Save Notification History
- Notification Count
- Notification Filtering

# Package Name

```
com.notificationframework
``

