using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Gray.Core
{
    internal class Game
    {
        public Game()
        {

        }

        public void Run()
        {
            InitWindow(800, 600, "Game");
            SetConfigFlags(ConfigFlags.VSyncHint);
            DisableCursor();

            Camera3D camera = new Camera3D();
            camera.Projection = CameraProjection.Perspective;
            camera.Position = new Vector3(3, 3, 3);
            camera.Target = new Vector3(0, 0, 0);
            camera.Up = new Vector3(0, 1, 0);
            camera.FovY = 60;

            Model goproModel = ModelManager.LoadModel("gopro");

            while (!WindowShouldClose())
            {
                UpdateCamera(ref camera, CameraMode.Free);
                BeginDrawing();
                ClearBackground(Color.DarkGreen);
                BeginMode3D(camera);

                DrawModel(goproModel, Vector3.Zero, 1.0f, Color.White);
                DrawGrid(10, 1);

                EndMode3D();

                DrawText($"FPS: {GetFPS()}", 10, 10, 30, Color.Black);

                EndDrawing();

                if (IsKeyDown(KeyboardKey.F11))
                {
                    ToggleFullscreen();
                }
            }

            ModelManager.UnloadAll();
            CloseWindow();
        }
    }
}
