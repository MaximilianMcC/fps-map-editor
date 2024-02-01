using System.Numerics;
using Raylib_cs;

class Editor
{
	private static List<Model> models;
	private static List<PlacedModel> placedModels;

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
		
	}

	public static void Render()
	{
		foreach (PlacedModel model in placedModels)
		{
			// TODO: Add rotation
			Raylib.DrawModelEx(model.Model, model.Rotation, Vector3.Zero, 0f, model.Scale, model.Color);
		}
	}



	// TODO: Do textures also. Just give random color for now
	private static void LoadAssets()
	{
		// Get all of the different .obj files in the map-assets directory
		// TODO: Pull directly from the assets folder of an actual game
		string[] modelFiles = Directory.GetFiles("./map-assets/models", "*.obj");

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