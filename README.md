# Map Editor
Very basic map editor made for creating maps for my FPS game. This is my first time making a 3D map editor.

There will be basically no mouse use. It will all be controlled by shortcuts because efficient👍

## wireframe
none of this is confirmed to happen its just idea
![wireframe plan](https://i.imgur.com/Ek1wa8T.png)

### version 2
This is the second version of this program. I was making the first one from scratch with RayLib, but now I'm making it with awt swing because I just want a final product
### version 3
switching back to raylib, and using imgui 

# Map file plan
planning of what the map will look like.
```py
# Map name
Example Map

# A line (>= 3 '-') separates the map into sections
---

# All of the different objects, and their path
# assets/model/ automatically applied. Same as .obj
1 wall
2 floor
3 desk
4 chair
# ...

# A line (>= 3 '-') separates the map into sections
---

# All of the different textures and their path
# assets/texture/ automatically applied. Same as .png
1 wall1
2 wall2
3 wall3
4 wall4
5 wall5
6 floor1
7 floor2
8 floor3
9 floor4
10 floor5
11 desk
12 chair
# ...

# A line (>= 3 '-') separates the map into sections
---

# Model(model id), Position (vector 3), rotation(vector 3), and texture(texture id) of all objects in map
# TODO: Eventually find a way to make it so that if there were multiple of the same thing together, like walls, it would combine into a single model and just either stick multiple textures, or one big texture onto it to save geometry. Since maps and stuff will be super small there will prolly be no performance increase, but its still good to do
1 0 0 0 0 0 0 3  # Wall at 0, 0, 0, with no rotation and the wall3 texture

# A line (>= 3 '-') separates the map into sections
---
# If the parser doesn't get to the end then there is something wrong
end
```