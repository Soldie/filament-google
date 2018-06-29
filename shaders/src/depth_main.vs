void main() {
#if defined(VERTEX_DOMAIN_DEVICE)
    gl_Position = getSkinnedPosition();
#else
    MaterialVertexInputs material;
    initMaterialVertex(material);
    gl_Position = getClipFromWorldMatrix() * material.worldPosition;
#endif

    if (frameUniforms.padding1 > 0.0) {
        vertex_positionZ = gl_Position.z;
        gl_Position.z = 0.0; // prevent z-clipping
    }
}
