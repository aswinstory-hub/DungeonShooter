using Raylib_cs;
using System.Numerics;

class Game
{
    // INTERNAL GAME RESOLUTION
    const int GAME_WIDTH = 320;
    const int GAME_HEIGHT = 180;

    // WINDOW SIZE
    const int WINDOW_WIDTH = 1280;
    const int WINDOW_HEIGHT = 720;

    RenderTexture2D target;

    public Game()
    {
        Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Platformer");

        Raylib.SetTargetFPS(60);

        // CREATE INTERNAL RENDER TEXTURE
        target = Raylib.LoadRenderTexture(GAME_WIDTH, GAME_HEIGHT);

        // ENABLE NEAREST-NEIGHBOR FILTERING
        Raylib.SetTextureFilter(
            target.Texture,
            TextureFilter.Point
        );
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }

        Raylib.UnloadRenderTexture(target);

        Raylib.CloseWindow();
    }

    void Update()
    {

    }

    void Draw()
    {
        //
        // DRAW EVERYTHING TO SMALL INTERNAL RESOLUTION
        //
        Raylib.BeginTextureMode(target);

        Raylib.ClearBackground(Color.Black);

        // TEST RECTANGLE
        Raylib.DrawRectangle(100, 80, 16, 16, Color.Red);

        Raylib.EndTextureMode();

        //
        // DRAW SCALED RESULT TO SCREEN
        //
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.Black);

        Rectangle source = new Rectangle(
            0,
            0,
            target.Texture.Width,
            -target.Texture.Height
        );

        Rectangle destination = new Rectangle(
            0,
            0,
            WINDOW_WIDTH,
            WINDOW_HEIGHT
        );

        Raylib.DrawTexturePro(
            target.Texture,
            source,
            destination,
            Vector2.Zero,
            0f,
            Color.White
        );

        Raylib.EndDrawing();
    }
}