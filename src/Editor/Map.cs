using System.Numerics;
using Raylib_cs;

struct Location
{
	public Model Model { get; set; }
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public Texture2D Texture { get; set; }
}

class Map
{
	public string Name { get; set; }
	public List<Texture2D> Textures { get; set; }
	public List<Model> Models { get; set; }
	public List<Location> Things { get; set; }

	public Map(string path, string name)
	{
		Console.WriteLine("Making map");

		// Get the filename
		string fileName = name.ToLower();
		fileName = fileName.Replace(' ', '-');
		fileName = fileName.Replace('\\', '\0').Replace('/', '\0').Replace(':', '\0').Replace('*', '\0').Replace('?', '\0').Replace('"', '\0').Replace('<', '\0').Replace('>', '\0').Replace('|', '\0').Replace('#', '\0');
		if (fileName == "") fileName = "myVeryFirstMapThatImMakingWithFPSMapEditor";

		// Write to the file. Add the name, and end section
		string contents = $"{name}\n---\nend";

		// Make the actual file for the map
		fileName = $"{path}/{fileName}.map";
		File.WriteAllText(fileName, contents);
	}
}