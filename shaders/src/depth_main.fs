//------------------------------------------------------------------------------
// Depth
//------------------------------------------------------------------------------

void main() {
#if defined(BLEND_MODE_MASKED)
    MaterialInputs inputs;
    initMaterial(inputs);
    material(inputs);

    float alpha = inputs.baseColor.a;
    if (alpha < getMaskThreshold()) {
        discard;
    }
#endif

    if (frameUniforms.padding1 > 0.0) {
        // clip -> window coordinates
        gl_FragDepth = (vertex_positionZ * 0.5 * gl_FragCoord.w) + 0.5;
        fragColor = vec4(0.0);
    } else {
        gl_FragDepth = gl_FragCoord.z;
    }
}
