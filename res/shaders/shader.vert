#version 330
in vec3 vertexPosition;
in vec2 vertexTexCoord;
in vec3 vertexNormal;
out vec2 fragTexCoord;
out vec3 fragNormal;
out vec3 fragPosition;
uniform mat4 mvp;
uniform mat4 matModel;
void main() {
    fragTexCoord = vertexTexCoord;
    fragNormal = normalize(vec3(matModel * vec4(vertexNormal, 0.0)));
    fragPosition = vec3(matModel * vec4(vertexPosition, 1.0));
    gl_Position = mvp * vec4(vertexPosition, 1.0);
}