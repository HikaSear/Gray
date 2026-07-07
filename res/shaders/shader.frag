#version 330
in vec2 fragTexCoord;
in vec3 fragNormal;
in vec3 fragPosition;
out vec4 finalColor;
uniform sampler2D texture0;
void main() {
    vec4 texColor = texture(texture0, fragTexCoord);
    vec3 lightPos = vec3(5.0, 10.0, 5.0); // Позиция нашего солнца
    vec3 lightDir = normalize(lightPos - fragPosition);
    
    // Считаем угол между светом и гранью (диффузное освещение)
    float diff = max(dot(fragNormal, lightDir), 0.0);
    
    // Эмбиент (минимальный свет в тени, чтобы не было абсолютно черным)
    vec3 ambient = vec3(0.2, 0.2, 0.2); 
    vec3 lighting = ambient + vec3(diff);
    
    finalColor = vec4(texColor.rgb * lighting, texColor.a);
}