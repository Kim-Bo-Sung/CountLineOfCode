using System.Runtime.InteropServices;

namespace MyCommon
{
    internal class MyDwm
    {
        // DwmSetWindowAttribute와 함께 사용합니다.
        // 어두운 모드 시스템 설정을 사용할 때 이 창의 창 프레임을 어두운 모드 색으로 그릴 수 있습니다.
        // 호환성을 위해 모든 창은 시스템 설정에 관계없이 기본적으로 라이트 모드로 설정됩니다.
        // pvAttribute 매개 변수는 BOOL 형식의 값을 가리킵니다.
        // TRUE 이면 창의 어두운 모드를 적용하고 FALSE 는 항상 광원 모드를 사용합니다.
        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            int attribute = IsWindows10OrGreater(18985) 
                ? (int)DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE 
                : (int)DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
            return DwmSetWindowAttribute(handle, attribute, ref enabled, sizeof(int)) == 0;
        }

        // DWM (Descktop Window Manager)
        // Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window.
        // For programming guidance, and code examples, see Controlling non-client region rendering.
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref bool pvAttrValue, int cbAttrSize);

        // 개발 S/W 운용 환경이 Window 10 또는 그보다 높은지 확인해서 bool 값을 리턴해주는 메소드.
        private static bool IsWindows10OrGreater(int build = -1)
            => Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;

        [Flags]
        public enum DwmWindowAttribute : uint
        {
            DWMWA_NCRENDERING_ENABLED,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_PASSIVE_UPDATE_MODE,
            DWMWA_USE_HOSTBACKDROPBRUSH,
            DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19,
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_WINDOW_CORNER_PREFERENCE = 33,
            DWMWA_BORDER_COLOR,
            DWMWA_CAPTION_COLOR,
            DWMWA_TEXT_COLOR,
            DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,
            DWMWA_SYSTEMBACKDROP_TYPE,
            DWMWA_LAST
        }
    }
}
