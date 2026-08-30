#version 330 core
layout(location = 0) in vec3 aPosition;

uniform mat4 ModelMatrix;
uniform mat4 ProjectionMatrix;

void main()
{
	gl_Position = ProjectionMatrix * ModelMatrix * vec4(aPosition, 1.0);
}