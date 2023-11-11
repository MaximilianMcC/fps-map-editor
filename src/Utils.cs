class Utils
{	
	// Linear Interpolate
	public static float Lerp(float start, float end, float progress)
	{
		return start + (end - start) * progress;
	}
}