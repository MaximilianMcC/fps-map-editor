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

	// Make a new map file
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

		// Load the map that we just made
		Parse(fileName);
	}

	// Load a map file
	public Map(string filepath)
	{
		Parse(filepath);
	}

	// Load a map
	private void Parse(string filePath)
	{
		// Get the contents of the filepath
		string[] rawContents = File.ReadAllLines(filePath);

		// Remove comments
		// TODO: Add support for `//` style also
		List<string> contentsNoComments = new List<string>();
		const string commentPrefix = "#";
		for (int i = 0; i < rawContents.Length; i++)
		{
			// Get the current line
			string line = rawContents[i];

			// Check for if the entire line is a comment or empty
			if (line == "" || line.StartsWith(commentPrefix)) continue;

			// Check for if a portion of a line is a comment
			int commentIndex = line.IndexOf(commentPrefix);
			// if (commentIndex >= 0) line = line.Substring(commentIndex, line.Length - commentIndex);
			if (commentIndex >= 0) line = line.Substring(0, commentIndex);

			// Add the line without comment to the list of comment-less lines
			contentsNoComments.Add(line);
		}

		//! debug print map file
		foreach (string line in contentsNoComments)
		{
			Console.WriteLine(line);
		}

	}
}