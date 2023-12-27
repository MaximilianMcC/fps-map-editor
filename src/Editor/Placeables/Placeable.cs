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
		Raylib.DrawModel(Model, Position, 1, Color.WHITE);
	}

    public override string ToString()
    {
        return Name;
    }
}