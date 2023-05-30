# XApps
High usage Extension framework used for multi-purpose applications, with many utility classes for ease of programming

# How to use it
Xapps is essentially an abstracted layer of a basic WinForms application, allowing you to create applications with dynamic graphics with ease. It also contains other Modules that take standard processes and cut down the programmer workload. This will be explained in further detail later.

The main classes you interact are contained in src/Base. As a user of the .dll, you will be interacting with:

**-XApp**

**-XBase**

**-XSession**

you will also be using src/Graphics/XWindow frequently. This will be explained in more detail later on.

# Live Demo (Recommended to watch)

Building a double pendulum using XApps - https://youtu.be/EI0OBZ-imqY

# XApp

XApp is the class that acts as the entry point for the programmer to enter the thread. From this class you can interact with user interactions with your program. This includes mouse and keyboard inputs. You override the relevant methods and handle the logic yourself in a more straight forward way.

# XBase

XBase is the class you should be interacting with the most. It acts as a low level representation of an object in your program. This could be a renderer, a physics object etc. Anything you want to be able to run code from should inherit XBase. XApp contains an instance of XSession, which handles the management and execution of the XBase instances it contains. This will make more sense in the example later on.

# XSession

Through XSession, you have control over the management of the objects in your program. Armed with acess to its methods along with pointers to the individual XBase instances, you have full control over what is executed in your program.

# Example implementation

I believe XApps is much easier to learn by diving straight in. Follow these steps to create your first XApp Application.

1) Install the .dll provided as a file in the project.
2) Create a WinForms application in any language ( all future examples will be in Visual Basic.NET )
3) After the WinForms solution has been created. Create a class that inherits the XApp class. The below example is named "Program"

```vb
Imports XApps

Public Class Program
    Inherits XApp
  
    Sub New(FormIn As Form)
    
        MyBase.New(FormIn)

    End Sub
    
End Class
```

We Inherit XApp, create a constructor with a parameter of a Form, and pass the form into the superclass' constructor.

4) Replace the code of the main form with the below code.

```vb
Public Class Form1
    Private Program_ As Program
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Program_ = New Program(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Program_.Run()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Me.Program_.Halt()
    End Sub
End Class
```

Your program is now in a runnable state. You will see no immediate changes, but XApps is now running. We will now add an object to our program. It will be self managed, and self rendering.

5) Create the below class and copy and paste the code.

```vb
Imports XApps
Public Class TimeDisplay
    Inherits XBase
    Sub New()
        Me.SetDrawStatus(True)
        ' // setting this flag to be true means the Draw() method will run every session tick

        ' // There are also flags for Update() and also a .SetDisposeStatus(res) which will safely dispose of the class in runtime.
    End Sub
    Public Overrides Sub Update(Session As XSession)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)

        g.DrawString(DateTime.Now.ToString, SystemFonts.StatusFont, Brushes.Black, 10, 10)

    End Sub
End Class
```

Depending on the Status of Update,Draw and Dispose the following methods will be run on the next tick of the session. In the above example, We are telling the Session to run the draw method on every game tick. Now we can add this class to our program.

Going back to the Program class, populate the constructor with the following code:


```vb
Imports XApps

Public Class Program
    Inherits XApp
  
    Sub New(FormIn As Form)
    
        MyBase.New(FormIn)

        Me.Session.SetSpeed(60) ' // Sets the framerate of the application to the value passed as a param. (60 fps)

        Me.Session.Window.SetClearColor(Color.White) ' // Sets the clear color of the window to white.

        Me.Session.AddObj(New TimeDisplay) ' // Adds the class we have created to the session+

        Me.Session.QueueRelease() ' // Adds the TimeDisplay Object to the correct container. TimeDisplay.Draw() will be run on the first tick instead of the second.
        
    End Sub
    
End Class
```

This basic implementation shows the ease of use of XApps. This is the result our program produces when run:

![image](https://user-images.githubusercontent.com/62959728/210561145-46e61597-e9f2-43e7-80f4-5512d0619247.png)

Because the time is drawn every tick, the value changes in real time. Using this basic concept, We can use XApps to develop a variety of projects.


## ========================

Not all projects need to implement the XApp logic and tick system. XApps also contains multiple classes that allow long winded processes to be performed in a much more simple and abstracted way. These classes are contained in src/SideClasses. You can use these classes to manage data in any .NET Project.

# SideClasses/3D

provides data types for representing 3D Objects in a 3D Space.

Example implementation 1: https://github.com/Thelegendseb/NEA-ShadowCasting

Example implementation 2: https://github.com/Thelegendseb/3D_Engine

Note: Uses the XApp base system as well. Good example for more advanced project that implements the above explanations.

# SideClasses/Networking

provides data types for connecting and transferring data from devices across the internet.

Example implementation: https://github.com/Thelegendseb/XApps-Networking-tests

## ========================

The other classes are basic modules that encapsulate .NET funcitonality. Made for ease of use in any project.

### More Examples that use XApps to process and display data.

# Bezier Curve teaching aide
https://user-images.githubusercontent.com/62959728/211173898-b82301b0-8325-4140-a80d-777b8f43d0b9.mp4

# RayCasting DOOM style
https://github.com/Thelegendseb/MazeMapper_CourseWorkCS2023

https://user-images.githubusercontent.com/62959728/210568365-c031915a-fb8d-4107-86ec-d7a5b3a97d18.mp4

# Asteroids multiplayer game
https://user-images.githubusercontent.com/62959728/210564470-9b93590c-64a1-4545-a491-adb64bf8887e.mp4

# Bouncing Balls
https://user-images.githubusercontent.com/62959728/219870150-21d2cdab-f0e0-48ea-bf7c-a0290d1cbcef.mp4

# Game copy of BuckShot - shown on https://www.youtube.com/watch?v=PC_pAgJopIA&ab_channel=PolyMars
https://user-images.githubusercontent.com/62959728/210564925-e8428861-cb8a-41ce-ac6d-b0a48150d20c.mp4

# Motion tracking from live webcam
https://user-images.githubusercontent.com/62959728/210570423-7f9c55c0-5092-401a-868e-49bf6e34fb28.mp4








