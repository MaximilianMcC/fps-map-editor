using System.Numerics;
using Raylib_cs;

class Placeable
{
	public string Name { get; set; }

	// Transform stuff
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public Vector3 Scale { get; set; }

	// 3D stuff
	public Model Model { get; private set; }

	public Placeable(string modelPath)
	{
		// Load in the model
		Model model = Raylib.LoadModel(modelPath);
		Model = model;

		// Set default transform values
		Position = Vector3.Zero;
		Rotation = Vector3.Zero;
		Scale = Vector3.One;

		// Get a name
		Name = modelPath.Split("\\")[1].Replace("-", " ").Replace(".obj", "");
	}

	public void Render()
	{
		Console.WriteLine("Rendering the " + Name + " rn");
		// Raylib.DrawModelEx(Model, Position, Rotation, 0f, Scale, Color.WHITE);
		// Raylib.DrawModelEx(Model, Vector3.Zero, new Vector3(0f, 1f, 0f), 90f, Vector3.One, Color.WHITE);
		// Raylib.DrawModelEx(Model, Vector3.Zero, new Vector3(30f, 10f, 20f), 0f, Vector3.One, Color.WHITE);
		// Raylib.DrawModelEx(Model, Vector3.Zero, new Vector3(30, 45, 0), 0f, Vector3.One, Color.WHITE);
		// Raylib.DrawCube(new Vector3(0, 0, -10), 10, 10, 10, Color.RED);

		float size = 1f;
		Mesh mesh = Raylib.GenMeshCube(size, size, size);
		Model model = Raylib.LoadModelFromMesh(mesh);
		// model.transform = new Matrix4x4()
	}

	public override string ToString()
	{
		return Name;
	}
}