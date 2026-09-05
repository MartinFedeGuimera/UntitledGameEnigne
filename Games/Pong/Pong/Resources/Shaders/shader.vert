#version 330 core
layout(location = 0) in vec2 aPosition;

uniform mat4 ModelMatrix;
uniform mat4 ProjectionMatrix;

void main()
{
	gl_Position = ProjectionMatrix * ModelMatrix * vec4(aPosition, 0.0, 1.0);
}