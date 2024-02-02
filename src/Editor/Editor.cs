using System.Numerics;
using Raylib_cs;

class Editor
{
	// TODO: Combine in dictionary or something
	private static List<Model> models;
	private static string[] modelFiles;

	private static List<PlacedModel> placedModels;

	public static string command;

	public static void Start()
	{
		models = new List<Model>();
		placedModels = new List<PlacedModel>();

		// Load in all of the different assets and stuff
		LoadAssets();

		//! debug
		placedModels.Add(new PlacedModel(models[1]));
	}

	public static void CleanUp()
	{
		UnloadAssets();
	}


	public static void Update()
	{
		ListenForCommand();
	}

	// 3D
	public static void Render()
	{
		// Draw all the models
		foreach (PlacedModel model in placedModels)
		{
			// TODO: Add rotation
			Raylib.DrawModelEx(model.Model, model.Rotation, Vector3.Zero, 0f, model.Scale, model.Color);
		}
	}

	// 2D
	public static void Draw()
	{
		// Get all of the model indexes for spawning and stuff
		string modelIndexes = "";
		for (int i = 0; i < modelFiles.Length; i++)
		{
			modelIndexes += $"{i}\t{modelFiles[i]}\n";
		}
		Raylib.DrawText(modelIndexes, 100, 100, 30, Color.BEIGE);

		// Draw the command thingy
		Raylib.DrawText(command, 10, Raylib.GetScreenHeight() - 50, 40, Color.DARKBROWN);
	}



	private static void ListenForCommand()
	{
		// Add the key that was pressed, but ignore if its movement keys
		// TODO: Copy blender movement
		if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE)) command = "";
		else if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
		{
			RunCommand();
			command = "";
		}
		else if (!(Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_D)))
		{
			int keyboardInput = Raylib.GetCharPressed();
			if (keyboardInput != 0) command += (char)keyboardInput;
		}
	}


	private static void RunCommand()
	{
		// Split up the command into different parts, like numbers and whatnot
		// then perform the operations on the object
		command = command.Trim();

		//! temp or something idk
		// TODO: Use different system
		if (command[0] == 'n') // New object
		{
			// Get the model index to add
			int index = int.Parse(command.Remove(0, 1));
			if (index > modelFiles.Length || index < 0)
			{
				Console.WriteLine("Not valid index");
				return;
			}

			// Add a new model
			placedModels.Add(new PlacedModel(models[index]));
			Console.WriteLine("Added new model");

			// TODO: Text on the side showing the model with the color text of the model or something idk
		}



		// a + "x" will spawn in modelIndex of x
		// g + x/y/z + 00000... will move around last thing placed
		// r + x/y/z + 00000... will rotate last thing placed
		// del wil remove last thing placed

	}


	// TODO: Do textures also. Just give random color for now
	private static void LoadAssets()
	{
		// Get all of the different .obj files in the map-assets directory
		// TODO: Pull directly from the assets folder of an actual game
		modelFiles = Directory.GetFiles("./map-assets/models", "*.obj");

		// Load in the model
		foreach (string modelPath in modelFiles)
		{
			models.Add(Raylib.LoadModel(modelPath));
		}
	}



	private static void UnloadAssets()
	{
		// Unload all of the models
		foreach (Model model in models)
		{
			Raylib.UnloadModel(model);
		}
	}
}



struct PlacedModel
{
	public Model Model;
	public Color Color;
	public Vector3 Position = Vector3.Zero;
	public Vector3 Rotation = Vector3.Zero;
	public Vector3 Scale = Vector3.One;

	public PlacedModel(Model model)
	{
		Model = model;

		// Apply a random color
		Color = new Color(Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), Raylib.GetRandomValue(0, 255), 255);
	}
}