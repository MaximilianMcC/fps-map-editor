using Raylib_cs;

class LeftPanel
{
	public const float WIDTH = 350;

	private static List<ModelInfo> models = new List<ModelInfo>();

	public static void Start()
	{
		// Get all of the objs/models that are 
		// in the "./map-assets/models" directory
		// and add them to a list so they can be used
		// in the panel
		const string modelsDirectory = "./map-assets/models";
		string[] files = Directory.GetFiles(modelsDirectory);
		files = files.Where(file => file.EndsWith(".obj")).ToArray();

		// Loop through all files and add them to the menu list thingy
		// TODO: Also add previews of them
		for (int i = 0; i < files.Length; i++)
		{
			models.Add(new ModelInfo(files[i]));
		}
	}

	public static void Update()
	{

	}

	public static void Draw()
	{
		// Draw the main panel background
		Rectangle panel = new Rectangle(0, 0, WIDTH, Raylib.GetScreenHeight());
		Raylib.DrawRectangleRec(panel, Colors.Background);

		// Draw all the models
		//! this is just temp for now
		for (int i = 0; i < models.Count; i++)
		{
			Raylib.DrawText(models[i].Name, 10, i * 10, 10, Colors.Text);
		}
	}
}