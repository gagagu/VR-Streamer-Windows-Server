using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Gagagu_VR_Streamer_Server
{
    class LenseCorrectionShader : ShaderEffect
    {
        public LenseCorrectionShader(PixelShader shader)
        {
            PixelShader = shader;
            UpdateShaderValue(InputProperty);
        }

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(LenseCorrectionShader), 0);
    }
}
