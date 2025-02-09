namespace MyCommon
{
    internal class MyRender : ToolStripProfessionalRenderer
    {
        public MyRender() : base(new MyColorTable()) { }
    }

    public class MyColorTable : ProfessionalColorTable
    {
        /// <summary> Gets the solid background color of the System.Windows.Forms.ToolStripDropDown. </summary>
        public override Color ToolStripDropDownBackground => Color.FromArgb(31, 31, 31);
        /// <summary> Gets the starting color of the gradient used when the System.Windows.Forms.ToolStripMenuItem is selected. </summary>
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(46, 46, 46);
        /// <summary> Gets the end color of the gradient used when the System.Windows.Forms.ToolStripMenuItem is selected. </summary>
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(46, 46, 46);
        /// <summary> Gets the starting color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu. </summary>
        public override Color ImageMarginGradientBegin => Color.FromArgb(51, 51, 51);
        /// <summary> Gets the middle color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu. </summary>
        public override Color ImageMarginGradientMiddle => Color.FromArgb(51, 51, 51);
        /// <summary> Gets the end color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu. </summary>
        public override Color ImageMarginGradientEnd => Color.FromArgb(51, 51, 51);
        /// <summary> Gets the solid selected color of the  System.Windows.Forms.ToolStripMenuItem. </summary>
        public override Color MenuItemSelected => Color.FromArgb(56, 56, 56);
        /// <summary> Gets the color that is the border color to use on a System.Windows.Forms.MenuStrip. </summary>
        public override Color MenuBorder => Color.FromArgb(62, 62, 62);
        /// <summary> Gets the starting color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem is pressed. </summary>
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(66, 66, 66);
        /// <summary> Gets the end color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem is pressed. </summary>
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(66, 66, 66);
        /// <summary> Gets the color to use to for shadow effects on the System.Windows.Forms.ToolStripSeparator. </summary>
        public override Color SeparatorDark => Color.FromArgb(88, 88, 88);
        /// <summary> Gets the border color to use with a System.Windows.Forms.ToolStripMenuItem. </summary>
        public override Color MenuItemBorder => Color.FromArgb(112, 112, 112);
    }
}
